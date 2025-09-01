Extensions.GetValueOrNull(IDataRecord, Int32) Method
====================================================
Gets the value of the specified column as an [Object][1], or null (Nothing in Visual Basic).
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                            | Name                                     | Description                                                                                  |
| -------------------------- | ---------------------------------------- | -------------------------------------------------------------------------------------------- |
| ![Public Extension Method] | **GetValueOrNull(IDataRecord, Int32)**   | Gets the value of the specified column as an [Object][1], or null (Nothing in Visual Basic). |
| ![Public Extension Method] | [GetValueOrNull(IDataRecord, String)][3] | Gets the value of the specified column as an [Object][1], or null (Nothing in Visual Basic). |


Syntax
------

```csharp
public static Object GetValueOrNull(
	this IDataRecord record,
	int i
)
```

#### Parameters

##### *record*  [IDataRecord][4]
The data record.

##### *i*  [Int32][5]
The zero-based column ordinal.

#### Return Value
[Object][1]  
The value of the column.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDataRecord][4]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

See Also
--------

#### Reference
[Extensions Class][8]  
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: GetValueOrNull_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.data.idatarecord
[5]: https://learn.microsoft.com/dotnet/api/system.int32
[6]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[7]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[8]: README.md
[Public Extension Method]: ../../icons/pubextension.svg "Public Extension Method"