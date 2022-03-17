Database.Execute Method (String, Object[])
==========================================
Creates and executes an [IDbCommand][1] using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][2]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][3] collection.

  **Namespace:**  [DbExtensions][4]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public int Execute(
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
The parameters to apply to the command text.

#### Return Value
Type: [Int32][7]  
The number of affected records.

See Also
--------

#### Reference
[Database Class][8]  
[DbExtensions Namespace][4]  

[1]: https://docs.microsoft.com/dotnet/api/system.data.idbcommand
[2]: https://docs.microsoft.com/dotnet/api/system.string.format#System_String_Format_System_String_System_Object___
[3]: https://docs.microsoft.com/dotnet/api/system.data.idbcommand.parameters#System_Data_IDbCommand_Parameters
[4]: ../README.md
[5]: https://docs.microsoft.com/dotnet/api/system.string
[6]: https://docs.microsoft.com/dotnet/api/system.object
[7]: https://docs.microsoft.com/dotnet/api/system.int32
[8]: README.md