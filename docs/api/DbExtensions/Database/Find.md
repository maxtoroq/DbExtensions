Database.Find(Type, Object) Method
==================================
Gets the entity whose primary key matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                          | Description                                                   |
| ---------------- | ----------------------------- | ------------------------------------------------------------- |
| ![Public method] | **Find(Type, Object)**        | Gets the entity whose primary key matches the *id* parameter. |
| ![Public method] | [Find&lt;TEntity>(Object)][2] | Gets the entity whose primary key matches the *id* parameter. |


Syntax
------

```csharp
public Object Find(
	Type entityType,
	Object id
)
```

#### Parameters

##### *entityType*  [Type][3]
The type of the entity.

##### *id*  [Object][4]
The primary key value.

#### Return Value
[Object][4]  
 The entity whose primary key matches the *id* parameter, or null if the *id* does not exist.

Remarks
-------
This method is a shortcut for `db.Table(entityType).Find(id)`.

See Also
--------

#### Reference
[Database Class][5]  
[DbExtensions Namespace][1]  
[SqlSet.Find(Object)][6]  

[1]: ../README.md
[2]: Find__1.md
[3]: https://learn.microsoft.com/dotnet/api/system.type
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: README.md
[6]: ../SqlSet/Find.md
[Public method]: ../../icons/pubmethod.svg "Public method"