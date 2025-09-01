Extensions.GetNullableInt32(IDataRecord, Int32) Method
======================================================
Gets the value of the specified column as a [Nullable&lt;T>][1] of [Int32][2].
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                            | Name                                       | Description                                                                    |
| -------------------------- | ------------------------------------------ | ------------------------------------------------------------------------------ |
| ![Public Extension Method] | **GetNullableInt32(IDataRecord, Int32)**   | Gets the value of the specified column as a [Nullable&lt;T>][1] of [Int32][2]. |
| ![Public Extension Method] | [GetNullableInt32(IDataRecord, String)][4] | Gets the value of the specified column as a [Nullable&lt;T>][1] of [Int32][2]. |


Syntax
------

```csharp
public static int? GetNullableInt32(
	this IDataRecord record,
	int i
)
```

#### Parameters

##### *record*  [IDataRecord][5]
The data record.

##### *i*  [Int32][2]
The zero-based column ordinal.

#### Return Value
[Nullable][1]&lt;[Int32][2]>  
The value of the column.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDataRecord][5]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

See Also
--------

#### Reference
[Extensions Class][8]  
[DbExtensions Namespace][3]  

[1]: https://learn.microsoft.com/dotnet/api/system.nullable-1
[2]: https://learn.microsoft.com/dotnet/api/system.int32
[3]: ../README.md
[4]: GetNullableInt32_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.data.idatarecord
[6]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[7]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[8]: README.md
[Public Extension Method]: ../../icons/pubextension.svg "Public Extension Method"