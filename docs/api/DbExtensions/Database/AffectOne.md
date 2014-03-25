Database.AffectOne Method (SqlBuilder)
======================================
Executes the *nonQuery* command in a new or existing transaction, and validates that the affected records value is equal to one before comitting.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public int AffectOne(
	SqlBuilder nonQuery
)
```

### Parameters

#### *nonQuery*
Type: [DbExtensions.SqlBuilder][2]  
The non-query command to execute.

### Return Value
Type: [Int32][3]  
The number of affected records.

Exceptions
----------

Exception                   | Condition                                           
--------------------------- | --------------------------------------------------- 
[DBConcurrencyException][4] | The number of affected records is not equal to one. 


See Also
--------
[Database Class][5]  
[DbExtensions Namespace][1]  
[Extensions.AffectOne(IDbCommand)][6]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: http://msdn.microsoft.com/en-us/library/td2s409d
[4]: http://msdn.microsoft.com/en-us/library/bsdf9tb2
[5]: README.md
[6]: ../Extensions/AffectOne_4.md