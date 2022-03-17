Database.CreateCommand Method (String, Object[])
================================================
Creates and returns an [IDbCommand][1] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][2]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][3] collection.

  **Namespace:**  [DbExtensions][4]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public virtual IDbCommand CreateCommand(
	string commandText,
	params Object[] parameters
)
```

#### Parameters

##### *commandText*
Type: [System.String][5]  
The command text.

##### *parameters*
Type: [System.Object][6][]  
 The array of parameters to be passed to the command. Note the following behavior: If the number of objects in the array is less than the highest number identified in the command string, an exception is thrown. If the array contains objects that are not referenced in the command string, no exception is thrown. If a parameter is null, it is converted to DBNull.Value.

#### Return Value
Type: [IDbCommand][1]  
 A new [IDbCommand][1] object whose [CommandText][7] property is initialized with the *commandText* parameter, and whose [Parameters][3] property is initialized with the values from the *parameters* parameter. 

Remarks
-------
[Transaction][8] is associated with all commands created using this method. 

See Also
--------

#### Reference
[Database Class][9]  
[DbExtensions Namespace][4]  

[1]: https://docs.microsoft.com/dotnet/api/system.data.idbcommand
[2]: https://docs.microsoft.com/dotnet/api/system.string.format#System_String_Format_System_String_System_Object___
[3]: https://docs.microsoft.com/dotnet/api/system.data.idbcommand.parameters#System_Data_IDbCommand_Parameters
[4]: ../README.md
[5]: https://docs.microsoft.com/dotnet/api/system.string
[6]: https://docs.microsoft.com/dotnet/api/system.object
[7]: https://docs.microsoft.com/dotnet/api/system.data.idbcommand.commandtext#System_Data_IDbCommand_CommandText
[8]: Transaction.md
[9]: README.md