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
using System.Text;

namespace DbExtensions;

using Metadata;

partial class Database {

   static readonly MethodInfo
   _tableMethod = typeof(Database)
      .GetMethods(BindingFlags.Public | BindingFlags.Instance)
      .Single(m => m.Name == nameof(Table) && m.ContainsGenericParameters && m.GetParameters().Length == 0);

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
      SqlTable<TEntity> table;

      if (_genericTables.TryGetValue(metaType, out var set)) {
         table = (SqlTable<TEntity>)set;

      } else {
         table = new SqlTable<TEntity>(this, metaType);
         _genericTables.Add(metaType, table);
      }

      return table;
   }

   /// <summary>
   /// Returns the <see cref="SqlTable"/> instance for the specified <paramref name="entityType"/>.
   /// </summary>
   /// <param name="entityType">The type of the entity.</param>
   /// <returns>The <see cref="SqlTable"/> instance for <paramref name="entityType"/>.</returns>

   public SqlTable
   Table(Type entityType) =>
      Table(this.Configuration.GetMetaType(entityType));

   internal SqlTable
   Table(MetaType metaType) {

      SqlTable table;

      if (!_tables.TryGetValue(metaType, out table)) {

         var genericTable = (ISqlTable)
            _tableMethod.MakeGenericMethod(metaType.Type).Invoke(this, null);

         table = new SqlTable(this, metaType, genericTable);
         _tables.Add(metaType, table);
      }

      return table;
   }

   /// <inheritdoc cref="SqlTable.Add(Object)"/>
   /// <remarks>This method is a shortcut for <c>db.Table(entity.GetType()).Add(entity)</c>.</remarks>
   /// <seealso cref="SqlTable.Add(Object)"/>

   public void
   Add(object entity) {

      if (entity is null) throw new ArgumentNullException(nameof(entity));

      Table(entity.GetType())
         .Add(entity);
   }

   /// <inheritdoc cref="SqlSet&lt;TEntity>.Find(Object)" path="*[not(self::remarks or self::exception[@cref='T:System.InvalidOperationException'])]"/>
   /// <typeparam name="TEntity">The type of the entity.</typeparam>
   /// <remarks>This method is a shortcut for <c>db.Table&lt;TEntity>().Find(id)</c>.</remarks>
   /// <seealso cref="SqlSet&lt;TEntity>.Find(Object)"/>

   public TEntity
   Find<TEntity>(object id) where TEntity : class =>
      Table<TEntity>().Find(id);

   /// <inheritdoc cref="SqlSet.Find(Object)" path="*[not(self::remarks or self::exception[@cref='T:System.InvalidOperationException'])]"/>
   /// <param name="entityType">The type of the entity.</param>
   /// <remarks>This method is a shortcut for <c>db.Table(entityType).Find(id)</c>.</remarks>
   /// <seealso cref="SqlSet.Find(Object)"/>

   public object
   Find(Type entityType, object id) {

      if (entityType is null) throw new ArgumentNullException(nameof(entityType));

      return Table(entityType)
         .Find(id);
   }

   /// <inheritdoc cref="SqlSet.Contains(Object)" path="*[not(self::remarks or self::exception[@cref='T:System.InvalidOperationException'])]"/>
   /// <remarks>This method is a shortcut for <c>db.Table(entity.GetType()).Contains(entity)</c>.</remarks>
   /// <seealso cref="SqlSet.Contains(Object)"/>

   public bool
   Contains(object entity) {

      if (entity is null) throw new ArgumentNullException(nameof(entity));

      return Table(entity.GetType())
         .Contains(entity);
   }

   /// <inheritdoc cref="SqlSet.ContainsKey(Object)" path="*[not(self::remarks or self::exception[@cref='T:System.InvalidOperationException'])]"/>
   /// <typeparam name="TEntity">The type of the entity.</typeparam>
   /// <remarks>This method is a shortcut for <c>db.Table&lt;TEntity>().ContainsKey(id)</c>.</remarks>
   /// <seealso cref="SqlSet.ContainsKey(Object)"/>

   public bool
   ContainsKey<TEntity>(object id) where TEntity : class =>
      Table<TEntity>().ContainsKey(id);

   /// <inheritdoc cref="SqlSet.ContainsKey(Object)" path="*[not(self::remarks or self::exception[@cref='T:System.InvalidOperationException'])]"/>
   /// <param name="entityType">The type of the entity.</param>
   /// <remarks>This method is a shortcut for <c>db.Table(entityType).ContainsKey(id)</c>.</remarks>
   /// <seealso cref="SqlSet.ContainsKey(Object)"/>

   public bool
   ContainsKey(Type entityType, object id) {

      if (entityType is null) throw new ArgumentNullException(nameof(entityType));

      return Table(entityType)
         .ContainsKey(id);
   }

   /// <inheritdoc cref="SqlTable.Update(Object)"/>
   /// <remarks>This method is a shortcut for <c>db.Table(entity.GetType()).Update(entity)</c>.</remarks>
   /// <seealso cref="SqlTable.Update(Object)"/>

   public void
   Update(object entity) {

      if (entity is null) throw new ArgumentNullException(nameof(entity));

      Table(entity.GetType())
         .Update(entity);
   }

   /// <inheritdoc cref="SqlTable.Update(Object, Object)"/>
   /// <remarks>This method is a shortcut for <c>db.Table(entity.GetType()).Update(entity, originalId)</c>.</remarks>
   /// <seealso cref="SqlTable.Update(Object, Object)"/>

   public void
   Update(object entity, object originalId) {

      if (entity is null) throw new ArgumentNullException(nameof(entity));

      Table(entity.GetType())
         .Update(entity, originalId);
   }

   /// <inheritdoc cref="SqlTable.Remove(Object)"/>
   /// <remarks>This method is a shortcut for <c>db.Table(entity.GetType()).Remove(entity)</c>.</remarks>
   /// <seealso cref="SqlTable.Remove(Object)"/>

   public void
   Remove(object entity) {

      if (entity is null) throw new ArgumentNullException(nameof(entity));

      Table(entity.GetType())
         .Remove(entity);
   }

   /// <inheritdoc cref="SqlTable&lt;TEntity>.RemoveKey(Object)"/>
   /// <remarks>This method is a shortcut for <c>db.Table&lt;TEntity>().RemoveKey(id)</c>.</remarks>
   /// <seealso cref="SqlTable&lt;TEntity>.RemoveKey(Object)"/>

   public void
   RemoveKey<TEntity>(object id) where TEntity : class =>
      Table<TEntity>().RemoveKey(id);

   /// <inheritdoc cref="SqlTable.RemoveKey(Object)"/>
   /// <param name="entityType">The type of the entity.</param>
   /// <remarks>This method is a shortcut for <c>db.Table(entityType).RemoveKey(id)</c>.</remarks>
   /// <seealso cref="SqlTable.RemoveKey(Object)"/>

   public void
   RemoveKey(Type entityType, object id) {

      if (entityType is null) throw new ArgumentNullException(nameof(entityType));

      Table(entityType)
         .RemoveKey(id);
   }

   internal string
   BuildPredicateFragment(
         object entity,
         IEnumerable<MetaDataMember> predicateMembers,
         ICollection<object> parametersBuffer,
         Func<MetaDataMember, object> getValueFn = null) {

      var predicateValues = predicateMembers.Select(m =>
         new KeyValuePair<string, object>(
            m.MappedName,
            (getValueFn is not null) ? getValueFn.Invoke(m) : m.GetValueForDatabase(entity)
         )
      );

      return BuildPredicateFragment(predicateValues, parametersBuffer);
   }

   internal string
   BuildPredicateFragment(IEnumerable<KeyValuePair<string, object>> predicateValues, ICollection<object> parametersBuffer) {

      //if (predicateValues is null || predicateValues.Count == 0) throw new ArgumentException("predicateValues cannot be empty", nameof(predicateValues));
      if (parametersBuffer is null) throw new ArgumentNullException(nameof(parametersBuffer));

      var sb = new StringBuilder();

      foreach (var item in predicateValues) {

         if (sb.Length > 0) {
            sb.Append(" AND ");
         }

         sb.Append(QuoteIdentifier(item.Key));

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
   SelectBody(MetaType metaType, IEnumerable<MetaDataMember> selectMembers, string tableAlias) {

      selectMembers ??= metaType.PersistentDataMembers.Where(m => !m.IsAssociation);

      var sb = new StringBuilder();

      var qualifier = (!String.IsNullOrEmpty(tableAlias)) ?
         QuoteIdentifier(tableAlias) + "." : null;

      var enumerator = selectMembers.GetEnumerator();

      while (enumerator.MoveNext()) {

         var mappedName = enumerator.Current.MappedName;
         var memberName = enumerator.Current.QueryPath;
         var columnAlias = !String.Equals(mappedName, memberName, StringComparison.Ordinal) ?
            memberName : null;

         if (sb.Length > 0) {
            sb.Append(", ");
         }

         if (qualifier is not null) {
            sb.Append(qualifier);
         }

         sb.Append(QuoteIdentifier(enumerator.Current.MappedName));

         if (columnAlias is not null) {

            sb.Append(" AS ")
               .Append(QuoteIdentifier(memberName));
         }
      }

      return sb.ToString();
   }

   internal string
   FromBody(MetaType metaType, string tableAlias) {

      if (metaType.Table is null) throw new InvalidOperationException("metaType.Table cannot be null.");

      var alias = (!String.IsNullOrEmpty(tableAlias)) ?
         " " + QuoteIdentifier(tableAlias)
         : null;

      return QuoteIdentifier(metaType.Table.TableName) + alias;
   }
}

sealed partial class DatabaseConfiguration {

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
   /// true to include version column check in SQL statements' predicates; otherwise, false. The default is true.
   /// </summary>

   public bool
   UseVersionMember { get; set; } = true;

   /// <summary>
   /// true to execute batch commands when possible; otherwise, false. The default is true.
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
   /// is specified on <see cref="ComplexPropertyAttribute.Separator"/>.
   /// </summary>

   public string
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
/// This class cannot be instantiated, to get an instance use the <see cref="Database.Table(Type)"/> method.
/// </summary>

[DebuggerDisplay("{_metaType.Name}")]
public sealed class SqlTable : SqlSet, ISqlTable {

   // table is the SqlTable<TEntity> instance for metaType
   // SqlTable is only a wrapper on SqlTable<TEntity>

   readonly ISqlTable
   _table;

   readonly MetaType
   _metaType;

   /// <summary>
   /// Gets the name of the table.
   /// </summary>

   public string
   Name => _metaType.Table.TableName;

   /// <summary>
   /// Gets a <see cref="SqlCommandBuilder&lt;Object>"/> object for the current table.
   /// </summary>

   public SqlCommandBuilder<object>
   CommandBuilder { get; }

   internal
   SqlTable(Database db, MetaType metaType, ISqlTable table)
      : base(new string[2] { db.FromBody(metaType, null), db.SelectBody(metaType, null, null) }, metaType.Type, db) {

      _table = table;

      _metaType = metaType;
      this.CommandBuilder = new SqlCommandBuilder<object>(db, metaType);
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

   #region ISqlTable Members

   // These methods just call the same method on this.table

   /// <inheritdoc cref="SqlTable&lt;TEntity>.Add(TEntity)"/>

   public void
   Add(object entity) =>
      _table.Add(entity);

   void
   ISqlTable.AddDescendants(object entity) =>
      _table.AddDescendants(entity);

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
   Update(object entity, object originalId) =>
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

   public void
   Remove(object entity) =>
      _table.Remove(entity);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.RemoveKey(Object)"/>

   public void
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

   /// <inheritdoc cref="SqlSet.Contains(Object)" path="*[not(self::exception[@cref='T:System.InvalidOperationException'])]"/>

   public new bool
   Contains(object entity) =>
      base.Contains(entity);

   /// <inheritdoc cref="SqlSet.ContainsKey(Object)" path="*[not(self::exception[@cref='T:System.InvalidOperationException'])]"/>

   public new bool
   ContainsKey(object id) =>
      base.ContainsKey(id);

   /// <inheritdoc cref="SqlTable&lt;TEntity>.Refresh(TEntity)"/>

   public void
   Refresh(object entity) =>
      _table.Refresh(entity);

   #endregion
}

/// <summary>
/// A <see cref="SqlSet&lt;TEntity>"/> that provides CRUD (Create, Read, Update, Delete)
/// operations for annotated classes. 
/// This class cannot be instantiated, to get an instance use the <see cref="Database.Table&lt;TEntity>"/> method.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>

[DebuggerDisplay("{_metaType.Name}")]
public sealed class SqlTable<TEntity> : SqlSet<TEntity>, ISqlTable where TEntity : class {

   readonly MetaType
   _metaType;

   /// <inheritdoc cref="SqlTable.Name"/>

   public string
   Name => _metaType.Table.TableName;

   /// <summary>
   /// Gets a <see cref="SqlCommandBuilder&lt;TEntity>"/> object for the current table.
   /// </summary>

   public SqlCommandBuilder<TEntity>
   CommandBuilder { get; }

   internal
   SqlTable(Database db, MetaType metaType)
      : base(new string[2] { db.FromBody(metaType, null), db.SelectBody(metaType, null, null) }, db) {

      _metaType = metaType;
      this.CommandBuilder = new SqlCommandBuilder<TEntity>(db, metaType);
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

      if (entity is null) throw new ArgumentNullException(nameof(entity));

      var insertSql = this.CommandBuilder.BuildInsertStatementForEntity(entity);

      var idMember = _metaType.DBGeneratedIdentityMember;

      var syncMembers = _metaType.PersistentDataMembers
         .Where(m => (m.AutoSync == AutoSync.Always || m.AutoSync == AutoSync.OnInsert)
            && m != idMember)
         .ToArray();

      using (var tx = _db.EnsureInTransaction()) {

         _db.Execute(insertSql, affect: 1, exact: true);

         if (idMember is not null) {

            var id = _db.LastInsertId();
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

      var oneToOne = _metaType.Associations
         .Where(a => !a.IsMany && a.ThisKeyIsPrimaryKey && a.OtherKeyIsPrimaryKey)
         .ToArray();

      for (int i = 0; i < oneToOne.Length; i++) {

         var assoc = oneToOne[i];

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

      var oneToMany = _metaType.Associations.Where(a => a.IsMany).ToArray();

      for (int i = 0; i < oneToMany.Length; i++) {

         var assoc = oneToMany[i];

         var many = ((IEnumerable<object>)assoc.ThisMember.MemberAccessor.GetBoxedValue(entity) ?? new object[0])
            .Where(o => o is not null)
            .ToArray();

         if (many.Length == 0) continue;

         for (int j = 0; j < many.Length; j++) {

            var child = many[j];

            for (int k = 0; k < assoc.ThisKey.Count; k++) {

               var thisKey = assoc.ThisKey[k];
               var otherKey = assoc.OtherKey[k];

               var thisKeyVal = thisKey.MemberAccessor.GetBoxedValue(entity);

               otherKey.MemberAccessor.SetBoxedValue(ref child, thisKeyVal);
            }
         }

         var otherTable = _db.Table(assoc.OtherType);

         otherTable.AddRange(many);

         for (int j = 0; j < many.Length; j++) {

            var child = many[j];

            ((ISqlTable)otherTable).AddDescendants(child);
         }
      }
   }

   /// <summary>
   /// Recursively executes INSERT commands for the specified <paramref name="entities"/> and all their
   /// one-to-one and one-to-many associations.
   /// </summary>
   /// <param name="entities">The entities whose INSERT commands are to be executed.</param>

   public void
   AddRange(IEnumerable<TEntity> entities) {

      if (entities is null) throw new ArgumentNullException(nameof(entities));

      AddRange(entities.ToArray());
   }

   /// <inheritdoc cref="AddRange(IEnumerable&lt;TEntity>)"/>

   public void
   AddRange(params TEntity[] entities) {

      if (entities is null) throw new ArgumentNullException(nameof(entities));

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
         .Where(m => m.AutoSync == AutoSync.Always || m.AutoSync == AutoSync.OnInsert)
         .ToArray();

      var batch = syncMembers.Length == 0
         && _db.Configuration.EnableBatchCommands;

      if (batch) {

         var batchInsert = SqlBuilder.JoinSql(";" + Environment.NewLine, entities.Select(e => this.CommandBuilder.BuildInsertStatementForEntity(e)));

         using (var tx = _db.EnsureInTransaction()) {

            _db.Execute(batchInsert, affect: entities.Length, exact: true);

            for (int i = 0; i < entities.Length; i++) {
               InsertDescendants(entities[i]);
            }

            tx.Commit();
         }

      } else {

         using (var tx = _db.EnsureInTransaction()) {

            for (int i = 0; i < entities.Length; i++) {
               Add(entities[i]);
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
   Update(TEntity entity, object originalId) {

      if (entity is null) throw new ArgumentNullException(nameof(entity));

      var updateSql = this.CommandBuilder.BuildUpdateStatementForEntity(entity, originalId);

      var syncMembers = _metaType.PersistentDataMembers
         .Where(m => m.AutoSync == AutoSync.Always || m.AutoSync == AutoSync.OnUpdate)
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

      if (entities is null) throw new ArgumentNullException(nameof(entities));

      UpdateRange(entities.ToArray());
   }

   /// <summary>
   /// Executes UPDATE commands for the specified <paramref name="entities"/>.
   /// </summary>
   /// <param name="entities">The entities whose UPDATE commands are to be executed.</param>

   public void
   UpdateRange(params TEntity[] entities) {

      if (entities is null) throw new ArgumentNullException(nameof(entities));

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
         .Where(m => m.AutoSync == AutoSync.Always || m.AutoSync == AutoSync.OnUpdate)
         .ToArray();

      var batch = syncMembers.Length == 0
         && _db.Configuration.EnableBatchCommands;

      if (batch) {

         var batchUpdate = SqlBuilder.JoinSql(";" + Environment.NewLine, entities.Select(e => this.CommandBuilder.BuildUpdateStatementForEntity(e)));

         _db.Execute(batchUpdate, affect: entities.Length, exact: true);

      } else {

         using (var tx = _db.EnsureInTransaction()) {

            for (int i = 0; i < entities.Length; i++) {
               Update(entities[i]);
            }

            tx.Commit();
         }
      }
   }

   /// <summary>
   /// Executes a DELETE command for the specified <paramref name="entity"/>.
   /// </summary>
   /// <param name="entity">The entity whose DELETE command is to be executed.</param>

   public void
   Remove(TEntity entity) {

      if (entity is null) throw new ArgumentNullException(nameof(entity));

      var deleteSql = this.CommandBuilder.BuildDeleteStatementForEntity(entity);

      var usingVersion = _db.Configuration.UseVersionMember
         && _metaType.VersionMember is not null;

      _db.Execute(deleteSql, affect: 1, exact: usingVersion);
   }

   /// <summary>
   /// Executes a DELETE command for the entity
   /// whose primary key matches the <paramref name="id"/> parameter.
   /// </summary>
   /// <param name="id">The primary key value.</param>

   public void
   RemoveKey(object id) {

      var deleteSql = this.CommandBuilder.BuildDeleteStatementForKey(id);

      _db.Execute(deleteSql, affect: 1);
   }

   /// <summary>
   /// Executes DELETE commands for the specified <paramref name="entities"/>.
   /// </summary>
   /// <param name="entities">The entities whose DELETE commands are to be executed.</param>

   public void
   RemoveRange(IEnumerable<TEntity> entities) {

      if (entities is null) throw new ArgumentNullException(nameof(entities));

      RemoveRange(entities.ToArray());
   }

   /// <summary>
   /// Executes DELETE commands for the specified <paramref name="entities"/>.
   /// </summary>
   /// <param name="entities">The entities whose DELETE commands are to be executed.</param>

   public void
   RemoveRange(params TEntity[] entities) {

      if (entities is null) throw new ArgumentNullException(nameof(entities));

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

         var sql = this.CommandBuilder
            .BuildDeleteStatement()
            .WHERE(_db.QuoteIdentifier(idMember.MappedName) + " IN ({0})", SQL.List(ids));

         _db.Execute(sql, affect: entities.Length);

      } else if (batch) {

         var batchDelete = SqlBuilder.JoinSql(";" + Environment.NewLine, entities.Select(e => this.CommandBuilder.BuildDeleteStatementForEntity(e)));

         _db.Execute(batchDelete, affect: entities.Length, exact: usingVersion);

      } else {

         using (var tx = _db.EnsureInTransaction()) {

            for (int i = 0; i < entities.Length; i++) {
               Remove(entities[i]);
            }

            tx.Commit();
         }
      }
   }

   /// <inheritdoc cref="SqlSet&lt;TEntity>.Contains(TEntity)" path="*[not(self::exception[@cref='T:System.InvalidOperationException'])]"/>

   public new bool
   Contains(TEntity entity) =>
      base.Contains(entity);

   /// <inheritdoc cref="SqlSet.ContainsKey(Object)" path="*[not(self::exception[@cref='T:System.InvalidOperationException'])]"/>

   public new bool
   ContainsKey(object id) =>
      base.ContainsKey(id);

   /// <summary>
   /// Sets all column members of <paramref name="entity"/> to their most current persisted value.
   /// </summary>
   /// <param name="entity">The entity to refresh.</param>

   public void
   Refresh(TEntity entity) =>
      Refresh(entity, null);

   void
   Refresh(TEntity entity, IEnumerable<MetaDataMember> refreshMembers) {

      if (entity is null) throw new ArgumentNullException(nameof(entity));

      EnsureEntityType();

      var query = this.CommandBuilder.BuildSelectStatement(refreshMembers);
      query.WHERE(_db.BuildPredicateFragment(entity, _metaType.IdentityMembers, query.ParameterValues));

      var mapper = _db.CreatePocoMapper(_metaType.Type);

      var entityObj = (object)entity;

      _db.Map<object>(query, r => {
         mapper.Load(entityObj, r);
         return null;

      }).SingleOrDefault();
   }

   void
   EnsureEntityType() =>
      SqlTable.EnsureEntityType(_metaType);

   #region ISqlTable Members

   void
   ISqlTable.Add(object entity) =>
      Add((TEntity)entity);

   void
   ISqlTable.AddDescendants(object entity) =>
      InsertDescendants((TEntity)entity);

   void
   ISqlTable.AddRange(IEnumerable<object> entities) =>
      AddRange((IEnumerable<TEntity>)entities);

   void
   ISqlTable.AddRange(params object[] entities) {

      if (entities is null) throw new ArgumentNullException(nameof(entities));

      AddRange(entities as TEntity[] ?? entities.Cast<TEntity>().ToArray());
   }

   void
   ISqlTable.Update(object entity) =>
      Update((TEntity)entity);

   void
   ISqlTable.Update(object entity, object originalId) =>
      Update((TEntity)entity, originalId);

   void
   ISqlTable.UpdateRange(IEnumerable<object> entities) =>
      UpdateRange((IEnumerable<TEntity>)entities);

   void
   ISqlTable.UpdateRange(params object[] entities) {

      if (entities is null) throw new ArgumentNullException(nameof(entities));

      UpdateRange(entities as TEntity[] ?? entities.Cast<TEntity>().ToArray());
   }

   void
   ISqlTable.Remove(object entity) =>
      Remove((TEntity)entity);

   void
   ISqlTable.RemoveKey(object id) =>
      RemoveKey(id);

   void
   ISqlTable.RemoveRange(IEnumerable<object> entities) =>
      RemoveRange((IEnumerable<TEntity>)entities);

   void
   ISqlTable.RemoveRange(params object[] entities) {

      if (entities is null) throw new ArgumentNullException(nameof(entities));

      RemoveRange(entities as TEntity[] ?? entities.Cast<TEntity>().ToArray());
   }

   void
   ISqlTable.Refresh(object entity) =>
      Refresh((TEntity)entity);

   #endregion
}

/// <summary>
/// Generates SQL commands for annotated classes.
/// This class cannot be instantiated, to get an instance use the <see cref="SqlTable&lt;TEntity>.CommandBuilder"/>
/// or <see cref="SqlTable.CommandBuilder"/> properties.
/// </summary>
/// <typeparam name="TEntity">The type of the entity to generate commands for.</typeparam>

public sealed class SqlCommandBuilder<TEntity> where TEntity : class {

   readonly Database
   _db;

   readonly MetaType
   _metaType;

   internal
   SqlCommandBuilder(Database db, MetaType metaType) {
      _db = db;
      _metaType = metaType;
   }

   /// <summary>
   /// Creates and returns a SELECT query for the current table
   /// that includes the SELECT clause only.
   /// </summary>
   /// <returns>The SELECT query for the current table.</returns>

   public SqlBuilder
   BuildSelectClause() =>
      BuildSelectClause(null);

   /// <summary>
   /// Creates and returns a SELECT query for the current table
   /// that includes the SELECT clause only. All column names are qualified with the provided
   /// <paramref name="tableAlias"/>.
   /// </summary>
   /// <param name="tableAlias">The table alias.</param>
   /// <returns>The SELECT query for the current table.</returns>

   public SqlBuilder
   BuildSelectClause(string tableAlias) =>
      BuildSelectClause(null, tableAlias);

   /// <summary>
   /// Creates and returns a SELECT query using the specified <paramref name="selectMembers"/>
   /// that includes the SELECT clause only. All column names are qualified with the provided
   /// <paramref name="tableAlias"/>.
   /// </summary>
   /// <param name="selectMembers">The members to use in the SELECT clause.</param>
   /// <param name="tableAlias">The table alias.</param>
   /// <returns>The SELECT query.</returns>

   SqlBuilder
   BuildSelectClause(IEnumerable<MetaDataMember> selectMembers, string tableAlias) =>
      new SqlBuilder()
         .SELECT(_db.SelectBody(_metaType, selectMembers, tableAlias));

   /// <summary>
   /// Creates and returns a SELECT query for the current table
   /// that includes the SELECT and FROM clauses.
   /// </summary>
   /// <returns>The SELECT query for the current table.</returns>

   public SqlBuilder
   BuildSelectStatement() =>
      BuildSelectStatement((string)null);

   /// <summary>
   /// Creates and returns a SELECT query for the current table
   /// that includes the SELECT and FROM clauses. All column names are qualified with the provided
   /// <paramref name="tableAlias"/>.
   /// </summary>
   /// <param name="tableAlias">The table alias.</param>
   /// <returns>The SELECT query for the current table.</returns>

   public SqlBuilder
   BuildSelectStatement(string tableAlias) =>
      BuildSelectStatement(null, tableAlias);

   internal SqlBuilder
   BuildSelectStatement(IEnumerable<MetaDataMember> selectMembers, string tableAlias = null) =>
      BuildSelectClause(selectMembers, tableAlias)
         .FROM(_db.FromBody(_metaType, tableAlias));

   /// <summary>
   /// Creates and returns an INSERT command for the specified <paramref name="entity"/>.
   /// </summary>
   /// <param name="entity">
   /// The object whose INSERT command is to be created. This parameter is named entity for consistency
   /// with the other CRUD methods, but in this case it doesn't need to be an actual entity, which means it doesn't
   /// need to have a primary key.
   /// </param>
   /// <returns>The INSERT command for <paramref name="entity"/>.</returns>

   public SqlBuilder
   BuildInsertStatementForEntity(TEntity entity) {

      if (entity is null) throw new ArgumentNullException(nameof(entity));

      var insertingMembers = _metaType.PersistentDataMembers
         .Where(m => !m.IsAssociation && !m.IsDbGenerated)
         .ToArray();

      var parameters = insertingMembers
         .Select(m => m.GetValueForDatabase(entity))
         .ToArray();

      var sb = new StringBuilder()
         .Append("INSERT INTO ")
         .Append(QuoteIdentifier(_metaType.Table.TableName))
         .Append(" (");

      for (int i = 0; i < insertingMembers.Length; i++) {

         if (i > 0) {
            sb.Append(", ");
         }

         sb.Append(QuoteIdentifier(insertingMembers[i].MappedName));
      }

      sb.AppendLine(")")
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

      return new SqlBuilder(sb.ToString(), parameters);
   }

   /// <summary>
   /// Creates and returns an UPDATE command for the current table
   /// that includes the UPDATE clause.
   /// </summary>
   /// <returns>The UPDATE command for the current table.</returns>

   public SqlBuilder
   BuildUpdateClause() =>
      new SqlBuilder("UPDATE " + QuoteIdentifier(_metaType.Table.TableName));

   /// <summary>
   /// Creates and returns an UPDATE command for the specified <paramref name="entity"/>.
   /// </summary>
   /// <param name="entity">The entity whose UPDATE command is to be created.</param>
   /// <returns>The UPDATE command for <paramref name="entity"/>.</returns>

   public SqlBuilder
   BuildUpdateStatementForEntity(TEntity entity) =>
      BuildUpdateStatementForEntity(entity, null);

   /// <inheritdoc cref="BuildUpdateStatementForEntity(TEntity)"/>
   /// <param name="originalId">The original primary key value.</param>
   /// <remarks>This overload is helpful when the entity uses an assigned primary key.</remarks>

   public SqlBuilder
   BuildUpdateStatementForEntity(TEntity entity, object originalId) {

      if (entity is null) throw new ArgumentNullException(nameof(entity));

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

      var parametersBuffer = new List<object>(updatingMembers.Length + predicateMembers.Length);

      var sb = new StringBuilder()
         .Append("UPDATE ")
         .Append(QuoteIdentifier(_metaType.Table.TableName))
         .AppendLine()
         .Append("SET ");

      for (int i = 0; i < updatingMembers.Length; i++) {

         if (i > 0) {
            sb.Append(", ");
         }

         var member = updatingMembers[i];
         var value = member.GetValueForDatabase(entity);

         sb.Append(QuoteIdentifier(member.MappedName))
            .Append(" = {")
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

      return new SqlBuilder(sb.ToString(), parametersBuffer.ToArray());
   }

   /// <summary>
   /// Creates and returns a DELETE command for the current table
   /// that includes the DELETE and FROM clauses.
   /// </summary>
   /// <returns>The DELETE command for the current table.</returns>

   public SqlBuilder
   BuildDeleteStatement() =>
      new SqlBuilder("DELETE FROM " + QuoteIdentifier(_metaType.Table.TableName));

   /// <summary>
   /// Creates and returns a DELETE command for the specified <paramref name="entity"/>.
   /// </summary>
   /// <param name="entity">The entity whose DELETE command is to be created.</param>
   /// <returns>The DELETE command for <paramref name="entity"/>.</returns>

   public SqlBuilder
   BuildDeleteStatementForEntity(TEntity entity) {

      if (entity is null) throw new ArgumentNullException(nameof(entity));

      EnsureEntityType();

      var predicateMembers = _metaType.PersistentDataMembers
         .Where(m => m.IsPrimaryKey || (m.IsVersion && _db.Configuration.UseVersionMember));

      var deleteSql = BuildDeleteStatement();
      deleteSql.WHERE(_db.BuildPredicateFragment(entity, predicateMembers, deleteSql.ParameterValues));

      return deleteSql;
   }

   /// <summary>
   /// Creates and returns a DELETE command for the entity
   /// whose primary key matches the <paramref name="id"/> parameter.
   /// </summary>
   /// <param name="id">The primary key value.</param>
   /// <returns>The DELETE command the entity whose primary key matches the <paramref name="id"/> parameter.</returns>

   public SqlBuilder
   BuildDeleteStatementForKey(object id) {

      EnsureEntityType();

      if (_metaType.IdentityMembers.Count > 1) {
         throw new InvalidOperationException("Cannot call this method when the entity has more than one identity member.");
      }

      return BuildDeleteStatement()
         .WHERE(QuoteIdentifier(_metaType.IdentityMembers[0].MappedName) + " = {0}", id);
   }

   string
   QuoteIdentifier(string unquotedIdentifier) =>
      _db.QuoteIdentifier(unquotedIdentifier);

   void
   EnsureEntityType() =>
      SqlTable.EnsureEntityType(_metaType);

   #region Object Members

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public override bool
   Equals(object obj) => base.Equals(obj);

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public override int
   GetHashCode() => base.GetHashCode();

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public new Type
   GetType() => base.GetType();

   /// <exclude/>

   [EditorBrowsable(EditorBrowsableState.Never)]
   public override string
   ToString() => base.ToString();

   #endregion
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
   /// <returns>true if the primary key value exists in the database; otherwise false.</returns>
   /// <exception cref="System.InvalidOperationException">This method can only be used on sets where the result type is an annotated class.</exception>

   public bool
   Contains(object entity) {

      if (entity is null) throw new ArgumentNullException(nameof(entity));

      var metaType = EnsureEntityType();

      var predicateMembers = metaType.PersistentDataMembers
         .Where(m => m.IsPrimaryKey || (m.IsVersion && _db.Configuration.UseVersionMember))
         .ToArray();

      var predicateValues = predicateMembers.ToDictionary(
         m => m.MappedName,
         m => m.GetValueForDatabase(entity)
      );

      return ContainsImpl(predicateMembers, predicateValues);
   }

   /// <summary>
   /// Checks the existance of an entity whose primary matches the <paramref name="id"/> parameter.
   /// </summary>
   /// <param name="id">The primary key value.</param>
   /// <returns>true if the primary key value exists in the database; otherwise false.</returns>
   /// <exception cref="System.InvalidOperationException">This method can only be used on sets where the result type is an annotated class.</exception>

   public bool
   ContainsKey(object id) {

      var metaType = EnsureEntityType(maxIdMembers: 1);
      var idMember = metaType.IdentityMembers[0];

      var predicateMembers = new[] { idMember };

      var predicateValues = new KeyValuePair<string, object>[] {
         new(idMember.MappedName, idMember.ConvertValueForDatabase(id))
      };

      return ContainsImpl(predicateMembers, predicateValues);
   }

   bool
   ContainsImpl(MetaDataMember[] predicateMembers, IEnumerable<KeyValuePair<string, object>> predicateValues) {

      var metaType = predicateMembers[0].DeclaringType;

      var predicateParams = new List<object>(predicateMembers.Length);

      return Where(_db.BuildPredicateFragment(predicateValues, predicateParams), predicateParams.ToArray())
         .Select(_db.SelectBody(metaType, predicateMembers, null))
         .Any();
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

   public object
   Find(object id) =>
      FindImpl(id).SingleOrDefault();

   private protected SqlSet
   FindImpl(object id) {

      if (id is null) throw new ArgumentNullException(nameof(id));

      var metaType = EnsureEntityType(maxIdMembers: 1);
      var idMember = metaType.IdentityMembers[0];

      var predicateValues = new KeyValuePair<string, object>[] {
         new(idMember.MappedName, idMember.ConvertValueForDatabase(id))
      };

      var parameters = new List<object>(predicateValues.Length);
      var predicate = _db.BuildPredicateFragment(predicateValues, parameters);

      return Where(predicate, parameters.ToArray());
   }

   /// <summary>
   /// Specifies the related objects to include in the query results.
   /// </summary>
   /// <param name="path">Dot-separated list of related objects to return in the query results.</param>
   /// <returns>A new <see cref="SqlSet"/> with the defined query path.</returns>
   /// <exception cref="System.InvalidOperationException">This method can only be used on sets where the result type is an annotated class.</exception>

   public SqlSet
   Include(string path) {

      if (path is null) throw new ArgumentNullException(nameof(path));

      var resultType = this.ResultType
         ?? throw new InvalidOperationException("Include operation is not supported on untyped sets.");

      var metaType = _db.Configuration.GetMetaType(resultType)
         ?? throw new InvalidOperationException($"Mapping information was not found for '{resultType.FullName}'.");

      return IncludeImpl.Expand(this, path, metaType);
   }

   static class IncludeImpl {

      static readonly char[]
      _pathSeparator = { '.' };

      public static SqlSet
      Expand(SqlSet source, string path, MetaType metaType) {

         var db = source._db;

         var parts = path.Split(_pathSeparator);

         SqlBuilder selectBuild(string alias) =>
            new SqlBuilder().SELECT(db.QuoteIdentifier(alias) + ".*");

         void fromAppend(SqlBuilder sql, string alias) =>
            sql.FROM(source.GetDefiningQuery(), db.QuoteIdentifier(alias));

         MetaAssociation manyAssoc;
         int manyIndex;

         var query = BuildJoinedQuery(parts, metaType, source._db, selectBuild, fromAppend, out manyAssoc, out manyIndex);

         var newSet = (query is null) ? source.Clone() : source.CreateSet(query);

         if (manyAssoc is not null) {
            AddManyInclude(newSet, parts, path, manyAssoc, manyIndex);
         }

         return newSet;
      }

      static SqlBuilder
      BuildJoinedQuery(
            string[] path, MetaType metaType, Database db,
            Func<string, SqlBuilder> selectBuild, Action<SqlBuilder, string> fromAppend,
            out MetaAssociation manyAssoc, out int manyIndex) {

         manyAssoc = null;
         manyIndex = -1;

         const string leftAlias = "dbex_l";
         const string rightAlias = "dbex_r";

         static string rAliasFn(int i) => rightAlias + (i + 1);

         var query = selectBuild.Invoke(leftAlias);
         var currentType = metaType;

         var associations = new List<MetaAssociation>();

         for (int i = 0; i < path.Length; i++) {

            var p = path[i];
            var rAlias = rAliasFn(i);

            var member = currentType.PersistentDataMembers
               .SingleOrDefault(m => m.Name == p);

            if (member is null) {
               throw new ArgumentException($"Couldn't find '{p}' on '{currentType.Type.FullName}'.", nameof(path));
            }

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

            query.SELECT(String.Join(", ", association.OtherType.PersistentDataMembers
               .Where(m => !m.IsAssociation)
               .Select(m => $"{db.QuoteIdentifier(rAlias)}.{db.QuoteIdentifier(m.MappedName)} AS {String.Join("$", associations.Select(a => a.ThisMember.Name))}${m.Name}")));

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

            var joinPredicate = new StringBuilder();

            for (int j = 0; j < association.ThisKey.Count; j++) {

               if (j > 0) {
                  joinPredicate.Append(" AND ");
               }

               var thisMember = association.ThisKey[j];
               var otherMember = association.OtherKey[j];

               joinPredicate.Append($"{db.QuoteIdentifier(lAlias)}.{db.QuoteIdentifier(thisMember.Name)} = {db.QuoteIdentifier(rAlias)}.{db.QuoteIdentifier(otherMember.MappedName)}");
            }

            query.LEFT_JOIN($"{db.QuoteIdentifier(association.OtherType.Table.TableName)} {db.QuoteIdentifier(rAlias)} ON ({joinPredicate.ToString()})");
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

            SqlBuilder selectBuild(string alias) =>
               table.CommandBuilder.BuildSelectClause(alias);

            void fromAppend(SqlBuilder sql, string alias) =>
               sql.FROM(db.QuoteIdentifier(metaType.Table.TableName) + " " + alias);

            MetaAssociation manyInManyAssoc;
            int manyInManyIndex;

            var manyQuery = BuildJoinedQuery(manyInclude, metaType, db, selectBuild, fromAppend, out manyInManyAssoc, out manyInManyIndex);

            if (manyInManyAssoc is not null) {
               throw new ArgumentException($"One-to-many associations can only be specified once in an include path ('{originalPath}').", nameof(path));
            }

            manySource = db.From(manyQuery, metaType.Type);
         }

         set.ManyIncludes ??= new Dictionary<string[], CollectionLoader>();

         set.ManyIncludes.Add(manyPath, new CollectionLoader {
            Load = GetMany,
            State = new CollectionLoaderState {
               Source = manySource,
               Association = manyAssoc
            }
         });
      }

      static IEnumerable
      GetMany(object container, object state) {

         var loaderState = (CollectionLoaderState)state;

         var association = loaderState.Association;
         var set = loaderState.Source;

         var predicateValues = association.OtherKey.Select((p, i) =>
            new KeyValuePair<string, object>(p.MappedName, association.ThisKey[i].GetValueForDatabase(container)));

         var parameters = new List<object>(association.OtherKey.Count);
         var whereFragment = set._db.BuildPredicateFragment(predicateValues, parameters);

         var children = set.Where(whereFragment, parameters.ToArray())
            .AsEnumerable();

         var otherMember = association.OtherMember;

         foreach (var child in children) {

            if (otherMember is not null
               && !otherMember.Association.IsMany) {

               var childObj = child;

               otherMember.MemberAccessor.SetBoxedValue(ref childObj, container);
            }

            yield return child;
         }
      }

      class CollectionLoaderState {

         public SqlSet
         Source;

         public MetaAssociation
         Association;
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
      base.Contains(entity);

   /// <inheritdoc cref="SqlSet.Find(Object)"/>

   public new TResult
   Find(object id) =>
      ((SqlSet<TResult>)FindImpl(id)).SingleOrDefault();

   /// <inheritdoc cref="SqlSet.Include(String)"/>
   /// <returns>A new <see cref="SqlSet&lt;TResult>"/> with the defined query path.</returns>

   public new SqlSet<TResult>
   Include(string path) =>
      (SqlSet<TResult>)base.Include(path);
}

interface ISqlTable {

   string
   Name { get; }

   void
   Add(object entity);

   void
   AddDescendants(object entity); // internal

   void
   AddRange(IEnumerable<object> entities);

   void
   AddRange(params object[] entities);

   void
   Remove(object entity);

   void
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
   Update(object entity, object originalId);

   void
   UpdateRange(IEnumerable<object> entities);

   void
   UpdateRange(params object[] entities);
}
