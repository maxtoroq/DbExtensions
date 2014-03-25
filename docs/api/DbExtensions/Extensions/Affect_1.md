Extensions.Affect Method (DbConnection, SqlBuilder, Int32, AffectedRecordsPolicy)
=================================================================================
Executes the *nonQuery* command in a new or existing transaction, and validates the affected records value before comitting.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static int Affect(
	this DbConnection connection,
	SqlBuilder nonQuery,
	int affectingRecords,
	AffectedRecordsPolicy affectedMode
)
```

### Parameters

#### *connection*
Type: [System.Data.Common.DbConnection][2]  
The connection.

#### *nonQuery*
Type: [DbExtensions.SqlBuilder][3]  
The non-query command to execute.

#### *affectingRecords*
Type: [System.Int32][4]  
The number of records that the command must affect, otherwise the transaction is rolledback.

#### *affectedMode*
Type: [DbExtensions.AffectedRecordsPolicy][5]  
The criteria for validating the affected records value.

### Return Value
Type: [Int32][4]  
The number of affected records.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbConnection][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

Exceptions
----------

Exception                   | Condition                                                                                                      
--------------------------- | -------------------------------------------------------------------------------------------------------------- 
[DBConcurrencyException][8] | The number of affected records is not valid according to the *affectingRecords* and *affectedMode* parameters. 


See Also
--------
[Extensions Class][9]  
[DbExtensions Namespace][1]  
[Extensions.Affect(IDbCommand, Int32, AffectedRecordsPolicy)][10]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/c790zwhc
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/td2s409d
[5]: ../AffectedRecordsPolicy/README.md
[6]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[7]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[8]: http://msdn.microsoft.com/en-us/library/bsdf9tb2
[9]: README.md
[10]: Affect_5.md