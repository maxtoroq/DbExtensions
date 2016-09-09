DatabaseConfiguration.IgnoreDeleteConflicts Property
====================================================
true to ignore when a concurrency conflict occurs when executing a DELETE command; otherwise, false. The default is true.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public bool IgnoreDeleteConflicts { get; set; }
```

#### Property Value
Type: [Boolean][2]

Remarks
-------
 This setting affects the behavior of [Remove(TEntity)][3], [RemoveKey(Object)][4] and [RemoveRange(TEntity[])][5]. 

See Also
--------

#### Reference
[DatabaseConfiguration Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/a28wyd50
[3]: ../SqlTable_1/Remove.md
[4]: ../SqlTable_1/RemoveKey.md
[5]: ../SqlTable_1/RemoveRange_1.md
[6]: README.md