Database.CreateCommand(SqlBuilder) Method
=========================================
Creates and returns an [IDbCommand][1] object from the specified *sqlBuilder*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                 | Description                                                                                                                                                                                                                                                                                                                   |
| ---------------- | ------------------------------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | **CreateCommand(SqlBuilder)**        | Creates and returns an [IDbCommand][1] object from the specified *sqlBuilder*.                                                                                                                                                                                                                                                |
| ![Public method] | [CreateCommand(String, Object[])][3] | Creates and returns an [IDbCommand][1] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][4]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][5] collection. |


Syntax
------

```csharp
public IDbCommand CreateCommand(
	SqlBuilder sqlBuilder
)
```

#### Parameters

##### *sqlBuilder*  [SqlBuilder][6]
The [SqlBuilder][6] that provides the command's text and parameters.

#### Return Value
[IDbCommand][1]  
 A new [IDbCommand][1] object whose [CommandText][7] property is initialized with the *sqlBuilder*'s string representation, and whose [Parameters][5] property is initialized with the values from the [ParameterValues][8] property of the *sqlBuilder* parameter.

See Also
--------

#### Reference
[Database Class][9]  
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand
[2]: ../README.md
[3]: CreateCommand_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.string.format#system-string-format(system-string-system-object())
[5]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand.parameters
[6]: ../SqlBuilder/README.md
[7]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand.commandtext
[8]: ../SqlBuilder/ParameterValues.md
[9]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"