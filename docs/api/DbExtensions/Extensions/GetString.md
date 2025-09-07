Extensions.GetString Method
===========================
Gets the value of the specified column as a [String][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static string GetString(
	this DbDataReader reader,
	string name
)
```

#### Parameters

##### *reader*  [DbDataReader][3]
The data reader.

##### *name*  [String][1]
The name of the column to find.

#### Return Value
[String][1]  
The value of the column.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbDataReader][3]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][4] or [Extension Methods (C# Programming Guide)][5].

See Also
--------

#### Reference
[Extensions Class][6]  
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.string
[2]: ../README.md
[3]: https://learn.microsoft.com/dotnet/api/system.data.common.dbdatareader
[4]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[5]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[6]: README.md