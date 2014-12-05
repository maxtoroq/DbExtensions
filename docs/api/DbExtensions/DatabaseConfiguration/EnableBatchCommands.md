DatabaseConfiguration.EnableBatchCommands Property
==================================================
true to execute batch commands when possible; otherwise, false. The default is true. You can override the default value using a "DbExtensions:{providerInvariantName}:EnableBatchCommands" entry in the appSettings configuration section, where {providerInvariantName} is replaced with the provider invariant name (e.g. DbExtensions:System.Data.SqlClient:EnableBatchCommands).

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public bool EnableBatchCommands { get; set; }
```

### Property Value
Type: [Boolean][2]

See Also
--------

### Reference
[DatabaseConfiguration Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/a28wyd50
[3]: README.md