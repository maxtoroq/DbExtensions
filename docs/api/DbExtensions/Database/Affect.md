Database.Affect Method (SqlBuilder, Int32)
==========================================
Executes the *nonQuery* command in a new or existing transaction, and validates the affected records value before comitting.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public int Affect(
	SqlBuilder nonQuery,
	int affectingRecords
)
```

#### Parameters

##### *nonQuery*
Type: [DbExtensions.SqlBuilder][2]  
The non-query command to execute.

##### *affectingRecords*
Type: [System.Int32][3]  
The number of records that the command must affect, otherwise the transaction is rolledback.

#### Return Value
Type: [Int32][3]  
The number of affected records.

Exceptions
----------

Exception                   | Condition                                                          
--------------------------- | ------------------------------------------------------------------ 
[DBConcurrencyException][4] | The number of affected records is not equal to *affectingRecords*. 


See Also
--------

#### Reference
[Database Class][5]  
[DbExtensions Namespace][1]  
[Extensions.Affect(IDbCommand, Int32)][6]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: http://msdn.microsoft.com/en-us/library/td2s409d
[4]: http://msdn.microsoft.com/en-us/library/bsdf9tb2
[5]: README.md
[6]: ../Extensions/Affect.md