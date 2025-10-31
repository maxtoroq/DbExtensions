// Copyright 2010-2025 Max Toro Q.
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
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbExtensions;

#nullable enable

abstract partial class Mapper {

   internal static readonly char
   _pathSeparator = '$';

   Node?
   _rootNode;

   MappingContext?
   _mappingContext;

   public TextWriter?
   Log { get; set; }

   public bool
   SingleResult { get; set; }

   protected MappingContext
   MappingContext {
      get {
         if (_mappingContext is null) {

            _mappingContext = new() {
               Log = Log,
               SingleResult = SingleResult
            };

            InitializeMappingContext2(_mappingContext);
         }
         return _mappingContext;
      }
   }

   protected abstract bool
   CanUseConstructorMapping { get; }

   protected
   Mapper() { }

   void
   ReadMapping(DbDataReader record, Node rootNode) {

      var groups =
         (from i in Enumerable.Range(0, record.FieldCount)
          let columnName = record.GetName(i)
          let path = columnName.Split(_pathSeparator)
          let property = (path.Length == 1) ? columnName : path[^1]
          let assoc = (path.Length == 1) ? String.Empty : path[^2]
          let parent = (path.Length <= 2) ? String.Empty : path[^3]
          let propertyInfo = new { ColumnOrdinal = i, PropertyName = property }
          group propertyInfo by new { depth = path.Length - 1, parent, assoc } into t
          orderby t.Key.depth, t.Key.parent, t.Key.assoc
          select new MapGroup(
             t.Key.depth,
             t.Key.assoc,
             t.Key.parent,
             t.ToDictionary(p => p.ColumnOrdinal, p => p.PropertyName)))
         .ToArray();

      var topGroup = groups.Where(m => m.Depth == 0).SingleOrDefault()
         ?? new MapGroup(0, String.Empty, String.Empty, new Dictionary<int, string>());

      ReadMapping(record, groups, topGroup, rootNode);
   }

   void
   ReadMapping(DbDataReader record, MapGroup[] groups, MapGroup currentGroup, Node instance) {

      var constructorParameters = new Dictionary<uint, MapParam>();
      var unmapped = new Dictionary<string, int>();
      var unmappedGroups = new Dictionary<string, MapGroup>();

      // simple properties

      foreach (var pair in currentGroup.Properties) {

         var propertyName = pair.Value;
         var columnOrdinal = pair.Key;
         var property = CreateSimpleProperty(instance, propertyName, columnOrdinal);

         if (property is not null) {
            instance.Properties.Add(property);
            continue;
         }

         if (UInt32.TryParse(propertyName, out var paramIndex)) {
            if (!constructorParameters.TryAdd(paramIndex, new MapParam(columnOrdinal))) {
               ThrowDuplicateConstructorArgument(paramIndex, columnOrdinal, record);
            }
         } else {
            unmapped.Add(propertyName, columnOrdinal);
            this.Log?.WriteLine($"-- WARNING: Couldn't find property '{propertyName}' on type '{instance.TypeName}'. Ignoring column.");
         }
      }

      // complex properties

      foreach (var nextLevel in groups
            .Where(m => m.Depth == currentGroup.Depth + 1 && m.Parent == currentGroup.Name)) {

         var propertyName = nextLevel.Name;
         var property = CreateComplexProperty(instance, propertyName);

         if (property is not null) {

            ReadMapping(record, groups, nextLevel, property);

            instance.Properties.Add(property);
            continue;
         }

         if (UInt32.TryParse(propertyName, out var paramIndex)) {
            if (!constructorParameters.TryAdd(paramIndex, new MapParam(nextLevel))) {
               ThrowDuplicateConstructorArgument(paramIndex, default, record);
            }
         } else {
            unmappedGroups.Add(propertyName, nextLevel);
            this.Log?.WriteLine($"-- WARNING: Couldn't find property '{propertyName}' on type '{instance.TypeName}'. Ignoring column(s).");
         }
      }

      if (!this.CanUseConstructorMapping) {
         return;
      }

      var constructors = instance
         .GetConstructors(BindingFlags.Public | BindingFlags.Instance);

      if (constructorParameters.Count > 0) {

         // choose constructor based on positional arguments

         var ctor = ChooseConstructor(constructors, instance, constructorParameters.Count);
         var parameters = ctor.GetParameters();

         var i = -1;

         foreach (var pair in constructorParameters.OrderBy(p => p.Key)) {

            i++;

            var paramIndex = pair.Key;
            var mapParam = pair.Value;
            var param = parameters[i];
            Node paramNode;

            if (mapParam.ColumnOrdinal.HasValue) {
               paramNode = CreateParameterNode(mapParam.ColumnOrdinal.Value, param);

            } else {

               paramNode = CreateParameterNode(param);
               ReadMapping(record, groups, mapParam.Group!, paramNode);
            }

            if (!instance.ConstructorParameters.TryAdd(paramIndex, paramNode)) {
               ThrowDuplicateConstructorArgument(param, mapParam.ColumnOrdinal, record);
            }
         }

         instance.Constructor = ctor;

      } else {

         ParameterInfo[] parameters;

         if (constructors.Length == 1
            && (parameters = constructors[0].GetParameters()).Length > 0) {

            // if there's a single constructor, try to bind unmaped
            // columns to constructor parameters by name

            foreach (var param in parameters) {

               var paramIndex = (uint)param.Position;

               if (unmapped.TryGetValue(param.Name!, out var columnOrdinal)) {

                  var paramNode = CreateParameterNode(columnOrdinal, param);

                  if (!instance.ConstructorParameters.TryAdd(paramIndex, paramNode)) {
                     ThrowDuplicateConstructorArgument(param, columnOrdinal, record);
                  }

                  continue;
               }

               var property = instance.Properties
                  .FirstOrDefault(p => !p.IsComplex && p.PropertyName == param.Name);

               if (property is not null) {

                  var paramNode = CreateParameterNode(property.ColumnOrdinal, param);

                  instance.Properties.Remove(property);

                  if (!instance.ConstructorParameters.TryAdd(paramIndex, paramNode)) {
                     ThrowDuplicateConstructorArgument(param, paramNode.ColumnOrdinal, record);
                  }

                  continue;
               }

               if (unmappedGroups.TryGetValue(param.Name!, out var group)) {

                  var paramNode = CreateParameterNode(param);
                  ReadMapping(record, groups, group, paramNode);

                  if (!instance.ConstructorParameters.TryAdd(paramIndex, paramNode)) {
                     ThrowDuplicateConstructorArgument(param, default, record);
                  }
               }
            }

            if (parameters.Length != instance.ConstructorParameters.Count) {
               throw new InvalidOperationException(
                  $"There are missing arguments for constructor with {parameters.Length} parameter(s) for type '{instance.TypeName}'.");
            }

            instance.Constructor = constructors[0];
         }
      }
   }

   [DoesNotReturn]
   static void
   ThrowDuplicateConstructorArgument(uint paramIndex, int? columnOrdinal, DbDataReader record) {

      var message = new StringBuilder();
      message.Append($"Already specified a positional argument {paramIndex}");

      if (columnOrdinal.HasValue) {
         message.Append($" ('{record.GetName(columnOrdinal.Value)}')");
      }

      message.Append('.');

      throw new InvalidOperationException(message.ToString());
   }

   [DoesNotReturn]
   static void
   ThrowDuplicateConstructorArgument(ParameterInfo param, int? columnOrdinal, DbDataReader record) {

      var message = new StringBuilder();
      message.Append($"Already specified an argument for parameter '{param.Name}'");

      if (columnOrdinal.HasValue) {
         message.Append($" ('{record.GetName(columnOrdinal.Value)}')");
      }

      message.Append('.');

      throw new InvalidOperationException(message.ToString());
   }

   private protected Node
   GetRootNode(DbDataReader record) {

      if (_rootNode is null) {

         var node = CreateRootNode();
         ReadMapping(record, node);

         _rootNode = node;
      }

      return _rootNode;
   }

   partial void
   InitializeMappingContext2(MappingContext context);

   protected abstract Node
   CreateRootNode();

   protected abstract Node?
   CreateSimpleProperty(Node container, string propertyName, int columnOrdinal);

   protected abstract Node?
   CreateComplexProperty(Node container, string propertyName);

   protected abstract Node
   CreateParameterNode(ParameterInfo paramInfo);

   protected abstract Node
   CreateParameterNode(int columnOrdinal, ParameterInfo paramInfo);

   static ConstructorInfo
   ChooseConstructor(ConstructorInfo[] constructors, Node node, int parameterLength) {

      constructors = constructors
         .Where(c => c.GetParameters().Length == parameterLength)
         .ToArray();

      if (constructors.Length == 0) {
         throw new InvalidOperationException(
            $"Couldn't find a public constructor with {parameterLength} parameter(s) for type '{node.TypeName}'.");
      }

      if (constructors.Length > 1) {
         throw new InvalidOperationException(
            $"Found more than one public constructors with {parameterLength} parameter(s) for type '{node.TypeName}'. Please use another constructor.");
      }

      return constructors[0];
   }

   sealed class MapGroup(int depth, string name, string parent, Dictionary<int, string> properties) {

      public readonly int
      Depth = depth;

      public readonly string
      Name = name;

      public readonly string
      Parent = parent;

      public readonly Dictionary<int, string>
      Properties = properties;
   }

   readonly struct MapParam {

      public readonly int?
      ColumnOrdinal;

      public readonly MapGroup?
      Group;

      public
      MapParam(int columnOrdinal) {

         this.ColumnOrdinal = columnOrdinal;
         this.Group = null;
      }

      public
      MapParam(MapGroup group) {

         this.ColumnOrdinal = null;
         this.Group = group;
      }
   }
}

sealed partial class MappingContext {

   public TextWriter?
   Log;

   public bool
   SingleResult;
}

abstract class Node {

   Dictionary<uint, Node>?
   _constructorParameters;

   List<Node>?
   _properties;

   public abstract bool
   IsComplex { get; }

   public abstract string?
   PropertyName { get; }

   public abstract int
   ColumnOrdinal { get; }

   public abstract string
   TypeName { get; }

   public ConstructorInfo?
   Constructor { get; internal set; }

   public Dictionary<uint, Node>
   ConstructorParameters =>
      _constructorParameters ??= new Dictionary<uint, Node>();

   public List<Node>
   Properties =>
      _properties ??= new List<Node>();

   public bool
   HasConstructorParameters =>
      _constructorParameters?.Count > 0;

   public bool
   HasProperties =>
      _properties?.Count > 0;

   public abstract ConstructorInfo[]
   GetConstructors(BindingFlags bindingAttr);
}
