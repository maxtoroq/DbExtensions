Extensions.GetNullableInt32(IDataRecord, Int32) Method
======================================================
Gets the value of the specified column as a [Nullable&lt;T>][1] of [Int32][2].
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static int? GetNullableInt32(
	this IDataRecord record,
	int i
)
```

#### Parameters

##### *record*  [IDataRecord][4]
The data record.

##### *i*  [Int32][2]
The zero-based column ordinal.

#### Return Value
[Nullable][1]&lt;[Int32][2]>  
The value of the column.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDataRecord][4]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][5] or [Extension Methods (C# Programming Guide)][6].

See Also
--------

#### Reference
[Extensions Class][7]  
[DbExtensions Namespace][3]  

[1]: https://learn.microsoft.com/dotnet/api/system.nullable-1
[2]: https://learn.microsoft.com/dotnet/api/system.int32
[3]: ../README.md
[4]: https://learn.microsoft.com/dotnet/api/system.data.idatarecord
[5]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[6]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[7]: README.md