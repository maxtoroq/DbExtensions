Extensions.Affect Method (IDbCommand, Int32, AffectedRecordsPolicy, TextWriter)
===============================================================================
Executes the *command* in a new or existing transaction, and validates the affected records value before comitting.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static int Affect(
	this IDbCommand command,
	int affectingRecords,
	AffectedRecordsPolicy affectedMode,
	TextWriter logger
)
```

#### Parameters

##### *command*
Type: [System.Data.IDbCommand][2]  
The non-query command to execute.

##### *affectingRecords*
Type: [System.Int32][3]  
The number of records that the command should affect.

##### *affectedMode*
Type: [DbExtensions.AffectedRecordsPolicy][4]  
The criteria for validating the affected records value.

##### *logger*
Type: [System.IO.TextWriter][5]  
A [TextWriter][5] for logging the whole process.

#### Return Value
Type: [Int32][3]  
The number of affected records.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDbCommand][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

Exceptions
----------

Exception                   | Condition                                                                                                      
--------------------------- | -------------------------------------------------------------------------------------------------------------- 
[DBConcurrencyException][8] | The number of affected records is not valid according to the *affectingRecords* and *affectedMode* parameters. 


See Also
--------

#### Reference
[Extensions Class][9]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/bt2afddc
[3]: http://msdn.microsoft.com/en-us/library/td2s409d
[4]: ../AffectedRecordsPolicy/README.md
[5]: http://msdn.microsoft.com/en-us/library/ywxh2328
[6]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[7]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[8]: http://msdn.microsoft.com/en-us/library/bsdf9tb2
[9]: README.md