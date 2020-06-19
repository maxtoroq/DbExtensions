Database.Update Method (Object, Object)
=======================================
Executes an UPDATE command for the specified *entity*.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void Update(
	Object entity,
	Object originalId
)
```

#### Parameters

##### *entity*
Type: [System.Object][2]  
The entity whose UPDATE command is to be executed.

##### *originalId*
Type: [System.Object][2]  
The original primary key value.


Remarks
-------
This method is a shortcut for `db.Table(entity.GetType()).Update(entity, originalId)`.

See Also
--------

#### Reference
[Database Class][3]  
[DbExtensions Namespace][1]  
[SqlTable.Update(Object, Object)][4]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: README.md
[4]: ../SqlTable/Update_1.md