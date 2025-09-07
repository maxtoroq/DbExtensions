Database.CreateCommand Method
=============================
Creates and returns a [DbCommand][1] object from the specified *sqlBuilder*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public virtual DbCommand CreateCommand(
	SqlBuilder sqlBuilder
)
```

#### Parameters

##### *sqlBuilder*  [SqlBuilder][3]
The [SqlBuilder][3] that provides the command's text and parameters.

#### Return Value
[DbCommand][1]  
 A new [DbCommand][1] object with its [CommandText][4] property initialized with the *sqlBuilder*'s string representation, and its [Parameters][5] property is initialized with the values from the [ParameterValues][6] property of the *sqlBuilder* parameter.

See Also
--------

#### Reference
[Database Class][7]  
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.data.common.dbcommand
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: https://learn.microsoft.com/dotnet/api/system.data.common.dbcommand.commandtext
[5]: https://learn.microsoft.com/dotnet/api/system.data.common.dbcommand.parameters
[6]: ../SqlBuilder/ParameterValues.md
[7]: README.md