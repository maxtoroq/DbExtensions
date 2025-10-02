Database.RemoveKey&lt;TEntity> Method
=====================================
Executes a DELETE command for the entity whose primary key matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public bool RemoveKey<TEntity>(
	Object id
)
where TEntity : class

```

#### Parameters

##### *id*  [Object][2]
The primary key value.

#### Type Parameters

##### *TEntity*


#### Return Value
[Boolean][3]  
`true` if a record that matches *id* was found and deleted; otherwise, `false`.

Remarks
-------
This method is a shortcut for `db.Table<TEntity>().RemoveKey(id)`.

See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][1]  
[SqlTable&lt;TEntity>.RemoveKey(Object)][5]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: https://learn.microsoft.com/dotnet/api/system.boolean
[4]: README.md
[5]: ../SqlTable_1/RemoveKey.md