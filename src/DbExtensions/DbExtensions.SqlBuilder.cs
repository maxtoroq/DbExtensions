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
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;

namespace DbExtensions {

   partial class SqlBuilder {

      /// <summary>
      /// Creates and returns a <see cref="DbCommand"/> object whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the SQL representation of this instance, and whose <see cref="DbCommand.Parameters"/>
      /// property is initialized with the values from <see cref="SqlBuilder.ParameterValues"/> of this instance.
      /// </summary>
      /// <param name="providerFactory">The provider factory used to create the command.</param>
      /// <returns>
      /// A new <see cref="DbCommand"/> object whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the SQL representation of this instance, and whose <see cref="DbCommand.Parameters"/>
      /// property is initialized with the values from <see cref="SqlBuilder.ParameterValues"/> of this instance.
      /// </returns>
      /// <seealso cref="Extensions.CreateCommand(DbProviderFactory, string, object[])"/>
      public DbCommand ToCommand(DbProviderFactory providerFactory) {

         if (providerFactory == null) throw new ArgumentNullException("providerFactory");

         return providerFactory.CreateCommand(ToString(), this.ParameterValues.ToArray());
      }

      /// <summary>
      /// Creates and returns a <see cref="DbCommand"/> object whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the SQL representation of this instance, and whose <see cref="DbCommand.Parameters"/>
      /// property is initialized with the values from <see cref="SqlBuilder.ParameterValues"/> of this instance.
      /// </summary>
      /// <param name="connection">The connection used to create the command.</param>
      /// <returns>
      /// A new <see cref="DbCommand"/> object whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the SQL representation of this instance, and whose <see cref="DbCommand.Parameters"/>
      /// property is initialized with the values from <see cref="SqlBuilder.ParameterValues"/> of this instance.
      /// </returns>
      /// <seealso cref="Extensions.CreateCommand(DbConnection, string, object[])"/>
      public DbCommand ToCommand(DbConnection connection) {

         if (connection == null) throw new ArgumentNullException("connection");

         return connection.CreateCommand(ToString(), this.ParameterValues.ToArray());
      }
   }

   public static partial class Extensions {

      /// <summary>
      /// Creates and returns a <see cref="DbCommand"/> object from the specified <paramref name="sqlBuilder"/>.
      /// </summary>
      /// <param name="providerFactory">The provider factory used to create the command.</param>
      /// <param name="sqlBuilder">The <see cref="SqlBuilder"/> that provides the command's text and parameters.</param>
      /// <returns>
      /// A new <see cref="DbCommand"/> object whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the SQL representation of this instance, and whose <see cref="DbCommand.Parameters"/>
      /// property is initialized with the values from <see cref="SqlBuilder.ParameterValues"/> of this instance.
      /// </returns>
      /// <seealso cref="Extensions.CreateCommand(DbProviderFactory, string, object[])"/>
      public static DbCommand CreateCommand(this DbProviderFactory providerFactory, SqlBuilder sqlBuilder) {
         return sqlBuilder.ToCommand(providerFactory);
      }

      /// <summary>
      /// Creates and returns a <see cref="DbCommand"/> object from the specified <paramref name="sqlBuilder"/>.
      /// </summary>
      /// <param name="connection">The connection used to create the command.</param>
      /// <param name="sqlBuilder">The <see cref="SqlBuilder"/> that provides the command's text and parameters.</param>
      /// <returns>
      /// A new <see cref="DbCommand"/> object whose <see cref="DbCommand.CommandText"/> property
      /// is initialized with the SQL representation of this instance, and whose <see cref="DbCommand.Parameters"/>
      /// property is initialized with the values from <see cref="SqlBuilder.ParameterValues"/> of this instance.
      /// </returns>
      /// <seealso cref="Extensions.CreateCommand(DbConnection, string, object[])"/>
      public static DbCommand CreateCommand(this DbConnection connection, SqlBuilder sqlBuilder) {
         return sqlBuilder.ToCommand(connection);
      }

      internal static IEnumerable<TResult> Map<TResult>(Func<SqlBuilder, IDbCommand> queryToCommand, SqlBuilder query, Mapper mapper, TextWriter logger) {

         if (query.HasIgnoredColumns) {
            mapper.IgnoredColumns = new HashSet<int>(query.IgnoredColumns);
         }

         return Map<TResult>(queryToCommand(query), r => (TResult)mapper.Map(r), logger);
      }
   }
}
