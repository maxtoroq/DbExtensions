SqlTable&lt;TEntity>.Update(TEntity, Object) Method
===================================================
Executes an UPDATE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public void Update(
	TEntity entity,
	Object originalId
)
```

#### Parameters

##### *entity*  [TEntity][2]
The entity whose UPDATE command is to be executed.

##### *originalId*  [Object][3]
The original primary key value.


Remarks
-------
This overload is helpful when the entity uses an assigned primary key.

See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: https://learn.microsoft.com/dotnet/api/system.object