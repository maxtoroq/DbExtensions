Extensions.GetNullableInt64(DbDataReader, Int32) Method
=======================================================
Gets the value of the specified column as a [Nullable&lt;T>][1] of [Int64][2].
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                        | Description                                                                    |
| ------------------------------------------- | ------------------------------------------------------------------------------ |
| **GetNullableInt64(DbDataReader, Int32)**   | Gets the value of the specified column as a [Nullable&lt;T>][1] of [Int64][2]. |
| [GetNullableInt64(DbDataReader, String)][4] | Gets the value of the specified column as a [Nullable&lt;T>][1] of [Int64][2]. |


Syntax
------

```csharp
public static long? GetNullableInt64(
	this DbDataReader reader,
	int i
)
```

#### Parameters

##### *reader*  [DbDataReader][5]
The data reader.

##### *i*  [Int32][6]
The zero-based column ordinal.

#### Return Value
[Nullable][1]&lt;[Int64][2]>  
The value of the column.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbDataReader][5]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][7] or [Extension Methods (C# Programming Guide)][8].

See Also
--------

#### Reference
[Extensions Class][9]  
[DbExtensions Namespace][3]  

[1]: https://learn.microsoft.com/dotnet/api/system.nullable-1
[2]: https://learn.microsoft.com/dotnet/api/system.int64
[3]: ../README.md
[4]: GetNullableInt64_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.data.common.dbdatareader
[6]: https://learn.microsoft.com/dotnet/api/system.int32
[7]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[8]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[9]: README.md