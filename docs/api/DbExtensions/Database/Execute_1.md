Database.Execute(String, Object[]) Method
=========================================
Creates and executes an [IDbCommand][1] using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][2]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][3] collection.
  
**Namespace:** [DbExtensions][4]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                     | Description                                                                                                                                                                                                                                                                                                             |
| ---------------- | ---------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | **Execute(String, Object[])**            | Creates and executes an [IDbCommand][1] using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][2]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][3] collection. |
| ![Public method] | [Execute(SqlBuilder, Int32, Boolean)][5] | Executes the *nonQuery* command. Optionally uses a transaction and validates affected records value before committing.                                                                                                                                                                                                  |


Syntax
------

```csharp
public int Execute(
	string commandText,
	params Object[] parameters
)
```

#### Parameters

##### *commandText*  [String][6]
The command text.

##### *parameters*  [Object][7][]
The parameters to apply to the command text.

#### Return Value
[Int32][8]  
The number of affected records.

See Also
--------

#### Reference
[Database Class][9]  
[DbExtensions Namespace][4]  

[1]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand
[2]: https://learn.microsoft.com/dotnet/api/system.string.format#system-string-format(system-string-system-object())
[3]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand.parameters
[4]: ../README.md
[5]: Execute.md
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: https://learn.microsoft.com/dotnet/api/system.object
[8]: https://learn.microsoft.com/dotnet/api/system.int32
[9]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"