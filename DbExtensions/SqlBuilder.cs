﻿// Copyright 2009-2013 Max Toro Q.
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
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace DbExtensions {

   /// <summary>
   /// Represents a mutable SQL string.
   /// </summary>
   [CLSCompliant(true)]
   [DebuggerDisplay("{Buffer}")]
   public class SqlBuilder {

      /// <summary>
      /// The underlying <see cref="StringBuilder"/>.
      /// </summary>
      public StringBuilder Buffer { get; private set; }

      /// <summary>
      /// The parameter objects to be included in the database command.
      /// </summary>
      public Collection<object> ParameterValues { get; private set; }

      /// <summary>
      /// Gets or sets the current SQL clause, used to identify consecutive 
      /// appends to the same clause.
      /// </summary>
      public string CurrentClause { get; set; }
      
      /// <summary>
      /// Gets or sets the separator of the current SQL clause body.
      /// </summary>
      /// <seealso cref="CurrentClause"/>
      public string CurrentSeparator { get; set; }
      
      /// <summary>
      /// Gets or sets the next SQL clause. Used by clause continuation methods,
      /// such as <see cref="AppendToCurrentClause(string)"/> and the methods that start with "_".
      /// </summary>
      public string NextClause { get; set; }

      /// <summary>
      /// Gets or sets the separator of the next SQL clause body.
      /// </summary>
      /// <seealso cref="NextClause"/>
      public string NextSeparator { get; set; }

      /// <summary>
      /// Returns true if the buffer is empty.
      /// </summary>
      public bool IsEmpty {
         get { return this.Buffer.Length == 0; }
      }

      /// <summary>
      /// Concatenates a specified separator <see cref="String"/> between each element of a 
      /// specified <see cref="SqlBuilder"/> array, yielding a single concatenated <see cref="SqlBuilder"/>.
      /// </summary>
      /// <param name="separator">The string to use as a separator.</param>
      /// <param name="values">An array of <see cref="SqlBuilder"/>.</param>
      /// <returns>
      /// A <see cref="SqlBuilder"/> consisting of the elements of <paramref name="values"/> 
      /// interspersed with the <paramref name="separator"/> string.
      /// </returns>
      public static SqlBuilder JoinSql(string separator, params SqlBuilder[] values) {

         if (values == null) throw new ArgumentNullException("values");

         SqlBuilder sql = new SqlBuilder();

         if (values.Length == 0) 
            return sql;

         if (separator == null)
            separator = "";

         SqlBuilder first = values[0];

         if (first != null)
            sql.Append(first);

         for (int i = 1; i < values.Length; i++) {

            sql.Append(separator);

            SqlBuilder val = values[i];

            if (val != null)
               sql.Append(val);
         }

         return sql;
      }

      /// <summary>
      /// Concatenates the members of a constructed <see cref="IEnumerable&lt;SqlBuilder>"/> collection of type <see cref="SqlBuilder"/>, 
      /// using the specified <paramref name="separator"/> between each member.
      /// </summary>
      /// <param name="separator">The string to use as a separator.</param>
      /// <param name="values">A collection that contains the <see cref="SqlBuilder"/> objects to concatenate.</param>
      /// <returns>
      /// A <see cref="SqlBuilder"/> that consists of the members of <paramref name="values"/> delimited 
      /// by the <paramref name="separator"/> string. If <paramref name="values"/> has no members, the method returns
      /// an empty <see cref="SqlBuilder"/>.
      /// </returns>
      public static SqlBuilder JoinSql(string separator, IEnumerable<SqlBuilder> values) {

         if (values == null) throw new ArgumentNullException("values");

         SqlBuilder sql = new SqlBuilder();

         if (separator == null)
            separator = "";

         using (IEnumerator<SqlBuilder> enumerator = values.GetEnumerator()) {

            if (!enumerator.MoveNext())
               return sql;

            if (enumerator.Current != null)
               sql.Append(enumerator.Current);

            while (enumerator.MoveNext()) {

               sql.Append(separator);

               if (enumerator.Current != null)
                  sql.Append(enumerator.Current);
            }
         }

         return sql;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlBuilder"/> class.
      /// </summary>
      public SqlBuilder() {
         
         this.Buffer = new StringBuilder();
         this.ParameterValues = new Collection<object>();
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlBuilder"/> class
      /// using the provided SQL string.
      /// </summary>
      /// <param name="sql">The SQL string.</param>
      public SqlBuilder(string sql) 
         : this(sql, null) { }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlBuilder"/> class
      /// using the provided format string and parameters.
      /// </summary>
      /// <param name="format">The SQL format string.</param>
      /// <param name="args">The array of parameters.</param>
      public SqlBuilder(string format, params object[] args) 
         : this() {
         
         Append(format, args);
      }

      /// <summary>
      /// Appends the SQL clause specified by <paramref name="clauseName"/> using the provided 
      /// <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="clauseName">The SQL clause.</param>
      /// <param name="separator">The clause body separator, used for consecutive appends to the same clause.</param>
      /// <param name="format">The format string that represents the body of the clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder AppendClause(string clauseName, string separator, string format, object[] args) {

         if (separator == null 
            || !String.Equals(clauseName, this.CurrentClause, StringComparison.OrdinalIgnoreCase)) {

            if (!this.IsEmpty)
               this.Buffer.AppendLine();

            if (clauseName != null) {
               this.Buffer.Append(clauseName);
               this.Buffer.Append(" ");
            }

         } else if (separator != null) {
            this.Buffer.Append(separator);
         }

         Append(format, args);

         this.CurrentClause = clauseName;
         this.CurrentSeparator = separator;

         this.NextClause = null;
         this.NextSeparator = null;

         return this;
      }

      /// <summary>
      /// Appends <paramref name="body"/> to the current clause.
      /// </summary>
      /// <param name="body">The body of the current clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      /// <seealso cref="CurrentClause"/>
      public SqlBuilder AppendToCurrentClause(string body) {
         return AppendToCurrentClause(body, null);
      }

      /// <summary>
      /// Appends <paramref name="format"/> to the current clause.
      /// </summary>
      /// <param name="format">The format string that represents the body of the current clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      /// <seealso cref="CurrentClause"/>
      public SqlBuilder AppendToCurrentClause(string format, params object[] args) {

         string clause = this.CurrentClause;
         string separator = this.CurrentSeparator;

         if (this.NextClause != null) {
            clause = this.NextClause;
            separator = this.NextSeparator;
         }

         AppendClause(clause, separator, format, args);

         return this;
      }

      /// <summary>
      /// Appends <paramref name="sql"/> to this instance.
      /// </summary>
      /// <param name="sql">A SQL string.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder Append(string sql) {
         return Append(sql, null);
      }

      /// <summary>
      /// Appends <paramref name="sql"/> to this instance.
      /// </summary>
      /// <param name="sql">A <see cref="SqlBuilder"/>.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder Append(SqlBuilder sql) {
         return Append("{0}", sql);
      }

      /// <summary>
      /// Appends <paramref name="format"/> to this instance.
      /// </summary>
      /// <param name="format">A SQL format string.</param>
      /// <param name="args">The array of parameters.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder Append(string format, params object[] args) {

         if (args == null || args.Length == 0) {
            this.Buffer.Append(format);
         } else {
            List<string> fargs = new List<string>();
            List<object> oargs = new List<object>();

            int fi = this.ParameterValues.Count;

            for (int i = 0; i < args.Length; i++) {
               object obj = args[i];

               if (obj != null) {
                  Array arr = obj as Array;

                  if (arr != null && arr.Length > 0) {
                     fargs.Add(String.Join(", ", Enumerable.Range(0, arr.Length).Select(x => String.Concat("{", fi++, "}")).ToArray()));
                     foreach (object item in arr) oargs.Add(item);
                     continue;

                  } else {
                     SqlBuilder sqlb = obj as SqlBuilder;

                     if (sqlb != null) {
                        StringBuilder sqlfrag = new StringBuilder()
                           .AppendLine()
                           .AppendFormat(CultureInfo.InvariantCulture, sqlb.ToString(), Enumerable.Range(0, sqlb.ParameterValues.Count).Select(x => String.Concat("{", fi++, "}")).ToArray())
                           .Replace(Environment.NewLine, Environment.NewLine + "\t");

                        fargs.Add(sqlfrag.ToString());
                        oargs.AddRange(sqlb.ParameterValues);
                        continue;
                     }
                  }
               }

               fargs.Add(String.Concat("{", fi++, "}"));
               oargs.Add(obj);
            }

            if (format == null) {

               string[] templArgs = Enumerable.Range(0, fargs.Count)
                  .Select(i => String.Concat("{", i, "}")).ToArray();

               format = String.Join(" ", templArgs);
            }

            if (format.Contains("{1}"))
            {
               this.Buffer.AppendFormat(CultureInfo.InvariantCulture, format, fargs.Cast<object>().ToArray());
            }
            else
            {
               // HACK ToArray for compatibility with .Net 3.5. Not required for 4.0 and later.
               string joinedArgs = String.Join(", ", fargs.ToArray());
               object[] jargs = new object[] { joinedArgs };
               this.Buffer.AppendFormat(CultureInfo.InvariantCulture, format, jargs);
            }

            foreach (object item in oargs)
               this.ParameterValues.Add(item);
         }

         return this;
      }

      /// <summary>
      /// Appends the default line terminator to this instance.
      /// </summary>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder AppendLine() {
         
         this.Buffer.AppendLine();
         return this;
      }

      /// <summary>
      /// Inserts a string into this instance at the specified character position.
      /// </summary>
      /// <param name="index">The position in this instance where insertion begins.</param>
      /// <param name="value">The string to insert.</param>
      /// <returns>A reference to this instance after the insert operation has completed.</returns>
      /// <seealso cref="StringBuilder.Insert(int, string)"/>
      public SqlBuilder Insert(int index, string value) {

         this.Buffer.Insert(index, value);

         return this;
      }

      /// <summary>
      /// Sets <paramref name="clauseName"/> as the current SQL clause.
      /// </summary>
      /// <param name="clauseName">The SQL clause.</param>
      /// <param name="separator">The clause body separator, used for consecutive appends to the same clause.</param>
      /// <returns>A reference to this instance after the operation has completed.</returns>
      /// <seealso cref="CurrentClause"/>
      public SqlBuilder SetCurrentClause(string clauseName, string separator) {

         this.CurrentClause = clauseName;
         this.CurrentSeparator = separator;

         return this;
      }

      /// <summary>
      /// Sets <paramref name="clauseName"/> as the next SQL clause.
      /// </summary>
      /// <param name="clauseName">The SQL clause.</param>
      /// <param name="separator">The clause body separator, used for consecutive appends to the same clause.</param>
      /// <returns>A reference to this instance after the operation has completed.</returns>
      /// <seealso cref="NextClause"/>
      public SqlBuilder SetNextClause(string clauseName, string separator) {
         
         this.NextClause = clauseName;
         this.NextSeparator = separator;

         return this;
      }

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

      /// <summary>
      /// Converts the value of this instance to a <see cref="String"/>.
      /// </summary>
      /// <returns>A string whose value is the same as this instance.</returns>
      public override string ToString() {
         return this.Buffer.ToString();
      }

      /// <summary>
      /// Creates and returns a copy of this instance.
      /// </summary>
      /// <returns>A new <see cref="SqlBuilder"/> that is equivalent to this instance.</returns>
      public SqlBuilder Clone() {

         var clone = new SqlBuilder();
         clone.Buffer.Append(this.Buffer.ToString());
         clone.CurrentClause = this.CurrentClause;
         clone.CurrentSeparator = this.CurrentSeparator;

         foreach (object item in this.ParameterValues) 
            clone.ParameterValues.Add(item);

         return clone;
      }

      /// <summary>
      /// Appends <paramref name="body"/> to the current clause. This method is a shortcut for
      /// <see cref="AppendToCurrentClause(string)"/>.
      /// </summary>
      /// <param name="body">The body of the current clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      /// <seealso cref="AppendToCurrentClause(string)"/>
      [CLSCompliant(false)]
      public SqlBuilder _(string body) {
         return AppendToCurrentClause(body);
      }

      /// <summary>
      /// Appends <paramref name="format"/> to the current clause. This method is a shortcut for
      /// <see cref="AppendToCurrentClause(string, object[])"/>.
      /// </summary>
      /// <param name="format">The format string that represents the body of the current clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      /// <seealso cref="AppendToCurrentClause(string, object[])"/>
      [CLSCompliant(false)]
      public SqlBuilder _(string format, params object[] args) {
         return AppendToCurrentClause(format, args);
      }

      /// <summary>
      /// Appends <paramref name="body"/> to the current clause if <paramref name="condition"/> is true.
      /// </summary>
      /// <param name="condition">true to append <paramref name="body"/> to the current clause; otherwise, false.</param>
      /// <param name="body">The body of the current clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      [CLSCompliant(false)]
      public SqlBuilder _If(bool condition, string body) {
         return _If(condition, body, null);
      }

      /// <summary>
      /// Appends <paramref name="body"/> to the current clause if <paramref name="condition"/> is true.
      /// </summary>
      /// <param name="condition">true to append <paramref name="body"/> to the current clause; otherwise, false.</param>
      /// <param name="body">The body of the current clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      [CLSCompliant(false)]
      public SqlBuilder _If(bool condition, int body) {
         return _If(condition, body.ToString(CultureInfo.InvariantCulture), null);
      }

      /// <summary>
      /// Appends <paramref name="body"/> to the current clause if <paramref name="condition"/> is true.
      /// </summary>
      /// <param name="condition">true to append <paramref name="body"/> to the current clause; otherwise, false.</param>
      /// <param name="body">The body of the current clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      [CLSCompliant(false)]
      public SqlBuilder _If(bool condition, long body) {
         return _If(condition, body.ToString(CultureInfo.InvariantCulture), null);
      }

      /// <summary>
      /// Appends <paramref name="format"/> to the current clause if <paramref name="condition"/> is true.
      /// </summary>
      /// <param name="condition">true to append <paramref name="format"/> to the current clause; otherwise, false.</param>
      /// <param name="format">The format string that represents the body of the current clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      [CLSCompliant(false)]
      public SqlBuilder _If(bool condition, string format, params object[] args) {
         return (condition) ? _(format, args) : this;
      }

      /// <summary>
      /// Appends to the current clause the string made by concatenating an <paramref name="itemFormat"/> for each element
      /// in <paramref name="items"/>, interspersed with <paramref name="separator"/>.
      /// </summary>
      /// <typeparam name="T">The type of elements in <paramref name="items"/>.</typeparam>
      /// <param name="items">The collection of objects that contain parameters.</param>
      /// <param name="format">The clause body format string, which must contain a {0} placeholder. This parameter can be null.</param>
      /// <param name="itemFormat">The item format.</param>
      /// <param name="separator">The string to use as separator between each item format.</param>
      /// <param name="parametersFactory">The delegate that extract parameters for each element in <paramref name="items"/>. This parameter can be null.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      [CLSCompliant(false)]
      public SqlBuilder _ForEach<T>(IEnumerable<T> items, string format, string itemFormat, string separator, Func<T, object[]> parametersFactory) {

         if (items == null) throw new ArgumentNullException("items");
         if (itemFormat == null) throw new ArgumentNullException("itemFormat");
         if (separator == null) throw new ArgumentNullException("separator");

         string formatStart = "", formatEnd = "";

         if (format != null) {
            string[] formatSplit = format.Split(new[] { "{0}" }, StringSplitOptions.None);
            formatStart = formatSplit[0];
            formatEnd = formatSplit[1];
         }

         if (parametersFactory == null)
            parametersFactory = (item) => null;

         string currentSeparator = this.NextSeparator ?? this.CurrentSeparator;

         bool first = true;

         foreach (var item in items) {

            string tempate = itemFormat;

            if (first) {
               first = false;
               tempate = formatStart + tempate;
            } else {
               this.CurrentSeparator = separator;
            }

            AppendToCurrentClause(tempate, parametersFactory(item));
         }

         if (!first) {
            Append(formatEnd);
            this.CurrentSeparator = currentSeparator;
         }

         return this;
      }

      /// <summary>
      /// Appends to the current clause the string made by concatenating an <paramref name="itemFormat"/> for each element
      /// in <paramref name="items"/>, interspersed with the OR operator.
      /// </summary>
      /// <typeparam name="T">The type of elements in <paramref name="items"/>.</typeparam>
      /// <param name="items">The collection of objects that contain parameters.</param>
      /// <param name="itemFormat">The format string.</param>
      /// <param name="parametersFactory">The delegate that extract parameters for each element in <paramref name="items"/>.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      [CLSCompliant(false)]
      public SqlBuilder _OR<T>(IEnumerable<T> items, string itemFormat, Func<T, object[]> parametersFactory) {
         return _ForEach(items, "({0})", itemFormat, " OR ", parametersFactory);
      }

      /// <summary>
      /// Appends the WITH clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the WITH clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder WITH(string body) {
         return WITH(body, null);
      }

      /// <summary>
      /// Appends the WITH clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the WITH clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder WITH(string format, params object[] args) {
         return AppendClause("WITH", null, format, args);
      }

      /// <summary>
      /// Appends the WITH clause using the provided <paramref name="subQuery"/> as body named after
      /// <paramref name="alias"/>.
      /// </summary>
      /// <param name="subQuery">The sub-query to use as the body of the WITH clause.</param>
      /// <param name="alias">The alias of the sub-query.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder WITH(SqlBuilder subQuery, string alias) {
         return WITH(alias + " AS ({0})", subQuery);
      }

      /// <summary>
      /// Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods,
      /// such as <see cref="_(string)"/> and <see cref="_If(bool, string)"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>
      public SqlBuilder SELECT() {
         return SetNextClause("SELECT", ", ");
      }

      /// <summary>
      /// Appends the SELECT clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the SELECT clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder SELECT(string body) {
         return SELECT(body, null);
      }

      /// <summary>
      /// Appends the SELECT clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the SELECT clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder SELECT(string format, params object[] args) {
         return AppendClause("SELECT", ", ", format, args);
      }

      /// <summary>
      /// Appends the FROM clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the FROM clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder FROM(string body) {
         return FROM(body, null);
      }

      /// <summary>
      /// Appends the FROM clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the FROM clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder FROM(string format, params object[] args) {
         return AppendClause("FROM", ", ", format, args);
      }

      /// <summary>
      /// Appends the FROM clause using the provided <paramref name="subQuery"/> as body named after
      /// <paramref name="alias"/>.
      /// </summary>
      /// <param name="subQuery">The sub-query to use as the body of the FROM clause.</param>
      /// <param name="alias">The alias of the sub-query.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder FROM(SqlBuilder subQuery, string alias) {
         return FROM("({0}) AS " + alias, subQuery);
      }

      /// <summary>
      /// Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods,
      /// such as <see cref="_(string)"/> and <see cref="_If(bool, string)"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>
      public SqlBuilder JOIN() {
         return SetNextClause("JOIN", null);
      }

      /// <summary>
      /// Appends the JOIN clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the JOIN clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder JOIN(string body) {
         return JOIN(body, null);
      }

      /// <summary>
      /// Appends the JOIN clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the JOIN clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder JOIN(string format, params object[] args) {
         return AppendClause("JOIN", null, format, args);
      }

      /// <summary>
      /// Appends the LEFT JOIN clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the LEFT JOIN clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder LEFT_JOIN(string body) {
         return LEFT_JOIN(body, null);
      }

      /// <summary>
      /// Appends the LEFT JOIN clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the LEFT JOIN clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder LEFT_JOIN(string format, params object[] args) {
         return AppendClause("LEFT JOIN", null, format, args);
      }

      /// <summary>
      /// Appends the RIGHT JOIN clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the RIGHT JOIN clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder RIGHT_JOIN(string body) {
         return RIGHT_JOIN(body, null);
      }

      /// <summary>
      /// Appends the RIGHT JOIN clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the RIGHT JOIN clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder RIGHT_JOIN(string format, params object[] args) {
         return AppendClause("RIGHT JOIN", null, format, args);
      }

      /// <summary>
      /// Appends the INNER JOIN clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the INNER JOIN clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder INNER_JOIN(string body) {
         return INNER_JOIN(body, null);
      }

      /// <summary>
      /// Appends the INNER JOIN clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the INNER JOIN clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder INNER_JOIN(string format, params object[] args) {
         return AppendClause("INNER JOIN", null, format, args);
      }

      /// <summary>
      /// Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods,
      /// such as <see cref="_(string)"/> and <see cref="_If(bool, string)"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>
      public SqlBuilder WHERE() {
         return SetNextClause("WHERE", " AND ");
      }

      /// <summary>
      /// Appends the WHERE clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the WHERE clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder WHERE(string body) {
         return WHERE(body, null);
      }

      /// <summary>
      /// Appends the WHERE clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the WHERE clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder WHERE(string format, params object[] args) {
         return AppendClause("WHERE", " AND ", format, args);
      }

      /// <summary>
      /// Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods,
      /// such as <see cref="_(string)"/> and <see cref="_If(bool, string)"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>
      public SqlBuilder GROUP_BY() {
         return SetNextClause("GROUP BY", ", ");
      }

      /// <summary>
      /// Appends the GROUP BY clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the GROUP BY clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder GROUP_BY(string body) {
         return GROUP_BY(body, null);
      }

      /// <summary>
      /// Appends the GROUP BY clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the GROUP BY clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder GROUP_BY(string format, params object[] args) {
         return AppendClause("GROUP BY", ", ", format, args);
      }

      /// <summary>
      /// Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods,
      /// such as <see cref="_(string)"/> and <see cref="_If(bool, string)"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>
      public SqlBuilder HAVING() {
         return SetNextClause("HAVING", " AND ");
      }

      /// <summary>
      /// Appends the HAVING clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the HAVING clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder HAVING(string body) {
         return HAVING(body, null);
      }

      /// <summary>
      /// Appends the HAVING clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the HAVING clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder HAVING(string format, params object[] args) {
         return AppendClause("HAVING", " AND ", format, args);
      }

      /// <summary>
      /// Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods,
      /// such as <see cref="_(string)"/> and <see cref="_If(bool, string)"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>
      public SqlBuilder ORDER_BY() {
         return SetNextClause("ORDER BY", ", ");
      }

      /// <summary>
      /// Appends the ORDER BY clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the ORDER BY clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder ORDER_BY(string body) {
         return ORDER_BY(body, null);
      }

      /// <summary>
      /// Appends the ORDER BY clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the ORDER BY clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder ORDER_BY(string format, params object[] args) {
         return AppendClause("ORDER BY", ", ", format, args);
      }

      /// <summary>
      /// Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods,
      /// such as <see cref="_(string)"/> and <see cref="_If(bool, string)"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>
      public SqlBuilder LIMIT() {
         return SetNextClause("LIMIT", null);
      }

      /// <summary>
      /// Appends the LIMIT clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the LIMIT clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder LIMIT(string body) {
         return LIMIT(body, null);
      }

      /// <summary>
      /// Appends the LIMIT clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the LIMIT clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder LIMIT(string format, params object[] args) {
         return AppendClause("LIMIT", null, format, args);
      }

      /// <summary>
      /// Appends the LIMIT clause using the string representation of <paramref name="maxRecords"/>
      /// as body.
      /// </summary>
      /// <param name="maxRecords">The value to use as the body of the LIMIT clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder LIMIT(int maxRecords) {
         return LIMIT("{0}", maxRecords);
      }

      /// <summary>
      /// Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods,
      /// such as <see cref="_(string)"/> and <see cref="_If(bool, string)"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>
      public SqlBuilder OFFSET() {
         return SetNextClause("OFFSET", null);
      }

      /// <summary>
      /// Appends the OFFSET clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the OFFSET clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder OFFSET(string body) {
         return OFFSET(body, null);
      }

      /// <summary>
      /// Appends the OFFSET clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the OFFSET clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder OFFSET(string format, params object[] args) {
         return AppendClause("OFFSET", null, format, args);
      }

      /// <summary>
      /// Appends the OFFSET clause using the string representation of <paramref name="startIndex"/>
      /// as body.
      /// </summary>
      /// <param name="startIndex">The value to use as the body of the OFFSET clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder OFFSET(int startIndex) {
         return OFFSET("{0}", startIndex);
      }

      /// <summary>
      /// Appends the UNION clause.
      /// </summary>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder UNION() {
         return AppendClause("UNION", null, null, null);
      }

      /// <summary>
      /// Appends the INSERT INTO clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the INSERT INTO clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder INSERT_INTO(string body) {
         return INSERT_INTO(body, null);
      }

      /// <summary>
      /// Appends the INSERT INTO clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the INSERT INTO clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder INSERT_INTO(string format, params object[] args) {
         return AppendClause("INSERT INTO", null, format, args);
      }

      /// <summary>
      /// Appends the DELETE FROM clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the DELETE FROM clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder DELETE_FROM(string body) {
         return DELETE_FROM(body, null);
      }

      /// <summary>
      /// Appends the DELETE FROM clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the DELETE FROM clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder DELETE_FROM(string format, params object[] args) {
         return AppendClause("DELETE FROM", null, format, args);
      }

      /// <summary>
      /// Appends the UPDATE clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the UPDATE clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder UPDATE(string body) {
         return UPDATE(body, null);
      }

      /// <summary>
      /// Appends the UPDATE clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the UPDATE clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder UPDATE(string format, params object[] args) {
         return AppendClause("UPDATE", null, format, args);
      }

      /// <summary>
      /// Appends the SET clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the SET clause.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder SET(string body) {
         return SET(body, null);
      }

      /// <summary>
      /// Appends the SET clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the SET clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder SET(string format, params object[] args) {
         return AppendClause("SET", ", ", format, args);
      }

      /// <summary>
      /// Appends the VALUES clause using the provided parameters.
      /// </summary>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>
      public SqlBuilder VALUES(params object[] args) {

         if (args == null || args.Length == 0)
            throw new ArgumentException("args cannot be empty", "args");

         return AppendClause("VALUES", null, "({0})", new object[] { args });
      }
   }

   /// <summary>
   /// Provides a set of static (Shared in Visual Basic) methods to create <see cref="SqlBuilder"/> 
   /// instances.
   /// </summary>
   public static class SQL {

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/>.
      /// </summary>
      /// <returns>A new <see cref="SqlBuilder"/>.</returns>
      /// <seealso cref="SqlBuilder()"/>
      public static SqlBuilder ctor() {
         return new SqlBuilder();
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/> initialized with
      /// <paramref name="sql"/>.
      /// </summary>
      /// <param name="sql">The SQL string.</param>
      /// <returns>
      /// A new <see cref="SqlBuilder"/> initialized with <paramref name="sql"/>.
      /// </returns>
      /// <seealso cref="SqlBuilder(string)"/>
      public static SqlBuilder ctor(string sql) {
         return new SqlBuilder(sql);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/> initialized with
      /// <paramref name="format"/> and <paramref name="args"/>.
      /// </summary>
      /// <param name="format">The SQL format string.</param>
      /// <param name="args">The array of parameters.</param>
      /// <returns>
      /// A new <see cref="SqlBuilder"/> initialized with
      /// <paramref name="format"/> and <paramref name="args"/>.
      /// </returns>
      /// <seealso cref="SqlBuilder(string, object[])"/>
      public static SqlBuilder ctor(string format, params object[] args) {
         return new SqlBuilder(format, args);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
      /// appending the WITH clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the WITH clause.</param>
      /// <returns>
      /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.WITH(string)"/>.
      /// </returns>
      /// <seealso cref="SqlBuilder.WITH(string)"/>
      public static SqlBuilder WITH(string body) {
         return ctor().WITH(body);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
      /// appending the WITH clause using the provided <paramref name="format"/>
      /// and <paramref name="args"/>.
      /// </summary>
      /// <param name="format">The body of the WITH clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>
      /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.WITH(string, object[])"/>.
      /// </returns>
      /// <seealso cref="SqlBuilder.WITH(string, object[])"/>
      public static SqlBuilder WITH(string format, params object[] args) {
         return ctor().WITH(format, args);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
      /// appending the WITH clause using the provided <paramref name="subQuery"/>
      /// and <paramref name="alias"/>.
      /// </summary>
      /// <param name="subQuery">The sub-query to use as the body of the WITH clause.</param>
      /// <param name="alias">The alias of the sub-query.</param>
      /// <returns>
      /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.WITH(SqlBuilder, string)"/>.
      /// </returns>
      /// <seealso cref="SqlBuilder.WITH(SqlBuilder, string)"/>
      public static SqlBuilder WITH(SqlBuilder subQuery, string alias) {
         return ctor().WITH(subQuery, alias);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
      /// appending the SELECT clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the SELECT clause.</param>
      /// <returns>
      /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.SELECT(string)"/>.
      /// </returns>
      /// <seealso cref="SqlBuilder.SELECT(string)"/>
      public static SqlBuilder SELECT(string body) {
         return ctor().SELECT(body);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
      /// appending the SELECT clause using the provided <paramref name="format"/>
      /// and <paramref name="args"/>.
      /// </summary>
      /// <param name="format">The body of the SELECT clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>
      /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.SELECT(string, object[])"/>.
      /// </returns>
      /// <seealso cref="SqlBuilder.SELECT(string, object[])"/>
      public static SqlBuilder SELECT(string format, params object[] args) {
         return ctor().SELECT(format, args);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
      /// appending the INSERT INTO clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the INSERT INTO clause.</param>
      /// <returns>
      /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.INSERT_INTO(string)"/>.
      /// </returns>
      /// <seealso cref="SqlBuilder.INSERT_INTO(string)"/>
      public static SqlBuilder INSERT_INTO(string body) {
         return ctor().INSERT_INTO(body);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
      /// appending the INSERT INTO clause using the provided <paramref name="format"/>
      /// and <paramref name="args"/>.
      /// </summary>
      /// <param name="format">The body of the INSERT INTO clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>
      /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.INSERT_INTO(string, object[])"/>.
      /// </returns>
      /// <seealso cref="SqlBuilder.INSERT_INTO(string, object[])"/>
      public static SqlBuilder INSERT_INTO(string format, params object[] args) {
         return ctor().INSERT_INTO(format, args);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
      /// appending the UPDATE clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the UPDATE clause.</param>
      /// <returns>
      /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.UPDATE(string)"/>.
      /// </returns>
      /// <seealso cref="SqlBuilder.UPDATE(string)"/>
      public static SqlBuilder UPDATE(string body) {
         return ctor().UPDATE(body);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
      /// appending the UPDATE clause using the provided <paramref name="format"/>
      /// and <paramref name="args"/>.
      /// </summary>
      /// <param name="format">The body of the UPDATE clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>
      /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.UPDATE(string, object[])"/>.
      /// </returns>
      /// <seealso cref="SqlBuilder.UPDATE(string, object[])"/>
      public static SqlBuilder UPDATE(string format, params object[] args) {
         return ctor().UPDATE(format, args);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
      /// appending the DELETE FROM clause using the provided <paramref name="body"/>.
      /// </summary>
      /// <param name="body">The body of the DELETE FROM clause.</param>
      /// <returns>
      /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.DELETE_FROM(string)"/>.
      /// </returns>
      /// <seealso cref="SqlBuilder.DELETE_FROM(string)"/>
      public static SqlBuilder DELETE_FROM(string body) {
         return ctor().DELETE_FROM(body);
      }

      /// <summary>
      /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
      /// appending the DELETE FROM clause using the provided <paramref name="format"/>
      /// and <paramref name="args"/>.
      /// </summary>
      /// <param name="format">The body of the DELETE FROM clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>
      /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.DELETE_FROM(string, object[])"/>.
      /// </returns>
      /// <seealso cref="SqlBuilder.DELETE_FROM(string, object[])"/>
      public static SqlBuilder DELETE_FROM(string format, params object[] args) {
         return ctor().DELETE_FROM(format, args);
      }
   }

   static partial class Extensions {

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <returns>The number of affected records.</returns>
      public static int Execute(this DbConnection connection, SqlBuilder nonQuery) {
         return connection.Execute(CreateCommand(connection, nonQuery), (TextWriter)null);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when the command is executed.</param>
      /// <returns>The number of affected records.</returns>
      public static int Execute(this DbConnection connection, SqlBuilder nonQuery, TextWriter logger) {
         return connection.Execute(CreateCommand(connection, nonQuery), logger);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command in a new or existing transaction, and
      /// validates the affected records value before comitting.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <param name="affectingRecords">The number of records that the command must affect, otherwise the transaction is rolledback.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.Affect(IDbCommand, int)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to <paramref name="affectingRecords"/>.</exception>
      public static int Affect(this DbConnection connection, SqlBuilder nonQuery, int affectingRecords) {
         return nonQuery.ToCommand(connection).Affect(affectingRecords);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command in a new or existing transaction, and
      /// validates the affected records value before comitting.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <param name="affectingRecords">The number of records that the command must affect, otherwise the transaction is rolledback.</param>
      /// <param name="affectedMode">The criteria for validating the affected records value.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.Affect(IDbCommand, int, AffectedRecordsPolicy)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is not valid according to the <paramref name="affectingRecords"/> and <paramref name="affectedMode"/> parameters.</exception>
      public static int Affect(this DbConnection connection, SqlBuilder nonQuery, int affectingRecords, AffectedRecordsPolicy affectedMode) {
         return nonQuery.ToCommand(connection).Affect(affectingRecords, affectedMode);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command in a new or existing transaction, and
      /// validates the affected records value before comitting.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <param name="affectingRecords">The number of records that the command must affect, otherwise the transaction is rolledback.</param>
      /// <param name="logger">A <see cref="TextWriter"/> for logging the whole process.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.Affect(IDbCommand, int, TextWriter)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to <paramref name="affectingRecords"/>.</exception>      
      public static int Affect(this DbConnection connection, SqlBuilder nonQuery, int affectingRecords, TextWriter logger) {
         return nonQuery.ToCommand(connection).Affect(affectingRecords, logger);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command in a new or existing transaction, and
      /// validates the affected records value before comitting.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <param name="affectingRecords">The number of records that the command must affect, otherwise the transaction is rolledback.</param>
      /// <param name="affectedMode">The criteria for validating the affected records value.</param>
      /// <param name="logger">A <see cref="TextWriter"/> for logging the whole process.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.Affect(IDbCommand, int, AffectedRecordsPolicy, TextWriter)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is not valid according to the <paramref name="affectingRecords"/> and <paramref name="affectedMode"/> parameters.</exception>
      public static int Affect(this DbConnection connection, SqlBuilder nonQuery, int affectingRecords, AffectedRecordsPolicy affectedMode, TextWriter logger) {
         return nonQuery.ToCommand(connection).Affect(affectingRecords, affectedMode, logger);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command in a new or existing transaction, and
      /// validates that the affected records value is equal to one before comitting.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOne(IDbCommand)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to one.</exception>
      public static int AffectOne(this DbConnection connection, SqlBuilder nonQuery) {
         return Affect(connection, nonQuery, 1);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command in a new or existing transaction, and
      /// validates that the affected records value is equal to one before comitting.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <param name="logger">A <see cref="TextWriter"/> for logging the whole process.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOne(IDbCommand, TextWriter)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is not equal to one.</exception>
      public static int AffectOne(this DbConnection connection, SqlBuilder nonQuery, TextWriter logger) {
         return Affect(connection, nonQuery, 1, logger);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command in a new or existing transaction, and
      /// validates that the affected records value is less or equal to one before comitting.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOneOrNone(IDbCommand)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is greater than one.</exception>
      public static int AffectOneOrNone(this DbConnection connection, SqlBuilder nonQuery) {
         return Affect(connection, nonQuery, 1, AffectedRecordsPolicy.AllowLower);
      }

      /// <summary>
      /// Executes the <paramref name="nonQuery"/> command in a new or existing transaction, and
      /// validates that the affected records value is less or equal to one before comitting.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="nonQuery">The non-query command to execute.</param>
      /// <param name="logger">A <see cref="TextWriter"/> for logging the whole process.</param>
      /// <returns>The number of affected records.</returns>
      /// <seealso cref="Extensions.AffectOneOrNone(IDbCommand, TextWriter)"/>
      /// <exception cref="DBConcurrencyException">The number of affected records is greater than one.</exception>      
      public static int AffectOneOrNone(this DbConnection connection, SqlBuilder nonQuery, TextWriter logger) {
         return Affect(connection, nonQuery, 1, AffectedRecordsPolicy.AllowLower, logger);
      }

      /// <summary>
      /// Maps the results of the <paramref name="query"/> to objects of type
      /// specified by the <paramref name="resultType"/> parameter.
      /// The query is deferred-executed.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="resultType">The type of objects to map the results to.</param>
      /// <param name="query">The query.</param>
      /// <returns>The results of the query as objects of type specified by the <paramref name="resultType"/> parameter.</returns>
      /// <seealso cref="Extensions.Map(IDbCommand, Type)"/>
      public static IEnumerable<object> Map(this DbConnection connection, Type resultType, SqlBuilder query) {
         return query.ToCommand(connection).Map(resultType);
      }

      /// <summary>
      /// Maps the results of the <paramref name="query"/> to objects of type
      /// specified by the <paramref name="resultType"/> parameter.
      /// The query is deferred-executed.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="resultType">The type of objects to map the results to.</param>
      /// <param name="query">The query.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when the command is executed.</param>
      /// <returns>The results of the query as objects of type specified by the <paramref name="resultType"/> parameter.</returns>
      /// <seealso cref="Extensions.Map(IDbCommand, Type, TextWriter)"/>
      public static IEnumerable<object> Map(this DbConnection connection, Type resultType, SqlBuilder query, TextWriter logger) {
         return query.ToCommand(connection).Map(resultType, logger);
      }

      /// <summary>
      /// Maps the results of the <paramref name="query"/> to <typeparamref name="TResult"/> objects.
      /// The query is deferred-executed.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="connection">The connection.</param>
      /// <param name="query">The query.</param>
      /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>
      /// <seealso cref="Extensions.Map&lt;T>(IDbCommand)"/>
      public static IEnumerable<TResult> Map<TResult>(this DbConnection connection, SqlBuilder query) {
         return query.ToCommand(connection).Map<TResult>();
      }

      /// <summary>
      /// Maps the results of the <paramref name="query"/> to <typeparamref name="TResult"/> objects.
      /// The query is deferred-executed.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="connection">The connection.</param>
      /// <param name="query">The query.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when the command is executed.</param>
      /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>
      /// <seealso cref="Extensions.Map&lt;T>(IDbCommand, TextWriter)"/>
      public static IEnumerable<TResult> Map<TResult>(this DbConnection connection, SqlBuilder query, TextWriter logger) {
         return query.ToCommand(connection).Map<TResult>(logger);
      }

      /// <summary>
      /// Maps the results of the <paramref name="query"/> to <typeparamref name="TResult"/> objects,
      /// using the provided <paramref name="mapper"/> delegate.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="connection">The connection.</param>
      /// <param name="query">The query.</param>
      /// <param name="mapper">The delegate for creating <typeparamref name="TResult"/> objects from an <see cref="IDataRecord"/> object.</param>
      /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>
      /// <seealso cref="Extensions.Map&lt;T>(IDbCommand, Func&lt;IDataRecord, T>)"/>
      public static IEnumerable<TResult> Map<TResult>(this DbConnection connection, SqlBuilder query, Func<IDataRecord, TResult> mapper) {
         return query.ToCommand(connection).Map<TResult>(mapper);
      }

      /// <summary>
      /// Maps the results of the <paramref name="query"/> to <typeparamref name="TResult"/> objects,
      /// using the provided <paramref name="mapper"/> delegate.
      /// </summary>
      /// <typeparam name="TResult">The type of objects to map the results to.</typeparam>
      /// <param name="connection">The connection.</param>
      /// <param name="query">The query.</param>
      /// <param name="mapper">The delegate for creating <typeparamref name="TResult"/> objects from an <see cref="IDataRecord"/> object.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when the command is executed.</param>
      /// <returns>The results of the query as <typeparamref name="TResult"/> objects.</returns>
      /// <seealso cref="Extensions.Map&lt;T>(IDbCommand, Func&lt;IDataRecord, T>, TextWriter)"/>
      public static IEnumerable<TResult> Map<TResult>(this DbConnection connection, SqlBuilder query, Func<IDataRecord, TResult> mapper, TextWriter logger) {
         return query.ToCommand(connection).Map<TResult>(mapper, logger);
      }

      /// <summary>
      /// Gets the number of results the <paramref name="query"/> would return.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="query">The query whose count is to be computed.</param>
      /// <returns>The number of results the <paramref name="query"/> would return.</returns>
      public static int Count(this DbConnection connection, SqlBuilder query) {
         return Count(connection, query, (TextWriter)null);
      }

      /// <summary>
      /// Gets the number of results the <paramref name="query"/> would return.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="query">The query whose count is to be computed.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when the command is executed.</param>
      /// <returns>The number of results the <paramref name="query"/> would return.</returns>
      public static int Count(this DbConnection connection, SqlBuilder query, TextWriter logger) {
         return Count(connection, CreateCommand(connection, CountQuery(query)), logger);
      }

      internal static int Count(this DbConnection connection, IDbCommand command, TextWriter logger) {
         return Convert.ToInt32(CountImpl(command, logger), CultureInfo.InvariantCulture);
      }

      /// <summary>
      /// Gets the number of results the <paramref name="query"/> would return.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="query">The query whose count is to be computed.</param>
      /// <returns>The number of results the <paramref name="query"/> would return.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "long", Justification = "Consistent with LINQ.")]
      public static long LongCount(this DbConnection connection, SqlBuilder query) {
         return LongCount(connection, query, (TextWriter)null);
      }

      /// <summary>
      /// Gets the number of results the <paramref name="query"/> would return.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="query">The query whose count is to be computed.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when the command is executed.</param>
      /// <returns>The number of results the <paramref name="query"/> would return.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "long", Justification = "Consistent with LINQ.")]
      public static long LongCount(this DbConnection connection, SqlBuilder query, TextWriter logger) {
         return LongCount(connection, CreateCommand(connection, CountQuery(query)), logger);
      }

      internal static long LongCount(this DbConnection connection, IDbCommand command, TextWriter logger) {
         return Convert.ToInt64(CountImpl(command, logger), CultureInfo.InvariantCulture);
      }

      static object CountImpl(IDbCommand command, TextWriter logger) {
         return command.Map(r => r[0], logger).SingleOrDefault() ?? 0;
      }

      internal static SqlBuilder CountQuery(SqlBuilder query) {

         return new SqlBuilder()
            .SELECT("COUNT(*)")
            .FROM("({0}) AS __countQuery", query);
      }

      /// <summary>
      /// Checks if <paramref name="query"/> would return at least one row.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="query">The query whose existance is to be checked.</param>
      /// <returns>true if <paramref name="query"/> contains any rows; otherwise, false.</returns>
      public static bool Exists(this DbConnection connection, SqlBuilder query) {
         return Exists(connection, query, (TextWriter)null);
      }

      /// <summary>
      /// Checks if <paramref name="query"/> would return at least one row.
      /// </summary>
      /// <param name="connection">The connection.</param>
      /// <param name="query">The query whose existance is to be checked.</param>
      /// <param name="logger">A <see cref="TextWriter"/> used to log when the command is executed.</param>
      /// <returns>true if <paramref name="query"/> contains any rows; otherwise, false.</returns>
      public static bool Exists(this DbConnection connection, SqlBuilder query, TextWriter logger) {

         if (query == null) throw new ArgumentNullException("query");

         return Exists(connection, CreateCommand(connection, ExistsQuery(query)), logger);
      }

      internal static bool Exists(this DbConnection connection, IDbCommand command, TextWriter logger) {
         
         return command.Map(r => Convert.ToInt32(r[0], CultureInfo.InvariantCulture) != 0, logger)
            .SingleOrDefault();
      }

      internal static SqlBuilder ExistsQuery(SqlBuilder query) {

         return new SqlBuilder()
            .SELECT("(CASE WHEN EXISTS ({0}) THEN 1 ELSE 0 END)", query);
      }

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
   }
}
