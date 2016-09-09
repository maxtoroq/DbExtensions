Database.Execute Method (SqlBuilder, Int32, Boolean)
====================================================
Executes the *nonQuery* command. Optionally uses a transaction scope and validates affected records value before completing.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

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

##### *nonQuery*
Type: [DbExtensions.SqlBuilder][2]  
The non-query command to execute.

##### *affect* (Optional)
Type: [System.Int32][3]  
The number of records the command should affect. This value is ignored if less or equal to -1.

##### *exact* (Optional)
Type: [System.Boolean][4]  
true if the number of affected records should exactly match *affect*; false if a lower number is acceptable.

#### Return Value
Type: [Int32][3]  
The number of affected records.

Exceptions
----------

Exception                    | Condition                                                
---------------------------- | -------------------------------------------------------- 
[ChangeConflictException][5] | The number of affected records is not equal to *affect*. 


See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: http://msdn.microsoft.com/en-us/library/td2s409d
[4]: http://msdn.microsoft.com/en-us/library/a28wyd50
[5]: ../ChangeConflictException/README.md
[6]: README.md