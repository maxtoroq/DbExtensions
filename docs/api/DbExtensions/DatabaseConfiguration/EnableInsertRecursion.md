DatabaseConfiguration.EnableInsertRecursion Property
====================================================
true to recursively execute INSERT commands for the entity's one-to-one and one-to-many associations; otherwise, false. The default is true.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public bool EnableInsertRecursion { get; set; }
```

### Property Value
Type: [Boolean][2]

Remarks
-------
 This setting affects the behavior of [Add(TEntity)][3] and [AddRange(TEntity[])][4]. 

See Also
--------
[DatabaseConfiguration Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/a28wyd50
[3]: ../SqlTable_1/Add.md
[4]: ../SqlTable_1/AddRange_1.md
[5]: README.md