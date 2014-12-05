// Copyright 2012-2014 Max Toro Q.
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
   /// <seealso href="../../../SqlSet.md">SqlSet Tutorial</seealso>
   public class SqlSet : ISqlSet<SqlSet, object> {

      const string SetAliasPrefix = "dbex_set";
      static readonly object padlock = new object();
      static readonly IDictionary<Type, SqlDialect> connectionDialect = new Dictionary<Type, SqlDialect>();

      // definingQuery should NEVER be modified

      readonly SqlBuilder definingQuery;
      readonly string[] fromSelect;
      internal readonly Type resultType;
      internal readonly IConnectionContext context;

      int setIndex = 1;

      SqlFragment _WhereBuffer;
      SqlFragment _OrderByBuffer;
      int? _SkipBuffer;
      int? _TakeBuffer;
      IDictionary<string[], CollectionLoader> _ManyIncludes;

      /// <summary>
      /// A <see cref="TextWriter"/> used to log when queries are executed.
      /// </summary>
      internal TextWriter Log {
         get { return context.Log; }
      }

      private bool HasBufferedCalls {
         get {
            return _WhereBuffer != null
               || _OrderByBuffer != null
               || _SkipBuffer.HasValue
               || _TakeBuffer.HasValue;
         }
      }

      private SqlFragment WhereBuffer {
         get { return _WhereBuffer; }
         set {
            if (value != null
               && _WhereBuffer != null) {

               throw new InvalidOperationException();
            }
            _WhereBuffer = value;
         }
      }

      private SqlFragment OrderByBuffer {
         get { return _OrderByBuffer; }
         set {
            if (value != null
               && _OrderByBuffer != null) {

               throw new InvalidOperationException();
            }
            _OrderByBuffer = value;
         }
      }

      private int? SkipBuffer {
         get { return _SkipBuffer; }
         set {
            if (value != null
               && _SkipBuffer != null) {

               throw new InvalidOperationException();
            }
            _SkipBuffer = value;
         }
      }

      private int? TakeBuffer {
         get { return _TakeBuffer; }
         set {
            if (value != null
               && _TakeBuffer != null) {

               throw new InvalidOperationException();
            }
            _TakeBuffer = value;
         }
      }

      internal IDictionary<string[], CollectionLoader> ManyIncludes {
         get { return _ManyIncludes; }
         set {
            if (_ManyIncludes != null) {
               throw new InvalidOperationException();
            }
            _ManyIncludes = value;
         }
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
         : this(definingQuery, (Type)null, connection) { }

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
         : this(definingQuery, resultType, new SimpleConnectionContext(connection)) { }

      internal SqlSet(SqlBuilder definingQuery, Type resultType, IConnectionContext context) {

         if (definingQuery == null) throw new ArgumentNullException("definingQuery");

         this.definingQuery = definingQuery.Clone();
         this.resultType = resultType;
         this.context = context;
      }

      internal SqlSet(string[] fromSelect, Type resultType, IConnectionContext context) {

         if (fromSelect == null) throw new ArgumentNullException("fromSelect");
         if (fromSelect.Length != 2) throw new ArgumentException("fromSelect.Length must be 2.", "fromSelect");

         this.fromSelect = fromSelect;
         this.resultType = resultType;
         this.context = context;
      }

      internal SqlSet(SqlSet set) {

         if (set == null) throw new ArgumentNullException("set");

         this.resultType = set.resultType;
         this.setIndex += set.setIndex;
         this.context = set.context;

         if (set.ManyIncludes != null) {
            this.ManyIncludes = new Dictionary<string[], CollectionLoader>(set.ManyIncludes);
         }
      }

      internal SqlSet(SqlSet set, SqlBuilder superQuery, Type resultType = null) 
         : this(set) {

         if (superQuery == null) throw new ArgumentNullException("superQuery");

         this.definingQuery = superQuery;

         if (resultType != null) {
            this.resultType = resultType;
         }
      }

      internal SqlSet(SqlSet set, string[] fromSelect, Type resultType = null) 
         : this(set) {

         if (fromSelect == null) throw new ArgumentNullException("fromSelect");
         if (fromSelect.Length != 2) throw new ArgumentException("fromSelect.Length must be 2.", "fromSelect");

         this.fromSelect = fromSelect;

         if (resultType != null) {
            this.resultType = resultType; 
         }
      }

      /// <summary>
      /// Returns the SQL query that is the source of data for the set.
      /// </summary>
      /// <returns>The SQL query that is the source of data for the set</returns>
      [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Calling the member twice in succession creates different results.")]
      public SqlBuilder GetDefiningQuery() {
         return GetDefiningQuery(clone: true);
      }

      internal SqlBuilder GetDefiningQuery(bool clone = true, bool omitBufferedCalls = false, bool super = false, string selectFormat = null, object[] args = null) {

         if (!omitBufferedCalls
            && this.HasBufferedCalls) {

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

      void CopyBufferState(SqlSet otherSet) {

         otherSet.WhereBuffer = this.WhereBuffer;
         otherSet.OrderByBuffer = this.OrderByBuffer;
         otherSet.SkipBuffer = this.SkipBuffer;
         otherSet.TakeBuffer = this.TakeBuffer;
      }

      SqlBuilder BuildQuery(string selectFormat = null, object[] args = null) {

         switch (GetConnectionDialect()) {
            case SqlDialect.Default:
               return BuildQuery_Default(selectFormat, args);
               
            case SqlDialect.SqlServer:
               return BuildQuery_SqlServer(selectFormat, args);

            case SqlDialect.Oracle:
               return BuildQuery_Oracle(selectFormat, args);
            
            default:
               throw new NotImplementedException();
         }
      }

      SqlBuilder BuildQuery_Default(string selectFormat = null, object[] args = null) {

         SqlFragment whereBuffer = this.WhereBuffer;
         SqlFragment orderByBuffer = this.OrderByBuffer;
         int? skipBuffer = this.SkipBuffer;
         int? takeBuffer = this.TakeBuffer;

         bool hasWhere = whereBuffer != null;
         bool hasOrderBy = orderByBuffer != null;
         bool hasSkip = skipBuffer.HasValue;
         bool hasTake = takeBuffer.HasValue;

         SqlBuilder query = GetDefiningQuery(omitBufferedCalls: true, super: true, selectFormat: selectFormat, args: args);

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

      SqlBuilder BuildQuery_SqlServer(string selectFormat = null, object[] args = null) {

         SqlFragment whereBuffer = this.WhereBuffer;
         SqlFragment orderByBuffer = this.OrderByBuffer;
         int? skipBuffer = this.SkipBuffer;
         int? takeBuffer = this.TakeBuffer;

         bool hasWhere = whereBuffer != null;
         bool hasOrderBy = orderByBuffer != null;
         bool hasSkip = skipBuffer.HasValue;
         bool hasTake = takeBuffer.HasValue;

         SqlBuilder definingQuery = GetDefiningQuery(omitBufferedCalls: true, super: true, selectFormat: selectFormat, args: args);

         if (hasSkip) {

            SqlBuilder query = GetDefiningQuery(omitBufferedCalls: true, super: true, selectFormat: selectFormat, args: args);

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
               query.AppendClause("FETCH", null, "NEXT {0} ROWS ONLY", new object[] { takeBuffer.Value });
            }

            return query;
         }

         if (hasTake) {

            SqlBuilder query = GetDefiningQuery(omitBufferedCalls: true, super: true, selectFormat: "TOP({0}) *", args: new object[] { takeBuffer.Value });

            if (hasWhere) {
               query.WHERE(whereBuffer.Format, whereBuffer.Args);
            }

            if (hasOrderBy) {
               query.ORDER_BY(orderByBuffer.Format, orderByBuffer.Args);
            }

            if (selectFormat != null) {
               query = CreateSuperQuery(query, selectFormat, args);
            }

            return query;
         }

         if (hasWhere
            || hasOrderBy) {

            SqlBuilder query = GetDefiningQuery(omitBufferedCalls: true, super: true, selectFormat: selectFormat, args: args);

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

         return definingQuery;
      }

      SqlBuilder BuildQuery_Oracle(string selectFormat = null, object[] args = null) {

         SqlFragment whereBuffer = this.WhereBuffer;
         SqlFragment orderByBuffer = this.OrderByBuffer;
         int? skipBuffer = this.SkipBuffer;
         int? takeBuffer = this.TakeBuffer;

         bool hasWhere = whereBuffer != null;
         bool hasOrderBy = orderByBuffer != null;
         bool hasSkip = skipBuffer.HasValue;
         bool hasTake = takeBuffer.HasValue;

         SqlBuilder definingQuery = GetDefiningQuery(omitBufferedCalls: true, selectFormat: selectFormat, args: args);

         if (hasSkip 
            || hasTake) {

            string queryAlias = SetAliasPrefix + GetNextIndex().ToString(CultureInfo.InvariantCulture);
            string innerQueryAlias = queryAlias + "_1";
            const string rowNumberAlias = "dbex_rn";

            int start = (hasSkip) ? skipBuffer.Value : 0;
            int? end = (hasTake) ? start + takeBuffer.Value : default(int?);

            var innerQuery = new SqlBuilder();

            if (hasOrderBy) {

               innerQuery
                  .SELECT(String.Concat("ROW_NUMBER() OVER (ORDER BY ", orderByBuffer.Format, ") AS ", rowNumberAlias), orderByBuffer.Args);
            
            } else {

               innerQuery
                  .SELECT("ROWNUM AS " + rowNumberAlias);
            }

            innerQuery
               .SELECT(innerQueryAlias + ".*")
               .FROM(definingQuery, innerQueryAlias);

            if (hasWhere) {
               innerQuery.WHERE(whereBuffer.Format, whereBuffer.Args);
            }

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

         if (hasWhere
            || hasOrderBy) {

            SqlBuilder query = definingQuery;

            if (hasWhere) {
               query.WHERE(whereBuffer.Format, whereBuffer.Args);
            }

            if (hasOrderBy) {
               query.ORDER_BY(orderByBuffer.Format, orderByBuffer.Args); 
            }

            return query;
         }

         return definingQuery;
      }

      SqlDialect GetConnectionDialect() {

         DbConnection conn = this.context.Connection;
         Type connType = conn.GetType();

         SqlDialect dialect;

         if (!connectionDialect.TryGetValue(connType, out dialect)) {
            lock (padlock) {
               if (!connectionDialect.TryGetValue(connType, out dialect)) {

                  dialect = IsSqlServer(conn) ? SqlDialect.SqlServer
                     : IsOracle(conn) ? SqlDialect.Oracle
                     : SqlDialect.Default;

                  connectionDialect[connType] = dialect;
               }
            }
         }

         return dialect;
      }

      static bool IsSqlServer(DbConnection conn) {
         return conn is System.Data.SqlClient.SqlConnection
            || conn.GetType().Namespace.Equals("System.Data.SqlServerCe", StringComparison.Ordinal);
      }

      static bool IsOracle(DbConnection conn) {
         return conn.GetType().Namespace.Equals("System.Data.OracleClient", StringComparison.Ordinal);
      }

      internal SqlBuilder CreateSuperQuery() {
         return CreateSuperQuery(null, null);
      }

      internal SqlBuilder CreateSuperQuery(string selectFormat, params object[] args) {
         return CreateSuperQuery(GetDefiningQuery(clone: false), selectFormat, args);
      }

      SqlBuilder CreateSuperQuery(SqlBuilder definingQuery, string selectFormat, object[] args) {

         var query = new SqlBuilder()
            .SELECT(selectFormat ?? "*", args)
            .FROM(definingQuery, SetAliasPrefix + GetNextIndex().ToString(CultureInfo.InvariantCulture));

         if (selectFormat == null) {

            if (definingQuery.HasIgnoredColumns) {
               
               foreach (int item in definingQuery.IgnoredColumns) {
                  query.IgnoredColumns.Add(item);
               } 
            }
         }

         return query;
      }

      int GetNextIndex() {
         return this.setIndex++;
      }

      internal virtual SqlSet CreateSet(SqlBuilder superQuery, Type resultType = null) {
         return new SqlSet(this, superQuery, resultType);
      }

      internal virtual SqlSet CreateSet(string[] fromSelect, Type resultType = null) {
         return new SqlSet(this, fromSelect, resultType);
      }

      internal SqlSet<TResult> CreateSet<TResult>(SqlBuilder superQuery, Func<IDataRecord, TResult> mapper = null) {
         return new SqlSet<TResult>(this, superQuery, mapper);
      }

      internal SqlSet<TResult> CreateSet<TResult>(string[] fromSelect) {
         return new SqlSet<TResult>(this, fromSelect);
      }

      internal SqlSet CreateSet(bool omitBufferedCalls, Type resultType = null) {

         SqlSet set = null;

         if (omitBufferedCalls
            && this.definingQuery == null) {
               
            set = CreateSet(this.fromSelect, resultType);
         }

         if (set == null) {
            
            SqlBuilder query = GetDefiningQuery(
               omitBufferedCalls: omitBufferedCalls
            );

            set = CreateSet(query, resultType);
         }
         
         CopyBufferState(set);

         return set;
      }

      internal SqlSet<TResult> CreateSet<TResult>(bool omitBufferedCalls) {

         SqlSet<TResult> set = null;

         if (omitBufferedCalls
            && this.definingQuery == null) {

            set = CreateSet<TResult>(this.fromSelect);
         }

         if (set == null) {

            SqlBuilder query = GetDefiningQuery(
               omitBufferedCalls: omitBufferedCalls
            );

            set = CreateSet<TResult>(query);
         }

         CopyBufferState(set);

         return set;
      }

      internal DbCommand CreateCommand(SqlBuilder sqlBuilder) {
         return this.context.CreateCommand(sqlBuilder);
      }

      internal virtual IEnumerable Map(bool singleResult) {

         SqlBuilder query = GetDefiningQuery(clone: false);

         if (this.resultType != null) {
            return Extensions.Map<object>(q => CreateCommand(query), query, CreatePocoMapper(singleResult), this.Log);
         }

         return Extensions.Map<dynamic>(
            q => CreateCommand(query),
            query,
            new DynamicMapper { 
               Log = this.Log,
               ManyIncludes = this.ManyIncludes,
               SingleResult = singleResult
            },
            this.Log
         );
      }

      internal PocoMapper CreatePocoMapper(bool singleResult) {

         return new PocoMapper(this.resultType) {
            Log = this.Log,
            ManyIncludes = this.ManyIncludes,
            SingleResult = singleResult
         };
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
         return this.context.ExistsImpl(GetDefiningQuery(clone: false));
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

         if (this.resultType != null
            && this.resultType != typeof(TResult)) {
            throw new InvalidOperationException("The specified type parameter is not valid for this instance.");
         }

         return CreateSet<TResult>(omitBufferedCalls: true);
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

         return CreateSet(omitBufferedCalls: true, resultType: resultType);
      }

      /// <summary>
      /// Returns the number of elements in the set.
      /// </summary>
      /// <returns>The number of elements in the set.</returns>
      /// <exception cref="System.OverflowException">The number of elements is larger than <see cref="Int32.MaxValue"/>.</exception>      
      public int Count() {
         return this.context.CountImpl(GetDefiningQuery(clone: false));
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
         return Take(1).AsEnumerable(singleResult: true).First();
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
         return Take(1).AsEnumerable(singleResult: true).FirstOrDefault();
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
         return this.context.LongCountImpl(GetDefiningQuery(clone: false));
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

         bool omitBufferedCalls = this.OrderByBuffer == null
            && this.SkipBuffer == null
            && this.TakeBuffer == null;

         SqlSet set = CreateSet(omitBufferedCalls);

         if (!omitBufferedCalls) {
            set.WhereBuffer = null;
         }

         set._OrderByBuffer = new SqlFragment(columnList, parameters);
         set.SkipBuffer = null;
         set.TakeBuffer = null;

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

         SqlBuilder query = GetDefiningQuery(selectFormat: columnList, args: parameters);

         return CreateSet<TResult>(query);
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

         SqlBuilder query = GetDefiningQuery(selectFormat: columnList, args: parameters);

         return CreateSet<TResult>(query, mapper);
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

         SqlBuilder query = GetDefiningQuery(selectFormat: columnList, args: parameters);

         return CreateSet(query, resultType);
      }

      /// <summary>
      /// Projects each element of the set into a new form.
      /// </summary>
      /// <param name="columnList">The list of columns to select.</param>
      /// <returns>A new <see cref="SqlSet"/>.</returns>
      public SqlSet Select(string columnList) {
         return Select(columnList, null);
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
         return AsEnumerable(singleResult: true).SingleOrDefault();
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

         bool omitBufferedCalls = this.SkipBuffer == null
            && this.TakeBuffer == null;

         SqlSet set = CreateSet(omitBufferedCalls);

         if (!omitBufferedCalls) {
            set.WhereBuffer = null;
            set.OrderByBuffer = null;
         }

         set._SkipBuffer = count;
         set.TakeBuffer = null;

         return set;
      }

      /// <summary>
      /// Returns a specified number of contiguous elements from the start of the set.
      /// </summary>
      /// <param name="count">The number of elements to return.</param>
      /// <returns>A new <see cref="SqlSet"/> that contains the specified number of elements from the start of the current set.</returns>
      public SqlSet Take(int count) {

         bool omitBufferedCalls = this.TakeBuffer == null;

         SqlSet set = CreateSet(omitBufferedCalls);

         if (!omitBufferedCalls) {
            set.WhereBuffer = null;
            set.OrderByBuffer = null;
            set.SkipBuffer = null;
         }

         set._TakeBuffer = count;

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

         bool omitBufferedCalls = this.WhereBuffer == null 
            && this.OrderByBuffer == null 
            && this.SkipBuffer == null
            && this.TakeBuffer == null;

         SqlSet set = CreateSet(omitBufferedCalls);
         
         set._WhereBuffer = new SqlFragment(predicate, parameters);
         set.OrderByBuffer = null;
         set.SkipBuffer = null;
         set.TakeBuffer = null;

         return set;
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

      enum SqlDialect { 
         Default = 0,
         SqlServer,
         Oracle
      }

      #endregion
   }

   /// <summary>
   /// Represents an immutable, connected SQL query that maps to <typeparamref name="TResult"/> objects.
   /// </summary>
   /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
   /// <seealso href="../../../SqlSet.md">SqlSet Tutorial</seealso>
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

      internal SqlSet(SqlBuilder definingQuery, IConnectionContext context)
         : base(definingQuery, typeof(TResult), context) { }

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
         : base(definingQuery, typeof(TResult), connection) {

         if (mapper == null) throw new ArgumentNullException("mapper");

         this.mapper = mapper;
      }

      internal SqlSet(SqlBuilder definingQuery, Func<IDataRecord, TResult> mapper, IConnectionContext context) 
         : base(definingQuery, typeof(TResult), context) {

         if (mapper == null) throw new ArgumentNullException("mapper");

         this.mapper = mapper;
      }

      internal SqlSet(string[] fromSelect, IConnectionContext context)
         : base(fromSelect, typeof(TResult), context) { }

      internal SqlSet(SqlSet<TResult> set, SqlBuilder superQuery) 
         : base((SqlSet)set, superQuery) {

         if (set == null) throw new ArgumentNullException("set");

         this.mapper = set.mapper;
      }

      internal SqlSet(SqlSet<TResult> set, string[] fromSelect)
         : base((SqlSet)set, fromSelect) {

         if (set == null) throw new ArgumentNullException("set");

         this.mapper = set.mapper;
      }

      internal SqlSet(SqlSet set, SqlBuilder superQuery, Func<IDataRecord, TResult> mapper = null)
         : base(set, superQuery, typeof(TResult)) {

         if (mapper != null) {
            this.mapper = mapper;
         }
      }

      internal SqlSet(SqlSet set, string[] fromSelect)
         : base(set, fromSelect, typeof(TResult)) { }

      internal override SqlSet CreateSet(SqlBuilder superQuery, Type resultType = null) {

         if (resultType != null) {
            return base.CreateSet(superQuery, resultType);
         }

         return new SqlSet<TResult>(this, superQuery);
      }

      internal override SqlSet CreateSet(string[] fromSelect, Type resultType = null) {

         if (resultType != null) {
            return base.CreateSet(fromSelect, resultType);
         }

         return new SqlSet<TResult>(this, fromSelect);
      }

      internal override IEnumerable Map(bool singleResult) {

         SqlBuilder query = GetDefiningQuery(clone: false);

         if (this.mapper != null) {
            return CreateCommand(query).Map(this.mapper, this.Log);
         }

         return Extensions.Map<TResult>(q => CreateCommand(q), query, CreatePocoMapper(singleResult), this.Log);
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
         return Take(1).AsEnumerable(singleResult: true).First();
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
         return Take(1).AsEnumerable(singleResult: true).FirstOrDefault();
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
         return AsEnumerable(singleResult: true).Single();
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
         return AsEnumerable(singleResult: true).SingleOrDefault();
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

      #endregion
   }

   public static partial class Extensions {

      internal static int CountImpl(this IConnectionContext context, SqlBuilder query) {
         return Count(context.CreateCommand(CountQuery(query)), context.Log);
      }

      internal static long LongCountImpl(this IConnectionContext context, SqlBuilder query) {
         return LongCount(context.CreateCommand(CountQuery(query)), context.Log);
      }

      static SqlBuilder CountQuery(SqlBuilder query) {

         return new SqlBuilder()
            .SELECT("COUNT(*)")
            .FROM("({0}) dbex_count", query);
      }

      static int Count(IDbCommand command, TextWriter logger) {
         return Convert.ToInt32(CountExecute(command, logger), CultureInfo.InvariantCulture);
      }

      static long LongCount(IDbCommand command, TextWriter logger) {
         return Convert.ToInt64(CountExecute(command, logger), CultureInfo.InvariantCulture);
      }

      static object CountExecute(IDbCommand command, TextWriter logger) {
         return command.Map(r => r[0], logger).SingleOrDefault() ?? 0;
      }

      internal static bool ExistsImpl(this IConnectionContext context, SqlBuilder query) {
         return Exists(context.CreateCommand(ExistsQuery(query)), context.Log);
      }

      static SqlBuilder ExistsQuery(SqlBuilder query) {

         return new SqlBuilder()
            .SELECT("(CASE WHEN EXISTS ({0}) THEN 1 ELSE 0 END)", query);
      }

      static bool Exists(IDbCommand command, TextWriter logger) {

         return command.Map(r => Convert.ToInt32(r[0], CultureInfo.InvariantCulture) != 0, logger)
            .SingleOrDefault();
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
      SqlSet Select(string columnList);
      SqlSet Select(string columnList, params object[] parameters);
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
   }

   interface IConnectionContext {

      DbConnection Connection { get; }
      TextWriter Log { get; }

      DbCommand CreateCommand(SqlBuilder query);
   }

   sealed class SimpleConnectionContext : IConnectionContext {

      readonly DbConnection _Connection;
      readonly TextWriter _Log;

      public DbConnection Connection {
         get { return _Connection; }
      }

      public TextWriter Log {
         get { return _Log; }
      }

      public SimpleConnectionContext(DbConnection connection, TextWriter log = null) {

         if (connection == null) throw new ArgumentNullException("connection");

         this._Connection = connection;
         this._Log = log;
      }

      public DbCommand CreateCommand(SqlBuilder query) {
         return query.ToCommand(this.Connection);
      }
   }
}
