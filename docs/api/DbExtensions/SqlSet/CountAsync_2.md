SqlSet.CountAsync(CancellationToken) Method
===========================================
Returns the number of elements in the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                      | Description                                                                        |
| --------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| **CountAsync(CancellationToken)**                         | Returns the number of elements in the set.                                         |
| [CountAsync(OperatorStringHandler, CancellationToken)][2] | Returns a number that represents how many elements in the set satisfy a condition. |
| [CountAsync(String, CancellationToken)][3]                | Returns a number that represents how many elements in the set satisfy a condition. |


Syntax
------

```csharp
public ValueTask<int> CountAsync(
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *cancellationToken*  [CancellationToken][4]  (Optional)
The [CancellationToken][4] to monitor for cancellation requests. The default is [None][5].

#### Return Value
[ValueTask][6]&lt;[Int32][7]>  
The number of elements in the set.

Exceptions
----------

| Exception              | Condition                                            |
| ---------------------- | ---------------------------------------------------- |
| [OverflowException][8] | The number of elements is larger than [MaxValue][9]. |


See Also
--------

#### Reference
[SqlSet Class][10]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: CountAsync.md
[3]: CountAsync_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[7]: https://learn.microsoft.com/dotnet/api/system.int32
[8]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[9]: https://learn.microsoft.com/dotnet/api/system.int32.maxvalue
[10]: README.md