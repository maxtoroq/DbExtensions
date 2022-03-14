Database.CreateCommand Method (SqlBuilder)
==========================================
Creates and returns an [IDbCommand][1] object from the specified *sqlBuilder*.

  **Namespace:**  [DbExtensions][2]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public IDbCommand CreateCommand(
	SqlBuilder sqlBuilder
)
```

#### Parameters

##### *sqlBuilder*
Type: [DbExtensions.SqlBuilder][3]  
The [SqlBuilder][3] that provides the command's text and parameters.

#### Return Value
Type: [IDbCommand][1]  
 A new [IDbCommand][1] object whose [CommandText][4] property is initialized with the *sqlBuilder*'s string representation, and whose [Parameters][5] property is initialized with the values from the [ParameterValues][6] property of the *sqlBuilder* parameter. 

See Also
--------

#### Reference
[Database Class][7]  
[DbExtensions Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.data.idbcommand
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: https://docs.microsoft.com/dotnet/api/system.data.idbcommand.commandtext#System_Data_IDbCommand_CommandText
[5]: https://docs.microsoft.com/dotnet/api/system.data.idbcommand.parameters#System_Data_IDbCommand_Parameters
[6]: ../SqlBuilder/ParameterValues.md
[7]: README.md