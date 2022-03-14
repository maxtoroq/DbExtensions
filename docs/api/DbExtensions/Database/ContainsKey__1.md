Database.ContainsKey&lt;TEntity> Method (Object)
================================================
Checks the existance of an entity whose primary matches the *id* parameter.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public bool ContainsKey<TEntity>(
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
Type: [Boolean][3]  
true if the primary key value exists in the database; otherwise false.

Remarks
-------
This method is a shortcut for `db.Table<TEntity>().ContainsKey(id)`.

See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][1]  
[SqlSet.ContainsKey(Object)][5]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: https://docs.microsoft.com/dotnet/api/system.boolean
[4]: README.md
[5]: ../SqlSet/ContainsKey.md