SqlSet&lt;TResult>.FirstAsync(String, CancellationToken) Method
===============================================================
Returns the first element in the set that satisfies a specified condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                      | Description                                                                |
| --------------------------------------------------------- | -------------------------------------------------------------------------- |
| [FirstAsync(CancellationToken)][2]                        | Returns the first element of the set.                                      |
| [FirstAsync(OperatorStringHandler, CancellationToken)][3] | Returns the first element in the set that satisfies a specified condition. |
| **FirstAsync(String, CancellationToken)**                 | Returns the first element in the set that satisfies a specified condition. |


Syntax
------

```csharp
public ValueTask<TResult> FirstAsync(
	string predicate,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *predicate*  [String][4]
A SQL expression to test each row for a condition.

##### *cancellationToken*  [CancellationToken][5]  (Optional)
The [CancellationToken][5] to monitor for cancellation requests. The default is [None][6].

#### Return Value
[ValueTask][7]&lt;[TResult][8]>  
The first element in the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                               |
| ------------------------------ | ----------------------------------------------------------------------- |
| [InvalidOperationException][9] | No element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FirstAsync_2.md
[3]: FirstAsync.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[7]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[8]: README.md
[9]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception