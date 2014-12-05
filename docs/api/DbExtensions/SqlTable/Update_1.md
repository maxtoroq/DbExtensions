SqlTable.Update Method (Object, ConcurrencyConflictPolicy)
==========================================================
Executes an UPDATE command for the specified *entity* using the provided *conflictPolicy*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void Update(
	Object entity,
	ConcurrencyConflictPolicy conflictPolicy
)
```

### Parameters

#### *entity*
Type: [System.Object][2]  
The entity whose UPDATE command is to be executed.

#### *conflictPolicy*
Type: [DbExtensions.ConcurrencyConflictPolicy][3]  
 The [ConcurrencyConflictPolicy][3] that specifies what columns to check for in the UPDATE predicate, and how to validate the affected records value.


See Also
--------

### Reference
[SqlTable Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../ConcurrencyConflictPolicy/README.md
[4]: README.md