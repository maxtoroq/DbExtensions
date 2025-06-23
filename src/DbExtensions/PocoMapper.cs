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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DbExtensions;

using MetaAccessor = Metadata.MetaAccessor;

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

      if (type is null) throw new ArgumentNullException(nameof(type));

      _type = type;
   }

   protected override Node
   CreateRootNode() =>
      new PocoNode(_type, default, isComplex: true);

   protected override Node
   CreateSimpleProperty(Node container, string propertyName, int columnOrdinal) {

      var property = GetProperty(((PocoNode)container).UnderlyingType, propertyName);

      if (property is null) {
         return null;
      }

      return new PocoNode(property, columnOrdinal);
   }

   protected override Node
   CreateComplexProperty(Node container, string propertyName) {

      var property = GetProperty(((PocoNode)container).UnderlyingType, propertyName);

      if (property is null) {
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

      if (property is null) {
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

      if (property is null) {
         return property;
      }

      if (!property.CanWrite) {
         throw new InvalidOperationException($"'{property.ReflectedType.FullName}' property '{property.Name}' doesn't have a setter.");
      }

      return property;
   }
}

class PocoNode : Node {

   static readonly ConcurrentDictionary<PropertyInfo, MetaAccessor>
   _accessorsCache = new();

   readonly MetaAccessor
   _accessor;

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

   public override string
   PropertyName => Property?.Name;

   public ParameterInfo
   Parameter { get; }

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

      _accessor = GetAccessor(property);
   }

   internal
   PocoNode(ParameterInfo parameter, int columnOrdinal = default, bool isComplex = default)
      : this(parameter.ParameterType, columnOrdinal, isComplex) {

      this.Parameter = parameter;
   }

   static MetaAccessor
   GetAccessor(PropertyInfo property) =>
      _accessorsCache.GetOrAdd(property, p => Metadata.PropertyAccessor.Create(p.ReflectedType, p, null));

   internal static CollectionAccessor
   GetCollectionAccessor(PropertyInfo property) =>
      (CollectionAccessor)_accessorsCache.GetOrAdd(property, p => CollectionAccessor.Create(p.ReflectedType, p));

   public override object
   Create(IDataRecord record, MappingContext context) {

      if (this.Constructor is null) {
         return ObjectFactory.CreateInstance(this.Type);
      }

      var args = this.ConstructorParameters
         .Select(m => m.Value.Map(record, context))
         .ToArray();

      if (this.ConstructorParameters.Any(p => context.ConvertingNodes.Contains(p.Value))
         || args.All(v => v is null)) {

         // args already converted on MapSimple() call
         return CreateInstance(args);
      }

      try {
         return CreateInstance(args);

      } catch (InvalidCastException) {

         var converted = false;
         var i = -1;

         foreach (var pair in this.ConstructorParameters) {

            i++;
            var value = args[i];

            if (value is null) {
               continue;
            }

            var paramNode = (PocoNode)pair.Value;

            if (!paramNode.Type.IsAssignableFrom(value.GetType())) {

               context.Log?.WriteLine($"-- WARNING: Couldn't instantiate {this.UnderlyingType.FullName} with argument '{paramNode.Parameter.Name}' of type {paramNode.Type.FullName} {((value is null) ? "to null" : $"with value of type '{value.GetType().FullName}'")}. Attempting conversion.");

               args[i] = paramNode.ConvertValue(value);

               context.ConvertingNodes.Add(paramNode);

               converted = true;
            }
         }

         if (converted) {
            return CreateInstance(args);
         }

         throw;
      }
   }

   object
   CreateInstance(object[] args) =>
      ObjectFactory.CreateInstance(this.Constructor, args);

   protected override object
   MapSimple(IDataRecord record, MappingContext context) {

      var value = base.MapSimple(record, context);

      if (value is not null
         && context.ConvertingNodes.Contains(this)) {

         value = ConvertValue(value);
      }

      return value;
   }

   protected override object
   Get(object instance) =>
      GetProperty(instance);

   protected override void
   Set(object instance, object value, MappingContext context) {

      if (this.IsComplex) {
         SetProperty(instance, value);
         return;
      }

      try {
         SetSimple(instance, value, context);

      } catch (Exception ex) {
         throw new InvalidCastException($"Couldn't set '{this.Property.ReflectedType.FullName}' property '{this.Property.Name}' of type '{this.Type.FullName}' {((value is null) ? "to null" : $"with value of type '{value.GetType().FullName}'")}.", ex);
      }
   }

   void
   SetSimple(object instance, object value, MappingContext context) {

      if (value is null
         || context.ConvertingNodes.Contains(this)) {

         // value is already converted on MapSimple() call
         SetProperty(instance, value);
         return;
      }

      try {
         SetProperty(instance, value);

      } catch (InvalidCastException) {

         context.Log?.WriteLine($"-- WARNING: Couldn't set '{this.Property.ReflectedType.FullName}' property '{this.Property.Name}' of type '{this.Property.PropertyType.FullName}' {((value is null) ? "to null" : $"with value of type '{value.GetType().FullName}'")}. Attempting conversion.");

         value = ConvertValue(value);

         context.ConvertingNodes.Add(this);

         SetProperty(instance, value);
      }
   }

   object
   GetProperty(object instance) =>
      _accessor.GetBoxedValue(instance);

   void
   SetProperty(object instance, object value) =>
      _accessor.SetBoxedValue(ref instance, value);

   public override ConstructorInfo[]
   GetConstructors(BindingFlags bindingAttr) =>
      this.UnderlyingType.GetConstructors(bindingAttr);

   object
   ConvertValue(object value) {

      if (this.UnderlyingType == typeof(bool)) {
         return ConvertToBoolean(this, value);
      }

      if (this.UnderlyingType.IsEnum) {
         return ConvertToEnum(this, value);
      }

      return ConvertTo(this, value);
   }

   static object
   ConvertToBoolean(PocoNode node, object value) {

      if (value is string s) {
         return Convert.ToBoolean(Convert.ToInt64(s, CultureInfo.InvariantCulture));
      }

      return ConvertTo(node, value);
   }

   static object
   ConvertToEnum(PocoNode node, object value) {

      if (value is string s) {
         return Enum.Parse(node.UnderlyingType, s);
      }

      return Enum.ToObject(node.UnderlyingType, value);
   }

   static object
   ConvertTo(PocoNode node, object value) =>
      Convert.ChangeType(value, node.UnderlyingType, CultureInfo.InvariantCulture);

   public override string
   ToString() {

      if (this.Parameter != null) {
         return this.Parameter.ToString();
      }

      if (this.Property != null) {
         return this.Property.DeclaringType.ToString() + ":" + this.PropertyName.ToString();
      }

      return this.Type.Name;
   }
}

class PocoCollection : CollectionNode {

   readonly PropertyInfo
   _property;

   readonly CollectionAccessor
   _accessor;

   Type
   _concreteType;

   private Type
   ConcreteType {
      get {
         if (_concreteType is null) {
            var colType = _property.PropertyType;
            _concreteType = (colType.IsAbstract || colType.IsInterface) ?
               typeof(Collection<>).MakeGenericType(_accessor.ElementType)
               : colType;
         }
         return _concreteType;
      }
   }

   public
   PocoCollection(PropertyInfo property) {

      _property = property;
      _accessor = PocoNode.GetCollectionAccessor(property);
   }

   protected override IEnumerable
   GetOrCreate(object instance, MappingContext context) {

      var collection = _accessor.GetBoxedValue(instance);

      if (collection is null) {
         collection = ObjectFactory.CreateInstance(this.ConcreteType);
         _accessor.SetBoxedValue(ref instance, collection);
      }

      return (IEnumerable)collection;
   }

   protected override void
   Add(IEnumerable collection, object element, MappingContext context) {

      var colObj = (object)collection;

      _accessor.AddBoxedElement(ref colObj, element);
   }
}

abstract class CollectionAccessor : MetaAccessor {

   public abstract Type
   ElementType { get; }

   public static CollectionAccessor
   Create(Type objectType, PropertyInfo pi) {

      var propAccessor = Metadata.PropertyAccessor.Create(objectType, pi, null);

      var colType = pi.PropertyType;
      var elementType = GetElementType(colType);

      var addMethod = colType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public, null, new[] { elementType }, null)
         ?? throw new InvalidOperationException($"Couldn't find a public 'Add' method on '{colType.FullName}'.");

      var addFn = Delegate.CreateDelegate(typeof(Action<,>)
         .MakeGenericType(colType, elementType), addMethod);

      return (CollectionAccessor)Activator.CreateInstance(
         typeof(CollectionAccessor<,,>).MakeGenericType(objectType, colType, elementType),
         BindingFlags.Instance | BindingFlags.NonPublic,
         null,
         new object[2] { propAccessor, addFn },
         null
      );
   }

   static Type
   GetElementType(Type colType) {

      var elementType = typeof(object);

      for (var type = colType; type is not null; type = type.BaseType) {

         var genericICol = type.GetInterfaces()
            .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>));

         if (genericICol is not null) {
            elementType = genericICol.GetGenericArguments()[0];
            break;
         }
      }

      return elementType;
   }

   public abstract void
   AddBoxedElement(ref object collection, object element);
}

class CollectionAccessor<TContainer, TCollection, TElement> : CollectionAccessor {

   readonly Metadata.MetaAccessor<TContainer, TCollection>
   _propAccessor;

   readonly Action<TCollection, TElement>
   _addFn;

   public override Type
   Type => _propAccessor.Type;

   public override Type
   ElementType => typeof(TElement);

   internal
   CollectionAccessor(
         Metadata.MetaAccessor<TContainer, TCollection> propAccessor,
         Action<TCollection, TElement> addFn) {

      _propAccessor = propAccessor;
      _addFn = addFn;
   }

   public TCollection
   GetValue(TContainer instance) =>
      _propAccessor.GetValue(instance);

   public void
   SetValue(ref TContainer instance, TCollection value) =>
      _propAccessor.SetValue(ref instance, value);

   public void
   AddElement(ref TCollection collection, TElement element) =>
      _addFn.Invoke(collection, element);

   public override void
   SetBoxedValue(ref object instance, object value) =>
      _propAccessor.SetBoxedValue(ref instance, value);

   public override object
   GetBoxedValue(object instance) =>
      _propAccessor.GetBoxedValue(instance);

   public override void
   AddBoxedElement(ref object collection, object element) {

      var TCol = (TCollection)collection;
      AddElement(ref TCol, (TElement)element);
      collection = TCol;
   }
}

static class ObjectFactory {

   static readonly ConcurrentDictionary<Type, Func<object>>
   _typeFactoryCache = new();

   static readonly ConcurrentDictionary<ConstructorInfo, Func<object[], object>>
   _ctorFactoryCache = new();

   public static object
   CreateInstance(Type type) =>
      _typeFactoryCache.GetOrAdd(type, CreateFactory).Invoke();

   static Func<object>
   CreateFactory(Type type) {

      var newExpr = Expression.New(type);
      var castExpr = Expression.Convert(newExpr, typeof(object));
      var lambdaExpr = Expression.Lambda<Func<object>>(castExpr);

      return lambdaExpr.Compile();
   }

   public static object
   CreateInstance(ConstructorInfo ctor, params object[] args) =>
      _ctorFactoryCache.GetOrAdd(ctor, CreateFactory).Invoke(args);

   static Func<object[], object>
   CreateFactory(ConstructorInfo ctor) {

      var parameters = ctor.GetParameters();
      var argsExpr = Expression.Parameter(typeof(object[]), "args");
      var args = new Expression[parameters.Length];

      for (var i = 0; i < parameters.Length; i++) {
         var argsIndexExpr = Expression.ArrayIndex(argsExpr, Expression.Constant(i));
         args[i] = Expression.Convert(argsIndexExpr, parameters[i].ParameterType);
      }

      var newExpr = Expression.New(ctor, args);
      var castExpr = Expression.Convert(newExpr, typeof(object));
      var lambdaExpr = Expression.Lambda<Func<object[], object>>(castExpr, argsExpr);

      return lambdaExpr.Compile();
   }
}
