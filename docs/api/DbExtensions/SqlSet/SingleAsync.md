SqlSet.SingleAsync(SqlSet.OperatorStringHandler, CancellationToken) Method
==========================================================================
Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                      | Description                                                                                                                             |
| --------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| [SingleAsync(CancellationToken)][2]                       | The single element of the set.                                                                                                          |
| **SingleAsync(OperatorStringHandler, CancellationToken)** | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. |
| [SingleAsync(String, CancellationToken)][3]               | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. |


Syntax
------

```csharp
public ValueTask<Object> SingleAsync(
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
[ValueTask][6]&lt;[Object][7]>  
The single element of the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                                                                                                |
| ------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------- |
| [InvalidOperationException][8] | No element satisfies the condition in *predicate*.-or-More than one element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet Class][9]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: SingleAsync_2.md
[3]: SingleAsync_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[7]: https://learn.microsoft.com/dotnet/api/system.object
[8]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception
[9]: README.md