SqlSet.CountAsync(String, CancellationToken) Method
===================================================
Returns a number that represents how many elements in the set satisfy a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                      | Description                                                                        |
| --------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| [CountAsync(CancellationToken)][2]                        | Returns the number of elements in the set.                                         |
| [CountAsync(OperatorStringHandler, CancellationToken)][3] | Returns a number that represents how many elements in the set satisfy a condition. |
| **CountAsync(String, CancellationToken)**                 | Returns a number that represents how many elements in the set satisfy a condition. |


Syntax
------

```csharp
public ValueTask<int> CountAsync(
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
[ValueTask][7]&lt;[Int32][8]>  
A number that represents how many elements in the set satisfy the condition in the *predicate*.

Exceptions
----------

| Exception              | Condition                                               |
| ---------------------- | ------------------------------------------------------- |
| [OverflowException][9] | The number of matching elements exceeds [MaxValue][10]. |


See Also
--------

#### Reference
[SqlSet Class][11]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: CountAsync_2.md
[3]: CountAsync.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[7]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[8]: https://learn.microsoft.com/dotnet/api/system.int32
[9]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[10]: https://learn.microsoft.com/dotnet/api/system.int32.maxvalue
[11]: README.md