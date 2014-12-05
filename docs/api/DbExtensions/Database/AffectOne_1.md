Database.AffectOne Method (String)
==================================
Creates and executes a [DbCommand][1] (whose [CommandText][2] property is initialized with the *commandText* parameter) in a new or existing transaction, and validates that the affected records value is equal to one before comitting.

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public int AffectOne(
	string commandText
)
```

### Parameters

#### *commandText*
Type: [System.String][4]  
The command text.

### Return Value
Type: [Int32][5]  
The number of affected records.

Exceptions
----------

Exception                   | Condition                                           
--------------------------- | --------------------------------------------------- 
[DBConcurrencyException][6] | The number of affected records is not equal to one. 


See Also
--------

### Reference
[Database Class][7]  
[DbExtensions Namespace][3]  
[Extensions.AffectOne(IDbCommand)][8]  

[1]: http://msdn.microsoft.com/en-us/library/852d01k6
[2]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[3]: ../README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: http://msdn.microsoft.com/en-us/library/td2s409d
[6]: http://msdn.microsoft.com/en-us/library/bsdf9tb2
[7]: README.md
[8]: ../Extensions/AffectOne.md