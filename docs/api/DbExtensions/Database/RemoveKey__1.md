Database.RemoveKey&lt;TEntity> Method (Object)
==============================================
Executes a DELETE command for the entity whose primary key matches the *id* parameter.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public void RemoveKey<TEntity>(
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



Remarks
-------
This method is a shortcut for `db.Table<TEntity>().RemoveKey(id)`.

See Also
--------

#### Reference
[Database Class][3]  
[DbExtensions Namespace][1]  
[SqlTable&lt;TEntity>.RemoveKey(Object)][4]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: README.md
[4]: ../SqlTable_1/RemoveKey.md