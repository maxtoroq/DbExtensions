SqlSet&lt;TResult> Constructor (SqlBuilder, Func&lt;IDataRecord, TResult>, DbConnection)
========================================================================================
Initializes a new instance of the [SqlSet<TResult>][1] class using the provided defining query, mapper and connection.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet(
	SqlBuilder definingQuery,
	Func<IDataRecord, TResult> mapper,
	DbConnection connection
)
```

### Parameters

#### *definingQuery*
Type: [DbExtensions.SqlBuilder][3]  
The SQL query that will be the source of data for the set.

#### *mapper*
Type: [System.Func][4]&lt;[IDataRecord][5], [TResult][1]>  
A custom mapper function that creates TResult instances from the rows in the set.

#### *connection*
Type: [System.Data.Common.DbConnection][6]  
The database connection.


See Also
--------
[SqlSet<TResult> Class][1]  
[DbExtensions Namespace][2]  

[1]: README.md
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/bb549151
[5]: http://msdn.microsoft.com/en-us/library/93wb1heh
[6]: http://msdn.microsoft.com/en-us/library/c790zwhc