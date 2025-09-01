SqlCommandBuilder&lt;TEntity>.BuildUpdateStatementForEntity(TEntity, Object) Method
===================================================================================
Creates and returns an UPDATE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                               | Description                                                       |
| ---------------- | -------------------------------------------------- | ----------------------------------------------------------------- |
| ![Public method] | [BuildUpdateStatementForEntity(TEntity)][2]        | Creates and returns an UPDATE command for the specified *entity*. |
| ![Public method] | **BuildUpdateStatementForEntity(TEntity, Object)** | Creates and returns an UPDATE command for the specified *entity*. |


Syntax
------

```csharp
public SqlBuilder BuildUpdateStatementForEntity(
	TEntity entity,
	Object originalId
)
```

#### Parameters

##### *entity*  [TEntity][3]
The entity whose UPDATE command is to be created.

##### *originalId*  [Object][4]
The original primary key value.

#### Return Value
[SqlBuilder][5]  
The UPDATE command for *entity*.

Remarks
-------
This overload is helpful when the entity uses an assigned primary key.

See Also
--------

#### Reference
[SqlCommandBuilder&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: BuildUpdateStatementForEntity.md
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: ../SqlBuilder/README.md
[Public method]: ../../icons/pubmethod.svg "Public method"