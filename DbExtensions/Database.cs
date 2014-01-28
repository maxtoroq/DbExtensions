// Copyright 2009-2014 Max Toro Q.
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
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DbExtensions {

   /// <summary>
   /// Creates and executes CRUD (Create, Read, Update, Delete) commands for entities mapped using the
   /// <see cref="N:System.Data.Linq.Mapping"/> API.
   /// </summary>
   public partial class Database : IDisposable, IConnectionContext {

      static readonly MethodInfo tableMethod = typeof(Database).GetMethods(BindingFlags.Public | BindingFlags.Instance)
         .Single(m => m.Name == "Table" && m.ContainsGenericParameters && m.GetParameters().Length == 0);

      readonly IDictionary<MetaType, SqlTable> tables = new Dictionary<MetaType, SqlTable>();
      readonly IDictionary<MetaType, ISqlTable> genericTables = new Dictionary<MetaType, ISqlTable>();
      
      readonly DbConnection connection;
      readonly bool disposeConnection;

      DbCommandBuilder cb;
      DatabaseConfiguration config;

      /// <summary>
      /// Gets the connection to associate with new commands.
      /// </summary>
      public DbConnection Connection { get { return connection; } }

      /// <summary>
      /// Gets or sets a <see cref="DbTransaction"/> to associate with 
      /// all new commands.		
      /// </summary>		
      public DbTransaction Transaction { get; set; }

      /// <summary>
      /// Provides access to configuration options for this instance. 
      /// </summary>
      public DatabaseConfiguration Configuration { get { return config; } }

      private TextWriter Log { get { return config.Log; } }

      /// <summary>
      /// Initializes a new instance of the <see cref="Database"/> class.
      /// </summary>
      public Database() 
         : this((MetaModel)null) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Database"/> class
      /// using the provided connection.
      /// </summary>
      /// <param name="connection">The connection.</param>
      public Database(DbConnection connection) 
         : this(connection, (MetaModel)null) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Database"/> class
      /// using the provided connection and meta model.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="mapping">The meta model.</param>
      public Database(DbConnection connection, MetaModel mapping) {
         
         if (connection == null) throw new ArgumentNullException("connection");

         this.connection = connection;

         Initialize(null, mapping);
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="Database"/> class
      /// using the provided connection string.
      /// </summary>
      /// <param name="connectionString">The connection string.</param>
      public Database(string connectionString)
         : this(connectionString, (MetaModel)null) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Database"/> class
      /// using the provided connection string and meta model.
      /// </summary>
      /// <param name="connectionString">The connection string.</param>
      /// <param name="mapping">The meta model.</param>
      public Database(string connectionString, MetaModel mapping) {

         string providerName;
         
         this.connection = CreateConnection(connectionString, out providerName);
         this.disposeConnection = true;

         Initialize(providerName, mapping);
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="Database"/> class
      /// using the provided meta model.
      /// </summary>
      /// <param name="mapping">The meta model.</param>
      public Database(MetaModel mapping) {
         
         string providerName;
         
         this.connection = CreateConnection(out providerName);
         this.disposeConnection = true;

         Initialize(providerName, mapping);
      }

      void Initialize(string providerName, MetaModel mapping) {

         if (mapping == null) {
            Type thisType = GetType();

            if (thisType != typeof(Database))
               mapping = new AttributeMappingSource().GetModel(thisType);
         }

         this.config = new DatabaseConfiguration(mapping);

         DbProviderFactory factory = this.Connection.GetProviderFactory();

         this.cb = factory.CreateCommandBuilder();

         this.config.LastInsertIdCommand = "SELECT @@identity";
         this.config.DeleteConflictPolicy = ConcurrencyConflictPolicy.IgnoreVersionAndLowerAffectedRecords;
         this.config.EnableBatchCommands = true;

         if (providerName != null) {
            string identityKey = String.Format(CultureInfo.InvariantCulture, "DbExtensions:{0}:LastInsertIdCommand", providerName);
            string identitySetting = ConfigurationManager.AppSettings[identityKey];

            if (identitySetting != null)
               this.config.LastInsertIdCommand = identitySetting;

            string batchKey = String.Format(CultureInfo.InvariantCulture, "DbExtensions:{0}:EnableBatchCommands", providerName);
            string batchSetting = ConfigurationManager.AppSettings[batchKey];
            
            if (batchSetting != null) {
               bool batch;

               if (!Boolean.TryParse(batchSetting, out batch))
                  throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, "The {0} appication setting must be a valid boolean.", batchSetting));

               this.config.EnableBatchCommands = batch; 
            }
         }
      }

      // Standard

      /// <summary>
      /// Opens <see cref="Connection"/> (if it's not open) and returns an <see cref="IDisposable"/> object
      /// you can use to close it (if it wasn't open).
      /// </summary>
      /// <returns>An <see cref="IDisposable"/> object to close the connection.</returns>
      /// <remarks>
      /// Use this method with the <c>using</c> statement in C# or Visual Basic to ensure that a block of code
      /// is always executed with an open connection.
      /// </remarks>
      /// <example>
      /// <code>
      /// using (db.EnsureConnectionOpen()) {
      ///   // Execute commands.
      /// }
      /// </code>
      /// </example>
      public IDisposable EnsureConnectionOpen() {
         return this.Connection.EnsureOpen();
      }

      /// <summary>
      /// Returns a virtual transaction that you can use to ensure a code block is always executed in 
      /// a transaction, new or existing.
      /// </summary>
      /// <returns>
      /// A virtual transaction you can use to ensure a code block is always executed in 
      /// a transaction, new or existing.
      /// </returns>
      /// <remarks>
      /// This method returns a virtual transaction that wraps an existing or new transaction.
      /// If <see cref="System.Transactions.Transaction.Current"/> is not null, this method creates a
      /// new <see cref="System.Transactions.TransactionScope"/> and returns an <see cref="IDbTransaction"/>
      /// object that wraps it, and by calling <see cref="IDbTransaction.Commit()"/> on this object it will 
      /// then call <see cref="System.Transactions.TransactionScope.Complete()"/> on the <see cref="System.Transactions.TransactionScope"/>.
      /// If <see cref="System.Transactions.Transaction.Current"/> is null, this methods begins a new
      /// <see cref="DbTransaction"/>, or uses an existing transaction created by a previous call to this method, and returns 
      /// an <see cref="IDbTransaction"/> object that wraps it, and by calling <see cref="IDbTransaction.Commit()"/> 
      /// on this object it will then call <see cref="DbTransaction.Commit"/> on the wrapped transaction if the 
      /// transaction was just created, or do nothing if it was previously created.
      /// <para>
      /// Calls to this method can be nested, like in the following example:
      /// </para>
      /// <code>
      /// void DoSomething() {
      /// 
      ///    using (var tx = this.db.EnsureInTransaction()) {
      ///       
      ///       // Execute commands
      /// 
      ///       DoSomethingElse();
      /// 
      ///       tx.Commit();
      ///    }
      /// }
      /// 
      /// void DoSomethingElse() { 
      ///    
      ///    using (var tx = this.db.EnsureInTransaction()) {
      ///       
      ///       // Execute commands
      /// 
      ///       tx.Commit();
      ///    }
      /// }
      /// </code>
      /// </remarks>
      public IDbTransaction EnsureInTransaction() {
         return EnsureInTransaction(IsolationLevel.Unspecified);
      }

      /// <summary>
      /// Returns a virtual transaction that you can use to ensure a code block is always executed in 
      /// a transaction, new or existing.
      /// </summary>
      /// <param name="isolationLevel">
      /// Specifies the isolation level for the transaction. This parameter is ignored when using
      /// an existing transaction.
      /// </param>
      /// <returns>
      /// A virtual transaction you can use to ensure a code block is always executed in 
      /// a transaction, new or existing.
      /// </returns>
      /// <remarks>
      /// This method returns a virtual transaction that wraps an existing or new transaction.
      /// If <see cref="System.Transactions.Transaction.Current"/> is not null, this method creates a
      /// new <see cref="System.Transactions.TransactionScope"/> and returns an <see cref="IDbTransaction"/>
      /// object that wraps it, and by calling <see cref="IDbTransaction.Commit()"/> on this object it will 
      /// then call <see cref="System.Transactions.TransactionScope.Complete()"/> on the <see cref="System.Transactions.TransactionScope"/>.
      /// If <see cref="System.Transactions.Transaction.Current"/> is null, this methods begins a new
      /// <see cref="DbTransaction"/>, or uses an existing transaction created by a previous call to this method, and returns 
      /// an <see cref="IDbTransaction"/> object that wraps it, and by calling <see cref="IDbTransaction.Commit()"/> 
      /// on this object it will then call <see cref="DbTransaction.Commit"/> on the wrapped transaction if the 
      /// transaction was just created, or do nothing if it was previously created.
      /// <para>
      /// Calls to this method can be nested, like in the following example:
      /// </para>
      /// <code>
      /// void DoSomething() {
      /// 
      ///    using (var tx = this.db.EnsureInTransaction()) {
      ///       
      ///       // Execute commands
      /// 
      ///       DoSomethingElse();
      /// 
      ///       tx.Commit();
      ///    }
      /// }
      /// 
      /// void DoSomethingElse() { 
      ///    
      ///    using (var tx = this.db.EnsureInTransaction()) {
      ///       
      ///       // Execute commands
      /// 
      ///       tx.Commit();
      ///    }
      /// }
      /// </code>
      /// </remarks>
      public IDbTransaction EnsureInTransaction(IsolationLevel isolationLevel) {
         return new WrappedTransaction(this, isolationLevel);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command.
      /// </summary>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <returns>The number of affected records.</returns>
      public int Execute(SqlBuilder nonQuery) {
         return this.Connection.Execute(CreateCommand(nonQuery), this.Log);
      }

      /// <summary>
      /// Creates and executes a <see cref="DbCommand"/> whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the <paramref name="commandText"/> parameter.
      /// </summary>
      /// <param name="commandText">The command text.</param>
      /// <returns>The number of affected records.</returns>
      public int Execute(string commandText) {
         return Execute(commandText, (object[])null);
      }

      /// <summary>
      /// Creates and executes a <see cref="DbCommand"/> using the provided <paramref name="commandText"/> as a composite format string 
      /// (as used on <see cref="String.Format(String, Object[])"/>), 
      /// where the format items are replaced with appropiate parameter names, and the objects in the
      /// <paramref name="parameters"/> array are added to the command's <see cref="DbCommand.Parameters"/> collection.
      /// </summary>
      /// <param name="commandText">The command text.</param>
      /// <param name="parameters">The parameters to apply to the command text.</param>
      /// <returns>The number of affected records.</returns>
      public int Execute(string commandText, params object[] parameters) {
         return this.Connection.Execute(CreateCommand(commandText, parameters), this.Log);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command in a new or existing transaction, and
      /// validates the affected records value before comitting.
      /// </summary>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <param name="affectingRecords">The number of records that the command must affect, otherwise the transaction is rolledback.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.Affect(IDbCommand, int)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to <paramref name="affectingRecords"/>.</exception>      
      public int Affect(SqlBuilder nonQuery, int affectingRecords) {
         return CreateCommand(nonQuery).Affect(affectingRecords, this.Log);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command in a new or existing transaction, and
      /// validates the affected records value before comitting.
      /// </summary>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <param name="affectingRecords">The number of records that the command should affect.</param>
      /// <param name="affectedMode">The criteria for validating the affected records value.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.Affect(IDbCommand, int, AffectedRecordsPolicy)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is not valid according to the <paramref name="affectingRecords"/> and <paramref name="affectedMode"/> parameters.</exception>
      public int Affect(SqlBuilder nonQuery, int affectingRecords, AffectedRecordsPolicy affectedMode) {
         return CreateCommand(nonQuery).Affect(affectingRecords, affectedMode, this.Log);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command in a new or existing transaction, and
      /// validates that the affected records value is equal to one before comitting.
      /// </summary>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOne(IDbCommand)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to one.</exception>
      public int AffectOne(SqlBuilder nonQuery) {
         return CreateCommand(nonQuery).AffectOne(this.Log);
      }

      /// <summary>
      /// Creates and executes a <see cref="DbCommand"/> (whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the <paramref name="commandText"/> parameter) in a new or existing transaction, and
      /// validates that the affected records value is equal to one before comitting.
      /// </summary>
      /// <param name="commandText">The command text.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOne(IDbCommand)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to one.</exception>
      public int AffectOne(string commandText) {
         return AffectOne(commandText, (object[])null);
      }

      /// <summary>
      /// Creates and executes a <see cref="DbCommand"/> (using the provided <paramref name="commandText"/> 
      /// as a composite format string, as used on <see cref="String.Format(String, Object[])"/>, 
      /// where the format items are replaced with appropiate parameter names, and the objects in the
      /// <paramref name="parameters"/> array are added to the command's <see cref="DbCommand.Parameters"/> collection)
      /// in a new or existing transaction, and validates that the affected records value is equal to one before comitting.
      /// </summary>
      /// <param name="commandText">The command text.</param>
      /// <param name="parameters">The parameters to apply to the command text.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOne(IDbCommand)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to one.</exception>
      public int AffectOne(string commandText, params object[] parameters) {
         return CreateCommand(commandText, parameters).AffectOne(this.Log);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command in a new or existing transaction, and
      /// validates that the affected records value is less or equal to one before comitting.
      /// </summary>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOneOrNone(IDbCommand)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is greater than one.</exception>      
      public int AffectOneOrNone(SqlBuilder nonQuery) {
         return CreateCommand(nonQuery).AffectOneOrNone(this.Log);
      }

      /// <summary>
      /// Creates and executes a <see cref="DbCommand"/> (whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the <paramref name="commandText"/> parameter) in a new or existing transaction, and
      /// validates that the affected records value is less or equal to one before comitting.
      /// </summary>
      /// <param name="commandText">The non-query command to execute.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOneOrNone(IDbCommand)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is greater than one.</exception>
      public int AffectOneOrNone(string commandText) {
         return AffectOneOrNone(commandText, (object[])null);
      }

      /// <summary>
      /// Creates and executes a <see cref="DbCommand"/> (using the provided <paramref name="commandText"/> 
      /// as a composite format string, as used on <see cref="String.Format(String, Object[])"/>, 
      /// where the format items are replaced with appropiate parameter names, and the objects in the
      /// <paramref name="parameters"/> array are added to the command's <see cref="DbCommand.Parameters"/> collection)
      /// in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting.
      /// </summary>
      /// <param name="commandText">The non-query command to execute.</param>
      /// <param name="parameters">The parameters to apply to the command text.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOneOrNone(IDbCommand)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is greater than one.</exception>
      public int AffectOneOrNone(string commandText, params object[] parameters) {
         return CreateCommand(commandText, parameters).AffectOneOrNone(this.Log);
      }

      /// <summary>
      /// Maps the results of the <paramref name="query"/> to <typeparamref name="TResult"/> objects.
      /// The query is deferred-executed.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="query">The query.</param>
      /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>
      /// <seealso cref="Extensions.Map&lt;T>(IDbCommand, TextWriter)"/>
      public IEnumerable<TResult> Map<TResult>(SqlBuilder query) {
         return Extensions.Map<TResult>(q => CreateCommand(q), query, new PocoMapper(typeof(TResult), this.Log), this.Log);
      }

      /// <summary>
      /// Maps the results of the <paramref name="query"/> to <typeparamref name="TResult"/> objects,
      /// using the provided <paramref name="mapper"/> delegate.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="query">The query.</param>
      /// <param name="mapper">The delegate for creating <typeparamref name="TResult"/> objects from an <see cref="IDataRecord"/> object.</param>
      /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>
      /// <seealso cref="Extensions.Map&lt;T>(IDbCommand, Func&lt;IDataRecord, T>, TextWriter)"/>
      public IEnumerable<TResult> Map<TResult>(SqlBuilder query, Func<IDataRecord, TResult> mapper) {
         return CreateCommand(query).Map<TResult>(mapper, this.Log);
      }

      /// <summary>
      /// Maps the results of the <paramref name="query"/> to objects of type
      /// specified by the <paramref name="resultType"/> parameter.
      /// The query is deferred-executed.
      /// </summary>
      /// <param name="resultType">The type of objects to map the results to.</param>
      /// <param name="query">The query.</param>
      /// <returns>The results of the query as objects of type specified by the <paramref name="resultType"/> parameter.</returns>
      /// <seealso cref="Extensions.Map(IDbCommand, Type, TextWriter)"/>
      public IEnumerable<object> Map(Type resultType, SqlBuilder query) {
         return Extensions.Map<object>(q => CreateCommand(q), query, new PocoMapper(resultType, this.Log), this.Log);
      }

      /// <summary>
      /// Checks if <paramref name="query"/> would return at least one row.
      /// </summary>
      /// <param name="query">The query whose existance is to be checked.</param>
      /// <returns>true if <paramref name="query"/> contains any rows; otherwise, false.</returns>
      public bool Exists(SqlBuilder query) {
         return this.Connection.Exists(CreateCommand(Extensions.ExistsQuery(query)), this.Log);
      }

      /// <summary>
      /// Gets the number of results the <paramref name="query"/> would return.
      /// </summary>
      /// <param name="query">The query whose count is to be computed.</param>
      /// <returns>The number of results the <paramref name="query"/> would return.</returns>
      /// <seealso cref="Extensions.Count(DbConnection, SqlBuilder)"/>
      public int Count(SqlBuilder query) {
         return this.Connection.Count(CreateCommand(Extensions.CountQuery(query)), this.Log);
      }

      /// <summary>
      /// Gets the number of results the <paramref name="query"/> would return.
      /// </summary>
      /// <param name="query">The query whose count is to be computed.</param>
      /// <returns>The number of results the <paramref name="query"/> would return.</returns>
      /// <seealso cref="Extensions.LongCount(DbConnection, SqlBuilder)"/>
      [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "long", Justification = "Consistent with LINQ.")]
      public long LongCount(SqlBuilder query) {
         return this.Connection.LongCount(CreateCommand(Extensions.CountQuery(query)), this.Log);
      }

      // Sets

      /// <summary>
      /// Returns the <see cref="SqlTable&lt;TEntity>"/> instance for the specified <typeparamref name="TEntity"/>.
      /// </summary>
      /// <typeparam name="TEntity">The type of the entity.</typeparam>
      /// <returns>The <see cref="SqlTable&lt;TEntity>"/> instance for <typeparamref name="TEntity"/>.</returns>
      public SqlTable<TEntity> Table<TEntity>() where TEntity : class {

         MetaType metaType = GetMetaType(typeof(TEntity));
         ISqlTable set;
         SqlTable<TEntity> table;

         if (this.genericTables.TryGetValue(metaType, out set)) {
            table = (SqlTable<TEntity>)set;

         } else {
            table = new SqlTable<TEntity>(this, metaType);
            this.genericTables.Add(metaType, table);
         }

         return table;
      }

      /// <summary>
      /// Returns the <see cref="SqlTable"/> instance for the specified <paramref name="entityType"/>.
      /// </summary>
      /// <param name="entityType">The type of the entity.</param>
      /// <returns>The <see cref="SqlTable"/> instance for <paramref name="entityType"/>.</returns>
      public SqlTable Table(Type entityType) {
         return Table(GetMetaType(entityType));
      }

      /// <summary>
      /// Returns the <see cref="SqlTable"/> instance for the specified <paramref name="metaType"/>.
      /// </summary>
      /// <param name="metaType">The <see cref="MetaType"/> of the entity.</param>
      /// <returns>The <see cref="SqlTable"/> instance for <paramref name="metaType"/>.</returns>
      protected internal SqlTable Table(MetaType metaType) {

         SqlTable table;

         if (!this.tables.TryGetValue(metaType, out table)) {
            
            ISqlTable genericTable = (ISqlTable)
               tableMethod.MakeGenericMethod(metaType.Type).Invoke(this, null);

            table = new SqlTable(this, metaType, genericTable);
            this.tables.Add(metaType, table);
         }

         return table;
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet"/> using the provided table name.
      /// </summary>
      /// <param name="tableName">The name of the table that will be the source of data for the set.</param>
      /// <returns>A new <see cref="SqlSet"/> object.</returns>
      public SqlSet From(string tableName) {
         return new SqlSet(tableName, (Type)null, this);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet"/> using the provided table name.
      /// </summary>
      /// <param name="tableName">The name of the table that will be the source of data for the set.</param>
      /// <param name="resultType">The type of objects to map the results to.</param>
      /// <returns>A new <see cref="SqlSet"/> object.</returns>
      public SqlSet From(string tableName, Type resultType) {
         return new SqlSet(tableName, resultType, this);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided table name.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="tableName">The name of the table that will be the source of data for the set.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> object.</returns>
      public SqlSet<TResult> From<TResult>(string tableName) {
         return new SqlSet<TResult>(tableName, this);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet"/> using the provided defining query.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <returns>A new <see cref="SqlSet"/> object.</returns>
      public SqlSet From(SqlBuilder definingQuery) {
         return new SqlSet(definingQuery, (Type)null, this, adoptQuery: false);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet"/> using the provided defining query.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="resultType">The type of objects to map the results to.</param>
      /// <returns>A new <see cref="SqlSet"/> object.</returns>
      public SqlSet From(SqlBuilder definingQuery, Type resultType) {
         return new SqlSet(definingQuery, resultType, this, adoptQuery: false);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided defining query.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> object.</returns>
      public SqlSet<TResult> From<TResult>(SqlBuilder definingQuery) {
         return new SqlSet<TResult>(definingQuery, this, adoptQuery: false);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided defining query and mapper.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="mapper">A custom mapper function that creates <typeparamref name="TResult"/> instances from the rows in the set.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> object.</returns>
      public SqlSet<TResult> From<TResult>(SqlBuilder definingQuery, Func<IDataRecord, TResult> mapper) {
         return new SqlSet<TResult>(definingQuery, mapper, this, adoptQuery: false);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided defining query.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> object.</returns>
      [EditorBrowsable(EditorBrowsableState.Never)]
      [Obsolete("Please use From<TResult>(SqlBuilder) instead.")]
      public SqlSet<TResult> Set<TResult>(SqlBuilder definingQuery) {
         return new SqlSet<TResult>(definingQuery, this, adoptQuery: false);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet&lt;TResult>"/> using the provided defining query and mapper.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <param name="mapper">A custom mapper function that creates <typeparamref name="TResult"/> instances from the rows in the set.</param>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> object.</returns>
      [EditorBrowsable(EditorBrowsableState.Never)]
      [Obsolete("Please use From<TResult>(SqlBuilder, Func<IDataRecord, TResult>) instead.")]
      public SqlSet<TResult> Set<TResult>(SqlBuilder definingQuery, Func<IDataRecord, TResult> mapper) {
         return new SqlSet<TResult>(definingQuery, mapper, this, adoptQuery: false);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlSet"/> using the provided defining query.
      /// </summary>
      /// <param name="definingQuery">The SQL query that will be the source of data for the set.</param>
      /// <returns>A new <see cref="SqlSet"/> object.</returns>
      [EditorBrowsable(EditorBrowsableState.Never)]
      [Obsolete("Please use From(SqlBuilder) instead.")]
      public SqlSet Set(SqlBuilder definingQuery) {
         return new SqlSet(definingQuery, (Type)null, this, adoptQuery: false);
      }

      // CRUD

      /// <summary>
      /// Executes INSERT commands for the specified <paramref name="entities"/>.
      /// </summary>
      /// <param name="entities">The entities whose INSERT commands are to be executed.</param>
      [EditorBrowsable(EditorBrowsableState.Never)]
      [Obsolete("Please use Table<TEntity>().InsertRange or Table(Type).InsertRange instead.")]
      public void InsertRange(IEnumerable<object> entities) {

         if (entities == null) throw new ArgumentNullException("entities");

         InsertRange(entities.ToArray());
      }

      /// <summary>
      /// Executes INSERT commands for the specified <paramref name="entities"/>.
      /// </summary>
      /// <param name="entities">The entities whose INSERT commands are to be executed.</param>
      [EditorBrowsable(EditorBrowsableState.Never)]
      [Obsolete("Please use Table<TEntity>().InsertRange or Table(Type).InsertRange instead.")]
      public void InsertRange(params object[] entities) {

         if (entities == null) throw new ArgumentNullException("entities");

         entities = entities.Where(o => o != null).ToArray();

         if (entities.Length == 0)
            return;

         var byType = entities.GroupBy(e => GetMetaType(e.GetType())).ToArray();

         if (byType.Length == 1) {
            Table(entities[0].GetType()).InsertRange(entities);
            return;
         }

         using (var tx = EnsureInTransaction()) {

            for (int i = 0; i < byType.Length; i++) {
               var grp = byType[i];

               Table(grp.Key).InsertRange(grp.ToArray());
            }

            tx.Commit();
         }
      }
      
      // Misc

      /// <summary>
      /// Gets the identity value of the last inserted record.
      /// </summary>
      /// <returns>The identity value of the last inserted record.</returns>
      /// <remarks>
      /// It is very important to keep the connection open between the last 
      /// command and this one, or else you might get the wrong value.
      /// </remarks>
      [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Operation is expensive.")]
      public virtual object LastInsertId() {

         if (String.IsNullOrEmpty(this.config.LastInsertIdCommand))
            throw new InvalidOperationException("LastInsertIdCommand cannot be null.");

         DbCommand command = CreateCommand(this.config.LastInsertIdCommand);

         object value = command.ExecuteScalar();

         LogLine(command.ToTraceString());

         return value;
      }

      /// <summary>
      /// Creates and returns a <see cref="DbCommand"/> object from the specified <paramref name="sqlBuilder"/>.
      /// </summary>
      /// <param name="sqlBuilder">The <see cref="SqlBuilder"/> that provides the command's text and parameters.</param>
      /// <returns>
      /// A new <see cref="DbCommand"/> object whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the <paramref name="sqlBuilder"/> string representation, and whose <see cref="DbCommand.Parameters"/>
      /// property is initialized with the values from the <see cref="SqlBuilder.ParameterValues"/> property of the
      /// <paramref name="sqlBuilder"/> parameter.
      /// </returns>
      /// <remarks>
      /// <see cref="Transaction"/> is associated with all new commands created using this method.
      /// </remarks>
      public DbCommand CreateCommand(SqlBuilder sqlBuilder) {

         if (sqlBuilder == null) throw new ArgumentNullException("sqlBuilder");

         return CreateCommand(sqlBuilder.ToString(), sqlBuilder.ParameterValues.ToArray());
      }

      /// <summary>
      /// Creates and returns a <see cref="DbCommand"/> object using the specified <paramref name="commandText"/>.
      /// </summary>
      /// <param name="commandText">The SQL command.</param>
      /// <returns>
      /// A new <see cref="DbCommand"/> object whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the <paramref name="commandText"/> parameter.
      /// </returns>
      /// <remarks>
      /// <see cref="Transaction"/> is associated with all new commands created using this method.
      /// </remarks>
      public DbCommand CreateCommand(string commandText) {
         return CreateCommand(commandText, (object[])null);
      }

      /// <summary>
      /// Creates and returns a <see cref="DbCommand"/> object using the provided <paramref name="commandText"/> as a composite format string 
      /// (as used on <see cref="String.Format(String, Object[])"/>), 
      /// where the format items are replaced with appropiate parameter names, and the objects in the
      /// <paramref name="parameters"/> array are added to the command's <see cref="DbCommand.Parameters"/> collection.
      /// </summary>
      /// <param name="commandText">The command text.</param>
      /// <param name="parameters">
      /// The array of parameters to be passed to the command. Note the following 
      /// behavior: If the number of objects in the array is less than the highest 
      /// number identified in the command string, an exception is thrown. If the 
      /// array contains objects that are not referenced in the command string, no 
      /// exception is thrown. If a parameter is null, it is converted to DBNull.Value. 
      /// </param>
      /// <returns>
      /// A new <see cref="DbCommand"/> object whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the <paramref name="commandText"/> parameter, and whose <see cref="DbCommand.Parameters"/>
      /// property is initialized with the values from the <paramref name="parameters"/> parameter.
      /// </returns>
      /// <remarks>
      /// <see cref="Transaction"/> is associated with all new commands created using this method.
      /// </remarks>
      /// <seealso cref="Extensions.CreateCommand(DbConnection, string, object[])"/>
      public DbCommand CreateCommand(string commandText, params object[] parameters) {

         DbCommand command = this.cb.CreateCommand(this.Connection, commandText, parameters);
         DbTransaction transaction = this.Transaction;

         if (transaction != null)
            command.Transaction = transaction;

         return command;
      }

      /// <summary>
      /// Given an unquoted identifier in the correct catalog case, returns the correct
      /// quoted form of that identifier, including properly escaping any embedded
      /// quotes in the identifier.
      /// </summary>
      /// <param name="unquotedIdentifier">The original unquoted identifier.</param>
      /// <returns>The quoted version of the identifier. Embedded quotes within the identifier are properly escaped.</returns>
      /// <seealso cref="DbCommandBuilder.QuoteIdentifier(string)"/>
      public string QuoteIdentifier(string unquotedIdentifier) {
         return this.cb.QuoteIdentifier(unquotedIdentifier);
      }

      internal void LogLine(string message) {

         if (this.Log != null)
            this.Log.WriteLine(message);
      }

      MetaType GetMetaType(Type entityType) {

         if (entityType == null) throw new ArgumentNullException("entityType");

         if (this.config.Mapping == null)
            throw new InvalidOperationException("There's no MetaModel associated, the operation is not available.");

         return this.config.Mapping.GetMetaType(entityType);
      }

      #region Object Members

      /// <summary>
      /// Returns whether the specified object is equal to the current object.
      /// </summary>
      /// <param name="obj">The object to compare with the current object. </param>
      /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
      [EditorBrowsable(EditorBrowsableState.Never)]
      public override bool Equals(object obj) {
         return base.Equals(obj);
      }

      /// <summary>
      /// Returns the hash function for the current object.
      /// </summary>
      /// <returns>The hash function for the current object.</returns>
      [EditorBrowsable(EditorBrowsableState.Never)]
      public override int GetHashCode() {
         return base.GetHashCode();
      }

      /// <summary>
      /// Gets the type for the current object.
      /// </summary>
      /// <returns>The type for the current object.</returns>
      [EditorBrowsable(EditorBrowsableState.Never)]
      [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Must match base signature.")]
      public new Type GetType() {
         return base.GetType();
      }

      /// <summary>
      /// Returns a string representation of the object.
      /// </summary>
      /// <returns>A string representation of the object.</returns>
      [EditorBrowsable(EditorBrowsableState.Never)]
      public override string ToString() {
         return base.ToString();
      }

      #endregion

      #region IConnectionContext Members

      DbConnection IConnectionContext.Connection {
         get { return this.Connection; }
      }

      TextWriter IConnectionContext.Log {
         get { return this.Log; }
      }

      DbCommand IConnectionContext.CreateCommand(SqlBuilder query) {
         return CreateCommand(query);
      }

      #endregion

      #region IDisposable Members

      /// <summary>
      /// Releases all resources used by the current instance of the <see cref="Database"/> class.
      /// </summary>
      public void Dispose() {

         Dispose(true);
         GC.SuppressFinalize(this);
      }

      /// <summary>
      /// Releases the resources used by this <see cref="Database"/> instance.
      /// </summary>
      /// <param name="disposing">
      /// true if this method is being called due to a call to <see cref="Dispose()"/>; otherwise, false.
      /// </param>
      protected virtual void Dispose(bool disposing) {

         if (disposing) {

            if (this.disposeConnection) {

               DbConnection conn = this.Connection;

               if (conn != null) {
                  conn.Dispose();
               }
            }
         }
      }

      #endregion

      #region Nested Types

      class WrappedTransaction : IDbTransaction {

         readonly Database db;
         readonly IDisposable connHolder;
         readonly IDbTransaction txAdo;
         readonly bool txBeganHere;
         readonly System.Transactions.TransactionScope txScope;

         readonly IDbConnection _Connection;
         readonly IsolationLevel _IsolationLevel;

         public IDbConnection Connection { get { return _Connection; } }
         public IsolationLevel IsolationLevel { get { return _IsolationLevel; } }

         public WrappedTransaction(Database db, IsolationLevel isolationLevel) {

            if (db == null) throw new ArgumentNullException("db");

            this.db = db;
            this.txAdo = this.db.Transaction;

            this._Connection = this.db.Connection;
            this._IsolationLevel = isolationLevel;

            this.connHolder = this.db.EnsureConnectionOpen();

            try {

               if (System.Transactions.Transaction.Current != null)
                  this.txScope = new System.Transactions.TransactionScope();

               if (this.txScope == null 
                  && this.txAdo == null) {

                  this.txAdo = this.db.Transaction = this.db.Connection.BeginTransaction(isolationLevel);
                  this.db.LogLine("-- TRANSACTION STARTED");
                  this.txBeganHere = true;
               }

            } catch {

               this.connHolder.Dispose();
               
               throw;
            }
         }

         public void Commit() {

            if (txScope != null) {
               txScope.Complete();
               return;
            }

            if (txBeganHere) {

               try {
                  txAdo.Commit();
                  db.LogLine("-- TRANSACTION COMMITED");

               } finally {
                  RemoveTxFromDao();
               }
            }
         }

         public void Rollback() {

            if (txScope != null)
               return;

            if (txBeganHere) {

               try {
                  txAdo.Rollback();
                  db.LogLine("-- TRANSACTION ROLLED BACK");

               } finally {
                  RemoveTxFromDao();
               }

            } else {
               throw new InvalidOperationException();
            }
         }

         public void Dispose() {

            try {
               if (txScope != null) {
                  txScope.Dispose();
                  return;
               }

               if (txBeganHere) {
                  try {
                     txAdo.Dispose();
                  } finally {
                     RemoveTxFromDao();
                  }
               }

            } finally {
               connHolder.Dispose();
            }
         }

         void RemoveTxFromDao() {

            if (db.Transaction != null && Object.ReferenceEquals(db.Transaction, txAdo))
               db.Transaction = null;
         }
      }

      #endregion
   }

   /// <summary>
   /// Holds configuration options that customize the behavior of <see cref="Database"/>.
   /// </summary>
   public sealed class DatabaseConfiguration {

      readonly MetaModel mapping;

      /// <summary>
      /// Gets or sets the SQL command that returns the last identity value generated on the 
      /// database. The default value is "SELECT @@identity". You can override the default value using
      /// a "DbExtensions:{providerInvariantName}:LastInsertIdCommand" entry in the appSettings
      /// configuration section, where {providerInvariantName} is replaced with the provider 
      /// invariant name (e.g. DbExtensions:System.Data.SqlClient:LastInsertIdCommand).
      /// </summary>
      /// <remarks>
      /// SQL Server users should consider using "SELECT SCOPE_IDENTITY()" instead. 
      /// The command for SQLite is "SELECT LAST_INSERT_ROWID()".
      /// </remarks>
      public string LastInsertIdCommand { get; set; }

      /// <summary>
      /// Gets the <see cref="MetaModel"/> on which the mapping is based.
      /// </summary>
      public MetaModel Mapping { get { return mapping; } }

      /// <summary>
      /// Specifies the destination to write the SQL query or command. 
      /// </summary>
      public TextWriter Log { get; set; }

      /// <summary>
      /// Gets or sets the default policy to use when calling
      /// <see cref="SqlTable&lt;TEntity>.Update(TEntity)"/>.
      /// The default value is <see cref="ConcurrencyConflictPolicy.UseVersion"/>.
      /// </summary>
      public ConcurrencyConflictPolicy UpdateConflictPolicy { get; set; }

      /// <summary>
      /// Gets or sets the default policy to use when calling
      /// <see cref="SqlTable&lt;TEntity>.Delete(TEntity)"/>.
      /// The default value is <see cref="ConcurrencyConflictPolicy.IgnoreVersionAndLowerAffectedRecords"/>.
      /// </summary>
      public ConcurrencyConflictPolicy DeleteConflictPolicy { get; set; }

      /// <summary>
      /// true to execute batch commands when possible; otherwise, false. The default is true.
      /// You can override the default value using a "DbExtensions:{providerInvariantName}:EnableBatchCommands" 
      /// entry in the appSettings configuration section, where {providerInvariantName} is replaced with the provider 
      /// invariant name (e.g. DbExtensions:System.Data.SqlClient:EnableBatchCommands).
      /// </summary>
      public bool EnableBatchCommands { get; set; }

      internal DatabaseConfiguration(MetaModel mapping) {
         this.mapping = mapping;
      }
   }

   /// <summary>
   /// Indicates what concurrency conflict policy to use.
   /// A concurrency conflict ocurrs when trying to UPDATE/DELETE a row that has a newer version,
   /// or when trying to UPDATE/DELETE a row that no longer exists.
   /// </summary>
   public enum ConcurrencyConflictPolicy {
      /// <summary>
      /// Include version column check in the UPDATE/DELETE statement predicate.
      /// </summary>
      UseVersion = 0,
      /// <summary>
      /// The predicate for the UPDATE/DELETE statement should not contain
      /// any version column checks to avoid version conflicts. 
      /// Note that a conflict can still ocurr if the row no longer exists.
      /// </summary>
      IgnoreVersion = 1,
      /// <summary>
      /// The predicate for the UPDATE/DELETE statement should not contain
      /// any version column checks to avoid version conflicts. 
      /// If the number of affected records is lower than expected then it is presumed that 
      /// the row was previously deleted.
      /// </summary>
      IgnoreVersionAndLowerAffectedRecords = 2
   }
}