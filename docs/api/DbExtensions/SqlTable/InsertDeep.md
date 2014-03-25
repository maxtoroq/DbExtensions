SqlTable.InsertDeep Method
==========================
Recursively executes INSERT commands for the specified *entity* and all its one-to-many associations.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
[ObsoleteAttribute("Please use Insert(TEntity, Boolean) instead.")]
public void InsertDeep(
	Object entity
)
```

### Parameters

#### *entity*
Type: [System.Object][2]  
The entity whose INSERT command is to be executed.


See Also
--------
[SqlTable Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: README.md