// Copyright 2010-2018 Max Toro Q.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbExtensions {

   partial class SqlSet {

      IDictionary<string[], CollectionLoader> _ManyIncludes;

      private IDictionary<string[], CollectionLoader> ManyIncludes {
         get { return _ManyIncludes; }
         set {
            if (_ManyIncludes != null) {
               throw new InvalidOperationException();
            }
            _ManyIncludes = value;
         }
      }

      partial void Initialize2(SqlSet set) {

         if (set.ManyIncludes != null) {
            this.ManyIncludes = new Dictionary<string[], CollectionLoader>(set.ManyIncludes);
         }

         Initialize3(set);
      }

      partial void Initialize3(SqlSet set);

      void InitializeMapper(Mapper mapper) {

         mapper.ManyIncludes = this.ManyIncludes;

         InitializeMapper2(mapper);
      }

      partial void InitializeMapper2(Mapper mapper);
   }

   abstract class Mapper {

      Node rootNode;
      IDictionary<CollectionNode, CollectionLoader> manyLoaders;

      public TextWriter Log { get; set; }

      public IDictionary<string[], CollectionLoader> ManyIncludes { get; set; }

      public bool SingleResult { get; set; }

      protected Mapper() { }

      void ReadMapping(IDataRecord record, Node rootNode) {

         MapGroup[] groups =
            (from i in Enumerable.Range(0, record.FieldCount)
             let columnName = record.GetName(i)
             let path = columnName.Split('$')
             let property = (path.Length == 1) ? columnName : path[path.Length - 1]
             let assoc = (path.Length == 1) ? "" : path[path.Length - 2]
             let parent = (path.Length <= 2) ? "" : path[path.Length - 3]
             let propertyInfo = new { ColumnOrdinal = i, PropertyName = property }
             group propertyInfo by new { depth = path.Length - 1, parent, assoc } into t
             orderby t.Key.depth, t.Key.parent, t.Key.assoc
             select new MapGroup {
                Depth = t.Key.depth,
                Name = t.Key.assoc,
                Parent = t.Key.parent,
                Properties = t.ToDictionary(p => p.ColumnOrdinal, p => p.PropertyName)
             }
            ).ToArray();

         MapGroup topGroup = groups.Where(m => m.Depth == 0).SingleOrDefault()
            ?? new MapGroup { Name = "", Parent = "", Properties = new Dictionary<int, string>() };

         ReadMapping(record, groups, topGroup, rootNode);
      }

      void ReadMapping(IDataRecord record, MapGroup[] groups, MapGroup currentGroup, Node instance) {

         var constructorParameters = new Dictionary<MapParam, Node>();

         foreach (var pair in currentGroup.Properties) {

            Node property = CreateSimpleProperty(instance, pair.Value, pair.Key);

            if (property != null) {
               property.Container = instance;
               instance.Properties.Add(property);
               continue;
            }

            uint valueAsNumber;

            if (UInt32.TryParse(pair.Value, out valueAsNumber)) {
               constructorParameters.Add(new MapParam(valueAsNumber, pair.Key), null);
            } else {
               this.Log?.WriteLine("-- WARNING: Couldn't find property '{0}' on type '{1}'. Ignoring column.", pair.Value, instance.TypeName);
            }
         }

         MapGroup[] nextLevels =
            (from m in groups
             where m.Depth == currentGroup.Depth + 1 && m.Parent == currentGroup.Name
             select m).ToArray();

         for (int i = 0; i < nextLevels.Length; i++) {

            MapGroup nextLevel = nextLevels[i];
            Node property = CreateComplexProperty(instance, nextLevel.Name);

            if (property != null) {

               property.Container = instance;

               ReadMapping(record, groups, nextLevel, property);

               instance.Properties.Add(property);
               continue;
            }

            uint valueAsNumber;

            if (UInt32.TryParse(nextLevel.Name, out valueAsNumber)) {
               constructorParameters.Add(new MapParam(valueAsNumber, nextLevel), null);
            } else {
               this.Log?.WriteLine("-- WARNING: Couldn't find property '{0}' on type '{1}'. Ignoring column(s).", nextLevel.Name, instance.TypeName);
            }
         }

         if (constructorParameters.Count > 0) {

            instance.Constructor = GetConstructor(instance, constructorParameters.Count);
            ParameterInfo[] parameters = instance.Constructor.GetParameters();

            int i = 0;

            foreach (var pair in constructorParameters.OrderBy(p => p.Key.ParameterIndex)) {

               ParameterInfo param = parameters[i];
               Node paramNode;

               if (pair.Key.ColumnOrdinal.HasValue) {
                  paramNode = CreateParameterNode(pair.Key.ColumnOrdinal.Value, param);

               } else {

                  paramNode = CreateParameterNode(param);
                  ReadMapping(record, groups, pair.Key.Group, paramNode);
               }

               if (instance.ConstructorParameters.ContainsKey(pair.Key.ParameterIndex)) {

                  var message = new StringBuilder();
                  message.AppendFormat(CultureInfo.InvariantCulture, "Already specified an argument for parameter '{0}'", param.Name);

                  if (pair.Key.ColumnOrdinal.HasValue) {
                     message.AppendFormat(CultureInfo.InvariantCulture, " ('{0}')", record.GetName(pair.Key.ColumnOrdinal.Value));
                  }

                  message.Append(".");

                  throw new InvalidOperationException(message.ToString());
               }

               instance.ConstructorParameters.Add(pair.Key.ParameterIndex, paramNode);

               i++;
            }
         }

         if (instance.IsComplex
            && this.ManyIncludes != null) {

            var includes = this.ManyIncludes
               .Where(p => p.Key.Length == currentGroup.Depth + 1)
               .Where(p => {

                  if (instance.Container == null) {
                     // root node
                     return true;
                  }

                  string[] reversedBasePath = p.Key.Take(p.Key.Length - 1).Reverse().ToArray();

                  Node container = instance;

                  for (int i = 0; i < reversedBasePath.Length; i++) {

                     if (container.PropertyName != reversedBasePath[i]) {
                        return false;
                     }

                     container = container.Container;
                  }

                  return true;
               })
               .ToArray();

            for (int i = 0; i < includes.Length; i++) {

               var pair = includes[i];

               string name = pair.Key[pair.Key.Length - 1];

               CollectionNode collection = CreateCollectionNode(instance, name);

               if (collection != null) {

                  instance.Collections.Add(collection);

                  if (this.manyLoaders == null) {
                     this.manyLoaders = new Dictionary<CollectionNode, CollectionLoader>();
                  }

                  this.manyLoaders.Add(collection, pair.Value);
               }
            }
         }
      }

      public object Map(IDataRecord record) {

         Node node = GetRootNode(record);

         MappingContext context = CreateMappingContext();

         object instance = node.Create(record, context);

         node.Load(ref instance, record, context);

         return instance;
      }

      public void Load(ref object instance, IDataRecord record) {

         Node node = GetRootNode(record);

         node.Load(ref instance, record, CreateMappingContext());
      }

      Node GetRootNode(IDataRecord record) {

         if (this.rootNode == null) {
            this.rootNode = CreateRootNode();
            ReadMapping(record, this.rootNode);
         }

         return this.rootNode;
      }

      MappingContext CreateMappingContext() {

         return new MappingContext {
            Log = this.Log,
            ManyLoaders = this.manyLoaders,
            SingleResult = this.SingleResult
         };
      }

      protected abstract Node CreateRootNode();

      protected abstract Node CreateSimpleProperty(Node container, string propertyName, int columnOrdinal);

      protected abstract Node CreateComplexProperty(Node container, string propertyName);

      protected abstract Node CreateParameterNode(ParameterInfo paramInfo);

      protected abstract Node CreateParameterNode(int columnOrdinal, ParameterInfo paramInfo);

      protected abstract CollectionNode CreateCollectionNode(Node container, string propertyName);

      static ConstructorInfo GetConstructor(Node node, int parameterLength) {

         ConstructorInfo[] constructors = node
            .GetConstructors(BindingFlags.Public | BindingFlags.Instance)
            .Where(c => c.GetParameters().Length == parameterLength)
            .ToArray();

         if (constructors.Length == 0) {
            throw new InvalidOperationException(
               String.Format(CultureInfo.InvariantCulture,
                  "Couldn't find a public constructor with {0} parameter(s) for type '{1}'.",
                  parameterLength,
                  node.TypeName
               )
            );
         }

         if (constructors.Length > 1) {
            throw new InvalidOperationException(
               String.Format(CultureInfo.InvariantCulture,
                  "Found more than one public constructors with {0} parameter(s) for type '{1}'. Please use another constructor.",
                  parameterLength,
                  node.TypeName
               )
            );
         }

         return constructors[0];
      }

      #region Nested Types

      class MapGroup {

         public string Name;
         public int Depth;
         public string Parent;
         public Dictionary<int, string> Properties;
      }

      class MapParam {

         public readonly uint ParameterIndex;
         public readonly int? ColumnOrdinal;
         public readonly MapGroup Group;

         public MapParam(uint parameterIndex, int columnOrdinal) {

            this.ParameterIndex = parameterIndex;
            this.ColumnOrdinal = columnOrdinal;
         }

         public MapParam(uint parameterIndex, MapGroup group) {

            this.ParameterIndex = parameterIndex;
            this.Group = group;
         }
      }

      #endregion
   }

   abstract class Node {

      Dictionary<uint, Node> _ConstructorParameters;
      List<Node> _Properties;
      List<CollectionNode> _Collections;

      public abstract bool IsComplex { get; }
      public abstract string PropertyName { get; }
      public abstract int ColumnOrdinal { get; }
      public abstract string TypeName { get; }

      public Node Container { get; internal set; }
      public ConstructorInfo Constructor { get; internal set; }

      public Dictionary<uint, Node> ConstructorParameters {
         get {
            return _ConstructorParameters
               ?? (_ConstructorParameters = new Dictionary<uint, Node>());
         }
      }

      public List<Node> Properties {
         get {
            return _Properties
               ?? (_Properties = new List<Node>());
         }
      }

      public List<CollectionNode> Collections {
         get {
            return _Collections
               ?? (_Collections = new List<CollectionNode>());
         }
      }

      public bool HasConstructorParameters {
         get {
            return _ConstructorParameters != null
               && _ConstructorParameters.Count > 0;
         }
      }

      public bool HasProperties {
         get {
            return _Properties != null
               && _Properties.Count > 0;
         }
      }

      public bool HasCollections {
         get {
            return _Collections != null
               && _Collections.Count > 0;
         }
      }

      public object Map(IDataRecord record, MappingContext context) {

         if (this.IsComplex) {
            return MapComplex(record, context);
         }

         return MapSimple(record, context);
      }

      protected virtual object MapComplex(IDataRecord record, MappingContext context) {

         if (AllColumnsNull(record)) {
            return null;
         }

         object value = Create(record, context);
         Load(ref value, record, context);

         return value;
      }

      bool AllColumnsNull(IDataRecord record) {

         if (this.IsComplex) {

            return (!this.HasConstructorParameters
                  || this.ConstructorParameters
                     .OrderBy(n => n.Value.IsComplex)
                     .All(n => n.Value.AllColumnsNull(record)))
               && this.Properties
                  .OrderBy(n => n.IsComplex)
                  .All(n => n.AllColumnsNull(record));
         }

         return record.IsDBNull(this.ColumnOrdinal);
      }

      protected virtual object MapSimple(IDataRecord record, MappingContext context) {

         bool isNull = record.IsDBNull(this.ColumnOrdinal);
         object value = (isNull) ? null : record.GetValue(this.ColumnOrdinal);

         return value;
      }

      public abstract object Create(IDataRecord record, MappingContext context);

      public void Load(ref object instance, IDataRecord record, MappingContext context) {

         for (int i = 0; i < this.Properties.Count; i++) {

            Node childNode = this.Properties[i];

            if (!childNode.IsComplex
               || childNode.HasConstructorParameters) {

               childNode.Read(ref instance, record, context);
               continue;
            }

            object currentValue = childNode.Get(ref instance);

            if (currentValue != null) {
               childNode.Load(ref currentValue, record, context);
            } else {
               childNode.Read(ref instance, record, context);
            }
         }

         if (this.HasCollections) {

            if (context.SingleResult) {
               // if the query is expected to return a single result at most
               // we close the data reader to allow for collections to be loaded
               // using the same connection (for providers that do not support MARS)

               IDataReader reader = record as IDataReader;
               reader?.Close();
            }

            for (int i = 0; i < this.Collections.Count; i++) {

               CollectionNode collectionNode = this.Collections[i];
               collectionNode.Load(ref instance, context);
            }
         }
      }

      void Read(ref object instance, IDataRecord record, MappingContext context) {

         object value = Map(record, context);
         Set(ref instance, value, context);
      }

      protected abstract object Get(ref object instance);

      protected abstract void Set(ref object instance, object value, MappingContext context);

      public abstract ConstructorInfo[] GetConstructors(BindingFlags bindingAttr);
   }

   abstract class CollectionNode {

      public void Load(ref object instance, MappingContext context) {

         IEnumerable collection = GetOrCreate(ref instance, context);
         CollectionLoader loader = context.ManyLoaders[this];

         IEnumerable elements = loader.Load(instance, loader.State);

         foreach (object element in elements) {
            Add(collection, element, context);
         }
      }

      protected abstract IEnumerable GetOrCreate(ref object instance, MappingContext context);

      protected abstract void Add(IEnumerable collection, object element, MappingContext context);
   }

   class MappingContext {

      public TextWriter Log;
      public IDictionary<CollectionNode, CollectionLoader> ManyLoaders;
      public bool SingleResult;
   }

   class CollectionLoader {

      public Func<object, object, IEnumerable> Load;
      public object State;
   }
}