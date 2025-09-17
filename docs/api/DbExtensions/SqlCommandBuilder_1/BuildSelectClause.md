SqlCommandBuilder&lt;TEntity>.BuildSelectClause Method
======================================================
Creates and returns a SELECT query for the current table that includes the SELECT clause only.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                           | Description                                                                                                                                                   |
| ------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **BuildSelectClause()**        | Creates and returns a SELECT query for the current table that includes the SELECT clause only.                                                                |
| [BuildSelectClause(String)][2] | Creates and returns a SELECT query for the current table that includes the SELECT clause only. All column names are qualified with the provided *tableAlias*. |


Syntax
------

```csharp
public SqlBuilder BuildSelectClause()
```

#### Return Value
[SqlBuilder][3]  
The SELECT query for the current table.

See Also
--------

#### Reference
[SqlCommandBuilder&lt;TEntity> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: BuildSelectClause_1.md
[3]: ../SqlBuilder/README.md
[4]: README.md