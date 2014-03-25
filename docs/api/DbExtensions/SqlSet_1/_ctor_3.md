SqlSet&lt;TResult> Constructor (SqlBuilder, Func&lt;IDataRecord, TResult>)
==========================================================================
Initializes a new instance of the [SqlSet&lt;TResult>][1] class using the provided defining query and mapper.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet(
	SqlBuilder definingQuery,
	Func<IDataRecord, TResult> mapper
)
```

### Parameters

#### *definingQuery*
Type: [DbExtensions.SqlBuilder][3]  
The SQL query that will be the source of data for the set.

#### *mapper*
Type: [System.Func][4]&lt;[IDataRecord][5], [TResult][1]>  
A custom mapper function that creates TResult instances from the rows in the set.


See Also
--------
[SqlSet&lt;TResult> Class][1]  
[DbExtensions Namespace][2]  

[1]: README.md
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/bb549151
[5]: http://msdn.microsoft.com/en-us/library/93wb1heh