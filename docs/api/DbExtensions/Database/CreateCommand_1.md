Database.CreateCommand(String, Object[]) Method
===============================================
Creates and returns an [IDbCommand][1] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][2]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][3] collection.
  
**Namespace:** [DbExtensions][4]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                | Description                                                                                                                                                                                                                                                                                                                   |
| ---------------- | ----------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [CreateCommand(SqlBuilder)][5]      | Creates and returns an [IDbCommand][1] object from the specified *sqlBuilder*.                                                                                                                                                                                                                                                |
| ![Public method] | **CreateCommand(String, Object[])** | Creates and returns an [IDbCommand][1] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][2]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][3] collection. |


Syntax
------

```csharp
public virtual IDbCommand CreateCommand(
	string commandText,
	params Object[] parameters
)
```

#### Parameters

##### *commandText*  [String][6]
The command text.

##### *parameters*  [Object][7][]
The array of parameters to be passed to the command. Note the following behavior: If the number of objects in the array is less than the highest number identified in the command string, an exception is thrown. If the array contains objects that are not referenced in the command string, no exception is thrown. If a parameter is null, it is converted to DBNull.Value.

#### Return Value
[IDbCommand][1]  
 A new [IDbCommand][1] object whose [CommandText][8] property is initialized with the *commandText* parameter, and whose [Parameters][3] property is initialized with the values from the *parameters* parameter.

Remarks
-------
[Transaction][9] is associated with all commands created using this method.

See Also
--------

#### Reference
[Database Class][10]  
[DbExtensions Namespace][4]  

[1]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand
[2]: https://learn.microsoft.com/dotnet/api/system.string.format#system-string-format(system-string-system-object())
[3]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand.parameters
[4]: ../README.md
[5]: CreateCommand.md
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: https://learn.microsoft.com/dotnet/api/system.object
[8]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand.commandtext
[9]: Transaction.md
[10]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"