SqlTable&lt;TEntity>.Add Method
===============================
Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations. Recursion can be disabled by setting [EnableInsertRecursion][1] to false.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void Add(
	TEntity entity
)
```

#### Parameters

##### *entity*
Type: [TEntity][3]  
 The object whose INSERT command is to be executed. This parameter is named entity for consistency with the other CRUD methods, but in this case it doesn't need to be an actual entity, which means it doesn't need to have a primary key.


See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][2]  

[1]: ../DatabaseConfiguration/EnableInsertRecursion.md
[2]: ../README.md
[3]: README.md