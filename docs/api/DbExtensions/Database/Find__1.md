Database.Find&lt;TEntity>(Object) Method
========================================
Gets the entity whose primary key matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                         | Description                                                   |
| ---------------- | ---------------------------- | ------------------------------------------------------------- |
| ![Public method] | [Find(Type, Object)][2]      | Gets the entity whose primary key matches the *id* parameter. |
| ![Public method] | **Find&lt;TEntity>(Object)** | Gets the entity whose primary key matches the *id* parameter. |


Syntax
------

```csharp
public TEntity Find<TEntity>(
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
**TEntity**  
 The entity whose primary key matches the *id* parameter, or null if the *id* does not exist.

Remarks
-------
This method is a shortcut for `db.Table<TEntity>().Find(id)`.

See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][1]  
[SqlSet&lt;TResult>.Find(Object)][5]  

[1]: ../README.md
[2]: Find.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: README.md
[5]: ../SqlSet_1/Find.md
[Public method]: ../../icons/pubmethod.svg "Public method"