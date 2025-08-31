Database.RemoveKey(Type, Object) Method
=======================================
Executes a DELETE command for the entity whose primary key matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public void RemoveKey(
	Type entityType,
	Object id
)
```

#### Parameters

##### *entityType*  [Type][2]
The type of the entity.

##### *id*  [Object][3]
The primary key value.


Remarks
-------
This method is a shortcut for `db.Table(entityType).RemoveKey(id)`.

See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][1]  
[RemoveKey(Object)][5]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.type
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: README.md
[5]: ../SqlTable/RemoveKey.md