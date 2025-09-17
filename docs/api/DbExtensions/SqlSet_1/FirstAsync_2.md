SqlSet&lt;TResult>.FirstAsync(CancellationToken) Method
=======================================================
Returns the first element of the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                      | Description                                                                |
| --------------------------------------------------------- | -------------------------------------------------------------------------- |
| **FirstAsync(CancellationToken)**                         | Returns the first element of the set.                                      |
| [FirstAsync(OperatorStringHandler, CancellationToken)][2] | Returns the first element in the set that satisfies a specified condition. |
| [FirstAsync(String, CancellationToken)][3]                | Returns the first element in the set that satisfies a specified condition. |


Syntax
------

```csharp
public ValueTask<TResult> FirstAsync(
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *cancellationToken*  [CancellationToken][4]  (Optional)
The [CancellationToken][4] to monitor for cancellation requests. The default is [None][5].

#### Return Value
[ValueTask][6]&lt;[TResult][7]>  
The first element in the set.

Exceptions
----------

| Exception                      | Condition         |
| ------------------------------ | ----------------- |
| [InvalidOperationException][8] | The set is empty. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FirstAsync.md
[3]: FirstAsync_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[7]: README.md
[8]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception