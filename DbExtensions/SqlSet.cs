// Copyright 2012 Max Toro Q.
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

namespace DbExtensions {

   [DebuggerDisplay("{definingQuery}")]
   public class SqlSet : ISqlSet<SqlSet, object> {

      readonly DbConnection connection;
      readonly SqlBuilder definingQuery;
      readonly Type resultType;
      readonly int setIndex = 1;
      int? sqlOffset;

      public DbConnection Connection { get { return connection; } }
      public TextWriter Log { get; set; }

      public SqlSet(DbConnection connection, SqlBuilder definingQuery) 
         : this(connection, definingQuery, adoptQuery: false) { }

      public SqlSet(DbConnection connection, SqlBuilder definingQuery, Type resultType) 
         : this(connection, definingQuery, resultType, adoptQuery: false) { }

      protected SqlSet(SqlSet set, SqlBuilder superQuery) {

         if (set == null) throw new ArgumentNullException("set");
         if (superQuery == null) throw new ArgumentNullException("superQuery");

         this.connection = set.connection;
         this.definingQuery = superQuery;
         this.resultType = set.resultType;
         this.Log = set.Log;
         this.setIndex += set.setIndex;
      }

      protected SqlSet(SqlSet set, SqlBuilder superQuery, Type resultType)
         : this(set, superQuery) {

         this.resultType = resultType;
      }

      private SqlSet(DbConnection connection, SqlBuilder definingQuery, bool adoptQuery) {

         if (connection == null) throw new ArgumentNullException("connection");
         if (definingQuery == null) throw new ArgumentNullException("definingQuery");

         this.connection = connection;
         this.definingQuery = (adoptQuery) ?
            definingQuery
            : definingQuery.Clone();
      }

      // This constructor is used by SqlTable
      internal SqlSet(DbConnection connection, SqlBuilder definingQuery, Type resultType, bool adoptQuery) 
         : this(connection, definingQuery, adoptQuery) {
         
         this.resultType = resultType;
      }

      [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Calling the member twice in succession creates different results.")]
      public SqlBuilder GetDefiningQuery() {
         return GetDefiningQuery(clone: true);
      }

      SqlBuilder GetDefiningQuery(bool clone = true, bool omitBufferedOffset = false) {

         SqlBuilder query = (clone) ? 
            this.definingQuery.Clone()
            : this.definingQuery;

         if (this.sqlOffset.HasValue 
            && !omitBufferedOffset) {
            
            if (!clone)
               query = query.Clone();

            query.OFFSET(this.sqlOffset.Value);
         }

         return query;
      }

      protected SqlBuilder CreateSuperQuery() {
         return CreateSuperQuery(null, null);
      }

      protected SqlBuilder CreateSuperQuery(string selectFormat, params object[] args) {

         var query = new SqlBuilder()
            .SELECT(selectFormat ?? "*", args)
            .FROM(GetDefiningQuery(clone: false), "__set" + this.setIndex.ToString(CultureInfo.InvariantCulture));

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

      protected DbCommand CreateCommand() {
         return CreateCommand(GetDefiningQuery(clone: false));
      }

      protected DbCommand CreateCommand(SqlBuilder sqlBuilder) {

         if (sqlBuilder == null) throw new ArgumentNullException("sqlBuilder");

         return CreateCommand(sqlBuilder.ToString(), sqlBuilder.ParameterValues.ToArray());
      }

      protected DbCommand CreateCommand(string commandText) {
         return CreateCommand(commandText, null);
      }

      protected virtual DbCommand CreateCommand(string commandText, params object[] parameters) {
         return this.connection.CreateCommand(commandText, parameters);
      }

      public IEnumerator<object> GetEnumerator() {
         return AsEnumerable().GetEnumerator();
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override bool Equals(object obj) {
         return base.Equals(obj);
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override int GetHashCode() {
         return base.GetHashCode();
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Must match base signature.")]
      public new Type GetType() {
         return base.GetType();
      }

      public override string ToString() {
         return GetDefiningQuery(clone: false).ToString();
      }

      #region ISqlSet<SqlSet,object> Members

      public bool All(string predicate) {
         return All(predicate, null);
      }

      public bool All(string predicate, params object[] parameters) {

         using (this.connection.EnsureOpen())
            return LongCount() == Where(predicate, parameters).LongCount();
      }

      /// <summary>
      /// Checks if the set contains rows.
      /// </summary>
      /// <returns>true id the set contains rows; otherwise, false.</returns>
      public bool Any() {
         return this.connection.Exists(CreateCommand(DbExtensionMethods.ExistsQuery(GetDefiningQuery(clone: false))), this.Log);
      }

      public bool Any(string predicate) {
         return Where(predicate).Any();
      }

      /// <summary>
      /// Checks if <paramref name="predicate"/> matches any of the rows in the set.
      /// </summary>
      /// <param name="predicate">The SQL predicate.</param>
      /// <param name="parameters">The parameters to use in the predicate.</param>
      /// <returns>true if at least one row matches the <paramref name="predicate"/>; otherwise, false.</returns>
      public bool Any(string predicate, params object[] parameters) {
         return Where(predicate, parameters).Any();
      }

      /// <summary>
      /// Gets all objects in the set. The query is deferred-executed.
      /// </summary>
      /// <returns>All objects in the set.</returns>
      public IEnumerable<object> AsEnumerable() {

         if (this.resultType == null)
            throw new InvalidOperationException("Cannot map set, a result type was not specified when this set was created. Call the 'Cast' method first.");

         return CreateCommand().Map(resultType, this.Log);
      }

      public SqlSet<TResult> Cast<TResult>() {
         return CreateSet<TResult>(GetDefiningQuery());
      }

      public SqlSet Cast(Type resultType) {
         return CreateSet(GetDefiningQuery(), resultType);
      }

      public int Count() {
         return this.connection.Count(CreateCommand(DbExtensionMethods.CountQuery(GetDefiningQuery(clone: false))), this.Log);
      }

      public int Count(string predicate) {
         return Where(predicate).Count();
      }

      /// <summary>
      /// Gets the number of rows in the set that matches the <paramref name="predicate"/>.
      /// </summary>
      /// <param name="predicate">The SQL predicate.</param>
      /// <param name="parameters">The parameters to use in the predicate.</param>
      /// <returns>The number of rows that match the <paramref name="predicate"/>.</returns>
      public int Count(string predicate, params object[] parameters) {
         return Where(predicate, parameters).Count();
      }

      public object First() {
         return Take(1).AsEnumerable().First();
      }

      public object First(string predicate) {
         return Where(predicate).First();
      }

      public object First(string predicate, params object[] parameters) {
         return Where(predicate, parameters).First();
      }

      public object FirstOrDefault() {
         return Take(1).AsEnumerable().FirstOrDefault();
      }

      public object FirstOrDefault(string predicate) {
         return Where(predicate).FirstOrDefault();
      }

      public object FirstOrDefault(string predicate, params object[] parameters) {
         return Where(predicate, parameters).FirstOrDefault();
      }

      [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "long", Justification = "Consistent with LINQ.")]
      public long LongCount() {
         return this.connection.LongCount(CreateCommand(DbExtensionMethods.CountQuery(GetDefiningQuery(clone: false))), this.Log);
      }

      public long LongCount(string predicate) {
         return Where(predicate).LongCount();
      }

      /// <summary>
      /// Gets the number of rows in the set that matches the <paramref name="predicate"/>.
      /// </summary>
      /// <param name="predicate">The SQL predicate.</param>
      /// <param name="parameters">The parameters to use in the predicate.</param>
      /// <returns>The number of rows that match the <paramref name="predicate"/>.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "long", Justification = "Consistent with LINQ.")]
      public long LongCount(string predicate, params object[] parameters) {
         return Where(predicate, parameters).LongCount();
      }

      public SqlSet OrderBy(string format) {
         return OrderBy(format, null);
      }

      public SqlSet OrderBy(string format, params object[] args) {

         var superQuery = CreateSuperQuery()
            .ORDER_BY(format, args);

         return CreateSet(superQuery);
      }

      public SqlSet<TResult> Select<TResult>(string format) {
         return Select<TResult>(format, null);
      }

      public SqlSet<TResult> Select<TResult>(string format, params object[] args) {

         var superQuery = CreateSuperQuery(format, args);

         return CreateSet<TResult>(superQuery);
      }

      public SqlSet<TResult> Select<TResult>(Func<IDataRecord, TResult> mapper, string format) {
         return Select<TResult>(mapper, format, null);
      }

      public SqlSet<TResult> Select<TResult>(Func<IDataRecord, TResult> mapper, string format, params object[] args) {

         var superQuery = CreateSuperQuery(format, args);

         return CreateSet<TResult>(superQuery, mapper);
      }

      public SqlSet Select(Type resultType, string format) {
         return Select(resultType, format, null);
      }

      public SqlSet Select(Type resultType, string format, params object[] args) {

         var superQuery = CreateSuperQuery(format, args);

         return CreateSet(superQuery, resultType);
      }

      public object Single() {
         return AsEnumerable().Single();
      }

      public object Single(string predicate) {
         return Where(predicate).Single();
      }

      public object Single(string predicate, params object[] parameters) {
         return Where(predicate, parameters).Single();
      }

      public object SingleOrDefault() {
         return AsEnumerable().SingleOrDefault();
      }

      public object SingleOrDefault(string predicate) {
         return Where(predicate).SingleOrDefault();
      }

      public object SingleOrDefault(string predicate, params object[] parameters) {
         return Where(predicate, parameters).SingleOrDefault();
      }

      public SqlSet Skip(int count) {

         SqlSet set = CreateSet(GetDefiningQuery());
         set.sqlOffset = count;

         return set;
      }

      public SqlSet Take(int count) {

         bool hasBufferedOffset = this.sqlOffset.HasValue;

         SqlBuilder query = (hasBufferedOffset) ?
            GetDefiningQuery(omitBufferedOffset: true)
            : CreateSuperQuery();

         query.LIMIT(count);

         if (hasBufferedOffset) 
            query.OFFSET(this.sqlOffset.Value);

         return CreateSet(query);
      }

      public object[] ToArray() {
         return AsEnumerable().ToArray();
      }

      [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Consistent with LINQ.")]
      public List<object> ToList() {
         return AsEnumerable().ToList();
      }

      public SqlSet Where(string predicate) {
         return Where(predicate, null);
      }

      public SqlSet Where(string predicate, params object[] parameters) {

         var superQuery = CreateSuperQuery()
            .WHERE(predicate, parameters);

         return CreateSet(superQuery);
      }

      public SqlSet Union(SqlSet otherSet) {

         if (otherSet == null) throw new ArgumentNullException("otherSet");

         var superQuery = CreateSuperQuery()
            .UNION()
            .Append(otherSet.CreateSuperQuery());

         return CreateSet(superQuery);
      }

      #endregion
   }

   public class SqlSet<TResult> : SqlSet, ISqlSet<SqlSet<TResult>, TResult> {

      readonly Func<IDataRecord, TResult> mapper;

      public SqlSet(DbConnection connection, SqlBuilder definingQuery) 
         : base(connection, definingQuery, typeof(TResult)) { }

      public SqlSet(DbConnection connection, SqlBuilder definingQuery, Func<IDataRecord, TResult> mapper)
         : base(connection, definingQuery, null) {

         // Passing null resultType to base, must use mapper

         if (mapper == null) throw new ArgumentNullException("mapper");

         this.mapper = mapper;
      }

      protected SqlSet(SqlSet<TResult> set, SqlBuilder superQuery) 
         : base((SqlSet)set, superQuery) {

         if (set == null) throw new ArgumentNullException("set");

         this.mapper = set.mapper;
      }

      // This constructor is used by SqlTable<TEntity>
      internal SqlSet(DbConnection connection, SqlBuilder definingQuery, bool adoptQuery)
         : base(connection, definingQuery, typeof(TResult), adoptQuery) { }

      // These constructors are used by SqlSet

      internal SqlSet(SqlSet set, SqlBuilder superQuery)
         : base(set, superQuery, typeof(TResult)) { }

      internal SqlSet(SqlSet set, SqlBuilder superQuery, Func<IDataRecord, TResult> mapper)
         : base(set, superQuery, (Type)null) {

         // Passing null resultType to base, must use mapper

         if (mapper == null) throw new ArgumentNullException("mapper");

         this.mapper = mapper;
      }

      protected override SqlSet CreateSet(SqlBuilder superQuery) {
         return new SqlSet<TResult>(this, superQuery);
      }

      public new IEnumerator<TResult> GetEnumerator() {
         return AsEnumerable().GetEnumerator();
      }

      #region ISqlSet<SqlSet<TResult>,TResult> Members

      /// <summary>
      /// Gets all <typeparamref name="TResult"/> objects in the set. The query is deferred-executed.
      /// </summary>
      /// <returns>All <typeparamref name="TResult"/> objects in the set.</returns>
      public new IEnumerable<TResult> AsEnumerable() {

         DbCommand command = CreateCommand();

         if (this.mapper != null)
            return command.Map(this.mapper, this.Log);

         return command.Map<TResult>(this.Log);
      }

      public new TResult First() {
         return Take(1).AsEnumerable().First();
      }

      public new TResult First(string predicate) {
         return Where(predicate).First();
      }

      public new TResult First(string predicate, params object[] parameters) {
         return Where(predicate, parameters).First();
      }

      public new TResult FirstOrDefault() {
         return Take(1).AsEnumerable().FirstOrDefault();
      }

      public new TResult FirstOrDefault(string predicate) {
         return Where(predicate).FirstOrDefault();
      }

      public new TResult FirstOrDefault(string predicate, params object[] parameters) {
         return Where(predicate, parameters).FirstOrDefault();
      }

      public new SqlSet<TResult> OrderBy(string format) {
         return (SqlSet<TResult>)base.OrderBy(format);
      }

      public new SqlSet<TResult> OrderBy(string format, params object[] args) {
         return (SqlSet<TResult>)base.OrderBy(format, args);
      }

      public new TResult Single() {
         return AsEnumerable().Single();
      }

      public new TResult Single(string predicate) {
         return Where(predicate).Single();
      }

      public new TResult Single(string predicate, params object[] parameters) {
         return Where(predicate, parameters).Single();
      }

      public new TResult SingleOrDefault() {
         return AsEnumerable().SingleOrDefault();
      }

      public new TResult SingleOrDefault(string predicate) {
         return Where(predicate).SingleOrDefault();
      }

      public new TResult SingleOrDefault(string predicate, params object[] parameters) {
         return Where(predicate, parameters).SingleOrDefault();
      }

      public new SqlSet<TResult> Skip(int count) {
         return (SqlSet<TResult>)base.Skip(count);
      }

      public new SqlSet<TResult> Take(int count) {
         return (SqlSet<TResult>)base.Take(count);
      }

      public new TResult[] ToArray() {
         return AsEnumerable().ToArray();
      }

      [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Consistent with LINQ.")]
      public new List<TResult> ToList() {
         return AsEnumerable().ToList();
      }

      public new SqlSet<TResult> Where(string predicate) {
         return (SqlSet<TResult>)base.Where(predicate);
      }

      public new SqlSet<TResult> Where(string predicate, params object[] parameters) {
         return (SqlSet<TResult>)base.Where(predicate, parameters);
      }

      public SqlSet<TResult> Union(SqlSet<TResult> otherSet) {
         return (SqlSet<TResult>)base.Union(otherSet);
      }

      #endregion
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
      long LongCount();
      long LongCount(string predicate);
      long LongCount(string predicate, params object[] parameters);
      TSqlSet OrderBy(string format);
      TSqlSet OrderBy(string format, params object[] args);
      SqlSet<TResult> Select<TResult>(string format);
      SqlSet<TResult> Select<TResult>(string format, params object[] args);
      SqlSet<TResult> Select<TResult>(Func<IDataRecord, TResult> mapper, string format);
      SqlSet<TResult> Select<TResult>(Func<IDataRecord, TResult> mapper, string format, params object[] args);
      SqlSet Select(Type resultType, string format);
      SqlSet Select(Type resultType, string format, params object[] args);
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
}
