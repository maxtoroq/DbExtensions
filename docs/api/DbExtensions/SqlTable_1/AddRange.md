SqlTable&lt;TEntity>.AddRange Method (IEnumerable&lt;TEntity>)
==============================================================
Recursively executes INSERT commands for the specified *entities* and all its one-to-one and one-to-many associations. Recursion can be disabled by setting [EnableInsertRecursion][1] to false.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void AddRange(
	IEnumerable<TEntity> entities
)
```

### Parameters

#### *entities*
Type: [System.Collections.Generic.IEnumerable][3]&lt;[TEntity][4]>  
The entities whose INSERT commands are to be executed.


See Also
--------
[SqlTable&lt;TEntity> Class][4]  
[DbExtensions Namespace][2]  

[1]: ../DatabaseConfiguration/EnableInsertRecursion.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/9eekhta0
[4]: README.md