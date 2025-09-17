SqlSet.LongCountAsync(SqlSet.OperatorStringHandler, CancellationToken) Method
=============================================================================
Returns an [Int64][1] that represents how many elements in the set satisfy a condition.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                         | Description                                                                             |
| ------------------------------------------------------------ | --------------------------------------------------------------------------------------- |
| [LongCountAsync(CancellationToken)][3]                       | Returns an [Int64][1] that represents the total number of elements in the set.          |
| **LongCountAsync(OperatorStringHandler, CancellationToken)** | Returns an [Int64][1] that represents how many elements in the set satisfy a condition. |
| [LongCountAsync(String, CancellationToken)][4]               | Returns an [Int64][1] that represents how many elements in the set satisfy a condition. |


Syntax
------

```csharp
public ValueTask<long> LongCountAsync(
	OperatorStringHandler predicate,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *predicate*  OperatorStringHandler
A SQL expression to test each row for a condition.

##### *cancellationToken*  [CancellationToken][5]  (Optional)
The [CancellationToken][5] to monitor for cancellation requests. The default is [None][6].

#### Return Value
[ValueTask][7]&lt;[Int64][1]>  
A number that represents how many elements in the set satisfy the condition in the *predicate*.

Exceptions
----------

| Exception              | Condition                                              |
| ---------------------- | ------------------------------------------------------ |
| [OverflowException][8] | The number of matching elements exceeds [MaxValue][9]. |


See Also
--------

#### Reference
[SqlSet Class][10]  
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.int64
[2]: ../README.md
[3]: LongCountAsync_2.md
[4]: LongCountAsync_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[7]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[8]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[9]: https://learn.microsoft.com/dotnet/api/system.int64.maxvalue
[10]: README.md