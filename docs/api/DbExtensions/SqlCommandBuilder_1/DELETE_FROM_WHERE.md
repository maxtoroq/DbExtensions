SqlCommandBuilder&lt;TEntity>.DELETE_FROM_WHERE Method (TEntity)
================================================================
Creates and returns a DELETE command for the specified *entity*, using the default [ConcurrencyConflictPolicy][1].

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder DELETE_FROM_WHERE(
	TEntity entity
)
```

### Parameters

#### *entity*
Type: [TEntity][3]  
The entity whose DELETE command is to be created.

### Return Value
Type: [SqlBuilder][4]  
The DELETE command for *entity*.

See Also
--------

### Reference
[SqlCommandBuilder&lt;TEntity> Class][3]  
[DbExtensions Namespace][2]  

[1]: ../ConcurrencyConflictPolicy/README.md
[2]: ../README.md
[3]: README.md
[4]: ../SqlBuilder/README.md