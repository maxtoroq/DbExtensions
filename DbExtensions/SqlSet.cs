// Copyright 2012-2013 Max Toro Q.
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
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections;

namespace DbExtensions {

   /// <summary>
   /// Represents an immutable, connected SQL query.
   /// </summary>
   [DebuggerDisplay("{definingQuery}")]
   public partial class SqlSet : ISqlSet<SqlSet, object> {

      const string SetAliasPrefix = "dbex_set";

      // definingQuery should NEVER be modified

      readonly SqlBuilder definingQuery;
      readonly Type resultType;
      readonly ISqlSetContext context;
      readonly int setIndex = 1;

      // OrderBy and Skip calls are buffered for the following reasons:
      // - Append LIMIT and OFFSET as one clause (MySQL, SQLite), in the appropiate order
      //   e.g. Skip(x).Take(y) -> LIMIT y OFFSET x
      // - Append ORDER BY, OFFSET and FETCH as one clause (for SQL Server)
      // - Minimize the number of subqueries

      SqlFragment orderByBuffer;
      int? skipBuffer;

      /// <summary>
      /// The database connection.
      /// </summary>
      private DbConnection Connection { 
         get { return context.Connection; } 
      }

      /// <summary>
      /// A <see cref="TextWriter"/> used to log when queries are executed.
      /// </summary>
      internal TextWriter Log {
         get { return context.Log; }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlSet"/> class
      /// using the provided defining query.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      public SqlSet(SqlBuilder definingQuery) 
         : this(definingQuery, Database.CreateConnection()) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlSet"/> class
      /// using the provided defining query and connection.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="connection">The database connection.</param>
      public SqlSet(SqlBuilder definingQuery, DbConnection connection) 
         : this(definingQuery, connection, (TextWriter)null) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlSet"/> class
      /// using the provided defining query, connection and logger.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="connection">The database connection.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when queries are executed.</param>
      public SqlSet(SqlBuilder definingQuery, DbConnection connection, TextWriter logger)
         : this(definingQuery, (Type)null, connection, logger) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlSet"/> class
      /// using the provided defining query and result type.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="resultType">The type of objects to map the results to.</param>
      public SqlSet(SqlBuilder definingQuery, Type resultType)
         : this(definingQuery, resultType, Database.CreateConnection()) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlSet"/> class
      /// using the provided defining query, result type and connection.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="resultType">The type of objects to map the results to.</param>
      /// <param name="connection">The database connection.</param>
      public SqlSet(SqlBuilder definingQuery, Type resultType, DbConnection connection) 
         : this(definingQuery, resultType, connection, (TextWriter)null) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlSet"/> class
      /// using the provided defining query, result type, connection and logger.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="resultType">The type of objects to map the results to.</param>
      /// <param name="connection">The database connection.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when queries are executed.</param>
      public SqlSet(SqlBuilder definingQuery, Type resultType, DbConnection connection, TextWriter logger)
         : this(definingQuery, resultType, connection, logger, adoptQuery: false) { }

      internal SqlSet(SqlBuilder definingQuery, Type resultType, DbConnection connection, TextWriter logger, bool adoptQuery) 
         : this(definingQuery, resultType, new SqlSetDefaultContext(connection, logger), adoptQuery) { }

      internal SqlSet(SqlBuilder definingQuery, Type resultType, ISqlSetContext context, bool adoptQuery) {

         if (definingQuery == null) throw new ArgumentNullException("definingQuery");

         this.definingQuery = (adoptQuery) ?
            definingQuery
            : definingQuery.Clone();

         this.resultType = resultType;
         this.context = context;
      }

      protected SqlSet(SqlSet set, SqlBuilder superQuery) {

         if (set == null) throw new ArgumentNullException("set");
         if (superQuery == null) throw new ArgumentNullException("superQuery");

         this.definingQuery = superQuery;
         this.resultType = set.resultType;
         this.setIndex += set.setIndex;
         this.context = set.context;
      }

      protected SqlSet(SqlSet set, SqlBuilder superQuery, Type resultType)
         : this(set, superQuery) {

         this.resultType = resultType;
      }

      /// <summary>
      /// Returns the SQL query that is the source of data for the set.
      /// </summary>
      /// <returns>The SQL query that is the source of data for the set</returns>
      [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Calling the member twice in succession creates different results.")]
      public SqlBuilder GetDefiningQuery() {
         return GetDefiningQuery(clone: true);
      }

      internal SqlBuilder GetDefiningQuery(bool clone = true, bool omitBufferedCalls = false) {

         bool hasBufferedCalls = skipBuffer.HasValue || orderByBuffer != null;
         bool applyBuffer = hasBufferedCalls && !omitBufferedCalls;

         if (applyBuffer) {
            return OrderBySkipTake(null);
         }

         SqlBuilder query = this.definingQuery;

         if (clone) {
            query = query.Clone();
         }

         return query;
      }

      void CopyBufferState(SqlSet otherSet) {

         otherSet.orderByBuffer = this.orderByBuffer;
         otherSet.skipBuffer = this.skipBuffer;
      }

      SqlBuilder OrderBySkipTake(int? take = null) {

         if (IsSqlServer()) {
            return OrderBySkipTake_SqlServer(take);
         }

         if (IsOracle()) {
            return OrderBySkipTake_Oracle(take);
         }

         return OrderBySkipTake_Default(take);
      }

      SqlBuilder OrderBySkipTake_Default(int? take = null) {

         bool hasOrderBy = this.orderByBuffer != null;
         bool hasSkip = this.skipBuffer.HasValue;
         bool hasTake = take.HasValue;

         if (hasOrderBy
            || hasTake
            || hasSkip) {

            SqlBuilder query = CreateSuperQuery(this.definingQuery, null, null);

            if (hasOrderBy) {
               query.ORDER_BY(this.orderByBuffer.Format, this.orderByBuffer.Args);
            }

            if (hasTake) {
               query.LIMIT(take.Value);
            }

            if (hasSkip) {
               query.OFFSET(this.skipBuffer.Value);
            }

            return query;
         }

         return null;
      }

      SqlBuilder OrderBySkipTake_SqlServer(int? take = null) {

         bool hasOrderBy = this.orderByBuffer != null;
         bool hasSkip = this.skipBuffer.HasValue;
         bool hasTake = take.HasValue;

         if (hasSkip) {

            SqlBuilder query = CreateSuperQuery(this.definingQuery, null, null);

            if (hasOrderBy) {
               query.ORDER_BY(this.orderByBuffer.Format, this.orderByBuffer.Args);

            } else {

               // Cannot have OFFSET without ORDER BY
               query.ORDER_BY("1");
            }

            query.OFFSET("{0} ROWS", this.skipBuffer.Value);

            if (hasTake)
               query.AppendClause("FETCH", null, "NEXT {0} ROWS ONLY", new object[] { take.Value });

            return query;
         }

         if (hasTake) {

            SqlBuilder query = CreateSuperQuery(this.definingQuery, "TOP({0}) *", new object[] { take.Value });

            if (hasOrderBy) {
               query.ORDER_BY(this.orderByBuffer.Format, this.orderByBuffer.Args);
            }

            return query;
         }

         if (hasOrderBy) {

            SqlBuilder query = CreateSuperQuery(this.definingQuery, null, null);

            query.ORDER_BY(this.orderByBuffer.Format, this.orderByBuffer.Args);

            // The ORDER BY clause is invalid in subqueries, unless TOP, OFFSET or FOR XML is also specified.

            query.OFFSET("0 ROWS");
         }

         return null;
      }

      SqlBuilder OrderBySkipTake_Oracle(int? take = null) { 
         
         bool hasOrderBy = this.orderByBuffer != null;
         bool hasSkip = this.skipBuffer.HasValue;
         bool hasTake = take.HasValue;

         if (hasSkip || hasTake) {

            string queryAlias = SetAliasPrefix + this.setIndex.ToString(CultureInfo.InvariantCulture);
            string innerQueryAlias = queryAlias + "_1";
            string rowNumberAlias = "dbex_rn";

            int start = (hasSkip) ? this.skipBuffer.Value : 0;
            int? end = (hasTake) ? start + take.Value : default(int?);

            var innerQuery = new SqlBuilder();

            if (hasOrderBy) {

               innerQuery
                  .SELECT(String.Concat("ROW_NUMBER() OVER (ORDER BY ", this.orderByBuffer.Format, ") AS ", rowNumberAlias), this.orderByBuffer.Args);
            
            } else {

               innerQuery
                  .SELECT("ROWNUM AS " + rowNumberAlias);
            }

            innerQuery
               .SELECT(innerQueryAlias + ".*")
               .FROM(this.definingQuery, innerQueryAlias);

            var query = new SqlBuilder()
               .SELECT("*")
               .FROM(innerQuery, queryAlias);

            if (end.HasValue) {
               query.WHERE(rowNumberAlias + " BETWEEN {0} AND {1}", (start + 1), end.Value);
            
            } else {
               query.WHERE(rowNumberAlias + " > {0}", start);
            }

            query.ORDER_BY(rowNumberAlias);

            query.IgnoredColumns.Add(0);

            return query;
         }

         if (hasOrderBy) {

            SqlBuilder query = CreateSuperQuery(this.definingQuery, null, null);

            query.ORDER_BY(this.orderByBuffer.Format, this.orderByBuffer.Args);

            return query;
         }

         return null;
      }

      bool IsSqlServer() {
         return this.Connection is System.Data.SqlClient.SqlConnection
            || this.Connection.GetType().Namespace.Equals("System.Data.SqlServerCe", StringComparison.Ordinal);
      }

      bool IsOracle() {
         return this.Connection.GetType().Namespace.Equals("System.Data.OracleClient", StringComparison.Ordinal);
      }

      protected SqlBuilder CreateSuperQuery() {
         return CreateSuperQuery(null, null);
      }

      protected SqlBuilder CreateSuperQuery(string selectFormat, params object[] args) {
         return CreateSuperQuery(GetDefiningQuery(clone: false), selectFormat, args);
      }

      SqlBuilder CreateSuperQuery(SqlBuilder definingQuery, string selectFormat, object[] args) {

         var query = new SqlBuilder()
            .SELECT(selectFormat ?? "*", args)
            .FROM(definingQuery, SetAliasPrefix + this.setIndex.ToString(CultureInfo.InvariantCulture));

         if (selectFormat == null) {

            if (definingQuery.HasIgnoredColumns) {
               
               foreach (int item in definingQuery.IgnoredColumns) {
                  query.IgnoredColumns.Add(item);
               } 
            }
         }

         return query;
      }

      protected virtual SqlSet CreateSet(SqlBuilder superQuery) {
         return new SqlSet(this, superQuery);
      }

      protected virtual SqlSet CreateSet(SqlBuilder superQuery, Type resultType) {
         return new SqlSet(this, superQuery, resultType);
      }

      protected virtual SqlSet<TResult> CreateSet<TResult>(SqlBuilder superQuery) {
         return new SqlSet<TResult>(this, superQuery);
      }

      protected virtual SqlSet<TResult> CreateSet<TResult>(SqlBuilder superQuery, Func<IDataRecord, TResult> mapper) {
         return new SqlSet<TResult>(this, superQuery, mapper);
      }

      internal DbCommand CreateCommand(SqlBuilder sqlBuilder) {
         return this.context.CreateCommand(sqlBuilder);
      }

      /// <summary>
      /// This member supports the DbExtensions infrastructure and is not intended to be used directly from your code.
      /// </summary>
      [Obsolete]
      protected virtual IEnumerable Execute(DbCommand command) {

         if (this.resultType == null) {
#if NET35
            throw new InvalidOperationException("Cannot map set, a result type was not specified when this set was created. Call the 'Cast' method first.");
#else
            return command.Map(this.Log);
#endif
         }

         return command.Map(resultType, this.Log);
      }

      internal virtual IEnumerable Map() {

         SqlBuilder query = GetDefiningQuery(clone: false);

         if (this.resultType == null) {
            return Extensions.Map<object>(q => CreateCommand(query), query, new PocoMapper(this.resultType, this.Log), this.Log);

         } else {
#if NET35
            throw new InvalidOperationException("Cannot map set, a result type was not specified when this set was created. Call the 'Cast' method first.");
#else
            return Extensions.Map<dynamic>(q => CreateCommand(query), query, new DynamicMapper(this.Log), this.Log);
#endif
         }
      }

      #region ISqlSet<SqlSet,object> Members

      /// <summary>
      /// Determines whether all elements of the set satisfy a condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <returns>true if every element of the set passes the test in the specified <paramref name="predicate"/>, or if the set is empty; otherwise, false.</returns>
      public bool All(string predicate) {
         return All(predicate, null);
      }

      /// <summary>
      /// Determines whether all elements of the set satisfy a condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>true if every element of the set passes the test in the specified <paramref name="predicate"/>, or if the set is empty; otherwise, false.</returns>
      public bool All(string predicate, params object[] parameters) {

         if (predicate == null) throw new ArgumentNullException("predicate");

         predicate = String.Concat("NOT (", predicate, ")");

         return !Any(predicate, parameters);
      }

      /// <summary>
      /// Determines whether the set contains any elements.
      /// </summary>
      /// <returns>true if the sequence contains any elements; otherwise, false.</returns>
      public bool Any() {
         return this.Connection.Exists(CreateCommand(Extensions.ExistsQuery(GetDefiningQuery(clone: false))), this.Log);
      }

      /// <summary>
      /// Determines whether any element of the set satisfies a condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <returns>true if any elements in the set pass the test in the specified <paramref name="predicate"/>; otherwise, false.</returns>
      public bool Any(string predicate) {
         return Where(predicate).Any();
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

         IEnumerable enumerable = Map();

         return enumerable as IEnumerable<object>
            ?? enumerable.Cast<object>();
      }

      /// <summary>
      /// Casts the elements of the set to the specified type.
      /// </summary>
      /// <typeparam name="TResult">The type to cast the elements of the set to.</typeparam>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains each element of the current set cast to the specified type.</returns>
      public SqlSet<TResult> Cast<TResult>() {

         if (this.resultType != null
            && this.resultType != typeof(TResult)) {
            throw new InvalidOperationException("The specified type parameter is not valid for this instance.");
         }

         return CreateSet<TResult>(GetDefiningQuery());
      }

      /// <summary>
      /// Casts the elements of the set to the specified type.
      /// </summary>
      /// <param name="resultType">The type to cast the elements of the set to.</param>
      /// <returns>A new <see cref="SqlSet"/> that contains each element of the current set cast to the specified type.</returns>
      public SqlSet Cast(Type resultType) {

         if (this.resultType != null
            && this.resultType != resultType) {
            throw new InvalidOperationException("The specified resultType is not valid for this instance.");
         }

         return CreateSet(GetDefiningQuery(), resultType);
      }

      /// <summary>
      /// Returns the number of elements in the set.
      /// </summary>
      /// <returns>The number of elements in the set.</returns>
      /// <exception cref="System.OverflowException">The number of elements is larger than <see cref="Int32.MaxValue"/>.</exception>      
      public int Count() {
         return this.Connection.Count(CreateCommand(Extensions.CountQuery(GetDefiningQuery(clone: false))), this.Log);
      }

      /// <summary>
      /// Returns a number that represents how many elements in the set satisfy a condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <returns>A number that represents how many elements in the set satisfy the condition in the <paramref name="predicate"/>.</returns>
      /// <exception cref="System.OverflowException">The number of matching elements exceeds <see cref="Int32.MaxValue"/>.</exception>      
      public int Count(string predicate) {
         return Where(predicate).Count();
      }

      /// <summary>
      /// Gets the number of elements in the set that matches the <paramref name="predicate"/>.
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
         return Take(1).AsEnumerable().First();
      }

      /// <summary>
      /// Returns the first element in the set that satisfies a specified condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <returns>The first element in the set that passes the test in the specified <paramref name="predicate"/>.</returns>
      /// <exception cref="System.InvalidOperationException">No element satisfies the condition in <paramref name="predicate"/>.-or-The set is empty.</exception>
      public object First(string predicate) {
         return Where(predicate).First();
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
         return Take(1).AsEnumerable().FirstOrDefault();
      }

      /// <summary>
      /// Returns the first element of the set that satisfies a condition or a default value if no such element is found.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <returns>
      /// A default value if the set is empty or if no element passes the test specified by <paramref name="predicate"/>; otherwise, the 
      /// first element that passes the test specified by <paramref name="predicate"/>.
      /// </returns>
      public object FirstOrDefault(string predicate) {
         return Where(predicate).FirstOrDefault();
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
         return this.Connection.LongCount(CreateCommand(Extensions.CountQuery(GetDefiningQuery(clone: false))), this.Log);
      }

      /// <summary>
      /// Returns an <see cref="System.Int64"/> that represents how many elements in the set satisfy a condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <returns>A number that represents how many elements in the set satisfy the condition in the <paramref name="predicate"/>.</returns>
      /// <exception cref="System.OverflowException">The number of matching elements exceeds <see cref="Int64.MaxValue"/>.</exception>      
      public long LongCount(string predicate) {
         return Where(predicate).LongCount();
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
      /// <returns>A new <see cref="SqlSet"/> whose elements are sorted according to <paramref name="columnList"/>.</returns>
      public SqlSet OrderBy(string columnList) {
         return OrderBy(columnList, null);
      }

      /// <summary>
      /// Sorts the elements of the set according to the <paramref name="columnList"/>.
      /// </summary>
      /// <param name="columnList">The list of columns to base the sort on.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="columnList"/>.</param>
      /// <returns>A new <see cref="SqlSet"/> whose elements are sorted according to <paramref name="columnList"/>.</returns>
      public SqlSet OrderBy(string columnList, params object[] parameters) {

         SqlBuilder query = (this.orderByBuffer == null) ?
            GetDefiningQuery(omitBufferedCalls: true)
            : CreateSuperQuery();

         SqlSet set = CreateSet(query);
         CopyBufferState(set);
         set.orderByBuffer = new SqlFragment(columnList, parameters);

         return set;
      }

      /// <summary>
      /// Projects each element of the set into a new form.
      /// </summary>
      /// <typeparam name="TResult">The type that <paramref name="columnList"/> maps to.</typeparam>
      /// <param name="columnList">The list of columns that maps to properties on <typeparamref name="TResult"/>.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/>.</returns>
      public SqlSet<TResult> Select<TResult>(string columnList) {
         return Select<TResult>(columnList, null);
      }

      /// <summary>
      /// Projects each element of the set into a new form.
      /// </summary>
      /// <typeparam name="TResult">The type that <paramref name="columnList"/> maps to.</typeparam>
      /// <param name="columnList">The list of columns that maps to properties on <typeparamref name="TResult"/>.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="columnList"/>.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/>.</returns>
      public SqlSet<TResult> Select<TResult>(string columnList, params object[] parameters) {

         var superQuery = CreateSuperQuery(columnList, parameters);

         return CreateSet<TResult>(superQuery);
      }

      /// <summary>
      /// Projects each element of the set into a new form.
      /// </summary>
      /// <typeparam name="TResult">The type that <paramref name="mapper"/> returns.</typeparam>
      /// <param name="mapper">A custom mapper function that creates <typeparamref name="TResult"/> instances from the rows in the set.</param>
      /// <param name="columnList">The list of columns that are used by <paramref name="mapper"/>.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/>.</returns>
      public SqlSet<TResult> Select<TResult>(Func<IDataRecord, TResult> mapper, string columnList) {
         return Select<TResult>(mapper, columnList, null);
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

         var superQuery = CreateSuperQuery(columnList, parameters);

         return CreateSet<TResult>(superQuery, mapper);
      }

      /// <summary>
      /// Projects each element of the set into a new form.
      /// </summary>
      /// <param name="resultType">The type that <paramref name="columnList"/> maps to.</param>
      /// <param name="columnList">The list of columns that maps to properties on <paramref name="resultType"/>.</param>
      /// <returns>A new <see cref="SqlSet"/>.</returns>
      public SqlSet Select(Type resultType, string columnList) {
         return Select(resultType, columnList, null);
      }

      /// <summary>
      /// Projects each element of the set into a new form.
      /// </summary>
      /// <param name="resultType">The type that <paramref name="columnList"/> maps to.</param>
      /// <param name="columnList">The list of columns that maps to properties on <paramref name="resultType"/>.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="columnList"/>.</param>
      /// <returns>A new <see cref="SqlSet"/>.</returns>
      public SqlSet Select(Type resultType, string columnList, params object[] parameters) {

         var superQuery = CreateSuperQuery(columnList, parameters);

         return CreateSet(superQuery, resultType);
      }

      /// <summary>
      /// The single element of the set.
      /// </summary>
      /// <returns>The single element of the set.</returns>
      /// <exception cref="System.InvalidOperationException">The set contains more than one element.-or-The set is empty.</exception>      
      public object Single() {
         return AsEnumerable().Single();
      }

      /// <summary>
      /// Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <returns>The single element of the set that passes the test in the specified <paramref name="predicate"/>.</returns>
      /// <exception cref="System.InvalidOperationException">No element satisfies the condition in <paramref name="predicate"/>.-or-More than one element satisfies the condition in <paramref name="predicate"/>.-or-The set is empty.</exception>      
      public object Single(string predicate) {
         return Where(predicate).Single();
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
         return AsEnumerable().SingleOrDefault();
      }

      /// <summary>
      /// Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <returns>The single element of the set that satisfies the condition, or a default value if no such element is found.</returns>
      public object SingleOrDefault(string predicate) {
         return Where(predicate).SingleOrDefault();
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

         SqlBuilder query = (!this.skipBuffer.HasValue) ?
            GetDefiningQuery(omitBufferedCalls: true)
            : CreateSuperQuery();

         SqlSet set = CreateSet(query);
         CopyBufferState(set);
         set.skipBuffer = count;

         return set;
      }

      /// <summary>
      /// Returns a specified number of contiguous elements from the start of the set.
      /// </summary>
      /// <param name="count">The number of elements to return.</param>
      /// <returns>A new <see cref="SqlSet"/> that contains the specified number of elements from the start of the current set.</returns>
      public SqlSet Take(int count) {

         SqlBuilder query = OrderBySkipTake(count);

         return CreateSet(query);
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
      /// <returns>A new <see cref="SqlSet"/> that contains elements from the current set that satisfy the condition.</returns>
      public SqlSet Where(string predicate) {
         return Where(predicate, null);
      }

      /// <summary>
      /// Filters the set based on a predicate.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>A new <see cref="SqlSet"/> that contains elements from the current set that satisfy the condition.</returns>
      public SqlSet Where(string predicate, params object[] parameters) {

         var superQuery = CreateSuperQuery()
            .WHERE(predicate, parameters);

         return CreateSet(superQuery);
      }

      /// <summary>
      /// Produces the set union of the current set with <paramref name="otherSet"/>.
      /// </summary>
      /// <param name="otherSet">A <see cref="SqlSet"/> whose distinct elements form the second set for the union.</param>
      /// <returns>A new <see cref="SqlSet"/> that contains the elements from both sets, excluding duplicates.</returns>
      public SqlSet Union(SqlSet otherSet) {

         if (otherSet == null) throw new ArgumentNullException("otherSet");

         // TODO: check result compatibility?

         var superQuery = CreateSuperQuery()
            .UNION()
            .Append(otherSet.CreateSuperQuery());

         return CreateSet(superQuery);
      }

      #endregion

      #region Object Members

      /// <summary>
      /// Returns whether the specified set is equal to the current set.
      /// </summary>
      /// <param name="obj">The set to compare with the current set. </param>
      /// <returns>True if the specified set is equal to the current set; otherwise, false.</returns>
      [EditorBrowsable(EditorBrowsableState.Never)]
      public override bool Equals(object obj) {
         return base.Equals(obj);
      }

      /// <summary>
      /// Returns the hash function for the current set.
      /// </summary>
      /// <returns>The hash function for the current set.</returns>
      [EditorBrowsable(EditorBrowsableState.Never)]
      public override int GetHashCode() {
         return base.GetHashCode();
      }

      /// <summary>
      /// Gets the type for the current set.
      /// </summary>
      /// <returns>The type for the current set.</returns>
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

      sealed class SqlFragment {
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
   /// </summary>
   /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
   public class SqlSet<TResult> : SqlSet, ISqlSet<SqlSet<TResult>, TResult> {

      readonly Func<IDataRecord, TResult> mapper;

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlSet&lt;TResult>"/> class
      /// using the provided defining query.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      public SqlSet(SqlBuilder definingQuery)
         : base(definingQuery, typeof(TResult)) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlSet&lt;TResult>"/> class
      /// using the provided defining query and connection.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="connection">The database connection.</param>
      public SqlSet(SqlBuilder definingQuery, DbConnection connection) 
         : base(definingQuery, typeof(TResult), connection) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlSet&lt;TResult>"/> class
      /// using the provided defining query, connection and logger.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="connection">The database connection.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when queries are executed.</param>
      public SqlSet(SqlBuilder definingQuery, DbConnection connection, TextWriter logger)
         : base(definingQuery, typeof(TResult), connection, logger) { }

      internal SqlSet(SqlBuilder definingQuery, ISqlSetContext context, bool adoptQuery)
         : base(definingQuery, typeof(TResult), context, adoptQuery) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlSet&lt;TResult>"/> class
      /// using the provided defining query and mapper.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="mapper">A custom mapper function that creates <typeparamref name="TResult"/> instances from the rows in the set.</param>
      public SqlSet(SqlBuilder definingQuery, Func<IDataRecord, TResult> mapper)
         : this(definingQuery, mapper, Database.CreateConnection()) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlSet&lt;TResult>"/> class
      /// using the provided defining query, mapper and connection.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="mapper">A custom mapper function that creates <typeparamref name="TResult"/> instances from the rows in the set.</param>
      /// <param name="connection">The database connection.</param>
      public SqlSet(SqlBuilder definingQuery, Func<IDataRecord, TResult> mapper, DbConnection connection) 
         : this(definingQuery, mapper, connection, (TextWriter)null) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlSet&lt;TResult>"/> class
      /// using the provided defining query, mapper, connection and logger.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="mapper">A custom mapper function that creates <typeparamref name="TResult"/> instances from the rows in the set.</param>
      /// <param name="connection">The database connection.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when queries are executed.</param>
      public SqlSet(SqlBuilder definingQuery, Func<IDataRecord, TResult> mapper, DbConnection connection, TextWriter logger)
         : base(definingQuery, typeof(TResult), connection, logger) {

         if (mapper == null) throw new ArgumentNullException("mapper");

         this.mapper = mapper;
      }

      internal SqlSet(SqlBuilder definingQuery, Func<IDataRecord, TResult> mapper, ISqlSetContext context, bool adoptQuery) 
         : base(definingQuery, typeof(TResult), context, adoptQuery) {

         if (mapper == null) throw new ArgumentNullException("mapper");

         this.mapper = mapper;
      }

      protected SqlSet(SqlSet<TResult> set, SqlBuilder superQuery) 
         : base((SqlSet)set, superQuery) {

         if (set == null) throw new ArgumentNullException("set");

         this.mapper = set.mapper;
      }

      // These constructors are used by SqlSet

      internal SqlSet(SqlSet set, SqlBuilder superQuery)
         : base(set, superQuery, typeof(TResult)) { }

      internal SqlSet(SqlSet set, SqlBuilder superQuery, Func<IDataRecord, TResult> mapper)
         : base(set, superQuery, typeof(TResult)) {

         if (mapper == null) throw new ArgumentNullException("mapper");

         this.mapper = mapper;
      }

      protected override SqlSet CreateSet(SqlBuilder superQuery) {
         return new SqlSet<TResult>(this, superQuery);
      }

      protected override SqlSet<T> CreateSet<T>(SqlBuilder superQuery) {
         return new SqlSet<T>(this, superQuery);
      }

      /// <summary>
      /// This member supports the DbExtensions infrastructure and is not intended to be used directly from your code.
      /// </summary>
      [Obsolete]
      protected override IEnumerable Execute(DbCommand command) {

         if (this.mapper != null)
            return command.Map(this.mapper, this.Log);

         return command.Map<TResult>(this.Log);
      }

      internal override IEnumerable Map() {

         SqlBuilder query = GetDefiningQuery(clone: false);

         if (this.mapper != null) {
            return CreateCommand(query).Map(this.mapper, this.Log);

         } else {
            return Extensions.Map<TResult>(q => CreateCommand(q), query, new PocoMapper(typeof(TResult), this.Log), this.Log);
         }
      }

      #region ISqlSet<SqlSet<TResult>,TResult> Members

      /// <summary>
      /// Gets all <typeparamref name="TResult"/> objects in the set. The query is deferred-executed.
      /// </summary>
      /// <returns>All <typeparamref name="TResult"/> objects in the set.</returns>
      public new IEnumerable<TResult> AsEnumerable() {
         return (IEnumerable<TResult>)Map();
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

      /// <summary>
      /// Casts the elements of the set to the specified type.
      /// </summary>
      /// <param name="resultType">The type to cast the elements of the set to.</param>
      /// <returns>A new <see cref="SqlSet"/> that contains each element of the current set cast to the specified type.</returns>
      [EditorBrowsable(EditorBrowsableState.Never)]
      public new SqlSet Cast(Type resultType) {
         return base.Cast(resultType);
      }

      /// <summary>
      /// Returns the first element of the set.
      /// </summary>
      /// <returns>The first element in the set.</returns>
      /// <exception cref="System.InvalidOperationException">The set is empty.</exception>
      public new TResult First() {
         return Take(1).AsEnumerable().First();
      }

      /// <summary>
      /// Returns the first element in the set that satisfies a specified condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <returns>The first element in the set that passes the test in the specified <paramref name="predicate"/>.</returns>
      /// <exception cref="System.InvalidOperationException">No element satisfies the condition in <paramref name="predicate"/>.-or-The set is empty.</exception>
      public new TResult First(string predicate) {
         return Where(predicate).First();
      }

      /// <summary>
      /// Returns the first element in the set that satisfies a specified condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>The first element in the set that passes the test in the specified <paramref name="predicate"/>.</returns>
      /// <exception cref="System.InvalidOperationException">No element satisfies the condition in <paramref name="predicate"/>.-or-The set is empty.</exception>
      public new TResult First(string predicate, params object[] parameters) {
         return Where(predicate, parameters).First();
      }

      /// <summary>
      /// Returns the first element of the set, or a default value if the set contains no elements.
      /// </summary>
      /// <returns>A default value if the set is empty; otherwise, the first element.</returns>
      public new TResult FirstOrDefault() {
         return Take(1).AsEnumerable().FirstOrDefault();
      }

      /// <summary>
      /// Returns the first element of the set that satisfies a condition or a default value if no such element is found.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <returns>
      /// A default value if the set is empty or if no element passes the test specified by <paramref name="predicate"/>; otherwise, the 
      /// first element that passes the test specified by <paramref name="predicate"/>.
      /// </returns>
      public new TResult FirstOrDefault(string predicate) {
         return Where(predicate).FirstOrDefault();
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

      /// <summary>
      /// Sorts the elements of the set according to the <paramref name="columnList"/>.
      /// </summary>
      /// <param name="columnList">The list of columns to base the sort on.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> whose elements are sorted according to <paramref name="columnList"/>.</returns>
      public new SqlSet<TResult> OrderBy(string columnList) {
         return (SqlSet<TResult>)base.OrderBy(columnList);
      }

      /// <summary>
      /// Sorts the elements of the set according to the <paramref name="columnList"/>.
      /// </summary>
      /// <param name="columnList">The list of columns to base the sort on.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="columnList"/>.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> whose elements are sorted according to <paramref name="columnList"/>.</returns>
      public new SqlSet<TResult> OrderBy(string columnList, params object[] parameters) {
         return (SqlSet<TResult>)base.OrderBy(columnList, parameters);
      }

      /// <summary>
      /// The single element of the set.
      /// </summary>
      /// <returns>The single element of the set.</returns>
      /// <exception cref="System.InvalidOperationException">The set contains more than one element.-or-The set is empty.</exception>      
      public new TResult Single() {
         return AsEnumerable().Single();
      }

      /// <summary>
      /// Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <returns>The single element of the set that passes the test in the specified <paramref name="predicate"/>.</returns>
      /// <exception cref="System.InvalidOperationException">No element satisfies the condition in <paramref name="predicate"/>.-or-More than one element satisfies the condition in <paramref name="predicate"/>.-or-The set is empty.</exception>      
      public new TResult Single(string predicate) {
         return Where(predicate).Single();
      }

      /// <summary>
      /// Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>The single element of the set that passes the test in the specified <paramref name="predicate"/>.</returns>
      /// <exception cref="System.InvalidOperationException">No element satisfies the condition in <paramref name="predicate"/>.-or-More than one element satisfies the condition in <paramref name="predicate"/>.-or-The set is empty.</exception>      
      public new TResult Single(string predicate, params object[] parameters) {
         return Where(predicate, parameters).Single();
      }

      /// <summary>
      /// Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.
      /// </summary>
      /// <returns>The single element of the set, or a default value if the set contains no elements.</returns>
      /// <exception cref="System.InvalidOperationException">The set contains more than one element.</exception>
      public new TResult SingleOrDefault() {
         return AsEnumerable().SingleOrDefault();
      }

      /// <summary>
      /// Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <returns>The single element of the set that satisfies the condition, or a default value if no such element is found.</returns>
      public new TResult SingleOrDefault(string predicate) {
         return Where(predicate).SingleOrDefault();
      }

      /// <summary>
      /// Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>The single element of the set that satisfies the condition, or a default value if no such element is found.</returns>
      public new TResult SingleOrDefault(string predicate, params object[] parameters) {
         return Where(predicate, parameters).SingleOrDefault();
      }

      /// <summary>
      /// Bypasses a specified number of elements in the set and then returns the remaining elements.
      /// </summary>
      /// <param name="count">The number of elements to skip before returning the remaining elements.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains the elements that occur after the specified index in the current set.</returns>
      public new SqlSet<TResult> Skip(int count) {
         return (SqlSet<TResult>)base.Skip(count);
      }

      /// <summary>
      /// Returns a specified number of contiguous elements from the start of the set.
      /// </summary>
      /// <param name="count">The number of elements to return.</param>
      /// <returns>A new <see cref="SqlSet"/> that contains the specified number of elements from the start of the current set.</returns>
      public new SqlSet<TResult> Take(int count) {
         return (SqlSet<TResult>)base.Take(count);
      }

      /// <summary>
      /// Creates an array from the set.
      /// </summary>
      /// <returns>An array that contains the elements from the set.</returns>
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

      /// <summary>
      /// Filters the set based on a predicate.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains elements from the current set that satisfy the condition.</returns>
      public new SqlSet<TResult> Where(string predicate) {
         return (SqlSet<TResult>)base.Where(predicate);
      }

      /// <summary>
      /// Filters the set based on a predicate.
      /// </summary>
      /// <param name="predicate">A SQL expression to test each row for a condition.</param>
      /// <param name="parameters">The parameters to apply to the <paramref name="predicate"/>.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains elements from the current set that satisfy the condition.</returns>
      public new SqlSet<TResult> Where(string predicate, params object[] parameters) {
         return (SqlSet<TResult>)base.Where(predicate, parameters);
      }

      /// <summary>
      /// Produces the set union of the current set with <paramref name="otherSet"/>.
      /// </summary>
      /// <param name="otherSet">A <see cref="SqlSet&lt;TResult>"/> whose distinct elements form the second set for the union.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> that contains the elements from both sets, excluding duplicates.</returns>
      public SqlSet<TResult> Union(SqlSet<TResult> otherSet) {
         return (SqlSet<TResult>)base.Union(otherSet);
      }

      #endregion
   }

   public static partial class Extensions {

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet"/> using the provided defining query.
      /// </summary>
      /// <param name="connection">The connection that the set is bound to.</param>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <returns>A new <see cref="SqlSet"/> object.</returns>
      public static SqlSet Set(this DbConnection connection, SqlBuilder definingQuery) {
         return new SqlSet(definingQuery, connection);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet"/> using the provided defining query and logger.
      /// </summary>
      /// <param name="connection">The connection that the set is bound to.</param>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when queries are executed.</param>
      /// <returns>A new <see cref="SqlSet"/> object.</returns>
      public static SqlSet Set(this DbConnection connection, SqlBuilder definingQuery, TextWriter logger) {
         return new SqlSet(definingQuery, connection, logger);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet"/> using the provided defining query and result type.
      /// </summary>
      /// <param name="connection">The connection that the set is bound to.</param>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="resultType">The type of objects to map the results to.</param>
      /// <returns>A new <see cref="SqlSet"/> object.</returns>
      public static SqlSet Set(this DbConnection connection, SqlBuilder definingQuery, Type resultType) {
         return new SqlSet(definingQuery, resultType, connection);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet"/> using the provided defining query, result type and logger.
      /// </summary>
      /// <param name="connection">The connection that the set is bound to.</param>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="resultType">The type of objects to map the results to.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when queries are executed.</param>
      /// <returns>A new <see cref="SqlSet"/> object.</returns>
      public static SqlSet Set(this DbConnection connection, SqlBuilder definingQuery, Type resultType, TextWriter logger) {
         return new SqlSet(definingQuery, resultType, connection, logger);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided defining query.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="connection">The connection that the set is bound to.</param>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> object.</returns>
      public static SqlSet<TResult> Set<TResult>(this DbConnection connection, SqlBuilder definingQuery) {
         return new SqlSet<TResult>(definingQuery, connection);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided defining query and logger.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="connection">The connection that the set is bound to.</param>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when queries are executed.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> object.</returns>
      public static SqlSet<TResult> Set<TResult>(this DbConnection connection, SqlBuilder definingQuery, TextWriter logger) {
         return new SqlSet<TResult>(definingQuery, connection, logger);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided defining query and mapper.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="connection">The connection that the set is bound to.</param>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="mapper">A custom mapper function that creates <typeparamref name="TResult"/> instances from the rows in the set.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> object.</returns>
      public static SqlSet<TResult> Set<TResult>(this DbConnection connection, SqlBuilder definingQuery, Func<IDataRecord, TResult> mapper) {
         return new SqlSet<TResult>(definingQuery, mapper, connection);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided defining query, mapper and logger.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="connection">The connection that the set is bound to.</param>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="mapper">A custom mapper function that creates <typeparamref name="TResult"/> instances from the rows in the set.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when queries are executed.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> object.</returns>
      public static SqlSet<TResult> Set<TResult>(this DbConnection connection, SqlBuilder definingQuery, Func<IDataRecord, TResult> mapper, TextWriter logger) {
         return new SqlSet<TResult>(definingQuery, mapper, connection, logger);
      }
   }

   interface ISqlSet<TSqlSet, TSource> where TSqlSet : SqlSet {

      bool All(string predicate);
      bool All(string predicate, params object[] parameters);
      bool Any();
      bool Any(string predicate);
      bool Any(string predicate, params object[] parameters);
      IEnumerable<TSource> AsEnumerable();
      SqlSet<TResult> Cast<TResult>();
      SqlSet Cast(Type resultType);
      int Count();
      int Count(string predicate);
      int Count(string predicate, params object[] parameters);
      TSource First();
      TSource First(string predicate);
      TSource First(string predicate, params object[] parameters);
      TSource FirstOrDefault();
      TSource FirstOrDefault(string predicate);
      TSource FirstOrDefault(string predicate, params object[] parameters);
      IEnumerator<TSource> GetEnumerator();
      long LongCount();
      long LongCount(string predicate);
      long LongCount(string predicate, params object[] parameters);
      TSqlSet OrderBy(string columnList);
      TSqlSet OrderBy(string columnList, params object[] parameters);
      SqlSet<TResult> Select<TResult>(string columnList);
      SqlSet<TResult> Select<TResult>(string columnList, params object[] parameters);
      SqlSet<TResult> Select<TResult>(Func<IDataRecord, TResult> mapper, string columnList);
      SqlSet<TResult> Select<TResult>(Func<IDataRecord, TResult> mapper, string columnList, params object[] parameters);
      SqlSet Select(Type resultType, string columnList);
      SqlSet Select(Type resultType, string columnList, params object[] parameters);
      TSource Single();
      TSource Single(string predicate);
      TSource Single(string predicate, params object[] parameters);
      TSource SingleOrDefault();
      TSource SingleOrDefault(string predicate);
      TSource SingleOrDefault(string predicate, params object[] parameters);
      TSqlSet Skip(int count);
      TSqlSet Take(int count);
      TSource[] ToArray();
      List<TSource> ToList();
      TSqlSet Where(string predicate);
      TSqlSet Where(string predicate, params object[] parameters);
      TSqlSet Union(TSqlSet otherSet);
   }

   interface ISqlSetContext {

      DbConnection Connection { get; }
      TextWriter Log { get; }

      DbCommand CreateCommand(SqlBuilder query);
   }

   sealed class SqlSetDefaultContext : ISqlSetContext {

      readonly DbConnection _Connection;
      readonly TextWriter _Log;

      public DbConnection Connection {
         get { return _Connection; }
      }

      public TextWriter Log {
         get { return _Log; }
      }

      public SqlSetDefaultContext(DbConnection connection, TextWriter log = null) {

         if (connection == null) throw new ArgumentNullException("connection");

         this._Connection = connection;
         this._Log = log;
      }

      public DbCommand CreateCommand(SqlBuilder query) {
         return query.ToCommand(this.Connection);
      }
   }
}
