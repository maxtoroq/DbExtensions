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
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DbExtensions;

using Metadata;

#nullable enable

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

      ArgumentNullException.ThrowIfNull(query);

      var mapper = CreatePocoMapper(typeof(TResult));

      return Map(query, r => (TResult)mapper.PocoMap(r));
   }

   /// <inheritdoc cref="Map&lt;TResult>(SqlBuilder)"/>

   public IAsyncEnumerable<TResult>
   AsyncMap<TResult>(SqlBuilder query) {

      ArgumentNullException.ThrowIfNull(query);

      var mapper = CreatePocoMapper(typeof(TResult));

      return AsyncMap(query, r => (TResult)mapper.PocoMap(r));
   }

   /// <summary>
   /// Maps the results of the <paramref name="query"/> to objects of type
   /// specified by the <paramref name="resultType"/> parameter.
   /// The query is deferred-executed.
   /// </summary>
   /// <param name="query">The query.</param>
   /// <param name="resultType">The type of objects to map the results to.</param>
   /// <returns>The results of the query as objects of type specified by the <paramref name="resultType"/> parameter.</returns>

   public IEnumerable<object>
   Map(SqlBuilder query, Type resultType) {

      ArgumentNullException.ThrowIfNull(query);
      ArgumentNullException.ThrowIfNull(resultType);

      var mapper = CreatePocoMapper(resultType);

      return Map(query, mapper.PocoMap);
   }

   /// <inheritdoc cref="Map(SqlBuilder, Type)"/>

   public IAsyncEnumerable<object>
   AsyncMap(SqlBuilder query, Type resultType) {

      ArgumentNullException.ThrowIfNull(query);
      ArgumentNullException.ThrowIfNull(resultType);

      var mapper = CreatePocoMapper(resultType);

      return AsyncMap(query, mapper.PocoMap);
   }

   internal PocoMapper
   CreatePocoMapper(Type type) {

      return new PocoMapper(type) {
         Log = this.Configuration.Log,
      };
   }
}

partial class SqlSet {

   Dictionary<string[], CollectionLoader>?
   _manyIncludes;

   private Dictionary<string[], CollectionLoader>?
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

   private protected PocoMapper
   CreatePocoMapper(bool singleResult) {

      Debug.Assert(this.ResultType is not null);

      var mapper = _db.CreatePocoMapper(this.ResultType);
      mapper.SingleResult = singleResult;
      mapper.ManyIncludes = this.ManyIncludes;

      return mapper;
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

sealed class PocoMapper : Mapper {

   static readonly ConcurrentDictionary<CacheKey, Func<DbDataReader, MappingContext, object>>
   _compiledMapCache = new();

   static readonly ConcurrentDictionary<CacheKey, Action<DbDataReader, MappingContext, object>>
   _compiledLoadCache = new();

   readonly Type
   _type;

   Func<DbDataReader, MappingContext, object>?
   _compiledMapFn;

   Action<DbDataReader, MappingContext, object>?
   _compiledLoadFn;

   public Dictionary<string[], CollectionLoader>?
   ManyIncludes { get; set; }

   protected override bool
   CanUseConstructorMapping => true;

   public
   PocoMapper(Type type) {
      _type = type;
   }

   public object
   PocoMap(DbDataReader record) {

      if (_compiledMapFn is null) {

         var arg = new CacheArg(this, record);

         static Func<DbDataReader, MappingContext, object> fnFactory(CacheKey k, CacheArg arg) =>
            ((PocoNode)arg.Mapper.GetRootNode(arg.Record)).CompileMap();

         _compiledMapFn = (record.FieldCount > 0) ?
            _compiledMapCache.GetOrAdd(BuildCacheKey(_type, record), fnFactory, arg)
            : fnFactory(default, arg);
      }

      var instance = _compiledMapFn.Invoke(record, this.MappingContext);

      return instance;
   }

   public void
   PocoLoad(object instance, DbDataReader record) {

      if (_compiledLoadFn is null) {

         var arg = new CacheArg(this, record);

         static Action<DbDataReader, MappingContext, object> fnFactory(CacheKey k, CacheArg arg) =>
            ((PocoNode)arg.Mapper.GetRootNode(arg.Record)).CompileLoad();

         _compiledLoadFn = (record.FieldCount > 0) ?
            _compiledLoadCache.GetOrAdd(BuildCacheKey(_type, record), fnFactory, arg)
            : fnFactory(default, arg);
      }

      _compiledLoadFn.Invoke(record, this.MappingContext, instance);
   }

   static CacheKey
   BuildCacheKey(Type type, DbDataReader record) {

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

   internal Dictionary<int, List<PocoCollection>>?
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
               : String.Join('.', path, 0, path.Length - 1).GetHashCode();

            ref var containerCols = ref CollectionsMarshal.GetValueRefOrAddDefault(collectionNodes, containerHash, out var exists);

            if (!exists) {
               containerCols = new();
            }

            containerCols!.Add(col);
         }
      }

      return collectionNodes;
   }

   protected override Node
   CreateRootNode() =>
      new PocoNode(_type, default, isComplex: true);

   protected override Node?
   CreateSimpleProperty(Node container, string propertyName, int columnOrdinal) {

      var pocoContainer = (PocoNode)container;
      var property = GetProperty(pocoContainer.UnderlyingType, propertyName);

      if (property is null) {
         return null;
      }

      return new PocoNode(property, pocoContainer, columnOrdinal);
   }

   protected override Node?
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

   static PropertyInfo?
   GetProperty(Type declaringType, string propertyName) {

      var property = declaringType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

      if (property is null) {
         return property;
      }

      if (!property.CanWrite) {
         throw new InvalidOperationException($"'{property.ReflectedType!.FullName}' property '{property.Name}' doesn't have a setter.");
      }

      return property;
   }

   readonly record struct CacheKey(Type Type, string Names);

   readonly record struct CacheArg(PocoMapper Mapper, DbDataReader Record);
}

partial class MappingContext {

   public Dictionary<int, List<PocoCollection>>?
   ManyLoaders;

   public void
   LoadMany(int nodeHash, object instance, DbDataReader record) {

      if (this.ManyLoaders?.TryGetValue(nodeHash, out var colLoaders) == true
         && colLoaders.Count > 0) {

         if (this.SingleResult) {
            // if the query is expected to return a single result at most
            // we close the data reader to allow for collections to be loaded
            // using the same connection (for providers that do not support MARS)

            record.Close();
         }

         foreach (var col in colLoaders) {
            col.Load(instance, this);
         }
      }
   }
}

sealed class CollectionLoader(Func<object, IEnumerable> load, MetaAssociation association) {

   public readonly Func<object, IEnumerable>
   Load = load;

   public readonly MetaAssociation
   Association = association;
}

sealed partial class PocoNode : Node {

   static readonly ConcurrentDictionary<PropertyInfo, MetaAccessor>
   _accessorCache = new(ReferenceEqualityComparer.Instance);

   int?
   _propertyHash;

   internal const int
   RootNodeHash = 0;

   private PocoNode?
   Container { get; }

   private Type
   Type { get; }

   public Type
   UnderlyingType { get; }

   public override int
   ColumnOrdinal { get; }

   public override string
   TypeName => UnderlyingType.FullName!;

   public override bool
   IsComplex { get; }

   private PropertyInfo?
   Property { get; }

   public override string?
   PropertyName => Property?.Name;

   public int
   PropertyHash =>
      _propertyHash ??= (Property is null ? RootNodeHash
         : GetPropertyPath().GetHashCode());

   public ParameterInfo?
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

   internal static CollectionAccessor
   GetCollectionAccessor(PropertyInfo property) =>
      (CollectionAccessor)_accessorCache.GetOrAdd(property, static p => CollectionAccessor.Create(p.ReflectedType!, p));

   public override object
   Create(DbDataReader record, MappingContext context) =>
      throw new NotImplementedException();

   protected override object?
   Get(object instance) =>
      throw new NotImplementedException();

   protected override void
   Set(object instance, object? value, MappingContext context) =>
      throw new NotImplementedException();

   public override ConstructorInfo[]
   GetConstructors(BindingFlags bindingAttr) =>
      this.UnderlyingType.GetConstructors(bindingAttr);

   string
   GetPropertyPath() {

      if (this.Property is null) {
         return String.Empty;
      }

      var path = this.PropertyName!;
      var container = this.Container;

      while (container is { PropertyName: { } containerName }) {

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
         return this.Property.DeclaringType!.ToString() + ":" + this.PropertyName!.ToString();
      }

      return this.Type.Name;
   }
}

sealed class PocoCollection {

   readonly CollectionLoader
   _loader;

   readonly PropertyInfo
   _property;

   CollectionAccessor?
   _accessor;

   Type?
   _concreteType;

   Func<object>?
   _factory;

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

   private Func<object>
   Factory => _factory
      ??= ObjectFactory.GetFactory(ConcreteType);

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

   IEnumerable
   GetOrCreate(object instance, MappingContext context) {

      var collection = this.Accessor.GetBoxedValue(instance);

      if (collection is null) {
         collection = this.Factory.Invoke();
         this.Accessor.SetBoxedValue(ref instance, collection);
      }

      return (IEnumerable)collection;
   }

   void
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

      var propAccessor = PropertyAccessor.Create(objectType, pi, null);

      var colType = pi.PropertyType;
      var elementType = GetElementType(colType);

      var addMethod = colType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public, null, [elementType], null)
         ?? throw new InvalidOperationException($"Couldn't find a public 'Add' method on '{colType.FullName}'.");

      var addFn = Delegate.CreateDelegate(typeof(Action<,>)
         .MakeGenericType(colType, elementType), addMethod);

      return (CollectionAccessor)Activator.CreateInstance(
         typeof(CollectionAccessor<,,>).MakeGenericType(objectType, colType, elementType),
         BindingFlags.Instance | BindingFlags.NonPublic,
         null,
         [propAccessor, addFn],
         null)!;
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

sealed class CollectionAccessor<TContainer, TCollection, TElement> : CollectionAccessor {

   readonly MetaAccessor<TContainer, TCollection>
   _propAccessor;

   readonly Action<TCollection, TElement>
   _addFn;

   public override Type
   Type => _propAccessor.Type;

   public override Type
   ElementType => typeof(TElement);

   internal
   CollectionAccessor(
         MetaAccessor<TContainer, TCollection> propAccessor,
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
      collection = TCol!;
   }
}

static class ObjectFactory {

   static readonly ConcurrentDictionary<Type, Func<object>>
   _factoryCache = new(ReferenceEqualityComparer.Instance);

   public static Func<object>
   GetFactory(Type type) =>
      _factoryCache.GetOrAdd(type, static t => CreateFactory(t));

   static Func<object>
   CreateFactory(Type type) {

      var newExpr = Expression.New(type);
      var castExpr = Expression.Convert(newExpr, typeof(object));
      var lambdaExpr = Expression.Lambda<Func<object>>(castExpr);

      return lambdaExpr.Compile();
   }
}

partial class PocoNode {

   ColumnAttribute?
   _columnAttribute;

   private ColumnAttribute?
   ColumnAttribute => _columnAttribute
      ??= this.Property?.GetCustomAttribute<ColumnAttribute>();

   internal Func<DbDataReader, MappingContext, object>
   CompileMap() {

      var recordParam = Expression.Parameter(typeof(DbDataReader));
      var contextParam = Expression.Parameter(typeof(MappingContext));

      var statements = new List<Expression>();
      var varExpr = GenerateExpressionComplex(statements, recordParam, contextParam);
      statements.Add(Expression.Convert(varExpr, typeof(object)));

      var lambda = Expression.Lambda<Func<DbDataReader, MappingContext, object>>(
         Expression.Block([varExpr], statements),
         recordParam,
         contextParam);

      return lambda.Compile();
   }

   internal Action<DbDataReader, MappingContext, object>
   CompileLoad() {

      var recordParam = Expression.Parameter(typeof(DbDataReader));
      var contextParam = Expression.Parameter(typeof(MappingContext));
      var instanceParam = Expression.Parameter(typeof(object));
      var varExpr = Expression.Variable(this.Type);

      var statements = new List<Expression> {
         Expression.Assign(varExpr, Expression.Convert(instanceParam, varExpr.Type))
      };

      GenerateLoad(varExpr, statements, recordParam, contextParam);

      var lambda = Expression.Lambda<Action<DbDataReader, MappingContext, object>>(
         Expression.Block([varExpr], statements),
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

         if (buffer is [BinaryExpression binExpr and { NodeType: ExpressionType.Assign }]
            && binExpr.Left == exprVarExpr) {

            statements.Add(Expression.Assign(varExpr, binExpr.Right));

         } else {

            buffer.Add(Expression.Assign(varExpr, exprVarExpr));

            statements.Add(Expression.Block(
               [exprVarExpr],
               buffer));
         }

      } else {

         var isDbNulls = new List<Expression>();

         foreach (var ordinal in GetAllOrdinals()) {
            isDbNulls.Add(Expression.Call(
               recordParam,
               References.IsDbNullMethod,
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

         if (falseBuffer is [BinaryExpression binExpr and { NodeType: ExpressionType.Assign }]
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
                     [exprVarExpr],
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

         var newExpr = Expression.New(this.Constructor!, vars);
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

         var memberExpr = Expression.Property(targetExpr, prop.Property!);

         if (!prop.IsComplex
            || prop.HasConstructorParameters) {

            var buffer = new List<Expression>();
            var exprVarExpr = prop.GenerateExpressionNullable(buffer, recordParam, contextParam);

            if (buffer is [BinaryExpression binExpr and { NodeType: ExpressionType.Assign }]
               && binExpr.Left == exprVarExpr) {

               statements.Add(Expression.Assign(memberExpr, binExpr.Right));

            } else {

               buffer.Add(Expression.Assign(memberExpr, exprVarExpr));

               statements.Add(Expression.Block(
                  [exprVarExpr],
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
                  [newVarExpr],
                  falseBuffer));

            statements.Add(Expression.Block(
               [varExpr],
               buffer));
         }
      }

      if (!IsInParameter()) {

         statements.Add(Expression.Call(
            contextParam,
            References.LoadManyMethod,
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
      var columnType = convertToType ?? this.UnderlyingType;
      var typeCode = Type.GetTypeCode(columnType);
      var isEnum = this.UnderlyingType.IsEnum;

      Expression valueExpr;

      if (References.RecordGetMethods.TryGetValue(typeCode, out var recordMethod)
         && (typeCode is not TypeCode.Object || this.Type == typeof(object))) {

         valueExpr = Expression.Call(recordParam, recordMethod, ordinalExpr);

      } else {

         valueExpr = Expression.Call(
            recordParam,
            References.GetFieldValueOpenMethod.MakeGenericMethod(columnType),
            ordinalExpr);
      }

      var targetType = this.UnderlyingType;
      var targetTypeExpr = Expression.Constant(targetType, typeof(Type));

      if (convertToType != null) {

         if (convertToType == typeof(string)
            && isEnum) {

            valueExpr = Expression.Call(
               References.EnumParseOpenMethod.MakeGenericMethod(targetType),
               valueExpr);

         } else {

            valueExpr = Expression.Call(
               References.ConvertChangeTypeMethod,
               varExpr,
               targetTypeExpr,
               Expression.Property(null, References.InvariantCultureProperty));
         }

      } else if (isEnum) {

         var trueExpr = (Expression)Expression.Call(
            References.EnumParseOpenMethod.MakeGenericMethod(targetType),
            Expression.Call(recordParam, References.RecordGetMethods[TypeCode.String], ordinalExpr));

         var falseExpr = valueExpr;
         falseExpr = Expression.Convert(falseExpr, targetType);

         valueExpr = Expression.Condition(
            Expression.MakeBinary(
               ExpressionType.Equal,
               Expression.Call(recordParam, References.GetFieldTypeMethod, ordinalExpr),
               Expression.Constant(typeof(string), typeof(Type))),
            trueExpr,
            falseExpr);
      }

      if (valueExpr.Type != varExpr.Type) {
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
#pragma warning disable IDE0220
            foreach (PocoNode prop in this.Properties) {
#pragma warning restore IDE0220
               foreach (var o in prop.GetAllOrdinals()) {
                  yield return o;
               }
            }
         }

         yield break;
      }

      yield return this.ColumnOrdinal;
   }

   static class References {

      public static readonly MethodInfo
      ConvertChangeTypeMethod = typeof(Convert)
         .GetMethod(nameof(Convert.ChangeType), BindingFlags.Public | BindingFlags.Static, null, [typeof(object), typeof(Type), typeof(IFormatProvider)], null)!;

      public static readonly MethodInfo
      EnumParseOpenMethod = typeof(Enum)
         .GetMethod(nameof(Enum.Parse), 1, BindingFlags.Public | BindingFlags.Static, null, [typeof(string)], null)!;

      public static readonly MethodInfo
      GetFieldTypeMethod = typeof(DbDataReader)
         .GetMethod(nameof(DbDataReader.GetFieldType))!;

      public static readonly MethodInfo
      GetFieldValueOpenMethod = typeof(DbDataReader)
         .GetMethod(nameof(DbDataReader.GetFieldValue))!;

      public static readonly PropertyInfo
      InvariantCultureProperty = typeof(CultureInfo)
         .GetProperty(nameof(CultureInfo.InvariantCulture))!;

      public static readonly MethodInfo
      IsDbNullMethod = typeof(DbDataReader)
         .GetMethod(nameof(DbDataReader.IsDBNull))!;

      public static readonly MethodInfo
      LoadManyMethod = typeof(MappingContext)
         .GetMethod(nameof(MappingContext.LoadMany))!;

      public static readonly Dictionary<TypeCode, MethodInfo>
      RecordGetMethods = new() {
         {  TypeCode.Boolean, typeof(DbDataReader).GetMethod(nameof(DbDataReader.GetBoolean))! },
         {  TypeCode.Byte, typeof(DbDataReader).GetMethod(nameof(DbDataReader.GetByte))! },
         {  TypeCode.Char, typeof(DbDataReader).GetMethod(nameof(DbDataReader.GetChar))! },
         {  TypeCode.DateTime, typeof(DbDataReader).GetMethod(nameof(DbDataReader.GetDateTime))! },
         {  TypeCode.Decimal, typeof(DbDataReader).GetMethod(nameof(DbDataReader.GetDecimal))! },
         {  TypeCode.Double, typeof(DbDataReader).GetMethod(nameof(DbDataReader.GetDouble))! },
         {  TypeCode.Int16, typeof(DbDataReader).GetMethod(nameof(DbDataReader.GetInt16))! },
         {  TypeCode.Int32, typeof(DbDataReader).GetMethod(nameof(DbDataReader.GetInt32))! },
         {  TypeCode.Int64, typeof(DbDataReader).GetMethod(nameof(DbDataReader.GetInt64))! },
         {  TypeCode.Object, typeof(DbDataReader).GetMethod(nameof(DbDataReader.GetValue))! },
         {  TypeCode.Single, typeof(DbDataReader).GetMethod(nameof(DbDataReader.GetFloat))! },
         {  TypeCode.String, typeof(DbDataReader).GetMethod(nameof(DbDataReader.GetString))! },
      };
   }
}
