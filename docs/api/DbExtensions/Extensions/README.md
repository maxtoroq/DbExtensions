Extensions Class
================
Provides extension methods for common ADO.NET objects.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **DbExtensions.Extensions**  
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static class Extensions
```

The **Extensions** type exposes the following members.


Methods
-------

| Name                                            | Description                                                                                  |
| ----------------------------------------------- | -------------------------------------------------------------------------------------------- |
| [GetBoolean][3]                                 | Gets the value of the specified column as a [Boolean][4].                                    |
| [GetByte][5]                                    | Gets the value of the specified column as a [Byte][6].                                       |
| [GetChar][7]                                    | Gets the value of the specified column as a [Char][8].                                       |
| [GetDateTime][9]                                | Gets the value of the specified column as a [DateTime][10].                                  |
| [GetDecimal][11]                                | Gets the value of the specified column as a [Decimal][12].                                   |
| [GetDouble][13]                                 | Gets the value of the specified column as a [Double][14].                                    |
| [GetFloat][15]                                  | Gets the value of the specified column as a [Single][16].                                    |
| [GetInt16][17]                                  | Gets the value of the specified column as an [Int16][18].                                    |
| [GetInt32][19]                                  | Gets the value of the specified column as an [Int32][20].                                    |
| [GetInt64][21]                                  | Gets the value of the specified column as an [Int64][22].                                    |
| [GetNullableBoolean(DbDataReader, Int32)][23]   | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Boolean][4].            |
| [GetNullableBoolean(DbDataReader, String)][25]  | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Boolean][4].            |
| [GetNullableByte(DbDataReader, Int32)][26]      | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Byte][6].               |
| [GetNullableByte(DbDataReader, String)][27]     | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Byte][6].               |
| [GetNullableChar(DbDataReader, Int32)][28]      | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Char][8].               |
| [GetNullableChar(DbDataReader, String)][29]     | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Char][8].               |
| [GetNullableDateTime(DbDataReader, Int32)][30]  | Gets the value of the specified column as a [Nullable&lt;T>][24] of [DateTime][10].          |
| [GetNullableDateTime(DbDataReader, String)][31] | Gets the value of the specified column as a [Nullable&lt;T>][24] of [DateTime][10].          |
| [GetNullableDecimal(DbDataReader, Int32)][32]   | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Decimal][12].           |
| [GetNullableDecimal(DbDataReader, String)][33]  | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Decimal][12].           |
| [GetNullableDouble(DbDataReader, Int32)][34]    | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Double][14].            |
| [GetNullableDouble(DbDataReader, String)][35]   | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Double][14].            |
| [GetNullableFloat(DbDataReader, Int32)][36]     | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Single][16].            |
| [GetNullableFloat(DbDataReader, String)][37]    | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Single][16].            |
| [GetNullableGuid(DbDataReader, Int32)][38]      | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Guid][39].              |
| [GetNullableGuid(DbDataReader, String)][40]     | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Guid][39].              |
| [GetNullableInt16(DbDataReader, Int32)][41]     | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Int16][18].             |
| [GetNullableInt16(DbDataReader, String)][42]    | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Int16][18].             |
| [GetNullableInt32(DbDataReader, Int32)][43]     | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Int32][20].             |
| [GetNullableInt32(DbDataReader, String)][44]    | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Int32][20].             |
| [GetNullableInt64(DbDataReader, Int32)][45]     | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Int64][22].             |
| [GetNullableInt64(DbDataReader, String)][46]    | Gets the value of the specified column as a [Nullable&lt;T>][24] of [Int64][22].             |
| [GetString][47]                                 | Gets the value of the specified column as a [String][48].                                    |
| [GetStringOrNull(DbDataReader, Int32)][49]      | Gets the value of the specified column as a [String][48], or null (Nothing in Visual Basic). |
| [GetStringOrNull(DbDataReader, String)][50]     | Gets the value of the specified column as a [String][48], or null (Nothing in Visual Basic). |
| [GetValue][51]                                  | Gets the value of the specified column.                                                      |
| [GetValueOrNull(DbDataReader, Int32)][52]       | Gets the value of the specified column as an [Object][1], or null (Nothing in Visual Basic). |
| [GetValueOrNull(DbDataReader, String)][53]      | Gets the value of the specified column as an [Object][1], or null (Nothing in Visual Basic). |


See Also
--------

#### Reference
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: GetBoolean.md
[4]: https://learn.microsoft.com/dotnet/api/system.boolean
[5]: GetByte.md
[6]: https://learn.microsoft.com/dotnet/api/system.byte
[7]: GetChar.md
[8]: https://learn.microsoft.com/dotnet/api/system.char
[9]: GetDateTime.md
[10]: https://learn.microsoft.com/dotnet/api/system.datetime
[11]: GetDecimal.md
[12]: https://learn.microsoft.com/dotnet/api/system.decimal
[13]: GetDouble.md
[14]: https://learn.microsoft.com/dotnet/api/system.double
[15]: GetFloat.md
[16]: https://learn.microsoft.com/dotnet/api/system.single
[17]: GetInt16.md
[18]: https://learn.microsoft.com/dotnet/api/system.int16
[19]: GetInt32.md
[20]: https://learn.microsoft.com/dotnet/api/system.int32
[21]: GetInt64.md
[22]: https://learn.microsoft.com/dotnet/api/system.int64
[23]: GetNullableBoolean.md
[24]: https://learn.microsoft.com/dotnet/api/system.nullable-1
[25]: GetNullableBoolean_1.md
[26]: GetNullableByte.md
[27]: GetNullableByte_1.md
[28]: GetNullableChar.md
[29]: GetNullableChar_1.md
[30]: GetNullableDateTime.md
[31]: GetNullableDateTime_1.md
[32]: GetNullableDecimal.md
[33]: GetNullableDecimal_1.md
[34]: GetNullableDouble.md
[35]: GetNullableDouble_1.md
[36]: GetNullableFloat.md
[37]: GetNullableFloat_1.md
[38]: GetNullableGuid.md
[39]: https://learn.microsoft.com/dotnet/api/system.guid
[40]: GetNullableGuid_1.md
[41]: GetNullableInt16.md
[42]: GetNullableInt16_1.md
[43]: GetNullableInt32.md
[44]: GetNullableInt32_1.md
[45]: GetNullableInt64.md
[46]: GetNullableInt64_1.md
[47]: GetString.md
[48]: https://learn.microsoft.com/dotnet/api/system.string
[49]: GetStringOrNull.md
[50]: GetStringOrNull_1.md
[51]: GetValue.md
[52]: GetValueOrNull.md
[53]: GetValueOrNull_1.md