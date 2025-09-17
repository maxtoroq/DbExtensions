SqlSet.AllAsync(SqlSet.OperatorStringHandler, CancellationToken) Method
=======================================================================
Determines whether all elements of the set satisfy a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                   | Description                                                     |
| ------------------------------------------------------ | --------------------------------------------------------------- |
| **AllAsync(OperatorStringHandler, CancellationToken)** | Determines whether all elements of the set satisfy a condition. |
| [AllAsync(String, CancellationToken)][2]               | Determines whether all elements of the set satisfy a condition. |


Syntax
------

```csharp
public ValueTask<bool> AllAsync(
	OperatorStringHandler predicate,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *predicate*  OperatorStringHandler
A SQL expression to test each row for a condition.

##### *cancellationToken*  [CancellationToken][3]  (Optional)
The [CancellationToken][3] to monitor for cancellation requests. The default is [None][4].

#### Return Value
[ValueTask][5]&lt;[Boolean][6]>  
true if every element of the set passes the test in the specified *predicate*, or if the set is empty; otherwise, false.

See Also
--------

#### Reference
[SqlSet Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AllAsync_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[5]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[6]: https://learn.microsoft.com/dotnet/api/system.boolean
[7]: README.md