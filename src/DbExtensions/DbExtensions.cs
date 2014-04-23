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

namespace DbExtensions {

   using System;
   using System.Collections.Generic;
   using System.Configuration;
   using System.Data;
   using System.Data.Common;
   using System.Diagnostics.CodeAnalysis;
   using System.Globalization;
   using System.IO;
   using System.Linq;
   using System.Reflection;
   using System.Text;
   using System.Text.RegularExpressions;
   using System.Transactions;

   /// <summary>
   /// Provides extension methods for common ADO.NET objects.
   /// </summary>
   public static partial class Extensions {

      static readonly Func<DbConnection, DbProviderFactory> getDbProviderFactory =
         (Func<DbConnection, DbProviderFactory>)Delegate.CreateDelegate(typeof(Func<DbConnection, DbProviderFactory>), typeof(DbConnection).GetProperty("DbProviderFactory", BindingFlags.Instance | BindingFlags.NonPublic).GetGetMethod(nonPublic: true));
      
      static readonly Func<DbCommandBuilder, int, string> getParameterName =
         (Func<DbCommandBuilder, int, string>)Delegate.CreateDelegate(typeof(Func<DbCommandBuilder, int, string>), typeof(DbCommandBuilder).GetMethod("GetParameterName", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new Type[] { typeof(Int32) }, null));
      
      static readonly Func<DbCommandBuilder, int, string> getParameterPlaceholder = 
         (Func<DbCommandBuilder, int, string>)Delegate.CreateDelegate(typeof(Func<DbCommandBuilder, int, string>), typeof(DbCommandBuilder).GetMethod("GetParameterPlaceholder", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new Type[] { typeof(Int32) }, null));
      
      /// <summary>
      /// Creates and returns a <see cref="DbConnection"/> object whose <see cref="DbConnection.ConnectionString"/>
      /// property is initialized with the <paramref name="connectionString"/> parameter.
      /// </summary>
      /// <param name="factory">The provider factory used to create the connection.</param>
      /// <param name="connectionString">The connection string for the connection.</param>
      /// <returns>
      /// A new <see cref="DbConnection"/> object whose <see cref="DbConnection.ConnectionString"/>
      /// property is initialized with the <paramref name="connectionString"/> parameter.
      /// </returns>
      /// <seealso cref="DbProviderFactory.CreateConnection()"/>
      public static DbConnection CreateConnection(this DbProviderFactory factory, string connectionString) {

         if (factory == null) throw new ArgumentNullException("factory");

         DbConnection conn = factory.CreateConnection();
         conn.ConnectionString = connectionString;

         return conn;
      }

      /// <summary>
      /// Gets the <see cref="DbProviderFactory"/> associated with the connection.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <returns>The <see cref="DbProviderFactory"/> associated with the connection.</returns>
      public static DbProviderFactory GetProviderFactory(this DbConnection connection) {

         if (connection == null) throw new ArgumentNullException("connection");

         DbProviderFactory factory = getDbProviderFactory(connection);

         if (factory != null)
            return factory;

         // In .NET 4.5 Odbc and OleDb do not override DbConnection.DbProviderFactory

         if (connection is System.Data.Odbc.OdbcConnection)
            return System.Data.Odbc.OdbcFactory.Instance;

         if (connection is System.Data.OleDb.OleDbConnection)
            return System.Data.OleDb.OleDbFactory.Instance;

         Type type = connection.GetType();
         string ns = type.Namespace;
         string factoryName = ns.Split('.').Last() + "Factory";
         
         Type factoryType = type.Assembly.GetType(ns + "." + factoryName, throwOnError: false);

         if (factoryType == null)
            return null;

         return (DbProviderFactory)factoryType.GetField("Instance", BindingFlags.Static | BindingFlags.Public).GetValue(null);
      }

      /// <summary>
      /// Creates and returns a <see cref="DbCommand"/> object whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the <paramref name="commandText"/> parameter.
      /// </summary>
      /// <param name="connection">The connection used to create the command.</param>
      /// <param name="commandText">The command text.</param>
      /// <returns>
      /// A new <see cref="DbCommand"/> object whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the <paramref name="commandText"/> parameter.
      /// </returns>
      /// <seealso cref="DbConnection.CreateCommand()"/>
      public static DbCommand CreateCommand(this DbConnection connection, string commandText) {

         if (connection == null) throw new ArgumentNullException("connection");

         DbCommand command = connection.CreateCommand();
         command.CommandText = commandText;

         return command;
      }

      /// <summary>
      /// Creates and returns a <see cref="DbCommand"/> object using the provided <paramref name="commandText"/> as a composite format string 
      /// (as used on <see cref="String.Format(String, Object[])"/>), 
      /// where the format items are replaced with appropiate parameter names, and the objects in the
      /// <paramref name="parameters"/> array are added to the command's <see cref="DbCommand.Parameters"/> collection.
      /// </summary>
      /// <param name="connection">The connection used to create the command.</param>
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
      public static DbCommand CreateCommand(this DbConnection connection, string commandText, params object[] parameters) {
         
         if (connection == null) throw new ArgumentNullException("connection");
         
         return CreateCommandImpl(GetProviderFactory(connection).CreateCommandBuilder(), connection.CreateCommand(), commandText, parameters);
      }

      /// <summary>
      /// Creates and returns a <see cref="DbCommand"/> object whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the <paramref name="commandText"/> parameter.
      /// </summary>
      /// <param name="factory">The provider factory used to create the command.</param>
      /// <param name="commandText">The command text.</param>
      /// <returns>
      /// A new <see cref="DbCommand"/> object whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the <paramref name="commandText"/> parameter.
      /// </returns>
      public static DbCommand CreateCommand(this DbProviderFactory factory, string commandText) {

         if (factory == null) throw new ArgumentNullException("factory");

         DbCommand command = factory.CreateCommand();
         command.CommandText = commandText;

         return command;
      }

      /// <summary>
      /// Creates and returns a <see cref="DbCommand"/> object using the provided <paramref name="commandText"/> as a composite format string 
      /// (as used on <see cref="String.Format(String, Object[])"/>), 
      /// where the format items are replaced with appropiate parameter names, and the objects in the
      /// <paramref name="parameters"/> array are added to the command's <see cref="DbCommand.Parameters"/> collection.
      /// </summary>
      /// <param name="factory">The provider factory used to create the command.</param>
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
      public static DbCommand CreateCommand(this DbProviderFactory factory, string commandText, params object[] parameters) {
         
         if (factory == null) throw new ArgumentNullException("factory");
         
         return CreateCommandImpl(factory.CreateCommandBuilder(), factory.CreateCommand(), commandText, parameters);
      }

      /// <summary>
      /// Creates and returns a <see cref="DbCommand"/> object using the provided <paramref name="commandText"/> as a composite format string 
      /// (as used on <see cref="String.Format(String, Object[])"/>), 
      /// where the format items are replaced with appropiate parameter names, and the objects in the
      /// <paramref name="parameters"/> array are added to the command's <see cref="DbCommand.Parameters"/> collection.
      /// </summary>
      /// <param name="commandBuilder">The command builder used to create the parameter names.</param>
      /// <param name="connection">The connection used to create the command.</param>
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
      public static DbCommand CreateCommand(this DbCommandBuilder commandBuilder, DbConnection connection, string commandText, params object[] parameters) {
         
         if (connection == null) throw new ArgumentNullException("connection");
         
         return CreateCommandImpl(commandBuilder, connection.CreateCommand(), commandText, parameters);
      }

      /// <summary>
      /// Creates and returns a <see cref="DbCommand"/> object using the provided <paramref name="commandText"/> as a composite format string 
      /// (as used on <see cref="String.Format(String, Object[])"/>), 
      /// where the format items are replaced with appropiate parameter names, and the objects in the
      /// <paramref name="parameters"/> array are added to the command's <see cref="DbCommand.Parameters"/> collection.
      /// </summary>
      /// <param name="commandBuilder">The command builder used to create the parameter names.</param>
      /// <param name="factory">The provider factory used to create the command.</param>
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
      public static DbCommand CreateCommand(this DbCommandBuilder commandBuilder, DbProviderFactory factory, string commandText, params object[] parameters) {
         
         if (factory == null) throw new ArgumentNullException("factory");

         return CreateCommandImpl(commandBuilder, factory.CreateCommand(), commandText, parameters);
      }

      static DbCommand CreateCommandImpl(DbCommandBuilder commandBuilder, DbCommand command, string commandText, params object[] parameters) {

         if (commandBuilder == null) throw new ArgumentNullException("commandBuilder");
         if (command == null) throw new ArgumentNullException("command");
         if (commandText == null) throw new ArgumentNullException("commandText");

         if (parameters == null || parameters.Length == 0) {
            command.CommandText = commandText;
            return command;
         }

         object[] paramPlaceholders = new object[parameters.Length];

         for (int i = 0; i < paramPlaceholders.Length; i++) {
            
            object paramValue = parameters[i];

            DbParameter dbParam = command.CreateParameter();
            dbParam.ParameterName = getParameterName(commandBuilder, i);
            dbParam.Value = paramValue ?? DBNull.Value;
            command.Parameters.Add(dbParam);

            paramPlaceholders[i] = getParameterPlaceholder(commandBuilder, i);
         }

         command.CommandText = String.Format(CultureInfo.InvariantCulture, commandText, paramPlaceholders);

         return command;
      }

      /// <summary>
      /// Opens the <paramref name="connection"/> (if it's not open) and returns an <see cref="IDisposable"/> object
      /// you can use to close it (if it wasn't open).
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <returns>An <see cref="IDisposable"/> object to close the connection.</returns>
      /// <remarks>
      /// Use this method with the <c>using</c> statement in C# or Visual Basic to ensure that a block of code
      /// is always executed with an open connection.
      /// </remarks>
      /// <example>
      /// <code>
      /// using (connection.EnsureOpen()) {
      ///   // Execute commands.
      /// }
      /// </code>
      /// </example>
      public static IDisposable EnsureOpen(this IDbConnection connection) {
         return new ConnectionHolder(connection);
      }

      /// <summary>
      /// Executes the <paramref name="command"/> in a new or existing transaction, and
      /// validates the affected records value before comitting.
      /// </summary>
      /// <param name="command">The non-query command to execute.</param>
      /// <param name="affectingRecords">The number of records that the command must affect, otherwise the transaction is rolledback.</param>
      /// <returns>The number of affected records.</returns>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to <paramref name="affectingRecords"/>.</exception>
      public static int Affect(this IDbCommand command, int affectingRecords) {
         return Affect(command, affectingRecords, (TextWriter)null);
      }

      /// <summary>
      /// Executes the <paramref name="command"/> in a new or existing transaction, and
      /// validates the affected records value before comitting.
      /// </summary>
      /// <param name="command">The non-query command to execute.</param>
      /// <param name="affectingRecords">The number of records that the command should affect.</param>
      /// <param name="affectedMode">The criteria for validating the affected records value.</param>
      /// <returns>The number of affected records.</returns>
      /// <exception cref="DBConcurrencyException">The number of affected records is not valid according to the <paramref name="affectingRecords"/> and <paramref name="affectedMode"/> parameters.</exception>
      public static int Affect(this IDbCommand command, int affectingRecords, AffectedRecordsPolicy affectedMode) {
         return Affect(command, affectingRecords, affectedMode, (TextWriter)null);
      }

      /// <summary>
      /// Executes the <paramref name="command"/> in a new or existing transaction, and
      /// validates the affected records value before comitting.
      /// </summary>
      /// <param name="command">The non-query command to execute.</param>
      /// <param name="affectingRecords">The number of records that the command must affect, otherwise the transaction is rolledback.</param>
      /// <param name="logger">A <see cref="TextWriter"/> for logging the whole process.</param>
      /// <returns>The number of affected records.</returns>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to <paramref name="affectingRecords"/>.</exception>      
      public static int Affect(this IDbCommand command, int affectingRecords, TextWriter logger) {
         return Affect(command, affectingRecords, AffectedRecordsPolicy.MustMatchAffecting, logger);
      }
      
      /// <summary>
      /// Executes the <paramref name="command"/> in a new or existing transaction, and
      /// validates the affected records value before comitting.
      /// </summary>
      /// <param name="command">The non-query command to execute.</param>
      /// <param name="affectingRecords">The number of records that the command should affect.</param>
      /// <param name="affectedMode">The criteria for validating the affected records value.</param>
      /// <param name="logger">A <see cref="TextWriter"/> for logging the whole process.</param>
      /// <returns>The number of affected records.</returns>
      /// <exception cref="DBConcurrencyException">The number of affected records is not valid according to the <paramref name="affectingRecords"/> and <paramref name="affectedMode"/> parameters.</exception>
      public static int Affect(this IDbCommand command, int affectingRecords, AffectedRecordsPolicy affectedMode, TextWriter logger) {

         if (command == null) throw new ArgumentNullException("command");
         if (command.Connection == null) throw new ArgumentException("DbCommand.Connection cannot be null", "command");

         if ((int)affectedMode < 0 || (int)affectedMode > 2)
            affectedMode = AffectedRecordsPolicy.MustMatchAffecting;

         logger = logger ?? TextWriter.Null;

         // use TransactionScope if Transaction.Current != null
         // else start ADO.NET transaction if command.Transaction == null

         TransactionScope txScope = (Transaction.Current != null) ? new TransactionScope() : null;
         bool startAdoTx = (txScope == null && command.Transaction == null);
         
         IDisposable connMng = command.Connection.EnsureOpen();

         try {

            if (startAdoTx) {
               command.Transaction = command.Connection.BeginTransaction();
               logger.WriteLine("-- TRANSACTION STARTED");
            }

            int affectedRecords;

            try {

               try {
                  affectedRecords = command.ExecuteNonQuery();
               } catch {
                  logger.WriteLine("-- ERROR: The following command produced an error");
                  logger.WriteLine(command.ToTraceString());

                  throw;
               }

               logger.WriteLine(command.ToTraceString(affectedRecords));

               if (affectedRecords != affectingRecords && affectedMode != AffectedRecordsPolicy.AllowAny) {

                  string errorMessage = null;

                  // already established they don't match
                  if (affectedMode == AffectedRecordsPolicy.MustMatchAffecting) {
                     errorMessage = String.Format(CultureInfo.InvariantCulture, "The number of affected records should be {0}, the actual number is {1}.", affectingRecords, affectedRecords);

                  } else if (affectedMode == AffectedRecordsPolicy.AllowLower && affectedRecords > affectingRecords) {
                     errorMessage = String.Format(CultureInfo.InvariantCulture, "The number of affected records should be {0} or lower, the actual number is {1}.", affectingRecords, affectedRecords);
                  }

                  if (errorMessage != null) 
                     throw new DBConcurrencyException(errorMessage);
               }
            
            } catch {

               if (startAdoTx) {
                  command.Transaction.Rollback();
                  logger.WriteLine("-- TRANSACTION ROLLED BACK");
               }

               throw;
            }

            if (txScope != null) {
               txScope.Complete();

            } else if (startAdoTx) {
               command.Transaction.Commit();
               logger.WriteLine("-- TRANSACTION COMMITED");
            }

            return affectedRecords;

         } finally {
            if (txScope != null)
               txScope.Dispose();

            connMng.Dispose();
         }
      }

      /// <summary>
      /// Executes the <paramref name="command"/> in a new or existing transaction, and
      /// validates that the affected records value is equal to one before comitting.
      /// </summary>
      /// <param name="command">The non-query command to execute.</param>
      /// <returns>The number of affected records.</returns>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to one.</exception>
      public static int AffectOne(this IDbCommand command) {
         return Affect(command, 1);
      }

      /// <summary>
      /// Executes the <paramref name="command"/> in a new or existing transaction, and
      /// validates that the affected records value is equal to one before comitting.
      /// </summary>
      /// <param name="command">The non-query command to execute.</param>
      /// <param name="logger">A <see cref="TextWriter"/> for logging the whole process.</param>
      /// <returns>The number of affected records.</returns>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to one.</exception>
      public static int AffectOne(this IDbCommand command, TextWriter logger) {
         return Affect(command, 1, logger);
      }

      /// <summary>
      /// Executes the <paramref name="command"/> in a new or existing transaction, and
      /// validates that the affected records value is less or equal to one before comitting.
      /// </summary>
      /// <param name="command">The non-query command to execute.</param>
      /// <returns>The number of affected records.</returns>
      /// <exception cref="DBConcurrencyException">The number of affected records is greater than one.</exception>      
      public static int AffectOneOrNone(this IDbCommand command) {
         return Affect(command, 1, AffectedRecordsPolicy.AllowLower);
      }

      /// <summary>
      /// Executes the <paramref name="command"/> in a new or existing transaction, and
      /// validates that the affected records value is less or equal to one before comitting.
      /// </summary>
      /// <param name="command">The non-query command to execute.</param>
      /// <param name="logger">A <see cref="TextWriter"/> for logging the whole process.</param>
      /// <returns>The number of affected records.</returns>
      /// <exception cref="DBConcurrencyException">The number of affected records is greater than one.</exception>      
      public static int AffectOneOrNone(this IDbCommand command, TextWriter logger) {
         return Affect(command, 1, AffectedRecordsPolicy.AllowLower, logger);
      }

      /// <summary>
      /// Maps the results of the <paramref name="command"/> to objects of type
      /// specified by the <paramref name="resultType"/> parameter.
      /// The query is deferred-executed.
      /// </summary>
      /// <param name="command">The query command.</param>
      /// <param name="resultType">The type of objects to map the results to.</param>
      /// <returns>The results of the query as objects of type specified by the <paramref name="resultType"/> parameter.</returns>
      public static IEnumerable<object> Map(this IDbCommand command, Type resultType) {
         return Map(command, resultType, (TextWriter)null);
      }

      /// <summary>
      /// Maps the results of the <paramref name="command"/> to objects of type
      /// specified by the <paramref name="resultType"/> parameter.
      /// The query is deferred-executed.
      /// </summary>
      /// <param name="command">The query command.</param>
      /// <param name="resultType">The type of objects to map the results to.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when the command is executed.</param>
      /// <returns>The results of the query as objects of type specified by the <paramref name="resultType"/> parameter.</returns>
      public static IEnumerable<object> Map(this IDbCommand command, Type resultType, TextWriter logger) {

         var mapper = new PocoMapper(resultType) { 
            Log = logger
         };

         return Map(command, r => mapper.Map(r), logger);
      }

      /// <summary>
      /// Maps the results of the <paramref name="command"/> to <typeparamref name="TResult"/> objects.
      /// The query is deferred-executed.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="command">The query command.</param>
      /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>
      public static IEnumerable<TResult> Map<TResult>(this IDbCommand command) {
         return Map<TResult>(command, (TextWriter)null);
      }

      /// <summary>
      /// Maps the results of the <paramref name="command"/> to <typeparamref name="TResult"/> objects.
      /// The query is deferred-executed.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="command">The query command.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when the command is executed.</param>
      /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>
      public static IEnumerable<TResult> Map<TResult>(this IDbCommand command, TextWriter logger) {

         var mapper = new PocoMapper(typeof(TResult)) { 
            Log = logger
         };

         return Map(command, r => (TResult)mapper.Map(r), logger);
      }

      /// <summary>
      /// Maps the results of the <paramref name="command"/> to <typeparamref name="TResult"/> objects,
      /// using the provided <paramref name="mapper"/> delegate.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="command">The query command.</param>
      /// <param name="mapper">The delegate for creating <typeparamref name="TResult"/> objects from an <see cref="IDataRecord"/> object.</param>
      /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>
      public static IEnumerable<TResult> Map<TResult>(this IDbCommand command, Func<IDataRecord, TResult> mapper) {
         return Map<TResult>(command, mapper, (TextWriter)null);
      }

      /// <summary>
      /// Maps the results of the <paramref name="command"/> to <typeparamref name="TResult"/> objects,
      /// using the provided <paramref name="mapper"/> delegate.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="command">The query command.</param>
      /// <param name="mapper">The delegate for creating <typeparamref name="TResult"/> objects from an <see cref="IDataRecord"/> object.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when the command is executed.</param>
      /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>
      public static IEnumerable<TResult> Map<TResult>(this IDbCommand command, Func<IDataRecord, TResult> mapper, TextWriter logger) {
         return new MappingEnumerable<TResult>(command, mapper, logger);
      }

      /// <summary>
      /// Creates a string representation of <paramref name="command"/> for logging
      /// and debugging purposes.
      /// </summary>
      /// <param name="command">The command.</param>
      /// <returns>The string representation of <paramref name="command"/>.</returns>
      public static string ToTraceString(this IDbCommand command) {

         if (command == null) throw new ArgumentNullException("command");

         StringBuilder sb = new StringBuilder(command.CommandText);

         for (int i = 0; i < command.Parameters.Count; i++) {

            IDbDataParameter param = command.Parameters[i] as IDbDataParameter;

            if (param != null) {
               sb.AppendLine()
                  .AppendFormat(CultureInfo.InvariantCulture, "-- {0}: {1} {2} (Size = {3}) [{4}]", param.ParameterName, param.Direction, param.DbType, param.Size, param.Value);
            }
         }

         return sb.ToString();
      }

      /// <summary>
      /// Creates a string representation of <paramref name="command"/> for logging
      /// and debugging purposes.
      /// </summary>
      /// <param name="command">The command.</param>
      /// <param name="affectedRecords">The number of affected records that the command returned.</param>
      /// <returns>The string representation of <paramref name="command"/>.</returns>
      public static string ToTraceString(this IDbCommand command, int affectedRecords) {
         return String.Concat(ToTraceString(command), Environment.NewLine, "-- [", affectedRecords, "] records affected.");
      }

      #region IDataRecord

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Boolean"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Boolean GetBoolean(this IDataRecord record, string name) {
         return record.GetBoolean(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Byte"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Byte GetByte(this IDataRecord record, string name) {
         return record.GetByte(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Char"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Char GetChar(this IDataRecord record, string name) {
         return record.GetChar(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="DateTime"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static DateTime GetDateTime(this IDataRecord record, string name) {
         return record.GetDateTime(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Decimal"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Decimal GetDecimal(this IDataRecord record, string name) {
         return record.GetDecimal(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Double"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Double GetDouble(this IDataRecord record, string name) {
         return record.GetDouble(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Single"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Single GetFloat(this IDataRecord record, string name) {
         return record.GetFloat(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as an <see cref="Int16"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Int16 GetInt16(this IDataRecord record, string name) {
         return record.GetInt16(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as an <see cref="Int32"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Int32 GetInt32(this IDataRecord record, string name) {
         return record.GetInt32(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as an <see cref="Int64"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Int64 GetInt64(this IDataRecord record, string name) {
         return record.GetInt64(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="String"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static String GetString(this IDataRecord record, string name) {
         return record.GetString(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Object GetValue(this IDataRecord record, string name) {
         return record.GetValue(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Boolean&gt;"/> of <see cref="Boolean"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Boolean? GetNullableBoolean(this IDataRecord record, string name) {
         return GetNullableBoolean(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Boolean&gt;"/> of <see cref="Boolean"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Boolean? GetNullableBoolean(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Boolean?) : record.GetBoolean(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Byte&gt;"/> of <see cref="Byte"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Byte? GetNullableByte(this IDataRecord record, string name) {
         return GetNullableByte(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Byte&gt;"/> of <see cref="Byte"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Byte? GetNullableByte(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Byte?) : record.GetByte(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Char&gt;"/> of <see cref="Char"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Char? GetNullableChar(this IDataRecord record, string name) {
         return GetNullableChar(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Char&gt;"/> of <see cref="Char"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Char? GetNullableChar(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Char?) : record.GetChar(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;DateTime&gt;"/> of <see cref="DateTime"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static DateTime? GetNullableDateTime(this IDataRecord record, string name) {
         return GetNullableDateTime(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;DateTime&gt;"/> of <see cref="DateTime"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static DateTime? GetNullableDateTime(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(DateTime?) : record.GetDateTime(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Decimal&gt;"/> of <see cref="Decimal"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Decimal? GetNullableDecimal(this IDataRecord record, string name) {
         return GetNullableDecimal(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Decimal&gt;"/> of <see cref="Decimal"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Decimal? GetNullableDecimal(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Decimal?) : record.GetDecimal(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Double&gt;"/> of <see cref="Double"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Double? GetNullableDouble(this IDataRecord record, string name) {
         return GetNullableDouble(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Double&gt;"/> of <see cref="Double"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Double? GetNullableDouble(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Double?) : record.GetDouble(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Single&gt;"/> of <see cref="Single"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Single? GetNullableFloat(this IDataRecord record, string name) {
         return GetNullableFloat(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Single&gt;"/> of <see cref="Single"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Single? GetNullableFloat(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Single?) : record.GetFloat(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Guid&gt;"/> of <see cref="Guid"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Guid? GetNullableGuid(this IDataRecord record, string name) {
         return GetNullableGuid(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Guid&gt;"/> of <see cref="Guid"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Guid? GetNullableGuid(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Guid?) : record.GetGuid(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Int16&gt;"/> of <see cref="Int16"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Int16? GetNullableInt16(this IDataRecord record, string name) {
         return GetNullableInt16(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Int16&gt;"/> of <see cref="Int16"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Int16? GetNullableInt16(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Int16?) : record.GetInt16(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Int32&gt;"/> of <see cref="Int32"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Int32? GetNullableInt32(this IDataRecord record, string name) {
         return GetNullableInt32(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Int32&gt;"/> of <see cref="Int32"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Int32? GetNullableInt32(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Int32?) : record.GetInt32(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Int64&gt;"/> of <see cref="Int64"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Int64? GetNullableInt64(this IDataRecord record, string name) {
         return GetNullableInt64(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Int64&gt;"/> of <see cref="Int64"/>.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Int64? GetNullableInt64(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Int64?) : record.GetInt64(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="String"/>, or null (Nothing in Visual Basic).
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static String GetStringOrNull(this IDataRecord record, string name) {
         return GetStringOrNull(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="String"/>, or null (Nothing in Visual Basic).
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static String GetStringOrNull(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(String) : record.GetString(i);
      }

      /// <summary>
      /// Gets the value of the specified column as an <see cref="Object"/>, or null (Nothing in Visual Basic).
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>
      public static Object GetValueOrNull(this IDataRecord record, string name) {
         return GetValueOrNull(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as an <see cref="Object"/>, or null (Nothing in Visual Basic).
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Object GetValueOrNull(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? null : record.GetValue(i);
      }

      #endregion

      #region Nested Types

      class ConnectionHolder : IDisposable {

         readonly IDbConnection conn;
         readonly bool prevStateWasClosed;

         public ConnectionHolder(IDbConnection conn) {

            if (conn == null) throw new ArgumentNullException("conn");

            this.conn = conn;
            this.prevStateWasClosed = (conn.State == ConnectionState.Closed);

            if (this.prevStateWasClosed)
               this.conn.Open();
         }

         public void Dispose() {

            if (conn != null && prevStateWasClosed && conn.State != ConnectionState.Closed)
               conn.Close();
         }
      }

      #endregion
   }

   public partial class Database {

      static readonly Regex namedConnectionStringPattern = new Regex(@"^name=([^;].+);?$", RegexOptions.IgnoreCase);
      static readonly IDictionary<string, DbProviderFactory> factories = new Dictionary<string, DbProviderFactory>();
      static readonly object padlock = new object();

      const string DbExtensions_DefaultConnectionName = "DbExtensions:DefaultConnectionName";
      const string DbExtensions_DefaultProviderName = "DbExtensions:DefaultProviderName";

      /// <summary>
      /// Locates a <see cref="DbProviderFactory"/> using <see cref="DbProviderFactories.GetFactory(string)"/>
      /// and caches the result.
      /// </summary>
      /// <param name="providerInvariantName">The provider invariant name.</param>
      /// <returns>The requested provider factory.</returns>
      public static DbProviderFactory GetProviderFactory(string providerInvariantName) {

         if (providerInvariantName == null) throw new ArgumentNullException("providerInvariantName");

         DbProviderFactory factory;

         if (!factories.TryGetValue(providerInvariantName, out factory)) {
            lock (padlock) {
               if (!factories.TryGetValue(providerInvariantName, out factory)) {

                  factory = DbProviderFactories.GetFactory(providerInvariantName);
                  factories[providerInvariantName] = factory;
               }
            }
         }

         return factory;
      }

      /// <summary>
      /// Creates a connection using the default connection name specified by the 
      /// "DbExtensions:DefaultConnectionName" key in the appSettings configuration section, 
      /// which is used to locate a connection string in the connectionStrings configuration section.
      /// </summary>
      /// <returns>The requested connection.</returns>
      public static DbConnection CreateConnection() {

         string providerName;

         return CreateConnection(out providerName);
      }

      static DbConnection CreateConnection(out string providerName) {

         string defaultConnection = ConfigurationManager.AppSettings[DbExtensions_DefaultConnectionName];

         if (defaultConnection == null) {
            throw new InvalidOperationException(
               String.Format(CultureInfo.InvariantCulture, "A default connection name must be provided using the '{0}' key in the appSettings configuration section.", DbExtensions_DefaultConnectionName)
            );
         }

         return CreateNamedConnection(defaultConnection, out providerName);
      }

      /// <summary>
      /// Creates a connection using the provided connection string. If the connection
      /// string is a named connection string (e.g. "name=Northwind"), then the name is used to
      /// locate the connection string in the connectionStrings configuration section, else the 
      /// default provider is used to create the connection (specified by the "DbExtensions:DefaultProviderName"
      /// key in the appSettings configuration section).
      /// </summary>
      /// <param name="connectionString">The connection string.</param>
      /// <returns>The requested connection.</returns>
      public static DbConnection CreateConnection(string connectionString) {

         string providerName;

         return CreateConnection(connectionString, out providerName);
      }

      static DbConnection CreateConnection(string connectionString, out string providerName) {

         if (connectionString == null) throw new ArgumentNullException("connectionString");

         Match namedMatch = namedConnectionStringPattern.Match(connectionString.Trim());

         if (namedMatch.Success) {

            string name = namedMatch.Groups[1].Value;

            return CreateNamedConnection(name, out providerName);
         } 

         providerName = ConfigurationManager.AppSettings[DbExtensions_DefaultProviderName];

         if (providerName == null) {
            throw new InvalidOperationException(
               String.Format(CultureInfo.InvariantCulture, "A default provider name must be provided using the '{0}' key in the appSettings configuration section.", DbExtensions_DefaultProviderName)
            );
         }

         DbProviderFactory factory = GetProviderFactory(providerName);
         DbConnection connection = factory.CreateConnection(connectionString);

         return connection;
      }

      static DbConnection CreateNamedConnection(string name, out string providerName) {

         ConnectionStringSettings connStringSettings = ConfigurationManager.ConnectionStrings[name];

         if (connStringSettings == null) {
            throw new ArgumentException(
               String.Format(CultureInfo.InvariantCulture, "Couldn't find '{0}' in System.Configuration.ConfigurationManager.ConnectionStrings.", name)
            , "name");
         }

         providerName = connStringSettings.ProviderName;

         DbProviderFactory factory = GetProviderFactory(providerName);
         DbConnection connection = factory.CreateConnection(connStringSettings.ConnectionString);

         return connection;
      }
   }

   /// <summary>
   /// Indicates how to validate the affected records value returned by a 
   /// non-query command.
   /// </summary>
   public enum AffectedRecordsPolicy { 
      /// <summary>
      /// The affected records value must be equal as the affecting records value.
      /// </summary>
      MustMatchAffecting = 0,
      /// <summary>
      /// The affected records value must be equal or lower than the affecting records value.
      /// </summary>
      AllowLower = 1,
      /// <summary>
      /// The affected records value is ignored.
      /// </summary>
      AllowAny = 2
   }
}

namespace DbExtensions {

   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Data;
   using System.IO;

   class MappingEnumerable<TResult> : IEnumerable<TResult>, IEnumerable, IDisposable {

      IEnumerator<TResult> enumerator;

      public MappingEnumerable(IDbCommand command, Func<IDataRecord, TResult> mapper)
         : this(command, mapper, null) { }

      public MappingEnumerable(IDbCommand command, Func<IDataRecord, TResult> mapper, TextWriter logger) {
         this.enumerator = new MappingEnumerable<TResult>.Enumerator(command, mapper, logger);
      }

      public IEnumerator<TResult> GetEnumerator() {

         IEnumerator<TResult> e = enumerator;

         if (e == null)
            throw new InvalidOperationException("Cannot enumerate more than once.");

         enumerator = null;

         return e;
      }

      IEnumerator IEnumerable.GetEnumerator() {
         return GetEnumerator();
      }

      public void Dispose() {
         
         if (enumerator != null)
            enumerator.Dispose();
      }

      #region Nested Types

      class Enumerator : IEnumerator<TResult>, IEnumerator, IDisposable {

         readonly IDbCommand command;
         readonly Func<IDataRecord, TResult> mapper;
         readonly TextWriter logger;
         readonly bool prevStateWasClosed;
         
         IDataReader reader;
         TResult current;

         public Enumerator(IDbCommand command, Func<IDataRecord, TResult> mapper, TextWriter logger) {

            if (command == null) throw new ArgumentNullException("command");
            if (mapper == null) throw new ArgumentNullException("mapper");

            IDbConnection conn = command.Connection;

            if (conn == null)
               throw new ArgumentException("command.Connection cannot be null", "command");

            prevStateWasClosed = (conn.State == ConnectionState.Closed);

            this.command = command;
            this.mapper = mapper;
            this.logger = logger;
         }

         public TResult Current { get { return current; } }

         object IEnumerator.Current { get { return current; } }

         public bool MoveNext() {

            if (reader == null) {

               if (prevStateWasClosed)
                  command.Connection.Open();

               try {
                  reader = command.ExecuteReader();
                  
                  if (logger != null) 
                     logger.WriteLine(command.ToTraceString(reader.RecordsAffected));
               
               } catch {

                  try {
                     if (logger != null) {
                        logger.WriteLine("-- ERROR: The following command produced an error");
                        logger.WriteLine(command.ToTraceString());
                     }

                  } finally {
                     if (prevStateWasClosed) 
                        EnsureConnectionClosed();
                  }

                  throw;
               }
            }

            if (reader.Read()) {
               
               try {
                  current = mapper(reader);

               } catch {
                  if (prevStateWasClosed) 
                     EnsureConnectionClosed();
                  
                  throw;
               }

               return true;
            }

            if (prevStateWasClosed) 
               EnsureConnectionClosed();

            return false;
         }

         public void Reset() {
            throw new NotSupportedException();
         }

         public void Dispose() {
            
            if (reader != null) 
               reader.Dispose();

            if (prevStateWasClosed)
               EnsureConnectionClosed();
         }

         void EnsureConnectionClosed() {

            IDbConnection conn = command.Connection;

            if (conn.State != ConnectionState.Closed)
               conn.Close();
         }
      }

      #endregion
   }
}

namespace DbExtensions {

   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Data;
   using System.Globalization;
   using System.IO;
   using System.Linq;
   using System.Reflection;
   using System.Text;

   abstract class Mapper {

      Node rootNode;
      IDictionary<CollectionNode, CollectionLoader> manyLoaders;

      public TextWriter Log { get; set; }

      public HashSet<int> IgnoredColumns { get; set; }

      public IDictionary<string[], CollectionLoader> ManyIncludes { get; set; }

      public bool SingleResult { get; set; }

      protected Mapper() { }

      void ReadMapping(IDataRecord record, Node rootNode) {

         MapGroup[] groups =
            (from i in Enumerable.Range(0, record.FieldCount)
             where this.IgnoredColumns == null
               || !this.IgnoredColumns.Contains(i)
             let columnName = record.GetName(i)
             let path = columnName.Split('$')
             let property = (path.Length == 1) ? columnName : path[path.Length - 1]
             let assoc = (path.Length == 1) ? "" : path[path.Length - 2]
             let parent = (path.Length <= 2) ? "" : path[path.Length - 3]
             let propertyInfo = new { ColumnOrdinal = i, PropertyName = property }
             group propertyInfo by new { depth = path.Length - 1, parent, assoc } into t
             orderby t.Key.depth, t.Key.parent, t.Key.assoc
             select new MapGroup {
                Depth = t.Key.depth,
                Name = t.Key.assoc,
                Parent = t.Key.parent,
                Properties = t.ToDictionary(p => p.ColumnOrdinal, p => p.PropertyName)
             }
            ).ToArray();

         MapGroup topGroup = groups.Where(m => m.Depth == 0).SingleOrDefault()
            ?? new MapGroup { Name = "", Parent = "", Properties = new Dictionary<int, string>() };

         ReadMapping(record, groups, topGroup, rootNode);
      }

      void ReadMapping(IDataRecord record, MapGroup[] groups, MapGroup currentGroup, Node instance) {

         var constructorParameters = new Dictionary<MapParam, Node>();

         foreach (var pair in currentGroup.Properties) {

            Node property = CreateSimpleProperty(instance, pair.Value, pair.Key);

            if (property != null) {
               property.Container = instance;
               instance.Properties.Add(property);
               continue;
            }

            uint valueAsNumber;

            if (UInt32.TryParse(pair.Value, out valueAsNumber)) {
               constructorParameters.Add(new MapParam(valueAsNumber, pair.Key), null);

            } else {

               if (this.Log != null) {
                  this.Log.WriteLine("-- WARNING: Couldn't find property '{0}' on type '{1}'. Ignoring column.", pair.Value, instance.TypeName);
               }
            }
         }

         MapGroup[] nextLevels =
            (from m in groups
             where m.Depth == currentGroup.Depth + 1 && m.Parent == currentGroup.Name
             select m).ToArray();

         for (int i = 0; i < nextLevels.Length; i++) {

            MapGroup nextLevel = nextLevels[i];
            Node property = CreateComplexProperty(instance, nextLevel.Name);

            if (property != null) {

               property.Container = instance;
               
               ReadMapping(record, groups, nextLevel, property);

               instance.Properties.Add(property);
               continue;
            }

            uint valueAsNumber;

            if (UInt32.TryParse(nextLevel.Name, out valueAsNumber)) {
               constructorParameters.Add(new MapParam(valueAsNumber, nextLevel), null);

            } else {

               if (this.Log != null) {
                  this.Log.WriteLine("-- WARNING: Couldn't find property '{0}' on type '{1}'. Ignoring column(s).", nextLevel.Name, instance.TypeName);
               }
            }
         }

         if (constructorParameters.Count > 0) {

            instance.Constructor = GetConstructor(instance, constructorParameters.Count);
            ParameterInfo[] parameters = instance.Constructor.GetParameters();

            int i = 0;

            foreach (var pair in constructorParameters.OrderBy(p => p.Key.ParameterIndex)) {

               ParameterInfo param = parameters[i];
               Node paramNode;

               if (pair.Key.ColumnOrdinal.HasValue) {
                  paramNode = CreateParameterNode(pair.Key.ColumnOrdinal.Value, param);

               } else {

                  paramNode = CreateParameterNode(param);
                  ReadMapping(record, groups, pair.Key.Group, paramNode);
               }

               if (instance.ConstructorParameters.ContainsKey(pair.Key.ParameterIndex)) {

                  var message = new StringBuilder();
                  message.AppendFormat(CultureInfo.InvariantCulture, "Already specified an argument for parameter '{0}'", param.Name);

                  if (pair.Key.ColumnOrdinal.HasValue)
                     message.AppendFormat(CultureInfo.InvariantCulture, " ('{0}')", record.GetName(pair.Key.ColumnOrdinal.Value));

                  message.Append(".");

                  throw new InvalidOperationException(message.ToString());
               }

               instance.ConstructorParameters.Add(pair.Key.ParameterIndex, paramNode);

               i++;
            }
         }

         if (instance.IsComplex
            && this.ManyIncludes != null) {

            var includes = this.ManyIncludes
               .Where(p => p.Key.Length == currentGroup.Depth + 1)
               .Where(p => {

                  if (instance.Container == null) {
                     // root node
                     return true;
                  }

                  string[] reversedBasePath = p.Key.Take(p.Key.Length - 1).Reverse().ToArray();

                  Node container = instance;

                  for (int i = 0; i < reversedBasePath.Length; i++) {

                     if (container.PropertyName != reversedBasePath[i]) {
                        return false;
                     }

                     container = container.Container;
                  }

                  return true;
               })
               .ToArray();

            for (int i = 0; i < includes.Length; i++) {

               var pair = includes[i];

               string name = pair.Key[pair.Key.Length - 1];
               
               CollectionNode collection = CreateCollectionNode(instance, name);

               if (collection != null) {

                  instance.Collections.Add(collection);

                  if (this.manyLoaders == null) {
                     this.manyLoaders = new Dictionary<CollectionNode, CollectionLoader>();
                  }

                  this.manyLoaders.Add(collection, pair.Value);
               }
            }
         }
      }

      public object Map(IDataRecord record) {

         Node node = GetRootNode(record);

         MappingContext context = CreateMappingContext();

         object instance = node.Create(record, context);

         node.Load(ref instance, record, context);

         return instance;
      }

      public void Load(ref object instance, IDataRecord record) {

         Node node = GetRootNode(record);

         node.Load(ref instance, record, CreateMappingContext());
      }

      Node GetRootNode(IDataRecord record) {

         if (this.rootNode == null) {
            this.rootNode = CreateRootNode();
            ReadMapping(record, this.rootNode);
         }

         return this.rootNode;
      }

      MappingContext CreateMappingContext() {

         return new MappingContext { 
            Log = this.Log,
            ManyLoaders = this.manyLoaders,
            SingleResult = this.SingleResult
         };
      }

      protected abstract Node CreateRootNode();

      protected abstract Node CreateSimpleProperty(Node container, string propertyName, int columnOrdinal);

      protected abstract Node CreateComplexProperty(Node container, string propertyName);

      protected abstract Node CreateParameterNode(ParameterInfo paramInfo);

      protected abstract Node CreateParameterNode(int columnOrdinal, ParameterInfo paramInfo);

      protected abstract CollectionNode CreateCollectionNode(Node container, string propertyName);

      static ConstructorInfo GetConstructor(Node node, int parameterLength) {

         ConstructorInfo[] constructors = node
            .GetConstructors(BindingFlags.Public | BindingFlags.Instance)
            .Where(c => c.GetParameters().Length == parameterLength)
            .ToArray();

         if (constructors.Length == 0) {
            throw new InvalidOperationException(
               String.Format(CultureInfo.InvariantCulture,
                  "Couldn't find a public constructor with {0} parameter(s) for type '{1}'.",
                  parameterLength,
                  node.TypeName
               )
            );
         }

         if (constructors.Length > 1) {
            throw new InvalidOperationException(
               String.Format(CultureInfo.InvariantCulture,
                  "Found more than one public constructors with {0} parameter(s) for type '{1}'. Please use another constructor.",
                  parameterLength,
                  node.TypeName
               )
            );
         }

         return constructors[0];
      }

      #region Nested Types

      class MapGroup {

         public string Name;
         public int Depth;
         public string Parent;
         public Dictionary<int, string> Properties;
      }

      class MapParam {

         public readonly uint ParameterIndex;
         public readonly int? ColumnOrdinal;
         public readonly MapGroup Group;

         public MapParam(uint parameterIndex, int columnOrdinal) {

            this.ParameterIndex = parameterIndex;
            this.ColumnOrdinal = columnOrdinal;
         }

         public MapParam(uint parameterIndex, MapGroup group) {

            this.ParameterIndex = parameterIndex;
            this.Group = group;
         }
      }

      #endregion
   }

   abstract class Node {

      Dictionary<uint, Node> _ConstructorParameters;
      List<Node> _Properties;
      List<CollectionNode> _Collections;

      public abstract bool IsComplex { get; }
      public abstract string PropertyName { get; }
      public abstract int ColumnOrdinal { get; }
      public abstract string TypeName { get; }

      public Node Container { get; internal set; }
      public ConstructorInfo Constructor { get; internal set; }

      public Dictionary<uint, Node> ConstructorParameters {
         get {
            return _ConstructorParameters
               ?? (_ConstructorParameters = new Dictionary<uint, Node>());
         }
      }

      public List<Node> Properties { 
         get {
            return _Properties
               ?? (_Properties = new List<Node>());
         } 
      }

      public List<CollectionNode> Collections {
         get {
            return _Collections
               ?? (_Collections = new List<CollectionNode>());
         }
      }

      public bool HasConstructorParameters {
         get {
            return _ConstructorParameters != null
               && _ConstructorParameters.Count > 0;
         }
      }

      public bool HasProperties {
         get {
            return _Properties != null
               && _Properties.Count > 0;
         }
      }

      public bool HasCollections {
         get {
            return _Collections != null
               && _Collections.Count > 0;
         }
      }

      public object Map(IDataRecord record, MappingContext context) {

         if (this.IsComplex)
            return MapComplex(record, context);

         return MapSimple(record, context);
      }

      protected virtual object MapComplex(IDataRecord record, MappingContext context) {

         if (AllColumnsNull(record))
            return null;

         object value = Create(record, context);
         Load(ref value, record, context);

         return value;
      }

      bool AllColumnsNull(IDataRecord record) {

         if (this.IsComplex) {

            return (!this.HasConstructorParameters
                  || this.ConstructorParameters
                     .OrderBy(n => n.Value.IsComplex)
                     .All(n => n.Value.AllColumnsNull(record)))
               && this.Properties
                  .OrderBy(n => n.IsComplex)
                  .All(n => n.AllColumnsNull(record));
         }

         return record.IsDBNull(this.ColumnOrdinal);
      }

      protected virtual object MapSimple(IDataRecord record, MappingContext context) {

         bool isNull = record.IsDBNull(this.ColumnOrdinal);
         object value = isNull ? null : record.GetValue(this.ColumnOrdinal);

         return value;
      }

      public abstract object Create(IDataRecord record, MappingContext context);

      public void Load(ref object instance, IDataRecord record, MappingContext context) {

         for (int i = 0; i < this.Properties.Count; i++) {

            Node childNode = this.Properties[i];

            if (!childNode.IsComplex
               || childNode.HasConstructorParameters) {

               childNode.Read(ref instance, record, context);
               continue;
            }

            object currentValue = childNode.Get(ref instance);

            if (currentValue != null) {
               childNode.Load(ref currentValue, record, context);
            } else {
               childNode.Read(ref instance, record, context);
            }
         }

         if (this.HasCollections) {

            if (context.SingleResult) {
               // if the query is expected to return a single result at most
               // we close the data reader to allow for collections to be loaded
               // using the same connection (for providers that do not support MARS)

               IDataReader reader = record as IDataReader;

               if (reader != null) {
                  reader.Close();
               }
            }

            for (int i = 0; i < this.Collections.Count; i++) {

               CollectionNode collectionNode = this.Collections[i];
               collectionNode.Load(ref instance, context);
            }
         }
      }

      void Read(ref object instance, IDataRecord record, MappingContext context) {

         object value = Map(record, context);
         Set(ref instance, value, context);
      }

      protected abstract object Get(ref object instance);

      protected abstract void Set(ref object instance, object value, MappingContext context);

      public abstract ConstructorInfo[] GetConstructors(BindingFlags bindingAttr);
   }

   abstract class CollectionNode {

      public void Load(ref object instance, MappingContext context) {

         IEnumerable collection = GetOrCreate(ref instance, context);
         CollectionLoader loader = context.ManyLoaders[this];

         IEnumerable elements = loader.Load(instance, loader.State);

         foreach (object element in elements) {
            Add(collection, element, context);
         }
      }

      protected abstract IEnumerable GetOrCreate(ref object instance, MappingContext context);

      protected abstract void Add(IEnumerable collection, object element, MappingContext context);
   }

   class MappingContext {

      public TextWriter Log;
      public IDictionary<CollectionNode, CollectionLoader> ManyLoaders;
      public bool SingleResult;
   }

   class CollectionLoader {

      public Func<object, object, IEnumerable> Load;
      public object State;
   }
}

namespace DbExtensions {

   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Collections.ObjectModel;
   using System.Data;
   using System.Globalization;
   using System.Linq;
   using System.Reflection;

   class PocoMapper : Mapper {

      readonly Type type;

      public PocoMapper(Type type) {

         if (type == null) throw new ArgumentNullException("type");

         this.type = type;
      }

      protected override Node CreateRootNode() {
         return PocoNode.Root(this.type);
      }

      protected override Node CreateSimpleProperty(Node container, string propertyName, int columnOrdinal) {

         PropertyInfo property = GetProperty(((PocoNode)container).UnderlyingType, propertyName);

         if (property == null)
            return null;

         return PocoNode.Simple(columnOrdinal, property);
      }

      protected override Node CreateComplexProperty(Node container, string propertyName) {

         PropertyInfo property = GetProperty(((PocoNode)container).UnderlyingType, propertyName);

         if (property == null)
            return null;

         return PocoNode.Complex(property);
      }

      protected override Node CreateParameterNode(int columnOrdinal, ParameterInfo paramInfo) {
         return PocoNode.Simple(columnOrdinal, paramInfo);
      }

      protected override Node CreateParameterNode(ParameterInfo paramInfo) {
         return PocoNode.Root(paramInfo);
      }

      protected override CollectionNode CreateCollectionNode(Node container, string propertyName) {

         Type declaringType = ((PocoNode)container).UnderlyingType;

         PropertyInfo property = declaringType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

         if (property == null) {
            return null;
         }

         if (!typeof(IEnumerable).IsAssignableFrom(property.PropertyType)) {
            return null;
         }

         return new PocoCollection(property);
      }

      static PropertyInfo GetProperty(Type declaringType, string propertyName) {

         PropertyInfo property = declaringType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

         if (property == null)
            return property;

         if (!property.CanWrite) {

            throw new InvalidOperationException(
               String.Format(CultureInfo.InvariantCulture,
                  "'{0}' property '{1}' doesn't have a setter.",
                  property.ReflectedType.FullName, property.Name
               )
            );
         }

         return property;
      }
   }

   class PocoNode : Node {

      readonly Type Type;
      public readonly Type UnderlyingType;

      readonly PropertyInfo Property;
      readonly MethodInfo Setter;

      bool _IsComplex;
      int _ColumnOrdinal;

      public Func<PocoNode, object, object> ConvertFunction;
      public ParameterInfo Parameter;

      public override bool IsComplex {
         get { return _IsComplex; }
      }

      public override string PropertyName {
         get {
            if (this.Property == null) {
               return null;
            }

            return this.Property.Name;
         }
      }

      public override int ColumnOrdinal {
         get { return _ColumnOrdinal; }
      }

      public override string TypeName {
         get { return UnderlyingType.FullName; }
      }

      public static PocoNode Root(Type type) {

         var node = new PocoNode(type) {
            _IsComplex = true,
         };

         return node;
      }

      public static PocoNode Root(ParameterInfo parameter) {

         var node = Root(parameter.ParameterType);
         node.Parameter = parameter;

         return node;
      }

      public static PocoNode Complex(PropertyInfo property) {

         var node = new PocoNode(property) {
            _IsComplex = true,
         };

         return node;
      }

      public static PocoNode Simple(int columnOrdinal, PropertyInfo property) {

         var node = new PocoNode(property) {
            _ColumnOrdinal = columnOrdinal
         };

         return node;
      }

      public static PocoNode Simple(int columnOrdinal, ParameterInfo parameter) {

         var node = new PocoNode(parameter.ParameterType) {
            _ColumnOrdinal = columnOrdinal,
            Parameter = parameter
         };

         return node;
      }

      private PocoNode(Type type) {

         this.Type = type;

         bool isNullableValueType = type.IsGenericType
            && type.GetGenericTypeDefinition() == typeof(Nullable<>);

         this.UnderlyingType = (isNullableValueType) ?
            Nullable.GetUnderlyingType(type)
            : type;
      }

      private PocoNode(PropertyInfo property)
         : this(property.PropertyType) {

         this.Property = property;
         this.Setter = property.GetSetMethod(true);
      }

      public override object Create(IDataRecord record, MappingContext context) {

         if (this.Constructor == null)
            return Activator.CreateInstance(this.Type);

         object[] args = this.ConstructorParameters.Select(m => m.Value.Map(record, context)).ToArray();

         if (this.ConstructorParameters.Any(p => ((PocoNode)p.Value).ConvertFunction != null)
            || args.All(v => v == null)) {

            return this.Constructor.Invoke(args);
         }

         try {
            return this.Constructor.Invoke(args);

         } catch (ArgumentException) {

            bool convertSet = false;

            for (int i = 0; i < this.ConstructorParameters.Count; i++) {

               object value = args[i];

               if (value == null) continue;

               PocoNode paramNode = (PocoNode)this.ConstructorParameters.ElementAt(i).Value;

               if (!paramNode.Type.IsAssignableFrom(value.GetType())) {

                  Func<PocoNode, object, object> convert = GetConversionFunction(value, paramNode);

                  if (context.Log != null) {

                     context.Log.WriteLine("-- WARNING: Couldn't instantiate {0} with argument '{1}' of type {2} {3}. Attempting conversion.",
                        this.UnderlyingType.FullName,
                        paramNode.Parameter.Name, paramNode.Type.FullName,
                        (value == null) ? "to null" : "with value of type " + value.GetType().FullName
                     );
                  }

                  paramNode.ConvertFunction = convert;

                  convertSet = true;
               }
            }

            if (convertSet)
               return Create(record, context);

            throw;
         }
      }

      protected override object MapSimple(IDataRecord record, MappingContext context) {

         object value = base.MapSimple(record, context);

         Func<PocoNode, object, object> convertFn;

         if (value != null
            && (convertFn = this.ConvertFunction) != null) {

            value = convertFn(this, value);
         }

         return value;
      }

      protected override object Get(ref object instance) {
         return GetProperty(ref instance);
      }

      protected override void Set(ref object instance, object value, MappingContext context) {

         if (this.IsComplex) {
            SetProperty(ref instance, value);

         } else {

            try {
               SetSimple(ref instance, value, context);

            } catch (Exception ex) {

               throw new InvalidCastException(
                  String.Format(CultureInfo.InvariantCulture,
                     "Couldn't set '{0}' property '{1}' of type '{2}' {3}.",
                     this.Property.ReflectedType.FullName, this.Property.Name, this.Type.FullName, (value == null) ? "to null" : "with value of type '" + value.GetType().FullName + "'"
                  )
               , ex);
            }
         }
      }

      void SetSimple(ref object instance, object value, MappingContext context) {

         if (this.ConvertFunction != null || value == null) {
            SetProperty(ref instance, value);
            return;
         }

         try {
            SetProperty(ref instance, value);

         } catch (ArgumentException) {

            Func<PocoNode, object, object> convert = GetConversionFunction(value, this);

            if (context.Log != null) {

               context.Log.WriteLine("-- WARNING: Couldn't set '{0}' property '{1}' of type '{2}' {3}. Attempting conversion.",
                  this.Property.ReflectedType.FullName,
                  this.Property.Name, this.Property.PropertyType.FullName,
                  (value == null) ? "to null" : "with value of type '" + value.GetType().FullName + "'"
               );
            }

            value = convert(this, value);

            this.ConvertFunction = convert;

            SetSimple(ref instance, value, context);
         }
      }

      object GetProperty(ref object instance) {
         return this.Property.GetValue(instance, null);
      }

      void SetProperty(ref object instance, object value) {
         this.Setter.Invoke(instance, new object[1] { value });
      }

      public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr) {
         return UnderlyingType.GetConstructors(bindingAttr);
      }

      static Func<PocoNode, object, object> GetConversionFunction(object value, PocoNode node) {

         if (node.UnderlyingType == typeof(bool)) {

            if (value.GetType() == typeof(string)) {
               return ConvertToBoolean;
            }

         } else if (node.UnderlyingType.IsEnum) {

            if (value.GetType() == typeof(string)) {
               return ParseEnum;
            }

            return CastToEnum;
         }

         return ConvertTo;
      }

      static object ConvertToBoolean(PocoNode node, object value) {
         return Convert.ToBoolean(Convert.ToInt64(value, CultureInfo.InvariantCulture));
      }

      static object CastToEnum(PocoNode node, object value) {
         return Enum.ToObject(node.UnderlyingType, value);
      }

      static object ParseEnum(PocoNode node, object value) {
         return Enum.Parse(node.UnderlyingType, Convert.ToString(value, CultureInfo.InvariantCulture));
      }

      static object ConvertTo(PocoNode node, object value) {
         return Convert.ChangeType(value, node.UnderlyingType, CultureInfo.InvariantCulture);
      }
   }

   class PocoCollection : CollectionNode {

      readonly PropertyInfo property;
      readonly Type elementType;
      readonly MethodInfo addMethod;

      public PocoCollection(PropertyInfo property) {

         this.property = property;

         Type colType = this.property.PropertyType;
         this.elementType = typeof(object);

         for (Type type = colType; type != null; type = type.BaseType) {

            Type[] interfaces = type.GetInterfaces();

            Type genericICol = type.GetInterfaces()
               .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>));

            if (genericICol != null) {
               this.elementType = genericICol.GetGenericArguments()[0];
               break;
            }
         }

         this.addMethod = colType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public, null, new[] { this.elementType }, null);

         if (this.addMethod == null) {
            throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, "Couldn't find a public 'Add' method on '{0}'.", colType.FullName));
         }
      }

      protected override IEnumerable GetOrCreate(ref object instance, MappingContext context) {

         object collection = this.property.GetValue(instance, null);

         if (collection == null) {

            Type collectionType = this.property.PropertyType;

            if (collectionType.IsAbstract
               || collectionType.IsInterface) {

               collection = Activator.CreateInstance(typeof(Collection<>).MakeGenericType(this.elementType));

            } else {
               collection = Activator.CreateInstance(collectionType);
            }

            this.property.SetValue(instance, collection, null);
         }

         return (IEnumerable)collection;
      }

      protected override void Add(IEnumerable collection, object element, MappingContext context) {
         this.addMethod.Invoke(collection, new[] { element });
      }
   }
}
