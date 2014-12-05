SqlBuilder.ToCommand Method (DbConnection)
==========================================
Creates and returns a [DbCommand][1] object whose [CommandText][2] property is initialized with the SQL representation of this instance, and whose [Parameters][3] property is initialized with the values from [ParameterValues][4] of this instance.

**Namespace:** [DbExtensions][5]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public DbCommand ToCommand(
	DbConnection connection
)
```

### Parameters

#### *connection*
Type: [System.Data.Common.DbConnection][6]  
The connection used to create the command.

### Return Value
Type: [DbCommand][1]  
 A new [DbCommand][1] object whose [CommandText][2] property is initialized with the SQL representation of this instance, and whose [Parameters][3] property is initialized with the values from [ParameterValues][4] of this instance. 

See Also
--------

### Reference
[SqlBuilder Class][7]  
[DbExtensions Namespace][5]  
[Extensions.CreateCommand(DbConnection, String, Object[])][8]  

[1]: http://msdn.microsoft.com/en-us/library/852d01k6
[2]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[3]: http://msdn.microsoft.com/en-us/library/9czdkzd1
[4]: ParameterValues.md
[5]: ../README.md
[6]: http://msdn.microsoft.com/en-us/library/c790zwhc
[7]: README.md
[8]: ../Extensions/CreateCommand_4.md