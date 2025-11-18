// Copyright 2012-2025 Max Toro Q.
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
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace DbExtensions;

using Metadata;

#nullable enable

partial class Database {

   /// <inheritdoc cref="SqlSet&lt;TEntity>.Find(Object)" path="*[not(self::remarks or self::exception[@cref='T:System.InvalidOperationException'])]"/>
   /// <typeparam name="TEntity">The type of the entity.</typeparam>
   /// <remarks>This method is a shortcut for <c>db.Table&lt;TEntity>().Find(id)</c>.</remarks>
   /// <seealso cref="SqlSet&lt;TEntity>.Find(Object)" qualifyHint="true"/>

   public TEntity?
   Find<TEntity>(object id) where TEntity : class =>
      Table<TEntity>().Find(id);
}

partial class SqlSet {

   MetaType
   EnsureAnnotatedType() {

      var resultType = this.ResultType
         ?? throw new InvalidOperationException("The operation is not supported on untyped sets.");

      var metaType = _db.Configuration.GetMetaType(resultType)
         ?? throw new InvalidOperationException($"Mapping information was not found for '{resultType.FullName}'.");

      return metaType;
   }

   MetaType
   EnsureEntityType(int maxIdMembers = -1) {

      var metaType = EnsureAnnotatedType();

      SqlTable.EnsureEntityType(metaType);

      if (maxIdMembers > 0
         && metaType.IdentityMembers.Count > maxIdMembers) {

         throw new InvalidOperationException("The operation is not supported for entities with more than one identity member.");
      }

      return metaType;
   }

   /// <summary>
   /// Checks the existance of the <paramref name="entity"/>, using the primary key value.
   /// </summary>
   /// <param name="entity">The entity whose existance is to be checked.</param>
   /// <returns><c>true</c> if the primary key value exists in the database; otherwise, <c>false</c>.</returns>
   /// <exception cref="System.InvalidOperationException">This method can only be used on sets where the result type is an annotated class.</exception>

   public bool
   Contains(object entity) {

      ArgumentNullException.ThrowIfNull(entity);

      var (fragment, columnList) = ContainsEntityImplParams(entity);

      return Where(fragment)
         .Select(columnList)
         .Any();
   }

   (ISqlFragment, string)
   ContainsEntityImplParams(object entity) {

      var metaType = EnsureEntityType();

      var predicateMembers = metaType.PersistentDataMembers
         .Where(m => m.IsPrimaryKey || (m.IsVersion && _db.Configuration.UseVersionMember))
         .ToArray();

      var predicateValues = predicateMembers.ToDictionary(
         m => m.MappedName,
         m => m.GetValueForDatabase(entity));

      return ContainsImplParams(predicateMembers, predicateValues);
   }

   /// <summary>
   /// Checks the existance of an entity whose primary matches the <paramref name="id"/> parameter.
   /// </summary>
   /// <param name="id">The primary key value.</param>
   /// <returns><c>true</c> if the primary key value exists in the database; otherwise, <c>false</c>.</returns>
   /// <exception cref="System.InvalidOperationException">This method can only be used on sets where the result type is an annotated class.</exception>

   public bool
   ContainsKey(object id) {

      ArgumentNullException.ThrowIfNull(id);

      var (fragment, columnList) = ContainsKeyImplParams(id);

      return Where(fragment)
         .Select(columnList)
         .Any();
   }

   (ISqlFragment, string)
   ContainsKeyImplParams(object id) {

      var metaType = EnsureEntityType(maxIdMembers: 1);
      var idMember = metaType.IdentityMembers[0];

      var predicateMembers = new[] { idMember };

      var predicateValues = new KeyValuePair<string, object>[] {
         new(idMember.MappedName, idMember.ConvertValueForDatabase(id))
      };

      return ContainsImplParams(predicateMembers, predicateValues);
   }

   (ISqlFragment, string)
   ContainsImplParams(MetaDataMember[] predicateMembers, IEnumerable<KeyValuePair<string, object>> predicateValues) {

      var metaType = predicateMembers[0].DeclaringType;
      var predicateParams = new List<object?>(predicateMembers.Length);

      var fragment = new SqlFragment(_db.BuildPredicateFragment(predicateValues, predicateParams), predicateParams);
      var columnList = _db.SelectBody(metaType, predicateMembers);

      return (fragment, columnList);
   }

   /// <summary>
   /// Gets the entity whose primary key matches the <paramref name="id"/> parameter.
   /// </summary>
   /// <param name="id">The primary key value.</param>
   /// <returns>
   /// The entity whose primary key matches the <paramref name="id"/> parameter, 
   /// or null if the <paramref name="id"/> does not exist.
   /// </returns>
   /// <exception cref="System.InvalidOperationException">This method can only be used on sets where the result type is an annotated class.</exception>

   public object?
   Find(object id) =>
      FindImpl(id).SingleOrDefault();

   private protected SqlSet
   FindImpl(object id) {

      ArgumentNullException.ThrowIfNull(id);

      var metaType = EnsureEntityType(maxIdMembers: 1);
      var idMember = metaType.IdentityMembers[0];

      var predicateValues = new KeyValuePair<string, object>[] {
         new(idMember.MappedName, idMember.ConvertValueForDatabase(id))
      };

      var parameters = new List<object?>(predicateValues.Length);
      var fragment = new SqlFragment(_db.BuildPredicateFragment(predicateValues, parameters), parameters);

      return Where(fragment);
   }

   /// <summary>
   /// Specifies the related objects to include in the query results.
   /// </summary>
   /// <param name="path">Dot-separated list of related objects to return in the query results.</param>
   /// <returns>A new <see cref="SqlSet"/> with the defined query path.</returns>
   /// <exception cref="System.InvalidOperationException">This method can only be used on sets where the result type is an annotated class.</exception>

   public SqlSet
   Include(string path) {

      ArgumentNullException.ThrowIfNull(path);

      var metaType = EnsureAnnotatedType();
      var parts = IncludePathSplit(path);

      const string leftAlias = "dbex_l";
      const string rightAlias = "dbex_r";

      static string rAliasFn(int i) => rightAlias + (i + 1);

      var query = new SqlBuilder()
         .SELECT(String.Empty);

      var sb = query.Buffer;

      _db.QuoteIdentifier(sb, leftAlias);
      sb.Append(".*");

      var currentType = metaType;

      var associations = new List<MetaAssociation>(parts.Length);

      for (int i = 0; i < parts.Length; i++) {

         var p = parts[i];
         var rAlias = rAliasFn(i);

         var member = currentType.PersistentDataMembers
            .SingleOrDefault(m => m.Name == p)
            ?? throw new ArgumentException($"Couldn't find '{p}' on '{currentType.Type.FullName}'.", nameof(path));

         if (!member.IsAssociation) {
            throw new ArgumentException($"'{p}' is not an association property.", nameof(path));
         }

         var association = member.Association;

         if (association.IsMany) {
            throw new ArgumentException($"Use the IncludeMany method to load collections ('{path}').", nameof(path));
         }

         associations.Add(association);

         foreach (var m in association.OtherType.PersistentDataMembers
               .Where(m => !m.IsAssociation)) {

            query.SELECT(String.Empty);
            _db.QuoteIdentifier(sb, rAlias);
            sb.Append('.');
            _db.QuoteIdentifier(sb, m.MappedName);
            sb.Append(" AS ");

            foreach (var a in associations) {
               sb.Append(a.ThisMember.Name)
                  .Append('$');
            }

            sb.Append(m.Name);
         }

         currentType = association.OtherType;
      }

      query.FROM(GetDefiningQuery(clone: false), _db.QuoteIdentifier(leftAlias));

      for (int i = 0; i < associations.Count; i++) {

         var association = associations[i];
         var lAlias = (i == 0) ? leftAlias : rAliasFn(i - 1);
         var rAlias = rAliasFn(i);

         query.LEFT_JOIN(String.Empty);
         _db.QuoteIdentifier(sb, association.OtherType.Table.TableName);
         sb.Append(' ');
         _db.QuoteIdentifier(sb, rAlias);
         sb.Append(" ON (");

         for (int j = 0; j < association.ThisKey.Count; j++) {

            if (j > 0) {
               sb.Append(" AND ");
            }

            var thisMember = association.ThisKey[j];
            var otherMember = association.OtherKey[j];

            _db.QuoteIdentifier(sb, lAlias);
            sb.Append('.');
            _db.QuoteIdentifier(sb, (i > 0) ? thisMember.MappedName : thisMember.Name);
            sb.Append(" = ");
            _db.QuoteIdentifier(sb, rAlias);
            sb.Append('.');
            _db.QuoteIdentifier(sb, otherMember.MappedName);
         }

         sb.Append(')');
      }

      var newSet = CreateSet(query);

      return newSet;
   }

   /// <summary>
   /// Specifies which collections to include in the query results.
   /// </summary>
   /// <param name="path">Dot-separated list of one or more related objects that ends with the collection to load.</param>
   /// <param name="elementPath">Dot-separated list of related objects to include in each element of the collection.</param>
   /// <returns>A new <see cref="SqlSet"/>.</returns>
   /// <exception cref="System.InvalidOperationException">This method can only be used on sets where the result type is an annotated class.</exception>

   public SqlSet
   IncludeMany(string path, string? elementPath = null) {

      ArgumentNullException.ThrowIfNull(path);

      var metaType = EnsureAnnotatedType();

      var parts = IncludePathSplit(path);
      var currentType = metaType;
      var manyAssoc = default(MetaAssociation);

      for (int i = 0; i < parts.Length; i++) {

         var p = parts[i];

         var member = currentType.PersistentDataMembers
            .SingleOrDefault(m => m.Name == p)
            ?? throw new ArgumentException($"Couldn't find '{p}' on '{currentType.Type.FullName}'.", nameof(path));

         if (!member.IsAssociation) {
            throw new ArgumentException($"'{p}' is not an association property.", nameof(path));
         }

         var association = member.Association;

         if (i == parts.Length - 1) {

            if (association.IsMany) {
               manyAssoc = association;
               break;
            }

            throw new ArgumentException(
               $"The last segment of the path must refer to a collection ('{path}').",
               nameof(path));

         } else if (association.IsMany) {

            throw new ArgumentException(
               $"Only the last segment of the path can refer to a collection ('{path}'). "
               + "Use the elementPath parameter to include a path in the collection.",
               nameof(path));
         }

         currentType = association.OtherType;
      }

      Debug.Assert(manyAssoc is not null);

      var manySource = (SqlSet)_db.Table(manyAssoc.OtherType);

      if (elementPath is not null) {
         manySource = manySource.Include(elementPath);
      }

      var newSet = Clone();

      newSet.AddManyInclude(parts,
         container => manyAssoc.LoadCollection(container, IncludeManyGet(container, manyAssoc, manySource)));

      return newSet;
   }

   static IEnumerable
   IncludeManyGet(object container, MetaAssociation manyAssoc, SqlSet manySource) {

      var predicateValues = manyAssoc.OtherKey.Select((p, i) =>
         new KeyValuePair<string, object>(p.MappedName, manyAssoc.ThisKey[i].GetValueForDatabase(container)));

      var parameters = new List<object?>(manyAssoc.OtherKey.Count);
      var whereFragment = new SqlFragment(manySource.Database.BuildPredicateFragment(predicateValues, parameters), parameters);

      return manySource
         .Where(whereFragment)
         .AsEnumerable();
   }

   static string[]
   IncludePathSplit(string path) {

      var pathParts = path.Split('.', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

      if (pathParts.Length == 0) {
         throw new ArgumentException("Path is empty.", nameof(path));
      }

      return pathParts;
   }
}

partial class SqlSet<TResult> {

   /// <inheritdoc cref="SqlSet.Contains(Object)"/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public new bool
   Contains(object entity) =>
      Contains((TResult)entity);

   /// <inheritdoc cref="SqlSet.Contains(Object)"/>

   public bool
   Contains(TResult entity) =>
      base.Contains(entity!);

   /// <inheritdoc cref="SqlSet.Find(Object)"/>

   public new TResult?
   Find(object id) =>
      ((SqlSet<TResult>)FindImpl(id)).SingleOrDefault();

   /// <inheritdoc cref="SqlSet.Include(String)"/>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/> with the defined query path.</returns>

   public new SqlSet<TResult>
   Include(string path) =>
      (SqlSet<TResult>)base.Include(path);

   /// <inheritdoc cref="Include(String)"/>
   /// <param name="path">Lambda expression that returns the deepest related object to return in the query results.</param>
   /// <param name="pathExpr">This argument is compiler generated.</param>

   public SqlSet<TResult>
   Include(Func<TResult, object?> path, [CallerArgumentExpression(nameof(path))] string pathExpr = "") {

      ArgumentNullException.ThrowIfNull(path);
      ArgumentException.ThrowIfNullOrEmpty(pathExpr);

      var pathStr = IncludeLambdaPath(pathExpr);

      return Include(pathStr);
   }

   /// <inheritdoc cref="SqlSet.IncludeMany(String, String?)"/>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/>.</returns>

   public new SqlSet<TResult>
   IncludeMany(string path, string? elementPath = null) =>
      (SqlSet<TResult>)base.IncludeMany(path, elementPath);

   /// <inheritdoc cref="IncludeMany(String, String?)"/>
   /// <typeparam name="TElement">The type of objects the collection holds.</typeparam>
   /// <param name="path">Lambda expression that returns the collection to load.</param>
   /// <param name="elementPath">Lambda expression that returns the deepest related object to include in each element of the collection.</param>
   /// <param name="pathExpr">This argument is compiler generated.</param>
   /// <param name="elementPathExpr">This argument is compiler generated.</param>

   public SqlSet<TResult>
   IncludeMany<TElement>(
         Func<TResult, ICollection<TElement>?> path,
         Func<TElement, object?>? elementPath = null,
         [CallerArgumentExpression(nameof(path))] string pathExpr = "",
         [CallerArgumentExpression(nameof(elementPath))] string elementPathExpr = "") {

      ArgumentNullException.ThrowIfNull(path);
      ArgumentException.ThrowIfNullOrEmpty(pathExpr);

      var pathStr = IncludeLambdaPath(pathExpr);
      var elementPathStr = (elementPath is not null) ?
         IncludeLambdaPath(elementPathExpr)
         : null;

      return IncludeMany(pathStr, elementPathStr);
   }

   static string
   IncludeLambdaPath(string pathExpr) {

      var arrowIndex = pathExpr.IndexOf("=>");

      if (arrowIndex == -1) {
         throw new ArgumentException("A lambda expression is expected.", nameof(pathExpr));
      }

      var firstDot = pathExpr.IndexOf('.', arrowIndex);

      if (firstDot == -1) {
         throw new ArgumentException("Path is empty.", nameof(pathExpr));
      }

      return pathExpr
         .Substring(firstDot + 1);
   }
}

// Async

partial class Database {

   /// <inheritdoc cref="SqlSet&lt;TEntity>.FindAsync(Object, CancellationToken)" path="*[not(self::remarks or self::exception[@cref='T:System.InvalidOperationException'])]"/>
   /// <typeparam name="TEntity">The type of the entity.</typeparam>
   /// <remarks>This method is a shortcut for <c>await db.Table&lt;TEntity>().FindAsync(id, cancellationToken)</c>.</remarks>

   public async ValueTask<TEntity?>
   FindAsync<TEntity>(object id, CancellationToken cancellationToken = default) where TEntity : class {

      return await Table<TEntity>()
         .FindAsync(id, cancellationToken)
         .ConfigureAwait(false);
   }
}

partial class SqlSet {

   /// <inheritdoc cref="Contains(Object)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<bool>
   ContainsAsync(object entity, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(entity);

      var (fragment, columnList) = ContainsEntityImplParams(entity);

      return await Where(fragment)
         .Select(columnList)
         .AnyAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="ContainsKey(Object)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<bool>
   ContainsKeyAsync(object id, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(id);

      var (fragment, columnList) = ContainsKeyImplParams(id);

      return await Where(fragment)
         .Select(columnList)
         .AnyAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="Find(Object)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object?>
   FindAsync(object id, CancellationToken cancellationToken = default) {

      return await FindImpl(id)
         .SingleOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }
}

partial class SqlSet<TResult> {

   /// <inheritdoc cref="SqlSet.ContainsAsync(Object, CancellationToken)"/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public new ValueTask<bool>
   ContainsAsync(object entity, CancellationToken cancellationToken = default) =>
      ContainsAsync((TResult)entity, cancellationToken);

   /// <inheritdoc cref="SqlSet.ContainsAsync(Object, CancellationToken)"/>

   public ValueTask<bool>
   ContainsAsync(TResult entity, CancellationToken cancellationToken = default) =>
      base.ContainsAsync(entity!, cancellationToken);

   /// <inheritdoc cref="SqlSet.FindAsync(Object, CancellationToken)"/>

   public new async ValueTask<TResult?>
   FindAsync(object id, CancellationToken cancellationToken = default) {

      return await ((SqlSet<TResult>)FindImpl(id))
         .SingleOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }
}
