SqlSet Constructor (SqlBuilder, Type, DbConnection)
===================================================
Initializes a new instance of the [SqlSet][1] class using the provided defining query, result type and connection.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet(
	SqlBuilder definingQuery,
	Type resultType,
	DbConnection connection
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


See Also
--------
[SqlSet Class][1]  
[DbExtensions Namespace][2]  

[1]: README.md
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/42892f65
[5]: http://msdn.microsoft.com/en-us/library/c790zwhc