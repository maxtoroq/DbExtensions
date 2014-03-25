Extensions.Map Method (DbConnection, Type, SqlBuilder, TextWriter)
==================================================================
Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static IEnumerable<Object> Map(
	this DbConnection connection,
	Type resultType,
	SqlBuilder query,
	TextWriter logger
)
```

### Parameters

#### *connection*
Type: [System.Data.Common.DbConnection][2]  
The connection.

#### *resultType*
Type: [System.Type][3]  
The type of objects to map the results to.

#### *query*
Type: [DbExtensions.SqlBuilder][4]  
The query.

#### *logger*
Type: [System.IO.TextWriter][5]  
A [TextWriter][5] used to log when the command is executed.

### Return Value
Type: [IEnumerable][6]&lt;[Object][7]>  
The results of the query as objects of type specified by the *resultType* parameter.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbConnection][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][8] or [Extension Methods (C# Programming Guide)][9].

See Also
--------
[Extensions Class][10]  
[DbExtensions Namespace][1]  
[Extensions.Map(IDbCommand, Type, TextWriter)][11]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/c790zwhc
[3]: http://msdn.microsoft.com/en-us/library/42892f65
[4]: ../SqlBuilder/README.md
[5]: http://msdn.microsoft.com/en-us/library/ywxh2328
[6]: http://msdn.microsoft.com/en-us/library/9eekhta0
[7]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[8]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[9]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[10]: README.md
[11]: Map_7.md