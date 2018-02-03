SqlCommandBuilder&lt;TEntity>.BuildUpdateStatementForEntity Method (TEntity, Object)
====================================================================================
Creates and returns an UPDATE command for the specified *entity*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder BuildUpdateStatementForEntity(
	TEntity entity,
	Object originalId
)
```

#### Parameters

##### *entity*
Type: [TEntity][2]  
The entity whose UPDATE command is to be created.

##### *originalId*
Type: [System.Object][3]  
The original primary key value.

#### Return Value
Type: [SqlBuilder][4]  
The UPDATE command for *entity*.

Remarks
-------
This overload is helpful when the entity uses an assigned primary key.

See Also
--------

#### Reference
[SqlCommandBuilder&lt;TEntity> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../SqlBuilder/README.md