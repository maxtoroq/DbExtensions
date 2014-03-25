Extensions.Count Method (DbConnection, SqlBuilder, TextWriter)
==============================================================
Gets the number of results the *query* would return.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static int Count(
	this DbConnection connection,
	SqlBuilder query,
	TextWriter logger
)
```

### Parameters

#### *connection*
Type: [System.Data.Common.DbConnection][2]  
The connection.

#### *query*
Type: [DbExtensions.SqlBuilder][3]  
The query whose count is to be computed.

#### *logger*
Type: [System.IO.TextWriter][4]  
A [TextWriter][4] used to log when the command is executed.

### Return Value
Type: [Int32][5]  
The number of results the *query* would return.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbConnection][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

See Also
--------
[Extensions Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/c790zwhc
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/ywxh2328
[5]: http://msdn.microsoft.com/en-us/library/td2s409d
[6]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[7]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[8]: README.md