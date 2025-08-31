SqlCommandBuilder&lt;TEntity>.BuildUpdateStatementForEntity(TEntity, Object) Method
===================================================================================
Creates and returns an UPDATE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder BuildUpdateStatementForEntity(
	TEntity entity,
	Object originalId
)
```

#### Parameters

##### *entity*  [TEntity][2]
The entity whose UPDATE command is to be created.

##### *originalId*  [Object][3]
The original primary key value.

#### Return Value
[SqlBuilder][4]  
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
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: ../SqlBuilder/README.md