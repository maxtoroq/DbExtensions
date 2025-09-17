SqlSet.FirstOrDefaultAsync(SqlSet.OperatorStringHandler, CancellationToken) Method
==================================================================================
Returns the first element of the set that satisfies a condition or a default value if no such element is found.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                              | Description                                                                                                     |
| ----------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------- |
| [FirstOrDefaultAsync(CancellationToken)][2]                       | Returns the first element of the set, or a default value if the set contains no elements.                       |
| **FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)** | Returns the first element of the set that satisfies a condition or a default value if no such element is found. |
| [FirstOrDefaultAsync(String, CancellationToken)][3]               | Returns the first element of the set that satisfies a condition or a default value if no such element is found. |


Syntax
------

```csharp
public ValueTask<Object> FirstOrDefaultAsync(
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
 A default value if the set is empty or if no element passes the test specified by *predicate*; otherwise, the first element that passes the test specified by *predicate*.

See Also
--------

#### Reference
[SqlSet Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FirstOrDefaultAsync_2.md
[3]: FirstOrDefaultAsync_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[7]: https://learn.microsoft.com/dotnet/api/system.object
[8]: README.md