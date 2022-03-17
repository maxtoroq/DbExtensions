SqlCommandBuilder&lt;TEntity>.BuildSelectClause Method (String)
===============================================================
Creates and returns a SELECT query for the current table that includes the SELECT clause only. All column names are qualified with the provided *tableAlias*.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder BuildSelectClause(
	string tableAlias
)
```

#### Parameters

##### *tableAlias*
Type: [System.String][2]  
The table alias.

#### Return Value
Type: [SqlBuilder][3]  
The SELECT query for the current table.

See Also
--------

#### Reference
[SqlCommandBuilder&lt;TEntity> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: ../SqlBuilder/README.md
[4]: README.md