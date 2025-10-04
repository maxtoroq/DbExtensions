// Copyright 2009-2025 Max Toro Q.
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
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DbExtensions;

#nullable enable

/// <summary>
/// Provides simple data access using <see cref="SqlSet"/>, <see cref="SqlBuilder"/> and <see cref="SqlTable&lt;TEntity>"/>.
/// </summary>

public partial class Database : IDisposable {

   readonly bool
   _disposeConn;

   /// <summary>
   /// Gets the connection to associate with new commands.
   /// </summary>

   public DbConnection
   Connection { get; }

   /// <summary>
   /// Gets or sets a transaction to associate with new commands.
   /// </summary>		

   public DbTransaction?
   Transaction { get; set; }

   /// <summary>
   /// Provides access to configuration options for this instance. 
   /// </summary>

   public DatabaseConfiguration
   Configuration { get; private set; }

   /// <summary>
   /// Initializes a new instance of the <see cref="Database"/> class
   /// using the provided connection string and provider's invariant name.
   /// </summary>
   /// <param name="connectionString">The connection string.</param>
   /// <param name="providerInvariantName">The provider's invariant name.</param>

#pragma warning disable CS8618
   public
   Database(string connectionString, string providerInvariantName) {

      ArgumentNullException.ThrowIfNull(connectionString);
      ArgumentNullException.ThrowIfNull(providerInvariantName);

      var factory = DbProviderFactories.GetFactory(providerInvariantName);

      var connection = factory.CreateConnection()
         ?? throw new ArgumentException("The provider factory CreateConnection() returned null.", nameof(providerInvariantName));

      connection.ConnectionString = connectionString;

      this.Connection = connection;
      _disposeConn = true;

      Initialize(providerInvariantName);
   }

   /// <summary>
   /// Initializes a new instance of the <see cref="Database"/> class
   /// using the provided connection.
   /// </summary>
   /// <param name="connection">The connection.</param>

   public
   Database(DbConnection connection) {

      ArgumentNullException.ThrowIfNull(connection);

      this.Connection = connection;

      Initialize(null);
   }

   internal // Used by tests
   Database(DbConnection connection, string providerInvariantName) {

      ArgumentNullException.ThrowIfNull(connection);
      ArgumentNullException.ThrowIfNull(providerInvariantName);

      this.Connection = connection;

      Initialize(providerInvariantName);
   }
#pragma warning restore CS8618

   void
   Initialize(string? providerInvariantName) {

      providerInvariantName ??= this.Connection.GetType().Namespace
         ?? throw new InvalidOperationException("Couldn't determine provider invariant name.");

      this.Configuration = new DatabaseConfiguration(
         providerInvariantName,
         () => CreateCommandBuilder(providerInvariantName));

      Initialize2(providerInvariantName);
   }

   partial void
   Initialize2(string providerInvariantName);

   DbCommandBuilder?
   CreateCommandBuilder(string providerInvariantName) {

      var factory = DbProviderFactories.GetFactory(this.Connection)
         ?? DbProviderFactories.GetFactory(providerInvariantName);

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

   public IDisposable
   EnsureConnectionOpen() {

      var conn = this.Connection;
      var wasClosed = (conn.State == ConnectionState.Closed);

      if (wasClosed) {
         conn.Open();
      }

      return new WrappedConnection((wasClosed) ? conn : null);
   }

   /// <summary>
   /// Opens <see cref="Connection"/> (if it's not open) and returns an <see cref="IAsyncDisposable"/> object
   /// you can use to close it (if it wasn't open).
   /// </summary>
   /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests. The default is <see cref="CancellationToken.None"/>.</param>
   /// <returns>An <see cref="IAsyncDisposable"/> object to close the connection.</returns>
   /// <remarks>
   /// Use this method with the <c>using</c> statement in C# or Visual Basic to ensure that a block of code
   /// is always executed with an open connection.
   /// </remarks>
   /// <example>
   /// <code>
   /// await using (await db.EnsureConnectionOpenAsync()) {
   ///   // Execute commands.
   /// }
   /// </code>
   /// </example>

   public async ValueTask<IAsyncDisposable>
   EnsureConnectionOpenAsync(CancellationToken cancellationToken = default) {

      var conn = this.Connection;
      var wasClosed = (conn.State == ConnectionState.Closed);

      if (wasClosed) {

         await conn.OpenAsync(cancellationToken)
            .ConfigureAwait(false);
      }

      return new WrappedConnection((wasClosed) ? conn : null);
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
   /// By calling <see cref="DbTransaction.Commit()"/> on the returned object, this object
   /// will then call <see cref="DbTransaction.Commit()"/> on the wrapped transaction if the
   /// transaction was just created, or do nothing if it was previously created.
   /// </remarks>
   /// <example>
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
   /// </example>

   public DbTransaction
   EnsureInTransaction() =>
      EnsureInTransaction(IsolationLevel.Unspecified);

   /// <inheritdoc cref="EnsureInTransaction()"/>
   /// <param name="isolationLevel">
   /// Specifies the isolation level for the transaction. This parameter is ignored when using
   /// an existing transaction.
   /// </param>

   public virtual DbTransaction
   EnsureInTransaction(IsolationLevel isolationLevel) {

      var connHolder = (WrappedConnection)EnsureConnectionOpen();
      var newTx = default(DbTransaction);

      try {

         if (this.Transaction is null) {
            this.Transaction = (newTx = this.Connection.BeginTransaction(isolationLevel));
            this.Configuration.Log?.WriteLine("-- TRANSACTION STARTED");
         }

      } catch {

         connHolder.Dispose();
         throw;
      }

      if (newTx != null) {
         return new WrappedTransaction(this, newTx, connHolder);
      }

      return new NoOpTransaction(this.Connection, isolationLevel, connHolder);
   }

   /// <inheritdoc cref="EnsureInTransaction()" path="*[not(self::example)]"/>
   /// <inheritdoc cref="EnsureConnectionOpenAsync" path="param"/>
   /// <example>
   /// <para>
   /// Calls to this method can be nested, like in the following example:
   /// </para>
   /// <code>
   /// async Task DoSomething() {
   /// 
   ///    await using (var tx = await this.db.EnsureInTransactionAsync()) {
   ///       
   ///       // Execute commands
   /// 
   ///       await DoSomethingElse();
   /// 
   ///       await tx.CommitAsync();
   ///    }
   /// }
   /// 
   /// async Task DoSomethingElse() {
   ///    
   ///    await using (var tx = await this.db.EnsureInTransactionAsync()) {
   ///       
   ///       // Execute commands
   /// 
   ///       await tx.CommitAsync();
   ///    }
   /// }
   /// </code>
   /// </example>

   public ValueTask<DbTransaction>
   EnsureInTransactionAsync(CancellationToken cancellationToken = default) =>
      EnsureInTransactionAsync(IsolationLevel.Unspecified, cancellationToken);

   /// <inheritdoc cref="EnsureInTransactionAsync(CancellationToken)"/>
   /// <inheritdoc cref="EnsureInTransaction(IsolationLevel)" path="param"/>

   public virtual async ValueTask<DbTransaction>
   EnsureInTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default) {

      var connHolder = (WrappedConnection)EnsureConnectionOpen();
      var newTx = default(DbTransaction);

      try {

         if (this.Transaction is null) {

            this.Transaction = (newTx = await this.Connection.BeginTransactionAsync(isolationLevel, cancellationToken)
               .ConfigureAwait(false));

            this.Configuration.Log?.WriteLine("-- TRANSACTION STARTED");
         }

      } catch {

         await connHolder.DisposeAsync()
            .ConfigureAwait(false);

         throw;
      }

      if (newTx != null) {
         return new WrappedTransaction(this, newTx, connHolder);
      }

      return new NoOpTransaction(this.Connection, isolationLevel, connHolder);
   }

   /// <summary>
   /// Executes the <paramref name="nonQuery"/> command. Optionally uses a transaction and validates
   /// affected records value before committing.
   /// </summary>
   /// <param name="nonQuery">The non-query command to execute.</param>
   /// <param name="affect">The number of records the command should affect. This value is ignored if less or equal to -1.</param>
   /// <param name="exact"><c>true</c> if the number of affected records should exactly match <paramref name="affect"/>; <c>false</c> if a lower number is acceptable.</param>
   /// <returns>The number of affected records.</returns>
   /// <exception cref="ChangeConflictException">The number of affected records is not equal to <paramref name="affect"/>.</exception>

   public int
   Execute(SqlBuilder nonQuery, int affect = -1, bool exact = false) {

      ArgumentNullException.ThrowIfNull(nonQuery);

      var command = CreateCommand(nonQuery);
      var validateAffected = affect > -1;

      using var conn = EnsureConnectionOpen();
      using var tx = (validateAffected) ? EnsureInTransaction() : null;

      command.Transaction = this.Transaction;

      int affectedRecords;

      try {
         affectedRecords = command.ExecuteNonQuery();
      } catch {

         Trace(command, error: true);
         throw;
      }

      OnExecuted(command, affect, exact, validateAffected, affectedRecords);

      tx?.Commit();

      return affectedRecords;
   }

   /// <inheritdoc cref="Execute"/>
   /// <inheritdoc cref="EnsureConnectionOpenAsync" path="param"/>

   public async ValueTask<int>
   ExecuteAsync(SqlBuilder nonQuery, int affect = -1, bool exact = false, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(nonQuery);

      var command = CreateCommand(nonQuery);
      var validateAffected = affect > -1;

      await using var conn = (await EnsureConnectionOpenAsync(cancellationToken)
            .ConfigureAwait(false))
         .ConfigureAwait(false);

      var tx = (validateAffected) ?
         await EnsureInTransactionAsync(cancellationToken).ConfigureAwait(false)
         : new NoOpTransaction(this.Connection, IsolationLevel.Unspecified, new WrappedConnection(null));

      await using var txDisp = tx.ConfigureAwait(false);

      command.Transaction = this.Transaction;

      int affectedRecords;

      try {

         affectedRecords = await command.ExecuteNonQueryAsync(cancellationToken)
            .ConfigureAwait(false);

      } catch {

         Trace(command, error: true);
         throw;
      }

      OnExecuted(command, affect, exact, validateAffected, affectedRecords);

      await tx.CommitAsync(cancellationToken)
         .ConfigureAwait(false);

      return affectedRecords;
   }

   void
   OnExecuted(DbCommand command, int affect, bool exact, bool validateAffected, int affectedRecords) {

      Trace(command, affectedRecords);

      if (validateAffected
         && affectedRecords != affect) {

         if (exact) {

            throw new ChangeConflictException(String.Create(
               CultureInfo.InvariantCulture,
               $"The number of affected records should be {affect}, the actual number is {affectedRecords}."));

         } else if (affectedRecords > affect) {

            throw new ChangeConflictException(String.Create(
               CultureInfo.InvariantCulture,
               $"The number of affected records should be {affect} or lower, the actual number is {affectedRecords}."));
         }
      }
   }

   /// <summary>
   /// Maps the results of the <paramref name="query"/> to <typeparamref name="TResult"/> objects,
   /// using the provided <paramref name="mapper"/> delegate.
   /// </summary>
   /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
   /// <param name="query">The query.</param>
   /// <param name="mapper">The delegate for creating <typeparamref name="TResult"/> objects from an <see cref="DbDataReader"/> object.</param>
   /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>

   public IEnumerable<TResult>
   Map<TResult>(SqlBuilder query, Func<DbDataReader, TResult> mapper) {

      ArgumentNullException.ThrowIfNull(query);
      ArgumentNullException.ThrowIfNull(mapper);

      return new MappingEnumerable<TResult>(CreateCommand(query), mapper, this.Configuration.Log);
   }

   /// <inheritdoc cref="Map&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)"/>

   public IAsyncEnumerable<TResult>
   AsyncMap<TResult>(SqlBuilder query, Func<DbDataReader, TResult> mapper) {

      ArgumentNullException.ThrowIfNull(query);
      ArgumentNullException.ThrowIfNull(mapper);

      return new AsyncMappingEnumerable<TResult>(CreateCommand(query), mapper, this.Configuration.Log);
   }

   /// <summary>
   /// Gets the identity value of the last inserted record.
   /// </summary>
   /// <returns>The identity value of the last inserted record.</returns>
   /// <remarks>
   /// It is very important to keep the connection open between the last 
   /// command and this one, or else you might get the wrong value.
   /// </remarks>

   public virtual object?
   LastInsertId() {

      var sql = this.Configuration.LastInsertIdCommand;

      if (String.IsNullOrEmpty(sql)) {
         throw new InvalidOperationException("Configuration.LastInsertIdCommand cannot be null or empty.");
      }

      var command = CreateCommand(new SqlBuilder(sql.Length, 0).Append(sql));
      var value = command.ExecuteScalar();

      Trace(command);

      return value;
   }

   /// <inheritdoc cref="LastInsertId"/>
   /// <inheritdoc cref="EnsureConnectionOpenAsync" path="param"/>

   public virtual async ValueTask<object?>
   LastInsertIdAsync(CancellationToken cancellationToken = default) {

      var sql = this.Configuration.LastInsertIdCommand;

      if (String.IsNullOrEmpty(sql)) {
         throw new InvalidOperationException("Configuration.LastInsertIdCommand cannot be null or empty.");
      }

      var command = CreateCommand(new SqlBuilder(sql.Length, 0).Append(sql));
      var value = await command.ExecuteScalarAsync(cancellationToken)
         .ConfigureAwait(false);

      Trace(command);

      return value;
   }

   /// <summary>
   /// Creates and returns a <see cref="DbCommand"/> object from the specified <paramref name="sqlBuilder"/>.
   /// </summary>
   /// <param name="sqlBuilder">The <see cref="SqlBuilder"/> that provides the command's text and parameters.</param>
   /// <returns>
   /// A new <see cref="DbCommand"/> object with its <see cref="DbCommand.CommandText"/> property
   /// initialized with the <paramref name="sqlBuilder"/>'s string representation, and its <see cref="DbCommand.Parameters"/>
   /// property is initialized with the values from the <see cref="SqlBuilder.ParameterValues"/> property of the <paramref name="sqlBuilder"/> parameter.
   /// </returns>

   public virtual DbCommand
   CreateCommand(SqlBuilder sqlBuilder) {

      ArgumentNullException.ThrowIfNull(sqlBuilder);

      var command = this.Connection.CreateCommand();

      var format = sqlBuilder.ToString();
      var parameters = sqlBuilder.ParameterValues;

      if (this.Transaction is { } tx) {
         command.Transaction = tx;
      }

      if (this.Configuration.CommandTimeout is { } timeout and > -1) {
         command.CommandTimeout = timeout;
      }

      if (parameters is null or { Count: 0 }) {
         command.CommandText = format;
         return command;
      }

      var paramPlaceholders = new object[parameters.Count];

      for (int i = 0; i < paramPlaceholders.Length; i++) {

         var paramValue = parameters[i];

         var dbParam = paramValue as DbParameter;

         if (dbParam is null) {
            dbParam = command.CreateParameter();
            dbParam.Value = paramValue ?? DBNull.Value;
         }

         dbParam.ParameterName = this.Configuration.ParameterNameBuilder
            .Invoke($"p{i}");

         command.Parameters.Add(dbParam);

         paramPlaceholders[i] = this.Configuration.ParameterPlaceholderBuilder
            .Invoke(dbParam.ParameterName);
      }

      command.CommandText = String.Format(CultureInfo.InvariantCulture, format, paramPlaceholders);

      return command;
   }

   /// <summary>
   /// Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier.
   /// </summary>
   /// <param name="identifier">The original identifier.</param>
   /// <returns>The quoted version of the identifier. If the indentifier is already quoted it's returned unchanged.</returns>

   public string
   QuoteIdentifier(string identifier) {

      QuoteIdentifierImpl(identifier, out var quotePrefix, out var quoteSuffix);

      return String.Concat(quotePrefix, identifier, quoteSuffix);
   }

   internal void
   QuoteIdentifier(StringBuilder sb, string identifier) {

      QuoteIdentifierImpl(identifier, out var quotePrefix, out var quoteSuffix);

      sb.Append(quotePrefix);
      sb.Append(identifier);
      sb.Append(quoteSuffix);
   }

   void
   QuoteIdentifierImpl(string identifier, out string quotePrefix, out string quoteSuffix) {

      ArgumentNullException.ThrowIfNull(identifier);

      quotePrefix = this.Configuration.QuotePrefix;
      quoteSuffix = this.Configuration.QuoteSuffix;

      if (quotePrefix.Length == 0
         && quoteSuffix.Length == 0) {

         return;
      }

      if (identifier.StartsWith(quotePrefix, StringComparison.Ordinal)
         && identifier.EndsWith(quoteSuffix, StringComparison.Ordinal)) {

         quotePrefix = String.Empty;
         quoteSuffix = String.Empty;
      }
   }

   internal void
   Trace(DbCommand command, int? affectedRecords = null, bool error = false) =>
      Trace(command, this.Configuration.Log, affectedRecords, error);

   internal static void
   Trace(DbCommand command, TextWriter? log, int? affectedRecords = null, bool error = false) {

      if (log is not null) {

         log.WriteLine();

         if (error) {
            log.WriteLine("-- ERROR: The following command produced an error");
         }

         log.WriteLine(command.CommandText);

         for (int i = 0; i < command.Parameters.Count; i++) {

            var param = command.Parameters[i];

            if (param is not null) {
               log.WriteLine(String.Create(log.FormatProvider, $"-- {param.ParameterName}: {param.Direction} {param.DbType} (Size = {param.Size}) [{param.Value}]"));
            }
         }

         if (affectedRecords is not null) {
            log.WriteLine(String.Create(log.FormatProvider, $"-- [{affectedRecords.Value}] records affected."));
         }
      }
   }

   /// <summary>
   /// Releases all resources used by the current instance of the <see cref="Database"/> class.
   /// </summary>

   public void
   Dispose() {

      Dispose(true);
      GC.SuppressFinalize(this);
   }

   /// <summary>
   /// Releases the resources used by this <see cref="Database"/> instance.
   /// </summary>
   /// <param name="disposing">
   /// <c>true</c> if this method is being called due to a call to <see cref="Dispose()"/>; otherwise, <c>false</c>.
   /// </param>

   protected virtual void
   Dispose(bool disposing) {

      if (disposing) {

         if (_disposeConn) {
            this.Connection?.Dispose();
         }
      }
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

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public override string?
   ToString() => base.ToString();

   sealed class WrappedConnection(DbConnection? previouslyClosedConn) : IDisposable, IAsyncDisposable {

      public void
      Dispose() {

         if (previouslyClosedConn is { State: not ConnectionState.Closed } conn) {
            conn.Close();
         }
      }

      public async ValueTask
      DisposeAsync() {

         if (previouslyClosedConn is { State: not ConnectionState.Closed } conn) {

            await conn.CloseAsync()
               .ConfigureAwait(false);
         }
      }
   }

   sealed class WrappedTransaction : DbTransaction {

      readonly Database
      _db;

      readonly DbTransaction
      _tx;

      readonly WrappedConnection
      _connHolder;

      protected override DbConnection?
      DbConnection => _tx.Connection;

      public override IsolationLevel
      IsolationLevel => _tx.IsolationLevel;

      public
      WrappedTransaction(Database db, DbTransaction tx, WrappedConnection connHolder) {
         _db = db;
         _tx = tx;
         _connHolder = connHolder;
      }

      public override void
      Commit() {

         try {
            _tx.Commit();
            _db.Configuration.Log?.WriteLine("-- TRANSACTION COMMITED");

         } finally {
            RemoveTxFromDatabase();
         }
      }

      public override async Task
      CommitAsync(CancellationToken cancellationToken = default) {

         try {

            await _tx.CommitAsync(cancellationToken)
               .ConfigureAwait(false);

            _db.Configuration.Log?.WriteLine("-- TRANSACTION COMMITED");

         } finally {
            RemoveTxFromDatabase();
         }
      }

      public override void
      Rollback() {

         try {
            _tx.Rollback();
            _db.Configuration.Log?.WriteLine("-- TRANSACTION ROLLED BACK");

         } finally {
            RemoveTxFromDatabase();
         }
      }

      public override async Task
      RollbackAsync(CancellationToken cancellationToken = default) {

         try {

            await _tx.RollbackAsync(cancellationToken)
               .ConfigureAwait(false);

            _db.Configuration.Log?.WriteLine("-- TRANSACTION ROLLED BACK");

         } finally {
            RemoveTxFromDatabase();
         }
      }

      protected override void
      Dispose(bool disposing) {

         if (disposing) {

            try {

               try {
                  _tx.Dispose();
               } finally {
                  RemoveTxFromDatabase();
               }

            } finally {
               _connHolder.Dispose();
            }
         }
      }

      public override async ValueTask
      DisposeAsync() {

         try {

            try {

               await _tx.DisposeAsync()
                  .ConfigureAwait(false);

            } finally {
               RemoveTxFromDatabase();
            }

         } finally {

            await _connHolder.DisposeAsync()
               .ConfigureAwait(false);
         }
      }

      void
      RemoveTxFromDatabase() {

         if (Object.ReferenceEquals(_tx, _db.Transaction)) {
            _db.Transaction = null;
         }
      }
   }

   sealed class NoOpTransaction(DbConnection conn, IsolationLevel isolationLevel, WrappedConnection connHolder) : DbTransaction {

      protected override DbConnection?
      DbConnection => conn;

      public override IsolationLevel
      IsolationLevel => isolationLevel;

      public override void
      Commit() { }

      public override void
      Rollback() =>
         throw new NotImplementedException();

      protected override void
      Dispose(bool disposing) {

         if (disposing) {
            connHolder.Dispose();
         }
      }

      public override async ValueTask
      DisposeAsync() {

         await connHolder.DisposeAsync()
            .ConfigureAwait(false);
      }
   }
}

/// <summary>
/// Holds configuration options that customize the behavior of <see cref="Database"/>.
/// This class cannot be instantiated, to get an instance use the <see cref="Database.Configuration"/> property.
/// </summary>

public sealed partial class DatabaseConfiguration {

   static readonly Func<DbCommandBuilder, int, string>
   _getParameterNameI = (Func<DbCommandBuilder, int, string>)
      Delegate.CreateDelegate(typeof(Func<DbCommandBuilder, int, string>), typeof(DbCommandBuilder)
         .GetMethod("GetParameterName", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, [typeof(int)], null)!);

   static readonly Func<DbCommandBuilder, string, string>
   _getParameterNameS = (Func<DbCommandBuilder, string, string>)
      Delegate.CreateDelegate(typeof(Func<DbCommandBuilder, string, string>), typeof(DbCommandBuilder)
         .GetMethod("GetParameterName", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, [typeof(string)], null)!);

   static readonly Func<DbCommandBuilder, int, string>
   _getParameterPlaceholder = (Func<DbCommandBuilder, int, string>)
      Delegate.CreateDelegate(typeof(Func<DbCommandBuilder, int, string>), typeof(DbCommandBuilder)
         .GetMethod("GetParameterPlaceholder", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, [typeof(int)], null)!);

   string?
   _quotePrefix;

   string?
   _quoteSuffix;

   Func<string, string>?
   _parameterNameBuilder;

   Func<string, string>?
   _parameterPlaceholderBuilder;

   string?
   _lastInsertIdCommand;

   /// <summary>
   /// Gets or sets the beginning character or characters to use when specifying database objects (for example, tables or columns)
   /// whose names contain characters such as spaces or reserved tokens.
   /// </summary>

   [AllowNull]
   public string
   QuotePrefix {
      get => _quotePrefix ?? "[";
      set => _quotePrefix = value;
   }

   /// <summary>
   /// Gets or sets the ending character or characters to use when specifying database objects (for example, tables or columns)
   /// whose names contain characters such as spaces or reserved tokens.
   /// </summary>

   [AllowNull]
   public string
   QuoteSuffix {
      get => _quoteSuffix ?? "]";
      set => _quoteSuffix = value;
   }

   /// <summary>
   /// Specifies a function that prepares a parameter name to be used on <see cref="DbParameter.ParameterName"/>.
   /// </summary>

   [AllowNull]
   public Func<string, string>
   ParameterNameBuilder {
      get => _parameterNameBuilder ?? DefaultParameterNameBuilder;
      set => _parameterNameBuilder = value;
   }

   /// <summary>
   /// Specifies a function that builds a parameter placeholder to be used in SQL statements.
   /// </summary>

   [AllowNull]
   public Func<string, string>
   ParameterPlaceholderBuilder {
      get => _parameterPlaceholderBuilder ?? DefaultParameterPlaceholderBuilder;
      set => _parameterPlaceholderBuilder = value;
   }

   /// <summary>
   /// Gets or sets the SQL command that returns the last identity value generated on the database.
   /// </summary>

   [AllowNull]
   public string
   LastInsertIdCommand {
      get => _lastInsertIdCommand ?? "SELECT @@IDENTITY";
      set => _lastInsertIdCommand = value;
   }

   /// <summary>
   /// Specifies the destination to write the SQL query or command. 
   /// </summary>

   public TextWriter?
   Log { get; set; }

   /// <summary>
   /// Specifies a timeout to assign to commands. This setting is ignored if less or equal to -1. The default is -1.
   /// </summary>

   public int
   CommandTimeout { get; set; } = -1;

   internal SqlDialect
   SqlDialect { get; set; }

   static string
   DefaultParameterNameBuilder(string name) => "@" + name;

   static string
   DefaultParameterPlaceholderBuilder(string name) => name;

#pragma warning disable CS8618
   internal
   DatabaseConfiguration(string providerInvariantName, Func<DbCommandBuilder?>? cbFn = null) {
#pragma warning restore CS8618

      switch (providerInvariantName) {
         case "Microsoft.Data.SqlClient":
            this.LastInsertIdCommand = "SELECT SCOPE_IDENTITY()";
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
            if (cbFn?.Invoke() is { } cb) {
               Initialize(cb);
            }
            break;
      }
   }

   void
   Initialize(DbCommandBuilder cb) {

      var qp = cb.QuotePrefix;
      var qs = cb.QuoteSuffix;

      if (!String.IsNullOrEmpty(qp)
         || !String.IsNullOrEmpty(qs)) {

         this.QuotePrefix = qp ?? String.Empty;
         this.QuoteSuffix = qs ?? String.Empty;
      }

      this.ParameterNameBuilder = (name) => _getParameterNameS.Invoke(cb, name);

      var pName = _getParameterNameI.Invoke(cb, 1);
      var pPlace = _getParameterPlaceholder.Invoke(cb, 1);

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

public sealed class ChangeConflictException : Exception {

   /// <summary>
   /// Initializes a new instance of the <see cref="ChangeConflictException"/> class
   /// with a specified error message.
   /// </summary>
   /// <param name="message">The message that describes the error.</param>

   public
   ChangeConflictException(string message)
      : base(message) { }
}

sealed class MappingEnumerable<TResult> : IEnumerable<TResult>, IEnumerable, IEnumerator<TResult>, IEnumerator, IDisposable {

   readonly DbCommand
   _command;

   readonly Func<DbDataReader, TResult>
   _mapper;

   readonly TextWriter?
   _logger;

   readonly bool
   _prevStateWasClosed;

   bool
   _used;

   DbDataReader?
   _reader;

   TResult
   _current;

   public TResult
   Current => _current;

   object
   IEnumerator.Current => Current!;

#pragma warning disable CS8618
   public
   MappingEnumerable(DbCommand command, Func<DbDataReader, TResult> mapper, TextWriter? logger) {
#pragma warning restore CS8618

      var conn = command.Connection
         ?? throw new ArgumentException("command.Connection cannot be null.", nameof(command));

      _prevStateWasClosed = (conn.State == ConnectionState.Closed);

      _command = command;
      _mapper = mapper;
      _logger = logger;
   }

   public IEnumerator<TResult>
   GetEnumerator() {

      if (!_used) {
         _used = true;
         return this;
      }

      throw new InvalidOperationException("Cannot enumerate more than once.");
   }

   IEnumerator
   IEnumerable.GetEnumerator() =>
      GetEnumerator();

   public bool
   MoveNext() {

      if (_reader is null) {

         PossiblyOpenConnection();

         try {
            _reader = _command.ExecuteReader();
            Database.Trace(_command, _logger, _reader.RecordsAffected);

         } catch {

            try {
               Database.Trace(_command, _logger, error: true);
            } finally {
               PossiblyCloseConnection();
            }

            throw;
         }
      }

      if (_reader.IsClosed) {
         // see MappingContext.LoadMany()
         return false;
      }

      try {
         if (_reader.Read()) {
            _current = _mapper.Invoke(_reader);
            return true;
         }

      } catch {

         PossiblyCloseConnection();
         throw;
      }

      PossiblyCloseConnection();

      return false;
   }

   public void
   Reset() =>
      throw new NotSupportedException();

   public void
   Dispose() {

      _reader?.Dispose();

      PossiblyCloseConnection();
   }

   void
   PossiblyOpenConnection() {

      if (_prevStateWasClosed) {
         _command.Connection?.Open();
      }
   }

   void
   PossiblyCloseConnection() {

      if (_prevStateWasClosed
         && _command.Connection is { State: not ConnectionState.Closed } conn) {

         conn.Close();
      }
   }
}

sealed class AsyncMappingEnumerable<TResult> : IAsyncEnumerable<TResult>, IAsyncEnumerator<TResult> {

   readonly DbCommand
   _command;

   readonly Func<DbDataReader, TResult>
   _mapper;

   readonly TextWriter?
   _logger;

   readonly bool
   _prevStateWasClosed;

   bool
   _used;

   CancellationToken
   _cancellationToken;

   DbDataReader?
   _reader;

   TResult
   _current;

   public TResult
   Current => _current;

#pragma warning disable CS8618
   public
   AsyncMappingEnumerable(DbCommand command, Func<DbDataReader, TResult> mapper, TextWriter? logger) {
#pragma warning restore CS8618

      var conn = command.Connection
         ?? throw new ArgumentException("command.Connection cannot be null.", nameof(command));

      _prevStateWasClosed = (conn.State == ConnectionState.Closed);

      _command = command;
      _mapper = mapper;
      _logger = logger;
   }

   public IAsyncEnumerator<TResult>
   GetAsyncEnumerator(CancellationToken cancellationToken = default) {

      if (!_used) {
         _cancellationToken = cancellationToken;
         _used = true;
         return this;
      }

      throw new InvalidOperationException("Cannot enumerate more than once.");
   }

   public async ValueTask<bool>
   MoveNextAsync() {

      if (_reader is null) {

         await PossiblyOpenConnection()
            .ConfigureAwait(false);

         try {

            _reader = await _command.ExecuteReaderAsync(_cancellationToken)
               .ConfigureAwait(false);

            Database.Trace(_command, _logger, _reader.RecordsAffected);

         } catch {

            try {
               Database.Trace(_command, _logger, error: true);
            } finally {

               await PossiblyCloseConnection()
                  .ConfigureAwait(false);
            }

            throw;
         }
      }

      if (_reader.IsClosed) {
         // see MappingContext.LoadMany()
         return false;
      }

      try {

         if (await _reader.ReadAsync(_cancellationToken).ConfigureAwait(false)) {
            _current = _mapper.Invoke(_reader);
            return true;
         }

      } catch {

         await PossiblyCloseConnection()
            .ConfigureAwait(false);

         throw;
      }

      await PossiblyCloseConnection()
         .ConfigureAwait(false);

      return false;
   }

   async ValueTask
   PossiblyOpenConnection() {

      if (_prevStateWasClosed
         && _command.Connection is { } conn) {

         await conn.OpenAsync(_cancellationToken)
            .ConfigureAwait(false);
      }
   }

   async ValueTask
   PossiblyCloseConnection() {

      if (_prevStateWasClosed
         && _command.Connection is { State: not ConnectionState.Closed } conn) {

         await conn.CloseAsync()
            .ConfigureAwait(false);
      }
   }

   public async ValueTask
   DisposeAsync() {

      if (_reader is { } r) {

         await r.DisposeAsync()
            .ConfigureAwait(false);
      }

      await PossiblyCloseConnection()
         .ConfigureAwait(false);
   }
}
