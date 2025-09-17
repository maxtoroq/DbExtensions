Extensions.GetStringOrNull(DbDataReader, String) Method
=======================================================
Gets the value of the specified column as a [String][1], or null (Nothing in Visual Basic).
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                      | Description                                                                                 |
| ----------------------------------------- | ------------------------------------------------------------------------------------------- |
| [GetStringOrNull(DbDataReader, Int32)][3] | Gets the value of the specified column as a [String][1], or null (Nothing in Visual Basic). |
| **GetStringOrNull(DbDataReader, String)** | Gets the value of the specified column as a [String][1], or null (Nothing in Visual Basic). |


Syntax
------

```csharp
public static string? GetStringOrNull(
	this DbDataReader reader,
	string name
)
```

#### Parameters

##### *reader*  [DbDataReader][4]
The data reader.

##### *name*  [String][1]
The name of the column to find.

#### Return Value
[String][1]  
The value of the column.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbDataReader][4]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][5] or [Extension Methods (C# Programming Guide)][6].

See Also
--------

#### Reference
[Extensions Class][7]  
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.string
[2]: ../README.md
[3]: GetStringOrNull.md
[4]: https://learn.microsoft.com/dotnet/api/system.data.common.dbdatareader
[5]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[6]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[7]: README.md