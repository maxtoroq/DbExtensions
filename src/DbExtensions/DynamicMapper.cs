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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Reflection;

namespace DbExtensions;

partial class Database {

   /// <summary>
   /// Maps the results of the <paramref name="query"/> to dynamic objects.
   /// The query is deferred-executed.
   /// </summary>
   /// <param name="query">The query.</param>
   /// <returns>The results of the query as dynamic objects.</returns>

   public IEnumerable<dynamic>
   Map(SqlBuilder query) {

      var mapper = CreateDynamicMapper();

      return Map(query, r => (dynamic)mapper.Map(r));
   }

   internal Mapper
   CreateDynamicMapper() {

      return new DynamicMapper {
         Log = this.Configuration.Log
      };
   }
}

partial class SqlSet {

   IEnumerable
   DynamicMap(bool singleResult) {

      var mapper = _db.CreateDynamicMapper();
      mapper.SingleResult = singleResult;

      InitializeMapper(mapper);

      return _db.Map(GetDefiningQuery(clone: false), r => mapper.Map(r));
   }
}

class DynamicMapper : Mapper {

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

   protected override CollectionNode
   CreateCollectionNode(Node container, string propertyName) =>
      throw new NotSupportedException();
}

class DynamicNode : Node {

   static readonly string
   _typeName = typeof(ExpandoObject).FullName;

   public override bool
   IsComplex { get; }

   public override string
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

      if (propertyName is null) throw new ArgumentNullException(nameof(propertyName));
      if (propertyName.Length == 0) throw new ArgumentException("Cannot map column using an empty property name.", nameof(propertyName));

      if (UInt32.TryParse(propertyName, out _)) {
         throw new ArgumentException("Cannot use constructor mapping, by using numeric column names, unless you specify the type of the object you want to map to.", nameof(propertyName));
      }

      this.PropertyName = propertyName;
      this.ColumnOrdinal = columnOrdinal;
      this.IsComplex = isComplex;
   }

   public override object
   Create(IDataRecord record, MappingContext context) =>
      new ExpandoObject();

   protected override object
   Get(object instance) {

      var dictionary = (IDictionary<string, object>)instance;

      if (dictionary.TryGetValue(this.PropertyName, out var value)) {
         return value;
      }

      return null;
   }

   protected override void
   Set(object instance, object value, MappingContext context) {
      ((IDictionary<string, object>)instance)[this.PropertyName] = value;
   }

   public override ConstructorInfo[]
   GetConstructors(BindingFlags bindingAttr) =>
      throw new InvalidOperationException("Cannot use constructor mapping, by using numeric column names, unless you specify the type of the object you want to map to.");
}
