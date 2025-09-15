Database.ExecuteAsync Method
============================
Executes the *nonQuery* command. Optionally uses a transaction and validates affected records value before committing.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public ValueTask<int> ExecuteAsync(
	SqlBuilder nonQuery,
	int affect = -1,
	bool exact = false,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *nonQuery*  [SqlBuilder][2]
The non-query command to execute.

##### *affect*  [Int32][3]  (Optional)
The number of records the command should affect. This value is ignored if less or equal to -1.

##### *exact*  [Boolean][4]  (Optional)
true if the number of affected records should exactly match *affect*; false if a lower number is acceptable.

##### *cancellationToken*  [CancellationToken][5]  (Optional)
The [CancellationToken][5] to monitor for cancellation requests. The default is [None][6].

#### Return Value
[ValueTask][7]&lt;[Int32][3]>  
The number of affected records.

Exceptions
----------

| Exception                    | Condition                                                |
| ---------------------------- | -------------------------------------------------------- |
| [ChangeConflictException][8] | The number of affected records is not equal to *affect*. |


See Also
--------

#### Reference
[Database Class][9]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: https://learn.microsoft.com/dotnet/api/system.int32
[4]: https://learn.microsoft.com/dotnet/api/system.boolean
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[7]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[8]: ../ChangeConflictException/README.md
[9]: README.md