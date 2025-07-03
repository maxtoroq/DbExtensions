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
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace DbExtensions.Metadata;

delegate V DGet<T, V>(T t);
delegate void DSet<T, V>(T t, V v);
delegate void DRSet<T, V>(ref T t, V v);

static class FieldAccessor {

   [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
   internal static MetaAccessor Create(Type objectType, FieldInfo fi) {

      if (!fi.ReflectedType.IsAssignableFrom(objectType)) {
         throw Error.InvalidFieldInfo(objectType, fi.FieldType, fi);
      }

      Delegate dget = null;
      Delegate drset = null;

      if (!objectType.IsGenericType) {

         var mget = new DynamicMethod(
            "xget_" + fi.Name,
            fi.FieldType,
            new Type[] { objectType },
            true
         );

         var gen = mget.GetILGenerator();
         gen.Emit(OpCodes.Ldarg_0);
         gen.Emit(OpCodes.Ldfld, fi);
         gen.Emit(OpCodes.Ret);
         dget = mget.CreateDelegate(typeof(DGet<,>).MakeGenericType(objectType, fi.FieldType));

         var mset = new DynamicMethod(
            "xset_" + fi.Name,
            typeof(void),
            new Type[] { objectType.MakeByRefType(), fi.FieldType },
            true
         );

         gen = mset.GetILGenerator();
         gen.Emit(OpCodes.Ldarg_0);

         if (!objectType.IsValueType) {
            gen.Emit(OpCodes.Ldind_Ref);
         }

         gen.Emit(OpCodes.Ldarg_1);
         gen.Emit(OpCodes.Stfld, fi);
         gen.Emit(OpCodes.Ret);
         drset = mset.CreateDelegate(typeof(DRSet<,>).MakeGenericType(objectType, fi.FieldType));
      }

      return (MetaAccessor)Activator.CreateInstance(
         typeof(Accessor<,>).MakeGenericType(objectType, fi.FieldType),
         BindingFlags.Instance | BindingFlags.NonPublic, null,
         new object[] { fi, dget, drset }, null
      );
   }

   class Accessor<T, V> : MetaAccessor<T, V> {

      readonly DGet<T, V> _dget;
      readonly DRSet<T, V> _drset;
      readonly FieldInfo _fi;

      internal Accessor(FieldInfo fi, DGet<T, V> dget, DRSet<T, V> drset) {
         _fi = fi;
         _dget = dget;
         _drset = drset;
      }

      public override V GetValue(T instance) {

         if (_dget is not null) {
            return _dget.Invoke(instance);
         }

         return (V)_fi.GetValue(instance);
      }

      public override void SetValue(ref T instance, V value) {

         if (_drset is not null) {
            _drset.Invoke(ref instance, value);
         } else {
            _fi.SetValue(instance, value);
         }
      }
   }
}

static class PropertyAccessor {

   internal static MetaAccessor Create(Type objectType, PropertyInfo pi, MetaAccessor storageAccessor) {

      var dset = default(Delegate);
      var drset = default(Delegate);
      var dgetType = typeof(DGet<,>).MakeGenericType(objectType, pi.PropertyType);
      var getMethod = pi.GetGetMethod(true);

      var dget = Delegate.CreateDelegate(dgetType, getMethod, true);

      if (dget is null) {
         throw Error.CouldNotCreateAccessorToProperty(objectType, pi.PropertyType, pi);
      }

      if (pi.CanWrite) {

         if (!objectType.IsValueType) {
            dset = Delegate.CreateDelegate(typeof(DSet<,>).MakeGenericType(objectType, pi.PropertyType), pi.GetSetMethod(true), true);
         } else {

            var mset = new DynamicMethod(
               "xset_" + pi.Name,
               typeof(void),
               new Type[] { objectType.MakeByRefType(), pi.PropertyType },
               true
            );

            var gen = mset.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);

            if (!objectType.IsValueType) {
               gen.Emit(OpCodes.Ldind_Ref);
            }

            gen.Emit(OpCodes.Ldarg_1);
            gen.Emit(OpCodes.Call, pi.GetSetMethod(true));
            gen.Emit(OpCodes.Ret);
            drset = mset.CreateDelegate(typeof(DRSet<,>).MakeGenericType(objectType, pi.PropertyType));
         }
      }

      var saType = (storageAccessor is not null) ?
         storageAccessor.Type
         : pi.PropertyType;

      return (MetaAccessor)Activator.CreateInstance(
         typeof(Accessor<,,>).MakeGenericType(objectType, pi.PropertyType, saType),
         BindingFlags.Instance | BindingFlags.NonPublic, null,
         new object[] { pi, dget, dset, drset, storageAccessor }, null
      );
   }

   class Accessor<T, V, V2> : MetaAccessor<T, V> where V2 : V {

      readonly PropertyInfo _pi;
      readonly DGet<T, V> _dget;
      readonly DSet<T, V> _dset;
      readonly DRSet<T, V> _drset;
      readonly MetaAccessor<T, V2> _storage;

      internal Accessor(PropertyInfo pi, DGet<T, V> dget, DSet<T, V> dset, DRSet<T, V> drset, MetaAccessor<T, V2> storage) {

         _pi = pi;
         _dget = dget;
         _dset = dset;
         _drset = drset;
         _storage = storage;
      }

      public override V GetValue(T instance) {
         return _dget.Invoke(instance);
      }

      public override void SetValue(ref T instance, V value) {

         if (_dset is not null) {
            _dset.Invoke(instance, value);

         } else if (_drset is not null) {
            _drset.Invoke(ref instance, value);

         } else if (_storage is not null) {
            _storage.SetValue(ref instance, (V2)value);

         } else {
            throw Error.UnableToAssignValueToReadonlyProperty(_pi);
         }
      }
   }
}
