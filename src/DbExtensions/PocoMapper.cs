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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace DbExtensions;

partial class Database {

   /// <summary>
   /// Maps the results of the <paramref name="query"/> to <typeparamref name="TResult"/> objects.
   /// The query is deferred-executed.
   /// </summary>
   /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
   /// <param name="query">The query.</param>
   /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>

   public IEnumerable<TResult>
   Map<TResult>(SqlBuilder query) {

      var mapper = CreatePocoMapper(typeof(TResult));

      return Map(query, r => (TResult)mapper.Map(r));
   }

   /// <summary>
   /// Maps the results of the <paramref name="query"/> to objects of type
   /// specified by the <paramref name="resultType"/> parameter.
   /// The query is deferred-executed.
   /// </summary>
   /// <param name="resultType">The type of objects to map the results to.</param>
   /// <param name="query">The query.</param>
   /// <returns>The results of the query as objects of type specified by the <paramref name="resultType"/> parameter.</returns>

   public IEnumerable<object>
   Map(Type resultType, SqlBuilder query) {

      var mapper = CreatePocoMapper(resultType);

      return Map(query, r => mapper.Map(r));
   }

   internal Mapper
   CreatePocoMapper(Type type) {

      return new PocoMapper(type) {
         Log = this.Configuration.Log
      };
   }
}

partial class SqlSet {

   IEnumerable
   PocoMap(bool singleResult) {

      var mapper = _db.CreatePocoMapper(this.ResultType);
      mapper.SingleResult = singleResult;

      InitializeMapper(mapper);

      return _db.Map(GetDefiningQuery(clone: false), r => mapper.Map(r));
   }
}

class PocoMapper : Mapper {

   readonly Type
   _type;

   protected override bool
   CanUseConstructorMapping => true;

   public
   PocoMapper(Type type) {

      if (type == null) throw new ArgumentNullException(nameof(type));

      _type = type;
   }

   protected override Node
   CreateRootNode() =>
      new PocoNode(_type, default, isComplex: true);

   protected override Node
   CreateSimpleProperty(Node container, string propertyName, int columnOrdinal) {

      var property = GetProperty(((PocoNode)container).UnderlyingType, propertyName);

      if (property == null) {
         return null;
      }

      return new PocoNode(property, columnOrdinal);
   }

   protected override Node
   CreateComplexProperty(Node container, string propertyName) {

      var property = GetProperty(((PocoNode)container).UnderlyingType, propertyName);

      if (property == null) {
         return null;
      }

      return new PocoNode(property, isComplex: true);
   }

   protected override Node
   CreateParameterNode(int columnOrdinal, ParameterInfo paramInfo) =>
      new PocoNode(paramInfo, columnOrdinal);

   protected override Node
   CreateParameterNode(ParameterInfo paramInfo) =>
      new PocoNode(paramInfo, isComplex: true);

   protected override CollectionNode
   CreateCollectionNode(Node container, string propertyName) {

      var declaringType = ((PocoNode)container).UnderlyingType;

      var property = declaringType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

      if (property == null) {
         return null;
      }

      if (!typeof(IEnumerable).IsAssignableFrom(property.PropertyType)) {
         return null;
      }

      return new PocoCollection(property);
   }

   static PropertyInfo
   GetProperty(Type declaringType, string propertyName) {

      var property = declaringType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

      if (property == null) {
         return property;
      }

      if (!property.CanWrite) {
         throw new InvalidOperationException($"'{property.ReflectedType.FullName}' property '{property.Name}' doesn't have a setter.");
      }

      return property;
   }
}

class PocoNode : Node {

   private Type
   Type { get; }

   public Type
   UnderlyingType { get; }

   public override int
   ColumnOrdinal { get; }

   public override string
   TypeName => UnderlyingType.FullName;

   public override bool
   IsComplex { get; }

   private PropertyInfo
   Property { get; }

   private MethodInfo
   Setter { get; }

   public override string
   PropertyName => Property?.Name;

   public ParameterInfo
   Parameter { get; }

   public Func<PocoNode, object, object>
   ConvertFunction { get; set; }

   internal
   PocoNode(Type type, int columnOrdinal, bool isComplex) {

      this.Type = type;
      this.UnderlyingType = Nullable.GetUnderlyingType(type) ?? type;
      this.ColumnOrdinal = columnOrdinal;
      this.IsComplex = isComplex;
   }

   internal
   PocoNode(PropertyInfo property, int columnOrdinal = default, bool isComplex = default)
      : this(property.PropertyType, columnOrdinal, isComplex) {

      this.Property = property;
      this.Setter = property.GetSetMethod(true);
   }

   internal
   PocoNode(ParameterInfo parameter, int columnOrdinal = default, bool isComplex = default)
      : this(parameter.ParameterType, columnOrdinal, isComplex) {

      this.Parameter = parameter;
   }

   public override object
   Create(IDataRecord record, MappingContext context) {

      if (this.Constructor == null) {
         return Activator.CreateInstance(this.Type);
      }

      var args = this.ConstructorParameters
         .Select(m => m.Value.Map(record, context))
         .ToArray();

      if (this.ConstructorParameters.Any(p => ((PocoNode)p.Value).ConvertFunction != null)
         || args.All(v => v == null)) {

         return this.Constructor.Invoke(args);
      }

      try {
         return this.Constructor.Invoke(args);

      } catch (ArgumentException) {

         var convertSet = false;

         for (int i = 0; i < this.ConstructorParameters.Count; i++) {

            var value = args[i];

            if (value == null) {
               continue;
            }

            var paramNode = (PocoNode)this.ConstructorParameters.ElementAt(i).Value;

            if (!paramNode.Type.IsAssignableFrom(value.GetType())) {

               var convert = GetConversionFunction(value, paramNode);

               context.Log?.WriteLine($"-- WARNING: Couldn't instantiate {this.UnderlyingType.FullName} with argument '{paramNode.Parameter.Name}' of type {paramNode.Type.FullName} {((value == null) ? "to null" : $"with value of type '{value.GetType().FullName}'")}. Attempting conversion.");

               paramNode.ConvertFunction = convert;

               convertSet = true;
            }
         }

         if (convertSet) {
            return Create(record, context);
         }

         throw;
      }
   }

   protected override object
   MapSimple(IDataRecord record, MappingContext context) {

      var value = base.MapSimple(record, context);

      Func<PocoNode, object, object> convertFn;

      if (value != null
         && (convertFn = this.ConvertFunction) != null) {

         value = convertFn.Invoke(this, value);
      }

      return value;
   }

   protected override object
   Get(ref object instance) =>
      GetProperty(ref instance);

   protected override void
   Set(ref object instance, object value, MappingContext context) {

      if (this.IsComplex) {
         SetProperty(ref instance, value);

      } else {

         try {
            SetSimple(ref instance, value, context);

         } catch (Exception ex) {
            throw new InvalidCastException($"Couldn't set '{this.Property.ReflectedType.FullName}' property '{this.Property.Name}' of type '{this.Type.FullName}' {((value == null) ? "to null" : $"with value of type '{value.GetType().FullName}'")}.", ex);
         }
      }
   }

   void
   SetSimple(ref object instance, object value, MappingContext context) {

      if (this.ConvertFunction != null || value == null) {
         SetProperty(ref instance, value);
         return;
      }

      try {
         SetProperty(ref instance, value);

      } catch (ArgumentException) {

         var convert = GetConversionFunction(value, this);

         context.Log?.WriteLine($"-- WARNING: Couldn't set '{this.Property.ReflectedType.FullName}' property '{this.Property.Name}' of type '{this.Property.PropertyType.FullName}' {((value == null) ? "to null" : $"with value of type '{value.GetType().FullName}'")}. Attempting conversion.");

         value = convert.Invoke(this, value);

         this.ConvertFunction = convert;

         SetSimple(ref instance, value, context);
      }
   }

   object
   GetProperty(ref object instance) =>
      this.Property.GetValue(instance, null);

   void
   SetProperty(ref object instance, object value) =>
      this.Setter.Invoke(instance, new object[1] { value });

   public override ConstructorInfo[]
   GetConstructors(BindingFlags bindingAttr) =>
      this.UnderlyingType.GetConstructors(bindingAttr);

   static Func<PocoNode, object, object>
   GetConversionFunction(object value, PocoNode node) {

      if (node.UnderlyingType == typeof(bool)) {

         if (value.GetType() == typeof(string)) {
            return ConvertToBoolean;
         }

      } else if (node.UnderlyingType.IsEnum) {

         if (value.GetType() == typeof(string)) {
            return ParseEnum;
         }

         return CastToEnum;
      }

      return ConvertTo;
   }

   static object
   ConvertToBoolean(PocoNode node, object value) =>
      Convert.ToBoolean(Convert.ToInt64(value, CultureInfo.InvariantCulture));

   static object
   CastToEnum(PocoNode node, object value) =>
      Enum.ToObject(node.UnderlyingType, value);

   static object
   ParseEnum(PocoNode node, object value) =>
      Enum.Parse(node.UnderlyingType, Convert.ToString(value, CultureInfo.InvariantCulture));

   static object
   ConvertTo(PocoNode node, object value) =>
      Convert.ChangeType(value, node.UnderlyingType, CultureInfo.InvariantCulture);
}

class PocoCollection : CollectionNode {

   readonly PropertyInfo
   _property;

   readonly Type
   _elementType;

   readonly MethodInfo
   _addMethod;

   public
   PocoCollection(PropertyInfo property) {

      _property = property;

      var colType = _property.PropertyType;
      _elementType = typeof(object);

      for (var type = colType; type != null; type = type.BaseType) {

         var interfaces = type.GetInterfaces();

         var genericICol = type.GetInterfaces()
            .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>));

         if (genericICol != null) {
            _elementType = genericICol.GetGenericArguments()[0];
            break;
         }
      }

      _addMethod = colType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public, null, new[] { _elementType }, null);

      if (_addMethod == null) {
         throw new InvalidOperationException($"Couldn't find a public 'Add' method on '{colType.FullName}'.");
      }
   }

   protected override IEnumerable
   GetOrCreate(ref object instance, MappingContext context) {

      var collection = _property.GetValue(instance, null);

      if (collection == null) {

         var collectionType = _property.PropertyType;

         if (collectionType.IsAbstract
            || collectionType.IsInterface) {

            collection = Activator.CreateInstance(typeof(Collection<>).MakeGenericType(_elementType));

         } else {
            collection = Activator.CreateInstance(collectionType);
         }

         _property.SetValue(instance, collection, null);
      }

      return (IEnumerable)collection;
   }

   protected override void
   Add(IEnumerable collection, object element, MappingContext context) =>
      _addMethod.Invoke(collection, new[] { element });
}
