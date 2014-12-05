SqlTable.UpdateRange Method (IEnumerable&lt;Object>, ConcurrencyConflictPolicy)
===============================================================================
Executes UPDATE commands for the specified *entities* using the provided *conflictPolicy*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void UpdateRange(
	IEnumerable<Object> entities,
	ConcurrencyConflictPolicy conflictPolicy
)
```

### Parameters

#### *entities*
Type: [System.Collections.Generic.IEnumerable][2]&lt;[Object][3]>  
The entities whose UPDATE commands are to be executed.

#### *conflictPolicy*
Type: [DbExtensions.ConcurrencyConflictPolicy][4]  
 The [ConcurrencyConflictPolicy][4] that specifies what columns to check for in the UPDATE predicate, and how to validate the affected records value.


See Also
--------

### Reference
[SqlTable Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/9eekhta0
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../ConcurrencyConflictPolicy/README.md
[5]: README.md