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
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DbExtensions;

using Metadata;

#nullable enable

partial class Database {

   static readonly MethodInfo
   _tableMethod = typeof(Database)
      .GetMethod(nameof(Table), 1, Type.EmptyTypes)!;

   static readonly MappingSource
   _mappingSource = new AttributeMappingSource();

   readonly Dictionary<MetaType, SqlTable>
   _tables = new();

   readonly Dictionary<MetaType, ISqlTable>
   _genericTables = new();

   partial void
   Initialize2(string providerInvariantName) {

      this.Configuration.SetModel(() => _mappingSource.GetModel(GetType()));
      Initialize3(providerInvariantName);
   }

   partial void
   Initialize3(string providerInvariantName);

   /// <summary>
   /// Returns the <see cref="SqlTable&lt;TEntity>"/> instance for the specified <typeparamref name="TEntity"/>.
   /// </summary>
   /// <typeparam name="TEntity">The type of the entity.</typeparam>
   /// <returns>The <see cref="SqlTable&lt;TEntity>"/> instance for <typeparamref name="TEntity"/>.</returns>

   public SqlTable<TEntity>
   Table<TEntity>() where TEntity : class {

      var metaType = this.Configuration.GetMetaType(typeof(TEntity));

      ref var table = ref CollectionsMarshal.GetValueRefOrAddDefault(_genericTables, metaType, out var exists);

      if (!exists) {
         table = new SqlTable<TEntity>(this, metaType);
      }

      return (SqlTable<TEntity>)table!;
   }

   /// <summary>
   /// Returns the <see cref="SqlTable"/> instance for the specified <paramref name="entityType"/>.
   /// </summary>
   /// <param name="entityType">The type of the entity.</param>
   /// <returns>The <see cref="SqlTable"/> instance for <paramref name="entityType"/>.</returns>

   public SqlTable
   Table(Type entityType) {

      ArgumentNullException.ThrowIfNull(entityType);

      return Table(this.Configuration.GetMetaType(entityType));
   }

   internal SqlTable
   Table(MetaType metaType) {

      ref var table = ref CollectionsMarshal.GetValueRefOrAddDefault(_tables, metaType, out var exists);

      if (!exists) {

         var genericTable = (ISqlTable)_tableMethod
            .MakeGenericMethod(metaType.Type)
            .Invoke(this, null)!;

         table = new SqlTable(this, metaType, genericTable);
      }

      return table!;
   }

   /// <inheritdoc cref="SqlTable.Add(Object)"/>
   /// <remarks>This method is a shortcut for <c>db.Table(entity.GetType()).Add(entity)</c>.</remarks>
   /// <seealso cref="SqlTable.Add(Object)" qualifyHint="true"/>

   public void
   Add(object entity) {

      ArgumentNullException.ThrowIfNull(entity);

      Table(entity.GetType())
         .Add(entity);
   }

   /// <inheritdoc cref="SqlSet&lt;TEntity>.Find(Object)" path="*[not(self::remarks or self::exception[@cref='T:System.InvalidOperationException'])]"/>
   /// <typeparam name="TEntity">The type of the entity.</typeparam>
   /// <remarks>This method is a shortcut for <c>db.Table&lt;TEntity>().Find(id)</c>.</remarks>
   /// <seealso cref="SqlSet&lt;TEntity>.Find(Object)" qualifyHint="true"/>

   public TEntity?
   Find<TEntity>(object id) where TEntity : class =>
      Table<TEntity>().Find(id);

   /// <inheritdoc cref="SqlTable.Update(Object)"/>
   /// <remarks>This method is a shortcut for <c>db.Table(entity.GetType()).Update(entity)</c>.</remarks>
   /// <seealso cref="SqlTable.Update(Object)" qualifyHint="true"/>

   public void
   Update(object entity) {

      ArgumentNullException.ThrowIfNull(entity);

      Table(entity.GetType())
         .Update(entity);
   }

   /// <inheritdoc cref="SqlTable.Update(Object, Object)"/>
   /// <remarks>This method is a shortcut for <c>db.Table(entity.GetType()).Update(entity, originalId)</c>.</remarks>
   /// <seealso cref="SqlTable.Update(Object, Object)" qualifyHint="true"/>

   public void
   Update(object entity, object? originalId) {

      ArgumentNullException.ThrowIfNull(entity);

      Table(entity.GetType())
         .Update(entity, originalId);
   }

   /// <inheritdoc cref="SqlTable.Remove(Object)"/>
   /// <remarks>This method is a shortcut for <c>db.Table(entity.GetType()).Remove(entity)</c>.</remarks>
   /// <seealso cref="SqlTable.Remove(Object)" qualifyHint="true"/>

   public bool
   Remove(object entity) {

      ArgumentNullException.ThrowIfNull(entity);

      return Table(entity.GetType())
         .Remove(entity);
   }

   internal string
   BuildPredicateFragment(
         object entity,
         IEnumerable<MetaDataMember> predicateMembers,
         ICollection<object?> parametersBuffer,
         Func<MetaDataMember, object>? getValueFn = null) {

      var predicateValues = predicateMembers.Select(m =>
         new KeyValuePair<string, object>(
            m.MappedName,
            (getValueFn is not null) ?
               getValueFn.Invoke(m)
               : m.GetValueForDatabase(entity)));

      return BuildPredicateFragment(predicateValues, parametersBuffer);
   }

   internal string
   BuildPredicateFragment(IEnumerable<KeyValuePair<string, object>> predicateValues, ICollection<object?> parametersBuffer) {

      //if (predicateValues is null || predicateValues.Count == 0) throw new ArgumentException("predicateValues cannot be empty", nameof(predicateValues));
      ArgumentNullException.ThrowIfNull(parametersBuffer);

      var sb = new StringBuilder();

      foreach (var item in predicateValues) {

         if (sb.Length > 0) {
            sb.Append(" AND ");
         }

         QuoteIdentifier(sb, item.Key);

         if (item.Value is null) {
            sb.Append(" IS NULL");
         } else {
            sb.Append(" = {")
               .Append(parametersBuffer.Count)
               .Append('}');

            parametersBuffer.Add(item.Value);
         }
      }

      return sb.ToString();
   }

   internal string
   SelectBody(MetaType metaType, IEnumerable<MetaDataMember>? selectMembers) {

      var sb = new StringBuilder();

      SelectBody(sb, metaType, selectMembers, null);

      return sb.ToString();
   }

   internal void
   SelectBody(StringBuilder sb, MetaType metaType, IEnumerable<MetaDataMember>? selectMembers, string? tableAlias) {

      selectMembers ??= metaType.PersistentDataMembers.Where(m => !m.IsAssociation);

      var appendAlias = !String.IsNullOrEmpty(tableAlias);
      var i = -1;

      foreach (var member in selectMembers) {

         i++;

         var mappedName = member.MappedName;
         var memberName = member.QueryPath;
         var columnAlias = !String.Equals(mappedName, memberName, StringComparison.Ordinal) ?
            memberName : null;

         if (i > 0) {
            sb.Append(',')
               .Append(' ');
         }

         if (appendAlias) {
            QuoteIdentifier(sb, tableAlias!);
            sb.Append('.');
         }

         QuoteIdentifier(sb, mappedName);

         if (columnAlias is not null) {

            sb.Append(" AS ");
            QuoteIdentifier(sb, columnAlias);
         }
      }
   }

   internal string
   FromBody(MetaType metaType) {

      if (metaType.Table is null) throw new InvalidOperationException("metaType.Table cannot be null.");

      return QuoteIdentifier(metaType.Table.TableName);
   }
}

partial class DatabaseConfiguration {

   Lazy<MetaModel>
   _model;

   MetaTableConfiguration
   _defaultMetaTableConfig;

   /// <summary>
   /// Gets the <see cref="MetaModel"/> on which the mapping is based.
   /// </summary>

   internal MetaModel
   Model => _model.Value;

   /// <summary>
   /// <c>true</c> to include version column check in SQL statements' predicates; otherwise, <c>false</c>. The default is <c>true</c>.
   /// </summary>

   public bool
   UseVersionMember { get; set; } = true;

   /// <summary>
   /// <c>true</c> to execute batch commands when possible; otherwise, <c>false</c>. The default is <c>true</c>.
   /// </summary>
   /// <remarks>
   /// This setting affects the behavior of <see cref="SqlTable&lt;TEntity>.AddRange(TEntity[])"/>,
   /// <see cref="SqlTable&lt;TEntity>.UpdateRange(TEntity[])"/> and <see cref="SqlTable&lt;TEntity>.RemoveRange(TEntity[])"/>.
   /// </remarks>

   public bool
   EnableBatchCommands { get; set; } = true;

   /// <summary>
   /// The default separator to use when mapping complex properties.
   /// The default value is null, which means no separator is used, unless an explicit separator
   /// is specified on <see cref="ComplexPropertyAttribute.Separator" qualifyHint="true"/>.
   /// </summary>

   public string?
   DefaultComplexPropertySeparator { get; set; }

   internal MetaTableConfiguration
   DefaultMetaTableConfig =>
      _defaultMetaTableConfig ??= new MetaTableConfiguration {
         DefaultComplexPropertySeparator = this.DefaultComplexPropertySeparator
      };

   internal void
   SetModel(Func<MetaModel> modelFn) {
      _model = new Lazy<MetaModel>(modelFn);
   }

   internal MetaType
   GetMetaType(Type type) =>
      this.Model.GetMetaType(type, this.DefaultMetaTableConfig);
}

/// <summary>
/// A non-generic version of <see cref="SqlTable&lt;TEntity>"/> which can be used when the type of the entity is not known at build time.
/// This class cannot be instantiated, to get an instance use the <see cref="Database.Table(Type)" qualifyHint="true"/> method.
/// </summary>

[DebuggerDisplay($"{{{nameof(_metaType)}.{nameof(_metaType.Name)}}}")]
public sealed partial class SqlTable : SqlSet, ISqlTable {

   // table is the SqlTable<TEntity> instance for metaType
   // SqlTable is only a wrapper on SqlTable<TEntity>

   readonly ISqlTable
   _table;

   internal readonly MetaType
   _metaType;

   /// <summary>
   /// Gets the name of the table.
   /// </summary>

   public string
   Name => _metaType.Table.TableName;

   internal
   SqlTable(Database db, MetaType metaType, ISqlTable table)
      : base([db.FromBody(metaType), db.SelectBody(metaType, null)], metaType.Type, db) {

      _table = table;
      _metaType = metaType;
   }

   /// <summary>
   /// Casts the current <see cref="SqlTable"/> to the generic <see cref="SqlTable&lt;TEntity>"/> instance.
   /// </summary>
   /// <typeparam name="TEntity">The type of the entity.</typeparam>
   /// <returns>The <see cref="SqlTable&lt;TEntity>"/> instance for <typeparamref name="TEntity"/>.</returns>
   /// <exception cref="System.InvalidOperationException">The specified <typeparamref name="TEntity"/> is not valid for this instance.</exception>

   public new SqlTable<TEntity>
   Cast<TEntity>() where TEntity : class {

      if (typeof(TEntity) != _metaType.Type) {
         throw new InvalidOperationException("The specified type parameter is not valid for this instance.");
      }

      return (SqlTable<TEntity>)_table;
   }

   /// <inheritdoc cref="SqlSet.Cast(Type)"/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public new SqlSet
   Cast(Type resultType) =>
      base.Cast(resultType);

   internal static void
   EnsureEntityType(MetaType metaType) {

      if (!metaType.IsEntity) {
         throw new InvalidOperationException($"The operation is not available for non-entity types ('{metaType.Type.FullName}').");
      }
   }

   // ISqlTable Members: these methods just call the same method on _table

   /// <inheritdoc cref="SqlTable&lt;TEntity>.Add(TEntity)"/>

   public void
   Add(object entity) =>
      _table.Add(entity);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.AddRange(IEnumerable&lt;TEntity>)"/>

   public void
   AddRange(IEnumerable<object> entities) =>
      _table.AddRange(entities);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.AddRange(TEntity[])"/>

   public void
   AddRange(params object[] entities) =>
      _table.AddRange(entities);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.Update(TEntity)"/>

   public void
   Update(object entity) =>
      _table.Update(entity);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.Update(TEntity, Object)"/>

   public void
   Update(object entity, object? originalId) =>
      _table.Update(entity, originalId);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.UpdateRange(IEnumerable&lt;TEntity>)"/>

   public void
   UpdateRange(IEnumerable<object> entities) =>
      _table.UpdateRange(entities);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.UpdateRange(TEntity[])"/>

   public void
   UpdateRange(params object[] entities) =>
      _table.UpdateRange(entities);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.Remove(TEntity)"/>

   public bool
   Remove(object entity) =>
      _table.Remove(entity);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.RemoveKey(Object)"/>

   public bool
   RemoveKey(object id) =>
      _table.RemoveKey(id);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.RemoveRange(IEnumerable&lt;TEntity>)"/>

   public void
   RemoveRange(IEnumerable<object> entities) =>
      _table.RemoveRange(entities);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.RemoveRange(TEntity[])"/>

   public void
   RemoveRange(params object[] entities) =>
      _table.RemoveRange(entities);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.Refresh(TEntity)"/>

   public void
   Refresh(object entity) =>
      _table.Refresh(entity);
}

/// <summary>
/// A <see cref="SqlSet&lt;TEntity>"/> that provides CRUD (Create, Read, Update, Delete)
/// operations for annotated classes. 
/// This class cannot be instantiated, to get an instance use the <see cref="Database.Table&lt;TEntity>" qualifyHint="true"/> method.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>

[DebuggerDisplay($"{{{nameof(_metaType)}.{nameof(_metaType.Name)}}}")]
public sealed partial class SqlTable<TEntity> : SqlSet<TEntity>, ISqlTable where TEntity : class {

   readonly MetaType
   _metaType;

   /// <inheritdoc cref="SqlTable.Name"/>

   public string
   Name => _metaType.Table.TableName;

   internal
   SqlTable(Database db, MetaType metaType)
      : base([db.FromBody(metaType), db.SelectBody(metaType, null)], db) {

      _metaType = metaType;
   }

   /// <summary>
   /// Recursively executes INSERT commands for the specified <paramref name="entity"/> and all its
   /// one-to-one and one-to-many associations.
   /// </summary>
   /// <param name="entity">
   /// The object whose INSERT command is to be executed. This parameter is named entity for consistency
   /// with the other CRUD methods, but in this case it doesn't need to be an actual entity, which means it doesn't
   /// need to have a primary key.
   /// </param>

   public void
   Add(TEntity entity) {

      ArgumentNullException.ThrowIfNull(entity);

      var idMember = _metaType.DBGeneratedIdentityMember;

      var outputIdMember = idMember is not null
         && _db.Configuration.SqlDialect is SqlDialect.TSql;

      var syncMembers = _metaType.PersistentDataMembers
         .Where(m => m.AutoSync is AutoSync.Always or AutoSync.OnInsert
            && m != idMember)
         .ToArray();

      var insertSql = BuildInsertStatementForEntity(entity, outputIdMember);
      var id = default(object);

      using (var tx = _db.EnsureInTransaction()) {

         if (outputIdMember) {

            // this block emulates Database.Execute()

            var cmd = _db.CreateCommand(insertSql);

            try {
               id = cmd.ExecuteScalar();

            } catch {

               _db.Trace(cmd, error: true);
               throw;
            }

            _db.Trace(cmd);

         } else {

            _db.Execute(insertSql, affect: 1, exact: true);

            if (idMember is not null) {
               id = _db.LastInsertId();
            }
         }

         if (idMember is not null) {

            var convertedId = Convert.ChangeType(id, idMember.Type, CultureInfo.InvariantCulture);
            var entityObj = (object)entity;

            idMember.MemberAccessor.SetBoxedValue(ref entityObj, convertedId);
         }

         if (syncMembers.Length > 0
            && _metaType.IsEntity) {

            Refresh(entity, syncMembers);
         }

         InsertDescendants(entity);

         tx.Commit();
      }
   }

   void
   InsertDescendants(TEntity entity) {

      InsertOneToOne(entity);
      InsertOneToMany(entity);
   }

   void
   InsertOneToOne(TEntity entity) {

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

         otherTable.Add(child);
      }
   }

   void
   InsertOneToMany(TEntity entity) {

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

         var otherTable = _db.Table(assoc.OtherType);
         otherTable.AddRange(many);
      }
   }

   /// <summary>
   /// Recursively executes INSERT commands for the specified <paramref name="entities"/> and all their
   /// one-to-one and one-to-many associations.
   /// </summary>
   /// <param name="entities">The entities whose INSERT commands are to be executed.</param>

   public void
   AddRange(IEnumerable<TEntity> entities) {

      ArgumentNullException.ThrowIfNull(entities);

      AddRange(entities as TEntity[] ?? entities.ToArray());
   }

   /// <inheritdoc cref="AddRange(IEnumerable&lt;TEntity>)"/>

   public void
   AddRange(params TEntity[] entities) {

      ArgumentNullException.ThrowIfNull(entities);

      entities = entities.Where(o => o is not null)
         .ToArray();

      if (entities.Length == 0) {
         return;
      }

      if (entities.Length == 1) {
         Add(entities[0]);
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
            entities.Select(e => BuildInsertStatementForEntity(e)));

         using (var tx = _db.EnsureInTransaction()) {

            _db.Execute(batchInsert, affect: entities.Length, exact: true);

            foreach (var e in entities) {
               InsertDescendants(e);
            }

            tx.Commit();
         }

      } else {

         using (var tx = _db.EnsureInTransaction()) {

            foreach (var e in entities) {
               Add(e);
            }

            tx.Commit();
         }
      }
   }

   /// <summary>
   /// Executes an UPDATE command for the specified <paramref name="entity"/>.
   /// </summary>
   /// <param name="entity">The entity whose UPDATE command is to be executed.</param>

   public void
   Update(TEntity entity) =>
      Update(entity, null);

   /// <inheritdoc cref="Update(TEntity)"/>
   /// <param name="originalId">The original primary key value.</param>
   /// <remarks>This overload is helpful when the entity uses an assigned primary key.</remarks>

   public void
   Update(TEntity entity, object? originalId) {

      ArgumentNullException.ThrowIfNull(entity);

      var updateSql = BuildUpdateStatementForEntity(entity, originalId);

      var syncMembers = _metaType.PersistentDataMembers
         .Where(m => m.AutoSync is AutoSync.Always or AutoSync.OnUpdate)
         .ToArray();

      using (_db.EnsureConnectionOpen()) {

         _db.Execute(updateSql, affect: 1, exact: true);

         if (syncMembers.Length > 0) {
            Refresh(entity, syncMembers);
         }
      }
   }

   /// <summary>
   /// Executes UPDATE commands for the specified <paramref name="entities"/>.
   /// </summary>
   /// <param name="entities">The entities whose UPDATE commands are to be executed.</param>

   public void
   UpdateRange(IEnumerable<TEntity> entities) {

      ArgumentNullException.ThrowIfNull(entities);

      UpdateRange(entities as TEntity[] ?? entities.ToArray());
   }

   /// <summary>
   /// Executes UPDATE commands for the specified <paramref name="entities"/>.
   /// </summary>
   /// <param name="entities">The entities whose UPDATE commands are to be executed.</param>

   public void
   UpdateRange(params TEntity[] entities) {

      ArgumentNullException.ThrowIfNull(entities);

      entities = entities.Where(o => o is not null)
         .ToArray();

      if (entities.Length == 0) {
         return;
      }

      if (entities.Length == 1) {
         Update(entities[0]);
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
            entities.Select(e => BuildUpdateStatementForEntity(e)));

         _db.Execute(batchUpdate, affect: entities.Length, exact: true);

      } else {

         using (var tx = _db.EnsureInTransaction()) {

            foreach (var e in entities) {
               Update(e);
            }

            tx.Commit();
         }
      }
   }

   /// <summary>
   /// Executes a DELETE command for the specified <paramref name="entity"/>.
   /// </summary>
   /// <param name="entity">The entity whose DELETE command is to be executed.</param>
   /// <returns><c>true</c> if <paramref name="entity"/> is deleted; otherwise, <c>false</c>.</returns>

   public bool
   Remove(TEntity entity) {

      ArgumentNullException.ThrowIfNull(entity);

      var deleteSql = BuildDeleteStatementForEntity(entity);

      var usingVersion = _db.Configuration.UseVersionMember
         && _metaType.VersionMember is not null;

      return _db.Execute(deleteSql, affect: 1, exact: usingVersion) == 1;
   }

   /// <summary>
   /// Executes a DELETE command for the entity
   /// whose primary key matches the <paramref name="id"/> parameter.
   /// </summary>
   /// <param name="id">The primary key value.</param>
   /// <returns><c>true</c> if a record that matches <paramref name="id"/> was found and deleted; otherwise, <c>false</c>.</returns>

   public bool
   RemoveKey(object id) {

      ArgumentNullException.ThrowIfNull(id);

      var deleteSql = BuildDeleteStatementForKey(id);

      return _db.Execute(deleteSql, affect: 1) == 1;
   }

   /// <summary>
   /// Executes DELETE commands for the specified <paramref name="entities"/>.
   /// </summary>
   /// <param name="entities">The entities whose DELETE commands are to be executed.</param>

   public void
   RemoveRange(IEnumerable<TEntity> entities) {

      ArgumentNullException.ThrowIfNull(entities);

      RemoveRange(entities as TEntity[] ?? entities.ToArray());
   }

   /// <summary>
   /// Executes DELETE commands for the specified <paramref name="entities"/>.
   /// </summary>
   /// <param name="entities">The entities whose DELETE commands are to be executed.</param>

   public void
   RemoveRange(params TEntity[] entities) {

      ArgumentNullException.ThrowIfNull(entities);

      entities = entities.Where(o => o is not null)
         .ToArray();

      if (entities.Length == 0) {
         return;
      }

      if (entities.Length == 1) {
         Remove(entities[0]);
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

         var sql = BuildDeleteStatement()
            .WHERE(String.Empty);

         var sb = sql.Buffer;

         _db.QuoteIdentifier(sb, idMember.MappedName);
         sb.Append(" IN (");

         for (int i = 0; i < ids.Length; i++) {

            if (i > 0) {
               sb.Append(',')
                  .Append(' ');
            }

            sb.Append('{')
               .Append(sql.ParameterValues.Count)
               .Append('}');

            sql.ParameterValues.Add(ids[i]);
         }

         sb.Append(')');

         _db.Execute(sql, affect: entities.Length);

      } else if (batch) {

         var batchDelete = SqlBuilder.JoinSql(
            ";" + Environment.NewLine,
            entities.Select(e => BuildDeleteStatementForEntity(e)));

         _db.Execute(batchDelete, affect: entities.Length, exact: usingVersion);

      } else {

         using (var tx = _db.EnsureInTransaction()) {

            foreach (var e in entities) {
               Remove(e);
            }

            tx.Commit();
         }
      }
   }

   /// <summary>
   /// Sets all column members of <paramref name="entity"/> to their most current persisted value.
   /// </summary>
   /// <param name="entity">The entity to refresh.</param>

   public void
   Refresh(TEntity entity) =>
      Refresh(entity, null);

   void
   Refresh(TEntity entity, IEnumerable<MetaDataMember>? refreshMembers) {

      ArgumentNullException.ThrowIfNull(entity);

      EnsureEntityType();

      var query = BuildSelectStatement(refreshMembers);
      query.WHERE(_db.BuildPredicateFragment(entity, _metaType.IdentityMembers, query.ParameterValues));

      var mapper = _db.CreatePocoMapper(_metaType.Type);

      var entityObj = (object)entity;

      _ = _db.Map<object?>(query, r => {
         mapper.PocoLoad(entityObj, r);
         return null;

      }).SingleOrDefault();
   }

   void
   EnsureEntityType() =>
      SqlTable.EnsureEntityType(_metaType);

   // ISqlTable Members

   void
   ISqlTable.Add(object entity) =>
      Add((TEntity)entity);

   void
   ISqlTable.AddRange(IEnumerable<object> entities) =>
      AddRange(entities.Cast<TEntity>());

   void
   ISqlTable.AddRange(params object[] entities) =>
      AddRange(entities.Cast<TEntity>());

   void
   ISqlTable.Update(object entity) =>
      Update((TEntity)entity);

   void
   ISqlTable.Update(object entity, object? originalId) =>
      Update((TEntity)entity, originalId);

   void
   ISqlTable.UpdateRange(IEnumerable<object> entities) =>
      UpdateRange(entities.Cast<TEntity>());

   void
   ISqlTable.UpdateRange(params object[] entities) =>
      UpdateRange(entities.Cast<TEntity>());

   bool
   ISqlTable.Remove(object entity) =>
      Remove((TEntity)entity);

   bool
   ISqlTable.RemoveKey(object id) =>
      RemoveKey(id);

   void
   ISqlTable.RemoveRange(IEnumerable<object> entities) =>
      RemoveRange(entities.Cast<TEntity>());

   void
   ISqlTable.RemoveRange(params object[] entities) =>
      RemoveRange(entities.Cast<TEntity>());

   void
   ISqlTable.Refresh(object entity) =>
      Refresh((TEntity)entity);
}

partial class SqlTable<TEntity> {

   SqlBuilder
   BuildSelectStatement(IEnumerable<MetaDataMember>? selectMembers) {

      var sql = new SqlBuilder()
         .SELECT(String.Empty);

      _db.SelectBody(sql.Buffer, _metaType, selectMembers, null);

      sql.FROM(_db.FromBody(_metaType));

      return sql;
   }

   SqlBuilder
   BuildInsertStatementForEntity(TEntity entity) =>
      BuildInsertStatementForEntity(entity, false);

   SqlBuilder
   BuildInsertStatementForEntity(TEntity entity, bool outputIdMember) {

      ArgumentNullException.ThrowIfNull(entity);

      var insertingMembers = _metaType.PersistentDataMembers
         .Where(m => !m.IsAssociation && !m.IsDbGenerated)
         .ToArray();

      var parameters = insertingMembers
         .Select(m => m.GetValueForDatabase(entity))
         .ToArray();

      var sql = new SqlBuilder();

      var sb = sql.Buffer
         .Append("INSERT INTO ");

      _db.QuoteIdentifier(sb, _metaType.Table.TableName);
      sb.Append(" (");

      for (int i = 0; i < insertingMembers.Length; i++) {

         if (i > 0) {
            sb.Append(", ");
         }

         _db.QuoteIdentifier(sb, insertingMembers[i].MappedName);
      }

      sb.Append(')');

      if (outputIdMember
         && _metaType.DBGeneratedIdentityMember is { } idMember) {

         sb.AppendLine()
            .Append("OUTPUT INSERTED.");
         _db.QuoteIdentifier(sb, idMember.MappedName);
      }

      sb.AppendLine()
         .Append("VALUES (");

      for (int i = 0; i < insertingMembers.Length; i++) {

         if (i > 0) {
            sb.Append(", ");
         }

         sb.Append('{')
            .Append(i)
            .Append('}');
      }

      sb.Append(')');

      foreach (var item in parameters) {
         sql.ParameterValues.Add(item);
      }

      return sql;
   }

   SqlBuilder
   BuildUpdateStatementForEntity(TEntity entity) =>
      BuildUpdateStatementForEntity(entity, null);

   SqlBuilder
   BuildUpdateStatementForEntity(TEntity entity, object? originalId) {

      ArgumentNullException.ThrowIfNull(entity);

      EnsureEntityType();

      var updatingMembers = _metaType.PersistentDataMembers
         .Where(m => !m.IsAssociation && !m.IsDbGenerated)
         .ToArray();

      var predicateMembers = _metaType.PersistentDataMembers
         .Where(m => m.IsPrimaryKey || (m.IsVersion && _db.Configuration.UseVersionMember))
         .ToArray();

      if (originalId is not null
         && predicateMembers.Count(m => m.IsPrimaryKey) > 1) {

         throw new InvalidOperationException("The operation is not supported for entities with more than one identity member.");
      }

      var sql = new SqlBuilder();
      var parametersBuffer = sql.ParameterValues;

      var sb = sql.Buffer
         .Append("UPDATE ");

      _db.QuoteIdentifier(sb, _metaType.Table.TableName);

      sb.AppendLine()
         .Append("SET ");

      for (int i = 0; i < updatingMembers.Length; i++) {

         if (i > 0) {
            sb.Append(", ");
         }

         var member = updatingMembers[i];
         var value = member.GetValueForDatabase(entity);

         _db.QuoteIdentifier(sb, member.MappedName);

         sb.Append(" = {")
            .Append(parametersBuffer.Count)
            .Append('}');

         parametersBuffer.Add(value);
      }

      var getValuefn = default(Func<MetaDataMember, object>);

      if (originalId is not null) {

         getValuefn = m => (m.IsPrimaryKey) ?
            m.ConvertValueForDatabase(originalId)
            : m.GetValueForDatabase(entity);
      }

      sb.AppendLine()
         .Append("WHERE ")
         .Append(_db.BuildPredicateFragment(entity, predicateMembers, parametersBuffer, getValuefn));

      return sql;
   }

   SqlBuilder
   BuildDeleteStatement() {

      var sql = new SqlBuilder()
         .Append("DELETE FROM ");

      _db.QuoteIdentifier(sql.Buffer, _metaType.Table.TableName);

      return sql;
   }

   SqlBuilder
   BuildDeleteStatementForEntity(TEntity entity) {

      ArgumentNullException.ThrowIfNull(entity);

      EnsureEntityType();

      var predicateMembers = _metaType.PersistentDataMembers
         .Where(m => m.IsPrimaryKey || (m.IsVersion && _db.Configuration.UseVersionMember));

      var deleteSql = BuildDeleteStatement();
      deleteSql.WHERE(_db.BuildPredicateFragment(entity, predicateMembers, deleteSql.ParameterValues));

      return deleteSql;
   }

   SqlBuilder
   BuildDeleteStatementForKey(object id) {

      ArgumentNullException.ThrowIfNull(id);

      EnsureEntityType();

      if (_metaType.IdentityMembers.Count > 1) {
         throw new InvalidOperationException("Cannot call this method when the entity has more than one identity member.");
      }

      var deleteSql = BuildDeleteStatement()
         .WHERE(String.Empty);

      var sb = deleteSql.Buffer;

      _db.QuoteIdentifier(sb, _metaType.IdentityMembers[0].MappedName);

      sb.Append(" = {")
         .Append(deleteSql.ParameterValues.Count)
         .Append('}');

      deleteSql.ParameterValues.Add(id);

      return deleteSql;
   }
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

         var db = source._db;

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

         var query = BuildJoinedQuery(parts, metaType, source._db, selectBuild, fromAppend, out manyAssoc, out manyIndex);

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

         var db = set._db;
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

               db.SelectBody(sql.Buffer, table._metaType, null, alias);

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

         set.ManyIncludes ??= new Dictionary<string[], CollectionLoader>();

         set.ManyIncludes.Add(manyPath, new CollectionLoader(
            c => GetMany(c, manyAssoc, manySource),
            manyAssoc.ThisMember));
      }

      static IEnumerable
      GetMany(object container, MetaAssociation association, SqlSet set) {

         var predicateValues = association.OtherKey.Select((p, i) =>
            new KeyValuePair<string, object>(p.MappedName, association.ThisKey[i].GetValueForDatabase(container)));

         var parameters = new List<object?>(association.OtherKey.Count);
         var whereFragment = new SqlFragment(set._db.BuildPredicateFragment(predicateValues, parameters), parameters);

         var children = set.Where(whereFragment)
            .AsEnumerable();

         var otherMember = association.OtherMember;
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

partial interface ISqlTable {

   string
   Name { get; }

   void
   Add(object entity);

   void
   AddRange(IEnumerable<object> entities);

   void
   AddRange(params object[] entities);

   bool
   Remove(object entity);

   bool
   RemoveKey(object id);

   void
   RemoveRange(IEnumerable<object> entities);

   void
   RemoveRange(params object[] entities);

   void
   Refresh(object entity);

   void
   Update(object entity);

   void
   Update(object entity, object? originalId);

   void
   UpdateRange(IEnumerable<object> entities);

   void
   UpdateRange(params object[] entities);
}
