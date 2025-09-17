SqlSet&lt;TResult>.FirstOrDefaultAsync(CancellationToken) Method
================================================================
Returns the first element of the set, or a default value if the set contains no elements.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                               | Description                                                                                                     |
| ------------------------------------------------------------------ | --------------------------------------------------------------------------------------------------------------- |
| **FirstOrDefaultAsync(CancellationToken)**                         | Returns the first element of the set, or a default value if the set contains no elements.                       |
| [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][2] | Returns the first element of the set that satisfies a condition or a default value if no such element is found. |
| [FirstOrDefaultAsync(String, CancellationToken)][3]                | Returns the first element of the set that satisfies a condition or a default value if no such element is found. |


Syntax
------

```csharp
public ValueTask<TResult> FirstOrDefaultAsync(
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *cancellationToken*  [CancellationToken][4]  (Optional)
The [CancellationToken][4] to monitor for cancellation requests. The default is [None][5].

#### Return Value
[ValueTask][6]&lt;[TResult][7]>  
A default value if the set is empty; otherwise, the first element.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FirstOrDefaultAsync.md
[3]: FirstOrDefaultAsync_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[7]: README.md