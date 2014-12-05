SqlSet&lt;TResult> Constructor (SqlBuilder, DbConnection)
=========================================================
Initializes a new instance of the [SqlSet&lt;TResult>][1] class using the provided defining query and connection.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet(
	SqlBuilder definingQuery,
	DbConnection connection
)
```

### Parameters

#### *definingQuery*
Type: [DbExtensions.SqlBuilder][3]  
The SQL query that will be the source of data for the set.

#### *connection*
Type: [System.Data.Common.DbConnection][4]  
The database connection.


See Also
--------

### Reference
[SqlSet&lt;TResult> Class][1]  
[DbExtensions Namespace][2]  

[1]: README.md
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/c790zwhc