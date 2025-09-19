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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DbExtensions;

using InterpolatedString = InterpolatedStringHandlerArgumentAttribute;

#nullable enable

interface ISqlFragment {

   IList<object?>
   ParameterValues { get; }

   string
   ToString();
}

/// <summary>
/// Represents a mutable SQL string.
/// </summary>
/// <remarks>For information on how to use SqlBuilder see <see href="https://maxtoroq.github.io/DbExtensions/docs/7/SqlBuilder.html">SqlBuilder Tutorial</see>.</remarks>

[CLSCompliant(true)]
[DebuggerDisplay($"{{{nameof(Buffer)}}}")]
[InterpolatedStringHandler]
public sealed partial class SqlBuilder : ISqlFragment {

   const int
   _defaultCapacity = 48;

   bool?
   _ifCondition;

   /// <summary>
   /// The underlying <see cref="StringBuilder"/>.
   /// </summary>

   public StringBuilder
   Buffer { get; }

   /// <summary>
   /// The parameter objects to be included in the database command.
   /// </summary>

   public Collection<object?>
   ParameterValues { get; }

   IList<object?>
   ISqlFragment.ParameterValues => ParameterValues;

   /// <summary>
   /// Gets or sets the current SQL clause, used to identify consecutive 
   /// appends to the same clause.
   /// </summary>

   public SqlClause?
   CurrentClause { get; set; }

   /// <summary>
   /// Gets or sets the next SQL clause. Used by clause continuation methods,
   /// such as <see cref="_(String)"/> and <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>

   public SqlClause?
   NextClause { get; set; }

   /// <summary>
   /// Returns true if the buffer is empty.
   /// </summary>

   public bool
   IsEmpty => Buffer.Length == 0;

   internal bool
   ElseOK => _ifCondition == false;

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

   public static SqlBuilder
   JoinSql(string? separator, params SqlBuilder?[] values) {

      ArgumentNullException.ThrowIfNull(values);

      var sql = new SqlBuilder();

      if (values.Length == 0) {
         return sql;
      }

      separator ??= String.Empty;

      var first = values[0];

      if (first is not null) {
         sql.Append(first);
      }

      for (int i = 1; i < values.Length; i++) {

         sql.Append(separator);

         var val = values[i];

         if (val is not null) {
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

   public static SqlBuilder
   JoinSql(string? separator, IEnumerable<SqlBuilder?> values) {

      ArgumentNullException.ThrowIfNull(values);

      var sql = new SqlBuilder();

      separator ??= String.Empty;

      using (var enumerator = values.GetEnumerator()) {

         if (!enumerator.MoveNext()) {
            return sql;
         }

         if (enumerator.Current is not null) {
            sql.Append(enumerator.Current);
         }

         while (enumerator.MoveNext()) {

            sql.Append(separator);

            if (enumerator.Current is not null) {
               sql.Append(enumerator.Current);
            }
         }
      }

      return sql;
   }

   /// <summary>
   /// Initializes a new instance of the <see cref="SqlBuilder"/> class
   /// using the provided interpolated string.
   /// </summary>
   /// <param name="handler">The interpolated string.</param>

   public static SqlBuilder
   Create([InterpolatedString] ref AppendStringHandler handler) =>
      handler.Builder;

   /// <summary>
   /// Initializes a new instance of the <see cref="SqlBuilder"/> class
   /// using the provided text.
   /// </summary>
   /// <param name="text">The SQL string.</param>

   public static SqlBuilder
   Create(string? text) {

      if (String.IsNullOrEmpty(text)) {
         return new SqlBuilder();
      }

      return new SqlBuilder(Math.Max(_defaultCapacity, text.Length))
         .Append(text);
   }

   /// <summary>
   /// Initializes a new instance of the <see cref="SqlBuilder"/> class.
   /// </summary>

   public
   SqlBuilder()
      : this(_defaultCapacity) { }

   private
   SqlBuilder(int capacity) {

      this.Buffer = new(capacity);
      this.ParameterValues = new();
   }

   private
   SqlBuilder(SqlBuilder other) {

      ArgumentNullException.ThrowIfNull(other);

      // When you clone a builder you most likely want to modify the clone,
      // therefore use default capacity as min.

      this.Buffer = new(Math.Max(_defaultCapacity, other.Buffer.Capacity));
      this.Buffer.Append(other.Buffer);
      this.ParameterValues = new(new List<object?>(other.ParameterValues));
      this.CurrentClause = other.CurrentClause;
      this.NextClause = other.NextClause;
      _ifCondition = other._ifCondition;
   }

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public
   SqlBuilder(int literalLength, int formattedCount) {

      // This constructor is used by interpolated string arguments.
      // Since these are literal "string" arguments, the query is most likely not
      // modified. Therefore we use a "static" capacity and ignore the default
      // capacity (although the interpolated string could still use sub-queries and
      // dynamic literals that make the query grow).

      this.Buffer = new(literalLength + PlaceholderLengthSum(formattedCount));
      this.ParameterValues = new(new List<object?>(formattedCount));
   }

   static int
   PlaceholderLengthSum(int formattedCount) {

      var result = 0;

      for (var i = 0; i < formattedCount; i++) {
         result += i switch {
            < 10 => 1,
            < 100 => 2,
            < 1_000 => 3,
            < 10_000 => 4,
            < 100_000 => 5,
            < 1_000_000 => 6,
            < 10_000_000 => 7,
            < 100_000_000 => 8,
            < 1_000_000_000 => 9,
            _ => 10
         } + 2;
      }

      return result;
   }

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public void
   AppendLiteral(string value) =>
      this.Buffer.Append(value);

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public void
   AppendFormatted(object? value, int alignment = 0, string? format = null) =>
      AppendPlaceholder(value, format);

   /// <summary>
   /// Appends the SQL clause identified by <typeparamref name="TClause"/>.
   /// </summary>
   /// <typeparam name="TClause">The type of the SQL clause.</typeparam>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   AppendClause<TClause>() where TClause : SqlClause, new() =>
      AppendClause(SqlClause.Instance<TClause>(), null);

   /// <summary>
   /// Appends the SQL clause identified by <typeparamref name="TClause"/> and
   /// appends the interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <typeparam name="TClause">The type of the SQL clause.</typeparam>
   /// <param name="handler">The interpolated string to append.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   AppendClause<TClause>([InterpolatedString("")] ref ClauseStringHandler<TClause> handler) where TClause : SqlClause, new() =>
      this;

   /// <summary>
   /// Appends the SQL clause identified by <typeparamref name="TClause"/> and
   /// appends the <paramref name="text"/>.
   /// </summary>
   /// <typeparam name="TClause">The type of the SQL clause.</typeparam>
   /// <param name="text">The text to append.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   AppendClause<TClause>(string? text) where TClause : SqlClause, new() =>
      AppendClause(SqlClause.Instance<TClause>(), text);

   /// <summary>
   /// Appends the SQL <paramref name="clause"/>.
   /// </summary>
   /// <param name="clause">The clause to append.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   AppendClause(SqlClause clause) =>
      AppendClause(clause, null);

   /// <summary>
   /// Appends the SQL <paramref name="clause"/> and the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="clause">The clause to append.</param>
   /// <param name="text">The text to append.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   AppendClause(SqlClause clause, string? text) {

      ArgumentNullException.ThrowIfNull(clause);

      if (clause is SqlClause.Current) {
         clause = this.NextClause
            ?? this.CurrentClause
            ?? throw new InvalidOperationException();
      }

      if (clause.Separator is null
         || !String.Equals(clause.Name, this.CurrentClause?.Name, StringComparison.OrdinalIgnoreCase)) {

         if (!this.IsEmpty) {
            this.Buffer.AppendLine();
         }

         if (clause.Name is { } name) {
            this.Buffer.Append(name)
               .Append(' ');
         }

      } else if (clause.Separator is { } sep) {
         this.Buffer.Append(sep);
      }

      this.Buffer.Append(text);

      this.CurrentClause = clause;
      this.NextClause = null;
      _ifCondition = null;

      return this;
   }

   /// <summary>
   /// Appends <paramref name="sql"/> to this instance.
   /// </summary>
   /// <param name="sql">A <see cref="SqlBuilder"/>.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   Append(SqlBuilder sql) {

      ArgumentNullException.ThrowIfNull(sql);

      AppendSql(sql, this.Buffer);
      return this;
   }

   internal SqlBuilder
   Append(ISqlFragment sql) {

      AppendSql(sql, this.Buffer);
      return this;
   }

   void
   AppendSql(ISqlFragment sql, StringBuilder sb) {

      if (sql.ParameterValues.Count == 0) {

         if (sql is SqlBuilder sqlB) {
            sb.Append(sqlB.Buffer);
         } else {
            sb.Append(sql.ToString());
         }

         return;
      }

      sb.AppendFormat(
         CultureInfo.InvariantCulture,
         sql.ToString(),
         Enumerable.Range(0, sql.ParameterValues.Count)
            .Select(x => $"{{{this.ParameterValues.Count + x}}}")
            .ToArray());

      foreach (var param in sql.ParameterValues) {
         this.ParameterValues.Add(param);
      }
   }

   /// <summary>
   /// Appends the interpolated string <paramref name="handler"/> to this instance.
   /// </summary>
   /// <param name="handler">The interpolated string.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   Append([InterpolatedString("")] ref AppendStringHandler handler) =>
      this;

   /// <summary>
   /// Appends <paramref name="text"/> to this instance.
   /// </summary>
   /// <param name="text">The string.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   Append(string? text) {

      this.Buffer.Append(text);
      return this;
   }

   internal void
   AppendPlaceholder(object? value, string? format) {

      if (format == "sql") {
         this.Buffer.Append(CultureInfo.InvariantCulture, $"{value}");
         return;
      }

      if (format == "list") {

         var items = (value as IEnumerable<object?>
            ?? (value as IEnumerable)?.Cast<object?>()
            ?? [])
            .DefaultIfEmpty();

         var first = true;

         foreach (var item in items) {

            if (!first) {
               this.Buffer.Append(',')
                  .Append(' ');
            }

            this.Buffer.Append('{')
               .Append(this.ParameterValues.Count)
               .Append('}');

            this.ParameterValues.Add(item);

            first = false;
         }

         return;
      }

      var sql = value as SqlBuilder;

      if (sql is null) {
         GetDefiningQueryFromObject(value, ref sql);
      }

      if (sql is not null) {
         AppendPlaceholderSql(sql);
         return;
      }

      this.Buffer.Append('{')
         .Append(this.ParameterValues.Count)
         .Append('}');

      this.ParameterValues.Add(value);
   }

   void
   AppendPlaceholderSql(SqlBuilder value) {

      var frag = new StringBuilder();
      AppendSql(value, frag);
      frag.Replace(Environment.NewLine, $"{Environment.NewLine}\t");

      this.Buffer.AppendLine()
         .Append(frag);
   }

   static partial void
   GetDefiningQueryFromObject(object? obj, ref SqlBuilder? definingQuery);

   /// <summary>
   /// Appends the default line terminator to this instance.
   /// </summary>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   AppendLine() {

      this.Buffer.AppendLine();
      return this;
   }

   /// <summary>
   /// Inserts a string into this instance at the specified character position.
   /// </summary>
   /// <param name="index">The position in this instance where insertion begins.</param>
   /// <param name="value">The string to insert.</param>
   /// <returns>A reference to this instance after the insert operation has completed.</returns>

   public SqlBuilder
   InsertText(int index, string? value) {

      this.Buffer.Insert(index, value);
      return this;
   }

   /// <summary>
   /// Sets the clause identified by <typeparamref name="TClause"/> as the current SQL clause.
   /// </summary>
   /// <typeparam name="TClause">The type of the SQL clause.</typeparam>
   /// <returns>A reference to this instance after the operation has completed.</returns>
   /// <seealso cref="CurrentClause"/>

   public SqlBuilder
   SetCurrentClause<TClause>() where TClause : SqlClause, new() =>
      SetCurrentClause(SqlClause.Instance<TClause>());

   /// <summary>
   /// Sets <paramref name="clause"/> as the current SQL clause.
   /// </summary>
   /// <param name="clause">The SQL clause.</param>
   /// <returns>A reference to this instance after the operation has completed.</returns>
   /// <seealso cref="CurrentClause"/>

   public SqlBuilder
   SetCurrentClause(SqlClause? clause) {

      this.CurrentClause = clause;
      return this;
   }

   /// <summary>
   /// Sets the clause identified by <typeparamref name="TClause"/> as the next SQL clause.
   /// </summary>
   /// <typeparam name="TClause">The type of the SQL clause.</typeparam>
   /// <returns>A reference to this instance after the operation has completed.</returns>
   /// <seealso cref="NextClause"/>

   public SqlBuilder
   SetNextClause<TClause>() where TClause : SqlClause, new() =>
      SetNextClause(SqlClause.Instance<TClause>());

   /// <summary>
   /// Sets <paramref name="clause"/> as the next SQL clause.
   /// </summary>
   /// <param name="clause">The SQL clause.</param>
   /// <returns>A reference to this instance after the operation has completed.</returns>
   /// <seealso cref="NextClause"/>

   public SqlBuilder
   SetNextClause(SqlClause? clause) {

      this.NextClause = clause;
      _ifCondition = null;

      return this;
   }

   /// <summary>
   /// Converts the value of this instance to a <see cref="String"/>.
   /// </summary>
   /// <returns>A string whose value is the same as this instance.</returns>

   public override string
   ToString() => this.Buffer.ToString();

   /// <summary>
   /// Creates and returns a copy of this instance.
   /// </summary>
   /// <returns>A new <see cref="SqlBuilder"/> that is equivalent to this instance.</returns>

   public SqlBuilder
   Clone() => new SqlBuilder(this);

#pragma warning disable IDE1006
   /// <summary>
   /// Appends the interpolated string <paramref name="handler"/> to the current clause.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the current clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   [CLSCompliant(false)]
   public SqlBuilder
   _([InterpolatedString("")] ref ClauseStringHandler<SqlClause.Current> handler) =>
      this;

   /// <summary>
   /// Appends the <paramref name="text"/> to the current clause.
   /// </summary>
   /// <param name="text">The text that represents the body of the current clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   [CLSCompliant(false)]
   public SqlBuilder
   _(string? text) =>
      AppendClause<SqlClause.Current>(text);

   /// <summary>
   /// Appends the interpolated string <paramref name="handler"/> to the current clause if <paramref name="condition"/> is true.
   /// </summary>
   /// <param name="condition">true to append <paramref name="handler"/> to the current clause; otherwise, false.</param>
   /// <param name="handler">The interpolated string that represents the body of the current clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   [CLSCompliant(false)]
   public SqlBuilder
   _If(bool condition, [InterpolatedString("", nameof(condition))] ref ConditionalStringHandler handler) {

      _ifCondition = condition;

      return this;
   }

   /// <summary>
   /// Appends <paramref name="handler"/> to the current clause if <paramref name="condition"/> is true
   /// and an antecedent call to <see cref="_If(Boolean, ref ConditionalStringHandler)"/>
   /// or <see cref="_ElseIf(Boolean, ref ConditionalElseStringHandler)"/> used a false condition.
   /// </summary>
   /// <inheritdoc cref="_If(Boolean, ref ConditionalStringHandler)" path="*[not(self::summary)]"/>

   [CLSCompliant(false)]
   public SqlBuilder
   _ElseIf(bool condition, [InterpolatedString("", nameof(condition))] ref ConditionalElseStringHandler handler) {

      if (this.ElseOK) {
         _ifCondition = condition;
      }

      return this;
   }

   /// <summary>
   /// Appends <paramref name="handler"/> to the current clause if an antecedent call to
   /// <see cref="_If(Boolean, ref ConditionalStringHandler)"/>
   /// or <see cref="_ElseIf(Boolean, ref ConditionalElseStringHandler)"/> used a
   /// false condition
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the current clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   [CLSCompliant(false)]
   public SqlBuilder
   _Else([InterpolatedString("")] ref ConditionalElseStringHandler handler) =>
      this;
#pragma warning restore IDE1006

   /// <summary>
   /// Appends the WITH clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the WITH clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   WITH([InterpolatedString("")] ref ClauseStringHandler<SqlClause.WITH> handler) =>
      this;

   /// <summary>
   /// Appends the WITH clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the WITH clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   WITH(string? text) =>
      AppendClause<SqlClause.WITH>(text);

   /// <summary>
   /// Appends the WITH clause using the provided <paramref name="subQuery"/> as body named after
   /// <paramref name="alias"/>.
   /// </summary>
   /// <param name="subQuery">The sub-query to use as the body of the WITH clause.</param>
   /// <param name="alias">The alias of the sub-query.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   WITH(string alias, SqlBuilder subQuery) {

      ArgumentNullException.ThrowIfNull(alias);
      ArgumentNullException.ThrowIfNull(subQuery);

      AppendClause<SqlClause.WITH>();

      this.Buffer.Append(alias)
         .Append(" AS (");
      AppendPlaceholderSql(subQuery);
      this.Buffer.Append(')');

      return this;
   }

   /// <summary>
   /// Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods,
   /// such as <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>
   /// <returns>A reference to this instance after the operation has completed.</returns>

   public SqlBuilder
   SELECT() =>
      SetNextClause<SqlClause.SELECT>();

   /// <summary>
   /// Appends the SELECT clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the SELECT clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   SELECT([InterpolatedString("")] ref ClauseStringHandler<SqlClause.SELECT> handler) =>
      this;

   /// <summary>
   /// Appends the SELECT clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the SELECT clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   SELECT(string? text) =>
      AppendClause<SqlClause.SELECT>(text);

   /// <summary>
   /// Sets FROM as the next clause, to be used by subsequent calls to clause continuation methods,
   /// such as <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>
   /// <returns>A reference to this instance after the operation has completed.</returns>

   public SqlBuilder
   FROM() =>
      SetNextClause<SqlClause.FROM>();

   /// <summary>
   /// Appends the FROM clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the FROM clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   FROM([InterpolatedString("")] ref ClauseStringHandler<SqlClause.FROM> handler) =>
      this;

   /// <summary>
   /// Appends the FROM clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the FROM clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   FROM(string? text) =>
      AppendClause<SqlClause.FROM>(text);

   /// <summary>
   /// Appends the FROM clause using the provided <paramref name="subQuery"/> as body named after
   /// <paramref name="alias"/>.
   /// </summary>
   /// <param name="subQuery">The sub-query to use as the body of the FROM clause.</param>
   /// <param name="alias">The alias of the sub-query.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   FROM(SqlBuilder subQuery, string alias) {

      ArgumentNullException.ThrowIfNull(subQuery);
      ArgumentNullException.ThrowIfNull(alias);

      AppendClause<SqlClause.FROM>();

      this.Buffer.Append('(');
      AppendPlaceholderSql(subQuery);
      this.Buffer.Append(") AS ")
         .Append(alias);

      return this;
   }

   /// <summary>
   /// Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods,
   /// such as <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>
   /// <returns>A reference to this instance after the operation has completed.</returns>

   public SqlBuilder
   JOIN() =>
      SetNextClause<SqlClause.JOIN>();

   /// <summary>
   /// Appends the JOIN clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the JOIN clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   JOIN([InterpolatedString("")] ref ClauseStringHandler<SqlClause.JOIN> handler) =>
      this;

   /// <summary>
   /// Appends the JOIN clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the JOIN clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   JOIN(string? text) =>
      AppendClause<SqlClause.JOIN>(text);

   /// <summary>
   /// Sets LEFT JOIN as the next clause, to be used by subsequent calls to clause continuation methods,
   /// such as <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>
   /// <returns>A reference to this instance after the operation has completed.</returns>

   public SqlBuilder
   LEFT_JOIN() =>
      SetNextClause<SqlClause.LEFT_JOIN>();

   /// <summary>
   /// Appends the LEFT JOIN clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the LEFT JOIN clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   LEFT_JOIN([InterpolatedString("")] ref ClauseStringHandler<SqlClause.LEFT_JOIN> handler) =>
      this;

   /// <summary>
   /// Appends the LEFT JOIN clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the LEFT JOIN clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   LEFT_JOIN(string? text) =>
      AppendClause<SqlClause.LEFT_JOIN>(text);

   /// <summary>
   /// Sets RIGHT JOIN as the next clause, to be used by subsequent calls to clause continuation methods,
   /// such as <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>
   /// <returns>A reference to this instance after the operation has completed.</returns>

   public SqlBuilder
   RIGHT_JOIN() =>
      SetNextClause<SqlClause.RIGHT_JOIN>();

   /// <summary>
   /// Appends the RIGHT JOIN clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the RIGHT JOIN clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   RIGHT_JOIN([InterpolatedString("")] ref ClauseStringHandler<SqlClause.RIGHT_JOIN> handler) =>
      this;

   /// <summary>
   /// Appends the RIGHT JOIN clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the RIGHT JOIN clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   RIGHT_JOIN(string? text) =>
      AppendClause<SqlClause.RIGHT_JOIN>(text);

   /// <summary>
   /// Sets INNER JOIN as the next clause, to be used by subsequent calls to clause continuation methods,
   /// such as <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>
   /// <returns>A reference to this instance after the operation has completed.</returns>

   public SqlBuilder
   INNER_JOIN() =>
      SetNextClause<SqlClause.INNER_JOIN>();

   /// <summary>
   /// Appends the INNER JOIN clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the INNER JOIN clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   INNER_JOIN([InterpolatedString("")] ref ClauseStringHandler<SqlClause.INNER_JOIN> handler) =>
      this;

   /// <summary>
   /// Appends the INNER JOIN clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the INNER JOIN clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   INNER_JOIN(string? text) =>
      AppendClause<SqlClause.INNER_JOIN>(text);

   /// <summary>
   /// Sets CROSS JOIN as the next clause, to be used by subsequent calls to clause continuation methods,
   /// such as <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>
   /// <returns>A reference to this instance after the operation has completed.</returns>

   public SqlBuilder
   CROSS_JOIN() =>
      SetNextClause<SqlClause.CROSS_JOIN>();

   /// <summary>
   /// Appends the CROSS JOIN clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the CROSS JOIN clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   CROSS_JOIN([InterpolatedString("")] ref ClauseStringHandler<SqlClause.CROSS_JOIN> handler) =>
      this;

   /// <summary>
   /// Appends the CROSS JOIN clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the CROSS JOIN clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   CROSS_JOIN(string? text) =>
      AppendClause<SqlClause.CROSS_JOIN>(text);

   /// <summary>
   /// Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods,
   /// such as <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>
   /// <returns>A reference to this instance after the operation has completed.</returns>

   public SqlBuilder
   WHERE() =>
      SetNextClause<SqlClause.WHERE>();

   /// <summary>
   /// Appends the WHERE clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the WHERE clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   WHERE([InterpolatedString("")] ref ClauseStringHandler<SqlClause.WHERE> handler) =>
      this;

   /// <summary>
   /// Appends the WHERE clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the WHERE clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   WHERE(string? text) =>
      AppendClause<SqlClause.WHERE>(text);

   /// <summary>
   /// Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods,
   /// such as <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>
   /// <returns>A reference to this instance after the operation has completed.</returns>

   public SqlBuilder
   GROUP_BY() =>
      SetNextClause<SqlClause.GROUP_BY>();

   /// <summary>
   /// Appends the GROUP BY clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the GROUP BY clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   GROUP_BY([InterpolatedString("")] ref ClauseStringHandler<SqlClause.GROUP_BY> handler) =>
      this;

   /// <summary>
   /// Appends the GROUP BY clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the GROUP BY clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   GROUP_BY(string? text) =>
      AppendClause<SqlClause.GROUP_BY>(text);

   /// <summary>
   /// Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods,
   /// such as <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>
   /// <returns>A reference to this instance after the operation has completed.</returns>

   public SqlBuilder
   HAVING() =>
      SetNextClause<SqlClause.HAVING>();

   /// <summary>
   /// Appends the HAVING clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the HAVING clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   HAVING([InterpolatedString("")] ref ClauseStringHandler<SqlClause.HAVING> handler) =>
      this;

   /// <summary>
   /// Appends the HAVING clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the HAVING clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   HAVING(string? text) =>
      AppendClause<SqlClause.HAVING>(text);

   /// <summary>
   /// Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods,
   /// such as <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>
   /// <returns>A reference to this instance after the operation has completed.</returns>

   public SqlBuilder
   ORDER_BY() =>
      SetNextClause<SqlClause.ORDER_BY>();

   /// <summary>
   /// Appends the ORDER BY clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the ORDER BY clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   ORDER_BY([InterpolatedString("")] ref ClauseStringHandler<SqlClause.ORDER_BY> handler) =>
      this;

   /// <summary>
   /// Appends the ORDER BY clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the ORDER BY clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   ORDER_BY(string? text) =>
      AppendClause<SqlClause.ORDER_BY>(text);

   /// <summary>
   /// Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods,
   /// such as <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>
   /// <returns>A reference to this instance after the operation has completed.</returns>

   public SqlBuilder
   LIMIT() =>
      SetNextClause<SqlClause.LIMIT>();

   /// <summary>
   /// Appends the LIMIT clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the LIMIT clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   LIMIT([InterpolatedString("")] ref ClauseStringHandler<SqlClause.LIMIT> handler) =>
      this;

   /// <summary>
   /// Appends the LIMIT clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the LIMIT clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   LIMIT(string? text) =>
      AppendClause<SqlClause.LIMIT>(text);

   /// <summary>
   /// Appends the LIMIT clause using the provided <paramref name="maxRecords"/> parameter.
   /// </summary>
   /// <param name="maxRecords">The value to use as parameter.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   LIMIT(int maxRecords) {

      AppendClause<SqlClause.LIMIT>();

      this.Buffer.Append('{')
         .Append(this.ParameterValues.Count)
         .Append('}');

      this.ParameterValues.Add(maxRecords);

      return this;
   }

   /// <summary>
   /// Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods,
   /// such as <see cref="_If(Boolean, ref ConditionalStringHandler)"/>.
   /// </summary>
   /// <returns>A reference to this instance after the operation has completed.</returns>

   public SqlBuilder
   OFFSET() =>
      SetNextClause<SqlClause.OFFSET>();

   /// <summary>
   /// Appends the OFFSET clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the OFFSET clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   OFFSET([InterpolatedString("")] ref ClauseStringHandler<SqlClause.OFFSET> handler) =>
      this;

   /// <summary>
   /// Appends the OFFSET clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the OFFSET clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   OFFSET(string? text) =>
      AppendClause<SqlClause.OFFSET>(text);

   /// <summary>
   /// Appends the OFFSET clause using the provided <paramref name="startIndex"/> parameter.
   /// </summary>
   /// <param name="startIndex">The value to use as parameter.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   OFFSET(int startIndex) {

      AppendClause<SqlClause.OFFSET>();

      this.Buffer.Append('{')
         .Append(this.ParameterValues.Count)
         .Append('}');

      this.ParameterValues.Add(startIndex);

      return this;
   }

   /// <summary>
   /// Appends the UNION clause.
   /// </summary>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   UNION() =>
      AppendClause<SqlClause.UNION>();

   /// <summary>
   /// Appends the INSERT INTO clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the INSERT INTO clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   INSERT_INTO([InterpolatedString("")] ref ClauseStringHandler<SqlClause.INSERT_INTO> handler) =>
      this;

   /// <summary>
   /// Appends the INSERT INTO clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the INSERT INTO clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   INSERT_INTO(string? text) =>
      AppendClause<SqlClause.INSERT_INTO>(text);

   /// <summary>
   /// Appends the DELETE FROM clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the DELETE FROM clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   DELETE_FROM([InterpolatedString("")] ref ClauseStringHandler<SqlClause.DELETE_FROM> handler) =>
      this;

   /// <summary>
   /// Appends the DELETE FROM clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the DELETE FROM clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   DELETE_FROM(string? text) =>
      AppendClause<SqlClause.DELETE_FROM>(text);

   /// <summary>
   /// Appends the UPDATE clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the UPDATE clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   UPDATE([InterpolatedString("")] ref ClauseStringHandler<SqlClause.UPDATE> handler) =>
      this;

   /// <summary>
   /// Appends the UPDATE clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the UPDATE clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   UPDATE(string? text) =>
      AppendClause<SqlClause.UPDATE>(text);

   /// <summary>
   /// Appends the SET clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the SET clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   SET([InterpolatedString("")] ref ClauseStringHandler<SqlClause.SET> handler) =>
      this;

   /// <summary>
   /// Appends the SET clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The text that represents the body of the SET clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   SET(string? text) =>
      AppendClause<SqlClause.SET>(text);

   /// <summary>
   /// Appends the VALUES clause using the provided interpolated string <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The interpolated string that represents the body of the VALUES clause.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   VALUES([InterpolatedString("")] ref ClauseStringHandler<SqlClause.VALUES> handler) =>
      this;

   /// <summary>
   /// Appends the VALUES clause using the provided parameters.
   /// </summary>
   /// <param name="args">The parameters of the clause body.</param>
   /// <returns>A reference to this instance after the append operation has completed.</returns>

   public SqlBuilder
   VALUES(params object?[] args) {

      ArgumentNullException.ThrowIfNull(args);

      if (args.Length == 0) {
         throw new ArgumentException($"{nameof(args)} cannot be empty", nameof(args));
      }

      AppendClause<SqlClause.VALUES>();

      this.Buffer.Append('(');

      for (int i = 0; i < args.Length; i++) {

         if (i > 0) {
            this.Buffer.Append(',')
               .Append(' ');
         }

         this.Buffer.Append('{')
            .Append(this.ParameterValues.Count)
            .Append('}');

         this.ParameterValues.Add(args[i]);
      }

      this.Buffer.Append(')');

      return this;
   }

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   [InterpolatedStringHandler]
   public struct AppendStringHandler {

      internal SqlBuilder
      Builder { get; }

      /// <exclude/>

      public
      AppendStringHandler(int literalLength, int formattedCount) {

         // This constructor is used for Create(ref AppendInterpolatedStringHandler).
         // Capacity used is consistent with Create(String).

         this.Builder = new(Math.Max(
            _defaultCapacity,
            literalLength + PlaceholderLengthSum(formattedCount)));
      }

      /// <exclude/>

      public
      AppendStringHandler(int literalLength, int formattedCount, SqlBuilder sqlBuilder) {

         ArgumentNullException.ThrowIfNull(sqlBuilder);

         this.Builder = sqlBuilder;
      }

      /// <exclude/>

      public void
      AppendLiteral(string value) =>
         this.Builder.Buffer.Append(value);

      /// <exclude/>

      public void
      AppendFormatted(object? value, int alignment = 0, string? format = null) =>
         this.Builder.AppendPlaceholder(value, format);
   }

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   [InterpolatedStringHandler]
   public struct ClauseStringHandler<TClause> where TClause : SqlClause, new() {

      internal SqlBuilder
      Builder { get; }

      /// <exclude/>

      public
      ClauseStringHandler(int literalLength, int formattedCount)
         : this(literalLength, formattedCount, new()) { }

      /// <exclude/>

      public
      ClauseStringHandler(int literalLength, int formattedCount, SqlBuilder sqlBuilder) {

         ArgumentNullException.ThrowIfNull(sqlBuilder);

         this.Builder = sqlBuilder;

         sqlBuilder.AppendClause<TClause>();
      }

      /// <exclude/>

      public void
      AppendLiteral(string value) =>
         this.Builder.Buffer.Append(value);

      /// <exclude/>

      public void
      AppendFormatted(object? value, int alignment = 0, string? format = null) =>
         this.Builder.AppendPlaceholder(value, format);
   }

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   [InterpolatedStringHandler]
   public struct ConditionalStringHandler {

      readonly SqlBuilder
      _sqlBuilder;

      /// <exclude/>

      public
      ConditionalStringHandler(int literalLength, int formattedCount, SqlBuilder sqlBuilder, bool condition, out bool shouldAppend) {

         ArgumentNullException.ThrowIfNull(sqlBuilder);

         _sqlBuilder = sqlBuilder;

         shouldAppend = condition;

         if (shouldAppend) {
            sqlBuilder.AppendClause<SqlClause.Current>();
         }
      }

      /// <exclude/>

      public void
      AppendLiteral(string value) =>
         _sqlBuilder.Buffer.Append(value);

      /// <exclude/>

      public void
      AppendFormatted(object? value, int alignment = 0, string? format = null) =>
         _sqlBuilder.AppendPlaceholder(value, format);
   }

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   [InterpolatedStringHandler]
   public struct ConditionalElseStringHandler {

      readonly SqlBuilder
      _sqlBuilder;

      /// <exclude/>

      public
      ConditionalElseStringHandler(int literalLength, int formattedCount, SqlBuilder sqlBuilder, out bool shouldAppend)
         : this(literalLength, formattedCount, sqlBuilder, true, out shouldAppend) { }

      /// <exclude/>

      public
      ConditionalElseStringHandler(int literalLength, int formattedCount, SqlBuilder sqlBuilder, bool condition, out bool shouldAppend) {

         ArgumentNullException.ThrowIfNull(sqlBuilder);

         _sqlBuilder = sqlBuilder;

         condition = condition
            && sqlBuilder.ElseOK;

         shouldAppend = condition;

         if (shouldAppend) {
            sqlBuilder.AppendClause<SqlClause.Current>();
         }
      }

      /// <exclude/>

      public void
      AppendLiteral(string value) =>
         _sqlBuilder.Buffer.Append(value);

      /// <exclude/>

      public void
      AppendFormatted(object? value, int alignment = 0, string? format = null) =>
         _sqlBuilder.AppendPlaceholder(value, format);
   }
}

/// <summary>
/// Provides a set of static (Shared in Visual Basic) methods to create <see cref="SqlBuilder"/>
/// instances.
/// </summary>

public static partial class SQL {

   /// <summary>
   /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
   /// appending the WITH clause using the provided string interpolated <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The body of the WITH clause.</param>
   /// <returns>
   /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.WITH(ref SqlBuilder.ClauseStringHandler&lt;SqlClause.WITH>)"/>.
   /// </returns>

   public static SqlBuilder
   WITH([InterpolatedString] ref SqlBuilder.ClauseStringHandler<SqlClause.WITH> handler) =>
      handler.Builder;

   /// <summary>
   /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
   /// appending the WITH clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The body of the WITH clause.</param>
   /// <returns>
   /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.WITH(String)"/>.
   /// </returns>

   public static SqlBuilder
   WITH(string? text) =>
      new SqlBuilder().WITH(text);

   /// <summary>
   /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
   /// appending the WITH clause using the provided <paramref name="subQuery"/>
   /// and <paramref name="alias"/>.
   /// </summary>
   /// <param name="alias">The alias of the sub-query.</param>
   /// <param name="subQuery">The sub-query to use as the body of the WITH clause.</param>
   /// <returns>
   /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.WITH(string, SqlBuilder)"/>.
   /// </returns>

   public static SqlBuilder
   WITH(string alias, SqlBuilder subQuery) {

      ArgumentNullException.ThrowIfNull(alias);
      ArgumentNullException.ThrowIfNull(subQuery);

      return new SqlBuilder().WITH(alias, subQuery);
   }

   /// <summary>
   /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
   /// appending the SELECT clause using the provided string interpolated <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The body of the SELECT clause.</param>
   /// <returns>
   /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.SELECT(ref SqlBuilder.ClauseStringHandler&lt;SqlClause.SELECT>)"/>.
   /// </returns>

   public static SqlBuilder
   SELECT([InterpolatedString] ref SqlBuilder.ClauseStringHandler<SqlClause.SELECT> handler) =>
      handler.Builder;

   /// <summary>
   /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
   /// appending the SELECT clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The body of the SELECT clause.</param>
   /// <returns>
   /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.SELECT(String)"/>.
   /// </returns>

   public static SqlBuilder
   SELECT(string? text) =>
      new SqlBuilder().SELECT(text);

   /// <summary>
   /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
   /// appending the INSERT INTO clause using the provided string interpolated <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The body of the INSERT INTO clause.</param>
   /// <returns>
   /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.INSERT_INTO(ref SqlBuilder.ClauseStringHandler&lt;SqlClause.INSERT_INTO>)"/>.
   /// </returns>

   public static SqlBuilder
   INSERT_INTO([InterpolatedString] ref SqlBuilder.ClauseStringHandler<SqlClause.INSERT_INTO> handler) =>
      handler.Builder;

   /// <summary>
   /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
   /// appending the INSERT INTO clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The body of the INSERT INTO clause.</param>
   /// <returns>
   /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.INSERT_INTO(String)"/>.
   /// </returns>

   public static SqlBuilder
   INSERT_INTO(string? text) =>
      new SqlBuilder().INSERT_INTO(text);

   /// <summary>
   /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
   /// appending the UPDATE clause using the provided string interpolated <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The body of the UPDATE clause.</param>
   /// <returns>
   /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.UPDATE(ref SqlBuilder.ClauseStringHandler&lt;SqlClause.UPDATE>)"/>.
   /// </returns>

   public static SqlBuilder
   UPDATE([InterpolatedString] ref SqlBuilder.ClauseStringHandler<SqlClause.UPDATE> handler) =>
      handler.Builder;

   /// <summary>
   /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
   /// appending the UPDATE clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The body of the UPDATE clause.</param>
   /// <returns>
   /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.UPDATE(String)"/>.
   /// </returns>

   public static SqlBuilder
   UPDATE(string? text) =>
      new SqlBuilder().UPDATE(text);

   /// <summary>
   /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
   /// appending the DELETE FROM clause using the provided string interpolated <paramref name="handler"/>.
   /// </summary>
   /// <param name="handler">The body of the DELETE FROM clause.</param>
   /// <returns>
   /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.DELETE_FROM(ref SqlBuilder.ClauseStringHandler&lt;SqlClause.DELETE_FROM>)"/>.
   /// </returns>

   public static SqlBuilder
   DELETE_FROM([InterpolatedString] ref SqlBuilder.ClauseStringHandler<SqlClause.DELETE_FROM> handler) =>
      handler.Builder;

   /// <summary>
   /// Creates and returns a new <see cref="SqlBuilder"/> initialized by
   /// appending the DELETE FROM clause using the provided <paramref name="text"/>.
   /// </summary>
   /// <param name="text">The body of the DELETE FROM clause.</param>
   /// <returns>
   /// A new <see cref="SqlBuilder"/> after calling <see cref="SqlBuilder.DELETE_FROM(String)"/>.
   /// </returns>

   public static SqlBuilder
   DELETE_FROM(string? text) =>
      new SqlBuilder().DELETE_FROM(text);

   // Object Members

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public static new bool
   Equals(object? objectA, object? objectB) =>
      Object.Equals(objectA, objectB);

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public static new bool
   ReferenceEquals(object? objectA, object? objectB) =>
      Object.ReferenceEquals(objectA, objectB);
}

/// <summary>
/// Provides information about a SQL clause. Used by <see cref="SqlBuilder"/>.
/// </summary>
/// <param name="Name">The name of the clause.</param>
/// <param name="Separator">The string to use for consecutive calls.</param>

public abstract record class SqlClause(string? Name, string? Separator) {

   /// <summary>
   /// The "current" clause.
   /// </summary>
   /// <exclude/>

   public sealed record class Current() : SqlClause(null, null);

   /// <summary>
   /// The WITH clause.
   /// </summary>
   /// <exclude/>

   public sealed record class WITH() : SqlClause("WITH", null);

   /// <summary>
   /// The SELECT clause.
   /// </summary>
   /// <exclude/>

   public sealed record class SELECT() : SqlClause("SELECT", ", ");

   /// <summary>
   /// The FROM clause.
   /// </summary>
   /// <exclude/>

   public sealed record class FROM() : SqlClause("FROM", ", ");

   /// <summary>
   /// The JOIN clause.
   /// </summary>
   /// <exclude/>

   public sealed record class JOIN() : SqlClause("JOIN", null);

   /// <summary>
   /// The LEFT JOIN clause.
   /// </summary>
   /// <exclude/>

   public sealed record class LEFT_JOIN() : SqlClause("LEFT JOIN", null);

   /// <summary>
   /// The RIGHT JOIN clause.
   /// </summary>
   /// <exclude/>

   public sealed record class RIGHT_JOIN() : SqlClause("RIGHT JOIN", null);

   /// <summary>
   /// The INNER JOIN clause.
   /// </summary>
   /// <exclude/>

   public sealed record class INNER_JOIN() : SqlClause("INNER JOIN", null);

   /// <summary>
   /// The CROSS JOIN clause.
   /// </summary>
   /// <exclude/>

   public sealed record class CROSS_JOIN() : SqlClause("CROSS JOIN", null);

   /// <summary>
   /// The WHERE clause.
   /// </summary>
   /// <exclude/>

   public sealed record class WHERE() : SqlClause("WHERE", " AND ");

   /// <summary>
   /// The GROUP BY clause.
   /// </summary>
   /// <exclude/>

   public sealed record class GROUP_BY() : SqlClause("GROUP BY", ", ");

   /// <summary>
   /// The HAVING clause.
   /// </summary>
   /// <exclude/>

   public sealed record class HAVING() : SqlClause("HAVING", " AND ");

   /// <summary>
   /// The ORDER BY clause.
   /// </summary>
   /// <exclude/>

   public sealed record class ORDER_BY() : SqlClause("ORDER BY", ", ");

   /// <summary>
   /// The LIMIT clause.
   /// </summary>
   /// <exclude/>

   public sealed record class LIMIT() : SqlClause("LIMIT", null);

   /// <summary>
   /// The OFFSET clause.
   /// </summary>
   /// <exclude/>

   public sealed record class OFFSET() : SqlClause("OFFSET", null);

   /// <summary>
   /// The UNION clause.
   /// </summary>
   /// <exclude/>

   public sealed record class UNION() : SqlClause("UNION", null);

   /// <summary>
   /// The INSERT INTO clause.
   /// </summary>
   /// <exclude/>

   public sealed record class INSERT_INTO() : SqlClause("INSERT INTO", null);

   /// <summary>
   /// The DELETE FROM clause.
   /// </summary>
   /// <exclude/>

   public sealed record class DELETE_FROM() : SqlClause("DELETE FROM", null);

   /// <summary>
   /// The UPDATE clause.
   /// </summary>
   /// <exclude/>

   public sealed record class UPDATE() : SqlClause("UPDATE", null);

   /// <summary>
   /// The SET clause.
   /// </summary>
   /// <exclude/>

   public sealed record class SET() : SqlClause("SET", ", ");

   /// <summary>
   /// The VALUES clause.
   /// </summary>
   /// <exclude/>

   public sealed record class VALUES() : SqlClause("VALUES", null);

   /// <summary>
   /// Gets a singleton instance of the clause identified by <typeparamref name="TClause"/>.
   /// </summary>
   /// <typeparam name="TClause">The type of the clause.</typeparam>
   /// <returns>An instance of <typeparamref name="TClause"/>.</returns>

   public static TClause
   Instance<TClause>() where TClause : SqlClause, new() =>
      InstanceClass<TClause>.Value;

   static class InstanceClass<TClause> where TClause : SqlClause, new() {

      internal static readonly TClause
      Value = new();
   }
}
