DatabaseConfiguration.EnableBatchCommands Property
==================================================
true to execute batch commands when possible; otherwise, false. The default is true.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public bool EnableBatchCommands { get; set; }
```

#### Property Value
Type: [Boolean][2]

Remarks
-------
 This setting affects the behavior of [AddRange(TEntity[])][3], [UpdateRange(TEntity[])][4] and [RemoveRange(TEntity[])][5]. 

See Also
--------

#### Reference
[DatabaseConfiguration Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/a28wyd50
[3]: ../SqlTable_1/AddRange_1.md
[4]: ../SqlTable_1/UpdateRange_1.md
[5]: ../SqlTable_1/RemoveRange_1.md
[6]: README.md