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
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DbExtensions;

using MetaAccessor = Metadata.MetaAccessor;
using MetaAssociation = Metadata.MetaAssociation;

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

      return Map(query, mapper.Map);
   }

   internal PocoMapper
   CreatePocoMapper(Type type) {

      return new PocoMapper(type) {
         Log = this.Configuration.Log,
         UseCompiledMapping = this.Configuration.UseCompiledMapping,
      };
   }
}

partial class DatabaseConfiguration {

   /// <summary>
   /// true to use the new cached compiled mapping implementation for POCO objects;
   /// otherwise, false. The default is false.
   /// </summary>

   public bool UseCompiledMapping { get; set; }
}

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

   IEnumerable
   PocoMap(bool singleResult) {

      var mapper = _db.CreatePocoMapper(this.ResultType);
      mapper.SingleResult = singleResult;
      mapper.ManyIncludes = this.ManyIncludes;

      return _db.Map(GetDefiningQuery(clone: false), mapper.Map);
   }
}

partial class Mapper {

   partial void
   InitializeMappingContext2(MappingContext context) {

      if (this is PocoMapper pocoMapper) {
         context.ManyLoaders = pocoMapper.GetManyLoaders();
      }

      InitializeMappingContext3(context);
   }

   partial void
   InitializeMappingContext3(MappingContext context);
}

class PocoMapper : Mapper {

   static readonly ConcurrentDictionary<CacheKey, Func<IDataRecord, MappingContext, object>>
   _compiledMapCache = new();

   static readonly ConcurrentDictionary<CacheKey, Action<IDataRecord, MappingContext, object>>
   _compiledLoadCache = new();

   readonly Type
   _type;

   Func<IDataRecord, MappingContext, object>
   _compiledMapFn;

   Action<IDataRecord, MappingContext, object>
   _compiledLoadFn;

   public Dictionary<string[], CollectionLoader>
   ManyIncludes { get; set; }

   protected override bool
   CanUseConstructorMapping => true;

   public bool
   UseCompiledMapping { get; set; }

   public
   PocoMapper(Type type) {

      if (type is null) throw new ArgumentNullException(nameof(type));

      _type = type;
   }

   public override object
   Map(IDataRecord record) {

      if (!this.UseCompiledMapping) {
         return base.Map(record);
      }

      if (_compiledMapFn is null) {

         var arg = new CacheArg(this, record);

         static Func<IDataRecord, MappingContext, object> fnFactory(CacheKey k, CacheArg arg) =>
            ((PocoNode)arg.Mapper.GetRootNode(arg.Record)).CompileMap();

         _compiledMapFn = (record.FieldCount > 0) ?
            _compiledMapCache.GetOrAdd(BuildCacheKey(_type, record), fnFactory, arg)
            : fnFactory(default, arg);
      }

      var instance = _compiledMapFn.Invoke(record, this.MappingContext);

      return instance;
   }

   public override void
   Load(object instance, IDataRecord record) {

      if (!this.UseCompiledMapping) {
         base.Load(instance, record);
         return;
      }

      if (_compiledLoadFn is null) {

         var arg = new CacheArg(this, record);

         static Action<IDataRecord, MappingContext, object> fnFactory(CacheKey k, CacheArg arg) =>
            ((PocoNode)arg.Mapper.GetRootNode(arg.Record)).CompileLoad();

         _compiledLoadFn = (record.FieldCount > 0) ?
            _compiledLoadCache.GetOrAdd(BuildCacheKey(_type, record), fnFactory, arg)
            : fnFactory(default, arg);
      }

      _compiledLoadFn.Invoke(record, this.MappingContext, instance);
   }

   static CacheKey
   BuildCacheKey(Type type, IDataRecord record) {

      var fieldCount = record.FieldCount;
      string names;

      if (fieldCount == 0) {
         names = String.Empty;
      } else if (fieldCount == 1) {
         names = record.GetName(0);
      } else {

         var sb = new StringBuilder();

         for (var i = 0; i < fieldCount; i++) {

            if (i > 0) {
               sb.Append('\n');
            }

            sb.Append(record.GetName(i));
         }

         names = sb.ToString();
      }

      return new CacheKey(type, names);
   }

   internal Dictionary<int, List<PocoCollection>>
   GetManyLoaders() {

      if (this.ManyIncludes is null or { Count: 0 }) {
         return null;
      }

      var collectionNodes = new Dictionary<int, List<PocoCollection>>();

      foreach (var pair in this.ManyIncludes) {

         var path = pair.Key;
         var col = new PocoCollection(pair.Value);

         if (col is not null) {

            var containerHash = (path.Length == 1) ?
               PocoNode.RootNodeHash
               : String.Join(".", path, 0, path.Length - 1).GetHashCode();

            List<PocoCollection> containerCols;

            if (!collectionNodes.TryGetValue(containerHash, out containerCols)) {
               containerCols = new();
               collectionNodes.Add(containerHash, containerCols);
            }

            containerCols.Add(col);
         }
      }

      return collectionNodes;
   }

   protected override Node
   CreateRootNode() =>
      new PocoNode(_type, default, isComplex: true);

   protected override Node
   CreateSimpleProperty(Node container, string propertyName, int columnOrdinal) {

      var pocoContainer = (PocoNode)container;
      var property = GetProperty(pocoContainer.UnderlyingType, propertyName);

      if (property is null) {
         return null;
      }

      return new PocoNode(property, pocoContainer, columnOrdinal);
   }

   protected override Node
   CreateComplexProperty(Node container, string propertyName) {

      var pocoContainer = (PocoNode)container;
      var property = GetProperty(pocoContainer.UnderlyingType, propertyName);

      if (property is null) {
         return null;
      }

      return new PocoNode(property, pocoContainer, isComplex: true);
   }

   protected override Node
   CreateParameterNode(int columnOrdinal, ParameterInfo paramInfo) =>
      new PocoNode(paramInfo, columnOrdinal);

   protected override Node
   CreateParameterNode(ParameterInfo paramInfo) =>
      new PocoNode(paramInfo, isComplex: true);

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

#if NET5_0_OR_GREATER
   readonly
#endif
   record struct CacheKey(Type Type, string Names);

#if NET5_0_OR_GREATER
   readonly
#endif
   record struct CacheArg(Mapper Mapper, IDataRecord Record);
}

partial class MappingContext {

   public HashSet<Node>
   ConvertingNodes = new(ReferenceEqualityComparer.Instance);

   public Dictionary<int, List<PocoCollection>>
   ManyLoaders;

   public void
   LoadMany(int nodeHash, object instance, IDataRecord record) {

      if (this.ManyLoaders?.TryGetValue(nodeHash, out var colLoaders) == true
         && colLoaders.Count > 0) {

         if (this.SingleResult) {
            // if the query is expected to return a single result at most
            // we close the data reader to allow for collections to be loaded
            // using the same connection (for providers that do not support MARS)

            var reader = record as IDataReader;
            reader?.Close();
         }

         foreach (var col in colLoaders) {
            col.Load(instance, this);
         }
      }
   }
}

class CollectionLoader {

   public Func<object, IEnumerable>
   Load;

   public MetaAssociation
   Association;
}

partial class PocoNode : Node {

   static readonly ConcurrentDictionary<PropertyInfo, MetaAccessor>
   _accessorsCache = new();

   MetaAccessor
   _accessor;

   int?
   _propertyHash;

   internal const int
   RootNodeHash = 0;

   private PocoNode
   Container { get; }

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

   public int
   PropertyHash =>
      _propertyHash ??= (Property is null ? RootNodeHash
         : GetPropertyPath().GetHashCode());

   private MetaAccessor
   PropertyAccessor =>
      _accessor ??= GetAccessor(Property);

   public ParameterInfo
   Parameter { get; }

   public bool
   CanBeNull { get; }

   internal
   PocoNode(Type type, int columnOrdinal, bool isComplex) {

      var underlyingNvt = Nullable.GetUnderlyingType(type);

      this.Type = type;
      this.UnderlyingType = underlyingNvt ?? type;
      this.ColumnOrdinal = columnOrdinal;
      this.IsComplex = isComplex;
      this.CanBeNull = !type.IsValueType || underlyingNvt is not null;
   }

   internal
   PocoNode(PropertyInfo property, PocoNode container, int columnOrdinal = default, bool isComplex = default)
      : this(property.PropertyType, columnOrdinal, isComplex) {

      this.Container = container;
      this.Property = property;
   }

   internal
   PocoNode(ParameterInfo parameter, int columnOrdinal = default, bool isComplex = default)
      : this(parameter.ParameterType, columnOrdinal, isComplex) {

      this.Parameter = parameter;
   }

   static MetaAccessor
   GetAccessor(PropertyInfo property) =>
      _accessorsCache.GetOrAdd(property, static p => Metadata.PropertyAccessor.Create(p.ReflectedType, p, null));

   internal static CollectionAccessor
   GetCollectionAccessor(PropertyInfo property) =>
      (CollectionAccessor)_accessorsCache.GetOrAdd(property, static p => CollectionAccessor.Create(p.ReflectedType, p));

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

   public override void
   Load(object instance, IDataRecord record, MappingContext context) {

      base.Load(instance, record, context);

      if (context.ManyLoaders is { Count: > 0 }
         && !IsInParameter()) {

         context.LoadMany(this.PropertyHash, instance, record);
      }
   }

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
      this.PropertyAccessor.GetBoxedValue(instance);

   void
   SetProperty(object instance, object value) =>
      this.PropertyAccessor.SetBoxedValue(ref instance, value);

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

   string
   GetPropertyPath() {

      if (this.Property is null) {
         return String.Empty;
      }

      var path = this.PropertyName;
      var container = this.Container;

      while (container is not null
         && container.PropertyName is { } containerName) {

         path = containerName + "." + path;

         container = container.Container;
      }

      return path;
   }

   bool
   IsInParameter() =>
      this.Parameter is not null
       || this.Container?.IsInParameter() == true;

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

class PocoCollection {

   readonly CollectionLoader
   _loader;

   readonly PropertyInfo
   _property;

   CollectionAccessor
   _accessor;

   Type
   _concreteType;

   private CollectionAccessor
   Accessor => _accessor
      ??= PocoNode.GetCollectionAccessor(_property);

   private Type
   ConcreteType {
      get {
         if (_concreteType is null) {
            var colType = _property.PropertyType;
            _concreteType = (colType.IsAbstract || colType.IsInterface) ?
               typeof(Collection<>).MakeGenericType(this.Accessor.ElementType)
               : colType;
         }
         return _concreteType;
      }
   }

   public
   PocoCollection(CollectionLoader loader) {
      _loader = loader;
      _property = (PropertyInfo)loader.Association.ThisMember.Member;
   }

   public void
   Load(object instance, MappingContext context) {

      var collection = GetOrCreate(instance, context);
      var elements = _loader.Load.Invoke(instance);

      foreach (var element in elements) {
         Add(collection, element, context);
      }
   }

   protected IEnumerable
   GetOrCreate(object instance, MappingContext context) {

      var collection = this.Accessor.GetBoxedValue(instance);

      if (collection is null) {
         collection = ObjectFactory.CreateInstance(this.ConcreteType);
         this.Accessor.SetBoxedValue(ref instance, collection);
      }

      return (IEnumerable)collection;
   }

   protected void
   Add(IEnumerable collection, object element, MappingContext context) {

      var colObj = (object)collection;

      this.Accessor.AddBoxedElement(ref colObj, element);
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

partial class PocoNode {

   static readonly MethodInfo
   _isDbNullMethod = typeof(IDataRecord)
      .GetMethod(nameof(IDataRecord.IsDBNull));

   static readonly MethodInfo
   _getFieldValueOpenMethod = typeof(DbDataReader)
      .GetMethod(nameof(DbDataReader.GetFieldValue));

   static readonly MethodInfo
   _loadManyMethod = typeof(MappingContext)
      .GetMethod(nameof(MappingContext.LoadMany));

   static readonly MethodInfo
   _enumParseMethod = typeof(Enum)
      .GetMethod(nameof(Enum.Parse), BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(Type), typeof(string) }, null);

   static readonly MethodInfo
   _convertChangeTypeMethod = typeof(Convert)
      .GetMethod(nameof(Convert.ChangeType), BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(object), typeof(Type), typeof(IFormatProvider) }, null);

   static readonly PropertyInfo
   _invariantCultureProperty = typeof(CultureInfo)
      .GetProperty(nameof(CultureInfo.InvariantCulture));

   ColumnAttribute
   _columnAttribute;

   private ColumnAttribute
   ColumnAttribute => _columnAttribute
      ??= this.Property?.GetCustomAttribute<ColumnAttribute>();

   internal Func<IDataRecord, MappingContext, object>
   CompileMap() {

      var recordParam = Expression.Parameter(typeof(IDataRecord));
      var contextParam = Expression.Parameter(typeof(MappingContext));

      var statements = new List<Expression>();
      var varExpr = GenerateExpressionComplex(statements, recordParam, contextParam);
      statements.Add(Expression.Convert(varExpr, typeof(object)));

      var lambda = Expression.Lambda<Func<IDataRecord, MappingContext, object>>(
         Expression.Block(new[] { varExpr }, statements),
         recordParam,
         contextParam);

      return lambda.Compile();
   }

   internal Action<IDataRecord, MappingContext, object>
   CompileLoad() {

      var recordParam = Expression.Parameter(typeof(IDataRecord));
      var contextParam = Expression.Parameter(typeof(MappingContext));
      var instanceParam = Expression.Parameter(typeof(object));

      var statements = new List<Expression>();
      GenerateLoad(instanceParam, statements, recordParam, contextParam);

      var lambda = Expression.Lambda<Action<IDataRecord, MappingContext, object>>(
         Expression.Block(statements),
         recordParam,
         contextParam,
         instanceParam);

      return lambda.Compile();
   }

   ParameterExpression
   GenerateExpressionNullable(List<Expression> statements, ParameterExpression recordParam, ParameterExpression contextParam) {

      var varExpr = Expression.Variable(this.Type);

      if (!this.CanBeNull) {

         var buffer = new List<Expression>();
         var exprVarExpr = GenerateExpression(buffer, recordParam, contextParam);

         if (buffer.Count == 1
            && buffer[0] is BinaryExpression binExpr and { NodeType: ExpressionType.Assign }
            && binExpr.Left == exprVarExpr) {

            statements.Add(Expression.Assign(varExpr, binExpr.Right));

         } else {

            buffer.Add(Expression.Assign(varExpr, exprVarExpr));

            statements.Add(Expression.Block(
               new[] { exprVarExpr },
               buffer));
         }

      } else {

         var isDbNulls = new List<Expression>();

         foreach (var ordinal in GetAllOrdinals()) {
            isDbNulls.Add(Expression.Call(
               recordParam,
               _isDbNullMethod,
               Expression.Constant(ordinal, typeof(int))));
         }

         var allNullsExpr = isDbNulls[0];

         for (var i = 1; i < isDbNulls.Count; i++) {
            allNullsExpr = Expression.MakeBinary(ExpressionType.AndAlso, allNullsExpr, isDbNulls[i]);
         }

         var falseBuffer = new List<Expression>();
         var exprVarExpr = GenerateExpression(falseBuffer, recordParam, contextParam);
         var valueExpr = (Expression)exprVarExpr;
         var simpleExpr = false;

         if (falseBuffer.Count == 1
            && falseBuffer[0] is BinaryExpression binExpr and { NodeType: ExpressionType.Assign }
            && binExpr.Left == exprVarExpr) {

            valueExpr = binExpr.Right;
            simpleExpr = true;
         }

         if (this.UnderlyingType.IsValueType) {
            valueExpr = Expression.Convert(valueExpr, this.Type);
         }

         var nullExpr = Expression.Constant(null, varExpr.Type);

         if (simpleExpr) {

            statements.Add(Expression.Assign(
               varExpr,
               Expression.Condition(
                  allNullsExpr,
                  nullExpr,
                  valueExpr)));

         } else {

            falseBuffer.Add(Expression.Assign(varExpr, valueExpr));

            statements.Add(
               Expression.IfThenElse(
                  allNullsExpr,
                  Expression.Assign(varExpr, nullExpr),
                  Expression.Block(
                     new[] { exprVarExpr },
                     falseBuffer)));
         }
      }

      return varExpr;
   }

   ParameterExpression
   GenerateExpression(List<Expression> statements, ParameterExpression recordParam, ParameterExpression contextParam) {

      var varExpr = (this.IsComplex) ?
         GenerateExpressionComplex(statements, recordParam, contextParam)
         : GenerateExpressionSimple(statements, recordParam);

      return varExpr;
   }

   ParameterExpression
   GenerateExpressionComplex(List<Expression> statements, ParameterExpression recordParam, ParameterExpression contextParam) {

      var varExpr = Expression.Variable(this.UnderlyingType);

      if (this.HasConstructorParameters) {

         var vars = new ParameterExpression[this.ConstructorParameters.Count];
         var buffer = new List<Expression>();

         var i = -1;

         foreach (var pair in this.ConstructorParameters) {

            i++;
            var paramNode = (PocoNode)pair.Value;
            vars[i] = paramNode.GenerateExpressionNullable(buffer, recordParam, contextParam);
         }

         var newExpr = Expression.New(this.Constructor, vars);
         buffer.Add(Expression.Assign(varExpr, newExpr));

         statements.Add(Expression.Block(vars, buffer));

      } else {

         var newExpr = Expression.New(this.UnderlyingType);
         statements.Add(Expression.Assign(varExpr, newExpr));
      }

      if (this.HasProperties) {
         GenerateLoad(varExpr, statements, recordParam, contextParam);
      }

      return varExpr;
   }

   void
   GenerateLoad(ParameterExpression targetExpr, List<Expression> statements, ParameterExpression recordParam, ParameterExpression contextParam) {

      var nullExpr = Expression.Constant(null);

      for (var i = 0; i < this.Properties.Count; i++) {

         var prop = (PocoNode)this.Properties[i];

         var memberExpr = Expression.Property(targetExpr, prop.Property);

         if (!prop.IsComplex
            || prop.HasConstructorParameters) {

            var buffer = new List<Expression>();
            var exprVarExpr = prop.GenerateExpressionNullable(buffer, recordParam, contextParam);

            if (buffer.Count == 1
               && buffer[0] is BinaryExpression binExpr and { NodeType: ExpressionType.Assign }
               && binExpr.Left == exprVarExpr) {

               statements.Add(Expression.Assign(memberExpr, binExpr.Right));

            } else {

               buffer.Add(Expression.Assign(memberExpr, exprVarExpr));

               statements.Add(Expression.Block(
                  new[] { exprVarExpr },
                  buffer));
            }

         } else {

            var buffer = new Expression[2];

            var varExpr = Expression.Variable(prop.Type);

            buffer[0] = Expression.Assign(varExpr, memberExpr);

            var trueBuffer = new List<Expression>();
            prop.GenerateLoad(varExpr, trueBuffer, recordParam, contextParam);

            var falseBuffer = new List<Expression>();
            var newVarExpr = prop.GenerateExpressionNullable(falseBuffer, recordParam, contextParam);
            falseBuffer.Add(Expression.Assign(memberExpr, newVarExpr));

            buffer[1] = Expression.IfThenElse(
               Expression.MakeBinary(ExpressionType.NotEqual, varExpr, nullExpr),
               (trueBuffer.Count == 1) ? trueBuffer[0] : Expression.Block(trueBuffer),
               Expression.Block(
                  new[] { newVarExpr },
                  falseBuffer));

            statements.Add(Expression.Block(
               new[] { varExpr },
               buffer));
         }
      }

      if (!IsInParameter()) {

         statements.Add(Expression.Call(
            contextParam,
            _loadManyMethod,
            Expression.Constant(this.PropertyHash),
            targetExpr,
            recordParam));
      }
   }

   ParameterExpression
   GenerateExpressionSimple(List<Expression> statements, ParameterExpression recordParam) {

      var varExpr = Expression.Variable(this.UnderlyingType);
      var ordinalExpr = Expression.Constant(this.ColumnOrdinal);

      var convertToType = this.ColumnAttribute?.ConvertTo;
      var typeCode = Type.GetTypeCode(convertToType ?? this.UnderlyingType);

      var isRecordType = typeCode
         is TypeCode.Boolean
            or TypeCode.Byte
            or TypeCode.Char
            or TypeCode.DateTime
            or TypeCode.Decimal
            or TypeCode.Double
            or TypeCode.Int16
            or TypeCode.Int32
            or TypeCode.Int64
            or TypeCode.Single
            or TypeCode.String
         || (typeCode is TypeCode.Object
            && this.Type == typeof(object));

      Expression valueExpr;

      if (isRecordType) {

         var recordMethod = typeof(IDataRecord)
            .GetMethod(typeCode switch {
               TypeCode.Single => nameof(IDataRecord.GetFloat),
               TypeCode.Object => nameof(IDataRecord.GetValue),
               _ => "Get" + typeCode.ToString()
            });

         valueExpr = Expression.Call(recordParam, recordMethod, ordinalExpr);

      } else {

         valueExpr = Expression.Call(
            Expression.Convert(recordParam, typeof(DbDataReader)),
            _getFieldValueOpenMethod.MakeGenericMethod(this.UnderlyingType),
            ordinalExpr);
      }

      if (convertToType != null) {

         var targetTypeExpr = Expression.Constant(this.UnderlyingType, typeof(Type));

         if (convertToType == typeof(string)
            && this.UnderlyingType.IsEnum) {

            valueExpr = Expression.Call(_enumParseMethod, targetTypeExpr, valueExpr);

         } else {

            valueExpr = Expression.Call(
               _convertChangeTypeMethod,
               varExpr,
               targetTypeExpr,
               Expression.Property(null, _invariantCultureProperty));
         }
      }

      if (this.UnderlyingType.IsEnum
         || convertToType != null) {

         valueExpr = Expression.Convert(valueExpr, varExpr.Type);
      }

      statements.Add(Expression.Assign(varExpr, valueExpr));

      return varExpr;
   }

   IEnumerable<int>
   GetAllOrdinals() {

      if (this.IsComplex) {

         if (this.HasConstructorParameters) {
            foreach (var pair in this.ConstructorParameters) {
               foreach (var o in ((PocoNode)pair.Value).GetAllOrdinals()) {
                  yield return o;
               }
            }
         }

         if (this.HasProperties) {
            foreach (PocoNode prop in this.Properties) {
               foreach (var o in prop.GetAllOrdinals()) {
                  yield return o;
               }
            }
         }

         yield break;
      }

      yield return this.ColumnOrdinal;
   }
}
