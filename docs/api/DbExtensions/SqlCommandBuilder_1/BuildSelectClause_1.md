SqlCommandBuilder&lt;TEntity>.BuildSelectClause(String) Method
==============================================================
Creates and returns a SELECT query for the current table that includes the SELECT clause only. All column names are qualified with the provided *tableAlias*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                          | Description                                                                                                                                                   |
| ----------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [BuildSelectClause()][2]      | Creates and returns a SELECT query for the current table that includes the SELECT clause only.                                                                |
| **BuildSelectClause(String)** | Creates and returns a SELECT query for the current table that includes the SELECT clause only. All column names are qualified with the provided *tableAlias*. |


Syntax
------

```csharp
public SqlBuilder BuildSelectClause(
	string? tableAlias
)
```

#### Parameters

##### *tableAlias*  [String][3]
The table alias.

#### Return Value
[SqlBuilder][4]  
The SELECT query for the current table.

See Also
--------

#### Reference
[SqlCommandBuilder&lt;TEntity> Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: BuildSelectClause.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: ../SqlBuilder/README.md
[5]: README.md