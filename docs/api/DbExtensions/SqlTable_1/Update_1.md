SqlTable&lt;TEntity>.Update(TEntity, Object) Method
===================================================
Executes an UPDATE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                        | Description                                            |
| ---------------- | --------------------------- | ------------------------------------------------------ |
| ![Public method] | [Update(TEntity)][2]        | Executes an UPDATE command for the specified *entity*. |
| ![Public method] | **Update(TEntity, Object)** | Executes an UPDATE command for the specified *entity*. |


Syntax
------

```csharp
public void Update(
	TEntity entity,
	Object originalId
)
```

#### Parameters

##### *entity*  [TEntity][3]
The entity whose UPDATE command is to be executed.

##### *originalId*  [Object][4]
The original primary key value.


Remarks
-------
This overload is helpful when the entity uses an assigned primary key.

See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Update.md
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.object
[Public method]: ../../icons/pubmethod.svg "Public method"