Database.RemoveKey(Type, Object) Method
=======================================
Executes a DELETE command for the entity whose primary key matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                               | Description                                                                            |
| ---------------- | ---------------------------------- | -------------------------------------------------------------------------------------- |
| ![Public method] | **RemoveKey(Type, Object)**        | Executes a DELETE command for the entity whose primary key matches the *id* parameter. |
| ![Public method] | [RemoveKey&lt;TEntity>(Object)][2] | Executes a DELETE command for the entity whose primary key matches the *id* parameter. |


Syntax
------

```csharp
public void RemoveKey(
	Type entityType,
	Object id
)
```

#### Parameters

##### *entityType*  [Type][3]
The type of the entity.

##### *id*  [Object][4]
The primary key value.


Remarks
-------
This method is a shortcut for `db.Table(entityType).RemoveKey(id)`.

See Also
--------

#### Reference
[Database Class][5]  
[DbExtensions Namespace][1]  
[SqlTable.RemoveKey(Object)][6]  

[1]: ../README.md
[2]: RemoveKey__1.md
[3]: https://learn.microsoft.com/dotnet/api/system.type
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: README.md
[6]: ../SqlTable/RemoveKey.md
[Public method]: ../../icons/pubmethod.svg "Public method"