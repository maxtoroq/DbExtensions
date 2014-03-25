Database.Set Method (SqlBuilder)
================================
Creates and returns a new [SqlSet][1] using the provided defining query.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
[ObsoleteAttribute("Please use From(SqlBuilder) instead.")]
public SqlSet Set(
	SqlBuilder definingQuery
)
```

### Parameters

#### *definingQuery*
Type: [DbExtensions.SqlBuilder][3]  
The SQL query that will be the source of data for the set.

### Return Value
Type: [SqlSet][1]  
A new [SqlSet][1] object.

See Also
--------
[Database Class][4]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet/README.md
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: README.md