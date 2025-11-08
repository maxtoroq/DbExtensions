// Copyright 2012-2025 Max Toro Q.
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
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DbExtensions;

#nullable enable

partial class SqlBuilder {

   /// <summary>
   /// Appends the WITH clause using the provided <paramref name="subQuery"/> as body named after
   /// <paramref name="alias"/>.
   /// </summary>
   /// <param name="subQuery">The sub-query to use as the body of the WITH clause.</param>
   /// <param name="alias">The alias of the sub-query.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   WITH(string alias, SqlSet subQuery) {

      ArgumentNullException.ThrowIfNull(alias);
      ArgumentNullException.ThrowIfNull(subQuery);

      return WITH(alias, subQuery.GetDefiningQuery());
   }

   /// <summary>
   /// Appends the FROM clause using the provided <paramref name="subQuery"/> as body named after
   /// <paramref name="alias"/>.
   /// </summary>
   /// <param name="subQuery">The sub-query to use as the body of the FROM clause.</param>
   /// <param name="alias">The alias of the sub-query.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   FROM(SqlSet subQuery, string alias) {

      ArgumentNullException.ThrowIfNull(subQuery);
      ArgumentNullException.ThrowIfNull(alias);

      return FROM(subQuery.GetDefiningQuery(), alias);
   }

   static partial void
   GetDefiningQueryFromObject(object? obj, ref SqlBuilder? definingQuery) =>
      definingQuery = (obj as SqlSet)?.GetDefiningQuery();
}

static partial class SQL {

   /// <summary>
   /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
   /// appending the WITH clause using the provided <paramref name="subQuery"/>
   /// and <paramref name="alias"/>.
   /// </summary>
   /// <param name="alias">The alias of the sub-query.</param>
   /// <param name="subQuery">The sub-query to use as the body of the WITH clause.</param>
   /// <returns>
   /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.WITH(string, SqlSet)"/>.
   /// </returns>

   public static SqlBuilder
   WITH(string alias, SqlSet subQuery) {

      ArgumentNullException.ThrowIfNull(alias);
      ArgumentNullException.ThrowIfNull(subQuery);

      return new SqlBuilder().WITH(alias, subQuery);
   }
}

partial class Database {

   /// <summary>
   /// Creates and returns a new <see cref="SqlSet"/> using the provided table name.
   /// </summary>
   /// <param name="tableName">The name of the table that will be the source of data for the set.</param>
   /// <returns>A new <see cref="SqlSet"/> object.</returns>

   public SqlSet
   From(string tableName) =>
      From(tableName, null);

   /// <inheritdoc cref="From(String)"/>
   /// <param name="resultType">The type of objects to map the results to.</param>

   public SqlSet
   From(string tableName, Type? resultType) {

      ArgumentNullException.ThrowIfNull(tableName);

      return new SqlSet([tableName, null], resultType, this);
   }

   /// <summary>
   /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided table name.
   /// </summary>
   /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
   /// <param name="tableName">The name of the table that will be the source of data for the set.</param>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/> object.</returns>

   public SqlSet<TResult>
   From<TResult>(string tableName) {

      ArgumentNullException.ThrowIfNull(tableName);

      return new SqlSet<TResult>([tableName, null], this);
   }

   /// <summary>This method is used by auto-generated "table" classes.</summary>
   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public SqlSet<TResult>
   From<TResult>(string tableName, string columnList) {

      ArgumentNullException.ThrowIfNull(tableName);

      return new SqlSet<TResult>([tableName, columnList], this);
   }

   /// <summary>
   /// Creates and returns a new <see cref="SqlSet"/> using the provided defining query.
   /// </summary>
   /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
   /// <returns>A new <see cref="SqlSet"/> object.</returns>

   public SqlSet
   FromQuery(SqlBuilder definingQuery) =>
      FromQuery(definingQuery, null);

   /// <inheritdoc cref="FromQuery(SqlBuilder)"/>
   /// <param name="resultType">The type of objects to map the results to.</param>

   public SqlSet
   FromQuery(SqlBuilder definingQuery, Type? resultType) {

      ArgumentNullException.ThrowIfNull(definingQuery);

      return new SqlSet(definingQuery, resultType, this);
   }

   /// <summary>
   /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided defining query.
   /// </summary>
   /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
   /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/> object.</returns>

   public SqlSet<TResult>
   FromQuery<TResult>(SqlBuilder definingQuery) {

      ArgumentNullException.ThrowIfNull(definingQuery);

      return new SqlSet<TResult>(definingQuery, this);
   }

   /// <summary>
   /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided defining query and mapper.
   /// </summary>
   /// <inheritdoc cref="FromQuery&lt;TResult>(SqlBuilder)"/>
   /// <param name="mapper">A custom mapper function that creates <typeparamref name="TResult"/> instances from the rows in the set.</param>

   public SqlSet<TResult>
   FromQuery<TResult>(SqlBuilder definingQuery, Func<DbDataReader, TResult> mapper) {

      ArgumentNullException.ThrowIfNull(definingQuery);
      ArgumentNullException.ThrowIfNull(mapper);

      return new SqlSet<TResult>(definingQuery, mapper, this);
   }
}

/// <summary>
/// Represents an immutable, connected SQL query.
/// This class cannot be instantiated, to get an instance use one of the
/// <see cref="Database.From(String)" qualifyHint="true" autoUpgrade="true"/> or
/// <see cref="Database.FromQuery(SqlBuilder)" qualifyHint="true" autoUpgrade="true"/> overloads.
/// </summary>
/// <remarks>For information on how to use SqlSet see <see href="https://maxtoroq.github.io/DbExtensions/docs/7/SqlSet.html">SqlSet Tutorial</see>.</remarks>

public partial class SqlSet : ISqlSet<SqlSet, object> {

   // definingQuery should NEVER be modified

   readonly SqlBuilder?
   _definingQuery;

   readonly string?[]?
   _fromSelect;

   readonly SqlBuffer
   _buffer;

   private protected readonly Database
   _db;

   readonly int
   _setIndex = 1;

   /// <summary>
   /// The type of objects this set returns. This property can be null.
   /// </summary>

   public Type?
   ResultType { get; }

   /// <summary>
   /// The <see cref="DbExtensions.Database"/> this set is connected to.
   /// </summary>

   public Database
   Database => _db;

   internal
   SqlSet(SqlBuilder definingQuery, Type? resultType, Database db) {

      _definingQuery = definingQuery.Clone();
      this.ResultType = resultType;
      _db = db;
   }

   internal
   SqlSet(string?[] fromSelect, Type? resultType, Database db) {

      Debug.Assert(fromSelect.Length == 2);

      _fromSelect = fromSelect;
      this.ResultType = resultType;
      _db = db;
   }

   private protected
   SqlSet(SqlSet set, SqlBuilder superQuery, Type? resultType, SqlBuffer? buffer)
      : this(set, resultType, buffer) {

      _definingQuery = superQuery;
   }

   private protected
   SqlSet(SqlSet set, string?[] fromSelect, Type? resultType, SqlBuffer? buffer)
      : this(set, resultType, buffer) {

      Debug.Assert(fromSelect.Length == 2);

      _fromSelect = fromSelect;
   }

   private
   SqlSet(SqlSet set, Type? resultType, SqlBuffer? buffer) {

      this.ResultType = resultType ?? set.ResultType;
      _setIndex += set._setIndex;
      _db = set._db;

      if (buffer is not null) {
         _buffer = buffer.Value;
      }

      Initialize2(set);
   }

   partial void
   Initialize2(SqlSet set);

   /// <summary>
   /// Returns the SQL query that is the source of data for the set.
   /// </summary>
   /// <returns>The SQL query that is the source of data for the set</returns>

   public SqlBuilder
   GetDefiningQuery() =>
      GetDefiningQuery(clone: true);

   private protected SqlBuilder
   GetDefiningQuery(bool clone = true, bool ignoreBuffer = false, bool super = false, ISqlFragment? select = null) {

      if (!ignoreBuffer
         && _buffer.HasValue) {

         return BuildQuery(select);
      }

      var query = _definingQuery;

      if (query is null) {

         Debug.Assert(_fromSelect is not null);

         query = new SqlBuilder()
            .SELECT(String.Empty);

         if (select is not null) {
            query.AppendFragment(select);
         } else {
            query.Append(_fromSelect[1] ?? "*");
         }

         query.FROM(_fromSelect[0]);

      } else if (super || select is not null) {

         query = CreateSuperQuery(query, select);

      } else if (clone) {

         query = query.Clone();
      }

      return query;
   }

   SqlBuilder
   BuildQuery(ISqlFragment? select) {

      switch (_db.Configuration.SqlDialect) {
         case SqlDialect.Default:
            return BuildQuery_Default(select);

         case SqlDialect.TSql:
            return BuildQuery_TSql(select);

         default:
            throw new NotImplementedException();
      }
   }

   SqlBuilder
   BuildQuery_Default(ISqlFragment? select) {

      var whereBuffer = _buffer.Where;
      var orderByBuffer = _buffer.OrderBy;
      var skipBuffer = _buffer.Skip;
      var takeBuffer = _buffer.Take;

      var hasWhere = whereBuffer is not null;
      var hasOrderBy = orderByBuffer is not null;
      var hasSkip = skipBuffer.HasValue;
      var hasTake = takeBuffer.HasValue;

      var query = GetDefiningQuery(ignoreBuffer: true, super: true, select: select);

      if (hasWhere) {
         query.WHERE(String.Empty)
            .AppendFragment(whereBuffer!);
      }

      if (hasOrderBy) {
         query.ORDER_BY(String.Empty)
            .AppendFragment(orderByBuffer!);
      }

      if (hasTake) {
         query.LIMIT(takeBuffer!.Value);
      }

      if (hasSkip) {
         query.OFFSET(skipBuffer!.Value);
      }

      return query;
   }

   SqlBuilder
   BuildQuery_TSql(ISqlFragment? select) {

      var whereBuffer = _buffer.Where;
      var orderByBuffer = _buffer.OrderBy;
      var skipBuffer = _buffer.Skip;
      var takeBuffer = _buffer.Take;

      var hasWhere = whereBuffer is not null;
      var hasOrderBy = orderByBuffer is not null;
      var hasSkip = skipBuffer.HasValue;
      var hasTake = takeBuffer.HasValue;

      if (hasSkip) {

         var query = GetDefiningQuery(ignoreBuffer: true, super: true, select: select);

         if (hasWhere) {
            query.WHERE(String.Empty)
               .AppendFragment(whereBuffer!);
         }

         if (hasOrderBy) {

            query.ORDER_BY(String.Empty)
               .AppendFragment(orderByBuffer!);

         } else {

            // Cannot have OFFSET without ORDER BY
            query.ORDER_BY("1");
         }

         query.OFFSET($"{skipBuffer!.Value} ROWS");

         if (hasTake) {
            query.AppendClause<FetchClause>()
               .Append($"NEXT {takeBuffer!.Value} ROWS ONLY");
         }

         return query;

      } else if (hasTake) {

         var topSelect = new SqlFragment("TOP({0}) *", (object[])[takeBuffer!.Value]);

         var query = GetDefiningQuery(ignoreBuffer: true, super: true, select: topSelect);

         if (hasWhere) {
            query.WHERE(String.Empty)
               .AppendFragment(whereBuffer!);
         }

         if (hasOrderBy) {
            query.ORDER_BY(String.Empty)
               .AppendFragment(orderByBuffer!);
         }

         if (select is not null) {

            // SELECT must be done in super query, it could remove columns used by WHERE/ORDER BY

            query = CreateSuperQuery(query, select);
         }

         return query;

      } else {

         var query = GetDefiningQuery(ignoreBuffer: true, super: true, select: select);

         if (hasWhere) {
            query.WHERE(String.Empty)
               .AppendFragment(whereBuffer!);
         }

         if (hasOrderBy) {

            query.ORDER_BY(String.Empty)
               .AppendFragment(orderByBuffer!);

            // The ORDER BY clause is invalid in subqueries, unless TOP, OFFSET or FOR XML is also specified.

            query.OFFSET("0 ROWS");
         }

         return query;
      }
   }

   SqlBuilder
   CreateSuperQuery(SqlBuilder query, ISqlFragment? select) {

      var superQuery = new SqlBuilder()
         .SELECT(String.Empty);

      if (select is not null) {
         superQuery.AppendFragment(select);
      } else {
         superQuery.Buffer.Append('*');
      }

      superQuery.FROM(query, $"dbex_set{_setIndex}");

      return superQuery;
   }

   private protected virtual SqlSet
   CreateSet(SqlBuilder superQuery, Type? resultType = null, SqlBuffer? buffer = null) =>
      new SqlSet(this, superQuery, resultType, buffer);

   private protected virtual SqlSet
   CreateSet(string?[] fromSelect, Type? resultType = null, SqlBuffer? buffer = null) =>
      new SqlSet(this, fromSelect, resultType, buffer);

   private SqlSet<TResult>
   CreateSet<TResult>(SqlBuilder superQuery, Func<DbDataReader, TResult>? mapper = null, SqlBuffer? buffer = null) =>
      new SqlSet<TResult>(this, superQuery, mapper, buffer);

   private SqlSet<TResult>
   CreateSet<TResult>(string?[] fromSelect, SqlBuffer? buffer = null) =>
      new SqlSet<TResult>(this, fromSelect, buffer);

   internal SqlSet
   Clone() =>
      CreateBufferedSet(ignoreBuffer: true, buffer: _buffer);

   SqlSet
   CreateBufferedSet(bool ignoreBuffer, SqlBuffer buffer, Type? resultType = null) {

      SqlSet set;

      if (ignoreBuffer
         && _definingQuery is null) {

         Debug.Assert(_fromSelect is not null);

         set = CreateSet(_fromSelect, resultType, buffer);

      } else {

         var query = GetDefiningQuery(ignoreBuffer: ignoreBuffer);

         set = CreateSet(query, resultType, buffer);
      }

      return set;
   }

   SqlSet<TResult>
   CreateBufferedSet<TResult>(bool ignoreBuffer, SqlBuffer buffer) {

      SqlSet<TResult> set;

      if (ignoreBuffer
         && _definingQuery is null) {

         Debug.Assert(_fromSelect is not null);

         set = CreateSet<TResult>(_fromSelect, buffer);

      } else {

         var query = GetDefiningQuery(ignoreBuffer: ignoreBuffer);

         set = CreateSet<TResult>(query, default(Func<DbDataReader, TResult>), buffer);
      }

      return set;
   }

   private protected virtual IEnumerable
   Map(bool singleResult) {

      var query = GetDefiningQuery(clone: false);
      var results = default(IEnumerable<object>);

      if (this.ResultType is not null) {

         PocoMap(singleResult, query, ref results);

         return results
            ?? throw new InvalidOperationException("Cannot enumerate this set.");

      } else {

         DynamicMap(singleResult, query, ref results);

         return results
            ?? throw new InvalidOperationException("Cannot enumerate this set unless you specify a result type.");
      }
   }

   partial void
   PocoMap(bool singleResult, SqlBuilder query, ref IEnumerable<object>? results);

   partial void
   DynamicMap(bool singleResult, SqlBuilder query, ref IEnumerable<object>? results);

   // ISqlSet Members

   /// <summary>
   /// Determines whether all elements of the set satisfy a condition.
   /// </summary>
   /// <param name="predicate">A SQL expression to test each row for a condition.</param>
   /// <returns><c>true</c> if every element of the set passes the test in the specified <paramref name="predicate"/>, or if the set is empty; otherwise, <c>false</c>.</returns>

   public bool
   All(string predicate) {

      ArgumentNullException.ThrowIfNull(predicate);

      return !Any(String.Concat("NOT (", predicate, ")"));
   }

   /// <inheritdoc cref="All(String)"/>

   public bool
   All(ref OperatorStringHandler predicate) {

      var builder = predicate.Fragment;
      builder.Buffer.Insert(0, "NOT (")
         .Append(')');

      return !Any(ref predicate);
   }

   /// <summary>
   /// Determines whether the set contains any elements.
   /// </summary>
   /// <returns><c>true</c> if the sequence contains any elements; otherwise, <c>false</c>.</returns>

   public bool
   Any() {

      var (query, mapFn) = AnyImplParams();

      return _db.Map(query, mapFn)
         .SingleOrDefault();
   }

   (SqlBuilder, Func<DbDataReader, bool>)
   AnyImplParams() {

      var query = new SqlBuilder()
         .SELECT($"(CASE WHEN EXISTS ({GetDefiningQuery(clone: false)}) THEN 1 ELSE 0 END)");

      return (query, mapFn);

      static bool mapFn(DbDataReader r) =>
         Convert.ToInt32(r[0], CultureInfo.InvariantCulture) != 0;
   }

   /// <summary>
   /// Determines whether any element of the set satisfies a condition.
   /// </summary>
   /// <param name="predicate">A SQL expression to test each row for a condition.</param>
   /// <returns><c>true</c> if any elements in the set pass the test in the specified <paramref name="predicate"/>; otherwise, <c>false</c>.</returns>

   public bool
   Any(string predicate) =>
      Where(predicate).Any();

   /// <inheritdoc cref="Any(String)"/>

   public bool
   Any(ref OperatorStringHandler predicate) =>
      Where(ref predicate).Any();

   /// <summary>
   /// Gets all elements in the set. The query is deferred-executed.
   /// </summary>
   /// <returns>All elements in the set.</returns>

   public IEnumerable<object>
   AsEnumerable() =>
      AsEnumerable(singleResult: false);

   IEnumerable<object>
   AsEnumerable(bool singleResult) =>
      Map(singleResult).Cast<object>();

   /// <summary>
   /// Casts the elements of the set to the specified type.
   /// </summary>
   /// <typeparam name="TResult">The type to cast the elements of the set to.</typeparam>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains each element of the current set cast to the specified type.</returns>

   public SqlSet<TResult>
   Cast<TResult>() {

      if (this.ResultType is not null
         && this.ResultType != typeof(TResult)) {

         throw new InvalidOperationException("The specified type parameter is not valid for this instance.");
      }

      return CreateBufferedSet<TResult>(ignoreBuffer: true, buffer: _buffer);
   }

   /// <summary>
   /// Casts the elements of the set to the specified type.
   /// </summary>
   /// <param name="resultType">The type to cast the elements of the set to.</param>
   /// <returns>A new <see cref="SqlSet"/> that contains each element of the current set cast to the specified type.</returns>

   public SqlSet
   Cast(Type resultType) {

      ArgumentNullException.ThrowIfNull(resultType);

      if (this.ResultType is not null
         && this.ResultType != resultType) {

         throw new InvalidOperationException("The specified resultType is not valid for this instance.");
      }

      return CreateBufferedSet(ignoreBuffer: true, buffer: _buffer, resultType: resultType);
   }

   /// <summary>
   /// Returns the number of elements in the set.
   /// </summary>
   /// <returns>The number of elements in the set.</returns>
   /// <exception cref="System.OverflowException">The number of elements is larger than <see cref="Int32.MaxValue"/>.</exception>      

   public int
   Count() {

      var (query, mapFn) = CountImplParams();

      return _db.Map(query, mapFn)
         .SingleOrDefault();
   }

   /// <summary>
   /// Returns a number that represents how many elements in the set satisfy a condition.
   /// </summary>
   /// <param name="predicate">A SQL expression to test each row for a condition.</param>
   /// <returns>A number that represents how many elements in the set satisfy the condition in the <paramref name="predicate"/>.</returns>
   /// <exception cref="System.OverflowException">The number of matching elements exceeds <see cref="Int32.MaxValue"/>.</exception>      

   public int
   Count(string predicate) =>
      Where(predicate).Count();

   /// <inheritdoc cref="Count(String)"/>

   public int
   Count(ref OperatorStringHandler predicate) =>
      Where(ref predicate).Count();

   (SqlBuilder, Func<DbDataReader, int>)
   CountImplParams() {

      var query = new SqlBuilder()
         .SELECT("COUNT(*)")
         .FROM(GetDefiningQuery(clone: false), "dbex_count");

      return (query, mapFn);

      static int mapFn(DbDataReader r) =>
         Convert.ToInt32(!r.IsDBNull(0) ? r.GetValue(0) : null, CultureInfo.InvariantCulture);
   }

   /// <summary>
   /// Returns the first element of the set.
   /// </summary>
   /// <returns>The first element in the set.</returns>
   /// <exception cref="System.InvalidOperationException">The set is empty.</exception>

   public object
   First() =>
      Take(1).AsEnumerable(singleResult: true).First();

   /// <summary>
   /// Returns the first element in the set that satisfies a specified condition.
   /// </summary>
   /// <param name="predicate">A SQL expression to test each row for a condition.</param>
   /// <returns>The first element in the set that passes the test in the specified <paramref name="predicate"/>.</returns>
   /// <exception cref="System.InvalidOperationException">No element satisfies the condition in <paramref name="predicate"/>.-or-The set is empty.</exception>

   public object
   First(string predicate) =>
      Where(predicate).First();

   /// <inheritdoc cref="First(String)"/>

   public object
   First(ref OperatorStringHandler predicate) =>
      Where(ref predicate).First();

   /// <summary>
   /// Returns the first element of the set, or a default value if the set contains no elements.
   /// </summary>
   /// <returns>A default value if the set is empty; otherwise, the first element.</returns>

   public object?
   FirstOrDefault() =>
      Take(1).AsEnumerable(singleResult: true).FirstOrDefault();

   /// <summary>
   /// Returns the first element of the set that satisfies a condition or a default value if no such element is found.
   /// </summary>
   /// <param name="predicate">A SQL expression to test each row for a condition.</param>
   /// <returns>
   /// A default value if the set is empty or if no element passes the test specified by <paramref name="predicate"/>; otherwise, the 
   /// first element that passes the test specified by <paramref name="predicate"/>.
   /// </returns>

   public object?
   FirstOrDefault(string predicate) =>
      Where(predicate).FirstOrDefault();

   /// <inheritdoc cref="FirstOrDefault(String)"/>

   public object?
   FirstOrDefault(ref OperatorStringHandler predicate) =>
      Where(ref predicate).FirstOrDefault();

   /// <summary>
   /// Returns an enumerator that iterates through the set.
   /// </summary>
   /// <returns>A <see cref="IEnumerator&lt;Object>"/> for the set.</returns>

   public IEnumerator<object>
   GetEnumerator() =>
      AsEnumerable().GetEnumerator();

   /// <summary>
   /// Returns an <see cref="System.Int64"/> that represents the total number of elements in the set.
   /// </summary>
   /// <returns>The number of elements in the set.</returns>
   /// <exception cref="System.OverflowException">The number of elements is larger than <see cref="Int64.MaxValue"/>.</exception>      

   public long
   LongCount() {

      var (query, mapFn) = LongCountImplParams();

      return _db.Map(query, mapFn)
         .SingleOrDefault();
   }

   /// <summary>
   /// Returns an <see cref="System.Int64"/> that represents how many elements in the set satisfy a condition.
   /// </summary>
   /// <param name="predicate">A SQL expression to test each row for a condition.</param>
   /// <returns>A number that represents how many elements in the set satisfy the condition in the <paramref name="predicate"/>.</returns>
   /// <exception cref="System.OverflowException">The number of matching elements exceeds <see cref="Int64.MaxValue"/>.</exception>      

   public long
   LongCount(string predicate) =>
      Where(predicate).LongCount();

   /// <inheritdoc cref="LongCount(String)"/>

   public long
   LongCount(ref OperatorStringHandler predicate) =>
      Where(ref predicate).LongCount();

   (SqlBuilder, Func<DbDataReader, long>)
   LongCountImplParams() {

      var query = new SqlBuilder()
         .SELECT("COUNT(*)")
         .FROM(GetDefiningQuery(clone: false), "dbex_count");

      return (query, mapFn);

      static long mapFn(DbDataReader r) =>
         Convert.ToInt64(!r.IsDBNull(0) ? r.GetValue(0) : null, CultureInfo.InvariantCulture);
   }

   /// <summary>
   /// Sorts the elements of the set according to the <paramref name="columnList"/>.
   /// </summary>
   /// <param name="columnList">The list of columns to base the sort on.</param>
   /// <returns>A new <see cref="SqlSet"/> whose elements are sorted according to <paramref name="columnList"/>.</returns>

   public SqlSet
   OrderBy(string columnList) {

      ArgumentNullException.ThrowIfNull(columnList);

      return OrderBy(new SqlFragment(columnList));
   }

   /// <inheritdoc cref="OrderBy(String)"/>

   public SqlSet
   OrderBy(ref OperatorStringHandler columnList) =>
      OrderBy(columnList.Fragment);

   SqlSet
   OrderBy(ISqlFragment fragment) {

      var ignoreBuffer = _buffer.OrderBy is null
         && _buffer.Skip is null
         && _buffer.Take is null;

      var newBuffer = new SqlBuffer(
         Where: (ignoreBuffer) ? _buffer.Where : null,
         OrderBy: fragment);

      var set = CreateBufferedSet(ignoreBuffer, newBuffer);

      return set;
   }

   /// <summary>
   /// Projects each element of the set into a new form.
   /// </summary>
   /// <typeparam name="TResult">The type that <paramref name="columnList"/> maps to.</typeparam>
   /// <param name="columnList">The list of columns that maps to properties on <typeparamref name="TResult"/>.</param>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/>.</returns>

   public SqlSet<TResult>
   Select<TResult>(string columnList) {

      ArgumentNullException.ThrowIfNull(columnList);

      return CreateSet<TResult>(GetDefiningQuery(select: new SqlFragment(columnList)));
   }

   /// <inheritdoc cref="Select&lt;TResult>(String)"/>

   public SqlSet<TResult>
   Select<TResult>(ref OperatorStringHandler columnList) =>
      CreateSet<TResult>(GetDefiningQuery(select: columnList.Fragment));

   /// <summary>
   /// Projects each element of the set into a new form.
   /// </summary>
   /// <typeparam name="TResult">The type that <paramref name="mapper"/> returns.</typeparam>
   /// <param name="columnList">The list of columns that are used by <paramref name="mapper"/>.</param>
   /// <param name="mapper">A custom mapper function that creates <typeparamref name="TResult"/> instances from the rows in the set.</param>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/>.</returns>

   public SqlSet<TResult>
   Select<TResult>(string columnList, Func<DbDataReader, TResult> mapper) {

      ArgumentNullException.ThrowIfNull(mapper);
      ArgumentNullException.ThrowIfNull(columnList);

      return CreateSet<TResult>(GetDefiningQuery(select: new SqlFragment(columnList)), mapper);
   }

   /// <inheritdoc cref="Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)"/>

   public SqlSet<TResult>
   Select<TResult>(ref OperatorStringHandler columnList, Func<DbDataReader, TResult> mapper) {

      ArgumentNullException.ThrowIfNull(mapper);

      return CreateSet<TResult>(GetDefiningQuery(select: columnList.Fragment), mapper);
   }

   /// <summary>
   /// Projects each element of the set into a new form.
   /// </summary>
   /// <param name="columnList">The list of columns that maps to properties on <paramref name="resultType"/>.</param>
   /// <param name="resultType">The type that <paramref name="columnList"/> maps to.</param>
   /// <returns>A new <see cref="SqlSet"/>.</returns>

   public SqlSet
   Select(string columnList, Type resultType) {

      ArgumentNullException.ThrowIfNull(resultType);
      ArgumentNullException.ThrowIfNull(columnList);

      return CreateSet(GetDefiningQuery(select: new SqlFragment(columnList)), resultType);
   }

   /// <inheritdoc cref="Select(String, Type)"/>

   public SqlSet
   Select(ref OperatorStringHandler columnList, Type resultType) {

      ArgumentNullException.ThrowIfNull(resultType);

      return CreateSet(GetDefiningQuery(select: columnList.Fragment), resultType);
   }

   /// <summary>
   /// Projects each element of the set into a new form.
   /// </summary>
   /// <param name="columnList">The list of columns to select.</param>
   /// <returns>A new <see cref="SqlSet"/>.</returns>

   public SqlSet
   Select(string columnList) {

      ArgumentNullException.ThrowIfNull(columnList);

      return CreateSet(GetDefiningQuery(select: new SqlFragment(columnList)));
   }

   /// <inheritdoc cref="Select(String)"/>

   public SqlSet
   Select(ref OperatorStringHandler columnList) =>
      CreateSet(GetDefiningQuery(select: columnList.Fragment));

   /// <summary>
   /// The single element of the set.
   /// </summary>
   /// <returns>The single element of the set.</returns>
   /// <exception cref="System.InvalidOperationException">The set contains more than one element.-or-The set is empty.</exception>      

   public object
   Single() =>
      AsEnumerable(singleResult: true).Single();

   /// <summary>
   /// Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.
   /// </summary>
   /// <param name="predicate">A SQL expression to test each row for a condition.</param>
   /// <returns>The single element of the set that passes the test in the specified <paramref name="predicate"/>.</returns>
   /// <exception cref="System.InvalidOperationException">No element satisfies the condition in <paramref name="predicate"/>.-or-More than one element satisfies the condition in <paramref name="predicate"/>.-or-The set is empty.</exception>      

   public object
   Single(string predicate) =>
      Where(predicate).Single();

   /// <inheritdoc cref="Single(String)"/>

   public object
   Single(ref OperatorStringHandler predicate) =>
      Where(ref predicate).Single();

   /// <summary>
   /// Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.
   /// </summary>
   /// <returns>The single element of the set, or a default value if the set contains no elements.</returns>
   /// <exception cref="System.InvalidOperationException">The set contains more than one element.</exception>

   public object?
   SingleOrDefault() =>
      AsEnumerable(singleResult: true).SingleOrDefault();

   /// <summary>
   /// Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
   /// </summary>
   /// <param name="predicate">A SQL expression to test each row for a condition.</param>
   /// <returns>The single element of the set that satisfies the condition, or a default value if no such element is found.</returns>

   public object?
   SingleOrDefault(string predicate) =>
      Where(predicate).SingleOrDefault();

   /// <inheritdoc cref="SingleOrDefault(String)"/>

   public object?
   SingleOrDefault(ref OperatorStringHandler predicate) =>
      Where(ref predicate).SingleOrDefault();

   /// <summary>
   /// Bypasses a specified number of elements in the set and then returns the remaining elements.
   /// </summary>
   /// <param name="count">The number of elements to skip before returning the remaining elements.</param>
   /// <returns>A new <see cref="SqlSet"/> that contains the elements that occur after the specified index in the current set.</returns>

   public SqlSet
   Skip(int count) {

      var ignoreBuffer = _buffer.Skip is null
         && _buffer.Take is null;

      var newBuffer = new SqlBuffer(
         Where: (ignoreBuffer) ? _buffer.Where : null,
         OrderBy: (ignoreBuffer) ? _buffer.OrderBy : null,
         Skip: count);

      var set = CreateBufferedSet(ignoreBuffer, newBuffer);

      return set;
   }

   /// <summary>
   /// Returns a specified number of contiguous elements from the start of the set.
   /// </summary>
   /// <param name="count">The number of elements to return.</param>
   /// <returns>A new <see cref="SqlSet"/> that contains the specified number of elements from the start of the current set.</returns>

   public SqlSet
   Take(int count) {

      var ignoreBuffer = _buffer.Take is null;

      var newBuffer = new SqlBuffer(
         Where: (ignoreBuffer) ? _buffer.Where : null,
         OrderBy: (ignoreBuffer) ? _buffer.OrderBy : null,
         Skip: (ignoreBuffer) ? _buffer.Skip : null,
         Take: count);

      var set = CreateBufferedSet(ignoreBuffer, newBuffer);

      return set;
   }

   /// <summary>
   /// Creates an array from the set.
   /// </summary>
   /// <returns>An array that contains the elements from the set.</returns>

   public object[]
   ToArray() => AsEnumerable().ToArray();

   /// <summary>
   /// Creates a List&lt;object> from the set.
   /// </summary>
   /// <returns>A List&lt;object> that contains elements from the set.</returns>

   public List<object>
   ToList() => AsEnumerable().ToList();

   /// <summary>
   /// Filters the set based on a predicate.
   /// </summary>
   /// <param name="predicate">A SQL expression to test each row for a condition.</param>
   /// <returns>A new <see cref="SqlSet"/> that contains elements from the current set that satisfy the condition.</returns>

   public SqlSet
   Where(string predicate) {

      ArgumentNullException.ThrowIfNull(predicate);

      return Where(new SqlFragment(predicate));
   }

   /// <inheritdoc cref="Where(String)"/>

   public SqlSet
   Where(ref OperatorStringHandler predicate) =>
      Where(predicate.Fragment);

   SqlSet
   Where(ISqlFragment fragment) {

      var ignoreBuffer = _buffer.Where is null
         && _buffer.OrderBy is null
         && _buffer.Skip is null
         && _buffer.Take is null;

      var newBuffer = new SqlBuffer(Where: fragment);

      var set = CreateBufferedSet(ignoreBuffer, newBuffer);

      return set;
   }

   // Object Members

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public override bool
   Equals(object? obj) => base.Equals(obj);

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public override int
   GetHashCode() => base.GetHashCode();

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public new Type
   GetType() => base.GetType();

   /// <summary>
   /// Returns the SQL query of the set.
   /// </summary>
   /// <returns>The SQL query of the set.</returns>

   public override string
   ToString() =>
      GetDefiningQuery(clone: false).ToString();

   internal record struct SqlBuffer(ISqlFragment? Where = null, ISqlFragment? OrderBy = null, int? Skip = null, int? Take = null) {

      public bool
      HasValue =>
         Where is not null
            || OrderBy is not null
            || Skip is not null
            || Take is not null;
   }

   sealed class SqlFragment(string text, IList<object?>? parameters = null) : ISqlFragment {

      public IList<object?>
      ParameterValues { get; } = parameters ?? Array.Empty<object?>();

      public override string
      ToString() => text;
   }

   sealed record class FetchClause() : SqlClause("FETCH", null);

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   [InterpolatedStringHandler]
   public struct OperatorStringHandler {

      readonly SqlBuilder
      _builder;

      internal SqlBuilder
      Fragment => _builder;

      /// <exclude/>

      public
      OperatorStringHandler(int literalLength, int formattedCount) {
         _builder = new SqlBuilder(literalLength, formattedCount);
      }

      /// <exclude/>

      public void
      AppendLiteral(string value) =>
         _builder.Buffer.Append(value);

      /// <exclude/>

      public void
      AppendFormatted(object? value, int alignment = 0, string? format = null) =>
         _builder.AppendPlaceholder(value, format);
   }
}

/// <summary>
/// Represents an immutable, connected SQL query that maps to <typeparamref name="TResult"/> objects.
/// This class cannot be instantiated, to get an instance use one of the
/// <see cref="Database.From&lt;TResult>(String)" qualifyHint="true"/> or
/// <see cref="Database.FromQuery&lt;TResult>(SqlBuilder)" qualifyHint="true"/> overloads.
/// </summary>
/// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
/// <inheritdoc path="remarks"/>

public partial class SqlSet<TResult> : SqlSet, ISqlSet<SqlSet<TResult>, TResult> {

   readonly Func<DbDataReader, TResult>?
   _explicitMapper;

   internal
   SqlSet(SqlBuilder definingQuery, Database db)
      : base(definingQuery, typeof(TResult), db) { }

   internal
   SqlSet(SqlBuilder definingQuery, Func<DbDataReader, TResult> mapper, Database db)
      : base(definingQuery, typeof(TResult), db) {

      _explicitMapper = mapper;
   }

   internal
   SqlSet(string?[] fromSelect, Database db)
      : base(fromSelect, typeof(TResult), db) { }

   // These two SHOULD NOT pass TResult to base ctor
   // result type is copied from set

   private
   SqlSet(SqlSet<TResult> set, SqlBuilder superQuery, SqlBuffer? buffer)
      : base((SqlSet)set, superQuery, default(Type), buffer) {

      _explicitMapper = set._explicitMapper;
   }

   private
   SqlSet(SqlSet<TResult> set, string?[] fromSelect, SqlBuffer? buffer)
      : base((SqlSet)set, fromSelect, default(Type), buffer) {

      _explicitMapper = set._explicitMapper;
   }

   // These two SHOULD pass TResult to base ctor

   internal
   SqlSet(SqlSet set, SqlBuilder superQuery, Func<DbDataReader, TResult>? mapper, SqlBuffer? buffer)
      : base(set, superQuery, typeof(TResult), buffer) {

      if (mapper is not null) {
         _explicitMapper = mapper;
      }
   }

   internal
   SqlSet(SqlSet set, string?[] fromSelect, SqlBuffer? buffer)
      : base(set, fromSelect, typeof(TResult), buffer) { }

   private protected override SqlSet
   CreateSet(SqlBuilder superQuery, Type? resultType = null, SqlBuffer? buffer = null) {

      if (resultType is not null) {
         return base.CreateSet(superQuery, resultType, buffer);
      }

      return new SqlSet<TResult>(this, superQuery, buffer);
   }

   private protected override SqlSet
   CreateSet(string?[] fromSelect, Type? resultType = null, SqlBuffer? buffer = null) {

      if (resultType is not null) {
         return base.CreateSet(fromSelect, resultType, buffer);
      }

      return new SqlSet<TResult>(this, fromSelect, buffer);
   }

   private protected override IEnumerable<TResult>
   Map(bool singleResult) {

      var query = GetDefiningQuery(clone: false);

      if (_explicitMapper is not null) {
         return _db.Map(query, _explicitMapper);
      } else {

         var results = default(IEnumerable<TResult>);

         PocoMap(singleResult, query, ref results);

         return results
            ?? throw new InvalidOperationException("Cannot enumerate this set.");
      }
   }

   partial void
   PocoMap(bool singleResult, SqlBuilder query, ref IEnumerable<TResult>? results);

   // ISqlSet Members

   /// <summary>
   /// Gets all <typeparamref name="TResult"/> objects in the set. The query is deferred-executed.
   /// </summary>
   /// <returns>All <typeparamref name="TResult"/> objects in the set.</returns>

   public new IEnumerable<TResult>
   AsEnumerable() =>
      AsEnumerable(singleResult: false);

   IEnumerable<TResult>
   AsEnumerable(bool singleResult) =>
      Map(singleResult);

   /// <summary>
   /// Casts the elements of the set to the specified type.
   /// </summary>
   /// <typeparam name="T">The type to cast the elements of the set to.</typeparam>
   /// <returns>A new <see cref="SqlSet&lt;T>"/> that contains each element of the current set cast to the specified type.</returns>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public new SqlSet<T>
   Cast<T>() => base.Cast<T>();

   /// <inheritdoc cref="SqlSet.Cast(Type)"/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public new SqlSet
   Cast(Type resultType) =>
      base.Cast(resultType);

   /// <inheritdoc cref="SqlSet.First()"/>

   public new TResult
   First() =>
      Take(1).AsEnumerable(singleResult: true).First();

   /// <inheritdoc cref="SqlSet.First(String)"/>

   public new TResult
   First(string predicate) =>
      Where(predicate).First();

   /// <inheritdoc cref="SqlSet.First(ref OperatorStringHandler)"/>

   public new TResult
   First(ref OperatorStringHandler predicate) =>
      Where(ref predicate).First();

   /// <inheritdoc cref="SqlSet.FirstOrDefault()"/>

   public new TResult?
   FirstOrDefault() =>
      Take(1).AsEnumerable(singleResult: true).FirstOrDefault();

   /// <inheritdoc cref="SqlSet.FirstOrDefault(String)"/>

   public new TResult?
   FirstOrDefault(string predicate) =>
      Where(predicate).FirstOrDefault();

   /// <inheritdoc cref="SqlSet.FirstOrDefault(ref OperatorStringHandler)"/>

   public new TResult?
   FirstOrDefault(ref OperatorStringHandler predicate) =>
      Where(ref predicate).FirstOrDefault();

   /// <summary>
   /// Returns an enumerator that iterates through the set.
   /// </summary>
   /// <returns>A <see cref="IEnumerator&lt;TResult>"/> for the set.</returns>

   public new IEnumerator<TResult>
   GetEnumerator() =>
      AsEnumerable().GetEnumerator();

   /// <inheritdoc cref="SqlSet.OrderBy(String)"/>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/> whose elements are sorted according to <paramref name="columnList"/>.</returns>

   public new SqlSet<TResult>
   OrderBy(string columnList) =>
      (SqlSet<TResult>)base.OrderBy(columnList);

   /// <inheritdoc cref="SqlSet.OrderBy(ref OperatorStringHandler)"/>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/> whose elements are sorted according to <paramref name="columnList"/>.</returns>

   public new SqlSet<TResult>
   OrderBy(ref OperatorStringHandler columnList) =>
      (SqlSet<TResult>)base.OrderBy(ref columnList);

   /// <inheritdoc cref="SqlSet.Single()"/>

   public new TResult
   Single() =>
      AsEnumerable(singleResult: true).Single();

   /// <inheritdoc cref="SqlSet.Single(String)"/>

   public new TResult
   Single(string predicate) =>
      Where(predicate).Single();

   /// <inheritdoc cref="SqlSet.Single(ref OperatorStringHandler)"/>

   public new TResult
   Single(ref OperatorStringHandler predicate) =>
      Where(ref predicate).Single();

   /// <inheritdoc cref="SqlSet.SingleOrDefault()"/>

   public new TResult?
   SingleOrDefault() =>
      AsEnumerable(singleResult: true).SingleOrDefault();

   /// <inheritdoc cref="SqlSet.SingleOrDefault(String)"/>

   public new TResult?
   SingleOrDefault(string predicate) =>
      Where(predicate).SingleOrDefault();

   /// <inheritdoc cref="SqlSet.SingleOrDefault(ref OperatorStringHandler)"/>

   public new TResult?
   SingleOrDefault(ref OperatorStringHandler predicate) =>
      Where(ref predicate).SingleOrDefault();

   /// <inheritdoc cref="SqlSet.Skip(Int32)"/>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains the elements that occur after the specified index in the current set.</returns>

   public new SqlSet<TResult>
   Skip(int count) =>
      (SqlSet<TResult>)base.Skip(count);

   /// <inheritdoc cref="SqlSet.Take(Int32)"/>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains the specified number of elements from the start of the current set.</returns>

   public new SqlSet<TResult>
   Take(int count) =>
      (SqlSet<TResult>)base.Take(count);

   /// <inheritdoc cref="SqlSet.ToArray()"/>

   public new TResult[]
   ToArray() => AsEnumerable().ToArray();

   /// <summary>
   /// Creates a List&lt;TResult> from the set.
   /// </summary>
   /// <returns>A List&lt;TResult> that contains elements from the set.</returns>

   public new List<TResult>
   ToList() => AsEnumerable().ToList();

   /// <inheritdoc cref="SqlSet.Where(String)"/>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains elements from the current set that satisfy the condition.</returns>

   public new SqlSet<TResult>
   Where(string predicate) =>
      (SqlSet<TResult>)base.Where(predicate);

   /// <inheritdoc cref="SqlSet.Where(ref OperatorStringHandler)"/>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains elements from the current set that satisfy the condition.</returns>

   public new SqlSet<TResult>
   Where(ref OperatorStringHandler predicate) =>
      (SqlSet<TResult>)base.Where(ref predicate);
}

partial interface ISqlSet<TSqlSet, TSource> where TSqlSet : SqlSet {

   bool
   All(string predicate);

   bool
   All(ref SqlSet.OperatorStringHandler predicate);

   bool
   Any();

   bool
   Any(string predicate);

   bool
   Any(ref SqlSet.OperatorStringHandler predicate);

   IEnumerable<TSource>
   AsEnumerable();

   SqlSet<TResult>
   Cast<TResult>();

   SqlSet
   Cast(Type resultType);

   int
   Count();

   int
   Count(string predicate);

   int
   Count(ref SqlSet.OperatorStringHandler predicate);

   TSource
   First();

   TSource
   First(string predicate);

   TSource
   First(ref SqlSet.OperatorStringHandler predicate);

   TSource?
   FirstOrDefault();

   TSource?
   FirstOrDefault(string predicate);

   TSource?
   FirstOrDefault(ref SqlSet.OperatorStringHandler predicate);

   IEnumerator<TSource>
   GetEnumerator();

   long
   LongCount();

   long
   LongCount(string predicate);

   long
   LongCount(ref SqlSet.OperatorStringHandler predicate);

   TSqlSet
   OrderBy(string columnList);

   TSqlSet
   OrderBy(ref SqlSet.OperatorStringHandler columnList);

   SqlSet<TResult>
   Select<TResult>(string columnList);

   SqlSet<TResult>
   Select<TResult>(string columnList, Func<DbDataReader, TResult> mapper);

   SqlSet<TResult>
   Select<TResult>(ref SqlSet.OperatorStringHandler columnList);

   SqlSet<TResult>
   Select<TResult>(ref SqlSet.OperatorStringHandler columnList, Func<DbDataReader, TResult> mapper);

   SqlSet
   Select(string columnList);

   SqlSet
   Select(string columnList, Type resultType);

   SqlSet
   Select(ref SqlSet.OperatorStringHandler columnList);

   SqlSet
   Select(ref SqlSet.OperatorStringHandler columnList, Type resultType);

   TSource
   Single();

   TSource
   Single(string predicate);

   TSource
   Single(ref SqlSet.OperatorStringHandler predicate);

   TSource?
   SingleOrDefault();

   TSource?
   SingleOrDefault(string predicate);

   TSource?
   SingleOrDefault(ref SqlSet.OperatorStringHandler predicate);

   TSqlSet
   Skip(int count);

   TSqlSet
   Take(int count);

   TSource[]
   ToArray();

   List<TSource>
   ToList();

   TSqlSet
   Where(string predicate);

   TSqlSet
   Where(ref SqlSet.OperatorStringHandler predicate);
}
