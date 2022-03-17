Database.Find&lt;TEntity> Method (Object)
=========================================
Gets the entity whose primary key matches the *id* parameter.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public TEntity Find<TEntity>(
	Object id
)
where TEntity : class

```

#### Parameters

##### *id*
Type: [System.Object][2]  
The primary key value.

#### Type Parameters

##### *TEntity*
The type of the entity.

#### Return Value
Type: **TEntity**  
 The entity whose primary key matches the *id* parameter, or null if the *id* does not exist. 

Remarks
-------
This method is a shortcut for `db.Table<TEntity>().Find(id)`.

See Also
--------

#### Reference
[Database Class][3]  
[DbExtensions Namespace][1]  
[SqlSet&lt;TResult>.Find(Object)][4]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: README.md
[4]: ../SqlSet_1/Find.md