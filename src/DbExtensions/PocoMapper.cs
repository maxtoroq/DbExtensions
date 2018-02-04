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
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace DbExtensions {

   partial class Database {

      /// <summary>
      /// Maps the results of the <paramref name="query"/> to <typeparamref name="TResult"/> objects.
      /// The query is deferred-executed.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="query">The query.</param>
      /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>

      public IEnumerable<TResult> Map<TResult>(SqlBuilder query) {

         Mapper mapper = CreatePocoMapper(typeof(TResult));

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

      public IEnumerable<object> Map(Type resultType, SqlBuilder query) {

         Mapper mapper = CreatePocoMapper(resultType);

         return Map(query, r => mapper.Map(r));
      }

      internal Mapper CreatePocoMapper(Type type) {

         return new PocoMapper(type) {
            Log = this.Configuration.Log
         };
      }
   }

   partial class SqlSet {

      IEnumerable PocoMap(bool singleResult) {

         Mapper mapper = this.db.CreatePocoMapper(this.ResultType);
         mapper.SingleResult = singleResult;

         InitializeMapper(mapper);

         return this.db.Map(GetDefiningQuery(clone: false), r => mapper.Map(r));
      }
   }

   class PocoMapper : Mapper {

      readonly Type type;

      public PocoMapper(Type type) {

         if (type == null) throw new ArgumentNullException(nameof(type));

         this.type = type;
      }

      protected override Node CreateRootNode() {
         return PocoNode.Root(this.type);
      }

      protected override Node CreateSimpleProperty(Node container, string propertyName, int columnOrdinal) {

         PropertyInfo property = GetProperty(((PocoNode)container).UnderlyingType, propertyName);

         if (property == null) {
            return null;
         }

         return PocoNode.Simple(columnOrdinal, property);
      }

      protected override Node CreateComplexProperty(Node container, string propertyName) {

         PropertyInfo property = GetProperty(((PocoNode)container).UnderlyingType, propertyName);

         if (property == null) {
            return null;
         }

         return PocoNode.Complex(property);
      }

      protected override Node CreateParameterNode(int columnOrdinal, ParameterInfo paramInfo) {
         return PocoNode.Simple(columnOrdinal, paramInfo);
      }

      protected override Node CreateParameterNode(ParameterInfo paramInfo) {
         return PocoNode.Root(paramInfo);
      }

      protected override CollectionNode CreateCollectionNode(Node container, string propertyName) {

         Type declaringType = ((PocoNode)container).UnderlyingType;

         PropertyInfo property = declaringType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

         if (property == null) {
            return null;
         }

         if (!typeof(IEnumerable).IsAssignableFrom(property.PropertyType)) {
            return null;
         }

         return new PocoCollection(property);
      }

      static PropertyInfo GetProperty(Type declaringType, string propertyName) {

         PropertyInfo property = declaringType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

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

      readonly Type Type;
      public readonly Type UnderlyingType;

      readonly PropertyInfo Property;
      readonly MethodInfo Setter;

      bool _IsComplex;
      int _ColumnOrdinal;

      public Func<PocoNode, object, object> ConvertFunction;
      public ParameterInfo Parameter;

      public override bool IsComplex {
         get { return _IsComplex; }
      }

      public override string PropertyName {
         get {
            if (this.Property == null) {
               return null;
            }

            return this.Property.Name;
         }
      }

      public override int ColumnOrdinal {
         get { return _ColumnOrdinal; }
      }

      public override string TypeName {
         get { return UnderlyingType.FullName; }
      }

      public static PocoNode Root(Type type) {

         var node = new PocoNode(type) {
            _IsComplex = true,
         };

         return node;
      }

      public static PocoNode Root(ParameterInfo parameter) {

         var node = Root(parameter.ParameterType);
         node.Parameter = parameter;

         return node;
      }

      public static PocoNode Complex(PropertyInfo property) {

         var node = new PocoNode(property) {
            _IsComplex = true,
         };

         return node;
      }

      public static PocoNode Simple(int columnOrdinal, PropertyInfo property) {

         var node = new PocoNode(property) {
            _ColumnOrdinal = columnOrdinal
         };

         return node;
      }

      public static PocoNode Simple(int columnOrdinal, ParameterInfo parameter) {

         var node = new PocoNode(parameter.ParameterType) {
            _ColumnOrdinal = columnOrdinal,
            Parameter = parameter
         };

         return node;
      }

      private PocoNode(Type type) {

         this.Type = type;

         bool isNullableValueType = type.IsGenericType
            && type.GetGenericTypeDefinition() == typeof(Nullable<>);

         this.UnderlyingType = (isNullableValueType) ?
            Nullable.GetUnderlyingType(type)
            : type;
      }

      private PocoNode(PropertyInfo property)
         : this(property.PropertyType) {

         this.Property = property;
         this.Setter = property.GetSetMethod(true);
      }

      public override object Create(IDataRecord record, MappingContext context) {

         if (this.Constructor == null) {
            return Activator.CreateInstance(this.Type);
         }

         object[] args = this.ConstructorParameters.Select(m => m.Value.Map(record, context)).ToArray();

         if (this.ConstructorParameters.Any(p => ((PocoNode)p.Value).ConvertFunction != null)
            || args.All(v => v == null)) {

            return this.Constructor.Invoke(args);
         }

         try {
            return this.Constructor.Invoke(args);

         } catch (ArgumentException) {

            bool convertSet = false;

            for (int i = 0; i < this.ConstructorParameters.Count; i++) {

               object value = args[i];

               if (value == null) {
                  continue;
               }

               PocoNode paramNode = (PocoNode)this.ConstructorParameters.ElementAt(i).Value;

               if (!paramNode.Type.IsAssignableFrom(value.GetType())) {

                  Func<PocoNode, object, object> convert = GetConversionFunction(value, paramNode);

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

      protected override object MapSimple(IDataRecord record, MappingContext context) {

         object value = base.MapSimple(record, context);

         Func<PocoNode, object, object> convertFn;

         if (value != null
            && (convertFn = this.ConvertFunction) != null) {

            value = convertFn(this, value);
         }

         return value;
      }

      protected override object Get(ref object instance) {
         return GetProperty(ref instance);
      }

      protected override void Set(ref object instance, object value, MappingContext context) {

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

      void SetSimple(ref object instance, object value, MappingContext context) {

         if (this.ConvertFunction != null || value == null) {
            SetProperty(ref instance, value);
            return;
         }

         try {
            SetProperty(ref instance, value);

         } catch (ArgumentException) {

            Func<PocoNode, object, object> convert = GetConversionFunction(value, this);

            context.Log?.WriteLine($"-- WARNING: Couldn't set '{this.Property.ReflectedType.FullName}' property '{this.Property.Name}' of type '{this.Property.PropertyType.FullName}' {((value == null) ? "to null" : $"with value of type '{value.GetType().FullName}'")}. Attempting conversion.");

            value = convert(this, value);

            this.ConvertFunction = convert;

            SetSimple(ref instance, value, context);
         }
      }

      object GetProperty(ref object instance) {
         return this.Property.GetValue(instance, null);
      }

      void SetProperty(ref object instance, object value) {
         this.Setter.Invoke(instance, new object[1] { value });
      }

      public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr) {
         return UnderlyingType.GetConstructors(bindingAttr);
      }

      static Func<PocoNode, object, object> GetConversionFunction(object value, PocoNode node) {

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

      static object ConvertToBoolean(PocoNode node, object value) {
         return Convert.ToBoolean(Convert.ToInt64(value, CultureInfo.InvariantCulture));
      }

      static object CastToEnum(PocoNode node, object value) {
         return Enum.ToObject(node.UnderlyingType, value);
      }

      static object ParseEnum(PocoNode node, object value) {
         return Enum.Parse(node.UnderlyingType, Convert.ToString(value, CultureInfo.InvariantCulture));
      }

      static object ConvertTo(PocoNode node, object value) {
         return Convert.ChangeType(value, node.UnderlyingType, CultureInfo.InvariantCulture);
      }
   }

   class PocoCollection : CollectionNode {

      readonly PropertyInfo property;
      readonly Type elementType;
      readonly MethodInfo addMethod;

      public PocoCollection(PropertyInfo property) {

         this.property = property;

         Type colType = this.property.PropertyType;
         this.elementType = typeof(object);

         for (Type type = colType; type != null; type = type.BaseType) {

            Type[] interfaces = type.GetInterfaces();

            Type genericICol = type.GetInterfaces()
               .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>));

            if (genericICol != null) {
               this.elementType = genericICol.GetGenericArguments()[0];
               break;
            }
         }

         this.addMethod = colType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public, null, new[] { this.elementType }, null);

         if (this.addMethod == null) {
            throw new InvalidOperationException($"Couldn't find a public 'Add' method on '{colType.FullName}'.");
         }
      }

      protected override IEnumerable GetOrCreate(ref object instance, MappingContext context) {

         object collection = this.property.GetValue(instance, null);

         if (collection == null) {

            Type collectionType = this.property.PropertyType;

            if (collectionType.IsAbstract
               || collectionType.IsInterface) {

               collection = Activator.CreateInstance(typeof(Collection<>).MakeGenericType(this.elementType));

            } else {
               collection = Activator.CreateInstance(collectionType);
            }

            this.property.SetValue(instance, collection, null);
         }

         return (IEnumerable)collection;
      }

      protected override void Add(IEnumerable collection, object element, MappingContext context) {
         this.addMethod.Invoke(collection, new[] { element });
      }
   }
}
