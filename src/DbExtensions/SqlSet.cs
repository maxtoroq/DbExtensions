// Copyright 2012-2018 Max Toro Q.
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
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Collections;

namespace DbExtensions {

   partial class Database {

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet"/> using the provided table name.
      /// </summary>
      /// <param name="tableName">The name of the table that will be the source of data for the set.</param>
      /// <returns>A new <see cref="SqlSet"/> object.</returns>

      public SqlSet From(string tableName) {
         return From(tableName, null);
      }

      /// <inheritdoc cref="From(String)"/>
      /// <param name="resultType">The type of objects to map the results to.</param>

      public SqlSet From(string tableName, Type resultType) {
         return new SqlSet(new string[2] { tableName, null }, resultType, this);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided table name.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="tableName">The name of the table that will be the source of data for the set.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> object.</returns>

      public SqlSet<TResult> From<TResult>(string tableName) {
         return new SqlSet<TResult>(new string[2] { tableName, null }, this);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet"/> using the provided defining query.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <returns>A new <see cref="SqlSet"/> object.</returns>

      public SqlSet From(SqlBuilder definingQuery) {
         return From(definingQuery, null);
      }

      /// <inheritdoc cref="From(SqlBuilder)"/>
      /// <param name="resultType">The type of objects to map the results to.</param>

      public SqlSet From(SqlBuilder definingQuery, Type resultType) {
         return new SqlSet(definingQuery, resultType, this);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided defining query.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> object.</returns>

      public SqlSet<TResult> From<TResult>(SqlBuilder definingQuery) {
         return new SqlSet<TResult>(definingQuery, this);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided defining query and mapper.
      /// </summary>
      /// <inheritdoc cref="From&lt;TResult>(SqlBuilder)"/>
      /// <param name="mapper">A custom mapper function that creates <typeparamref name="TResult"/> instances from the rows in the set.</param>

      public SqlSet<TResult> From<TResult>(SqlBuilder definingQuery, Func<IDataRecord, TResult> mapper) {
         return new SqlSet<TResult>(definingQuery, mapper, this);
      }
   }

   /// <summary>
   /// Represents an immutable, connected SQL query.
   /// This class cannot be instantiated, to get an instance use the <see cref="Database.From(string)"/> method.
   /// </summary>
   /// <remarks>For information on how to use SqlSet see <see href="http://maxtoroq.github.io/DbExtensions/docs/SqlSet.html">SqlSet Tutorial</see>.</remarks>

   public partial class SqlSet : ISqlSet<SqlSet, object> {

      // definingQuery should NEVER be modified

      readonly SqlBuilder definingQuery;
      readonly string[] fromSelect;
      readonly SqlBuffer buffer;

      internal readonly Database db;
      readonly int setIndex = 1;

      /// <summary>
      /// The type of objects this set returns. This property can be null.
      /// </summary>

      public Type ResultType { get; }

      internal SqlSet(SqlBuilder definingQuery, Type resultType, Database db) {

         if (definingQuery == null) throw new ArgumentNullException(nameof(definingQuery));

         this.definingQuery = definingQuery.Clone();
         this.ResultType = resultType;
         this.db = db;
      }

      internal SqlSet(string[] fromSelect, Type resultType, Database db) {

         if (fromSelect == null) throw new ArgumentNullException(nameof(fromSelect));
         if (fromSelect.Length != 2) throw new ArgumentException("fromSelect.Length must be 2.", nameof(fromSelect));

         this.fromSelect = fromSelect;
         this.ResultType = resultType;
         this.db = db;
      }

      internal SqlSet(SqlSet set, SqlBuilder superQuery, Type resultType, SqlBuffer? buffer)
         : this(set, resultType, buffer) {

         if (superQuery == null) throw new ArgumentNullException(nameof(superQuery));

         this.definingQuery = superQuery;
      }

      internal SqlSet(SqlSet set, string[] fromSelect, Type resultType, SqlBuffer? buffer)
         : this(set, resultType, buffer) {

         if (fromSelect == null) throw new ArgumentNullException(nameof(fromSelect));
         if (fromSelect.Length != 2) throw new ArgumentException("fromSelect.Length must be 2.", nameof(fromSelect));

         this.fromSelect = fromSelect;
      }

      private SqlSet(SqlSet set, Type resultType, SqlBuffer? buffer) {

         if (set == null) throw new ArgumentNullException(nameof(set));

         this.ResultType = set.ResultType;
         this.setIndex += set.setIndex;
         this.db = set.db;

         if (resultType != null) {
            this.ResultType = resultType;
         }

         if (buffer != null) {
            this.buffer = buffer.Value;
         }

         Initialize2(set);
      }

      partial void Initialize2(SqlSet set);

      /// <summary>
      /// Returns the SQL query that is the source of data for the set.
      /// </summary>
      /// <returns>The SQL query that is the source of data for the set</returns>

      [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Calling the member twice in succession creates different results.")]
      public SqlBuilder GetDefiningQuery() {
         return GetDefiningQuery(clone: true);
      }

      internal SqlBuilder GetDefiningQuery(bool clone = true, bool ignoreBuffer = false, bool super = false, string selectFormat = null, object[] args = null) {

         if (!ignoreBuffer
            && this.buffer.HasBuffer) {

            return BuildQuery(selectFormat, args);
         }

         SqlBuilder query = this.definingQuery;

         if (query == null) {

            query = new SqlBuilder()
               .SELECT(selectFormat ?? this.fromSelect[1] ?? "*", args)
               .FROM(this.fromSelect[0]);

         } else if (super || selectFormat != null) {

            query = CreateSuperQuery(query, selectFormat, args);

         } else if (clone) {

            query = query.Clone();
         }

         return query;
      }

      SqlBuilder BuildQuery(string selectFormat, object[] args) {

         switch (this.db.Configuration.SqlDialect) {
            case SqlDialect.Default:
               return BuildQuery_Default(selectFormat, args);

            case SqlDialect.TSql:
               return BuildQuery_TSql(selectFormat, args);

            default:
               throw new NotImplementedException();
         }
      }

      SqlBuilder BuildQuery_Default(string selectFormat, object[] args) {

         SqlFragment whereBuffer = this.buffer.Where;
         SqlFragment orderByBuffer = this.buffer.OrderBy;
         int? skipBuffer = this.buffer.Skip;
         int? takeBuffer = this.buffer.Take;

         bool hasWhere = whereBuffer != null;
         bool hasOrderBy = orderByBuffer != null;
         bool hasSkip = skipBuffer.HasValue;
         bool hasTake = takeBuffer.HasValue;

         SqlBuilder query = GetDefiningQuery(ignoreBuffer: true, super: true, selectFormat: selectFormat, args: args);

         if (hasWhere
            || hasOrderBy
            || hasTake
            || hasSkip) {

            if (hasWhere) {
               query.WHERE(whereBuffer.Format, whereBuffer.Args);
            }

            if (hasOrderBy) {
               query.ORDER_BY(orderByBuffer.Format, orderByBuffer.Args);
            }

            if (hasTake) {
               query.LIMIT(takeBuffer.Value);
            }

            if (hasSkip) {
               query.OFFSET(skipBuffer.Value);
            }
         }

         return query;
      }

      SqlBuilder BuildQuery_TSql(string selectFormat, object[] args) {

         SqlFragment whereBuffer = this.buffer.Where;
         SqlFragment orderByBuffer = this.buffer.OrderBy;
         int? skipBuffer = this.buffer.Skip;
         int? takeBuffer = this.buffer.Take;

         bool hasWhere = whereBuffer != null;
         bool hasOrderBy = orderByBuffer != null;
         bool hasSkip = skipBuffer.HasValue;
         bool hasTake = takeBuffer.HasValue;

         if (hasSkip) {

            SqlBuilder query = GetDefiningQuery(ignoreBuffer: true, super: true, selectFormat: selectFormat, args: args);

            if (hasWhere) {
               query.WHERE(whereBuffer.Format, whereBuffer.Args);
            }

            if (hasOrderBy) {
               query.ORDER_BY(orderByBuffer.Format, orderByBuffer.Args);

            } else {

               // Cannot have OFFSET without ORDER BY
               query.ORDER_BY("1");
            }

            query.OFFSET("{0} ROWS", skipBuffer.Value);

            if (hasTake) {
               query.AppendClause("FETCH", null, "NEXT {0} ROWS ONLY", takeBuffer.Value);
            }

            return query;

         } else if (hasTake) {

            SqlBuilder query = GetDefiningQuery(ignoreBuffer: true, super: true, selectFormat: "TOP({0}) *", args: new object[1] { takeBuffer.Value });

            if (hasWhere) {
               query.WHERE(whereBuffer.Format, whereBuffer.Args);
            }

            if (hasOrderBy) {
               query.ORDER_BY(orderByBuffer.Format, orderByBuffer.Args);
            }

            if (selectFormat != null) {

               // SELECT must be done in super query, it could remove columns used by WHERE/ORDER BY

               query = CreateSuperQuery(query, selectFormat, args);
            }

            return query;

         } else {

            SqlBuilder query = GetDefiningQuery(ignoreBuffer: true, super: true, selectFormat: selectFormat, args: args);

            if (hasWhere) {
               query.WHERE(whereBuffer.Format, whereBuffer.Args);
            }

            if (hasOrderBy) {

               query.ORDER_BY(orderByBuffer.Format, orderByBuffer.Args);

               // The ORDER BY clause is invalid in subqueries, unless TOP, OFFSET or FOR XML is also specified.

               query.OFFSET("0 ROWS");
            }

            return query;
         }
      }

      SqlBuilder CreateSuperQuery(SqlBuilder query, string selectFormat, object[] args) {

         var superQuery = new SqlBuilder()
            .SELECT(selectFormat ?? "*", args)
            .FROM(query, "dbex_set" + this.setIndex.ToString(CultureInfo.InvariantCulture));

         return superQuery;
      }

      internal virtual SqlSet CreateSet(SqlBuilder superQuery, Type resultType = null, SqlBuffer? buffer = null) {
         return new SqlSet(this, superQuery, resultType, buffer);
      }

      internal virtual SqlSet CreateSet(string[] fromSelect, Type resultType = null, SqlBuffer? buffer = null) {
         return new SqlSet(this, fromSelect, resultType, buffer);
      }

      internal SqlSet<TResult> CreateSet<TResult>(SqlBuilder superQuery, Func<IDataRecord, TResult> mapper = null, SqlBuffer? buffer = null) {
         return new SqlSet<TResult>(this, superQuery, mapper, buffer);
      }

      internal SqlSet<TResult> CreateSet<TResult>(string[] fromSelect, SqlBuffer? buffer = null) {
         return new SqlSet<TResult>(this, fromSelect, buffer);
      }

      internal SqlSet Clone() {
         return CreateBufferedSet(ignoreBuffer: true, buffer: this.buffer);
      }

      internal SqlSet CreateBufferedSet(bool ignoreBuffer, SqlBuffer buffer, Type resultType = null) {

         SqlSet set = null;

         if (ignoreBuffer
            && this.definingQuery == null) {

            set = CreateSet(this.fromSelect, resultType, buffer);
         }

         if (set == null) {

            SqlBuilder query = GetDefiningQuery(ignoreBuffer: ignoreBuffer);

            set = CreateSet(query, resultType, buffer);
         }

         return set;
      }

      internal SqlSet<TResult> CreateBufferedSet<TResult>(bool ignoreBuffer, SqlBuffer buffer) {

         SqlSet<TResult> set = null;

         if (ignoreBuffer
            && this.definingQuery == null) {

            set = CreateSet<TResult>(this.fromSelect, buffer);
         }

         if (set == null) {

            SqlBuilder query = GetDefiningQuery(ignoreBuffer: ignoreBuffer);

            set = CreateSet<TResult>(query, default(Func<IDataRecord, TResult>), buffer);
         }

         return set;
      }

      internal virtual IEnumerable Map(bool singleResult) {

         if (this.ResultType != null) {
#if DBEX_NO_POCO
            throw new InvalidOperationException("Cannot enumerate this set.");
#else
            return PocoMap(singleResult);
#endif
         }

#if DBEX_NO_DYN
         throw new InvalidOperationException("Cannot enumerate this set unless you specify a result type.");
#else
         return DynamicMap(singleResult);
#endif
      }

      #region ISqlSet<SqlSet,object> Members

      /// <summary>
      /// Determines whether all elements of the set satisfy a condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>true if every element of the set passes the test in the specified <paramref name="predicate"/>, or if the set is empty; otherwise, false.</returns>

      public bool All(string predicate, params object[] parameters) {

         if (predicate == null) throw new ArgumentNullException(nameof(predicate));

         return !Any(String.Concat("NOT (", predicate, ")"), parameters);
      }

      /// <summary>
      /// Determines whether the set contains any elements.
      /// </summary>
      /// <returns>true if the sequence contains any elements; otherwise, false.</returns>

      public bool Any() {

         var query = new SqlBuilder()
            .SELECT("(CASE WHEN EXISTS ({0}) THEN 1 ELSE 0 END)", GetDefiningQuery(clone: false));

         return this.db.Map(query, r => Convert.ToInt32(r[0], CultureInfo.InvariantCulture) != 0)
            .SingleOrDefault();
      }

      /// <summary>
      /// Determines whether any element of the set satisfies a condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>true if any elements in the set pass the test in the specified <paramref name="predicate"/>; otherwise, false.</returns>

      public bool Any(string predicate, params object[] parameters) {
         return Where(predicate, parameters).Any();
      }

      /// <summary>
      /// Gets all elements in the set. The query is deferred-executed.
      /// </summary>
      /// <returns>All elements in the set.</returns>

      public IEnumerable<object> AsEnumerable() {
         return AsEnumerable(singleResult: false);
      }

      IEnumerable<object> AsEnumerable(bool singleResult) {

         IEnumerable enumerable = Map(singleResult);

         return enumerable as IEnumerable<object>
            ?? enumerable.Cast<object>();
      }

      /// <summary>
      /// Casts the elements of the set to the specified type.
      /// </summary>
      /// <typeparam name="TResult">The type to cast the elements of the set to.</typeparam>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains each element of the current set cast to the specified type.</returns>

      public SqlSet<TResult> Cast<TResult>() {

         if (this.ResultType != null
            && this.ResultType != typeof(TResult)) {

            throw new InvalidOperationException("The specified type parameter is not valid for this instance.");
         }

         return CreateBufferedSet<TResult>(ignoreBuffer: true, buffer: this.buffer);
      }

      /// <summary>
      /// Casts the elements of the set to the specified type.
      /// </summary>
      /// <param name="resultType">The type to cast the elements of the set to.</param>
      /// <returns>A new <see cref="SqlSet"/> that contains each element of the current set cast to the specified type.</returns>

      public SqlSet Cast(Type resultType) {

         if (this.ResultType != null
            && this.ResultType != resultType) {

            throw new InvalidOperationException("The specified resultType is not valid for this instance.");
         }

         return CreateBufferedSet(ignoreBuffer: true, buffer: this.buffer, resultType: resultType);
      }

      /// <summary>
      /// Returns the number of elements in the set.
      /// </summary>
      /// <returns>The number of elements in the set.</returns>
      /// <exception cref="System.OverflowException">The number of elements is larger than <see cref="Int32.MaxValue"/>.</exception>      

      public int Count() {

         var query = new SqlBuilder()
            .SELECT("COUNT(*)")
            .FROM("({0}) dbex_count", GetDefiningQuery(clone: false));

         return this.db.Map(query, r => (int?)Convert.ToInt32(r[0], CultureInfo.InvariantCulture))
            .SingleOrDefault() ?? 0;
      }

      /// <summary>
      /// Returns a number that represents how many elements in the set satisfy a condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the predicate.</param>
      /// <returns>A number that represents how many elements in the set satisfy the condition in the <paramref name="predicate"/>.</returns>
      /// <exception cref="System.OverflowException">The number of matching elements exceeds <see cref="Int32.MaxValue"/>.</exception>      

      public int Count(string predicate, params object[] parameters) {
         return Where(predicate, parameters).Count();
      }

      /// <summary>
      /// Returns the first element of the set.
      /// </summary>
      /// <returns>The first element in the set.</returns>
      /// <exception cref="System.InvalidOperationException">The set is empty.</exception>

      public object First() {
         return Take(1).AsEnumerable(singleResult: true).First();
      }

      /// <summary>
      /// Returns the first element in the set that satisfies a specified condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>The first element in the set that passes the test in the specified <paramref name="predicate"/>.</returns>
      /// <exception cref="System.InvalidOperationException">No element satisfies the condition in <paramref name="predicate"/>.-or-The set is empty.</exception>

      public object First(string predicate, params object[] parameters) {
         return Where(predicate, parameters).First();
      }

      /// <summary>
      /// Returns the first element of the set, or a default value if the set contains no elements.
      /// </summary>
      /// <returns>A default value if the set is empty; otherwise, the first element.</returns>

      public object FirstOrDefault() {
         return Take(1).AsEnumerable(singleResult: true).FirstOrDefault();
      }

      /// <summary>
      /// Returns the first element of the set that satisfies a condition or a default value if no such element is found.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>
      /// A default value if the set is empty or if no element passes the test specified by <paramref name="predicate"/>; otherwise, the 
      /// first element that passes the test specified by <paramref name="predicate"/>.
      /// </returns>

      public object FirstOrDefault(string predicate, params object[] parameters) {
         return Where(predicate, parameters).FirstOrDefault();
      }

      /// <summary>
      /// Returns an enumerator that iterates through the set.
      /// </summary>
      /// <returns>A <see cref="IEnumerator&lt;Object>"/> for the set.</returns>

      public IEnumerator<object> GetEnumerator() {
         return AsEnumerable().GetEnumerator();
      }

      /// <summary>
      /// Returns an <see cref="System.Int64"/> that represents the total number of elements in the set.
      /// </summary>
      /// <returns>The number of elements in the set.</returns>
      /// <exception cref="System.OverflowException">The number of elements is larger than <see cref="Int64.MaxValue"/>.</exception>      

      [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "long", Justification = "Consistent with LINQ.")]
      public long LongCount() {

         var query = new SqlBuilder()
            .SELECT("COUNT(*)")
            .FROM("({0}) dbex_count", GetDefiningQuery(clone: false));

         return this.db.Map(query, r => (long?)Convert.ToInt64(r[0], CultureInfo.InvariantCulture))
            .SingleOrDefault() ?? 0L;
      }

      /// <summary>
      /// Returns an <see cref="System.Int64"/> that represents how many elements in the set satisfy a condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>A number that represents how many elements in the set satisfy the condition in the <paramref name="predicate"/>.</returns>
      /// <exception cref="System.OverflowException">The number of matching elements exceeds <see cref="Int64.MaxValue"/>.</exception>      

      [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "long", Justification = "Consistent with LINQ.")]
      public long LongCount(string predicate, params object[] parameters) {
         return Where(predicate, parameters).LongCount();
      }

      /// <summary>
      /// Sorts the elements of the set according to the <paramref name="columnList"/>.
      /// </summary>
      /// <param name="columnList">The list of columns to base the sort on.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="columnList"/>.</param>
      /// <returns>A new <see cref="SqlSet"/> whose elements are sorted according to <paramref name="columnList"/>.</returns>

      public SqlSet OrderBy(string columnList, params object[] parameters) {

         bool ignoreBuffer = this.buffer.OrderBy == null
            && this.buffer.Skip == null
            && this.buffer.Take == null;

         var newBuffer = new SqlBuffer(
            where: (ignoreBuffer) ? this.buffer.Where : null,
            orderBy: new SqlFragment(columnList, parameters),
            skip: null,
            take: null
         );

         SqlSet set = CreateBufferedSet(ignoreBuffer, newBuffer);

         return set;
      }

      /// <summary>
      /// Projects each element of the set into a new form.
      /// </summary>
      /// <typeparam name="TResult">The type that <paramref name="columnList"/> maps to.</typeparam>
      /// <param name="columnList">The list of columns that maps to properties on <typeparamref name="TResult"/>.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="columnList"/>.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/>.</returns>

      public SqlSet<TResult> Select<TResult>(string columnList, params object[] parameters) {

         SqlBuilder query = GetDefiningQuery(selectFormat: columnList, args: parameters);

         return CreateSet<TResult>(query);
      }

      /// <summary>
      /// Projects each element of the set into a new form.
      /// </summary>
      /// <typeparam name="TResult">The type that <paramref name="mapper"/> returns.</typeparam>
      /// <param name="mapper">A custom mapper function that creates <typeparamref name="TResult"/> instances from the rows in the set.</param>
      /// <param name="columnList">The list of columns that are used by <paramref name="mapper"/>.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="columnList"/>.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/>.</returns>

      public SqlSet<TResult> Select<TResult>(Func<IDataRecord, TResult> mapper, string columnList, params object[] parameters) {

         SqlBuilder query = GetDefiningQuery(selectFormat: columnList, args: parameters);

         return CreateSet<TResult>(query, mapper);
      }

      /// <summary>
      /// Projects each element of the set into a new form.
      /// </summary>
      /// <param name="resultType">The type that <paramref name="columnList"/> maps to.</param>
      /// <param name="columnList">The list of columns that maps to properties on <paramref name="resultType"/>.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="columnList"/>.</param>
      /// <returns>A new <see cref="SqlSet"/>.</returns>

      public SqlSet Select(Type resultType, string columnList, params object[] parameters) {

         SqlBuilder query = GetDefiningQuery(selectFormat: columnList, args: parameters);

         return CreateSet(query, resultType);
      }

      /// <summary>
      /// Projects each element of the set into a new form.
      /// </summary>
      /// <param name="columnList">The list of columns to select.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="columnList"/>.</param>
      /// <returns>A new <see cref="SqlSet"/>.</returns>

      public SqlSet Select(string columnList, params object[] parameters) {

         SqlBuilder query = GetDefiningQuery(selectFormat: columnList, args: parameters);

         return CreateSet(query);
      }

      /// <summary>
      /// The single element of the set.
      /// </summary>
      /// <returns>The single element of the set.</returns>
      /// <exception cref="System.InvalidOperationException">The set contains more than one element.-or-The set is empty.</exception>      

      public object Single() {
         return AsEnumerable(singleResult: true).Single();
      }

      /// <summary>
      /// Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>The single element of the set that passes the test in the specified <paramref name="predicate"/>.</returns>
      /// <exception cref="System.InvalidOperationException">No element satisfies the condition in <paramref name="predicate"/>.-or-More than one element satisfies the condition in <paramref name="predicate"/>.-or-The set is empty.</exception>      

      public object Single(string predicate, params object[] parameters) {
         return Where(predicate, parameters).Single();
      }

      /// <summary>
      /// Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.
      /// </summary>
      /// <returns>The single element of the set, or a default value if the set contains no elements.</returns>
      /// <exception cref="System.InvalidOperationException">The set contains more than one element.</exception>

      public object SingleOrDefault() {
         return AsEnumerable(singleResult: true).SingleOrDefault();
      }

      /// <summary>
      /// Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>The single element of the set that satisfies the condition, or a default value if no such element is found.</returns>

      public object SingleOrDefault(string predicate, params object[] parameters) {
         return Where(predicate, parameters).SingleOrDefault();
      }

      /// <summary>
      /// Bypasses a specified number of elements in the set and then returns the remaining elements.
      /// </summary>
      /// <param name="count">The number of elements to skip before returning the remaining elements.</param>
      /// <returns>A new <see cref="SqlSet"/> that contains the elements that occur after the specified index in the current set.</returns>

      public SqlSet Skip(int count) {

         bool ignoreBuffer = this.buffer.Skip == null
            && this.buffer.Take == null;

         var newBuffer = new SqlBuffer(
            where: (ignoreBuffer) ? this.buffer.Where : null,
            orderBy: (ignoreBuffer) ? this.buffer.OrderBy : null,
            skip: count,
            take: null
         );

         SqlSet set = CreateBufferedSet(ignoreBuffer, newBuffer);

         return set;
      }

      /// <summary>
      /// Returns a specified number of contiguous elements from the start of the set.
      /// </summary>
      /// <param name="count">The number of elements to return.</param>
      /// <returns>A new <see cref="SqlSet"/> that contains the specified number of elements from the start of the current set.</returns>

      public SqlSet Take(int count) {

         bool ignoreBuffer = this.buffer.Take == null;

         var newBuffer = new SqlBuffer(
            where: (ignoreBuffer) ? this.buffer.Where : null,
            orderBy: (ignoreBuffer) ? this.buffer.OrderBy : null,
            skip: (ignoreBuffer) ? this.buffer.Skip : null,
            take: count
         );

         SqlSet set = CreateBufferedSet(ignoreBuffer, newBuffer);

         return set;
      }

      /// <summary>
      /// Creates an array from the set.
      /// </summary>
      /// <returns>An array that contains the elements from the set.</returns>

      public object[] ToArray() {
         return AsEnumerable().ToArray();
      }

      /// <summary>
      /// Creates a List&lt;object> from the set.
      /// </summary>
      /// <returns>A List&lt;object> that contains elements from the set.</returns>

      [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Consistent with LINQ.")]
      public List<object> ToList() {
         return AsEnumerable().ToList();
      }

      /// <summary>
      /// Filters the set based on a predicate.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>A new <see cref="SqlSet"/> that contains elements from the current set that satisfy the condition.</returns>

      public SqlSet Where(string predicate, params object[] parameters) {

         bool ignoreBuffer = this.buffer.Where == null
            && this.buffer.OrderBy == null
            && this.buffer.Skip == null
            && this.buffer.Take == null;

         var newBuffer = new SqlBuffer(
            where: new SqlFragment(predicate, parameters),
            orderBy: null,
            skip: null,
            take: null
         );

         SqlSet set = CreateBufferedSet(ignoreBuffer, newBuffer);

         return set;
      }

      #endregion

      #region Object Members

      /// <exclude/>

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override bool Equals(object obj) {
         return base.Equals(obj);
      }

      /// <exclude/>

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override int GetHashCode() {
         return base.GetHashCode();
      }

      /// <exclude/>

      [EditorBrowsable(EditorBrowsableState.Never)]
      [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Must match base signature.")]
      public new Type GetType() {
         return base.GetType();
      }

      /// <summary>
      /// Returns the SQL query of the set.
      /// </summary>
      /// <returns>The SQL query of the set.</returns>

      public override string ToString() {
         return GetDefiningQuery(clone: false).ToString();
      }

      #endregion

      #region Nested Types

      internal struct SqlBuffer {

         public readonly SqlFragment Where;
         public readonly SqlFragment OrderBy;
         public readonly int? Skip;
         public readonly int? Take;

         public bool HasBuffer {
            get {
               return Where != null
                  || OrderBy != null
                  || Skip != null
                  || Take != null;
            }
         }

         public SqlBuffer(SqlFragment where, SqlFragment orderBy, int? skip, int? take) {

            this.Where = where;
            this.OrderBy = orderBy;
            this.Skip = skip;
            this.Take = take;
         }
      }

      internal class SqlFragment {

         public readonly string Format;
         public readonly object[] Args;

         public SqlFragment(string format, object[] args) {
            this.Format = format;
            this.Args = args;
         }
      }

      #endregion
   }

   /// <summary>
   /// Represents an immutable, connected SQL query that maps to <typeparamref name="TResult"/> objects.
   /// This class cannot be instantiated, to get an instance use the <see cref="Database.From&lt;TResult>(string)"/> method.
   /// </summary>
   /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
   /// <inheritdoc select="remarks"/>

   public partial class SqlSet<TResult> : SqlSet, ISqlSet<SqlSet<TResult>, TResult> {

      readonly Func<IDataRecord, TResult> explicitMapper;

      internal SqlSet(SqlBuilder definingQuery, Database db)
         : base(definingQuery, typeof(TResult), db) { }

      internal SqlSet(SqlBuilder definingQuery, Func<IDataRecord, TResult> mapper, Database db)
         : base(definingQuery, typeof(TResult), db) {

         if (mapper == null) throw new ArgumentNullException(nameof(mapper));

         this.explicitMapper = mapper;
      }

      internal SqlSet(string[] fromSelect, Database db)
         : base(fromSelect, typeof(TResult), db) { }

      // These two SHOULD NOT pass TResult to base ctor
      // result type is copied from set

      private SqlSet(SqlSet<TResult> set, SqlBuilder superQuery, SqlBuffer? buffer)
         : base((SqlSet)set, superQuery, default(Type), buffer) {

         if (set == null) throw new ArgumentNullException(nameof(set));

         this.explicitMapper = set.explicitMapper;
      }

      private SqlSet(SqlSet<TResult> set, string[] fromSelect, SqlBuffer? buffer)
         : base((SqlSet)set, fromSelect, default(Type), buffer) {

         if (set == null) throw new ArgumentNullException(nameof(set));

         this.explicitMapper = set.explicitMapper;
      }

      // These two SHOULD pass TResult to base ctor

      internal SqlSet(SqlSet set, SqlBuilder superQuery, Func<IDataRecord, TResult> mapper, SqlBuffer? buffer)
         : base(set, superQuery, typeof(TResult), buffer) {

         if (mapper != null) {
            this.explicitMapper = mapper;
         }
      }

      internal SqlSet(SqlSet set, string[] fromSelect, SqlBuffer? buffer)
         : base(set, fromSelect, typeof(TResult), buffer) { }

      internal override SqlSet CreateSet(SqlBuilder superQuery, Type resultType = null, SqlBuffer? buffer = null) {

         if (resultType != null) {
            return base.CreateSet(superQuery, resultType, buffer);
         }

         return new SqlSet<TResult>(this, superQuery, buffer);
      }

      internal override SqlSet CreateSet(string[] fromSelect, Type resultType = null, SqlBuffer? buffer = null) {

         if (resultType != null) {
            return base.CreateSet(fromSelect, resultType, buffer);
         }

         return new SqlSet<TResult>(this, fromSelect, buffer);
      }

      internal override IEnumerable Map(bool singleResult) {

         if (this.explicitMapper != null) {

            SqlBuilder query = GetDefiningQuery(clone: false);

            return this.db.Map(query, this.explicitMapper);
         }

         return base.Map(singleResult).Cast<TResult>();
      }

      #region ISqlSet<SqlSet<TResult>,TResult> Members

      /// <summary>
      /// Gets all <typeparamref name="TResult"/> objects in the set. The query is deferred-executed.
      /// </summary>
      /// <returns>All <typeparamref name="TResult"/> objects in the set.</returns>

      public new IEnumerable<TResult> AsEnumerable() {
         return AsEnumerable(singleResult: false);
      }

      IEnumerable<TResult> AsEnumerable(bool singleResult) {
         return (IEnumerable<TResult>)Map(singleResult);
      }

      /// <summary>
      /// Casts the elements of the set to the specified type.
      /// </summary>
      /// <typeparam name="T">The type to cast the elements of the set to.</typeparam>
      /// <returns>A new <see cref="SqlSet&lt;T>"/> that contains each element of the current set cast to the specified type.</returns>

      [EditorBrowsable(EditorBrowsableState.Never)]
      public new SqlSet<T> Cast<T>() {
         return base.Cast<T>();
      }

      /// <inheritdoc cref="SqlSet.Cast(Type)"/>

      [EditorBrowsable(EditorBrowsableState.Never)]
      public new SqlSet Cast(Type resultType) {
         return base.Cast(resultType);
      }

      /// <inheritdoc cref="SqlSet.First()"/>

      public new TResult First() {
         return Take(1).AsEnumerable(singleResult: true).First();
      }

      /// <inheritdoc cref="SqlSet.First(String, Object[])"/>

      public new TResult First(string predicate, params object[] parameters) {
         return Where(predicate, parameters).First();
      }

      /// <inheritdoc cref="SqlSet.FirstOrDefault()"/>

      public new TResult FirstOrDefault() {
         return Take(1).AsEnumerable(singleResult: true).FirstOrDefault();
      }

      /// <inheritdoc cref="SqlSet.FirstOrDefault(String, Object[])"/>

      public new TResult FirstOrDefault(string predicate, params object[] parameters) {
         return Where(predicate, parameters).FirstOrDefault();
      }

      /// <summary>
      /// Returns an enumerator that iterates through the set.
      /// </summary>
      /// <returns>A <see cref="IEnumerator&lt;TResult>"/> for the set.</returns>

      public new IEnumerator<TResult> GetEnumerator() {
         return AsEnumerable().GetEnumerator();
      }

      /// <inheritdoc cref="SqlSet.OrderBy(String, Object[])"/>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> whose elements are sorted according to <paramref name="columnList"/>.</returns>

      public new SqlSet<TResult> OrderBy(string columnList, params object[] parameters) {
         return (SqlSet<TResult>)base.OrderBy(columnList, parameters);
      }

      /// <inheritdoc cref="SqlSet.Single()"/>

      public new TResult Single() {
         return AsEnumerable(singleResult: true).Single();
      }

      /// <inheritdoc cref="SqlSet.Single(String, Object[])"/>

      public new TResult Single(string predicate, params object[] parameters) {
         return Where(predicate, parameters).Single();
      }

      /// <inheritdoc cref="SqlSet.SingleOrDefault()"/>

      public new TResult SingleOrDefault() {
         return AsEnumerable(singleResult: true).SingleOrDefault();
      }

      /// <inheritdoc cref="SqlSet.SingleOrDefault(String, Object[])"/>

      public new TResult SingleOrDefault(string predicate, params object[] parameters) {
         return Where(predicate, parameters).SingleOrDefault();
      }

      /// <inheritdoc cref="SqlSet.Skip(Int32)"/>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains the elements that occur after the specified index in the current set.</returns>

      public new SqlSet<TResult> Skip(int count) {
         return (SqlSet<TResult>)base.Skip(count);
      }

      /// <inheritdoc cref="SqlSet.Take(Int32)"/>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains the specified number of elements from the start of the current set.</returns>

      public new SqlSet<TResult> Take(int count) {
         return (SqlSet<TResult>)base.Take(count);
      }

      /// <inheritdoc cref="SqlSet.ToArray()"/>

      public new TResult[] ToArray() {
         return AsEnumerable().ToArray();
      }

      /// <summary>
      /// Creates a List&lt;TResult> from the set.
      /// </summary>
      /// <returns>A List&lt;TResult> that contains elements from the set.</returns>

      [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Consistent with LINQ.")]
      public new List<TResult> ToList() {
         return AsEnumerable().ToList();
      }

      /// <inheritdoc cref="SqlSet.Where(String, Object[])"/>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains elements from the current set that satisfy the condition.</returns>

      public new SqlSet<TResult> Where(string predicate, params object[] parameters) {
         return (SqlSet<TResult>)base.Where(predicate, parameters);
      }

      #endregion
   }

   interface ISqlSet<TSqlSet, TSource> where TSqlSet : SqlSet {

      bool All(string predicate, params object[] parameters);
      bool Any();
      bool Any(string predicate, params object[] parameters);
      IEnumerable<TSource> AsEnumerable();
      SqlSet<TResult> Cast<TResult>();
      SqlSet Cast(Type resultType);
      int Count();
      int Count(string predicate, params object[] parameters);
      TSource First();
      TSource First(string predicate, params object[] parameters);
      TSource FirstOrDefault();
      TSource FirstOrDefault(string predicate, params object[] parameters);
      IEnumerator<TSource> GetEnumerator();
      long LongCount();
      long LongCount(string predicate, params object[] parameters);
      TSqlSet OrderBy(string columnList, params object[] parameters);
      SqlSet<TResult> Select<TResult>(string columnList, params object[] parameters);
      SqlSet<TResult> Select<TResult>(Func<IDataRecord, TResult> mapper, string columnList, params object[] parameters);
      SqlSet Select(string columnList, params object[] parameters);
      SqlSet Select(Type resultType, string columnList, params object[] parameters);
      TSource Single();
      TSource Single(string predicate, params object[] parameters);
      TSource SingleOrDefault();
      TSource SingleOrDefault(string predicate, params object[] parameters);
      TSqlSet Skip(int count);
      TSqlSet Take(int count);
      TSource[] ToArray();
      List<TSource> ToList();
      TSqlSet Where(string predicate, params object[] parameters);
   }
}
