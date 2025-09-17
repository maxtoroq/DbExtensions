SqlCommandBuilder&lt;TEntity>.BuildUpdateStatementForEntity(TEntity) Method
===========================================================================
Creates and returns an UPDATE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                | Description                                                       |
| --------------------------------------------------- | ----------------------------------------------------------------- |
| **BuildUpdateStatementForEntity(TEntity)**          | Creates and returns an UPDATE command for the specified *entity*. |
| [BuildUpdateStatementForEntity(TEntity, Object)][2] | Creates and returns an UPDATE command for the specified *entity*. |


Syntax
------

```csharp
public SqlBuilder BuildUpdateStatementForEntity(
	TEntity entity
)
```

#### Parameters

##### *entity*  [TEntity][3]
The entity whose UPDATE command is to be created.

#### Return Value
[SqlBuilder][4]  
The UPDATE command for *entity*.

See Also
--------

#### Reference
[SqlCommandBuilder&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: BuildUpdateStatementForEntity_1.md
[3]: README.md
[4]: ../SqlBuilder/README.md