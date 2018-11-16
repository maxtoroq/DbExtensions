Database.RemoveKey Method (Type, Object)
========================================
Executes a DELETE command for the entity whose primary key matches the *id* parameter.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void RemoveKey(
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


Remarks
-------
This method is a shortcut for `db.Table(entityType).RemoveKey(id)`.

See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][1]  
[SqlTable.RemoveKey(Object)][5]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/42892f65
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: README.md
[5]: ../SqlTable/RemoveKey.md