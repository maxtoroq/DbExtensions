Database.Execute(SqlBuilder, Int32, Boolean) Method
===================================================
Executes the *nonQuery* command. Optionally uses a transaction and validates affected records value before committing.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                    | Description                                                                                                                                                                                                                                                                                                             |
| ---------------- | --------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [Execute(String, Object[])][2]          | Creates and executes an [IDbCommand][3] using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][4]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][5] collection. |
| ![Public method] | **Execute(SqlBuilder, Int32, Boolean)** | Executes the *nonQuery* command. Optionally uses a transaction and validates affected records value before committing.                                                                                                                                                                                                  |


Syntax
------

```csharp
public int Execute(
	SqlBuilder nonQuery,
	int affect = -1,
	bool exact = false
)
```

#### Parameters

##### *nonQuery*  [SqlBuilder][6]
The non-query command to execute.

##### *affect*  [Int32][7]  (Optional)
The number of records the command should affect. This value is ignored if less or equal to -1.

##### *exact*  [Boolean][8]  (Optional)
true if the number of affected records should exactly match *affect*; false if a lower number is acceptable.

#### Return Value
[Int32][7]  
The number of affected records.

Exceptions
----------

| Exception                    | Condition                                                |
| ---------------------------- | -------------------------------------------------------- |
| [ChangeConflictException][9] | The number of affected records is not equal to *affect*. |


See Also
--------

#### Reference
[Database Class][10]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Execute_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand
[4]: https://learn.microsoft.com/dotnet/api/system.string.format#system-string-format(system-string-system-object())
[5]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand.parameters
[6]: ../SqlBuilder/README.md
[7]: https://learn.microsoft.com/dotnet/api/system.int32
[8]: https://learn.microsoft.com/dotnet/api/system.boolean
[9]: ../ChangeConflictException/README.md
[10]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"