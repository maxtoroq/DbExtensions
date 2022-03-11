Database.Contains Method
========================
Checks the existance of the *entity*, using the primary key value.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public bool Contains(
	Object entity
)
```

#### Parameters

##### *entity*
Type: [System.Object][2]  
The entity whose existance is to be checked.

#### Return Value
Type: [Boolean][3]  
true if the primary key value exists in the database; otherwise false.

Remarks
-------
This method is a shortcut for `db.Table(entity.GetType()).Contains(entity)`.

See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][1]  
[SqlSet.Contains(Object)][5]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: README.md
[5]: ../SqlSet/Contains.md