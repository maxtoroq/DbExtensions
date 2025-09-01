Database.ContainsKey(Type, Object) Method
=========================================
Checks the existance of an entity whose primary matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                 | Description                                                                 |
| ---------------- | ------------------------------------ | --------------------------------------------------------------------------- |
| ![Public method] | **ContainsKey(Type, Object)**        | Checks the existance of an entity whose primary matches the *id* parameter. |
| ![Public method] | [ContainsKey&lt;TEntity>(Object)][2] | Checks the existance of an entity whose primary matches the *id* parameter. |


Syntax
------

```csharp
public bool ContainsKey(
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
[Boolean][5]  
true if the primary key value exists in the database; otherwise false.

Remarks
-------
This method is a shortcut for `db.Table(entityType).ContainsKey(id)`.

See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][1]  
[SqlSet.ContainsKey(Object)][7]  

[1]: ../README.md
[2]: ContainsKey__1.md
[3]: https://learn.microsoft.com/dotnet/api/system.type
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: https://learn.microsoft.com/dotnet/api/system.boolean
[6]: README.md
[7]: ../SqlSet/ContainsKey.md
[Public method]: ../../icons/pubmethod.svg "Public method"