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
   EnsureEntityType(int maxIdMembers = -1) {

      var resultType = this.ResultType
         ?? throw new InvalidOperationException("The operation is not supported on untyped sets.");

      var metaType = _db.Configuration.GetMetaType(resultType)
         ?? throw new InvalidOperationException($"Mapping information was not found for '{resultType.FullName}'.");

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

      var resultType = this.ResultType
         ?? throw new InvalidOperationException("Include operation is not supported on untyped sets.");

      var metaType = _db.Configuration.GetMetaType(resultType)
         ?? throw new InvalidOperationException($"Mapping information was not found for '{resultType.FullName}'.");

      return IncludeImpl.Expand(this, path, metaType);
   }

   static class IncludeImpl {

      public static SqlSet
      Expand(SqlSet source, string path, MetaType metaType) {

         var db = source.Database;
         var parts = path.Split('.');

         SqlBuilder selectBuild(string alias) {

            var sql = new SqlBuilder()
               .SELECT(String.Empty);

            db.QuoteIdentifier(sql.Buffer, alias);
            sql.Append(".*");

            return sql;
         }

         void fromAppend(SqlBuilder sql, string alias) =>
            sql.FROM(source.GetDefiningQuery(), db.QuoteIdentifier(alias));

         MetaAssociation? manyAssoc;
         int manyIndex;

         var query = BuildJoinedQuery(parts, metaType, db, selectBuild, fromAppend, out manyAssoc, out manyIndex);

         var newSet = (query is null) ?
            source.Clone()
            : source.CreateSet(query);

         if (manyAssoc is not null) {
            AddManyInclude(newSet, parts, path, manyAssoc, manyIndex);
         }

         return newSet;
      }

      static SqlBuilder?
      BuildJoinedQuery(
            string[] path, MetaType metaType, Database db,
            Func<string, SqlBuilder> selectBuild, Action<SqlBuilder, string> fromAppend,
            out MetaAssociation? manyAssoc, out int manyIndex) {

         manyAssoc = null;
         manyIndex = -1;

         const string leftAlias = "dbex_l";
         const string rightAlias = "dbex_r";

         static string rAliasFn(int i) => rightAlias + (i + 1);

         var query = selectBuild.Invoke(leftAlias);
         var sb = query.Buffer;
         var currentType = metaType;

         var associations = new List<MetaAssociation>();

         for (int i = 0; i < path.Length; i++) {

            var p = path[i];
            var rAlias = rAliasFn(i);

            var member = currentType.PersistentDataMembers
               .SingleOrDefault(m => m.Name == p)
               ?? throw new ArgumentException($"Couldn't find '{p}' on '{currentType.Type.FullName}'.", nameof(path));

            if (!member.IsAssociation) {
               throw new ArgumentException($"'{p}' is not an association property.", nameof(path));
            }

            var association = member.Association;

            if (association.IsMany) {

               manyAssoc = association;
               manyIndex = i;
               break;
            }

            associations.Add(association);

            foreach (var m in association.OtherType.PersistentDataMembers
                  .Where(m => !m.IsAssociation)) {

               query.SELECT(String.Empty);
               db.QuoteIdentifier(sb, rAlias);
               sb.Append('.');
               db.QuoteIdentifier(sb, m.MappedName);
               sb.Append(" AS ");

               foreach (var a in associations) {
                  sb.Append(a.ThisMember.Name)
                     .Append('$');
               }

               sb.Append(m.Name);
            }

            currentType = association.OtherType;
         }

         if (associations.Count == 0) {
            return null;
         }

         fromAppend.Invoke(query, leftAlias);

         for (int i = 0; i < associations.Count; i++) {

            var association = associations[i];
            var lAlias = (i == 0) ? leftAlias : rAliasFn(i - 1);
            var rAlias = rAliasFn(i);

            query.LEFT_JOIN(String.Empty);
            db.QuoteIdentifier(sb, association.OtherType.Table.TableName);
            sb.Append(' ');
            db.QuoteIdentifier(sb, rAlias);
            sb.Append(" ON (");

            for (int j = 0; j < association.ThisKey.Count; j++) {

               if (j > 0) {
                  sb.Append(" AND ");
               }

               var thisMember = association.ThisKey[j];
               var otherMember = association.OtherKey[j];

               db.QuoteIdentifier(sb, lAlias);
               sb.Append('.');
               db.QuoteIdentifier(sb, thisMember.Name);
               sb.Append(" = ");
               db.QuoteIdentifier(sb, rAlias);
               sb.Append('.');
               db.QuoteIdentifier(sb, otherMember.MappedName);
            }

            sb.Append(')');
         }

         return query;
      }

      static void
      AddManyInclude(SqlSet set, string[] path, string originalPath, MetaAssociation manyAssoc, int manyIndex) {

         Debug.Assert(path.Length > 0);
         Debug.Assert(manyIndex >= 0);

         var db = set.Database;
         var metaType = manyAssoc.OtherType;
         var table = db.Table(metaType);

         string[] manyPath;
         SqlSet manySource;

         if (manyIndex == path.Length - 1) {

            manyPath = path;
            manySource = table;

         } else {

            manyPath = new string[manyIndex + 1];

            Array.Copy(path, manyPath, manyPath.Length);

            var manyInclude = new string[path.Length - manyIndex - 1];

            Array.Copy(path, manyIndex + 1, manyInclude, 0, manyInclude.Length);

            SqlBuilder selectBuild(string alias) {

               var sql = new SqlBuilder()
                  .SELECT(String.Empty);

               db.SelectBody(sql.Buffer, metaType, null, alias);

               return sql;
            }

            void fromAppend(SqlBuilder sql, string alias) {
               sql.FROM(String.Empty);
               db.QuoteIdentifier(sql.Buffer, metaType.Table.TableName);
               sql.Buffer.Append(' ')
                  .Append(alias);
            }

            MetaAssociation? manyInManyAssoc;
            int manyInManyIndex;

            var manyQuery = BuildJoinedQuery(manyInclude, metaType, db, selectBuild, fromAppend, out manyInManyAssoc, out manyInManyIndex);

            if (manyInManyAssoc is not null) {
               throw new ArgumentException($"One-to-many associations can only be specified once in an include path ('{originalPath}').", nameof(path));
            }

            manySource = db.FromQuery(manyQuery!, metaType.Type);
         }

         set.ManyIncludes ??= new Dictionary<string[], Action<object>>();

         set.ManyIncludes.Add(manyPath,
            container => ((MetaCollectionAccessor)manyAssoc.ThisMember.MemberAccessor)
               .Load(container, GetMany(container, manyAssoc, manySource)));
      }

      static IEnumerable
      GetMany(object container, MetaAssociation manyAssoc, SqlSet manySource) {

         var predicateValues = manyAssoc.OtherKey.Select((p, i) =>
            new KeyValuePair<string, object>(p.MappedName, manyAssoc.ThisKey[i].GetValueForDatabase(container)));

         var parameters = new List<object?>(manyAssoc.OtherKey.Count);
         var whereFragment = new SqlFragment(manySource.Database.BuildPredicateFragment(predicateValues, parameters), parameters);

         var children = manySource
            .Where(whereFragment)
            .AsEnumerable();

         var otherMember = manyAssoc.OtherMember;
         var setOtherMember = otherMember is { Association.IsMany: false };

         foreach (var child in children) {

            if (setOtherMember) {
               var childObj = child;
               otherMember.MemberAccessor.SetBoxedValue(ref childObj, container);
            }

            yield return child;
         }
      }
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
