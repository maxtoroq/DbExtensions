SqlBuilder.ToCommand Method (DbProviderFactory)
===============================================
Creates and returns a [DbCommand][1] object whose [CommandText][2] property is initialized with the SQL representation of this instance, and whose [Parameters][3] property is initialized with the values from [ParameterValues][4] of this instance.

**Namespace:** [DbExtensions][5]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public DbCommand ToCommand(
	DbProviderFactory providerFactory
)
```

### Parameters

#### *providerFactory*
Type: [System.Data.Common.DbProviderFactory][6]  
The provider factory used to create the command.

### Return Value
Type: [DbCommand][1]  
 A new [DbCommand][1] object whose [CommandText][2] property is initialized with the SQL representation of this instance, and whose [Parameters][3] property is initialized with the values from [ParameterValues][4] of this instance. 

See Also
--------
[SqlBuilder Class][7]  
[DbExtensions Namespace][5]  
[Extensions.CreateCommand(DbProviderFactory, String, Object[])][8]  

[1]: http://msdn.microsoft.com/en-us/library/852d01k6
[2]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[3]: http://msdn.microsoft.com/en-us/library/9czdkzd1
[4]: ParameterValues.md
[5]: ../README.md
[6]: http://msdn.microsoft.com/en-us/library/c6c4a26c
[7]: README.md
[8]: ../Extensions/CreateCommand_7.md