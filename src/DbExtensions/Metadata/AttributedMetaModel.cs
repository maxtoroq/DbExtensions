// Copyright 2016-2022 Max Toro Q.
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
using System.Linq;
using System.Reflection;
using System.Threading;

namespace DbExtensions.Metadata;

class AttributedMetaModel : MetaModel {

   ReaderWriterLock _lock = new();
   Dictionary<Type, MetaType> _metaTypes = new();
   Dictionary<Type, MetaTable> _metaTables = new();

   internal override MappingSource MappingSource { get; }

   internal override Type ContextType { get; }

   internal override string DatabaseName { get; }

   [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
   internal AttributedMetaModel(MappingSource mappingSource, Type contextType) {

      this.MappingSource = mappingSource;
      this.ContextType = contextType;

      var das = (DatabaseAttribute[])this.ContextType.GetCustomAttributes(typeof(DatabaseAttribute), false);

      this.DatabaseName = (das is not null && das.Length > 0) ?
         das[0].Name
         : this.ContextType.Name;
   }

   public override IEnumerable<MetaTable> GetTables() {

      _lock.AcquireReaderLock(Timeout.Infinite);

      try {
         return _metaTables.Values
            .Where(static x => x is not null)
            .Distinct();
      } finally {
         _lock.ReleaseReaderLock();
      }
   }

   public override MetaTable GetTable(Type rowType, MetaTableConfiguration config) {

      if (rowType is null) throw Error.ArgumentNull(nameof(rowType));

      MetaTable table;

      _lock.AcquireReaderLock(Timeout.Infinite);

      try {
         if (_metaTables.TryGetValue(rowType, out table)) {
            return table;
         }
      } finally {
         _lock.ReleaseReaderLock();
      }

      _lock.AcquireWriterLock(Timeout.Infinite);

      try {
         table = GetTableNoLocks(rowType, config);
      } finally {
         _lock.ReleaseWriterLock();
      }

      return table;
   }

   internal MetaTable GetTableNoLocks(Type rowType, MetaTableConfiguration config) {

      MetaTable table;

      if (!_metaTables.TryGetValue(rowType, out table)) {

         var root = GetRoot(rowType) ?? rowType;
         var attrs = (TableAttribute[])root.GetCustomAttributes(typeof(TableAttribute), true);

         if (attrs.Length == 0) {
            _metaTables.Add(rowType, null);
         } else {

            if (!_metaTables.TryGetValue(root, out table)) {

               table = new AttributedMetaTable(this, attrs[0], root, config);

               foreach (var mt in table.RowType.InheritanceTypes) {
                  _metaTables.Add(mt.Type, table);
               }
            }

            // catch case of derived type that is not part of inheritance

            if (table.RowType.GetInheritanceType(rowType) is null) {
               _metaTables.Add(rowType, null);
               return null;
            }
         }
      }

      return table;
   }

   static Type GetRoot(Type derivedType) {

      while (derivedType is not null && derivedType != typeof(object)) {

         var attrs = (TableAttribute[])derivedType.GetCustomAttributes(typeof(TableAttribute), false);

         if (attrs.Length > 0) {
            return derivedType;
         }

         derivedType = derivedType.BaseType;
      }

      return null;
   }

   public override MetaType GetMetaType(Type type, MetaTableConfiguration config) {

      if (type is null) throw Error.ArgumentNull(nameof(type));

      MetaType mtype = null;

      _lock.AcquireReaderLock(Timeout.Infinite);

      try {
         if (_metaTypes.TryGetValue(type, out mtype)) {
            return mtype;
         }
      } finally {
         _lock.ReleaseReaderLock();
      }

      // Attributed meta model allows us to learn about tables we did not
      // statically know about

      var tab = GetTable(type, config);

      if (tab is not null) {
         return tab.RowType.GetInheritanceType(type);
      }

      _lock.AcquireWriterLock(Timeout.Infinite);

      try {
         if (!_metaTypes.TryGetValue(type, out mtype)) {
            mtype = new UnmappedType(this, type);
            _metaTypes.Add(type, mtype);
         }
      } finally {
         _lock.ReleaseWriterLock();
      }

      return mtype;
   }
}

sealed class AttributedMetaTable : MetaTable {

   public override MetaModel Model { get; }

   public override string TableName { get; }

   public override MetaType RowType { get; }

   internal MetaTableConfiguration Configuration { get; private set; }

   internal AttributedMetaTable(AttributedMetaModel model, TableAttribute attr, Type rowType, MetaTableConfiguration config) {

      // set this first
      this.Configuration = new MetaTableConfiguration(config);

      this.Model = model;
      this.TableName = String.IsNullOrEmpty(attr.Name) ? rowType.Name : attr.Name;
      this.RowType = new AttributedRootType(model, this, rowType);
   }
}

sealed class AttributedRootType : AttributedMetaType {

   Dictionary<Type, MetaType> _types;
   Dictionary<object, MetaType> _codeMap;

   internal override bool HasInheritance => _types is not null;

   internal override ReadOnlyCollection<MetaType> InheritanceTypes { get; }

   internal override MetaType InheritanceDefault { get; }

   internal AttributedRootType(AttributedMetaModel model, AttributedMetaTable table, Type type)
      : base(model, table, type, null) {

      // check for inheritance and create all other types
      var inheritanceInfo = (InheritanceMappingAttribute[])
         type.GetCustomAttributes(typeof(InheritanceMappingAttribute), true);

      if (inheritanceInfo.Length > 0) {

         if (this.Discriminator is null) {
            throw Error.NoDiscriminatorFound(type);
         }

         if (!MappingSystem.IsSupportedDiscriminatorType(this.Discriminator.Type)) {
            throw Error.DiscriminatorClrTypeNotSupported(this.Discriminator.DeclaringType.Name, this.Discriminator.Name, this.Discriminator.Type);
         }

         _types = new Dictionary<Type, MetaType>();
         _types.Add(type, this); // add self
         _codeMap = new Dictionary<object, MetaType>();

         // initialize inheritance types

         foreach (var attr in inheritanceInfo) {

            if (!type.IsAssignableFrom(attr.Type)) {
               throw Error.InheritanceTypeDoesNotDeriveFromRoot(attr.Type, type);
            }

            if (attr.Type.IsAbstract) {
               throw Error.AbstractClassAssignInheritanceDiscriminator(attr.Type);
            }

            var mt = CreateInheritedType(type, attr.Type);

            if (attr.Code is null) {
               throw Error.InheritanceCodeMayNotBeNull();
            }

            if (mt._inheritanceCode is not null) {
               throw Error.InheritanceTypeHasMultipleDiscriminators(attr.Type);
            }

            //var codeValue = DBConvert.ChangeType(*/attr.Code/*, this.Discriminator.Type);
            var codeValue = attr.Code;

            foreach (var d in _codeMap.Keys) {

               // if the keys are equal, or if they are both strings containing only spaces
               // they are considered equal

               if ((codeValue.GetType() == typeof(string)
                     && ((string)codeValue).Trim().Length == 0
                     && d.GetType() == typeof(string)
                     && ((string)d).Trim().Length == 0)
                  || object.Equals(d, codeValue)) {

                  throw Error.InheritanceCodeUsedForMultipleTypes(codeValue);
               }
            }

            mt._inheritanceCode = codeValue;
            _codeMap.Add(codeValue, mt);

            if (attr.IsDefault) {

               if (this.InheritanceDefault is not null) {
                  throw Error.InheritanceTypeHasMultipleDefaults(type);
               }

               this.InheritanceDefault = mt;
            }
         }

         if (this.InheritanceDefault is null) {
            throw Error.InheritanceHierarchyDoesNotDefineDefault(type);
         }
      }

      if (_types is not null) {
         this.InheritanceTypes = _types.Values.ToList().AsReadOnly();
      } else {
         this.InheritanceTypes = new MetaType[] { this }.ToList().AsReadOnly();
      }

      Validate();
   }

   void Validate() {

      var memberToColumn = new Dictionary<object, string>();

      foreach (var type in this.InheritanceTypes) {

         if (type != this) {

            var attrs = (TableAttribute[])type.Type.GetCustomAttributes(typeof(TableAttribute), false);

            if (attrs.Length > 0) {
               throw Error.InheritanceSubTypeIsAlsoRoot(type.Type);
            }
         }

         foreach (var mem in type.PersistentDataMembers) {

            if (mem.IsDeclaredBy(type)) {

               if (mem.IsDiscriminator && !this.HasInheritance) {
                  throw Error.NonInheritanceClassHasDiscriminator(type);
               }

               if (!mem.IsAssociation) {

                  // validate that no database column is mapped twice

                  if (!String.IsNullOrEmpty(mem.MappedName)) {

                     var dn = InheritanceRules.DistinguishedMemberName(mem.Member);

                     if (memberToColumn.TryGetValue(dn, out var column)) {
                        if (column != mem.MappedName) {
                           throw Error.MemberMappedMoreThanOnce(mem.Member.Name);
                        }
                     } else {
                        memberToColumn.Add(dn, mem.MappedName);
                     }
                  }
               }
            }
         }
      }
   }

   AttributedMetaType CreateInheritedType(Type root, Type type) {

      MetaType metaType;

      if (!_types.TryGetValue(type, out metaType)) {

         metaType = new AttributedMetaType(this.Model, this.Table, type, this);
         _types.Add(type, metaType);

         if (type != root && type.BaseType != typeof(object)) {
            CreateInheritedType(root, type.BaseType);
         }
      }

      return (AttributedMetaType)metaType;
   }

   internal override MetaType GetInheritanceType(Type type) {

      if (type == this.Type) {
         return this;
      }

      var metaType = default(MetaType);

      if (_types is not null) {
         _types.TryGetValue(type, out metaType);
      }

      return metaType;
   }
}

class AttributedMetaType : MetaType {

   Dictionary<MetaPosition, MetaDataMember> _dataMemberMap;
   ReadOnlyCollection<MetaDataMember> _dataMembers;
   ReadOnlyCollection<MetaAssociation> _associations;
   MetaDataMember _dbGeneratedIdentity;
   MetaDataMember _version;

   bool _inheritanceBaseSet;
   MetaType _inheritanceBase;
   internal object _inheritanceCode;
   MetaDataMember _discriminator;
   ReadOnlyCollection<MetaType> _derivedTypes;

   object _locktarget = new(); // Hold locks on private object rather than public MetaType.

   public override MetaModel Model { get; }

   public override MetaTable Table { get; }

   public override Type Type { get; }

   public override MetaDataMember DBGeneratedIdentityMember => _dbGeneratedIdentity;

   public override MetaDataMember VersionMember => _version;

   public override string Name => Type.Name;

   public override bool IsEntity => Table?.RowType.IdentityMembers.Count > 0;

   public override bool CanInstantiate => !Type.IsAbstract && (this == InheritanceRoot || HasInheritanceCode);

   public override bool HasUpdateCheck => PersistentDataMembers.Any(static m => m.UpdateCheck != UpdateCheck.Never);

   public override ReadOnlyCollection<MetaDataMember> DataMembers => _dataMembers;

   public override ReadOnlyCollection<MetaDataMember> PersistentDataMembers { get; }

   public override ReadOnlyCollection<MetaDataMember> IdentityMembers { get; }

   public override ReadOnlyCollection<MetaAssociation> Associations {
      get {

         // LOCKING: Associations are late-expanded so that cycles are broken.

         if (_associations is null) {
            lock (_locktarget) {
               if (_associations is null) {
                  _associations = DataMembers.Where(static m => m.IsAssociation)
                     .Select(static m => m.Association)
                     .ToList()
                     .AsReadOnly();
               }
            }
         }

         return _associations;
      }
   }

   internal override MetaType InheritanceRoot { get; }

   internal override MetaDataMember Discriminator => _discriminator;

   internal override bool HasInheritance => InheritanceRoot.HasInheritance;

   internal override bool HasInheritanceCode => InheritanceCode is not null;

   internal override object InheritanceCode => _inheritanceCode;

   internal override MetaType InheritanceDefault => InheritanceRoot.InheritanceDefault;

   internal override bool IsInheritanceDefault => InheritanceDefault == this;

   internal override ReadOnlyCollection<MetaType> InheritanceTypes => InheritanceRoot.InheritanceTypes;

   internal override MetaType InheritanceBase {
      get {

         // LOCKING: Cannot initialize at construction

         if (!_inheritanceBaseSet
            && _inheritanceBase is null) {

            lock (_locktarget) {
               if (_inheritanceBase is null) {
                  _inheritanceBase = InheritanceBaseFinder.FindBase(this);
                  _inheritanceBaseSet = true;
               }
            }
         }

         return _inheritanceBase;
      }
   }

   internal override ReadOnlyCollection<MetaType> DerivedTypes {
      get {

         // LOCKING: Cannot initialize at construction because derived types
         // won't exist yet.

         if (_derivedTypes is null) {
            lock (_locktarget) {
               if (_derivedTypes is null) {

                  var dTypes = new List<MetaType>();

                  foreach (var mt in InheritanceTypes) {
                     if (mt.Type.BaseType == Type) {
                        dTypes.Add(mt);
                     }
                  }

                  _derivedTypes = dTypes.AsReadOnly();
               }
            }
         }

         return _derivedTypes;
      }
   }

   [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
   internal AttributedMetaType(MetaModel model, MetaTable table, Type type, MetaType inheritanceRoot) {

      this.Model = model;
      this.Table = table;
      this.Type = type;
      this.InheritanceRoot = inheritanceRoot ?? this;

      // Not lazy-loading to simplify locking and enhance performance 
      // (because no lock will be required for the common read scenario).

      InitDataMembers();

      this.IdentityMembers = this.DataMembers.Where(static m => m.IsPrimaryKey).ToList().AsReadOnly();
      this.PersistentDataMembers = this.DataMembers.Where(static m => m.IsPersistent).ToList().AsReadOnly();
   }

   void ValidatePrimaryKeyMember(MetaDataMember mm) {

      //if the type is a sub-type, no member declared in the type can be primary key

      if (mm.IsPrimaryKey
         && this.InheritanceRoot != this
         && mm.Member.DeclaringType == this.Type) {

         throw (Error.PrimaryKeyInSubTypeNotSupported(this.Type.Name, mm.Name));
      }
   }

   void InitDataMembers() {

      if (_dataMembers is null) {

         _dataMemberMap = new Dictionary<MetaPosition, MetaDataMember>();

         InitDataMembersImpl(this.Type);

         _dataMembers = new List<MetaDataMember>(_dataMemberMap.Values).AsReadOnly();
      }
   }

   void InitDataMembersImpl(Type containerType, MetaComplexProperty containerCp = null) {
      { // preserving indentation for cleaner diff

         var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

         var fis = TypeSystem.GetAllFields(containerType, flags)
            .ToArray();

         if (fis is not null) {

            for (int i = 0, n = fis.Length; i < n; i++) {

               var fi = fis[i];
               var mm = new AttributedMetaDataMember(this, fi, _dataMemberMap.Count, null);
               ValidatePrimaryKeyMember(mm);

               // must be public or persistent
               if (!mm.IsPersistent && !fi.IsPublic) {
                  continue;
               }

               _dataMemberMap.Add(new MetaPosition(fi), mm);

               // must be persistent for the rest

               if (!mm.IsPersistent) {
                  continue;
               }

               InitSpecialMember(mm);
            }
         }

         var pis = TypeSystem.GetAllProperties(containerType, flags)
            .ToArray();

         if (pis is not null) {

            for (int i = 0, n = pis.Length; i < n; i++) {

               var pi = pis[i];

               var mm = new AttributedMetaDataMember(this, pi, _dataMemberMap.Count, containerCp);
               ValidatePrimaryKeyMember(mm);

               // must be public or persistent

               var isPublic =
                  (pi.CanRead && pi.GetGetMethod(false) is not null)
                     && (!pi.CanWrite || pi.GetSetMethod(false) is not null);

               if (!mm.IsPersistent && !isPublic) {
                  continue;
               }

               if (!mm.IsPersistent) {

                  var cpAttr = (ComplexPropertyAttribute)Attribute.GetCustomAttribute(pi, typeof(ComplexPropertyAttribute));

                  if (cpAttr is not null) {

                     var complexPropType = pi.PropertyType;

                     if (!complexPropType.IsClass) {
                        throw new InvalidOperationException("A persistent complex property must be a class.");
                     }

                     if (complexPropType.IsAbstract) {
                        throw new InvalidOperationException("A persistent complex property cannot be an abstract type.");
                     }

                     var metaCp = new MetaComplexProperty(this, pi, cpAttr, containerCp);

                     InitDataMembersImpl(complexPropType, metaCp);

                     continue;
                  }
               }

               _dataMemberMap.Add(new MetaPosition(pi), mm);

               // must be persistent for the rest

               if (!mm.IsPersistent) {
                  continue;
               }

               InitSpecialMember(mm);
            }
         }
      }
   }

   void InitSpecialMember(MetaDataMember mm) {

      // Can only have one auto gen member that is also an identity member,
      // except if that member is a computed column (since they are implicitly auto gen)

      if (mm.IsDbGenerated
         && mm.IsPrimaryKey
         && String.IsNullOrEmpty(mm.Expression)) {

         if (_dbGeneratedIdentity is not null) {
            throw Error.TwoMembersMarkedAsPrimaryKeyAndDBGenerated(mm.Member, _dbGeneratedIdentity.Member);
         }

         _dbGeneratedIdentity = mm;
      }

      if (mm.IsPrimaryKey
         && !MappingSystem.IsSupportedIdentityType(mm.Type)) {

         throw Error.IdentityClrTypeNotSupported(mm.DeclaringType, mm.Name, mm.Type);
      }

      if (mm.IsVersion) {

         if (_version is not null) {
            throw Error.TwoMembersMarkedAsRowVersion(mm.Member, _version.Member);
         }

         _version = mm;
      }

      if (mm.IsDiscriminator) {

         if (_discriminator is not null) {
            throw Error.TwoMembersMarkedAsInheritanceDiscriminator(mm.Member, _discriminator.Member);
         }

         _discriminator = mm;
      }
   }

   public override MetaDataMember GetDataMember(MemberInfo mi) {

      if (mi is null) throw Error.ArgumentNull(nameof(mi));

      if (_dataMemberMap.TryGetValue(new MetaPosition(mi), out var mm)) {
         return mm;
      }

      // DON'T look to see if we are trying to get a member from an inherited type.
      // The calling code should know to look in the inherited type.

      if (mi.DeclaringType.IsInterface) {
         throw Error.MappingOfInterfacesMemberIsNotSupported(mi.DeclaringType.Name, mi.Name);
      }

      // the member is not mapped in the base class

      throw Error.UnmappedClassMember(mi.DeclaringType.Name, mi.Name);
   }

   internal override MetaType GetInheritanceType(Type inheritanceType) {

      if (inheritanceType == this.Type) {
         return this;
      }

      return this.InheritanceRoot.GetInheritanceType(inheritanceType);
   }

   internal override MetaType GetTypeForInheritanceCode(object key) {

      if (this.InheritanceRoot.Discriminator.Type == typeof(string)) {

         var skey = (string)key;

         foreach (var mt in this.InheritanceRoot.InheritanceTypes) {

            if (String.Compare((string)mt.InheritanceCode, skey, StringComparison.OrdinalIgnoreCase) == 0) {
               return mt;
            }
         }

      } else {

         foreach (var mt in this.InheritanceRoot.InheritanceTypes) {
            if (Object.Equals(mt.InheritanceCode, key)) {
               return mt;
            }
         }
      }

      return null;
   }

   public override string ToString() {
      return this.Name;
   }
}

sealed class AttributedMetaDataMember : MetaDataMember {

   Type _memberDeclaringType;
   bool _hasAccessors;
   MetaAccessor _accPublic;
   MetaAccessor _accPrivate;
   IDataAttribute _attr;
   ColumnAttribute _attrColumn;
   AssociationAttribute _attrAssoc;
   AttributedMetaAssociation _assoc;
   bool _isNullableType;
   object _locktarget = new(); // Hold locks on private object rather than public MetaType.

   MetaComplexProperty _containerCp;

   public override MetaType DeclaringType { get; }

   public override MemberInfo Member { get; }

   public override MemberInfo StorageMember { get; }

   public override string Name => Member.Name;

   public override int Ordinal { get; }

   public override Type Type { get; }

   public override Type ConvertToType => _attrColumn?.ConvertTo;

   public override bool IsPersistent => _attrColumn is not null || _attrAssoc is not null;

   public override bool IsAssociation => _attrAssoc is not null;

   public override bool IsPrimaryKey => _attrColumn?.IsPrimaryKey ?? false;

   public override bool IsVersion => _attrColumn?.IsVersion ?? false;

   public override string DbType => _attrColumn?.DbType;

   public override string Expression => _attrColumn?.Expression;

   public override UpdateCheck UpdateCheck => _attrColumn?.UpdateCheck ?? UpdateCheck.Never;

   public override string MappedName {
      get {
         var n = _attrColumn?.Name
            ?? _attrAssoc?.Name
            ?? Member.Name;

         if (_containerCp is not null) {
            return _containerCp.FullMappedName + _containerCp.Separator + n;
         }

         return n;
      }
   }

   public override string QueryPath =>
      (_containerCp is not null) ?
         _containerCp.QueryPath + MetaComplexProperty.QueryPathSeparator + Name
         : Name;

   internal override bool IsDiscriminator => _attrColumn?.IsDiscriminator ?? false;

   /// <summary>
   /// Returns true if the member is explicitly marked as auto gen, or if the
   /// member is computed or generated by the database server.
   /// </summary>

   public override bool IsDbGenerated {
      get {
         return _attrColumn is not null &&
            (_attrColumn.IsDbGenerated || !String.IsNullOrEmpty(_attrColumn.Expression)) || IsVersion;
      }
   }

   public override MetaAccessor MemberAccessor {
      get {
         InitAccessors();
         return _accPublic;
      }
   }

   public override MetaAccessor StorageAccessor {
      get {
         InitAccessors();
         return _accPrivate;
      }
   }

   public override bool CanBeNull {
      get {

         if (_attrColumn is null) {
            return true;
         }

         if (!_attrColumn.CanBeNullSet) {
            return _isNullableType || !Type.IsValueType;
         }

         return _attrColumn.CanBeNull;
      }
   }

   public override AutoSync AutoSync {
      get {
         if (_attrColumn is not null) {

            // auto-gen keys are always and only synced on insert

            if (IsDbGenerated && IsPrimaryKey) {
               return AutoSync.OnInsert;
            }

            // if the user has explicitly set it, use their value

            if (_attrColumn.AutoSync != AutoSync.Default) {
               return _attrColumn.AutoSync;
            }

            // database generated members default to always

            if (IsDbGenerated) {
               return AutoSync.Always;
            }
         }

         return AutoSync.Never;
      }
   }

   public override MetaAssociation Association {
      get {

         if (IsAssociation) {

            // LOCKING: This deferral isn't an optimization. It can't be done in the constructor
            // because there may be loops in the association graph.

            if (_assoc is null) {
               lock (_locktarget) {
                  if (_assoc is null) {
                     _assoc = new AttributedMetaAssociation(this, _attrAssoc);
                  }
               }
            }
         }

         return _assoc;
      }
   }

   internal AttributedMetaDataMember(AttributedMetaType metaType, MemberInfo mi, int ordinal, MetaComplexProperty containerCp) {

      _memberDeclaringType = mi.DeclaringType;
      this.DeclaringType = metaType;
      this.Member = mi;
      this.Ordinal = ordinal;
      this.Type = TypeSystem.GetMemberType(mi);
      _isNullableType = TypeSystem.IsNullableType(this.Type);
      _attrColumn = (ColumnAttribute)Attribute.GetCustomAttribute(mi, typeof(ColumnAttribute));
      _attrAssoc = (AssociationAttribute)Attribute.GetCustomAttribute(mi, typeof(AssociationAttribute));
      _attr = (_attrColumn is not null) ? (IDataAttribute)_attrColumn : (IDataAttribute)_attrAssoc;

      if (_attr is not null && _attr.Storage is not null) {

         var mis = mi.DeclaringType.GetMember(_attr.Storage, BindingFlags.Instance | BindingFlags.NonPublic);

         if (mis is null || mis.Length != 1) {
            throw Error.BadStorageProperty(_attr.Storage, mi.DeclaringType, mi.Name);
         }

         this.StorageMember = mis[0];
      }

      var storageType = (this.StorageMember is not null) ?
         TypeSystem.GetMemberType(this.StorageMember)
         : this.Type;

      if (_attrColumn is not null
         && _attrColumn.IsDbGenerated
         && _attrColumn.IsPrimaryKey) {

         // auto-gen identities must be synced on insert

         if ((_attrColumn.AutoSync != AutoSync.Default)
            && (_attrColumn.AutoSync != AutoSync.OnInsert)) {

            throw Error.IncorrectAutoSyncSpecification(mi.Name);
         }
      }

      _containerCp = containerCp;
   }

   void InitAccessors() {

      if (!_hasAccessors) {
         lock (_locktarget) {
            if (!_hasAccessors) {

               if (this.StorageMember is not null) {
                  _accPrivate = MakeMemberAccessor(this.Member.ReflectedType, this.StorageMember, null);
                  _accPublic = MakeMemberAccessor(this.Member.ReflectedType, this.Member, _accPrivate);
               } else {
                  _accPublic = _accPrivate = MakeMemberAccessor(this.Member.ReflectedType, this.Member, null);
               }

               _hasAccessors = true;
            }
         }
      }
   }

   static MetaAccessor MakeMemberAccessor(Type accessorType, MemberInfo mi, MetaAccessor storage) {

      var fi = mi as FieldInfo;
      MetaAccessor acc;

      if (fi is not null) {
         acc = FieldAccessor.Create(accessorType, fi);
      } else {
         var pi = (PropertyInfo)mi;
         acc = PropertyAccessor.Create(accessorType, pi, storage);
      }

      return acc;
   }

   public override object GetValueForDatabase(object instance) {

      if (_containerCp is not null) {

         instance = _containerCp.GetValueFromRoot(instance);

         if (instance is null) {
            return null;
         }
      }

      return base.GetValueForDatabase(instance);
   }

   public override bool IsDeclaredBy(MetaType declaringMetaType) {

      if (declaringMetaType is null) throw Error.ArgumentNull(nameof(declaringMetaType));

      return declaringMetaType.Type == _memberDeclaringType;
   }

   public override string ToString() {
      return this.DeclaringType.ToString() + ":" + this.Member.ToString();
   }
}

class MetaComplexProperty {

   internal static readonly string QueryPathSeparator = new(Mapper._pathSeparator);

   readonly ComplexPropertyAttribute _cpAttr;

   MetaAccessor _accPublic;
   bool _hasAccessors;
   object _locktarget = new();

   public PropertyInfo Member { get; }

   public string Separator => _cpAttr.Separator;

   public string MappedName => _cpAttr.Name ?? Member.Name;

   public string FullMappedName =>
      (Parent is not null) ?
         Parent.FullMappedName + Parent.Separator + MappedName
         : MappedName;

   public string QueryPath =>
      (Parent is not null) ?
         Parent.QueryPath + QueryPathSeparator + Member.Name
         : Member.Name;

   public MetaComplexProperty Parent { get; }

   public MetaAccessor MemberAccessor {
      get {
         InitAccessors();
         return _accPublic;
      }
   }

   public MetaComplexProperty(AttributedMetaType metaType, PropertyInfo member, ComplexPropertyAttribute cpAttr, MetaComplexProperty parent) {

      this.Member = member;
      _cpAttr = cpAttr;
      this.Parent = parent;

      string defaultSeparator;

      if (cpAttr.Separator is null
         && (defaultSeparator = ((AttributedMetaTable)metaType.Table).Configuration.DefaultComplexPropertySeparator) is not null) {

         _cpAttr = new ComplexPropertyAttribute(_cpAttr) {
            Separator = defaultSeparator
         };
      }
   }

   void InitAccessors() {

      if (!_hasAccessors) {
         lock (_locktarget) {
            if (!_hasAccessors) {

               _accPublic = PropertyAccessor.Create(this.Member.ReflectedType, this.Member, null);
               _hasAccessors = true;
            }
         }
      }
   }

   public object GetValueFromRoot(object root) {

      var cpStack = new Stack<MetaComplexProperty>();
      cpStack.Push(this);

      var current = this;

      while (current.Parent is not null) {
         cpStack.Push(current.Parent);
         current = current.Parent;
      }

      object obj = root;

      while (cpStack.Count > 0) {

         var cp = cpStack.Pop();
         obj = cp.MemberAccessor.GetBoxedValue(obj);

         if (obj is null) {
            break;
         }
      }

      return obj;
   }
}

class AttributedMetaAssociation : MetaAssociationImpl {

   public override MetaType OtherType { get; }

   public override MetaDataMember ThisMember { get; }

   public override MetaDataMember OtherMember { get; }

   public override ReadOnlyCollection<MetaDataMember> ThisKey { get; }

   public override ReadOnlyCollection<MetaDataMember> OtherKey { get; }

   public override bool ThisKeyIsPrimaryKey { get; }

   public override bool OtherKeyIsPrimaryKey { get; }

   public override bool IsMany { get; }

   public override bool IsForeignKey { get; }

   public override bool IsUnique { get; }

   public override bool IsNullable { get; }

   public override string DeleteRule { get; }

   public override bool DeleteOnNull { get; }

   [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
   internal AttributedMetaAssociation(AttributedMetaDataMember member, AssociationAttribute attr) {

      this.ThisMember = member;
      this.IsMany = TypeSystem.IsSequenceType(this.ThisMember.Type);

      var ot = (this.IsMany) ?
         TypeSystem.GetElementType(this.ThisMember.Type)
         : this.ThisMember.Type;

      this.OtherType = this.ThisMember.DeclaringType.Model.GetMetaType(ot, ((AttributedMetaTable)this.ThisMember.DeclaringType.Table).Configuration);
      this.ThisKey = (attr.ThisKey is not null) ? MakeKeys(this.ThisMember.DeclaringType, attr.ThisKey) : this.ThisMember.DeclaringType.IdentityMembers;
      this.OtherKey = (attr.OtherKey is not null) ? MakeKeys(this.OtherType, attr.OtherKey) : this.OtherType.IdentityMembers;
      this.ThisKeyIsPrimaryKey = AreEqual(this.ThisKey, this.ThisMember.DeclaringType.IdentityMembers);
      this.OtherKeyIsPrimaryKey = AreEqual(this.OtherKey, this.OtherType.IdentityMembers);
      this.IsForeignKey = attr.IsForeignKey;

      this.IsUnique = attr.IsUnique;
      this.DeleteRule = attr.DeleteRule;
      this.DeleteOnNull = attr.DeleteOnNull;

      // if any key members are not nullable, the association is not nullable

      foreach (var mm in this.ThisKey) {

         if (!mm.CanBeNull) {
            this.IsNullable = false;
            break;
         }
      }

      // validate DeleteOnNull specification

      if (this.DeleteOnNull == true) {
         if (!(this.IsForeignKey
            && !this.IsMany
            && !this.IsNullable)) {

            throw Error.InvalidDeleteOnNullSpecification(member);
         }
      }

      // validate the number of ThisKey columns is the same as the number of OtherKey columns

      if (this.ThisKey.Count != this.OtherKey.Count
         && this.ThisKey.Count > 0
         && this.OtherKey.Count > 0) {

         throw Error.MismatchedThisKeyOtherKey(member.Name, member.DeclaringType.Name);
      }

      // determine reverse reference member

      foreach (var omm in this.OtherType.PersistentDataMembers) {

         var oattr = (AssociationAttribute)Attribute.GetCustomAttribute(omm.Member, typeof(AssociationAttribute));

         if (oattr is null
            || omm == this.ThisMember) {

            continue;
         }

         if (attr.Name is not null
            && oattr.Name == attr.Name) {

            this.OtherMember = omm;
            break;
         }

         var otherMemberIsMany = TypeSystem.IsSequenceType(omm.Type);
         var otherMemberType = (otherMemberIsMany) ?
            TypeSystem.GetElementType(omm.Type)
            : omm.Type;

         if (member.DeclaringType.Type == otherMemberType) {
            this.OtherMember = omm;
            break;
         }
      }
   }
}

abstract class MetaAssociationImpl : MetaAssociation {

   static readonly char[] _keySeparators = new[] { ',' };

   /// <summary>
   /// Given a MetaType and a set of key fields, return the set of MetaDataMembers
   /// corresponding to the key.
   /// </summary>

   protected static ReadOnlyCollection<MetaDataMember> MakeKeys(MetaType mtype, string keyFields) {

      var names = keyFields.Split(_keySeparators);
      var members = new MetaDataMember[names.Length];

      for (int i = 0; i < names.Length; i++) {

         names[i] = names[i].Trim();

         var rmis = mtype.Type.GetMember(names[i], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

         if (rmis is null || rmis.Length != 1) {
            throw Error.BadKeyMember(names[i], keyFields, mtype.Name);
         }

         members[i] = mtype.GetDataMember(rmis[0]);

         if (members[i] is null) {
            throw Error.BadKeyMember(names[i], keyFields, mtype.Name);
         }
      }

      return new List<MetaDataMember>(members).AsReadOnly();
   }

   /// <summary>
   /// Compare two sets of keys for equality.
   /// </summary>

   protected static bool AreEqual(IEnumerable<MetaDataMember> key1, IEnumerable<MetaDataMember> key2) {

      using (var e1 = key1.GetEnumerator()) {
         using (var e2 = key2.GetEnumerator()) {

            bool m1, m2;

            for (m1 = e1.MoveNext(), m2 = e2.MoveNext(); m1 && m2; m1 = e1.MoveNext(), m2 = e2.MoveNext()) {
               if (e1.Current != e2.Current) {
                  return false;
               }
            }

            if (m1 != m2) {
               return false;
            }
         }
      }

      return true;
   }

   public override string ToString() {
      return $"{this.ThisMember.DeclaringType.Name} ->{(this.IsMany ? "*" : null)} {this.OtherType.Name}";
   }
}

sealed class UnmappedType : MetaType {

   static ReadOnlyCollection<MetaType> _emptyTypes = new List<MetaType>().AsReadOnly();
   static ReadOnlyCollection<MetaDataMember> _emptyDataMembers = new List<MetaDataMember>().AsReadOnly();
   static ReadOnlyCollection<MetaAssociation> _emptyAssociations = new List<MetaAssociation>().AsReadOnly();

   Dictionary<object, MetaDataMember> _dataMemberMap;
   ReadOnlyCollection<MetaDataMember> _dataMembers;
   ReadOnlyCollection<MetaType> _inheritanceTypes;
   object _locktarget = new(); // Hold locks on private object rather than public MetaType.

   public override MetaModel Model { get; }

   public override Type Type { get; }

   public override MetaTable Table => null;

   public override string Name => Type.Name;

   public override bool IsEntity => false;

   public override bool CanInstantiate => !Type.IsAbstract;

   public override MetaDataMember DBGeneratedIdentityMember => null;

   public override MetaDataMember VersionMember => null;

   internal override MetaDataMember Discriminator => null;

   public override bool HasUpdateCheck => false;

   public override ReadOnlyCollection<MetaDataMember> DataMembers {
      get {
         InitDataMembers();
         return _dataMembers;
      }
   }

   public override ReadOnlyCollection<MetaDataMember> PersistentDataMembers => _emptyDataMembers;

   public override ReadOnlyCollection<MetaDataMember> IdentityMembers {
      get {
         InitDataMembers();
         return _dataMembers;
      }
   }

   public override ReadOnlyCollection<MetaAssociation> Associations => _emptyAssociations;

   internal override ReadOnlyCollection<MetaType> InheritanceTypes {
      get {

         if (_inheritanceTypes is null) {
            lock (_locktarget) {
               if (_inheritanceTypes is null) {
                  _inheritanceTypes = new MetaType[] { this }.ToList().AsReadOnly();
               }
            }
         }

         return _inheritanceTypes;
      }
   }

   internal override ReadOnlyCollection<MetaType> DerivedTypes => _emptyTypes;

   internal override bool HasInheritance => false;

   internal override bool HasInheritanceCode => false;

   internal override object InheritanceCode => null;

   internal override MetaType InheritanceRoot => this;

   internal override MetaType InheritanceBase => null;

   internal override MetaType InheritanceDefault => null;

   internal override bool IsInheritanceDefault => false;

   internal UnmappedType(MetaModel model, Type type) {

      this.Model = model;
      this.Type = type;
   }

   internal override MetaType GetInheritanceType(Type inheritanceType) {

      if (inheritanceType == this.Type) {
         return this;
      }

      return null;
   }

   internal override MetaType GetTypeForInheritanceCode(object key) {
      return null;
   }

   public override MetaDataMember GetDataMember(MemberInfo mi) {

      if (mi is null) throw Error.ArgumentNull(nameof(mi));

      InitDataMembers();

      if (_dataMemberMap is null) {
         lock (_locktarget) {
            if (_dataMemberMap is null) {

               var map = new Dictionary<object, MetaDataMember>();

               foreach (var mm in _dataMembers) {
                  map.Add(InheritanceRules.DistinguishedMemberName(mm.Member), mm);
               }

               _dataMemberMap = map;
            }
         }
      }

      var dn = InheritanceRules.DistinguishedMemberName(mi);

      _dataMemberMap.TryGetValue(dn, out var mdm);

      return mdm;
   }

   void InitDataMembers() {

      if (_dataMembers is null) {
         lock (_locktarget) {
            if (_dataMembers is null) {

               var dMembers = new List<MetaDataMember>();
               var ordinal = 0;

               var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

               foreach (var fi in this.Type.GetFields(flags)) {
                  var mm = new UnmappedDataMember(this, fi, ordinal);
                  dMembers.Add(mm);
                  ordinal++;
               }

               foreach (var pi in this.Type.GetProperties(flags)) {
                  var mm = new UnmappedDataMember(this, pi, ordinal);
                  dMembers.Add(mm);
                  ordinal++;
               }

               _dataMembers = dMembers.AsReadOnly();
            }
         }
      }
   }

   public override string ToString() {
      return this.Name;
   }
}

sealed class UnmappedDataMember : MetaDataMember {

   MetaAccessor _accPublic;
   object _lockTarget = new();

   public override MetaType DeclaringType { get; }

   public override MemberInfo Member { get; }

   public override int Ordinal { get; }

   public override Type Type { get; }

   public override Type ConvertToType { get; }

   public override MemberInfo StorageMember => Member;

   public override string Name => Member.Name;

   public override MetaAccessor MemberAccessor {
      get {
         InitAccessors();
         return _accPublic;
      }
   }

   public override MetaAccessor StorageAccessor {
      get {
         InitAccessors();
         return _accPublic;
      }
   }

   public override bool IsPersistent => false;

   public override bool IsAssociation => false;

   public override bool IsPrimaryKey => false;

   public override bool IsDbGenerated => false;

   public override bool IsVersion => false;

   internal override bool IsDiscriminator => false;

   public override bool CanBeNull => !Type.IsValueType || TypeSystem.IsNullableType(Type);

   public override string DbType => null;

   public override string Expression => null;

   public override string MappedName => Member.Name;

   public override UpdateCheck UpdateCheck => UpdateCheck.Never;

   public override AutoSync AutoSync => AutoSync.Never;

   public override MetaAssociation Association => null;

   internal UnmappedDataMember(MetaType declaringType, MemberInfo mi, int ordinal) {

      this.DeclaringType = declaringType;
      this.Member = mi;
      this.Ordinal = ordinal;
      this.Type = TypeSystem.GetMemberType(mi);
   }

   void InitAccessors() {

      if (_accPublic is null) {
         lock (_lockTarget) {
            if (_accPublic is null) {
               _accPublic = MakeMemberAccessor(this.Member.ReflectedType, this.Member);
            }
         }
      }
   }

   public override bool IsDeclaredBy(MetaType metaType) {

      if (metaType is null) throw Error.ArgumentNull(nameof(metaType));

      return metaType.Type == this.Member.DeclaringType;
   }

   static MetaAccessor MakeMemberAccessor(Type accessorType, MemberInfo mi) {

      MetaAccessor acc;

      if (mi is FieldInfo fi) {
         acc = FieldAccessor.Create(accessorType, fi);
      } else {
         PropertyInfo pi = (PropertyInfo)mi;
         acc = PropertyAccessor.Create(accessorType, pi, null);
      }

      return acc;
   }
}

static class InheritanceBaseFinder {

   internal static MetaType FindBase(MetaType derivedType) {

      if (derivedType.Type == typeof(object)) {
         return null;
      }

      var clrType = derivedType.Type; // start
      var rootClrType = derivedType.InheritanceRoot.Type; // end
      var metaTable = derivedType.Table;
      MetaType metaType;

      while (true) {

         if (clrType == typeof(object)
            || clrType == rootClrType) {

            return null;
         }

         clrType = clrType.BaseType;
         metaType = derivedType.InheritanceRoot.GetInheritanceType(clrType);

         if (metaType is not null) {
            return metaType;
         }
      }
   }
}

/// <summary>
/// This class defines the rules for inheritance behaviors. The rules:
/// 
///  (1) The same field may not be mapped to different database columns.    
///      The DistinguishedMemberName and AreSameMember methods describe what 'same' means between two MemberInfos.
///  (2) Discriminators held in fixed-length fields in the database don't need
///      to be manually padded in inheritance mapping [InheritanceMapping(Code='x')]. 
///  
/// </summary>

static class InheritanceRules {

   /// <summary>
   /// Creates a name that is the same when the member should be considered 'same'
   /// for the purposes of the inheritance feature.
   /// </summary>

   internal static object DistinguishedMemberName(MemberInfo mi) {

      var pi = mi as PropertyInfo;
      var fi = mi as FieldInfo;

      if (fi is not null) {

         // Human readable variant:
         // return "fi:" + mi.Name + ":" + mi.DeclaringType;
         return new MetaPosition(mi);

      } else if (pi is not null) {

         var meth = default(MethodInfo);

         if (pi.CanRead) {
            meth = pi.GetGetMethod();
         }

         if (meth is null && pi.CanWrite) {
            meth = pi.GetSetMethod();
         }

         var isVirtual = meth is not null && meth.IsVirtual;

         // Human readable variant:
         // return "pi:" + mi.Name + ":" + (isVirtual ? "virtual" : mi.DeclaringType.ToString());

         if (isVirtual) {
            return mi.Name;
         } else {
            return new MetaPosition(mi);
         }

      } else {
         throw Error.ArgumentOutOfRange(nameof(mi));
      }
   }

   /// <summary>
   /// Compares two MemberInfos for 'same-ness'.
   /// </summary>

   internal static bool AreSameMember(MemberInfo mi1, MemberInfo mi2) {
      return DistinguishedMemberName(mi1).Equals(DistinguishedMemberName(mi2));
   }
}
