Database.Execute Method (String, Object[])
==========================================
Creates and executes a [DbCommand][1] using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][2]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][3] collection.

**Namespace:** [DbExtensions][4]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public int Execute(
	string commandText,
	params Object[] parameters
)
```

### Parameters

#### *commandText*
Type: [System.String][5]  
The command text.

#### *parameters*
Type: [System.Object][6][]  
The parameters to apply to the command text.

### Return Value
Type: [Int32][7]  
The number of affected records.

See Also
--------
[Database Class][8]  
[DbExtensions Namespace][4]  

[1]: http://msdn.microsoft.com/en-us/library/852d01k6
[2]: http://msdn.microsoft.com/en-us/library/b1csw23d
[3]: http://msdn.microsoft.com/en-us/library/9czdkzd1
[4]: ../README.md
[5]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[6]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[7]: http://msdn.microsoft.com/en-us/library/td2s409d
[8]: README.md