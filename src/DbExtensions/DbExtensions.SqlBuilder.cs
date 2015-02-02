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
         return Extensions.CreateCommand(providerFactory, this);
      }

      /// <inheritdoc cref="ToCommand(DbProviderFactory)"
      ///             select="*[not(self::param/@name='providerFactory') and not(self::seealso)]"/>
      /// <param name="connection">The connection used to create the command.</param>
      /// <seealso cref="Extensions.CreateCommand(DbConnection, string, object[])"/>
      public DbCommand ToCommand(DbConnection connection) {
         return Extensions.CreateCommand(connection, this);
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
      /// is initialized with the <paramref name="sqlBuilder"/>'s string representation, and whose <see cref="DbCommand.Parameters"/>
      /// property is initialized with the values from the <see cref="SqlBuilder.ParameterValues"/> property of the <paramref name="sqlBuilder"/> parameter.
      /// </returns>
      /// <seealso cref="CreateCommand(DbProviderFactory, string, object[])"/>
      public static DbCommand CreateCommand(this DbProviderFactory providerFactory, SqlBuilder sqlBuilder) {

         // TODO: providerFactory should be factory for consistency with other methods in Extension class

         return CreateCommand(providerFactory, sqlBuilder.ToString(), sqlBuilder.ParameterValues.ToArray());
      }

      /// <inheritdoc cref="CreateCommand(DbProviderFactory, SqlBuilder)"
      ///             select="*[not(self::param/@name='providerFactory') and not(self::seealso)]"/>
      /// <param name="connection">The connection used to create the command.</param>
      /// <seealso cref="CreateCommand(DbConnection, string, object[])"/>
      public static DbCommand CreateCommand(this DbConnection connection, SqlBuilder sqlBuilder) {
         return CreateCommand(connection, sqlBuilder.ToString(), sqlBuilder.ParameterValues.ToArray());
      }

      internal static IEnumerable<TResult> Map<TResult>(Func<SqlBuilder, IDbCommand> queryToCommand, SqlBuilder query, Mapper mapper, TextWriter logger) {

         if (query.HasIgnoredColumns) {
            mapper.IgnoredColumns = new HashSet<int>(query.IgnoredColumns);
         }

         return Map<TResult>(queryToCommand(query), r => (TResult)mapper.Map(r), logger);
      }
   }
}
