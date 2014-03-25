SqlCommandBuilder&lt;TEntity>.DELETE_FROM_WHERE Method (TEntity, ConcurrencyConflictPolicy)
===========================================================================================
Creates and returns a DELETE command for the specified *entity* using the provided *conflictPolicy*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder DELETE_FROM_WHERE(
	TEntity entity,
	ConcurrencyConflictPolicy conflictPolicy
)
```

### Parameters

#### *entity*
Type: [TEntity][2]  
The entity whose DELETE command is to be created.

#### *conflictPolicy*
Type: [DbExtensions.ConcurrencyConflictPolicy][3]  
The [ConcurrencyConflictPolicy][3] that specifies what columns to include in the DELETE predicate.

### Return Value
Type: [SqlBuilder][4]  
The DELETE command for *entity*.

See Also
--------
[SqlCommandBuilder<TEntity> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: ../ConcurrencyConflictPolicy/README.md
[4]: ../SqlBuilder/README.md