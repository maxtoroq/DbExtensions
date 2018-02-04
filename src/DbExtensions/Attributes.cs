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
using System.Diagnostics.CodeAnalysis;

namespace DbExtensions {

   [AttributeUsage(AttributeTargets.Class)]
   sealed class DatabaseAttribute : Attribute {

      public string Name { get; set; }
   }

   /// <summary>
   /// Designates a class as an entity class that is associated with a database table.
   /// </summary>

   [AttributeUsage(AttributeTargets.Class, Inherited = false)]
   public sealed class TableAttribute : Attribute {

      /// <summary>
      /// Gets or sets the name of the table or view.
      /// </summary>

      public string Name { get; set; }
   }

   /// <summary>
   /// Associates a property with a column in a database table.
   /// </summary>

   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
   public sealed class ColumnAttribute : Attribute, IDataAttribute {

      bool canBeNull = true;
      bool canBeNullSet = false;

      /// <summary>
      /// Gets or sets the name of a column.
      /// </summary>

      public string Name { get; set; }

      /// <summary>
      /// Gets or sets a private storage field to hold the value from a column.
      /// </summary>

      string IDataAttribute.Storage { get; set; }

      /// <summary>
      /// Gets or sets the type of the database column.
      /// </summary>

      [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "Conforms to legacy spelling.")]
      internal string DbType { get; set; }

      /// <summary>
      /// Gets or sets the type to convert this member to before sending to the database.
      /// </summary>

      public Type ConvertTo { get; set; }

      internal string Expression { get; set; }

      /// <summary>
      /// Gets or sets whether this class member represents a column that is part or all of the primary key of the table.
      /// </summary>

      public bool IsPrimaryKey { get; set; }

      /// <summary>
      ///  Gets or sets whether a column contains values that the database auto-generates.
      /// </summary>

      [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "Conforms to legacy spelling.")]
      public bool IsDbGenerated { get; set; }

      /// <summary>
      /// Gets or sets whether the column type of the member is a database timestamp or version number.
      /// </summary>

      public bool IsVersion { get; set; }

      internal UpdateCheck UpdateCheck { get; set; } = UpdateCheck.Always;

      /// <summary>
      /// Gets or sets the <see cref="AutoSync"/> enumeration.
      /// </summary>

      public AutoSync AutoSync { get; set; } = AutoSync.Default;

      internal bool IsDiscriminator { get; set; }

      internal bool CanBeNull {
         get { return canBeNull; }
         set {
            canBeNullSet = true;
            canBeNull = value;
         }
      }

      internal bool CanBeNullSet => canBeNullSet;
   }

   internal enum UpdateCheck {
      Always,
      Never,
      WhenChanged
   }

   /// <summary>
   /// Used to specify for during INSERT and UPDATE operations when
   /// a data member should be read back after the operation completes.
   /// </summary>

   public enum AutoSync {

      /// <summary>
      /// Automatically selects the value.
      /// </summary>

      Default = 0, // Automatically choose

      /// <summary>
      /// Always returns the value.
      /// </summary>

      Always = 1,

      /// <summary>
      /// Never returns the value.
      /// </summary>

      Never = 2,

      /// <summary>
      /// Returns the value only after an INSERT operation.
      /// </summary>

      OnInsert = 3,

      /// <summary>
      /// Returns the value only after an UPDATE operation.
      /// </summary>

      OnUpdate = 4
   }

   /// <summary>
   /// Designates a property to represent a database association, such as a foreign key relationship.
   /// </summary>

   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
   public sealed class AssociationAttribute : Attribute, IDataAttribute {

      /// <summary>
      /// Gets or sets the name of a constraint.
      /// </summary>

      public string Name { get; set; }

      /// <summary>
      /// Gets or sets a private storage field to hold the value for the association property.
      /// </summary>

      string IDataAttribute.Storage { get; set; }

      /// <summary>
      /// Gets or sets members of this entity class to represent the key values on this side of the association.
      /// </summary>

      public string ThisKey { get; set; }

      /// <summary>
      /// Gets or sets one or more members of the target entity class as key values on the other side of the association.
      /// </summary>

      public string OtherKey { get; set; }

      /// <summary>
      /// Gets or sets the indication of a uniqueness constraint on the foreign key.
      /// </summary>
      /// <remarks>When true, this property indicates a true 1:1 relationship.</remarks>

      internal bool IsUnique { get; set; }

      /// <summary>
      /// Gets or sets the member as the foreign key in an association representing a database relationship.
      /// </summary>

      internal bool IsForeignKey { get; set; }

      internal string DeleteRule { get; set; }

      internal bool DeleteOnNull { get; set; }
   }

   /// <summary>
   /// Class attribute used to describe an inheritance hierarchy to be mapped.
   /// For example, 
   /// 
   ///     [Table(Name = "People")]
   ///     [InheritanceMapping(Code = "P", Type = typeof(Person), IsDefault=true)]
   ///     [InheritanceMapping(Code = "C", Type = typeof(Customer))]
   ///     [InheritanceMapping(Code = "E", Type = typeof(Employee))]
   ///     class Person { ... }
   ///     
   /// </summary>

   [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
   sealed class InheritanceMappingAttribute : Attribute {

      /// <summary>
      /// Discriminator value in store column for this type.
      /// </summary>

      public object Code { get; set; }

      /// <summary>
      /// Type to instantiate when Key is matched.
      /// </summary>

      [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "The contexts in which this is available are fairly specific.")]
      public Type Type { get; set; }

      /// <summary>
      /// If discriminator value in store column is unrecognized then instantiate this type.
      /// </summary>

      public bool IsDefault { get; set; }
   }

   interface IDataAttribute {

      string Name { get; set; }

      string Storage { get; set; }
   }
}
