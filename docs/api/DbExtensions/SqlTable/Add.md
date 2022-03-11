SqlTable.Add Method
===================
Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public void Add(
	Object entity
)
```

#### Parameters

##### *entity*
Type: [System.Object][2]  
 The object whose INSERT command is to be executed. This parameter is named entity for consistency with the other CRUD methods, but in this case it doesn't need to be an actual entity, which means it doesn't need to have a primary key.


See Also
--------

#### Reference
[SqlTable Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: README.md