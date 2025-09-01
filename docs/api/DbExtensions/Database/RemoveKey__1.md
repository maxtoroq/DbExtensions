Database.RemoveKey&lt;TEntity>(Object) Method
=============================================
Executes a DELETE command for the entity whose primary key matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                              | Description                                                                            |
| ---------------- | --------------------------------- | -------------------------------------------------------------------------------------- |
| ![Public method] | [RemoveKey(Type, Object)][2]      | Executes a DELETE command for the entity whose primary key matches the *id* parameter. |
| ![Public method] | **RemoveKey&lt;TEntity>(Object)** | Executes a DELETE command for the entity whose primary key matches the *id* parameter. |


Syntax
------

```csharp
public void RemoveKey<TEntity>(
	Object id
)
where TEntity : class

```

#### Parameters

##### *id*  [Object][3]
The primary key value.

#### Type Parameters

##### *TEntity*



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
[2]: RemoveKey.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: README.md
[5]: ../SqlTable_1/RemoveKey.md
[Public method]: ../../icons/pubmethod.svg "Public method"