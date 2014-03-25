Extensions.Execute Method (DbConnection, String)
================================================
Creates and executes a [DbCommand][1] whose [CommandText][2] property is initialized with the *commandText* parameter.

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static int Execute(
	this DbConnection connection,
	string commandText
)
```

### Parameters

#### *connection*
Type: [System.Data.Common.DbConnection][4]  
The connection to which the command is executed against.

#### *commandText*
Type: [System.String][5]  
The command text.

### Return Value
Type: [Int32][6]  
The number of affected records.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbConnection][4]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][7] or [Extension Methods (C# Programming Guide)][8].

See Also
--------
[Extensions Class][9]  
[DbExtensions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/852d01k6
[2]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[3]: ../README.md
[4]: http://msdn.microsoft.com/en-us/library/c790zwhc
[5]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[6]: http://msdn.microsoft.com/en-us/library/td2s409d
[7]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[8]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[9]: README.md