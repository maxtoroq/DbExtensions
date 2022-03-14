Database.Find Method (Type, Object)
===================================
Gets the entity whose primary key matches the *id* parameter.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public Object Find(
	Type entityType,
	Object id
)
```

#### Parameters

##### *entityType*
Type: [System.Type][2]  
The type of the entity.

##### *id*
Type: [System.Object][3]  
The primary key value.

#### Return Value
Type: [Object][3]  
 The entity whose primary key matches the *id* parameter, or null if the *id* does not exist. 

Remarks
-------
This method is a shortcut for `db.Table(entityType).Find(id)`.

See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][1]  
[SqlSet.Find(Object)][5]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.type
[3]: https://docs.microsoft.com/dotnet/api/system.object
[4]: README.md
[5]: ../SqlSet/Find.md