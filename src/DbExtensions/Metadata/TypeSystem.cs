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
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace DbExtensions.Metadata {

   static class TypeSystem {

      internal static bool IsSequenceType(Type seqType) {

         return seqType != typeof(string)
                && seqType != typeof(byte[])
                && seqType != typeof(char[])
                && FindIEnumerable(seqType) != null;
      }

      static Type FindIEnumerable(Type seqType) {

         if (seqType == null || seqType == typeof(string)) {
            return null;
         }

         if (seqType.IsArray) {
            return typeof(IEnumerable<>).MakeGenericType(seqType.GetElementType());
         }

         if (seqType.IsGenericType) {

            foreach (Type arg in seqType.GetGenericArguments()) {

               Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);

               if (ienum.IsAssignableFrom(seqType)) {
                  return ienum;
               }
            }
         }

         Type[] ifaces = seqType.GetInterfaces();

         if (ifaces != null && ifaces.Length > 0) {

            foreach (Type iface in ifaces) {

               Type ienum = FindIEnumerable(iface);

               if (ienum != null) {
                  return ienum;
               }
            }
         }

         if (seqType.BaseType != null
            && seqType.BaseType != typeof(object)) {

            return FindIEnumerable(seqType.BaseType);
         }

         return null;
      }

      internal static Type GetElementType(Type seqType) {

         Type ienum = FindIEnumerable(seqType);

         if (ienum == null) {
            return seqType;
         }

         return ienum.GetGenericArguments()[0];
      }

      internal static bool IsNullableType(Type type) {

         return type != null
            && type.IsGenericType
            && type.GetGenericTypeDefinition() == typeof(Nullable<>);
      }

      internal static Type GetMemberType(MemberInfo mi) {

         FieldInfo fi = mi as FieldInfo;

         if (fi != null) {
            return fi.FieldType;
         }

         PropertyInfo pi = mi as PropertyInfo;

         if (pi != null) {
            return pi.PropertyType;
         }

         EventInfo ei = mi as EventInfo;

         if (ei != null) {
            return ei.EventHandlerType;
         }

         return null;
      }

      internal static IEnumerable<FieldInfo> GetAllFields(Type type, BindingFlags flags) {

         var seen = new Dictionary<MetaPosition, FieldInfo>();

         Type currentType = type;

         do {

            foreach (FieldInfo fi in currentType.GetFields(flags)) {
               if (fi.IsPrivate || type == currentType) {
                  var mp = new MetaPosition(fi);
                  seen[mp] = fi;
               }
            }

            currentType = currentType.BaseType;

         } while (currentType != null);

         return seen.Values;
      }

      internal static IEnumerable<PropertyInfo> GetAllProperties(Type type, BindingFlags flags) {

         var seen = new Dictionary<MetaPosition, PropertyInfo>();

         Type currentType = type;

         do {

            foreach (PropertyInfo pi in currentType.GetProperties(flags)) {
               if (type == currentType || IsPrivate(pi)) {
                  var mp = new MetaPosition(pi);
                  seen[mp] = pi;
               }
            }

            currentType = currentType.BaseType;

         } while (currentType != null);

         return seen.Values;
      }

      static bool IsPrivate(PropertyInfo pi) {

         MethodInfo mi = pi.GetGetMethod() ?? pi.GetSetMethod();

         if (mi != null) {
            return mi.IsPrivate;
         }

         return true;
      }
   }

   /// <summary>
   /// Hashable MetaDataToken+Assembly. This type uniquely describes a metadata element
   /// like a MemberInfo. MetaDataToken by itself is not sufficient because its only
   /// unique within a single assembly.
   /// </summary>

   struct MetaPosition : IEqualityComparer<MetaPosition>, IEqualityComparer {

      int metadataToken;
      Assembly assembly;

      internal MetaPosition(MemberInfo mi)
         : this(mi.DeclaringType.Assembly, mi.MetadataToken) {
      }

      private MetaPosition(Assembly assembly, int metadataToken) {
         this.assembly = assembly;
         this.metadataToken = metadataToken;
      }

      // Equality is implemented here according to the advice in
      // CLR via C# 2ed, J. Richter, p 146. In particular, ValueType.Equals
      // should not be called for perf reasons.

      #region Object Members

      public override bool Equals(object obj) {

         if (obj == null) {
            return false;
         }

         if (obj.GetType() != GetType()) {
            return false;
         }

         return AreEqual(this, (MetaPosition)obj);
      }

      public override int GetHashCode() {
         return this.metadataToken;
      }

      #endregion

      #region IEqualityComparer<MetaPosition> Members

      public bool Equals(MetaPosition x, MetaPosition y) {
         return AreEqual(x, y);
      }

      public int GetHashCode(MetaPosition obj) {
         return obj.metadataToken;
      }

      #endregion

      #region IEqualityComparer Members

      bool IEqualityComparer.Equals(object x, object y) {
         return Equals((MetaPosition)x, (MetaPosition)y);
      }
      int IEqualityComparer.GetHashCode(object obj) {
         return GetHashCode((MetaPosition)obj);
      }

      #endregion

      static bool AreEqual(MetaPosition x, MetaPosition y) {

         return (x.metadataToken == y.metadataToken)
             && (x.assembly == y.assembly);
      }

      // Since MetaPositions are immutable, we overload the equality operator
      // to test for value equality, rather than reference equality

      public static bool operator ==(MetaPosition x, MetaPosition y) {
         return AreEqual(x, y);
      }

      public static bool operator !=(MetaPosition x, MetaPosition y) {
         return !AreEqual(x, y);
      }
   }
}
