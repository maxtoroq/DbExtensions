SqlTable&lt;TEntity>.RemoveRange Method (TEntity[])
===================================================
Executes DELETE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][1].

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void RemoveRange(
	params TEntity[] entities
)
```

### Parameters

#### *entities*
Type: [TEntity][3][]  
The entities whose DELETE commands are to be executed.


See Also
--------
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][2]  

[1]: ../ConcurrencyConflictPolicy/README.md
[2]: ../README.md
[3]: README.md