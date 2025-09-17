SqlSet&lt;TResult>.FirstAsync(SqlSet.OperatorStringHandler, CancellationToken) Method
=====================================================================================
Returns the first element in the set that satisfies a specified condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                     | Description                                                                |
| -------------------------------------------------------- | -------------------------------------------------------------------------- |
| [FirstAsync(CancellationToken)][2]                       | Returns the first element of the set.                                      |
| **FirstAsync(OperatorStringHandler, CancellationToken)** | Returns the first element in the set that satisfies a specified condition. |
| [FirstAsync(String, CancellationToken)][3]               | Returns the first element in the set that satisfies a specified condition. |


Syntax
------

```csharp
public ValueTask<TResult> FirstAsync(
	OperatorStringHandler predicate,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *predicate*  OperatorStringHandler
A SQL expression to test each row for a condition.

##### *cancellationToken*  [CancellationToken][4]  (Optional)
The [CancellationToken][4] to monitor for cancellation requests. The default is [None][5].

#### Return Value
[ValueTask][6]&lt;[TResult][7]>  
The first element in the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                               |
| ------------------------------ | ----------------------------------------------------------------------- |
| [InvalidOperationException][8] | No element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FirstAsync_2.md
[3]: FirstAsync_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[7]: README.md
[8]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception