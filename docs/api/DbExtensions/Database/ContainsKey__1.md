Database.ContainsKey&lt;TEntity>(Object) Method
===============================================
Checks the existance of an entity whose primary matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                | Description                                                                 |
| ---------------- | ----------------------------------- | --------------------------------------------------------------------------- |
| ![Public method] | [ContainsKey(Type, Object)][2]      | Checks the existance of an entity whose primary matches the *id* parameter. |
| ![Public method] | **ContainsKey&lt;TEntity>(Object)** | Checks the existance of an entity whose primary matches the *id* parameter. |


Syntax
------

```csharp
public bool ContainsKey<TEntity>(
	Object id
)
where TEntity : class

```

#### Parameters

##### *id*  [Object][3]
The primary key value.

#### Type Parameters

##### *TEntity*
The type of the entity.

#### Return Value
[Boolean][4]  
true if the primary key value exists in the database; otherwise false.

Remarks
-------
This method is a shortcut for `db.Table<TEntity>().ContainsKey(id)`.

See Also
--------

#### Reference
[Database Class][5]  
[DbExtensions Namespace][1]  
[SqlSet.ContainsKey(Object)][6]  

[1]: ../README.md
[2]: ContainsKey.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: https://learn.microsoft.com/dotnet/api/system.boolean
[5]: README.md
[6]: ../SqlSet/ContainsKey.md
[Public method]: ../../icons/pubmethod.svg "Public method"