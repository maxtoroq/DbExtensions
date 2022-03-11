Database.From Method (SqlBuilder, Type)
=======================================
Creates and returns a new [SqlSet][1] using the provided defining query.

  **Namespace:**  [DbExtensions][2]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet From(
	SqlBuilder definingQuery,
	Type resultType
)
```

#### Parameters

##### *definingQuery*
Type: [DbExtensions.SqlBuilder][3]  
The SQL query that will be the source of data for the set.

##### *resultType*
Type: [System.Type][4]  
The type of objects to map the results to.

#### Return Value
Type: [SqlSet][1]  
A new [SqlSet][1] object.

See Also
--------

#### Reference
[Database Class][5]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet/README.md
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/42892f65
[5]: README.md