// Copyright 2013-2025 Max Toro Q.
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
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace DbExtensions;

#nullable enable

partial class Database {

   /// <summary>
   /// Maps the results of the <paramref name="query"/> to dynamic objects.
   /// The query is deferred-executed.
   /// </summary>
   /// <param name="query">The query.</param>
   /// <returns>The results of the query as dynamic objects.</returns>

   public IEnumerable<dynamic>
   Map(SqlBuilder query) {

      ArgumentNullException.ThrowIfNull(query);

      var mapper = CreateDynamicMapper();

      return Map(query, r => (dynamic)mapper.DynamicMap(r));
   }

   /// <inheritdoc cref="Map(SqlBuilder)"/>

   public IAsyncEnumerable<dynamic>
   AsyncMap(SqlBuilder query) {

      ArgumentNullException.ThrowIfNull(query);

      var mapper = CreateDynamicMapper();

      return AsyncMap(query, r => (dynamic)mapper.DynamicMap(r));
   }

   internal DynamicMapper
   CreateDynamicMapper() {

      return new DynamicMapper {
         Log = this.Configuration.Log
      };
   }
}

partial class SqlSet {

   partial void
   DynamicMap(bool singleResult, SqlBuilder query, ref IEnumerable<object>? results) {

      var mapper = CreateDynamicMapper(singleResult);

      results = _db.Map(query, mapper.DynamicMap);
   }

   partial void
   DynamicAsyncMap(bool singleResult, SqlBuilder query, ref IAsyncEnumerable<object>? results) {

      var mapper = CreateDynamicMapper(singleResult);

      results = _db.AsyncMap(query, mapper.DynamicMap);
   }

   DynamicMapper
   CreateDynamicMapper(bool singleResult) {

      var mapper = _db.CreateDynamicMapper();
      mapper.SingleResult = singleResult;

      return mapper;
   }
}

sealed class DynamicMapper : Mapper {

   protected override bool
   CanUseConstructorMapping => false;

   protected override Node
   CreateRootNode() => new DynamicNode();

   protected override Node
   CreateSimpleProperty(Node container, string propertyName, int columnOrdinal) =>
      new DynamicNode(propertyName, columnOrdinal);

   protected override Node
   CreateComplexProperty(Node container, string propertyName) =>
      new DynamicNode(propertyName, isComplex: true);

   protected override Node
   CreateParameterNode(ParameterInfo paramInfo) =>
      throw new NotImplementedException();

   protected override Node
   CreateParameterNode(int columnOrdinal, ParameterInfo paramInfo) =>
      throw new NotImplementedException();

   public object
   DynamicMap(DbDataReader record) {

      var node = (DynamicNode)GetRootNode(record);
      var context = this.MappingContext;

      var instance = node.Create(record, context);
      node.Load(instance, record, context);

      return instance;
   }
}

sealed class DynamicNode : Node {

   static readonly string
   _typeName = typeof(ExpandoObject).FullName!;

   public override bool
   IsComplex { get; }

   public override string?
   PropertyName { get; }

   public override int
   ColumnOrdinal { get; }

   public override string
   TypeName => _typeName;

   internal
   DynamicNode() {
      this.IsComplex = true;
   }

   internal
   DynamicNode(string propertyName, int columnOrdinal = default, bool isComplex = default) {

      ArgumentNullException.ThrowIfNull(propertyName);

      if (propertyName.Length == 0) {
         throw new ArgumentException("Cannot map column using an empty property name.", nameof(propertyName));
      }

      if (UInt32.TryParse(propertyName, out _)) {
         throw new ArgumentException("Cannot use constructor mapping, by using numeric column names, unless you specify the type of the object you want to map to.", nameof(propertyName));
      }

      this.PropertyName = propertyName;
      this.ColumnOrdinal = columnOrdinal;
      this.IsComplex = isComplex;
   }

   public object?
   Map(DbDataReader record, MappingContext context) {

      if (this.IsComplex) {
         return MapComplex(record, context);
      }

      return MapSimple(record, context);
   }

   object?
   MapComplex(DbDataReader record, MappingContext context) {

      if (AllColumnsNull(record)) {
         return null;
      }

      var value = Create(record, context);
      Load(value, record, context);

      return value;
   }

   bool
   AllColumnsNull(DbDataReader record) {

      if (this.IsComplex) {

         return (!this.HasConstructorParameters
               || this.ConstructorParameters
                  .OrderBy(n => n.Value.IsComplex)
                  .All(n => ((DynamicNode)n.Value).AllColumnsNull(record)))
            && this.Properties
               .OrderBy(n => n.IsComplex)
               .All(n => ((DynamicNode)n).AllColumnsNull(record));
      }

      return record.IsDBNull(this.ColumnOrdinal);
   }

   object?
   MapSimple(DbDataReader record, MappingContext context) {

      var isNull = record.IsDBNull(this.ColumnOrdinal);
      var value = (isNull) ? null : record.GetValue(this.ColumnOrdinal);

      return value;
   }

   public object
   Create(DbDataReader record, MappingContext context) =>
      new ExpandoObject();

   public void
   Load(object instance, DbDataReader record, MappingContext context) {

      for (int i = 0; i < this.Properties.Count; i++) {

         var childNode = (DynamicNode)this.Properties[i];

         if (!childNode.IsComplex
            || childNode.HasConstructorParameters) {

            childNode.Read(instance, record, context);
            continue;
         }

         var currentValue = childNode.Get(instance);

         if (currentValue is not null) {
            childNode.Load(currentValue, record, context);
         } else {
            childNode.Read(instance, record, context);
         }
      }
   }

   void
   Read(object instance, DbDataReader record, MappingContext context) {

      var value = Map(record, context);
      Set(instance, value, context);
   }

   object?
   Get(object instance) {

      var dictionary = (IDictionary<string, object?>)instance;

      if (dictionary.TryGetValue(this.PropertyName!, out var value)) {
         return value;
      }

      return null;
   }

   void
   Set(object instance, object? value, MappingContext context) {
      ((IDictionary<string, object?>)instance)[this.PropertyName!] = value;
   }

   public override ConstructorInfo[]
   GetConstructors(BindingFlags bindingAttr) =>
      throw new InvalidOperationException("Cannot use constructor mapping, by using numeric column names, unless you specify the type of the object you want to map to.");
}
