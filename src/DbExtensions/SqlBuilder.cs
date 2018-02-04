// Copyright 2009-2018 Max Toro Q.
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DbExtensions {

   /// <summary>
   /// Represents a mutable SQL string.
   /// </summary>
   /// <remarks>For information on how to use SqlBuilder see <see href="http://maxtoroq.github.io/DbExtensions/docs/SqlBuilder.html">SqlBuilder Tutorial</see>.</remarks>

   [CLSCompliant(true)]
   [DebuggerDisplay("{Buffer}")]
   public partial class SqlBuilder {

      /// <summary>
      /// The underlying <see cref="StringBuilder"/>.
      /// </summary>

      public StringBuilder Buffer { get; } = new StringBuilder();

      /// <summary>
      /// The parameter objects to be included in the database command.
      /// </summary>

      public Collection<object> ParameterValues { get; } = new Collection<object>();

      /// <summary>
      /// Gets or sets the current SQL clause, used to identify consecutive 
      /// appends to the same clause.
      /// </summary>

      public string CurrentClause { get; set; }

      /// <summary>
      /// Gets or sets the separator of the current SQL clause body.
      /// </summary>

      public string CurrentSeparator { get; set; }

      /// <summary>
      /// Gets or sets the next SQL clause. Used by clause continuation methods,
      /// such as <see cref="AppendToCurrentClause(string, object[])"/> and the methods that start with "_".
      /// </summary>

      public string NextClause { get; set; }

      /// <summary>
      /// Gets or sets the separator of the next SQL clause body.
      /// </summary>

      public string NextSeparator { get; set; }

      /// <summary>
      /// Returns true if the buffer is empty.
      /// </summary>

      public bool IsEmpty => Buffer.Length == 0;

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

         if (values == null) throw new ArgumentNullException(nameof(values));

         var sql = new SqlBuilder();

         if (values.Length == 0) {
            return sql;
         }

         if (separator == null) {
            separator = "";
         }

         SqlBuilder first = values[0];

         if (first != null) {
            sql.Append(first);
         }

         for (int i = 1; i < values.Length; i++) {

            sql.Append(separator);

            SqlBuilder val = values[i];

            if (val != null) {
               sql.Append(val);
            }
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

         if (values == null) throw new ArgumentNullException(nameof(values));

         var sql = new SqlBuilder();

         if (separator == null) {
            separator = "";
         }

         using (IEnumerator<SqlBuilder> enumerator = values.GetEnumerator()) {

            if (!enumerator.MoveNext()) {
               return sql;
            }

            if (enumerator.Current != null) {
               sql.Append(enumerator.Current);
            }

            while (enumerator.MoveNext()) {

               sql.Append(separator);

               if (enumerator.Current != null) {
                  sql.Append(enumerator.Current);
               }
            }
         }

         return sql;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlBuilder"/> class.
      /// </summary>

      public SqlBuilder() { }

      /// <summary>
      /// Initializes a new instance of the <see cref="SqlBuilder"/> class
      /// using the provided format string and parameters.
      /// </summary>
      /// <param name="format">The SQL format string.</param>
      /// <param name="args">The array of parameters.</param>

      public SqlBuilder(string format, params object[] args) {
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

      public SqlBuilder AppendClause(string clauseName, string separator, string format, params object[] args) {

         if (separator == null
            || !String.Equals(clauseName, this.CurrentClause, StringComparison.OrdinalIgnoreCase)) {

            if (!this.IsEmpty) {
               this.Buffer.AppendLine();
            }

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
      /// Appends <paramref name="format"/> to the current clause.
      /// </summary>
      /// <param name="format">The format string that represents the body of the current clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>

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
      /// <param name="sql">A <see cref="SqlBuilder"/>.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>

      public SqlBuilder Append(SqlBuilder sql) {

         this.Buffer.Append(MakeAbsolutePlaceholders(sql));

         for (int i = 0; i < sql.ParameterValues.Count; i++) {
            this.ParameterValues.Add(sql.ParameterValues[i]);
         }

         return this;
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
            return this;
         }

         var fargs = new List<string>();

         for (int i = 0; i < args.Length; i++) {

            object obj = args[i];

            if (obj != null) {

               SqlList list = obj as SqlList;

               if (list != null) {

                  fargs.Add(String.Join(", ", Enumerable.Range(0, list.Count).Select(x => Placeholder(this.ParameterValues.Count + x))));

                  for (int j = 0; j < list.Count; j++) {
                     this.ParameterValues.Add(list[j]);
                  }

                  continue;

               } else {

                  var sqlb = obj as SqlBuilder;

                  if (sqlb != null) {

                     var sqlfrag = new StringBuilder()
                        .AppendLine()
                        .Append(MakeAbsolutePlaceholders(sqlb))
                        .Replace(Environment.NewLine, Environment.NewLine + "\t");

                     fargs.Add(sqlfrag.ToString());

                     for (int j = 0; j < sqlb.ParameterValues.Count; j++) {
                        this.ParameterValues.Add(sqlb.ParameterValues[j]);
                     }

                     continue;
                  }
               }
            }

            fargs.Add(Placeholder(this.ParameterValues.Count));
            this.ParameterValues.Add(obj);
         }

         if (format == null) {
            format = String.Join(" ", Enumerable.Range(0, fargs.Count).Select(i => Placeholder(i)));
         }

         this.Buffer.AppendFormat(CultureInfo.InvariantCulture, format, fargs.Cast<object>().ToArray());

         return this;
      }

      string MakeAbsolutePlaceholders(SqlBuilder sql) {
         return String.Format(CultureInfo.InvariantCulture, sql.ToString(), Enumerable.Range(0, sql.ParameterValues.Count).Select(x => Placeholder(this.ParameterValues.Count + x)).ToArray());
      }

      static string Placeholder(int index) {
         return String.Concat("{", index.ToString(CultureInfo.InvariantCulture), "}");
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

         foreach (object item in this.ParameterValues) {
            clone.ParameterValues.Add(item);
         }

         return clone;
      }

      /// <summary>
      /// Appends <paramref name="format"/> to the current clause. This method is a shortcut for
      /// <see cref="AppendToCurrentClause(string, object[])"/>.
      /// </summary>
      /// <param name="format">The format string that represents the body of the current clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>

      [CLSCompliant(false)]
      public SqlBuilder _(string format, params object[] args) {
         return AppendToCurrentClause(format, args);
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

         if (items == null) throw new ArgumentNullException(nameof(items));
         if (itemFormat == null) throw new ArgumentNullException(nameof(itemFormat));
         if (separator == null) throw new ArgumentNullException(nameof(separator));

         string formatStart = "", formatEnd = "";

         if (format != null) {
            string[] formatSplit = format.Split(new[] { "{0}" }, StringSplitOptions.None);
            formatStart = formatSplit[0];
            formatEnd = formatSplit[1];
         }

         if (parametersFactory == null) {
            parametersFactory = (item) => null;
         }

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
      /// such as <see cref="_(string, object[])"/> and <see cref="_If(bool, string, object[])"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>

      public SqlBuilder SELECT() {
         return SetNextClause("SELECT", ", ");
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
         return FROM("({0}) " + alias, subQuery);
      }

      /// <summary>
      /// Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods,
      /// such as <see cref="_(string, object[])"/> and <see cref="_If(bool, string, object[])"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>

      public SqlBuilder JOIN() {
         return SetNextClause("JOIN", null);
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
      /// Appends the LEFT JOIN clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the LEFT JOIN clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>

      public SqlBuilder LEFT_JOIN(string format, params object[] args) {
         return AppendClause("LEFT JOIN", null, format, args);
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
      /// Appends the INNER JOIN clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the INNER JOIN clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>

      public SqlBuilder INNER_JOIN(string format, params object[] args) {
         return AppendClause("INNER JOIN", null, format, args);
      }

      /// <summary>
      /// Appends the CROSS JOIN clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the CROSS JOIN clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>

      public SqlBuilder CROSS_JOIN(string format, params object[] args) {
         return AppendClause("CROSS JOIN", null, format, args);
      }

      /// <summary>
      /// Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods,
      /// such as <see cref="_(string, object[])"/> and <see cref="_If(bool, string, object[])"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>

      public SqlBuilder WHERE() {
         return SetNextClause("WHERE", " AND ");
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
      /// such as <see cref="_(string, object[])"/> and <see cref="_If(bool, string, object[])"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>

      public SqlBuilder GROUP_BY() {
         return SetNextClause("GROUP BY", ", ");
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
      /// such as <see cref="_(string, object[])"/> and <see cref="_If(bool, string, object[])"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>

      public SqlBuilder HAVING() {
         return SetNextClause("HAVING", " AND ");
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
      /// such as <see cref="_(string, object[])"/> and <see cref="_If(bool, string, object[])"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>

      public SqlBuilder ORDER_BY() {
         return SetNextClause("ORDER BY", ", ");
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
      /// such as <see cref="_(string, object[])"/> and <see cref="_If(bool, string, object[])"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>

      public SqlBuilder LIMIT() {
         return SetNextClause("LIMIT", null);
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
      /// Appends the LIMIT clause using the provided <paramref name="maxRecords"/> parameter.
      /// </summary>
      /// <param name="maxRecords">The value to use as parameter.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>

      public SqlBuilder LIMIT(int maxRecords) {
         return LIMIT("{0}", maxRecords);
      }

      /// <summary>
      /// Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods,
      /// such as <see cref="_(string, object[])"/> and <see cref="_If(bool, string, object[])"/>.
      /// </summary>
      /// <returns>A reference to this instance after the operation has completed.</returns>

      public SqlBuilder OFFSET() {
         return SetNextClause("OFFSET", null);
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
      /// Appends the OFFSET clause using the provided <paramref name="startIndex"/> parameter.
      /// </summary>
      /// <param name="startIndex">The value to use as parameter.</param>
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
      /// Appends the INSERT INTO clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the INSERT INTO clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>

      public SqlBuilder INSERT_INTO(string format, params object[] args) {
         return AppendClause("INSERT INTO", null, format, args);
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
      /// Appends the UPDATE clause using the provided <paramref name="format"/> string and parameters.
      /// </summary>
      /// <param name="format">The format string that represents the body of the UPDATE clause.</param>
      /// <param name="args">The parameters of the clause body.</param>
      /// <returns>A reference to this instance after the append operation has completed.</returns>

      public SqlBuilder UPDATE(string format, params object[] args) {
         return AppendClause("UPDATE", null, format, args);
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

         if (args == null || args.Length == 0) {
            throw new ArgumentException("args cannot be empty", nameof(args));
         }

         return AppendClause("VALUES", null, "({0})", SQL.List(args));
      }
   }

   /// <summary>
   /// Provides a set of static (Shared in Visual Basic) methods to create <see cref="SqlBuilder"/> 
   /// instances.
   /// </summary>

   public static class SQL {

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

      public static SqlBuilder WITH(string format, params object[] args) {
         return new SqlBuilder().WITH(format, args);
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

      public static SqlBuilder WITH(SqlBuilder subQuery, string alias) {
         return new SqlBuilder().WITH(subQuery, alias);
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

      public static SqlBuilder SELECT(string format, params object[] args) {
         return new SqlBuilder().SELECT(format, args);
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

      public static SqlBuilder INSERT_INTO(string format, params object[] args) {
         return new SqlBuilder().INSERT_INTO(format, args);
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

      public static SqlBuilder UPDATE(string format, params object[] args) {
         return new SqlBuilder().UPDATE(format, args);
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

      public static SqlBuilder DELETE_FROM(string format, params object[] args) {
         return new SqlBuilder().DELETE_FROM(format, args);
      }

      /// <inheritdoc cref="List(object[])"/>

      public static object List(IEnumerable values) {
         return new SqlList(values);
      }

      /// <summary>
      /// Returns a special parameter value that is expanded into a list of comma-separated placeholder items.
      /// </summary>
      /// <param name="values">The values to expand into a list.</param>
      /// <returns>A special object to be used as parameter in <see cref="SqlBuilder"/>.</returns>
      /// <remarks>
      /// <para>
      /// For example:
      /// </para>
      /// <code>
      /// var query = SQL
      ///    .SELECT("{0} IN ({1})", "a", SQL.List("a", "b", "c"));
      /// 
      /// Console.WriteLine(query.ToString());
      /// </code>
      /// <para>
      /// The above code outputs: <c>SELECT {0} IN ({1}, {2}, {3})</c>
      /// </para>
      /// </remarks>

      public static object List(params object[] values) {
         return new SqlList(values);
      }

      #region Object Members

      /// <exclude/>

      [EditorBrowsable(EditorBrowsableState.Never)]
      public static new bool Equals(object objectA, object objectB) {
         return Object.Equals(objectA, objectB);
      }

      /// <exclude/>

      [EditorBrowsable(EditorBrowsableState.Never)]
      public static new bool ReferenceEquals(object objectA, object objectB) {
         return Object.ReferenceEquals(objectA, objectB);
      }

      #endregion
   }

   class SqlList {

      object[] values;

      public object this[int index] => values[index];

      public int Count => values.Length;

      public SqlList(IEnumerable values) {

         object[] arr = values?.Cast<object>()
            .ToArray();

         if (arr == null
            || arr.Length == 0) {

            // ensuring at least one item to avoid building an empty list
            // e.g. foo IN ()

            arr = new object[1] { null };
         }

         this.values = arr;
      }
   }
}
