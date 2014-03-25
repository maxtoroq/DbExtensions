SqlTable&lt;TEntity>.DeleteKey Method (Object, ConcurrencyConflictPolicy)
=========================================================================
Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the provided *conflictPolicy*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void DeleteKey(
	Object id,
	ConcurrencyConflictPolicy conflictPolicy
)
```

### Parameters

#### *id*
Type: [System.Object][2]  
The primary key value.

#### *conflictPolicy*
Type: [DbExtensions.ConcurrencyConflictPolicy][3]  
The [ConcurrencyConflictPolicy][3] that specifies how to validate the affected records value.


See Also
--------
[SqlTable<TEntity> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../ConcurrencyConflictPolicy/README.md
[4]: README.md