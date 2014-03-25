SqlTable&lt;TEntity>.Insert Method (TEntity, Boolean)
=====================================================
Executes an INSERT command for the specified *entity*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void Insert(
	TEntity entity,
	bool deep
)
```

### Parameters

#### *entity*
Type: [TEntity][2]  
The object whose INSERT command is to be executed. This parameter is named entity for consistency with the other CRUD methods, but in this case it doesn't need to be an actual entity, which means it doesn't need to have a primary key.

#### *deep*
Type: [System.Boolean][3]  
true to recursively execute INSERT commands for the *entity*'s one-to-many associations; otherwise, false.


See Also
--------
[SqlTable&lt;TEntity> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50