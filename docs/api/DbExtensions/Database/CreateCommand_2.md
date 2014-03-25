Database.CreateCommand Method (String, Object[])
================================================
Creates and returns a [DbCommand][1] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][2]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][3] collection.

**Namespace:** [DbExtensions][4]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public DbCommand CreateCommand(
	string commandText,
	params Object[] parameters
)
```

### Parameters

#### *commandText*
Type: [System.String][5]  
The command text.

#### *parameters*
Type: [System.Object][6][]  
The array of parameters to be passed to the command. Note the following behavior: If the number of objects in the array is less than the highest number identified in the command string, an exception is thrown. If the array contains objects that are not referenced in the command string, no exception is thrown. If a parameter is null, it is converted to DBNull.Value.

### Return Value
Type: [DbCommand][1]  
 A new [DbCommand][1] object whose [CommandText][7] property is initialized with the *commandText* parameter, and whose [Parameters][3] property is initialized with the values from the *parameters* parameter. 

Remarks
-------
[Transaction][8] is associated with all new commands created using this method. 

See Also
--------
[Database Class][9]  
[DbExtensions Namespace][4]  
[Extensions.CreateCommand(DbConnection, String, Object[])][10]  

[1]: http://msdn.microsoft.com/en-us/library/852d01k6
[2]: http://msdn.microsoft.com/en-us/library/b1csw23d
[3]: http://msdn.microsoft.com/en-us/library/9czdkzd1
[4]: ../README.md
[5]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[6]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[7]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[8]: Transaction.md
[9]: README.md
[10]: ../Extensions/CreateCommand_4.md