Extensions.GetStringOrNull(IDataRecord, String) Method
======================================================
Gets the value of the specified column as a [String][1], or null (Nothing in Visual Basic).
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                            | Name                                     | Description                                                                                 |
| -------------------------- | ---------------------------------------- | ------------------------------------------------------------------------------------------- |
| ![Public Extension Method] | [GetStringOrNull(IDataRecord, Int32)][3] | Gets the value of the specified column as a [String][1], or null (Nothing in Visual Basic). |
| ![Public Extension Method] | **GetStringOrNull(IDataRecord, String)** | Gets the value of the specified column as a [String][1], or null (Nothing in Visual Basic). |


Syntax
------

```csharp
public static string GetStringOrNull(
	this IDataRecord record,
	string name
)
```

#### Parameters

##### *record*  [IDataRecord][4]
The data record.

##### *name*  [String][1]
The name of the column to find.

#### Return Value
[String][1]  
The value of the column.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDataRecord][4]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][5] or [Extension Methods (C# Programming Guide)][6].

See Also
--------

#### Reference
[Extensions Class][7]  
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.string
[2]: ../README.md
[3]: GetStringOrNull.md
[4]: https://learn.microsoft.com/dotnet/api/system.data.idatarecord
[5]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[6]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[7]: README.md
[Public Extension Method]: ../../icons/pubextension.svg "Public Extension Method"