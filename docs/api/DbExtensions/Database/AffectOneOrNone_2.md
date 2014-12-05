Database.AffectOneOrNone Method (String, Object[])
==================================================
Creates and executes a [DbCommand][1] (using the provided *commandText* as a composite format string, as used on [Format(String, Object[])][2], where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][3] collection) in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting.

**Namespace:** [DbExtensions][4]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public int AffectOneOrNone(
	string commandText,
	params Object[] parameters
)
```

#### Parameters

##### *commandText*
Type: [System.String][5]  
The non-query command to execute.

##### *parameters*
Type: [System.Object][6][]  
The parameters to apply to the command text.

#### Return Value
Type: [Int32][7]  
The number of affected records.

Exceptions
----------

Exception                   | Condition                                           
--------------------------- | --------------------------------------------------- 
[DBConcurrencyException][8] | The number of affected records is greater than one. 


See Also
--------

#### Reference
[Database Class][9]  
[DbExtensions Namespace][4]  
[Extensions.AffectOneOrNone(IDbCommand)][10]  

[1]: http://msdn.microsoft.com/en-us/library/852d01k6
[2]: http://msdn.microsoft.com/en-us/library/b1csw23d
[3]: http://msdn.microsoft.com/en-us/library/9czdkzd1
[4]: ../README.md
[5]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[6]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[7]: http://msdn.microsoft.com/en-us/library/td2s409d
[8]: http://msdn.microsoft.com/en-us/library/bsdf9tb2
[9]: README.md
[10]: ../Extensions/AffectOneOrNone.md