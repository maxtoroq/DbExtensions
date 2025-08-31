Database.Execute Method
=======================
Executes the *nonQuery* command. Optionally uses a transaction and validates affected records value before committing.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

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

##### *nonQuery*  [SqlBuilder][2]
The non-query command to execute.

##### *affect*  [Int32][3]  (Optional)
The number of records the command should affect. This value is ignored if less or equal to -1.

##### *exact*  [Boolean][4]  (Optional)
true if the number of affected records should exactly match *affect*; false if a lower number is acceptable.

#### Return Value
[Int32][3]  
The number of affected records.

Exceptions
----------

| Exception                    | Condition                                                |
| ---------------------------- | -------------------------------------------------------- |
| [ChangeConflictException][5] | The number of affected records is not equal to *affect*. |


See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: https://learn.microsoft.com/dotnet/api/system.int32
[4]: https://learn.microsoft.com/dotnet/api/system.boolean
[5]: ../ChangeConflictException/README.md
[6]: README.md