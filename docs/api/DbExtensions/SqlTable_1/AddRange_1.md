SqlTable&lt;TEntity>.AddRange Method (TEntity[])
================================================
Recursively executes INSERT commands for the specified *entities* and all its one-to-one and one-to-many associations.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void AddRange(
	params TEntity[] entities
)
```

#### Parameters

##### *entities*
Type: [TEntity][2][]  
The entities whose INSERT commands are to be executed.


See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md