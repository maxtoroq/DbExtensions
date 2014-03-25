Extensions.Map&lt;TResult> Method (DbConnection, SqlBuilder)
============================================================
Maps the results of the *query* to TResult objects. The query is deferred-executed.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static IEnumerable<TResult> Map<TResult>(
	this DbConnection connection,
	SqlBuilder query
)
```

### Parameters

#### *connection*
Type: [System.Data.Common.DbConnection][2]  
The connection.

#### *query*
Type: [DbExtensions.SqlBuilder][3]  
The query.


Type Parameters
---------------

#### *TResult*
The type of objects to map the results to.

### Return Value
Type: [IEnumerable][4]&lt;**TResult**>  
The results of the query as TResult objects.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbConnection][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][5] or [Extension Methods (C# Programming Guide)][6].

See Also
--------
[Extensions Class][7]  
[DbExtensions Namespace][1]  
[Extensions.Map&lt;TResult>(IDbCommand)][8]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/c790zwhc
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/9eekhta0
[5]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[6]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[7]: README.md
[8]: Map__1_4.md