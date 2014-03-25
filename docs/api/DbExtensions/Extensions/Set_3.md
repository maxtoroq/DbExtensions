Extensions.Set Method (DbConnection, SqlBuilder, Type, TextWriter)
==================================================================
Creates and returns a new [SqlSet][1] using the provided defining query, result type and logger.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
[ObsoleteAttribute("Please use From(SqlBuilder, Type, TextWriter) instead.")]
public static SqlSet Set(
	this DbConnection connection,
	SqlBuilder definingQuery,
	Type resultType,
	TextWriter logger
)
```

### Parameters

#### *connection*
Type: [System.Data.Common.DbConnection][3]  
The connection that the set is bound to.

#### *definingQuery*
Type: [DbExtensions.SqlBuilder][4]  
The SQL query that will be the source of data for the set.

#### *resultType*
Type: [System.Type][5]  
The type of objects to map the results to.

#### *logger*
Type: [System.IO.TextWriter][6]  
A [TextWriter][6] used to log when queries are executed.

### Return Value
Type: [SqlSet][1]  
A new [SqlSet][1] object.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbConnection][3]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][7] or [Extension Methods (C# Programming Guide)][8].

See Also
--------
[Extensions Class][9]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet/README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/c790zwhc
[4]: ../SqlBuilder/README.md
[5]: http://msdn.microsoft.com/en-us/library/42892f65
[6]: http://msdn.microsoft.com/en-us/library/ywxh2328
[7]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[8]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[9]: README.md