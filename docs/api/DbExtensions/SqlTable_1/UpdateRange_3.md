SqlTable&lt;TEntity>.UpdateRange Method (TEntity[], ConcurrencyConflictPolicy)
==============================================================================
Executes UPDATE commands for the specified *entities* using the provided *conflictPolicy*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void UpdateRange(
	TEntity[] entities,
	ConcurrencyConflictPolicy conflictPolicy
)
```

### Parameters

#### *entities*
Type: [TEntity][2][]  
The entities whose UPDATE commands are to be executed.

#### *conflictPolicy*
Type: [DbExtensions.ConcurrencyConflictPolicy][3]  
The [ConcurrencyConflictPolicy][3] that specifies what columns to check for in the UPDATE predicate, and how to validate the affected records value.


See Also
--------
[SqlTable<TEntity> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: ../ConcurrencyConflictPolicy/README.md