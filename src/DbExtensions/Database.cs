// Copyright 2009-2016 Max Toro Q.
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
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Transactions;
using IsolationLevel = System.Data.IsolationLevel;

namespace DbExtensions {

   /// <summary>
   /// Provides simple data access using <see cref="SqlSet"/>, <see cref="SqlBuilder"/> and <see cref="SqlTable&lt;TEntity>"/>.
   /// </summary>

   public partial class Database : IDisposable {

      static readonly ConcurrentDictionary<string, DbProviderFactory> factories = new ConcurrentDictionary<string, DbProviderFactory>();

      readonly bool disposeConnection;

      /// <summary>
      /// Gets the connection to associate with new commands.
      /// </summary>

      public IDbConnection Connection { get; }

      /// <summary>
      /// Gets or sets a transaction to associate with new commands.
      /// </summary>		

      public IDbTransaction Transaction { get; set; }

      /// <summary>
      /// Provides access to configuration options for this instance. 
      /// </summary>

      public DatabaseConfiguration Configuration { get; private set; }

      /// <summary>
      /// Initializes a new instance of the <see cref="Database"/> class.
      /// </summary>

      public Database() {

         string providerInvariantName;

         this.Connection = CreateConnection(null, null, out providerInvariantName);
         this.disposeConnection = true;

         Initialize(providerInvariantName);
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="Database"/> class
      /// using the provided connection string.
      /// </summary>
      /// <param name="connectionString">The connection string.</param>

      public Database(string connectionString) {

         if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));

         string providerInvariantName;

         this.Connection = CreateConnection(connectionString, null, out providerInvariantName);
         this.disposeConnection = true;

         Initialize(providerInvariantName);
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="Database"/> class
      /// using the provided connection string and provider's invariant name.
      /// </summary>
      /// <param name="connectionString">The connection string.</param>
      /// <param name="providerInvariantName">The provider's invariant name.</param>

      public Database(string connectionString, string providerInvariantName) {

         if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));

         string finalProviderInvariantName;

         this.Connection = CreateConnection(connectionString, providerInvariantName, out finalProviderInvariantName);
         this.disposeConnection = true;

         Initialize(finalProviderInvariantName);
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="Database"/> class
      /// using the provided connection.
      /// </summary>
      /// <param name="connection">The connection.</param>

      public Database(IDbConnection connection) {

         if (connection == null) throw new ArgumentNullException(nameof(connection));

         this.Connection = connection;

         Initialize(null);
      }

      void Initialize(string providerInvariantName) {

         providerInvariantName = providerInvariantName
            ?? this.Connection.GetType().Namespace;

         this.Configuration = new DatabaseConfiguration(
            providerInvariantName
            , () => CreateCommandBuilder(providerInvariantName)
         );

         Initialize2(providerInvariantName);
      }

      partial void Initialize2(string providerInvariantName);

      static IDbConnection CreateConnection(string connectionString, string callerProviderInvariantName, out string providerInvariantName) {

         connectionString = connectionString ?? DatabaseConfiguration.DefaultConnectionString;
         providerInvariantName = callerProviderInvariantName ?? DatabaseConfiguration.DefaultProviderInvariantName;

         if (connectionString == null) {
            throw new InvalidOperationException($"A default connection string name must be specified in the {typeof(DatabaseConfiguration).FullName}.{nameof(DatabaseConfiguration.DefaultConnectionString)} property.");
         }

         if (providerInvariantName == null) {
            throw new InvalidOperationException($"A default provider name must be specified in the {typeof(DatabaseConfiguration).FullName}.{nameof(DatabaseConfiguration.DefaultProviderInvariantName)} property.");
         }

         DbProviderFactory factory = GetProviderFactory(providerInvariantName);

         IDbConnection connection = factory.CreateConnection();
         connection.ConnectionString = connectionString;

         return connection;
      }

      static DbProviderFactory GetProviderFactory(string providerInvariantName) {

         if (providerInvariantName == null) throw new ArgumentNullException(nameof(providerInvariantName));

         DbProviderFactory factory = factories.GetOrAdd(providerInvariantName, n => DbProviderFactories.GetFactory(n));

         return factory;
      }

      DbCommandBuilder CreateCommandBuilder(string providerInvariantName) {

         DbConnection dbConn = this.Connection as DbConnection;

         DbProviderFactory factory = ((dbConn != null) ? DbProviderFactories.GetFactory(dbConn) : null)
            ?? GetProviderFactory(providerInvariantName);

         return factory.CreateCommandBuilder();
      }

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
         return new ConnectionHolder(this.Connection);
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
      /// If <see cref="Transaction.Current"/> is not null, this method creates a
      /// new <see cref="TransactionScope"/> and returns an <see cref="IDbTransaction"/>
      /// object that wraps it, and by calling <see cref="IDbTransaction.Commit()"/> on this object it will 
      /// then call <see cref="TransactionScope.Complete()"/> on the <see cref="TransactionScope"/>.
      /// If <see cref="Transaction.Current"/> is null, this methods begins a new
      /// <see cref="IDbTransaction"/>, or uses an existing transaction created by a previous call to this method, and returns 
      /// an <see cref="IDbTransaction"/> object that wraps it, and by calling <see cref="IDbTransaction.Commit()"/> 
      /// on this object it will then call <see cref="IDbTransaction.Commit()"/> on the wrapped transaction if the 
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

      /// <inheritdoc cref="EnsureInTransaction()"/>
      /// <param name="isolationLevel">
      /// Specifies the isolation level for the transaction. This parameter is ignored when using
      /// an existing transaction.
      /// </param>

      public IDbTransaction EnsureInTransaction(IsolationLevel isolationLevel) {
         return new WrappedTransaction(this, isolationLevel);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command. Optionally uses a transaction and validates
      /// affected records value before committing.
      /// </summary>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <param name="affect">The number of records the command should affect. This value is ignored if less or equal to -1.</param>
      /// <param name="exact">true if the number of affected records should exactly match <paramref name="affect"/>; false if a lower number is acceptable.</param>
      /// <returns>The number of affected records.</returns>
      /// <exception cref="ChangeConflictException">The number of affected records is not equal to <paramref name="affect"/>.</exception>

      public int Execute(SqlBuilder nonQuery, int affect = -1, bool exact = false) {

         if (nonQuery == null) throw new ArgumentNullException(nameof(nonQuery));

         IDbCommand command = CreateCommand(nonQuery);

         using (EnsureConnectionOpen()) {
            using (var tx = (affect > -1 ? EnsureInTransaction() : null)) {

               int affectedRecords;

               try {
                  affectedRecords = command.ExecuteNonQuery();
               } catch {

                  Trace(command, error: true);
                  throw;
               }

               Trace(command, affectedRecords);

               if (tx != null
                  && affectedRecords != affect) {

                  string errorMessage = null;

                  if (exact) {
                     errorMessage = String.Format(CultureInfo.InvariantCulture, "The number of affected records should be {0}, the actual number is {1}.", affect, affectedRecords);

                  } else if (affectedRecords > affect) {
                     errorMessage = String.Format(CultureInfo.InvariantCulture, "The number of affected records should be {0} or lower, the actual number is {1}.", affect, affectedRecords);
                  }

                  if (errorMessage != null) {
                     throw new ChangeConflictException(errorMessage);
                  }
               }

               tx?.Commit();

               return affectedRecords;
            }
         }
      }

      /// <summary>
      /// Creates and executes an <see cref="IDbCommand"/> using the provided <paramref name="commandText"/> as a composite format string 
      /// (as used on <see cref="String.Format(String, Object[])"/>), 
      /// where the format items are replaced with appropiate parameter names, and the objects in the
      /// <paramref name="parameters"/> array are added to the command's <see cref="IDbCommand.Parameters"/> collection.
      /// </summary>
      /// <param name="commandText">The command text.</param>
      /// <param name="parameters">The parameters to apply to the command text.</param>
      /// <returns>The number of affected records.</returns>

      public int Execute(string commandText, params object[] parameters) {
         return Execute(new SqlBuilder(commandText, parameters));
      }

      /// <summary>
      /// Maps the results of the <paramref name="query"/> to <typeparamref name="TResult"/> objects,
      /// using the provided <paramref name="mapper"/> delegate.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="query">The query.</param>
      /// <param name="mapper">The delegate for creating <typeparamref name="TResult"/> objects from an <see cref="IDataRecord"/> object.</param>
      /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>

      public IEnumerable<TResult> Map<TResult>(SqlBuilder query, Func<IDataRecord, TResult> mapper) {
         return new MappingEnumerable<TResult>(CreateCommand(query), mapper, this.Configuration.Log);
      }

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

         if (String.IsNullOrEmpty(this.Configuration.LastInsertIdCommand)) {
            throw new InvalidOperationException("Configuration.LastInsertIdCommand cannot be null.");
         }

         IDbCommand command = CreateCommand(this.Configuration.LastInsertIdCommand);

         object value = command.ExecuteScalar();

         Trace(command);

         return value;
      }

      /// <summary>
      /// Creates and returns an <see cref="IDbCommand"/> object from the specified <paramref name="sqlBuilder"/>.
      /// </summary>
      /// <param name="sqlBuilder">The <see cref="SqlBuilder"/> that provides the command's text and parameters.</param>
      /// <returns>
      /// A new <see cref="IDbCommand"/> object whose <see cref="IDbCommand.CommandText"/> property
      /// is initialized with the <paramref name="sqlBuilder"/>'s string representation, and whose <see cref="IDbCommand.Parameters"/>
      /// property is initialized with the values from the <see cref="SqlBuilder.ParameterValues"/> property of the <paramref name="sqlBuilder"/> parameter.
      /// </returns>

      public IDbCommand CreateCommand(SqlBuilder sqlBuilder) {

         if (sqlBuilder == null) throw new ArgumentNullException(nameof(sqlBuilder));

         return CreateCommand(sqlBuilder.ToString(), sqlBuilder.ParameterValues.ToArray());
      }

      /// <summary>
      /// Creates and returns an <see cref="IDbCommand"/> object using the provided <paramref name="commandText"/> as a composite format string 
      /// (as used on <see cref="String.Format(String, Object[])"/>), 
      /// where the format items are replaced with appropiate parameter names, and the objects in the
      /// <paramref name="parameters"/> array are added to the command's <see cref="IDbCommand.Parameters"/> collection.
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
      /// A new <see cref="IDbCommand"/> object whose <see cref="IDbCommand.CommandText"/> property
      /// is initialized with the <paramref name="commandText"/> parameter, and whose <see cref="IDbCommand.Parameters"/>
      /// property is initialized with the values from the <paramref name="parameters"/> parameter.
      /// </returns>
      /// <remarks>
      /// <see cref="Transaction"/> is associated with all commands created using this method.
      /// </remarks>

      [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
      public IDbCommand CreateCommand(string commandText, params object[] parameters) {

         if (commandText == null) throw new ArgumentNullException(nameof(commandText));

         IDbCommand command = this.Connection.CreateCommand();

         IDbTransaction transaction = this.Transaction;

         if (transaction != null) {
            command.Transaction = transaction;
         }

         int commandTimeout = this.Configuration.CommandTimeout;

         if (commandTimeout > -1) {
            command.CommandTimeout = commandTimeout;
         }

         if (parameters == null || parameters.Length == 0) {
            command.CommandText = commandText;
            return command;
         }

         object[] paramPlaceholders = new object[parameters.Length];

         for (int i = 0; i < paramPlaceholders.Length; i++) {

            object paramValue = parameters[i];

            IDataParameter dbParam = paramValue as IDataParameter;

            if (dbParam == null) {
               dbParam = command.CreateParameter();
               dbParam.Value = paramValue ?? DBNull.Value;
            }

            dbParam.ParameterName = this.Configuration.ParameterNameBuilder("p" + i.ToString(CultureInfo.InvariantCulture));
            command.Parameters.Add(dbParam);

            paramPlaceholders[i] = this.Configuration.ParameterPlaceholderBuilder(dbParam.ParameterName);
         }

         command.CommandText = String.Format(CultureInfo.InvariantCulture, commandText, paramPlaceholders);

         return command;
      }

      /// <summary>
      /// Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier,
      /// including properly escaping any embedded quotes in the identifier.
      /// </summary>
      /// <param name="unquotedIdentifier">The original unquoted identifier.</param>
      /// <returns>The quoted version of the identifier. Embedded quotes within the identifier are properly escaped.</returns>

      public virtual string QuoteIdentifier(string unquotedIdentifier) {

         if (unquotedIdentifier == null) throw new ArgumentNullException(nameof(unquotedIdentifier));

         if (IsQuotedIdentifier(unquotedIdentifier)) {
            return unquotedIdentifier;
         }

         string quotePrefix = this.Configuration.QuotePrefix;
         string quoteSuffix = this.Configuration.QuoteSuffix;

         var sb = new StringBuilder();

         if (!String.IsNullOrEmpty(quotePrefix)) {
            sb.Append(quotePrefix);
         }

         if (!String.IsNullOrEmpty(quoteSuffix)) {
            sb.Append(unquotedIdentifier.Replace(quoteSuffix, quoteSuffix + quoteSuffix));
            sb.Append(quoteSuffix);
         } else {
            sb.Append(unquotedIdentifier);
         }

         return sb.ToString();
      }

      bool IsQuotedIdentifier(string identifier) {

         if (identifier == null) throw new ArgumentNullException(nameof(identifier));

         string quotePrefix = this.Configuration.QuotePrefix;
         string quoteSuffix = this.Configuration.QuoteSuffix;

         if (identifier.Length < (quotePrefix?.Length + quoteSuffix?.Length)) {
            return false;
         }

         return (!String.IsNullOrEmpty(quotePrefix) && identifier.StartsWith(quotePrefix, StringComparison.Ordinal))
             && (!String.IsNullOrEmpty(quoteSuffix) && identifier.EndsWith(quoteSuffix, StringComparison.Ordinal));
      }

      internal void Trace(IDbCommand command, int? affectedRecords = null, bool error = false) {
         Trace(command, this.Configuration.Log, affectedRecords, error);
      }

      internal static void Trace(IDbCommand command, TextWriter log, int? affectedRecords = null, bool error = false) {

         if (command == null) throw new ArgumentNullException(nameof(command));

         if (log != null) {

            log.WriteLine();

            if (error) {
               log.WriteLine("-- ERROR: The following command produced an error");
            }

            log.WriteLine(command.CommandText);

            for (int i = 0; i < command.Parameters.Count; i++) {

               IDbDataParameter param = command.Parameters[i] as IDbDataParameter;

               if (param != null) {

                  log.WriteLine("-- {0}: {1} {2} (Size = {3}) [{4}]", param.ParameterName, param.Direction, param.DbType, param.Size, param.Value);
               }
            }

            if (affectedRecords != null) {
               log.WriteLine("-- [{0}] records affected.", affectedRecords.Value);
            }
         }
      }

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
               this.Connection?.Dispose();
            }
         }
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

      /// <exclude/>

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override string ToString() {
         return base.ToString();
      }

      #endregion

      #region Nested Types

      class ConnectionHolder : IDisposable {

         readonly IDbConnection conn;
         readonly bool prevStateWasClosed;

         public ConnectionHolder(IDbConnection conn) {

            if (conn == null) throw new ArgumentNullException(nameof(conn));

            this.conn = conn;
            this.prevStateWasClosed = (conn.State == ConnectionState.Closed);

            if (this.prevStateWasClosed) {
               this.conn.Open();
            }
         }

         public void Dispose() {

            if (conn != null
               && prevStateWasClosed
               && conn.State != ConnectionState.Closed) {

               conn.Close();
            }
         }
      }

      class WrappedTransaction : IDbTransaction {

         readonly Database db;
         readonly IDisposable connHolder;
         readonly IDbTransaction txAdo;
         readonly bool txBeganHere;
         readonly TransactionScope txScope;

         public IDbConnection Connection { get; }
         public IsolationLevel IsolationLevel { get; }

         public WrappedTransaction(Database db, IsolationLevel isolationLevel) {

            if (db == null) throw new ArgumentNullException(nameof(db));

            this.db = db;
            this.txAdo = this.db.Transaction;

            this.Connection = this.db.Connection;
            this.IsolationLevel = isolationLevel;

            this.connHolder = this.db.EnsureConnectionOpen();

            try {

               if (System.Transactions.Transaction.Current != null) {
                  this.txScope = new TransactionScope();
               }

               if (this.txScope == null
                  && this.txAdo == null) {

                  this.db.Transaction = this.db.Connection.BeginTransaction(isolationLevel);
                  this.txAdo = this.db.Transaction;
                  this.db.Configuration.Log?.WriteLine("-- TRANSACTION STARTED");
                  this.txBeganHere = true;
               }

            } catch {

               this.connHolder.Dispose();
               throw;
            }
         }

         public void Commit() {

            if (this.txScope != null) {
               this.txScope.Complete();
               return;
            }

            if (this.txBeganHere) {

               try {
                  this.txAdo.Commit();
                  this.db.Configuration.Log?.WriteLine("-- TRANSACTION COMMITED");

               } finally {
                  RemoveTxFromDatabase();
               }
            }
         }

         public void Rollback() {

            if (this.txScope != null) {
               return;
            }

            if (this.txBeganHere) {

               try {
                  this.txAdo.Rollback();
                  this.db.Configuration.Log?.WriteLine("-- TRANSACTION ROLLED BACK");

               } finally {
                  RemoveTxFromDatabase();
               }

            } else {
               throw new InvalidOperationException();
            }
         }

         public void Dispose() {

            try {
               if (this.txScope != null) {
                  this.txScope.Dispose();
                  return;
               }

               if (this.txBeganHere) {
                  try {
                     this.txAdo.Dispose();
                  } finally {
                     RemoveTxFromDatabase();
                  }
               }

            } finally {
               this.connHolder.Dispose();
            }
         }

         void RemoveTxFromDatabase() {

            if (this.db.Transaction != null
               && Object.ReferenceEquals(this.db.Transaction, this.txAdo)) {

               this.db.Transaction = null;
            }
         }
      }

      #endregion
   }

   /// <summary>
   /// Holds configuration options that customize the behavior of <see cref="Database"/>.
   /// This class cannot be instantiated, to get an instance use the <see cref="Database.Configuration"/> property.
   /// </summary>

   public sealed partial class DatabaseConfiguration {

      static readonly Func<DbCommandBuilder, int, string> getParameterNameI =
         (Func<DbCommandBuilder, int, string>)Delegate.CreateDelegate(typeof(Func<DbCommandBuilder, int, string>), typeof(DbCommandBuilder).GetMethod("GetParameterName", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new[] { typeof(int) }, null));

      static readonly Func<DbCommandBuilder, string, string> getParameterNameS =
         (Func<DbCommandBuilder, string, string>)Delegate.CreateDelegate(typeof(Func<DbCommandBuilder, string, string>), typeof(DbCommandBuilder).GetMethod("GetParameterName", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new[] { typeof(string) }, null));

      static readonly Func<DbCommandBuilder, int, string> getParameterPlaceholder =
         (Func<DbCommandBuilder, int, string>)Delegate.CreateDelegate(typeof(Func<DbCommandBuilder, int, string>), typeof(DbCommandBuilder).GetMethod("GetParameterPlaceholder", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new[] { typeof(int) }, null));

      /// <summary>
      /// The connection string to use as default.
      /// </summary>

      public static string DefaultConnectionString { get; set; }

      /// <summary>
      /// The provider's invariant name to use as default.
      /// </summary>

      public static string DefaultProviderInvariantName { get; set; }

      /// <summary>
      /// Gets or sets the beginning character or characters to use when specifying database objects (for example, tables or columns)
      /// whose names contain characters such as spaces or reserved tokens.
      /// </summary>

      public string QuotePrefix { get; set; } = "[";

      /// <summary>
      /// Gets or sets the ending character or characters to use when specifying database objects (for example, tables or columns)
      /// whose names contain characters such as spaces or reserved tokens.
      /// </summary>

      public string QuoteSuffix { get; set; } = "]";

      /// <summary>
      /// Specifies a function that prepares a parameter name to be used on <see cref="IDataParameter.ParameterName"/>.
      /// </summary>

      public Func<string, string> ParameterNameBuilder { get; set; } = (name) => "@" + name;

      /// <summary>
      /// Specifies a function that builds a parameter placeholder to be used in SQL statements.
      /// </summary>

      public Func<string, string> ParameterPlaceholderBuilder { get; set; } = (paramName) => paramName;

      /// <summary>
      /// Gets or sets the SQL command that returns the last identity value generated on the database.
      /// </summary>

      public string LastInsertIdCommand { get; set; } = "SELECT @@identity";

      /// <summary>
      /// Specifies the destination to write the SQL query or command. 
      /// </summary>

      public TextWriter Log { get; set; }

      /// <summary>
      /// Specifies a timeout to assign to commands. This setting is ignored if less or equal to -1. The default is -1.
      /// </summary>

      public int CommandTimeout { get; set; } = -1;

      internal SqlDialect SqlDialect { get; set; }

      internal DatabaseConfiguration(string providerInvariantName, Func<DbCommandBuilder> cbFn = null) {

         if (providerInvariantName == null) throw new ArgumentNullException(nameof(providerInvariantName));

         switch (providerInvariantName) {
            case "System.Data.SqlClient":
               this.SqlDialect = SqlDialect.TSql;
               break;

            case "MySql.Data.MySqlClient":
               this.QuotePrefix = "`";
               this.QuoteSuffix = this.QuotePrefix;
               break;

            case "System.Data.Odbc":
            case "System.Data.OleDb":
               this.ParameterNameBuilder = (name) => name;
               this.ParameterPlaceholderBuilder = (paramName) => "?";
               break;

            case "System.Data.SQLite":
               this.LastInsertIdCommand = "SELECT LAST_INSERT_ROWID()";
               break;

            default:

               if (providerInvariantName == "System.Data.SqlServerCe"
                  || providerInvariantName.StartsWith("System.Data.SqlServerCe.")) {

                  this.SqlDialect = SqlDialect.TSql;

               } else {

                  DbCommandBuilder cb = cbFn?.Invoke();

                  if (cb != null) {
                     Initialize(cb);
                  }
               }

               break;
         }
      }

      void Initialize(DbCommandBuilder cb) {

         string qp = cb.QuotePrefix;
         string qs = cb.QuoteSuffix;

         if (!String.IsNullOrEmpty(qp)
            || !String.IsNullOrEmpty(qs)) {

            this.QuotePrefix = qp;
            this.QuoteSuffix = qs;
         }

         this.ParameterNameBuilder = (name) => getParameterNameS(cb, name);

         string pName = getParameterNameI(cb, 1);
         string pPlace = getParameterPlaceholder(cb, 1);

         if (!(Object.ReferenceEquals(pName, pPlace)
            || pName == pPlace)) {

            this.ParameterPlaceholderBuilder = (paramName) => pPlace.Replace(pName, paramName);
         }
      }
   }

   enum SqlDialect {
      Default = 0,
      TSql
   }

   /// <summary>
   /// An exception that is thrown when a concurrency violation is encountered while saving to the database. A concurrency violation
   /// occurs when an unexpected number of rows are affected during save. This is usually because the data in the database has
   /// been modified since it was loaded into memory.
   /// </summary>

   [Serializable]
   public class ChangeConflictException : Exception {

      /// <summary>
      /// Initializes a new instance of the <see cref="ChangeConflictException"/> class
      /// with a specified error message.
      /// </summary>
      /// <param name="message">The message that describes the error.</param>

      public ChangeConflictException(string message)
         : base(message) { }
   }

   class MappingEnumerable<TResult> : IEnumerable<TResult>, IEnumerable, IDisposable {

      IEnumerator<TResult> enumerator;

      public MappingEnumerable(IDbCommand command, Func<IDataRecord, TResult> mapper, TextWriter logger = null) {
         this.enumerator = new MappingEnumerable<TResult>.Enumerator(command, mapper, logger);
      }

      public IEnumerator<TResult> GetEnumerator() {

         IEnumerator<TResult> e = this.enumerator;

         if (e == null) {
            throw new InvalidOperationException("Cannot enumerate more than once.");
         }

         this.enumerator = null;

         return e;
      }

      IEnumerator IEnumerable.GetEnumerator() {
         return GetEnumerator();
      }

      public void Dispose() {
         this.enumerator?.Dispose();
      }

      #region Nested Types

      class Enumerator : IEnumerator<TResult>, IEnumerator, IDisposable {

         readonly IDbCommand command;
         readonly Func<IDataRecord, TResult> mapper;
         readonly TextWriter logger;
         readonly bool prevStateWasClosed;

         IDataReader reader;

         public Enumerator(IDbCommand command, Func<IDataRecord, TResult> mapper, TextWriter logger) {

            if (command == null) throw new ArgumentNullException(nameof(command));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));

            IDbConnection conn = command.Connection;

            if (conn == null) {
               throw new ArgumentException("command.Connection cannot be null", nameof(command));
            }

            prevStateWasClosed = (conn.State == ConnectionState.Closed);

            this.command = command;
            this.mapper = mapper;
            this.logger = logger;
         }

         public TResult Current { get; private set; }

         object IEnumerator.Current => Current;

         public bool MoveNext() {

            if (this.reader == null) {

               PossiblyOpenConnection();

               try {
                  this.reader = this.command.ExecuteReader();
                  Database.Trace(this.command, this.logger, this.reader.RecordsAffected);

               } catch {

                  try {
                     Database.Trace(this.command, this.logger, error: true);
                  } finally {
                     PossiblyCloseConnection();
                  }

                  throw;
               }
            }

            if (this.reader.IsClosed) {
               // see Node.Load
               return false;
            }

            try {
               if (this.reader.Read()) {
                  this.Current = this.mapper(this.reader);
                  return true;
               }

            } catch {

               PossiblyCloseConnection();
               throw;
            }

            PossiblyCloseConnection();

            return false;
         }

         public void Reset() {
            throw new NotSupportedException();
         }

         public void Dispose() {

            this.reader?.Dispose();

            PossiblyCloseConnection();
         }

         void PossiblyOpenConnection() {

            if (this.prevStateWasClosed) {
               this.command.Connection.Open();
            }
         }

         void PossiblyCloseConnection() {

            if (this.prevStateWasClosed) {

               IDbConnection conn = this.command.Connection;

               if (conn.State != ConnectionState.Closed) {
                  conn.Close();
               }
            }
         }
      }

      #endregion
   }
}
