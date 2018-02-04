// Copyright 2016-2018 Max Toro Q.
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

#region Based on code from .NET Framework
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace DbExtensions.Metadata {

   /// <summary>
   /// A MetaModel is an abstraction representing the mapping between a database and domain objects
   /// </summary>

   abstract class MetaModel {

      /// <summary>
      ///  The mapping source that originated this model.
      /// </summary>

      internal abstract MappingSource MappingSource { get; }

      /// <summary>
      /// The type of DataContext type this model describes.
      /// </summary>

      internal abstract Type ContextType { get; }

      /// <summary>
      /// The name of the database.
      /// </summary>

      internal abstract string DatabaseName { get; }

      /// <summary>
      /// Gets the MetaTable associated with a given type.
      /// </summary>
      /// <param name="rowType">The CLR row type.</param>
      /// <returns>The MetaTable if one exists, otherwise null.</returns>

      public abstract MetaTable GetTable(Type rowType);

      /// <summary>
      /// Get an enumeration of all tables.
      /// </summary>
      /// <returns>An enumeration of all the MetaTables</returns>

      [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Non-trivial operations are not suitable for properties.")]
      public abstract IEnumerable<MetaTable> GetTables();

      /// <summary>
      /// This method discovers the MetaType for the given Type.
      /// </summary>

      public abstract MetaType GetMetaType(Type type);
   }

   /// <summary>
   /// A MetaTable represents an abstraction of a database table (or view)
   /// </summary>

   abstract class MetaTable {

      /// <summary>
      /// The MetaModel containing this MetaTable.
      /// </summary>

      public abstract MetaModel Model { get; }

      /// <summary>
      /// The name of the table as defined by the database.
      /// </summary>

      public abstract string TableName { get; }

      /// <summary>
      /// The MetaType describing the type of the rows of the table.
      /// </summary>

      public abstract MetaType RowType { get; }
   }

   /// <summary>
   /// A MetaType represents the mapping of a domain object type onto a database table's columns.
   /// </summary>

   abstract class MetaType {

      /// <summary>
      /// The MetaModel containing this MetaType.
      /// </summary>

      public abstract MetaModel Model { get; }

      /// <summary>
      /// The MetaTable using this MetaType for row definition.
      /// </summary>

      public abstract MetaTable Table { get; }

      /// <summary>
      /// The underlying CLR type.
      /// </summary>

      [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "The contexts in which this is available are fairly specific.")]
      public abstract Type Type { get; }

      /// <summary>
      /// The name of the MetaType (same as the CLR type's name).
      /// </summary>

      public abstract string Name { get; }

      /// <summary>
      /// True if the MetaType is an entity type.
      /// </summary>

      public abstract bool IsEntity { get; }

      /// <summary>
      /// True if the underlying type can be instantiated as the result of a query.
      /// </summary>

      public abstract bool CanInstantiate { get; }

      /// <summary>
      /// The member that represents the auto-generated identity column, or null if there is none.
      /// </summary>

      public abstract MetaDataMember DBGeneratedIdentityMember { get; }

      /// <summary>
      /// The member that represents the row-version or timestamp column, or null if there is none.
      /// </summary>

      public abstract MetaDataMember VersionMember { get; }

      /// <summary>
      /// The member that represents the inheritance discriminator column, or null if there is none.
      /// </summary>

      internal abstract MetaDataMember Discriminator { get; }

      /// <summary>
      /// True if the type has any persistent member with an UpdateCheck policy other than Never.
      /// </summary>

      public abstract bool HasUpdateCheck { get; }

      /// <summary>
      /// True if the type is part of a mapped inheritance hierarchy.
      /// </summary>

      internal abstract bool HasInheritance { get; }

      /// <summary>
      /// True if this type defines an inheritance code.
      /// </summary>

      internal abstract bool HasInheritanceCode { get; }

      /// <summary>
      /// The inheritance code defined by this type.
      /// </summary>

      internal abstract object InheritanceCode { get; }

      /// <summary>
      /// True if this type is used as the default of an inheritance hierarchy.
      /// </summary>

      internal abstract bool IsInheritanceDefault { get; }

      /// <summary>
      /// The root type of the inheritance hierarchy.
      /// </summary>

      internal abstract MetaType InheritanceRoot { get; }

      /// <summary>
      /// The base metatype in the inheritance hierarchy.
      /// </summary>

      internal abstract MetaType InheritanceBase { get; }

      /// <summary>
      /// The type that is the default of the inheritance hierarchy.
      /// </summary>

      internal abstract MetaType InheritanceDefault { get; }

      /// <summary>
      /// Gets the MetaType for an inheritance sub type.
      /// </summary>
      /// <param name="type">The root or sub type of the inheritance hierarchy.</param>
      /// <returns>The MetaType.</returns>

      internal abstract MetaType GetInheritanceType(Type type);

      /// <summary>
      /// Gets type associated with the specified inheritance code.
      /// </summary>
      /// <param name="code">The inheritance code</param>
      /// <returns>The MetaType.</returns>

      internal abstract MetaType GetTypeForInheritanceCode(object code);

      /// <summary>
      /// Gets an enumeration of all types defined by an inheritance hierarchy.
      /// </summary>
      /// <returns>Enumeration of MetaTypes.</returns>

      internal abstract ReadOnlyCollection<MetaType> InheritanceTypes { get; }

      /// <summary>
      /// Gets an enumeration of the immediate derived types in an inheritance hierarchy.
      /// </summary>
      /// <returns>Enumeration of MetaTypes.</returns>

      internal abstract ReadOnlyCollection<MetaType> DerivedTypes { get; }

      /// <summary>
      /// Gets an enumeration of all the data members (fields and properties).
      /// </summary>

      public abstract ReadOnlyCollection<MetaDataMember> DataMembers { get; }

      /// <summary>
      /// Gets an enumeration of all the persistent data members (fields and properties mapped into database columns).
      /// </summary>

      public abstract ReadOnlyCollection<MetaDataMember> PersistentDataMembers { get; }

      /// <summary>
      /// Gets an enumeration of all the data members that define up the unique identity of the type.
      /// </summary>

      public abstract ReadOnlyCollection<MetaDataMember> IdentityMembers { get; }

      /// <summary>
      /// Gets an enumeration of all the associations.
      /// </summary>

      public abstract ReadOnlyCollection<MetaAssociation> Associations { get; }

      /// <summary>
      /// Gets the MetaDataMember associated with the specified member.
      /// </summary>
      /// <param name="member">The CLR member.</param>
      /// <returns>The MetaDataMember if there is one, otherwise null.</returns>

      public abstract MetaDataMember GetDataMember(MemberInfo member);
   }

   /// <summary>
   /// A MetaDataMember represents the mapping between a domain object's field or property into a database table's column.
   /// </summary>

   [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "MetaData", Justification = "The capitalization was deliberately chosen.")]
   abstract class MetaDataMember {

      /// <summary>
      /// The MetaType containing this data member.
      /// </summary>

      public abstract MetaType DeclaringType { get; }

      /// <summary>
      /// The underlying MemberInfo.
      /// </summary>

      public abstract MemberInfo Member { get; }

      /// <summary>
      /// The member that actually stores this member's data.
      /// </summary>

      public abstract MemberInfo StorageMember { get; }

      /// <summary>
      /// The name of the member, same as the MemberInfo name.
      /// </summary>

      public abstract string Name { get; }

      /// <summary>
      /// The name of the column (or constraint) in the database.
      /// </summary>

      public abstract string MappedName { get; }

      /// <summary>
      /// The oridinal position of this member in the default layout of query results.
      /// </summary>

      public abstract int Ordinal { get; }

      /// <summary>
      /// The type of this member.
      /// </summary>

      [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "The contexts in which this is available are fairly specific.")]
      public abstract Type Type { get; }

      public abstract Type ConvertToType { get; }

      /// <summary>
      /// True if this member is declared by the specified type.
      /// </summary>
      /// <param name="type">Type to check.</param>

      public abstract bool IsDeclaredBy(MetaType type);

      /// <summary>
      /// The accessor used to get/set the value of this member.
      /// </summary>

      public abstract MetaAccessor MemberAccessor { get; }

      /// <summary>
      /// The accessor used to get/set the storage value of this member.
      /// </summary>

      public abstract MetaAccessor StorageAccessor { get; }

      /// <summary>
      /// True if this member is mapped to a column (or constraint).
      /// </summary>

      public abstract bool IsPersistent { get; }

      /// <summary>
      /// True if this member defines an association relationship.
      /// </summary>

      public abstract bool IsAssociation { get; }

      /// <summary>
      /// True if this member is part of the type's identity.
      /// </summary>

      public abstract bool IsPrimaryKey { get; }

      /// <summary>
      /// True if this member is automatically generated by the database.
      /// </summary>

      [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "Conforms to legacy spelling.")]
      public abstract bool IsDbGenerated { get; }

      /// <summary>
      /// True if this member represents the row version or timestamp.
      /// </summary>

      public abstract bool IsVersion { get; }

      /// <summary>
      /// True if this member represents the inheritance discriminator.
      /// </summary>

      internal abstract bool IsDiscriminator { get; }

      /// <summary>
      /// True if this member's value can be assigned the null value.
      /// </summary>

      public abstract bool CanBeNull { get; }

      /// <summary>
      /// The type of the database column.
      /// </summary>

      [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "Conforms to legacy spelling.")]
      public abstract string DbType { get; }

      /// <summary>
      /// Expression defining a computed column.
      /// </summary>

      public abstract string Expression { get; }

      /// <summary>
      /// The optimistic concurrency check policy for this member.
      /// </summary>

      public abstract UpdateCheck UpdateCheck { get; }

      /// <summary>
      /// Specifies for inserts and updates when this member should be read back after the
      /// operation completes.
      /// </summary>

      public abstract AutoSync AutoSync { get; }

      /// <summary>
      /// The MetaAssociation corresponding to this member, or null if there is none.
      /// </summary>

      public abstract MetaAssociation Association { get; }

      public object GetValueForDatabase(object instance) {

         object value = this.MemberAccessor.GetBoxedValue(instance);

         return ConvertValueForDatabase(value);
      }

      public object ConvertValueForDatabase(object value) {

         if (value == null
            || this.ConvertToType == null) {

            return value;
         }

         return Convert.ChangeType(value, this.ConvertToType);
      }
   }

   /// <summary>
   /// A MetaAssociation represents an association relationship between two entity types.
   /// </summary>

   abstract class MetaAssociation {

      /// <summary>
      /// The type on the other end of the association.
      /// </summary>

      public abstract MetaType OtherType { get; }

      /// <summary>
      /// The member on this side that represents the association.
      /// </summary>

      public abstract MetaDataMember ThisMember { get; }

      /// <summary>
      /// The member on the other side of this association that represents the reverse association (may be null).
      /// </summary>

      public abstract MetaDataMember OtherMember { get; }

      /// <summary>
      /// A list of members representing the values on this side of the association.
      /// </summary>

      public abstract ReadOnlyCollection<MetaDataMember> ThisKey { get; }

      /// <summary>
      /// A list of members representing the values on the other side of the association.
      /// </summary>

      public abstract ReadOnlyCollection<MetaDataMember> OtherKey { get; }

      /// <summary>
      /// True if the association is OneToMany.
      /// </summary>

      public abstract bool IsMany { get; }

      /// <summary>
      /// True if the other type is the parent of this type.
      /// </summary>

      public abstract bool IsForeignKey { get; }

      /// <summary>
      /// True if the association is unique (defines a uniqueness constraint).
      /// </summary>

      public abstract bool IsUnique { get; }

      /// <summary>
      /// True if the association may be null (key values).
      /// </summary>

      public abstract bool IsNullable { get; }

      /// <summary>
      /// True if the ThisKey forms the identity (primary key) of the this type.
      /// </summary>

      public abstract bool ThisKeyIsPrimaryKey { get; }

      /// <summary>
      /// True if the OtherKey forms the identity (primary key) of the other type.
      /// </summary>

      public abstract bool OtherKeyIsPrimaryKey { get; }

      /// <summary>
      /// Specifies the behavior when the child is deleted (e.g. CASCADE, SET NULL).
      /// Returns null if no action is specified on delete.
      /// </summary>

      public abstract string DeleteRule { get; }

      /// <summary>
      /// Specifies whether the object should be deleted when this association
      /// is set to null.
      /// </summary>

      public abstract bool DeleteOnNull { get; }
   }

   /// <summary>
   /// A MetaAccessor
   /// </summary>

   abstract class MetaAccessor {

      /// <summary>
      /// The type of the member accessed by this accessor.
      /// </summary>

      [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "The contexts in which this is available are fairly specific.")]
      public abstract Type Type { get; }

      /// <summary>
      /// Gets the value as an object.
      /// </summary>
      /// <param name="instance">The instance to get the value from.</param>
      /// <returns>Value.</returns>

      public abstract object GetBoxedValue(object instance);

      /// <summary>
      /// Sets the value as an object.
      /// </summary>
      /// <param name="instance">The instance to set the value into.</param>
      /// <param name="value">The value to set.</param>

      [SuppressMessage("Microsoft.Design", "CA1007:UseGenericsWhereAppropriate", Justification = "[....]: Needs to handle classes and structs.")]
      [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", Justification = "Unknown reason.")]
      public abstract void SetBoxedValue(ref object instance, object value);

      /// <summary>
      /// True if the instance has a loaded or assigned value.
      /// </summary>

      internal virtual bool HasValue(object instance) {
         return true;
      }

      /// <summary>
      /// True if the instance has an assigned value.
      /// </summary>

      internal virtual bool HasAssignedValue(object instance) {
         return true;
      }

      /// <summary>
      /// True if the instance has a value loaded from a deferred source.
      /// </summary>

      internal virtual bool HasLoadedValue(object instance) {
         return false;
      }
   }

   /// <summary>
   /// A strongly-typed MetaAccessor. Used for reading from and writing to
   /// CLR objects.
   /// </summary>
   /// <typeparam name="TEntity">The type of the object</typeparam>
   /// <typeparam name="TMember">The type of the accessed member</typeparam>

   abstract class MetaAccessor<TEntity, TMember> : MetaAccessor {

      /// <summary>
      /// The underlying CLR type.
      /// </summary>

      public override Type Type => typeof(TMember);

      /// <summary>
      /// Set the boxed value on an instance.
      /// </summary>

      public override void SetBoxedValue(ref object instance, object value) {

         TEntity tInst = (TEntity)instance;
         SetValue(ref tInst, (TMember)value);
         instance = tInst;
      }

      /// <summary>
      /// Retrieve the boxed value.
      /// </summary>

      public override object GetBoxedValue(object instance) {
         return GetValue((TEntity)instance);
      }

      /// <summary>
      /// Gets the strongly-typed value.
      /// </summary>

      public abstract TMember GetValue(TEntity instance);

      /// <summary>
      /// Sets the strongly-typed value
      /// </summary>

      [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#", Justification = "Unknown reason.")]
      public abstract void SetValue(ref TEntity instance, TMember value);
   }
}
