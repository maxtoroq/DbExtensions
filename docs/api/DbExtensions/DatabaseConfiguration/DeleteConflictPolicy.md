DatabaseConfiguration.DeleteConflictPolicy Property
===================================================
Gets or sets the default policy to use when calling [Delete(TEntity)][1]. The default value is [IgnoreVersionAndLowerAffectedRecords][2].

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public ConcurrencyConflictPolicy DeleteConflictPolicy { get; set; }
```

### Property Value
Type: [ConcurrencyConflictPolicy][2]

See Also
--------
[DatabaseConfiguration Class][4]  
[DbExtensions Namespace][3]  

[1]: ../SqlTable_1/Delete.md
[2]: ../ConcurrencyConflictPolicy/README.md
[3]: ../README.md
[4]: README.md