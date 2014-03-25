SqlSet Constructor (SqlBuilder, Type, DbConnection, TextWriter)
===============================================================
Initializes a new instance of the [SqlSet][1] class using the provided defining query, result type, connection and logger.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet(
	SqlBuilder definingQuery,
	Type resultType,
	DbConnection connection,
	TextWriter logger
)
```

### Parameters

#### *definingQuery*
Type: [DbExtensions.SqlBuilder][3]  
The SQL query that will be the source of data for the set.

#### *resultType*
Type: [System.Type][4]  
The type of objects to map the results to.

#### *connection*
Type: [System.Data.Common.DbConnection][5]  
The database connection.

#### *logger*
Type: [System.IO.TextWriter][6]  
A [TextWriter][6] used to log when queries are executed.


See Also
--------
[SqlSet Class][1]  
[DbExtensions Namespace][2]  

[1]: README.md
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/42892f65
[5]: http://msdn.microsoft.com/en-us/library/c790zwhc
[6]: http://msdn.microsoft.com/en-us/library/ywxh2328