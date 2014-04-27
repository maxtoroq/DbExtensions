Database.Affect Method (SqlBuilder, Int32, AffectedRecordsPolicy)
=================================================================
Executes the *nonQuery* command in a new or existing transaction, and validates the affected records value before comitting.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public int Affect(
	SqlBuilder nonQuery,
	int affectingRecords,
	AffectedRecordsPolicy affectedMode
)
```

### Parameters

#### *nonQuery*
Type: [DbExtensions.SqlBuilder][2]  
The non-query command to execute.

#### *affectingRecords*
Type: [System.Int32][3]  
The number of records that the command should affect.

#### *affectedMode*
Type: [DbExtensions.AffectedRecordsPolicy][4]  
The criteria for validating the affected records value.

### Return Value
Type: [Int32][3]  
The number of affected records.

Exceptions
----------

Exception                   | Condition                                                                                                      
--------------------------- | -------------------------------------------------------------------------------------------------------------- 
[DBConcurrencyException][5] | The number of affected records is not valid according to the *affectingRecords* and *affectedMode* parameters. 


See Also
--------
[Database Class][6]  
[DbExtensions Namespace][1]  
[Extensions.Affect(IDbCommand, Int32, AffectedRecordsPolicy)][7]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: http://msdn.microsoft.com/en-us/library/td2s409d
[4]: ../AffectedRecordsPolicy/README.md
[5]: http://msdn.microsoft.com/en-us/library/bsdf9tb2
[6]: README.md
[7]: ../Extensions/Affect_1.md