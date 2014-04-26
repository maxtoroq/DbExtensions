SqlTable&lt;TEntity>.Remove Method (TEntity, ConcurrencyConflictPolicy)
=======================================================================
Executes a DELETE command for the specified *entity* using the provided *conflictPolicy*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void Remove(
	TEntity entity,
	ConcurrencyConflictPolicy conflictPolicy
)
```

### Parameters

#### *entity*
Type: [TEntity][2]  
The entity whose DELETE command is to be executed.

#### *conflictPolicy*
Type: [DbExtensions.ConcurrencyConflictPolicy][3]  
The [ConcurrencyConflictPolicy][3] that specifies what columns to check for in the DELETE predicate, and how to validate the affected records value.


See Also
--------
[SqlTable&lt;TEntity> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: ../ConcurrencyConflictPolicy/README.md