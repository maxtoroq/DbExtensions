// Copyright 2009-2018 Max Toro Q.
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
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace DbExtensions {

   /// <summary>
   /// Provides extension methods for common ADO.NET objects.
   /// </summary>

   public static partial class Extensions {

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Boolean"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Boolean GetBoolean(this IDataRecord record, string name) {
         return record.GetBoolean(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Byte"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Byte GetByte(this IDataRecord record, string name) {
         return record.GetByte(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Char"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Char GetChar(this IDataRecord record, string name) {
         return record.GetChar(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="DateTime"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static DateTime GetDateTime(this IDataRecord record, string name) {
         return record.GetDateTime(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Decimal"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Decimal GetDecimal(this IDataRecord record, string name) {
         return record.GetDecimal(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Double"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Double GetDouble(this IDataRecord record, string name) {
         return record.GetDouble(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Single"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Single GetFloat(this IDataRecord record, string name) {
         return record.GetFloat(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as an <see cref="Int16"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Int16 GetInt16(this IDataRecord record, string name) {
         return record.GetInt16(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as an <see cref="Int32"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Int32 GetInt32(this IDataRecord record, string name) {
         return record.GetInt32(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as an <see cref="Int64"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Int64 GetInt64(this IDataRecord record, string name) {
         return record.GetInt64(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="String"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static String GetString(this IDataRecord record, string name) {
         return record.GetString(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column.
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="name">The name of the column to find.</param>
      /// <returns>The value of the column.</returns>

      public static Object GetValue(this IDataRecord record, string name) {
         return record.GetValue(record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Boolean&gt;"/> of <see cref="Boolean"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Boolean? GetNullableBoolean(this IDataRecord record, string name) {
         return GetNullableBoolean(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Boolean&gt;"/> of <see cref="Boolean"/>.
      /// </summary>
      /// <inheritdoc cref="GetValueOrNull(IDataRecord, Int32)"/>

      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Boolean? GetNullableBoolean(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Boolean?) : record.GetBoolean(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Byte&gt;"/> of <see cref="Byte"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Byte? GetNullableByte(this IDataRecord record, string name) {
         return GetNullableByte(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Byte&gt;"/> of <see cref="Byte"/>.
      /// </summary>
      /// <inheritdoc cref="GetValueOrNull(IDataRecord, Int32)"/>

      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Byte? GetNullableByte(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Byte?) : record.GetByte(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Char&gt;"/> of <see cref="Char"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Char? GetNullableChar(this IDataRecord record, string name) {
         return GetNullableChar(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Char&gt;"/> of <see cref="Char"/>.
      /// </summary>
      /// <inheritdoc cref="GetValueOrNull(IDataRecord, Int32)"/>

      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Char? GetNullableChar(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Char?) : record.GetChar(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;DateTime&gt;"/> of <see cref="DateTime"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static DateTime? GetNullableDateTime(this IDataRecord record, string name) {
         return GetNullableDateTime(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;DateTime&gt;"/> of <see cref="DateTime"/>.
      /// </summary>
      /// <inheritdoc cref="GetValueOrNull(IDataRecord, Int32)"/>

      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static DateTime? GetNullableDateTime(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(DateTime?) : record.GetDateTime(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Decimal&gt;"/> of <see cref="Decimal"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Decimal? GetNullableDecimal(this IDataRecord record, string name) {
         return GetNullableDecimal(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Decimal&gt;"/> of <see cref="Decimal"/>.
      /// </summary>
      /// <inheritdoc cref="GetValueOrNull(IDataRecord, Int32)"/>

      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Decimal? GetNullableDecimal(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Decimal?) : record.GetDecimal(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Double&gt;"/> of <see cref="Double"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Double? GetNullableDouble(this IDataRecord record, string name) {
         return GetNullableDouble(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Double&gt;"/> of <see cref="Double"/>.
      /// </summary>
      /// <inheritdoc cref="GetValueOrNull(IDataRecord, Int32)"/>

      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Double? GetNullableDouble(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Double?) : record.GetDouble(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Single&gt;"/> of <see cref="Single"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Single? GetNullableFloat(this IDataRecord record, string name) {
         return GetNullableFloat(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Single&gt;"/> of <see cref="Single"/>.
      /// </summary>
      /// <inheritdoc cref="GetValueOrNull(IDataRecord, Int32)"/>

      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Single? GetNullableFloat(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Single?) : record.GetFloat(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Guid&gt;"/> of <see cref="Guid"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Guid? GetNullableGuid(this IDataRecord record, string name) {
         return GetNullableGuid(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Guid&gt;"/> of <see cref="Guid"/>.
      /// </summary>
      /// <inheritdoc cref="GetValueOrNull(IDataRecord, Int32)"/>

      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Guid? GetNullableGuid(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Guid?) : record.GetGuid(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Int16&gt;"/> of <see cref="Int16"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Int16? GetNullableInt16(this IDataRecord record, string name) {
         return GetNullableInt16(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Int16&gt;"/> of <see cref="Int16"/>.
      /// </summary>
      /// <inheritdoc cref="GetValueOrNull(IDataRecord, Int32)"/>

      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Int16? GetNullableInt16(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Int16?) : record.GetInt16(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Int32&gt;"/> of <see cref="Int32"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Int32? GetNullableInt32(this IDataRecord record, string name) {
         return GetNullableInt32(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Int32&gt;"/> of <see cref="Int32"/>.
      /// </summary>
      /// <inheritdoc cref="GetValueOrNull(IDataRecord, Int32)"/>

      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Int32? GetNullableInt32(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Int32?) : record.GetInt32(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Int64&gt;"/> of <see cref="Int64"/>.
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Int64? GetNullableInt64(this IDataRecord record, string name) {
         return GetNullableInt64(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="Nullable&lt;Int64&gt;"/> of <see cref="Int64"/>.
      /// </summary>
      /// <inheritdoc cref="GetValueOrNull(IDataRecord, Int32)"/>

      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Int64? GetNullableInt64(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(Int64?) : record.GetInt64(i);
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="String"/>, or null (Nothing in Visual Basic).
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static String GetStringOrNull(this IDataRecord record, string name) {
         return GetStringOrNull(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as a <see cref="String"/>, or null (Nothing in Visual Basic).
      /// </summary>
      /// <inheritdoc cref="GetValueOrNull(IDataRecord, Int32)"/>

      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static String GetStringOrNull(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? default(String) : record.GetString(i);
      }

      /// <summary>
      /// Gets the value of the specified column as an <see cref="Object"/>, or null (Nothing in Visual Basic).
      /// </summary>
      /// <inheritdoc cref="GetValue(IDataRecord, String)"/>

      public static Object GetValueOrNull(this IDataRecord record, string name) {
         return GetValueOrNull(record, record.GetOrdinal(name));
      }

      /// <summary>
      /// Gets the value of the specified column as an <see cref="Object"/>, or null (Nothing in Visual Basic).
      /// </summary>
      /// <param name="record">The data record.</param>
      /// <param name="i">The zero-based column ordinal.</param>
      /// <returns>The value of the column.</returns>

      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "i", Justification = "Consistent with .NET Framework.")]
      public static Object GetValueOrNull(this IDataRecord record, int i) {
         return (record.IsDBNull(i)) ? null : record.GetValue(i);
      }
   }
}
