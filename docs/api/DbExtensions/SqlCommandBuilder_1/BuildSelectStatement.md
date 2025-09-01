SqlCommandBuilder&lt;TEntity>.BuildSelectStatement Method
=========================================================
Creates and returns a SELECT query for the current table that includes the SELECT and FROM clauses.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                              | Description                                                                                                                                                        |
| ---------------- | --------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | **BuildSelectStatement()**        | Creates and returns a SELECT query for the current table that includes the SELECT and FROM clauses.                                                                |
| ![Public method] | [BuildSelectStatement(String)][2] | Creates and returns a SELECT query for the current table that includes the SELECT and FROM clauses. All column names are qualified with the provided *tableAlias*. |


Syntax
------

```csharp
public SqlBuilder BuildSelectStatement()
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
[2]: BuildSelectStatement_1.md
[3]: ../SqlBuilder/README.md
[4]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"