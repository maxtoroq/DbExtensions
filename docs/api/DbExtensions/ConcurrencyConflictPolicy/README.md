ConcurrencyConflictPolicy Enumeration
=====================================
Indicates what concurrency conflict policy to use. A concurrency conflict ocurrs when trying to UPDATE/DELETE a row that has a newer version, or when trying to UPDATE/DELETE a row that no longer exists.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public enum ConcurrencyConflictPolicy
```


Members
-------

Member name                              | Value | Description                                                                                                                                                                                                                              
---------------------------------------- | ----- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
**UseVersion**                           | 0     | Include version column check in the UPDATE/DELETE statement predicate.                                                                                                                                                                   
**IgnoreVersion**                        | 1     | The predicate for the UPDATE/DELETE statement should not contain any version column checks to avoid version conflicts. Note that a conflict can still ocurr if the row no longer exists.                                                 
**IgnoreVersionAndLowerAffectedRecords** | 2     | The predicate for the UPDATE/DELETE statement should not contain any version column checks to avoid version conflicts. If the number of affected records is lower than expected then it is presumed that the row was previously deleted. 


See Also
--------
[DbExtensions Namespace][1]  

[1]: ../README.md