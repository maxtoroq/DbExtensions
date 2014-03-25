Extensions.From Method (DbConnection, String, TextWriter)
=========================================================
Creates and returns a new [SqlSet][1] using the provided table name.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static SqlSet From(
	this DbConnection connection,
	string tableName,
	TextWriter logger
)
```

### Parameters

#### *connection*
Type: [System.Data.Common.DbConnection][3]  
The connection that the set is bound to.

#### *tableName*
Type: [System.String][4]  
The name of the table that will be the source of data for the set.

#### *logger*
Type: [System.IO.TextWriter][5]  
A [TextWriter][5] used to log when queries are executed.

### Return Value
Type: [SqlSet][1]  
A new [SqlSet][1] object.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbConnection][3]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

See Also
--------
[Extensions Class][8]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet/README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/c790zwhc
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: http://msdn.microsoft.com/en-us/library/ywxh2328
[6]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[7]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[8]: README.md