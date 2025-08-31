Database.CreateCommand Method
=============================
Creates and returns an [IDbCommand][1] object from the specified *sqlBuilder*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public virtual IDbCommand CreateCommand(
	SqlBuilder sqlBuilder
)
```

#### Parameters

##### *sqlBuilder*  [SqlBuilder][3]
The [SqlBuilder][3] that provides the command's text and parameters.

#### Return Value
[IDbCommand][1]  
 A new [IDbCommand][1] object whose [CommandText][4] property is initialized with the *sqlBuilder*'s string representation, and whose [Parameters][5] property is initialized with the values from the [ParameterValues][6] property of the *sqlBuilder* parameter.

See Also
--------

#### Reference
[Database Class][7]  
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand.commandtext
[5]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand.parameters
[6]: ../SqlBuilder/ParameterValues.md
[7]: README.md