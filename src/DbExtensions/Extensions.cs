// Copyright 2009-2025 Max Toro Q.
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
using System.Data.Common;

namespace DbExtensions;

#nullable enable

/// <summary>
/// Provides extension methods for common ADO.NET objects.
/// </summary>

public static class Extensions {

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Boolean"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Boolean
   GetBoolean(this DbDataReader reader, string name) =>
      reader.GetBoolean(reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Byte"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Byte
   GetByte(this DbDataReader reader, string name) =>
      reader.GetByte(reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Char"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Char
   GetChar(this DbDataReader reader, string name) =>
      reader.GetChar(reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="DateTime"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static DateTime
   GetDateTime(this DbDataReader reader, string name) =>
      reader.GetDateTime(reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Decimal"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Decimal
   GetDecimal(this DbDataReader reader, string name) =>
      reader.GetDecimal(reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Double"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Double
   GetDouble(this DbDataReader reader, string name) =>
      reader.GetDouble(reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Single"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Single
   GetFloat(this DbDataReader reader, string name) =>
      reader.GetFloat(reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as an <see cref="Int16"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Int16
   GetInt16(this DbDataReader reader, string name) =>
      reader.GetInt16(reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as an <see cref="Int32"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Int32
   GetInt32(this DbDataReader reader, string name) =>
      reader.GetInt32(reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as an <see cref="Int64"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Int64
   GetInt64(this DbDataReader reader, string name) =>
      reader.GetInt64(reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="String"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static String
   GetString(this DbDataReader reader, string name) =>
      reader.GetString(reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column.
   /// </summary>
   /// <param name="reader">The data reader.</param>
   /// <param name="name">The name of the column to find.</param>
   /// <returns>The value of the column.</returns>

   public static Object
   GetValue(this DbDataReader reader, string name) =>
      reader.GetValue(reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Boolean&gt;"/> of <see cref="Boolean"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Boolean?
   GetNullableBoolean(this DbDataReader reader, string name) =>
      GetNullableBoolean(reader, reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Boolean&gt;"/> of <see cref="Boolean"/>.
   /// </summary>
   /// <inheritdoc cref="GetValueOrNull(DbDataReader, Int32)"/>

   public static Boolean?
   GetNullableBoolean(this DbDataReader reader, int i) =>
      (reader.IsDBNull(i)) ? default(Boolean?) : reader.GetBoolean(i);

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Byte&gt;"/> of <see cref="Byte"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Byte?
   GetNullableByte(this DbDataReader reader, string name) =>
      GetNullableByte(reader, reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Byte&gt;"/> of <see cref="Byte"/>.
   /// </summary>
   /// <inheritdoc cref="GetValueOrNull(DbDataReader, Int32)"/>

   public static Byte?
   GetNullableByte(this DbDataReader reader, int i) =>
      (reader.IsDBNull(i)) ? default(Byte?) : reader.GetByte(i);

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Char&gt;"/> of <see cref="Char"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Char?
   GetNullableChar(this DbDataReader reader, string name) =>
      GetNullableChar(reader, reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Char&gt;"/> of <see cref="Char"/>.
   /// </summary>
   /// <inheritdoc cref="GetValueOrNull(DbDataReader, Int32)"/>

   public static Char?
   GetNullableChar(this DbDataReader reader, int i) =>
      (reader.IsDBNull(i)) ? default(Char?) : reader.GetChar(i);

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;DateTime&gt;"/> of <see cref="DateTime"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static DateTime?
   GetNullableDateTime(this DbDataReader reader, string name) =>
      GetNullableDateTime(reader, reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;DateTime&gt;"/> of <see cref="DateTime"/>.
   /// </summary>
   /// <inheritdoc cref="GetValueOrNull(DbDataReader, Int32)"/>

   public static DateTime?
   GetNullableDateTime(this DbDataReader reader, int i) =>
      (reader.IsDBNull(i)) ? default(DateTime?) : reader.GetDateTime(i);

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Decimal&gt;"/> of <see cref="Decimal"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Decimal?
   GetNullableDecimal(this DbDataReader reader, string name) =>
      GetNullableDecimal(reader, reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Decimal&gt;"/> of <see cref="Decimal"/>.
   /// </summary>
   /// <inheritdoc cref="GetValueOrNull(DbDataReader, Int32)"/>

   public static Decimal?
   GetNullableDecimal(this DbDataReader reader, int i) =>
      (reader.IsDBNull(i)) ? default(Decimal?) : reader.GetDecimal(i);

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Double&gt;"/> of <see cref="Double"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Double?
   GetNullableDouble(this DbDataReader reader, string name) =>
      GetNullableDouble(reader, reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Double&gt;"/> of <see cref="Double"/>.
   /// </summary>
   /// <inheritdoc cref="GetValueOrNull(DbDataReader, Int32)"/>

   public static Double?
   GetNullableDouble(this DbDataReader reader, int i) =>
      (reader.IsDBNull(i)) ? default(Double?) : reader.GetDouble(i);

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Single&gt;"/> of <see cref="Single"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Single?
   GetNullableFloat(this DbDataReader reader, string name) =>
      GetNullableFloat(reader, reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Single&gt;"/> of <see cref="Single"/>.
   /// </summary>
   /// <inheritdoc cref="GetValueOrNull(DbDataReader, Int32)"/>

   public static Single?
   GetNullableFloat(this DbDataReader reader, int i) =>
      (reader.IsDBNull(i)) ? default(Single?) : reader.GetFloat(i);

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Guid&gt;"/> of <see cref="Guid"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Guid?
   GetNullableGuid(this DbDataReader reader, string name) =>
      GetNullableGuid(reader, reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Guid&gt;"/> of <see cref="Guid"/>.
   /// </summary>
   /// <inheritdoc cref="GetValueOrNull(DbDataReader, Int32)"/>

   public static Guid?
   GetNullableGuid(this DbDataReader reader, int i) =>
      (reader.IsDBNull(i)) ? default(Guid?) : reader.GetGuid(i);

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Int16&gt;"/> of <see cref="Int16"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Int16?
   GetNullableInt16(this DbDataReader reader, string name) =>
      GetNullableInt16(reader, reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Int16&gt;"/> of <see cref="Int16"/>.
   /// </summary>
   /// <inheritdoc cref="GetValueOrNull(DbDataReader, Int32)"/>

   public static Int16?
   GetNullableInt16(this DbDataReader reader, int i) =>
      (reader.IsDBNull(i)) ? default(Int16?) : reader.GetInt16(i);

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Int32&gt;"/> of <see cref="Int32"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Int32?
   GetNullableInt32(this DbDataReader reader, string name) =>
      GetNullableInt32(reader, reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Int32&gt;"/> of <see cref="Int32"/>.
   /// </summary>
   /// <inheritdoc cref="GetValueOrNull(DbDataReader, Int32)"/>

   public static Int32?
   GetNullableInt32(this DbDataReader reader, int i) =>
      (reader.IsDBNull(i)) ? default(Int32?) : reader.GetInt32(i);

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Int64&gt;"/> of <see cref="Int64"/>.
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Int64?
   GetNullableInt64(this DbDataReader reader, string name) =>
      GetNullableInt64(reader, reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="Nullable&lt;Int64&gt;"/> of <see cref="Int64"/>.
   /// </summary>
   /// <inheritdoc cref="GetValueOrNull(DbDataReader, Int32)"/>

   public static Int64?
   GetNullableInt64(this DbDataReader reader, int i) =>
      (reader.IsDBNull(i)) ? default(Int64?) : reader.GetInt64(i);

   /// <summary>
   /// Gets the value of the specified column as a <see cref="String"/>, or null (Nothing in Visual Basic).
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static String?
   GetStringOrNull(this DbDataReader reader, string name) =>
      GetStringOrNull(reader, reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as a <see cref="String"/>, or null (Nothing in Visual Basic).
   /// </summary>
   /// <inheritdoc cref="GetValueOrNull(DbDataReader, Int32)"/>

   public static String?
   GetStringOrNull(this DbDataReader reader, int i) =>
      (reader.IsDBNull(i)) ? default(String) : reader.GetString(i);

   /// <summary>
   /// Gets the value of the specified column as an <see cref="Object"/>, or null (Nothing in Visual Basic).
   /// </summary>
   /// <inheritdoc cref="GetValue(DbDataReader, String)"/>

   public static Object?
   GetValueOrNull(this DbDataReader reader, string name) =>
      GetValueOrNull(reader, reader.GetOrdinal(name));

   /// <summary>
   /// Gets the value of the specified column as an <see cref="Object"/>, or null (Nothing in Visual Basic).
   /// </summary>
   /// <param name="reader">The data reader.</param>
   /// <param name="i">The zero-based column ordinal.</param>
   /// <returns>The value of the column.</returns>

   public static Object?
   GetValueOrNull(this DbDataReader reader, int i) =>
      (reader.IsDBNull(i)) ? null : reader.GetValue(i);
}
