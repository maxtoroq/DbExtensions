SqlSet&lt;TResult>.SingleAsync(String, CancellationToken) Method
================================================================
Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                       | Description                                                                                                                             |
| ---------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| [SingleAsync(CancellationToken)][2]                        | The single element of the set.                                                                                                          |
| [SingleAsync(OperatorStringHandler, CancellationToken)][3] | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. |
| **SingleAsync(String, CancellationToken)**                 | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. |


Syntax
------

```csharp
public ValueTask<TResult> SingleAsync(
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
The single element of the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                                                                                                |
| ------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------- |
| [InvalidOperationException][9] | No element satisfies the condition in *predicate*.-or-More than one element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: SingleAsync_2.md
[3]: SingleAsync.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[7]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[8]: README.md
[9]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception