Database.ContainsKey Method (Type, Object)
==========================================
Checks the existance of an entity whose primary matches the *id* parameter.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public bool ContainsKey(
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
Type: [Boolean][4]  
true if the primary key value exists in the database; otherwise false.

Remarks
-------
This method is a shortcut for `db.Table(entityType).ContainsKey(id)`.

See Also
--------

#### Reference
[Database Class][5]  
[DbExtensions Namespace][1]  
[SqlSet.ContainsKey(Object)][6]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/42892f65
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: http://msdn.microsoft.com/en-us/library/a28wyd50
[5]: README.md
[6]: ../SqlSet/ContainsKey.md