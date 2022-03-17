Extensions.GetStringOrNull Method (IDataRecord, String)
=======================================================
Gets the value of the specified column as a [String][1], or null (Nothing in Visual Basic).

  **Namespace:**  [DbExtensions][2]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static string GetStringOrNull(
	this IDataRecord record,
	string name
)
```

#### Parameters

##### *record*
Type: [System.Data.IDataRecord][3]  
The data record.

##### *name*
Type: [System.String][1]  
The name of the column to find.

#### Return Value
Type: [String][1]  
The value of the column.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDataRecord][3]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][4] or [Extension Methods (C# Programming Guide)][5].

See Also
--------

#### Reference
[Extensions Class][6]  
[DbExtensions Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.string
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/system.data.idatarecord
[4]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[5]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[6]: README.md