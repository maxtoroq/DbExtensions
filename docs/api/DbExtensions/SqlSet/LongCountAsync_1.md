SqlSet.LongCountAsync(String, CancellationToken) Method
=======================================================
Returns an [Int64][1] that represents how many elements in the set satisfy a condition.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                          | Description                                                                             |
| ------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| [LongCountAsync(CancellationToken)][3]                        | Returns an [Int64][1] that represents the total number of elements in the set.          |
| [LongCountAsync(OperatorStringHandler, CancellationToken)][4] | Returns an [Int64][1] that represents how many elements in the set satisfy a condition. |
| **LongCountAsync(String, CancellationToken)**                 | Returns an [Int64][1] that represents how many elements in the set satisfy a condition. |


Syntax
------

```csharp
public ValueTask<long> LongCountAsync(
	string predicate,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *predicate*  [String][5]
A SQL expression to test each row for a condition.

##### *cancellationToken*  [CancellationToken][6]  (Optional)
The [CancellationToken][6] to monitor for cancellation requests. The default is [None][7].

#### Return Value
[ValueTask][8]&lt;[Int64][1]>  
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
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.int64
[2]: ../README.md
[3]: LongCountAsync_2.md
[4]: LongCountAsync.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[7]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[8]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[9]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[10]: https://learn.microsoft.com/dotnet/api/system.int64.maxvalue
[11]: README.md