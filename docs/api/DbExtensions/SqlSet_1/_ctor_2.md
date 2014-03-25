SqlSet&lt;TResult> Constructor (SqlBuilder, DbConnection, TextWriter)
=====================================================================
Initializes a new instance of the [SqlSet<TResult>][1] class using the provided defining query, connection and logger.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet(
	SqlBuilder definingQuery,
	DbConnection connection,
	TextWriter logger
)
```

### Parameters

#### *definingQuery*
Type: [DbExtensions.SqlBuilder][3]  
The SQL query that will be the source of data for the set.

#### *connection*
Type: [System.Data.Common.DbConnection][4]  
The database connection.

#### *logger*
Type: [System.IO.TextWriter][5]  
A [TextWriter][5] used to log when queries are executed.


See Also
--------
[SqlSet<TResult> Class][1]  
[DbExtensions Namespace][2]  

[1]: README.md
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/c790zwhc
[5]: http://msdn.microsoft.com/en-us/library/ywxh2328