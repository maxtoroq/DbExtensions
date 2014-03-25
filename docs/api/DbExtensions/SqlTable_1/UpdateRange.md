SqlTable&lt;TEntity>.UpdateRange Method (IEnumerable&lt;TEntity>)
=================================================================
Executes UPDATE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][1].

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void UpdateRange(
	IEnumerable<TEntity> entities
)
```

### Parameters

#### *entities*
Type: [System.Collections.Generic.IEnumerable][3]&lt;[TEntity][4]>  
The entities whose UPDATE commands are to be executed.


See Also
--------
[SqlTable<TEntity> Class][4]  
[DbExtensions Namespace][2]  

[1]: ../ConcurrencyConflictPolicy/README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/9eekhta0
[4]: README.md