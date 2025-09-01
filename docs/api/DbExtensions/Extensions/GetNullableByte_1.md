Extensions.GetNullableByte(IDataRecord, String) Method
======================================================
Gets the value of the specified column as a [Nullable&lt;T>][1] of [Byte][2].
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                            | Name                                     | Description                                                                   |
| -------------------------- | ---------------------------------------- | ----------------------------------------------------------------------------- |
| ![Public Extension Method] | [GetNullableByte(IDataRecord, Int32)][4] | Gets the value of the specified column as a [Nullable&lt;T>][1] of [Byte][2]. |
| ![Public Extension Method] | **GetNullableByte(IDataRecord, String)** | Gets the value of the specified column as a [Nullable&lt;T>][1] of [Byte][2]. |


Syntax
------

```csharp
public static byte? GetNullableByte(
	this IDataRecord record,
	string name
)
```

#### Parameters

##### *record*  [IDataRecord][5]
The data record.

##### *name*  [String][6]
The name of the column to find.

#### Return Value
[Nullable][1]&lt;[Byte][2]>  
The value of the column.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDataRecord][5]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][7] or [Extension Methods (C# Programming Guide)][8].

See Also
--------

#### Reference
[Extensions Class][9]  
[DbExtensions Namespace][3]  

[1]: https://learn.microsoft.com/dotnet/api/system.nullable-1
[2]: https://learn.microsoft.com/dotnet/api/system.byte
[3]: ../README.md
[4]: GetNullableByte.md
[5]: https://learn.microsoft.com/dotnet/api/system.data.idatarecord
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[8]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[9]: README.md
[Public Extension Method]: ../../icons/pubextension.svg "Public Extension Method"