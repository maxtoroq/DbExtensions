// Copyright 2009-2012 Max Toro Q.
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
         return getDbProviderFactory(connection);
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

#if NET40
            if (paramValue != null) {
               Type paramType = paramValue.GetType();

               if (paramType.IsGenericType && paramType.GetGenericTypeDefinition() == typeof(Lazy<>))
                  paramValue = paramType.GetProperty("Value").GetValue(paramValue, null);
            } 
#endif

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
      /// Creates and executes a <see cref="DbCommand"/> whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the <paramref name="commandText"/> parameter.
      /// </summary>
      /// <param name="connection">The connection to which the command is executed against.</param>
      /// <param name="commandText">The command text.</param>
      /// <returns>The number of affected records.</returns>
      public static int Execute(this DbConnection connection, string commandText) {
         return Execute(connection, commandText, null);
      }

      /// <summary>
      /// Creates and executes a <see cref="DbCommand"/> using the provided <paramref name="commandText"/> as a composite format string 
      /// (as used on <see cref="String.Format(String, Object[])"/>), 
      /// where the format items are replaced with appropiate parameter names, and the objects in the
      /// <paramref name="parameters"/> array are added to the command's <see cref="DbCommand.Parameters"/> collection.
      /// </summary>
      /// <param name="connection">The connection to which the command is executed against.</param>
      /// <param name="commandText">The command text.</param>
      /// <param name="parameters">The parameters to apply to the command text.</param>
      /// <returns>The number of affected records.</returns>
      public static int Execute(this DbConnection connection, string commandText, params object[] parameters) {
         return Execute(connection, CreateCommand(connection, commandText, parameters), null);
      }

      internal static int Execute(this IDbConnection connection, IDbCommand command, TextWriter logger) {

         using (connection.EnsureOpen()) {
            int aff = command.ExecuteNonQuery();

            if (logger != null)
               logger.WriteLine(command.ToTraceString(aff));

            return aff;
         }
      }

      /// <summary>
      /// Creates and executes a <see cref="DbCommand"/> (whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the <paramref name="commandText"/> parameter) in a new or existing transaction, and
      /// validates that the affected records value is equal to one before comitting.
      /// </summary>
      /// <param name="connection">The connection to which the command is executed against.</param>
      /// <param name="commandText">The command text.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOne(IDbCommand)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to one.</exception>
      public static int AffectOne(this DbConnection connection, string commandText) {
         return CreateCommand(connection, commandText).AffectOne();
      }

      /// <summary>
      /// Creates and executes a <see cref="DbCommand"/> (using the provided <paramref name="commandText"/> 
      /// as a composite format string, as used on <see cref="String.Format(String, Object[])"/>, 
      /// where the format items are replaced with appropiate parameter names, and the objects in the
      /// <paramref name="parameters"/> array are added to the command's <see cref="DbCommand.Parameters"/> collection)
      /// in a new or existing transaction, and validates that the affected records value is equal to one before comitting.
      /// </summary>
      /// <param name="connection">The connection to which the command is executed against.</param>
      /// <param name="commandText">The command text.</param>
      /// <param name="parameters">The parameters to apply to the command text.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOne(IDbCommand)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to one.</exception>
      public static int AffectOne(this DbConnection connection, string commandText, params object[] parameters) {
         return CreateCommand(connection, commandText, parameters).AffectOne();
      }

      /// <summary>
      /// Creates and executes a <see cref="DbCommand"/> (whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the <paramref name="commandText"/> parameter) in a new or existing transaction, and
      /// validates that the affected records value is less or equal to one before comitting.
      /// </summary>
      /// <param name="connection">The connection to which the command is executed against.</param>
      /// <param name="commandText">The non-query command to execute.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOneOrNone(IDbCommand)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is greater than one.</exception>
      public static int AffectOneOrNone(this DbConnection connection, string commandText) {
         return CreateCommand(connection, commandText).AffectOneOrNone();
      }

      /// <summary>
      /// Creates and executes a <see cref="DbCommand"/> (using the provided <paramref name="commandText"/> 
      /// as a composite format string, as used on <see cref="String.Format(String, Object[])"/>, 
      /// where the format items are replaced with appropiate parameter names, and the objects in the
      /// <paramref name="parameters"/> array are added to the command's <see cref="DbCommand.Parameters"/> collection)
      /// in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting.
      /// </summary>
      /// <param name="connection">The connection to which the command is executed against.</param>
      /// <param name="commandText">The non-query command to execute.</param>
      /// <param name="parameters">The parameters to apply to the command text.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOneOrNone(IDbCommand)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is greater than one.</exception>
      public static int AffectOneOrNone(this DbConnection connection, string commandText, params object[] parameters) {
         return CreateCommand(connection, commandText, parameters).AffectOneOrNone();
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

         PocoMapper mapper = new PocoMapper(resultType, logger);

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
         
         PocoMapper mapper = new PocoMapper(typeof(TResult), logger);

         return Map(command, r => mapper.Map(r), logger).Cast<TResult>();
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
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Object GetValueOrNull(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? null : record.GetValue(i);
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

   /// <summary>
   /// Provides a set of static (Shared in Visual Basic) methods for the creation 
   /// and location of common ADO.NET objects.
   /// </summary>
   public static class DbFactory {

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

         if (!factories.ContainsKey(providerInvariantName)) {
            lock (padlock) {
               if (!factories.ContainsKey(providerInvariantName)) {

                  var factory = DbProviderFactories.GetFactory(providerInvariantName);
                  factories[providerInvariantName] = factory;

                  return factory;
               }
            }
         }

         return factories[providerInvariantName];
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

      internal static DbConnection CreateConnection(out string providerName) {

         var defaultConnection = ConfigurationManager.AppSettings[DbExtensions_DefaultConnectionName];

         if (defaultConnection == null)
            throw new InvalidOperationException(
               String.Format(CultureInfo.InvariantCulture, "A default connection name must be provided using the '{0}' key in the appSettings configuration section.", DbExtensions_DefaultConnectionName)
            );

         return CreateConnection("name=" + defaultConnection, out providerName);
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

      internal static DbConnection CreateConnection(string connectionString, out string providerName) {

         if (connectionString == null) throw new ArgumentNullException("connectionString");

         var namedMatch = namedConnectionStringPattern.Match(connectionString.Trim());

         if (namedMatch.Success) {

            var name = namedMatch.Groups[1].Value;
            var connStringSettings = ConfigurationManager.ConnectionStrings[name];

            if (connStringSettings == null)
               throw new ArgumentException(
                  String.Format(CultureInfo.InvariantCulture, "Couldn't find '{0}' in System.Configuration.ConfigurationManager.ConnectionStrings.", name)
               , "connectionString");

            providerName = connStringSettings.ProviderName;

            var factory = DbFactory.GetProviderFactory(providerName);
            var connection = factory.CreateConnection(connStringSettings.ConnectionString);

            return connection;

         } else {

            providerName = ConfigurationManager.AppSettings[DbExtensions_DefaultProviderName];

            if (providerName == null)
               throw new InvalidOperationException(
                  String.Format(CultureInfo.InvariantCulture, "A default provider name must be provided using the '{0}' key in the appSettings configuration section.", DbExtensions_DefaultProviderName)
               );

            var factory = DbFactory.GetProviderFactory(providerName);
            var connection = factory.CreateConnection(connectionString);

            return connection;
         }
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

   internal class MappingEnumerable<TResult> : IEnumerable<TResult>, IEnumerable, IDisposable {

      MappingEnumerable<TResult>.Enumerator enumerator;

      public MappingEnumerable(IDbCommand command, Func<IDataRecord, TResult> mapper)
         : this(command, mapper, null) { }

      public MappingEnumerable(IDbCommand command, Func<IDataRecord, TResult> mapper, TextWriter logger) {
         this.enumerator = new MappingEnumerable<TResult>.Enumerator(command, mapper, logger);
      }

      public IEnumerator<TResult> GetEnumerator() {

         MappingEnumerable<TResult>.Enumerator e = enumerator;

         if (e == null)
            throw new InvalidOperationException("Cannot enumerate more than once.");

         enumerator = null;

         return e;
      }

      IEnumerator IEnumerable.GetEnumerator() {
         return this.GetEnumerator();
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

            if (command.Connection == null)
               throw new ArgumentException("command.Connection cannot be null", "command");

            prevStateWasClosed = (command.Connection.State == ConnectionState.Closed);

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

            if (command.Connection.State != ConnectionState.Closed)
               command.Connection.Close();
         }
      }

      #endregion
   }
}

namespace DbExtensions {

   using System;
   using System.Collections.Generic;
   using System.Data;
   using System.Globalization;
   using System.IO;
   using System.Linq;
   using System.Reflection;

   internal class PocoMapper {

      readonly Type type;
      readonly TextWriter logger;
      MapNode rootNode;

      public PocoMapper(Type type, TextWriter logger) {

         if (type == null) throw new ArgumentNullException("type");

         this.type = type;
         this.logger = logger;
      }

      MapNode ReadMapping(IDataRecord record) {

         MapGroup[] groups =
            (from i in Enumerable.Range(0, record.FieldCount)
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

         return ReadMapping(groups, groups.Where(m => m.Depth == 0).Single(), this.type);
      }

      MapNode ReadMapping(MapGroup[] groups, MapGroup currentGroup, Type parentType) {

         PropertyInfo property = !String.IsNullOrEmpty(currentGroup.Name) ? GetProperty(parentType, currentGroup.Name) : null;
         Type declaringType = (property == null) ? parentType : property.PropertyType;

         MapNode instance = new MapNode(property);

         instance.Properties.AddRange(
            from p in currentGroup.Properties
            select new MapNode(GetProperty(declaringType, p.Value), p.Key)
         );

         instance.Properties.AddRange(
            from m in groups
            where m.Depth == currentGroup.Depth + 1 && m.Parent == currentGroup.Name
            select ReadMapping(groups, m, declaringType)
         );

         return instance;
      }

      static PropertyInfo GetProperty(Type declaringType, string propertyName) {
         return declaringType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
      }

      public object Map(IDataRecord record) {

         object instance = Activator.CreateInstance(this.type);

         Load(instance, record);

         return instance;
      }

      public void Load(object instance, IDataRecord record) {
         
         if (instance == null) throw new ArgumentNullException("instance");
         if (record == null) throw new ArgumentNullException("record");

         if (this.rootNode == null)
            this.rootNode = ReadMapping(record);

         Load(instance, record, this.rootNode);
      }

      void Load(object instance, IDataRecord record, MapNode mapNode) {

         for (int i = 0; i < mapNode.Properties.Count; i++) {
            MapNode node = mapNode.Properties[i];
            PropertyInfo prop = node.Property;

            if (!node.IsComplex) {
               if (prop != null) {
                  LoadScalarProperty(instance, record, node);
               }
            
            } else {

               if (prop != null) {
                  
                  bool allNulls = node.Properties
                     .Where(m => !m.IsComplex)
                     .All(m => record.IsDBNull(m.ColumnOrdinal));

                  object value = prop.GetValue(instance, null);

                  if (value == null) {
                     if (!allNulls) {
                        value = Activator.CreateInstance(prop.PropertyType);
                        prop.SetValue(instance, value, null);
                     }
                  } else {
                     if (allNulls) {
                        prop.SetValue(instance, null, null);
                     }
                  }

                  if (value != null)
                     Load(value, record, node); 
               }
            }
         }
      }

      void LoadScalarProperty(object instance, IDataRecord record, MapNode mapNode) {

         PropertyInfo property = mapNode.Property;
         Type propertyType = property.PropertyType;
         bool isNull = record.IsDBNull(mapNode.ColumnOrdinal);
         object value = isNull ? null : record.GetValue(mapNode.ColumnOrdinal);

         try {
            SetScalarProperty(instance, value, isNull, mapNode);

         } catch (Exception ex) {
            throw new InvalidCastException(
               String.Format(CultureInfo.InvariantCulture,
                  "Couldn't set {0} property {1} of type {2} {3}.",
                  property.ReflectedType.FullName, property.Name, propertyType.FullName, (isNull) ? "to null" : "with value of type " + value.GetType().FullName
               )
            , ex);
         }
      }

      void SetScalarProperty(object instance, object value, bool isNull, MapNode mapNode) {

         PropertyInfo property = mapNode.Property;
         Type propertyType = property.PropertyType;

         if (!isNull && mapNode.RequiresConversion) {

            Type conversionType = mapNode.ConversionType;

            if (conversionType == null) {

               bool isNullableValueType = (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>));
               conversionType = (isNullableValueType) ? Nullable.GetUnderlyingType(propertyType) : propertyType;

               mapNode.ConversionType = conversionType;
            }

            if (conversionType == typeof(bool)
               && value.GetType() == typeof(string)) {

               value = Convert.ToBoolean(Convert.ToInt64(value, CultureInfo.InvariantCulture));

            } else {
               value = Convert.ChangeType(value, conversionType, CultureInfo.InvariantCulture);
            }
         }

         try {
            property.SetValue(instance, value, null);

         } catch {

            if (!isNull && !mapNode.RequiresConversion) {

               if (this.logger != null) {

                  this.logger.WriteLine("-- WARNING: Couldn't set {0} property {1} of type {2} {3}. Attempting conversion.",
                     property.ReflectedType.FullName, 
                     property.Name, propertyType.FullName, 
                     (isNull) ? "to null" : "with value of type " + value.GetType().FullName
                  );
               }

               mapNode.RequiresConversion = true;   

               SetScalarProperty(instance, value, isNull, mapNode);

            } else {
               throw;
            }
         }
      }

      #region Nested Types

      class MapGroup {
         public string Name;
         public int Depth;
         public string Parent;
         public Dictionary<int, string> Properties;
      }

      class MapNode {

         public readonly PropertyInfo Property;
         public readonly bool IsComplex;
         public bool RequiresConversion;
         public Type ConversionType;

         // mutually exclusive
         public readonly int ColumnOrdinal;
         public readonly List<MapNode> Properties;

         public MapNode(PropertyInfo property) {

            this.Property = property;
            this.IsComplex = true;
            this.Properties = new List<MapNode>();
         }

         public MapNode(PropertyInfo property, int columnOrdinal) {

            this.Property = property;
            this.ColumnOrdinal = columnOrdinal;
         }
      }

      #endregion
   }
}