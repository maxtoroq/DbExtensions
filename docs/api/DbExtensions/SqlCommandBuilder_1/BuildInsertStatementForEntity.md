SqlCommandBuilder&lt;TEntity>.BuildInsertStatementForEntity Method
==================================================================
Creates and returns an INSERT command for the specified *entity*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder BuildInsertStatementForEntity(
	TEntity entity
)
```

#### Parameters

##### *entity*
Type: [TEntity][2]  
 The object whose INSERT command is to be created. This parameter is named entity for consistency with the other CRUD methods, but in this case it doesn't need to be an actual entity, which means it doesn't need to have a primary key.

#### Return Value
Type: [SqlBuilder][3]  
The INSERT command for *entity*.

See Also
--------

#### Reference
[SqlCommandBuilder&lt;TEntity> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: ../SqlBuilder/README.md