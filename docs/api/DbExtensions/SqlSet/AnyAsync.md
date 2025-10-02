SqlSet.AnyAsync(SqlSet.OperatorStringHandler, CancellationToken) Method
=======================================================================
Determines whether any element of the set satisfies a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                   | Description                                                      |
| ------------------------------------------------------ | ---------------------------------------------------------------- |
| [AnyAsync(CancellationToken)][2]                       | Determines whether the set contains any elements.                |
| **AnyAsync(OperatorStringHandler, CancellationToken)** | Determines whether any element of the set satisfies a condition. |
| [AnyAsync(String, CancellationToken)][3]               | Determines whether any element of the set satisfies a condition. |


Syntax
------

```csharp
public ValueTask<bool> AnyAsync(
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
[ValueTask][6]&lt;[Boolean][7]>  
`true` if any elements in the set pass the test in the specified *predicate*; otherwise, `false`.

See Also
--------

#### Reference
[SqlSet Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AnyAsync_2.md
[3]: AnyAsync_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[7]: https://learn.microsoft.com/dotnet/api/system.boolean
[8]: README.md