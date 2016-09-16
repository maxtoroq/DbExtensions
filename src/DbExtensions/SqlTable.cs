// Copyright 2012-2016 Max Toro Q.
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
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbExtensions {

   using Metadata;

   partial class Database {

      static readonly MethodInfo tableMethod = typeof(Database)
         .GetMethods(BindingFlags.Public | BindingFlags.Instance)
         .Single(m => m.Name == nameof(Table) && m.ContainsGenericParameters && m.GetParameters().Length == 0);

      static readonly MappingSource mappingSource = new AttributeMappingSource();

      readonly IDictionary<MetaType, SqlTable> tables = new Dictionary<MetaType, SqlTable>();
      readonly IDictionary<MetaType, ISqlTable> genericTables = new Dictionary<MetaType, ISqlTable>();

      partial void Initialize2(string providerInvariantName) {

         this.Configuration.SetModel(() => {
            return mappingSource.GetModel(GetType());
         });

         Initialize3(providerInvariantName);
      }

      partial void Initialize3(string providerInvariantName);

      /// <summary>
      /// Returns the <see cref="SqlTable&lt;TEntity>"/> instance for the specified <typeparamref name="TEntity"/>.
      /// </summary>
      /// <typeparam name="TEntity">The type of the entity.</typeparam>
      /// <returns>The <see cref="SqlTable&lt;TEntity>"/> instance for <typeparamref name="TEntity"/>.</returns>

      public SqlTable<TEntity> Table<TEntity>() where TEntity : class {

         MetaType metaType = this.Configuration.Model.GetMetaType(typeof(TEntity));
         ISqlTable set;
         SqlTable<TEntity> table;

         if (this.genericTables.TryGetValue(metaType, out set)) {
            table = (SqlTable<TEntity>)set;

         } else {
            table = new SqlTable<TEntity>(this, metaType);
            this.genericTables.Add(metaType, table);
         }

         return table;
      }

      /// <summary>
      /// Returns the <see cref="SqlTable"/> instance for the specified <paramref name="entityType"/>.
      /// </summary>
      /// <param name="entityType">The type of the entity.</param>
      /// <returns>The <see cref="SqlTable"/> instance for <paramref name="entityType"/>.</returns>

      public SqlTable Table(Type entityType) {
         return Table(this.Configuration.Model.GetMetaType(entityType));
      }

      /// <summary>
      /// Returns the <see cref="SqlTable"/> instance for the specified <paramref name="metaType"/>.
      /// </summary>
      /// <param name="metaType">The <see cref="MetaType"/> of the entity.</param>
      /// <returns>The <see cref="SqlTable"/> instance for <paramref name="metaType"/>.</returns>

      internal SqlTable Table(MetaType metaType) {

         SqlTable table;

         if (!this.tables.TryGetValue(metaType, out table)) {

            ISqlTable genericTable = (ISqlTable)
               tableMethod.MakeGenericMethod(metaType.Type).Invoke(this, null);

            table = new SqlTable(this, metaType, genericTable);
            this.tables.Add(metaType, table);
         }

         return table;
      }

      internal object GetMemberValue(object entity, MetaDataMember member) {

         object value = member.MemberAccessor.GetBoxedValue(entity);

         return ConvertMemberValue(member, value);
      }

      internal object ConvertMemberValue(MetaDataMember member, object value) {

         if (value == null) {
            return value;
         }

         if (member.DbType != null
            && (member.Type.IsEnum || (member.Type.IsGenericType
               && member.Type.GetGenericTypeDefinition() == typeof(Nullable<>)
               && Nullable.GetUnderlyingType(member.Type).IsEnum))
            && member.DbType.IndexOf("char", StringComparison.OrdinalIgnoreCase) > 0) {

            value = Convert.ToString(value, CultureInfo.InvariantCulture);
         }

         return value;
      }

      internal string BuildPredicateFragment(object entity, ICollection<MetaDataMember> predicateMembers, ICollection<object> parametersBuffer) {

         var predicateValues = predicateMembers.ToDictionary(
            m => m.MappedName,
            m => GetMemberValue(entity, m)
         );

         return BuildPredicateFragment(predicateValues, parametersBuffer);
      }

      internal string BuildPredicateFragment(IDictionary<string, object> predicateValues, ICollection<object> parametersBuffer) {

         if (predicateValues == null || predicateValues.Count == 0) throw new ArgumentException("predicateValues cannot be empty", nameof(predicateValues));
         if (parametersBuffer == null) throw new ArgumentNullException(nameof(parametersBuffer));

         var sb = new StringBuilder();

         foreach (var item in predicateValues) {

            if (sb.Length > 0) {
               sb.Append(" AND ");
            }

            sb.Append(QuoteIdentifier(item.Key));

            if (item.Value == null) {
               sb.Append(" IS NULL");
            } else {
               sb.Append(" = {")
                  .Append(parametersBuffer.Count)
                  .Append("}");

               parametersBuffer.Add(item.Value);
            }
         }

         return sb.ToString();
      }

      internal string SelectBody(MetaType metaType, IEnumerable<MetaDataMember> selectMembers, string tableAlias) {

         if (selectMembers == null) {
            selectMembers = metaType.PersistentDataMembers.Where(m => !m.IsAssociation);
         }

         var sb = new StringBuilder();

         string qualifier = (!String.IsNullOrEmpty(tableAlias)) ?
            QuoteIdentifier(tableAlias) + "." : null;

         IEnumerator<MetaDataMember> enumerator = selectMembers.GetEnumerator();

         while (enumerator.MoveNext()) {

            string mappedName = enumerator.Current.MappedName;
            string memberName = enumerator.Current.Name;
            string columnAlias = !String.Equals(mappedName, memberName, StringComparison.Ordinal) ?
               memberName : null;

            if (sb.Length > 0) {
               sb.Append(", ");
            }

            if (qualifier != null) {
               sb.Append(qualifier);
            }

            sb.Append(QuoteIdentifier(enumerator.Current.MappedName));

            if (columnAlias != null) {

               sb.Append(" AS ")
                  .Append(QuoteIdentifier(memberName));
            }
         }

         return sb.ToString();
      }

      internal string FromBody(MetaType metaType, string tableAlias) {

         if (metaType.Table == null) throw new InvalidOperationException("metaType.Table cannot be null.");

         string alias = (!String.IsNullOrEmpty(tableAlias)) ?
            " " + QuoteIdentifier(tableAlias)
            : null;

         return QuoteIdentifier(metaType.Table.TableName) + (alias ?? "");
      }
   }

   sealed partial class DatabaseConfiguration {

      Lazy<MetaModel> _Model;

      /// <summary>
      /// Gets the <see cref="MetaModel"/> on which the mapping is based.
      /// </summary>

      internal MetaModel Model => _Model.Value;

      /// <summary>
      /// true to include version column check in SQL statements' predicates; otherwise, false. The default is true.
      /// </summary>

      public bool UseVersionMember { get; set; } = true;

      /// <summary>
      /// true to ignore when a concurrency conflict occurs when executing a DELETE command; otherwise, false. The default is true.
      /// </summary>
      /// <remarks>
      /// This setting affects the behavior of <see cref="SqlTable&lt;TEntity>.Remove(TEntity)"/>,
      /// <see cref="SqlTable&lt;TEntity>.RemoveKey(object)"/> and <see cref="SqlTable&lt;TEntity>.RemoveRange(TEntity[])"/>.
      /// </remarks>

      public bool IgnoreDeleteConflicts { get; set; } = true;

      /// <summary>
      /// true to execute batch commands when possible; otherwise, false. The default is true.
      /// </summary>
      /// <remarks>
      /// This setting affects the behavior of <see cref="SqlTable&lt;TEntity>.AddRange(TEntity[])"/>,
      /// <see cref="SqlTable&lt;TEntity>.UpdateRange(TEntity[])"/> and <see cref="SqlTable&lt;TEntity>.RemoveRange(TEntity[])"/>.
      /// </remarks>

      public bool EnableBatchCommands { get; set; } = true;

      internal void SetModel(Func<MetaModel> modelFn) {
         _Model = new Lazy<MetaModel>(modelFn);
      }
   }

   /// <summary>
   /// A non-generic version of <see cref="SqlTable&lt;TEntity>"/> which can be used when the type of the entity is not known at build time.
   /// This class cannot be instantiated, to get an instance use the <see cref="Database.Table(Type)"/> method.
   /// </summary>

   [DebuggerDisplay("{metaType.Name}")]
   public sealed class SqlTable : SqlSet, ISqlTable {

      // table is the SqlTable<TEntity> instance for metaType
      // SqlTable is only a wrapper on SqlTable<TEntity>

      readonly ISqlTable table;
      readonly MetaType metaType;

      /// <summary>
      /// Gets a <see cref="SqlCommandBuilder&lt;Object>"/> object for the current table.
      /// </summary>

      public SqlCommandBuilder<object> CommandBuilder { get; }

      internal SqlTable(Database db, MetaType metaType, ISqlTable table)
         : base(new string[2] { db.FromBody(metaType, null), db.SelectBody(metaType, null, null) }, metaType.Type, db) {

         this.table = table;

         this.metaType = metaType;
         this.CommandBuilder = new SqlCommandBuilder<object>(db, metaType);
      }

      /// <summary>
      /// Casts the current <see cref="SqlTable"/> to the generic <see cref="SqlTable&lt;TEntity>"/> instance.
      /// </summary>
      /// <typeparam name="TEntity">The type of the entity.</typeparam>
      /// <returns>The <see cref="SqlTable&lt;TEntity>"/> instance for <typeparamref name="TEntity"/>.</returns>
      /// <exception cref="System.InvalidOperationException">The specified <typeparamref name="TEntity"/> is not valid for this instance.</exception>

      public new SqlTable<TEntity> Cast<TEntity>() where TEntity : class {

         if (typeof(TEntity) != this.metaType.Type) {
            throw new InvalidOperationException("The specified type parameter is not valid for this instance.");
         }

         return (SqlTable<TEntity>)this.table;
      }

      /// <inheritdoc cref="SqlSet.Cast(Type)"/>

      [EditorBrowsable(EditorBrowsableState.Never)]
      public new SqlSet Cast(Type resultType) {
         return base.Cast(resultType);
      }

      internal static void EnsureEntityType(MetaType metaType) {

         if (!metaType.IsEntity) {
            throw new InvalidOperationException($"The operation is not available for non-entity types ('{metaType.Type.FullName}').");
         }
      }

      #region ISqlTable Members

      // These methods just call the same method on this.table

      /// <inheritdoc cref="SqlTable&lt;TEntity>.Add(TEntity)"/>

      public void Add(object entity) {
         this.table.Add(entity);
      }

      void ISqlTable.AddDescendants(object entity) {
         this.table.AddDescendants(entity);
      }

      /// <inheritdoc cref="SqlTable&lt;TEntity>.AddRange(IEnumerable&lt;TEntity>)"/>

      public void AddRange(IEnumerable<object> entities) {
         this.table.AddRange(entities);
      }

      /// <inheritdoc cref="SqlTable&lt;TEntity>.AddRange(TEntity[])"/>

      public void AddRange(params object[] entities) {
         this.table.AddRange(entities);
      }

      /// <inheritdoc cref="SqlTable&lt;TEntity>.Update(TEntity)"/>

      public void Update(object entity) {
         this.table.Update(entity);
      }

      /// <inheritdoc cref="SqlTable&lt;TEntity>.UpdateRange(IEnumerable&lt;TEntity>)"/>

      public void UpdateRange(IEnumerable<object> entities) {
         this.table.UpdateRange(entities);
      }

      /// <inheritdoc cref="SqlTable&lt;TEntity>.UpdateRange(TEntity[])"/>

      public void UpdateRange(params object[] entities) {
         this.table.UpdateRange(entities);
      }

      /// <inheritdoc cref="SqlTable&lt;TEntity>.Remove(TEntity)"/>

      public void Remove(object entity) {
         this.table.Remove(entity);
      }

      /// <inheritdoc cref="SqlTable&lt;TEntity>.RemoveKey(Object)"/>

      public void RemoveKey(object id) {
         this.table.RemoveKey(id);
      }

      /// <inheritdoc cref="SqlTable&lt;TEntity>.RemoveRange(IEnumerable&lt;TEntity>)"/>

      public void RemoveRange(IEnumerable<object> entities) {
         this.table.RemoveRange(entities);
      }

      /// <inheritdoc cref="SqlTable&lt;TEntity>.RemoveRange(TEntity[])"/>

      public void RemoveRange(params object[] entities) {
         this.table.RemoveRange(entities);
      }

      /// <inheritdoc cref="SqlTable&lt;TEntity>.Contains(TEntity)"/>

      public bool Contains(object entity) {
         return this.table.Contains(entity);
      }

      /// <inheritdoc cref="SqlTable&lt;TEntity>.ContainsKey(Object)"/>

      public bool ContainsKey(object id) {
         return this.table.ContainsKey(id);
      }

      /// <inheritdoc cref="SqlTable&lt;TEntity>.Refresh(TEntity)"/>

      public void Refresh(object entity) {
         this.table.Refresh(entity);
      }

      #endregion
   }

   /// <summary>
   /// A <see cref="SqlSet&lt;TEntity>"/> that provides additional methods for CRUD (Create, Read, Update, Delete)
   /// operations for entities mapped using the <see cref="N:System.Data.Linq.Mapping"/> API. 
   /// This class cannot be instantiated, to get an instance use the <see cref="Database.Table&lt;TEntity>"/> method.
   /// </summary>
   /// <typeparam name="TEntity">The type of the entity.</typeparam>

   [DebuggerDisplay("{metaType.Name}")]
   public sealed class SqlTable<TEntity> : SqlSet<TEntity>, ISqlTable
      where TEntity : class {

      readonly MetaType metaType;

      /// <summary>
      /// Gets a <see cref="SqlCommandBuilder&lt;TEntity>"/> object for the current table.
      /// </summary>

      public SqlCommandBuilder<TEntity> CommandBuilder { get; }

      internal SqlTable(Database db, MetaType metaType)
         : base(new string[2] { db.FromBody(metaType, null), db.SelectBody(metaType, null, null) }, db) {

         this.metaType = metaType;
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

      public void Add(TEntity entity) {

         if (entity == null) throw new ArgumentNullException(nameof(entity));

         SqlBuilder insertSql = this.CommandBuilder.BuildInsertStatementForEntity(entity);

         MetaDataMember idMember = this.metaType.DBGeneratedIdentityMember;

         MetaDataMember[] syncMembers =
            (from m in this.metaType.PersistentDataMembers
             where (m.AutoSync == AutoSync.Always || m.AutoSync == AutoSync.OnInsert)
               && m != idMember
             select m).ToArray();

         using (var tx = this.db.EnsureInTransaction()) {

            this.db.Execute(insertSql, affect: 1, exact: true);

            if (idMember != null) {

               object id = this.db.LastInsertId();

               if (Convert.IsDBNull(id) || id == null) {
                  throw new DataException("The last insert id value cannot be null.");
               }

               object convertedId;

               try {
                  convertedId = Convert.ChangeType(id, idMember.Type, CultureInfo.InvariantCulture);

               } catch (InvalidCastException ex) {
                  throw new DataException("Couldn't convert the last insert id value to the appropiate type (see inner exception for details).", ex);
               }

               object entityObj = (object)entity;

               idMember.MemberAccessor.SetBoxedValue(ref entityObj, convertedId);
            }

            if (syncMembers.Length > 0
               && this.metaType.IsEntity) {

               Refresh(entity, syncMembers);
            }

            InsertDescendants(entity);

            tx.Commit();
         }
      }

      void InsertDescendants(TEntity entity) {

         InsertOneToOne(entity);
         InsertOneToMany(entity);
      }

      void InsertOneToOne(TEntity entity) {

         MetaAssociation[] oneToOne = this.metaType.Associations
            .Where(a => !a.IsMany && a.ThisKeyIsPrimaryKey && a.OtherKeyIsPrimaryKey)
            .ToArray();

         for (int i = 0; i < oneToOne.Length; i++) {

            MetaAssociation assoc = oneToOne[i];

            object child = assoc.ThisMember.MemberAccessor.GetBoxedValue(entity);

            if (child == null) {
               continue;
            }

            for (int j = 0; j < assoc.ThisKey.Count; j++) {

               MetaDataMember thisKey = assoc.ThisKey[j];
               MetaDataMember otherKey = assoc.OtherKey[j];

               object thisKeyVal = thisKey.MemberAccessor.GetBoxedValue(entity);

               otherKey.MemberAccessor.SetBoxedValue(ref child, thisKeyVal);
            }

            SqlTable otherTable = this.db.Table(assoc.OtherType);

            otherTable.Add(child);
         }
      }

      void InsertOneToMany(TEntity entity) {

         MetaAssociation[] oneToMany = this.metaType.Associations.Where(a => a.IsMany).ToArray();

         for (int i = 0; i < oneToMany.Length; i++) {

            MetaAssociation assoc = oneToMany[i];

            object[] many = ((IEnumerable<object>)assoc.ThisMember.MemberAccessor.GetBoxedValue(entity) ?? new object[0])
               .Where(o => o != null)
               .ToArray();

            if (many.Length == 0) continue;

            for (int j = 0; j < many.Length; j++) {

               object child = many[j];

               for (int k = 0; k < assoc.ThisKey.Count; k++) {

                  MetaDataMember thisKey = assoc.ThisKey[k];
                  MetaDataMember otherKey = assoc.OtherKey[k];

                  object thisKeyVal = thisKey.MemberAccessor.GetBoxedValue(entity);

                  otherKey.MemberAccessor.SetBoxedValue(ref child, thisKeyVal);
               }
            }

            SqlTable otherTable = this.db.Table(assoc.OtherType);

            otherTable.AddRange(many);

            for (int j = 0; j < many.Length; j++) {

               object child = many[j];

               ((ISqlTable)otherTable).AddDescendants(child);
            }
         }
      }

      /// <summary>
      /// Recursively executes INSERT commands for the specified <paramref name="entities"/> and all its
      /// one-to-one and one-to-many associations.
      /// </summary>
      /// <param name="entities">The entities whose INSERT commands are to be executed.</param>

      public void AddRange(IEnumerable<TEntity> entities) {

         if (entities == null) throw new ArgumentNullException(nameof(entities));

         AddRange(entities.ToArray());
      }

      /// <inheritdoc cref="AddRange(IEnumerable&lt;TEntity>)"/>

      public void AddRange(params TEntity[] entities) {

         if (entities == null) throw new ArgumentNullException(nameof(entities));

         entities = entities.Where(o => o != null).ToArray();

         if (entities.Length == 0) {
            return;
         }

         if (entities.Length == 1) {
            Add(entities[0]);
            return;
         }

         MetaDataMember[] syncMembers =
            (from m in this.metaType.PersistentDataMembers
             where (m.AutoSync == AutoSync.Always || m.AutoSync == AutoSync.OnInsert)
             select m).ToArray();

         bool batch = syncMembers.Length == 0
            && this.db.Configuration.EnableBatchCommands;

         if (batch) {

            SqlBuilder batchInsert = SqlBuilder.JoinSql(";" + Environment.NewLine, entities.Select(e => this.CommandBuilder.BuildInsertStatementForEntity(e)));

            using (var tx = this.db.EnsureInTransaction()) {

               this.db.Execute(batchInsert, affect: entities.Length, exact: true);

               for (int i = 0; i < entities.Length; i++) {
                  InsertDescendants(entities[i]);
               }

               tx.Commit();
            }

         } else {

            using (var tx = this.db.EnsureInTransaction()) {

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

      public void Update(TEntity entity) {

         if (entity == null) throw new ArgumentNullException(nameof(entity));

         SqlBuilder updateSql = this.CommandBuilder.BuildUpdateStatementForEntity(entity);

         MetaDataMember[] syncMembers =
            (from m in this.metaType.PersistentDataMembers
             where m.AutoSync == AutoSync.Always || m.AutoSync == AutoSync.OnUpdate
             select m).ToArray();

         using (this.db.EnsureConnectionOpen()) {

            this.db.Execute(updateSql, affect: 1, exact: true);

            if (syncMembers.Length > 0) {
               Refresh(entity, syncMembers);
            }
         }
      }

      /// <summary>
      /// Executes UPDATE commands for the specified <paramref name="entities"/>.
      /// </summary>
      /// <param name="entities">The entities whose UPDATE commands are to be executed.</param>

      public void UpdateRange(IEnumerable<TEntity> entities) {

         if (entities == null) throw new ArgumentNullException(nameof(entities));

         UpdateRange(entities.ToArray());
      }

      /// <summary>
      /// Executes UPDATE commands for the specified <paramref name="entities"/>.
      /// </summary>
      /// <param name="entities">The entities whose UPDATE commands are to be executed.</param>

      public void UpdateRange(params TEntity[] entities) {

         if (entities == null) throw new ArgumentNullException(nameof(entities));

         entities = entities.Where(o => o != null).ToArray();

         if (entities.Length == 0) {
            return;
         }

         if (entities.Length == 1) {
            Update(entities[0]);
            return;
         }

         EnsureEntityType();

         MetaDataMember[] syncMembers =
            (from m in this.metaType.PersistentDataMembers
             where m.AutoSync == AutoSync.Always || m.AutoSync == AutoSync.OnUpdate
             select m).ToArray();

         bool batch = syncMembers.Length == 0
            && this.db.Configuration.EnableBatchCommands;

         if (batch) {

            SqlBuilder batchUpdate = SqlBuilder.JoinSql(";" + Environment.NewLine, entities.Select(e => this.CommandBuilder.BuildUpdateStatementForEntity(e)));

            this.db.Execute(batchUpdate, affect: entities.Length, exact: true);

         } else {

            using (var tx = this.db.EnsureInTransaction()) {

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

      public void Remove(TEntity entity) {

         if (entity == null) throw new ArgumentNullException(nameof(entity));

         SqlBuilder deleteSql = this.CommandBuilder.BuildDeleteStatementForEntity(entity);

         this.db.Execute(deleteSql, affect: 1, exact: !this.db.Configuration.IgnoreDeleteConflicts);
      }

      /// <summary>
      /// Executes a DELETE command for the entity
      /// whose primary key matches the <paramref name="id"/> parameter.
      /// </summary>
      /// <param name="id">The primary key value.</param>

      public void RemoveKey(object id) {

         SqlBuilder deleteSql = this.CommandBuilder.BuildDeleteStatementForKey(id);

         this.db.Execute(deleteSql, affect: 1, exact: !this.db.Configuration.IgnoreDeleteConflicts);
      }

      /// <summary>
      /// Executes DELETE commands for the specified <paramref name="entities"/>.
      /// </summary>
      /// <param name="entities">The entities whose DELETE commands are to be executed.</param>

      public void RemoveRange(IEnumerable<TEntity> entities) {

         if (entities == null) throw new ArgumentNullException(nameof(entities));

         RemoveRange(entities.ToArray());
      }

      /// <summary>
      /// Executes DELETE commands for the specified <paramref name="entities"/>.
      /// </summary>
      /// <param name="entities">The entities whose DELETE commands are to be executed.</param>

      public void RemoveRange(params TEntity[] entities) {

         if (entities == null) throw new ArgumentNullException(nameof(entities));

         entities = entities.Where(o => o != null).ToArray();

         if (entities.Length == 0) {
            return;
         }

         if (entities.Length == 1) {
            Remove(entities[0]);
            return;
         }

         EnsureEntityType();

         bool affectExact = !this.db.Configuration.IgnoreDeleteConflicts;

         bool useVersion = this.db.Configuration.UseVersionMember
            && this.metaType.VersionMember != null;

         bool singleStatement = this.metaType.IdentityMembers.Count == 1
            && !useVersion;

         bool batch = this.db.Configuration.EnableBatchCommands;

         if (singleStatement) {

            MetaDataMember idMember = this.metaType.IdentityMembers[0];

            object[] ids = entities.Select(e => this.db.GetMemberValue(e, idMember)).ToArray();

            SqlBuilder sql = this.CommandBuilder
               .BuildDeleteStatement()
               .WHERE(this.db.QuoteIdentifier(idMember.MappedName) + " IN ({0})", DbExtensions.SQL.List(ids));

            this.db.Execute(sql, affect: entities.Length, exact: affectExact);

         } else if (batch) {

            SqlBuilder batchDelete = SqlBuilder.JoinSql(";" + Environment.NewLine, entities.Select(e => this.CommandBuilder.BuildDeleteStatementForEntity(e)));

            this.db.Execute(batchDelete, affect: entities.Length, exact: affectExact);

         } else {

            using (var tx = this.db.EnsureInTransaction()) {

               for (int i = 0; i < entities.Length; i++) {
                  Remove(entities[i]);
               }

               tx.Commit();
            }
         }
      }

      /// <summary>
      /// Checks the existance of the <paramref name="entity"/>, using the primary key value.
      /// </summary>
      /// <param name="entity">The entity whose existance is to be checked.</param>
      /// <returns>true if the primary key value exists in the database; otherwise false.</returns>

      public bool Contains(TEntity entity) {

         if (entity == null) throw new ArgumentNullException(nameof(entity));

         EnsureEntityType();

         MetaDataMember[] predicateMembers =
            (from m in this.metaType.PersistentDataMembers
             where m.IsPrimaryKey || (m.IsVersion && this.db.Configuration.UseVersionMember)
             select m).ToArray();

         IDictionary<string, object> predicateValues = predicateMembers.ToDictionary(
            m => m.MappedName,
            m => this.db.GetMemberValue(entity, m)
         );

         return Contains(predicateMembers, predicateValues);
      }

      /// <summary>
      /// Checks the existance of an entity whose primary matches the <paramref name="id"/> parameter.
      /// </summary>
      /// <param name="id">The primary key value.</param>
      /// <returns>true if the primary key value exists in the database; otherwise false.</returns>

      public bool ContainsKey(object id) {
         return ContainsKey(new object[1] { id });
      }

      bool ContainsKey(object[] keyValues) {

         if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));

         EnsureEntityType();

         MetaDataMember[] predicateMembers = this.metaType.IdentityMembers.ToArray();

         if (keyValues.Length != predicateMembers.Length) {
            throw new ArgumentException("The Length of keyValues must match the number of identity members.", nameof(keyValues));
         }

         IDictionary<string, object> predicateValues =
            Enumerable.Range(0, predicateMembers.Length)
               .ToDictionary(i => predicateMembers[i].MappedName, i => this.db.ConvertMemberValue(predicateMembers[i], keyValues[i]));

         return Contains(predicateMembers, predicateValues);
      }

      bool Contains(MetaDataMember[] predicateMembers, IDictionary<string, object> predicateValues) {

         SqlBuilder query = this.CommandBuilder.BuildSelectStatement(new[] { predicateMembers[0] });
         query.WHERE(this.db.BuildPredicateFragment(predicateValues, query.ParameterValues));

         return this.db.From(query).Any();
      }

      /// <summary>
      /// Sets all mapped members of <paramref name="entity"/> to their most current persisted value.
      /// </summary>
      /// <param name="entity">The entity to refresh.</param>

      public void Refresh(TEntity entity) {
         Refresh(entity, null);
      }

      void Refresh(TEntity entity, IEnumerable<MetaDataMember> refreshMembers) {

         if (entity == null) throw new ArgumentNullException(nameof(entity));

         EnsureEntityType();

         SqlBuilder query = this.CommandBuilder.BuildSelectStatement(refreshMembers);
         query.WHERE(this.db.BuildPredicateFragment(entity, this.metaType.IdentityMembers, query.ParameterValues));

         Mapper mapper = this.db.CreatePocoMapper(this.metaType.Type);

         object entityObj = (object)entity;

         this.db.Map<object>(query, r => {
            mapper.Load(ref entityObj, r);
            return null;

         }).SingleOrDefault();
      }

      string QuoteIdentifier(string unquotedIdentifier) {
         return this.db.QuoteIdentifier(unquotedIdentifier);
      }

      void EnsureEntityType() {
         SqlTable.EnsureEntityType(this.metaType);
      }

      #region ISqlTable Members

      void ISqlTable.Add(object entity) {
         Add((TEntity)entity);
      }

      void ISqlTable.AddDescendants(object entity) {
         InsertDescendants((TEntity)entity);
      }

      void ISqlTable.AddRange(IEnumerable<object> entities) {
         AddRange((IEnumerable<TEntity>)entities);
      }

      void ISqlTable.AddRange(params object[] entities) {

         if (entities == null) throw new ArgumentNullException(nameof(entities));

         AddRange(entities as TEntity[] ?? entities.Cast<TEntity>().ToArray());
      }

      void ISqlTable.Update(object entity) {
         Update((TEntity)entity);
      }

      void ISqlTable.UpdateRange(IEnumerable<object> entities) {
         UpdateRange((IEnumerable<TEntity>)entities);
      }

      void ISqlTable.UpdateRange(params object[] entities) {

         if (entities == null) throw new ArgumentNullException(nameof(entities));

         UpdateRange(entities as TEntity[] ?? entities.Cast<TEntity>().ToArray());
      }

      void ISqlTable.Remove(object entity) {
         Remove((TEntity)entity);
      }

      void ISqlTable.RemoveKey(object id) {
         RemoveKey(id);
      }

      void ISqlTable.RemoveRange(IEnumerable<object> entities) {
         RemoveRange((IEnumerable<TEntity>)entities);
      }

      void ISqlTable.RemoveRange(params object[] entities) {

         if (entities == null) throw new ArgumentNullException(nameof(entities));

         RemoveRange(entities as TEntity[] ?? entities.Cast<TEntity>().ToArray());
      }

      bool ISqlTable.Contains(object entity) {
         return Contains((TEntity)entity);
      }

      void ISqlTable.Refresh(object entity) {
         Refresh((TEntity)entity);
      }

      #endregion
   }

   /// <summary>
   /// Generates SQL commands for entities mapped by <see cref="SqlTable&lt;TEntity>"/> and <see cref="SqlTable"/>.
   /// This class cannot be instantiated, to get an instance use the <see cref="SqlTable&lt;TEntity>.CommandBuilder"/>
   /// or <see cref="SqlTable.CommandBuilder"/> properties.
   /// </summary>
   /// <typeparam name="TEntity">The type of the entity to generate commands for.</typeparam>

   public sealed class SqlCommandBuilder<TEntity> where TEntity : class {

      readonly Database db;
      readonly MetaType metaType;

      internal SqlCommandBuilder(Database db, MetaType metaType) {
         this.db = db;
         this.metaType = metaType;
      }

      /// <summary>
      /// Creates and returns a SELECT query for the current table
      /// that includes the SELECT clause only.
      /// </summary>
      /// <returns>The SELECT query for the current table.</returns>

      public SqlBuilder BuildSelectClause() {
         return BuildSelectClause(null);
      }

      /// <summary>
      /// Creates and returns a SELECT query for the current table
      /// that includes the SELECT clause only. All column names are qualified with the provided
      /// <paramref name="tableAlias"/>.
      /// </summary>
      /// <param name="tableAlias">The table alias.</param>
      /// <returns>The SELECT query for the current table.</returns>

      public SqlBuilder BuildSelectClause(string tableAlias) {
         return BuildSelectClause(null, tableAlias);
      }

      /// <summary>
      /// Creates and returns a SELECT query using the specified <paramref name="selectMembers"/>
      /// that includes the SELECT clause only. All column names are qualified with the provided
      /// <paramref name="tableAlias"/>.
      /// </summary>
      /// <param name="selectMembers">The members to use in the SELECT clause.</param>
      /// <param name="tableAlias">The table alias.</param>
      /// <returns>The SELECT query.</returns>

      SqlBuilder BuildSelectClause(IEnumerable<MetaDataMember> selectMembers, string tableAlias) {

         return new SqlBuilder()
            .SELECT(this.db.SelectBody(this.metaType, selectMembers, tableAlias));
      }

      /// <summary>
      /// Creates and returns a SELECT query for the current table
      /// that includes the SELECT and FROM clauses.
      /// </summary>
      /// <returns>The SELECT query for the current table.</returns>

      public SqlBuilder BuildSelectStatement() {
         return BuildSelectStatement((string)null);
      }

      /// <summary>
      /// Creates and returns a SELECT query for the current table
      /// that includes the SELECT and FROM clauses. All column names are qualified with the provided
      /// <paramref name="tableAlias"/>.
      /// </summary>
      /// <param name="tableAlias">The table alias.</param>
      /// <returns>The SELECT query for the current table.</returns>

      public SqlBuilder BuildSelectStatement(string tableAlias) {
         return BuildSelectStatement(null, tableAlias);
      }

      internal SqlBuilder BuildSelectStatement(IEnumerable<MetaDataMember> selectMembers, string tableAlias = null) {

         return BuildSelectClause(selectMembers, tableAlias)
            .FROM(this.db.FromBody(this.metaType, tableAlias));
      }

      /// <summary>
      /// Creates and returns an INSERT command for the specified <paramref name="entity"/>.
      /// </summary>
      /// <param name="entity">
      /// The object whose INSERT command is to be created. This parameter is named entity for consistency
      /// with the other CRUD methods, but in this case it doesn't need to be an actual entity, which means it doesn't
      /// need to have a primary key.
      /// </param>
      /// <returns>The INSERT command for <paramref name="entity"/>.</returns>

      public SqlBuilder BuildInsertStatementForEntity(TEntity entity) {

         if (entity == null) throw new ArgumentNullException(nameof(entity));

         MetaDataMember[] insertingMembers =
            (from m in this.metaType.PersistentDataMembers
             where !m.IsAssociation && !m.IsDbGenerated
             select m).ToArray();

         object[] parameters = insertingMembers
            .Select(m => this.db.GetMemberValue(entity, m))
            .ToArray();

         var sb = new StringBuilder()
            .Append("INSERT INTO ")
            .Append(QuoteIdentifier(this.metaType.Table.TableName))
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

            sb.Append("{")
               .Append(i)
               .Append("}");
         }

         sb.Append(")");

         return new SqlBuilder(sb.ToString(), parameters);
      }

      /// <summary>
      /// Creates and returns an UPDATE command for the current table
      /// that includes the UPDATE clause.
      /// </summary>
      /// <returns>The UPDATE command for the current table.</returns>

      public SqlBuilder BuildUpdateClause() {
         return new SqlBuilder("UPDATE " + QuoteIdentifier(this.metaType.Table.TableName));
      }

      /// <summary>
      /// Creates and returns an UPDATE command for the specified <paramref name="entity"/>.
      /// </summary>
      /// <param name="entity">The entity whose UPDATE command is to be created.</param>
      /// <returns>The UPDATE command for <paramref name="entity"/>.</returns>

      public SqlBuilder BuildUpdateStatementForEntity(TEntity entity) {

         if (entity == null) throw new ArgumentNullException(nameof(entity));

         EnsureEntityType();

         MetaDataMember[] updatingMembers =
            (from m in this.metaType.PersistentDataMembers
             where !m.IsAssociation && !m.IsDbGenerated
             select m).ToArray();

         MetaDataMember[] predicateMembers =
            (from m in this.metaType.PersistentDataMembers
             where m.IsPrimaryKey || (m.IsVersion && this.db.Configuration.UseVersionMember)
             select m).ToArray();

         var parametersBuffer = new List<object>(updatingMembers.Length + predicateMembers.Length);

         var sb = new StringBuilder()
            .Append("UPDATE ")
            .Append(QuoteIdentifier(this.metaType.Table.TableName))
            .AppendLine()
            .Append("SET ");

         for (int i = 0; i < updatingMembers.Length; i++) {

            if (i > 0) {
               sb.Append(", ");
            }

            MetaDataMember member = updatingMembers[i];
            object value = this.db.GetMemberValue(entity, member);

            sb.Append(QuoteIdentifier(member.MappedName))
               .Append(" = {")
               .Append(parametersBuffer.Count)
               .Append("}");

            parametersBuffer.Add(value);
         }

         sb.AppendLine()
            .Append("WHERE ")
            .Append(this.db.BuildPredicateFragment(entity, predicateMembers, parametersBuffer));

         return new SqlBuilder(sb.ToString(), parametersBuffer.ToArray());
      }

      /// <summary>
      /// Creates and returns a DELETE command for the current table
      /// that includes the DELETE and FROM clauses.
      /// </summary>
      /// <returns>The DELETE command for the current table.</returns>

      public SqlBuilder BuildDeleteStatement() {
         return new SqlBuilder("DELETE FROM " + QuoteIdentifier(this.metaType.Table.TableName));
      }

      /// <summary>
      /// Creates and returns a DELETE command for the specified <paramref name="entity"/>.
      /// </summary>
      /// <param name="entity">The entity whose DELETE command is to be created.</param>
      /// <returns>The DELETE command for <paramref name="entity"/>.</returns>

      public SqlBuilder BuildDeleteStatementForEntity(TEntity entity) {

         if (entity == null) throw new ArgumentNullException(nameof(entity));

         EnsureEntityType();

         MetaDataMember[] predicateMembers =
            (from m in this.metaType.PersistentDataMembers
             where m.IsPrimaryKey || (m.IsVersion && this.db.Configuration.UseVersionMember)
             select m).ToArray();

         SqlBuilder deleteSql = BuildDeleteStatement();
         deleteSql.WHERE(this.db.BuildPredicateFragment(entity, predicateMembers, deleteSql.ParameterValues));

         return deleteSql;
      }

      /// <summary>
      /// Creates and returns a DELETE command for the entity
      /// whose primary key matches the <paramref name="id"/> parameter.
      /// </summary>
      /// <param name="id">The primary key value.</param>
      /// <returns>The DELETE command the entity whose primary key matches the <paramref name="id"/> parameter.</returns>

      public SqlBuilder BuildDeleteStatementForKey(object id) {

         EnsureEntityType();

         if (this.metaType.IdentityMembers.Count > 1) {
            throw new InvalidOperationException("Cannot call this method when the entity has more than one identity member.");
         }

         return BuildDeleteStatement()
            .WHERE(QuoteIdentifier(this.metaType.IdentityMembers[0].MappedName) + " = {0}", id);
      }

      string QuoteIdentifier(string unquotedIdentifier) {
         return this.db.QuoteIdentifier(unquotedIdentifier);
      }

      void EnsureEntityType() {
         SqlTable.EnsureEntityType(this.metaType);
      }

      #region Object Members

      /// <exclude/>

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override bool Equals(object obj) {
         return base.Equals(obj);
      }

      /// <exclude/>

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override int GetHashCode() {
         return base.GetHashCode();
      }

      /// <exclude/>

      [EditorBrowsable(EditorBrowsableState.Never)]
      [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Must match base signature.")]
      public new Type GetType() {
         return base.GetType();
      }

      /// <exclude/>

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override string ToString() {
         return base.ToString();
      }

      #endregion
   }

   partial class SqlSet {

      /// <summary>
      /// Gets the entity whose primary key matches the <paramref name="id"/> parameter.
      /// </summary>
      /// <param name="id">The primary key value.</param>
      /// <returns>
      /// The entity whose primary key matches the <paramref name="id"/> parameter, 
      /// or null if the <paramref name="id"/> does not exist.
      /// </returns>
      /// <remarks>
      /// This method can only be used on mapped sets created by <see cref="Database"/>.
      /// </remarks>

      public object Find(object id) {
         return FindImpl(this, id).SingleOrDefault();
      }

      internal static SqlSet FindImpl(SqlSet source, object id) {

         if (source == null) throw new ArgumentNullException(nameof(source));
         if (id == null) throw new ArgumentNullException(nameof(id));

         Database db = source.db;
         Type resultType = source.ResultType;

         if (resultType == null) {
            throw new InvalidOperationException("Find operation is not supported on untyped sets.");
         }

         MetaType metaType = db.Configuration.Model.GetMetaType(resultType);

         if (metaType == null) {
            throw new InvalidOperationException($"Mapping information was not found for '{resultType.FullName}'.");
         }

         if (metaType.IdentityMembers.Count == 0) {
            throw new InvalidOperationException("The entity has no identity members defined.");

         } else if (metaType.IdentityMembers.Count > 1) {
            throw new InvalidOperationException("Cannot call this method when the entity has more than one identity member.");
         }

         MetaDataMember idMember = metaType.IdentityMembers[0];

         var predicateValues = new Dictionary<string, object> {
            { idMember.MappedName, db.ConvertMemberValue(idMember, id) }
         };

         var parameters = new List<object>(predicateValues.Count);
         string predicate = db.BuildPredicateFragment(predicateValues, parameters);

         return source.Where(predicate, parameters.ToArray());
      }

      /// <summary>
      /// Specifies the related objects to include in the query results.
      /// </summary>
      /// <param name="path">Dot-separated list of related objects to return in the query results.</param>
      /// <returns>A new <see cref="SqlSet"/> with the defined query path.</returns>
      /// <remarks>
      /// This method can only be used on mapped sets created by <see cref="Database"/>.
      /// </remarks>

      public SqlSet Include(string path) {

         if (path == null) throw new ArgumentNullException(nameof(path));

         if (this.ResultType == null) {
            throw new InvalidOperationException("Include operation is not supported on untyped sets.");
         }

         MetaType metaType = this.db.Configuration.Model.GetMetaType(this.ResultType);

         if (metaType == null) {
            throw new InvalidOperationException($"Mapping information was not found for '{this.ResultType.FullName}'.");
         }

         return IncludeImpl.Expand(this, path, metaType);
      }

      static class IncludeImpl {

         public static SqlSet Expand(SqlSet source, string path, MetaType metaType) {

            const string leftAlias = "dbex_l";
            const string rightAlias = "dbex_r";

            Database db = source.db;

            var query = new SqlBuilder()
               .SELECT(leftAlias + ".*");

            var associations = new List<MetaAssociation>();

            string[] parts = path.Split('.');
            Func<int, string> rAliasFn = i => rightAlias + (i + 1);

            MetaType currentType = metaType;
            MetaAssociation manyAssoc = null;

            for (int i = 0; i < parts.Length; i++) {

               string p = parts[i];
               string rAlias = rAliasFn(i);

               MetaDataMember member = currentType.PersistentDataMembers.SingleOrDefault(m => m.Name == p);

               if (member == null) {
                  throw new ArgumentException($"Couldn't find '{p}' on '{currentType.Type.FullName}'.", nameof(path));
               }

               if (!member.IsAssociation) {
                  throw new ArgumentException($"'{p}' is not an association property.", nameof(path));
               }

               MetaAssociation association = member.Association;

               if (association.IsMany) {

                  if (i != parts.Length - 1) {
                     throw new ArgumentException($"One-to-many associations can only be specified in the last segment of an include path ('{path}').", nameof(path));
                  }

                  manyAssoc = association;
                  break;
               }

               associations.Add(association);

               query.SELECT(String.Join(", ", association.OtherType.PersistentDataMembers
                  .Where(m => !m.IsAssociation)
                  .Select(m => $"{rAlias}.{db.QuoteIdentifier(m.MappedName)} AS {String.Join("$", associations.Select(a => a.ThisMember.Name))}${m.Name}")));

               currentType = association.OtherType;
            }

            SqlSet newSet;

            if (associations.Count == 0) {
               newSet = source.Clone();

            } else {

               query.FROM(source.GetDefiningQuery(), leftAlias);

               for (int i = 0; i < associations.Count; i++) {

                  MetaAssociation association = associations[i];
                  string lAlias = (i == 0) ? leftAlias : rAliasFn(i - 1);
                  string rAlias = rAliasFn(i);

                  var joinPredicate = new StringBuilder();

                  for (int j = 0; j < association.ThisKey.Count; j++) {

                     if (j > 0) {
                        joinPredicate.Append(" AND ");
                     }

                     MetaDataMember thisMember = association.ThisKey[j];
                     MetaDataMember otherMember = association.OtherKey[j];

                     joinPredicate.AppendFormat(CultureInfo.InvariantCulture, "{0}.{1} = {2}.{3}", lAlias, db.QuoteIdentifier(thisMember.Name), rAlias, db.QuoteIdentifier(otherMember.MappedName));
                  }

                  query.LEFT_JOIN($"{db.QuoteIdentifier(association.OtherType.Table.TableName)} {rAlias} ON ({joinPredicate.ToString()})");
               }

               newSet = source.CreateSet(query);
            }

            if (manyAssoc != null) {
               AddManyInclude(newSet, parts, manyAssoc);
            }

            return newSet;
         }

         static void AddManyInclude(SqlSet set, string[] path, MetaAssociation association) {

            if (set.ManyIncludes == null) {
               set.ManyIncludes = new Dictionary<string[], CollectionLoader>();
            }

            set.ManyIncludes.Add(path, new CollectionLoader {
               Load = GetMany,
               State = new CollectionLoaderState {
                  Table = set.db.Table(association.OtherType),
                  Association = association
               }
            });
         }

         static IEnumerable GetMany(object container, object state) {

            var loaderState = (CollectionLoaderState)state;

            MetaAssociation association = loaderState.Association;
            SqlTable table = loaderState.Table;

            var predicateValues = new Dictionary<string, object>();

            for (int i = 0; i < association.OtherKey.Count; i++) {
               predicateValues.Add(association.OtherKey[i].MappedName, table.db.GetMemberValue(container, association.ThisKey[i]));
            }

            var parameters = new List<object>();
            string whereFragment = table.db.BuildPredicateFragment(predicateValues, parameters);

            IEnumerable children = table.Where(whereFragment, parameters.ToArray()).AsEnumerable();

            MetaDataMember otherMember = association.OtherMember;

            foreach (object child in children) {

               if (otherMember != null
                  && !otherMember.Association.IsMany) {

                  object childObj = child;

                  otherMember.MemberAccessor.SetBoxedValue(ref childObj, container);
               }

               yield return child;
            }
         }

         class CollectionLoaderState {

            public SqlTable Table;
            public MetaAssociation Association;
         }
      }
   }

   partial class SqlSet<TResult> {

      /// <inheritdoc cref="SqlSet.Find(Object)"/>

      [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Need to keep result type same as input type.")]
      public new TResult Find(object id) {
         return ((SqlSet<TResult>)FindImpl(this, id)).SingleOrDefault();
      }

      /// <inheritdoc cref="SqlSet.Include(String)"/>
      /// <returns>A new <see cref="SqlSet&lt;TResult>"/> with the defined query path.</returns>

      [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Need to keep result type same as input type.")]
      public new SqlSet<TResult> Include(string path) {
         return (SqlSet<TResult>)base.Include(path);
      }
   }

   interface ISqlTable {

      bool Contains(object entity);
      bool ContainsKey(object id);

      void Remove(object entity);
      void RemoveKey(object id);
      void RemoveRange(IEnumerable<object> entities);
      void RemoveRange(params object[] entities);

      void Add(object entity);
      void AddDescendants(object entity); // internal
      void AddRange(IEnumerable<object> entities);
      void AddRange(params object[] entities);

      void Refresh(object entity);

      void Update(object entity);
      void UpdateRange(IEnumerable<object> entities);
      void UpdateRange(params object[] entities);
   }
}
