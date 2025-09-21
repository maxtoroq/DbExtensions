// Copyright 2025 Max Toro Q.
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
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DbExtensions;

using Metadata;

#nullable enable

partial class Database {

   /// <inheritdoc cref="SqlTable.AddAsync(Object, CancellationToken)"/>
   /// <remarks>This method is a shortcut for <c>await db.Table(entity.GetType()).AddAsync(entity, cancellationToken)</c>.</remarks>
   /// <seealso cref="SqlTable.AddAsync(Object, CancellationToken)" qualifyHint="true"/>

   public async ValueTask
   AddAsync(object entity, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(entity);

      await Table(entity.GetType())
         .AddAsync(entity, cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlSet&lt;TEntity>.FindAsync(Object, CancellationToken)" path="*[not(self::remarks or self::exception[@cref='T:System.InvalidOperationException'])]"/>
   /// <typeparam name="TEntity">The type of the entity.</typeparam>
   /// <remarks>This method is a shortcut for <c>await db.Table&lt;TEntity>().FindAsync(id, cancellationToken)</c>.</remarks>

   public async ValueTask<TEntity?>
   FindAsync<TEntity>(object id, CancellationToken cancellationToken = default) where TEntity : class {

      return await Table<TEntity>()
         .FindAsync(id, cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlTable.UpdateAsync(Object, CancellationToken)"/>
   /// <remarks>This method is a shortcut for <c>await db.Table(entity.GetType()).UpdateAsync(entity, cancellationToken)</c>.</remarks>
   /// <seealso cref="SqlTable.UpdateAsync(Object, CancellationToken)" qualifyHint="true"/>

   public async ValueTask
   UpdateAsync(object entity, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(entity);

      await Table(entity.GetType())
         .UpdateAsync(entity, cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlTable.UpdateAsync(Object, Object, CancellationToken)"/>
   /// <remarks>This method is a shortcut for <c>await db.Table(entity.GetType()).UpdateAsync(entity, originalId, cancellationToken)</c>.</remarks>
   /// <seealso cref="SqlTable.UpdateAsync(Object, Object, CancellationToken)" qualifyHint="true"/>

   public async ValueTask
   UpdateAsync(object entity, object? originalId, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(entity);

      await Table(entity.GetType())
         .UpdateAsync(entity, originalId, cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlTable.RemoveAsync(Object, CancellationToken)"/>
   /// <remarks>This method is a shortcut for <c>await db.Table(entity.GetType()).RemoveAsync(entity, cancellationToken)</c>.</remarks>
   /// <seealso cref="SqlTable.RemoveAsync(Object, CancellationToken)" qualifyHint="true"/>

   public async ValueTask
   RemoveAsync(object entity, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(entity);

      await Table(entity.GetType())
         .RemoveAsync(entity, cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlTable&lt;TEntity>.RemoveKeyAsync(Object, CancellationToken)"/>
   /// <remarks>This method is a shortcut for <c>await db.Table&lt;TEntity>().RemoveKeyAsync(id, cancellationToken)</c>.</remarks>
   /// <seealso cref="SqlTable&lt;TEntity>.RemoveKeyAsync(Object, CancellationToken)" qualifyHint="true"/>

   public async ValueTask
   RemoveKeyAsync<TEntity>(object id, CancellationToken cancellationToken = default) where TEntity : class {

      await Table<TEntity>()
         .RemoveKeyAsync(id, cancellationToken)
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

partial class SqlTable {

   /// <inheritdoc cref="SqlTable&lt;TEntity>.AddAsync(TEntity, CancellationToken)"/>

   public ValueTask
   AddAsync(object entity, CancellationToken cancellationToken = default) =>
      _table.AddAsync(entity, cancellationToken);

   ValueTask
   ISqlTable.AddDescendantsAsync(object entity, CancellationToken cancellationToken) =>
      _table.AddDescendantsAsync(entity, cancellationToken);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.AddRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)"/>

   public ValueTask
   AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default) =>
      _table.AddRangeAsync(entities, cancellationToken);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.AddRangeAsync(TEntity[])"/>

   public ValueTask
   AddRangeAsync(params object[] entities) =>
      _table.AddRangeAsync(entities);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.RemoveAsync(TEntity, CancellationToken)"/>

   public ValueTask
   RemoveAsync(object entity, CancellationToken cancellationToken = default) =>
      _table.RemoveAsync(entity, cancellationToken);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.RemoveKeyAsync(Object, CancellationToken)"/>

   public ValueTask
   RemoveKeyAsync(object id, CancellationToken cancellationToken = default) =>
      _table.RemoveKeyAsync(id, cancellationToken);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.RemoveRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)"/>

   public ValueTask
   RemoveRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default) =>
      _table.RemoveRangeAsync(entities, cancellationToken);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.RemoveRangeAsync(TEntity[])"/>

   public ValueTask
   RemoveRangeAsync(params object[] entities) =>
      _table.RemoveRangeAsync(entities);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.RefreshAsync(TEntity, CancellationToken)"/>

   public ValueTask
   RefreshAsync(object entity, CancellationToken cancellationToken = default) =>
      _table.RefreshAsync(entity, cancellationToken);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.UpdateAsync(TEntity, CancellationToken)"/>

   public ValueTask
   UpdateAsync(object entity, CancellationToken cancellationToken = default) =>
      _table.UpdateAsync(entity, cancellationToken);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.UpdateAsync(TEntity, Object, CancellationToken)"/>

   public ValueTask
   UpdateAsync(object entity, object? originalId, CancellationToken cancellationToken = default) =>
      _table.UpdateAsync(entity, originalId, cancellationToken);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.UpdateRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)"/>

   public ValueTask
   UpdateRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default) =>
      _table.UpdateRangeAsync(entities, cancellationToken);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.UpdateRangeAsync(TEntity[])"/>

   public ValueTask
   UpdateRangeAsync(params object[] entities) =>
      _table.UpdateRangeAsync(entities);
}

partial class SqlTable<TEntity> {

   /// <inheritdoc cref="Add(TEntity)"/>
   /// <inheritdoc cref="SqlSet.AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask
   AddAsync(TEntity entity, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(entity);

      var idMember = _metaType.DBGeneratedIdentityMember;

      var outputIdMember = idMember is not null
         && _db.Configuration.SqlDialect is SqlDialect.TSql;

      var syncMembers = _metaType.PersistentDataMembers
         .Where(m => m.AutoSync is AutoSync.Always or AutoSync.OnInsert
            && m != idMember)
         .ToArray();

      var insertSql = this.CommandBuilder.BuildInsertStatementForEntity(entity, outputIdMember);
      var id = default(object);

      var tx = await _db.EnsureInTransactionAsync(cancellationToken)
         .ConfigureAwait(false);

      await using var txDisp = tx.ConfigureAwait(false);

      if (outputIdMember) {

         // this block emulates Database.Execute()

         var cmd = _db.CreateCommand(insertSql);

         try {
            id = await cmd.ExecuteScalarAsync(cancellationToken)
               .ConfigureAwait(false);

         } catch {

            _db.Trace(cmd, error: true);
            throw;
         }

         _db.Trace(cmd);

      } else {

         await _db.ExecuteAsync(insertSql, affect: 1, exact: true, cancellationToken)
            .ConfigureAwait(false);

         if (idMember is not null) {
            id = await _db.LastInsertIdAsync(cancellationToken)
               .ConfigureAwait(false);
         }
      }

      if (idMember is not null) {

         var convertedId = Convert.ChangeType(id, idMember.Type, CultureInfo.InvariantCulture);
         var entityObj = (object)entity;

         idMember.MemberAccessor.SetBoxedValue(ref entityObj, convertedId);
      }

      if (syncMembers.Length > 0
         && _metaType.IsEntity) {

         await RefreshAsync(entity, syncMembers, cancellationToken)
            .ConfigureAwait(false);
      }

      await InsertDescendantsAsync(entity, cancellationToken)
         .ConfigureAwait(false);

      await tx.CommitAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   async ValueTask
   InsertDescendantsAsync(TEntity entity, CancellationToken cancellationToken) {

      await InsertOneToOneAsync(entity, cancellationToken)
         .ConfigureAwait(false);

      await InsertOneToManyAsync(entity, cancellationToken)
         .ConfigureAwait(false);
   }

   async ValueTask
   InsertOneToOneAsync(TEntity entity, CancellationToken cancellationToken) {

      foreach (var assoc in _metaType.Associations
            .Where(a => !a.IsMany && a.ThisKeyIsPrimaryKey && a.OtherKeyIsPrimaryKey)) {

         var child = assoc.ThisMember.MemberAccessor.GetBoxedValue(entity);

         if (child is null) {
            continue;
         }

         for (int j = 0; j < assoc.ThisKey.Count; j++) {

            var thisKey = assoc.ThisKey[j];
            var otherKey = assoc.OtherKey[j];

            var thisKeyVal = thisKey.MemberAccessor.GetBoxedValue(entity);

            otherKey.MemberAccessor.SetBoxedValue(ref child, thisKeyVal);
         }

         var otherTable = _db.Table(assoc.OtherType);

         await otherTable.AddAsync(child, cancellationToken)
            .ConfigureAwait(false);
      }
   }

   async ValueTask
   InsertOneToManyAsync(TEntity entity, CancellationToken cancellationToken) {

      foreach (var assoc in _metaType.Associations.Where(a => a.IsMany)) {

         var many = ((IEnumerable<object>)assoc.ThisMember.MemberAccessor.GetBoxedValue(entity) ?? [])
            .Where(o => o is not null)
            .ToArray();

         if (many.Length == 0) {
            continue;
         }

         foreach (var child in many) {

            for (int k = 0; k < assoc.ThisKey.Count; k++) {

               var thisKey = assoc.ThisKey[k];
               var otherKey = assoc.OtherKey[k];

               var thisKeyVal = thisKey.MemberAccessor.GetBoxedValue(entity);
               var c = child;

               otherKey.MemberAccessor.SetBoxedValue(ref c, thisKeyVal);
            }
         }

         var otherTable = (ISqlTable)_db.Table(assoc.OtherType);

         await otherTable.AddRangeAsync(many, cancellationToken)
            .ConfigureAwait(false);

         foreach (var child in many) {
            await otherTable.AddDescendantsAsync(child, cancellationToken)
               .ConfigureAwait(false);
         }
      }
   }

   /// <inheritdoc cref="AddRange(IEnumerable&lt;TEntity>)"/>
   /// <inheritdoc cref="SqlSet.AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask
   AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(entities);

      await AddRangeAsync(entities as TEntity[] ?? entities.ToArray(), cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="AddRange(TEntity[])"/>

   public ValueTask
   AddRangeAsync(params TEntity[] entities) =>
      AddRangeAsync(entities, default(CancellationToken));

   async ValueTask
   AddRangeAsync(TEntity[] entities, CancellationToken cancellationToken) {

      ArgumentNullException.ThrowIfNull(entities);

      entities = entities.Where(o => o is not null)
         .ToArray();

      if (entities.Length == 0) {
         return;
      }

      if (entities.Length == 1) {
         await AddAsync(entities[0], cancellationToken)
            .ConfigureAwait(false);
         return;
      }

      var syncMembers = _metaType.PersistentDataMembers
         .Where(m => m.AutoSync is AutoSync.Always or AutoSync.OnInsert)
         .ToArray();

      var batch = syncMembers.Length == 0
         && _db.Configuration.EnableBatchCommands;

      if (batch) {

         var batchInsert = SqlBuilder.JoinSql(
            ";" + Environment.NewLine,
            entities.Select(e => this.CommandBuilder.BuildInsertStatementForEntity(e)));

         var tx = await _db.EnsureInTransactionAsync(cancellationToken)
            .ConfigureAwait(false);

         await using var txDisp = tx.ConfigureAwait(false);

         await _db.ExecuteAsync(batchInsert, affect: entities.Length, exact: true, cancellationToken)
            .ConfigureAwait(false);

         foreach (var e in entities) {
            await InsertDescendantsAsync(e, cancellationToken)
               .ConfigureAwait(false);
         }

         await tx.CommitAsync(cancellationToken)
            .ConfigureAwait(false);

      } else {

         var tx = await _db.EnsureInTransactionAsync(cancellationToken)
            .ConfigureAwait(false);

         await using var txDisp = tx.ConfigureAwait(false);

         foreach (var e in entities) {
            await AddAsync(e, cancellationToken)
               .ConfigureAwait(false);
         }

         await tx.CommitAsync(cancellationToken)
            .ConfigureAwait(false);
      }
   }

   /// <inheritdoc cref="Remove(TEntity)"/>
   /// <inheritdoc cref="SqlSet.AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask
   RemoveAsync(TEntity entity, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(entity);

      var deleteSql = this.CommandBuilder.BuildDeleteStatementForEntity(entity);

      var usingVersion = _db.Configuration.UseVersionMember
         && _metaType.VersionMember is not null;

      await _db.ExecuteAsync(deleteSql, affect: 1, exact: usingVersion, cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="RemoveKey(Object)"/>
   /// <inheritdoc cref="SqlSet.AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask
   RemoveKeyAsync(object id, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(id);

      var deleteSql = this.CommandBuilder.BuildDeleteStatementForKey(id);

      await _db.ExecuteAsync(deleteSql, affect: 1, cancellationToken: cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="RemoveRange(IEnumerable&lt;TEntity>)"/>
   /// <inheritdoc cref="SqlSet.AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask
   RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(entities);

      await RemoveRangeAsync(entities as TEntity[] ?? entities.ToArray(), cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="RemoveRange(TEntity[])"/>

   public ValueTask
   RemoveRangeAsync(params TEntity[] entities) =>
      RemoveRangeAsync(entities, default(CancellationToken));

   async ValueTask
   RemoveRangeAsync(TEntity[] entities, CancellationToken cancellationToken) {

      ArgumentNullException.ThrowIfNull(entities);

      entities = entities.Where(o => o is not null)
         .ToArray();

      if (entities.Length == 0) {
         return;
      }

      if (entities.Length == 1) {
         await RemoveAsync(entities[0], cancellationToken)
            .ConfigureAwait(false);
         return;
      }

      EnsureEntityType();

      var usingVersion = _db.Configuration.UseVersionMember
         && _metaType.VersionMember is not null;

      var singleStatement = _metaType.IdentityMembers.Count == 1
         && !usingVersion;

      var batch = _db.Configuration.EnableBatchCommands;

      if (singleStatement) {

         var idMember = _metaType.IdentityMembers[0];

         var ids = entities.Select(e => idMember.GetValueForDatabase(e))
            .ToArray();

         var sql = this.CommandBuilder
            .BuildDeleteStatement()
            .WHERE(String.Empty);

         sql.Buffer.Append(_db.QuoteIdentifier(idMember.MappedName))
            .Append(" IN (");

         for (int i = 0; i < ids.Length; i++) {

            if (i > 0) {
               sql.Buffer.Append(',')
                  .Append(' ');
            }

            sql.Buffer.Append('{')
               .Append(sql.ParameterValues.Count)
               .Append('}');

            sql.ParameterValues.Add(ids[i]);
         }

         sql.Buffer.Append(')');

         await _db.ExecuteAsync(sql, affect: entities.Length, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

      } else if (batch) {

         var batchDelete = SqlBuilder.JoinSql(
            ";" + Environment.NewLine,
            entities.Select(e => this.CommandBuilder.BuildDeleteStatementForEntity(e)));

         await _db.ExecuteAsync(batchDelete, affect: entities.Length, exact: usingVersion, cancellationToken)
            .ConfigureAwait(false);

      } else {

         var tx = await _db.EnsureInTransactionAsync(cancellationToken)
            .ConfigureAwait(false);

         await using var txDisp = tx.ConfigureAwait(false);

         foreach (var e in entities) {
            await RemoveAsync(e, cancellationToken)
               .ConfigureAwait(false);
         }

         await tx.CommitAsync(cancellationToken)
            .ConfigureAwait(false);
      }
   }

   /// <inheritdoc cref="Refresh(TEntity)"/>
   /// <inheritdoc cref="SqlSet.AnyAsync(CancellationToken)" path="param"/>

   public ValueTask
   RefreshAsync(TEntity entity, CancellationToken cancellationToken = default) =>
      RefreshAsync(entity, null, cancellationToken);

   async ValueTask
   RefreshAsync(TEntity entity, IEnumerable<MetaDataMember>? refreshMembers, CancellationToken cancellationToken) {

      ArgumentNullException.ThrowIfNull(entity);

      EnsureEntityType();

      var query = this.CommandBuilder.BuildSelectStatement(refreshMembers);
      query.WHERE(_db.BuildPredicateFragment(entity, _metaType.IdentityMembers, query.ParameterValues));

      var mapper = _db.CreatePocoMapper(_metaType.Type);

      var entityObj = (object)entity;

      _ = await _db.AsyncMap<object?>(query, r => {
         mapper.PocoLoad(entityObj, r);
         return null;

      }).SingleOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="Update(TEntity)"/>
   /// <inheritdoc cref="SqlSet.AnyAsync(CancellationToken)" path="param"/>

   public ValueTask
   UpdateAsync(TEntity entity, CancellationToken cancellationToken = default) =>
      UpdateAsync(entity, null, cancellationToken);

   /// <inheritdoc cref="Update(TEntity, Object)"/>
   /// <inheritdoc cref="SqlSet.AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask
   UpdateAsync(TEntity entity, object? originalId, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(entity);

      var updateSql = this.CommandBuilder.BuildUpdateStatementForEntity(entity, originalId);

      var syncMembers = _metaType.PersistentDataMembers
         .Where(m => m.AutoSync is AutoSync.Always or AutoSync.OnUpdate)
         .ToArray();

      await using var conn = (await _db.EnsureConnectionOpenAsync(cancellationToken)
            .ConfigureAwait(false))
         .ConfigureAwait(false);

      await _db.ExecuteAsync(updateSql, affect: 1, exact: true, cancellationToken)
         .ConfigureAwait(false);

      if (syncMembers.Length > 0) {
         await RefreshAsync(entity, syncMembers, cancellationToken)
            .ConfigureAwait(false);
      }
   }

   /// <inheritdoc cref="UpdateRange(IEnumerable&lt;TEntity>)"/>
   /// <inheritdoc cref="SqlSet.AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask
   UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(entities);

      await UpdateRangeAsync(entities as TEntity[] ?? entities.ToArray(), cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="UpdateRange(TEntity[])"/>
   /// <inheritdoc cref="SqlSet.AnyAsync(CancellationToken)" path="param"/>

   public ValueTask
   UpdateRangeAsync(params TEntity[] entities) =>
      UpdateRangeAsync(entities, default(CancellationToken));

   async ValueTask
   UpdateRangeAsync(TEntity[] entities, CancellationToken cancellationToken) {

      ArgumentNullException.ThrowIfNull(entities);

      entities = entities.Where(o => o is not null)
         .ToArray();

      if (entities.Length == 0) {
         return;
      }

      if (entities.Length == 1) {
         await UpdateAsync(entities[0], cancellationToken)
            .ConfigureAwait(false);
         return;
      }

      EnsureEntityType();

      var syncMembers = _metaType.PersistentDataMembers
         .Where(m => m.AutoSync is AutoSync.Always or AutoSync.OnUpdate)
         .ToArray();

      var batch = syncMembers.Length == 0
         && _db.Configuration.EnableBatchCommands;

      if (batch) {

         var batchUpdate = SqlBuilder.JoinSql(
            ";" + Environment.NewLine,
            entities.Select(e => this.CommandBuilder.BuildUpdateStatementForEntity(e)));

         await _db.ExecuteAsync(batchUpdate, affect: entities.Length, exact: true, cancellationToken)
            .ConfigureAwait(false);

      } else {

         var tx = await _db.EnsureInTransactionAsync(cancellationToken)
            .ConfigureAwait(false);

         await using var txDisp = tx.ConfigureAwait(false);

         foreach (var e in entities) {
            await UpdateAsync(e, cancellationToken)
               .ConfigureAwait(false);
         }

         await tx.CommitAsync(cancellationToken)
            .ConfigureAwait(false);
      }
   }

   // ISqlTable Members

   ValueTask
   ISqlTable.AddAsync(object entity, CancellationToken cancellationToken) =>
      AddAsync((TEntity)entity, cancellationToken);

   ValueTask
   ISqlTable.AddDescendantsAsync(object entity, CancellationToken cancellationToken) =>
      InsertDescendantsAsync((TEntity)entity, cancellationToken);

   ValueTask
   ISqlTable.AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken) =>
      AddRangeAsync(entities.Cast<TEntity>(), cancellationToken);

   ValueTask
   ISqlTable.AddRangeAsync(params object[] entities) =>
      AddRangeAsync(entities.Cast<TEntity>());

   ValueTask
   ISqlTable.RemoveAsync(object entity, CancellationToken cancellationToken) =>
      RemoveAsync((TEntity)entity, cancellationToken);

   ValueTask
   ISqlTable.RemoveKeyAsync(object id, CancellationToken cancellationToken) =>
      RemoveKeyAsync(id, cancellationToken);

   ValueTask
   ISqlTable.RemoveRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken) =>
      RemoveRangeAsync(entities.Cast<TEntity>(), cancellationToken);

   ValueTask
   ISqlTable.RemoveRangeAsync(params object[] entities) =>
      RemoveRangeAsync(entities.Cast<TEntity>());

   ValueTask
   ISqlTable.RefreshAsync(object entity, CancellationToken cancellationToken) =>
      RefreshAsync((TEntity)entity, cancellationToken);

   ValueTask
   ISqlTable.UpdateAsync(object entity, CancellationToken cancellationToken) =>
      UpdateAsync((TEntity)entity, cancellationToken);

   ValueTask
   ISqlTable.UpdateAsync(object entity, object? originalId, CancellationToken cancellationToken) =>
      UpdateAsync((TEntity)entity, originalId, cancellationToken);

   ValueTask
   ISqlTable.UpdateRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken) =>
      UpdateRangeAsync(entities.Cast<TEntity>(), cancellationToken);

   ValueTask
   ISqlTable.UpdateRangeAsync(params object[] entities) =>
      UpdateRangeAsync(entities.Cast<TEntity>());
}

partial interface ISqlTable {

   ValueTask
   AddAsync(object entity, CancellationToken cancellationToken);

   ValueTask // internal
   AddDescendantsAsync(object entity, CancellationToken cancellationToken);

   ValueTask
   AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken);

   ValueTask
   AddRangeAsync(params object[] entities);

   ValueTask
   RemoveAsync(object entity, CancellationToken cancellationToken);

   ValueTask
   RemoveKeyAsync(object id, CancellationToken cancellationToken);

   ValueTask
   RemoveRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken);

   ValueTask
   RemoveRangeAsync(params object[] entities);

   ValueTask
   RefreshAsync(object entity, CancellationToken cancellationToken);

   ValueTask
   UpdateAsync(object entity, CancellationToken cancellationToken);

   ValueTask
   UpdateAsync(object entity, object? originalId, CancellationToken cancellationToken);

   ValueTask
   UpdateRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken);

   ValueTask
   UpdateRangeAsync(params object[] entities);
}
