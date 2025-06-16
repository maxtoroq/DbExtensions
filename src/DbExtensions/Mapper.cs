﻿// Copyright 2010-2025 Max Toro Q.
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

namespace DbExtensions;

partial class SqlSet {

   Dictionary<string[], CollectionLoader>
   _manyIncludes;

   private Dictionary<string[], CollectionLoader>
   ManyIncludes {
      get => _manyIncludes;
      set {
         if (_manyIncludes is not null) {
            throw new InvalidOperationException();
         }
         _manyIncludes = value;
      }
   }

   partial void
   Initialize2(SqlSet set) {

      if (set.ManyIncludes is not null) {
         this.ManyIncludes = new Dictionary<string[], CollectionLoader>(set.ManyIncludes);
      }

      Initialize3(set);
   }

   partial void
   Initialize3(SqlSet set);

   void
   InitializeMapper(Mapper mapper) {

      mapper.ManyIncludes = this.ManyIncludes;

      InitializeMapper2(mapper);
   }

   partial void
   InitializeMapper2(Mapper mapper);
}

abstract class Mapper {

   internal static readonly char[]
   _pathSeparator = { '$' };

   Node
   _rootNode;

   Dictionary<CollectionNode, CollectionLoader>
   _manyLoaders;

   public TextWriter
   Log { get; set; }

   public Dictionary<string[], CollectionLoader>
   ManyIncludes { get; set; }

   public bool
   SingleResult { get; set; }

   protected abstract bool
   CanUseConstructorMapping { get; }

   protected
   Mapper() { }

   void
   ReadMapping(IDataRecord record, Node rootNode) {

      var groups =
         (from i in Enumerable.Range(0, record.FieldCount)
          let columnName = record.GetName(i)
          let path = columnName.Split(_pathSeparator)
          let property = (path.Length == 1) ? columnName : path[path.Length - 1]
          let assoc = (path.Length == 1) ? String.Empty : path[path.Length - 2]
          let parent = (path.Length <= 2) ? String.Empty : path[path.Length - 3]
          let propertyInfo = new { ColumnOrdinal = i, PropertyName = property }
          group propertyInfo by new { depth = path.Length - 1, parent, assoc } into t
          orderby t.Key.depth, t.Key.parent, t.Key.assoc
          select new MapGroup {
             Depth = t.Key.depth,
             Name = t.Key.assoc,
             Parent = t.Key.parent,
             Properties = t.ToDictionary(p => p.ColumnOrdinal, p => p.PropertyName)
          })
         .ToArray();

      var topGroup = groups.Where(m => m.Depth == 0).SingleOrDefault()
         ?? new MapGroup { Name = String.Empty, Parent = String.Empty, Properties = new Dictionary<int, string>() };

      ReadMapping(record, groups, topGroup, rootNode);
   }

   void
   ReadMapping(IDataRecord record, MapGroup[] groups, MapGroup currentGroup, Node instance) {

      var constructorParameters = new Dictionary<MapParam, Node>();
      var unmapped = new Dictionary<string, int>();

      foreach (var pair in currentGroup.Properties) {

         var propertyName = pair.Value;
         var columnOrdinal = pair.Key;
         var property = CreateSimpleProperty(instance, propertyName, columnOrdinal);

         if (property is not null) {
            property.Container = instance;
            instance.Properties.Add(property);
            continue;
         }

         if (UInt32.TryParse(propertyName, out var valueAsNumber)) {
            constructorParameters.Add(new MapParam(valueAsNumber, columnOrdinal), null);
         } else {
            unmapped.Add(propertyName, columnOrdinal);
            this.Log?.WriteLine("-- WARNING: Couldn't find property '{0}' on type '{1}'. Ignoring column.", propertyName, instance.TypeName);
         }
      }

      var nextLevels = groups
         .Where(m => m.Depth == currentGroup.Depth + 1 && m.Parent == currentGroup.Name)
         .ToArray();

      var unmappedGroups = new Dictionary<string, MapGroup>();

      for (int i = 0; i < nextLevels.Length; i++) {

         var nextLevel = nextLevels[i];
         var propertyName = nextLevel.Name;
         var property = CreateComplexProperty(instance, propertyName);

         if (property is not null) {

            property.Container = instance;

            ReadMapping(record, groups, nextLevel, property);

            instance.Properties.Add(property);
            continue;
         }

         if (UInt32.TryParse(propertyName, out var valueAsNumber)) {
            constructorParameters.Add(new MapParam(valueAsNumber, nextLevel), null);
         } else {
            unmappedGroups.Add(propertyName, nextLevel);
            this.Log?.WriteLine("-- WARNING: Couldn't find property '{0}' on type '{1}'. Ignoring column(s).", propertyName, instance.TypeName);
         }
      }

      if (constructorParameters.Count > 0) {

         instance.Constructor = ChooseConstructor(GetConstructors(instance), instance, constructorParameters.Count);
         var parameters = instance.Constructor.GetParameters();

         int i = 0;

         foreach (var pair in constructorParameters.OrderBy(p => p.Key.ParameterIndex)) {

            var param = parameters[i];
            Node paramNode;

            if (pair.Key.ColumnOrdinal.HasValue) {
               paramNode = CreateParameterNode(pair.Key.ColumnOrdinal.Value, param);

            } else {

               paramNode = CreateParameterNode(param);
               ReadMapping(record, groups, pair.Key.Group, paramNode);
            }

            if (instance.ConstructorParameters.ContainsKey(pair.Key.ParameterIndex)) {

               var message = new StringBuilder();
               message.Append($"Already specified an argument for parameter '{param.Name}'");

               if (pair.Key.ColumnOrdinal.HasValue) {
                  message.Append($" ('{record.GetName(pair.Key.ColumnOrdinal.Value)}')");
               }

               message.Append('.');

               throw new InvalidOperationException(message.ToString());
            }

            instance.ConstructorParameters.Add(pair.Key.ParameterIndex, paramNode);

            i++;
         }

      } else {

         ConstructorInfo[] constructors;
         ParameterInfo[] parameters;

         if (this.CanUseConstructorMapping
            && (constructors = GetConstructors(instance)).Length == 1
            && (parameters = constructors[0].GetParameters()).Length > 0) {

            foreach (var param in parameters) {

               var paramIndex = (uint)param.Position;

               if (unmapped.TryGetValue(param.Name, out var columnOrdinal)) {

                  var paramNode = CreateParameterNode(columnOrdinal, param);
                  instance.ConstructorParameters.Add(paramIndex, paramNode);
                  continue;
               }

               var property = instance.Properties
                  .FirstOrDefault(p => !p.IsComplex && p.PropertyName == param.Name);

               if (property is not null) {

                  var paramNode = CreateParameterNode(property.ColumnOrdinal, param);

                  instance.Properties.Remove(property);
                  instance.ConstructorParameters.Add(paramIndex, paramNode);
                  continue;
               }

               if (unmappedGroups.TryGetValue(param.Name, out var group)) {

                  var paramNode = CreateParameterNode(param);
                  ReadMapping(record, groups, group, paramNode);

                  instance.ConstructorParameters.Add(paramIndex, paramNode);
               }
            }

            if (parameters.Length != instance.ConstructorParameters.Count) {
               throw new InvalidOperationException(
                  $"There are missing arguments for constructor with {parameters.Length.ToStringInvariant()} parameter(s) for type '{instance.TypeName}'."
               );
            }

            instance.Constructor = constructors[0];
         }
      }

      if (instance.IsComplex
         && this.ManyIncludes is not null) {

         var includes = this.ManyIncludes
            .Where(p => p.Key.Length == currentGroup.Depth + 1)
            .Where(p => {

               if (instance.Container is null) {
                  // root node
                  return true;
               }

               var reversedBasePath = p.Key.Take(p.Key.Length - 1)
                  .Reverse()
                  .ToArray();

               var container = instance;

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
            var name = pair.Key[pair.Key.Length - 1];

            var collection = CreateCollectionNode(instance, name);

            if (collection is not null) {

               instance.Collections.Add(collection);

               _manyLoaders ??= new Dictionary<CollectionNode, CollectionLoader>();
               _manyLoaders.Add(collection, pair.Value);
            }
         }
      }
   }

   public object
   Map(IDataRecord record) {

      var node = GetRootNode(record);
      var context = CreateMappingContext();
      var instance = node.Create(record, context);

      node.Load(ref instance, record, context);

      return instance;
   }

   public void
   Load(ref object instance, IDataRecord record) {

      var node = GetRootNode(record);

      node.Load(ref instance, record, CreateMappingContext());
   }

   Node
   GetRootNode(IDataRecord record) {

      if (_rootNode is null) {
         _rootNode = CreateRootNode();
         ReadMapping(record, _rootNode);
      }

      return _rootNode;
   }

   MappingContext
   CreateMappingContext() {

      return new MappingContext {
         Log = this.Log,
         ManyLoaders = _manyLoaders,
         SingleResult = this.SingleResult
      };
   }

   protected abstract Node
   CreateRootNode();

   protected abstract Node
   CreateSimpleProperty(Node container, string propertyName, int columnOrdinal);

   protected abstract Node
   CreateComplexProperty(Node container, string propertyName);

   protected abstract Node
   CreateParameterNode(ParameterInfo paramInfo);

   protected abstract Node
   CreateParameterNode(int columnOrdinal, ParameterInfo paramInfo);

   protected abstract CollectionNode
   CreateCollectionNode(Node container, string propertyName);

   static ConstructorInfo[]
   GetConstructors(Node node) {

      var constructors = node
         .GetConstructors(BindingFlags.Public | BindingFlags.Instance);

      return constructors;
   }

   static ConstructorInfo
   ChooseConstructor(ConstructorInfo[] constructors, Node node, int parameterLength) {

      constructors = constructors
         .Where(c => c.GetParameters().Length == parameterLength)
         .ToArray();

      if (constructors.Length == 0) {
         throw new InvalidOperationException(
            $"Couldn't find a public constructor with {parameterLength.ToStringInvariant()} parameter(s) for type '{node.TypeName}'."
         );
      }

      if (constructors.Length > 1) {
         throw new InvalidOperationException(
            $"Found more than one public constructors with {parameterLength.ToStringInvariant()} parameter(s) for type '{node.TypeName}'. Please use another constructor."
         );
      }

      return constructors[0];
   }

   #region Nested Types

   class MapGroup {

      public string
      Name;

      public int
      Depth;

      public string
      Parent;

      public Dictionary<int, string>
      Properties;
   }

   class MapParam {

      public readonly uint
      ParameterIndex;

      public readonly int?
      ColumnOrdinal;

      public readonly MapGroup
      Group;

      public
      MapParam(uint parameterIndex, int columnOrdinal) {

         this.ParameterIndex = parameterIndex;
         this.ColumnOrdinal = columnOrdinal;
      }

      public
      MapParam(uint parameterIndex, MapGroup group) {

         this.ParameterIndex = parameterIndex;
         this.Group = group;
      }
   }

   #endregion
}

abstract class Node {

   Dictionary<uint, Node>
   _constructorParameters;

   List<Node>
   _properties;

   List<CollectionNode>
   _collections;

   public abstract bool
   IsComplex { get; }

   public abstract string
   PropertyName { get; }

   public abstract int
   ColumnOrdinal { get; }

   public abstract string
   TypeName { get; }

   public Node
   Container { get; internal set; }

   public ConstructorInfo
   Constructor { get; internal set; }

   public Dictionary<uint, Node>
   ConstructorParameters =>
      _constructorParameters ??= new Dictionary<uint, Node>();

   public List<Node>
   Properties =>
      _properties ??= new List<Node>();

   public List<CollectionNode>
   Collections =>
      _collections ??= new List<CollectionNode>();

   public bool
   HasConstructorParameters =>
      _constructorParameters?.Count > 0;

   public bool
   HasProperties =>
      _properties?.Count > 0;

   public bool
   HasCollections =>
      _collections?.Count > 0;

   public object
   Map(IDataRecord record, MappingContext context) {

      if (this.IsComplex) {
         return MapComplex(record, context);
      }

      return MapSimple(record, context);
   }

   protected virtual object
   MapComplex(IDataRecord record, MappingContext context) {

      if (AllColumnsNull(record)) {
         return null;
      }

      var value = Create(record, context);
      Load(ref value, record, context);

      return value;
   }

   bool
   AllColumnsNull(IDataRecord record) {

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

   protected virtual object
   MapSimple(IDataRecord record, MappingContext context) {

      var isNull = record.IsDBNull(this.ColumnOrdinal);
      var value = (isNull) ? null : record.GetValue(this.ColumnOrdinal);

      return value;
   }

   public abstract object
   Create(IDataRecord record, MappingContext context);

   public void
   Load(ref object instance, IDataRecord record, MappingContext context) {

      for (int i = 0; i < this.Properties.Count; i++) {

         var childNode = this.Properties[i];

         if (!childNode.IsComplex
            || childNode.HasConstructorParameters) {

            childNode.Read(ref instance, record, context);
            continue;
         }

         var currentValue = childNode.Get(ref instance);

         if (currentValue is not null) {
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

            var reader = record as IDataReader;
            reader?.Close();
         }

         for (int i = 0; i < this.Collections.Count; i++) {

            var collectionNode = this.Collections[i];
            collectionNode.Load(ref instance, context);
         }
      }
   }

   void
   Read(ref object instance, IDataRecord record, MappingContext context) {

      var value = Map(record, context);
      Set(ref instance, value, context);
   }

   protected abstract object
   Get(ref object instance);

   protected abstract void
   Set(ref object instance, object value, MappingContext context);

   public abstract ConstructorInfo[]
   GetConstructors(BindingFlags bindingAttr);
}

abstract class CollectionNode {

   public void
   Load(ref object instance, MappingContext context) {

      var collection = GetOrCreate(ref instance, context);
      var loader = context.ManyLoaders[this];

      var elements = loader.Load.Invoke(instance, loader.State);

      foreach (var element in elements) {
         Add(collection, element, context);
      }
   }

   protected abstract IEnumerable
   GetOrCreate(ref object instance, MappingContext context);

   protected abstract void
   Add(IEnumerable collection, object element, MappingContext context);
}

class MappingContext {

   public TextWriter
   Log;

   public IDictionary<CollectionNode, CollectionLoader>
   ManyLoaders;

   public bool
   SingleResult;
}

class CollectionLoader {

   public Func<object, object, IEnumerable>
   Load;

   public object
   State;
}
