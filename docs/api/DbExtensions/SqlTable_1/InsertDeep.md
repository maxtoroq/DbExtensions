SqlTable&lt;TEntity>.InsertDeep Method
======================================
Recursively executes INSERT commands for the specified *entity* and all its one-to-many associations.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
[ObsoleteAttribute("Please use Insert(TEntity, Boolean) instead.")]
public void InsertDeep(
	TEntity entity
)
```

### Parameters

#### *entity*
Type: [TEntity][2]  
The entity whose INSERT command is to be executed.


See Also
--------
[SqlTable<TEntity> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md