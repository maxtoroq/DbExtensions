SqlSet.AnyAsync(String, CancellationToken) Method
=================================================
Determines whether any element of the set satisfies a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                    | Description                                                      |
| ------------------------------------------------------- | ---------------------------------------------------------------- |
| [AnyAsync(CancellationToken)][2]                        | Determines whether the set contains any elements.                |
| [AnyAsync(OperatorStringHandler, CancellationToken)][3] | Determines whether any element of the set satisfies a condition. |
| **AnyAsync(String, CancellationToken)**                 | Determines whether any element of the set satisfies a condition. |


Syntax
------

```csharp
public ValueTask<bool> AnyAsync(
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
[ValueTask][7]&lt;[Boolean][8]>  
true if any elements in the set pass the test in the specified *predicate*; otherwise, false.

See Also
--------

#### Reference
[SqlSet Class][9]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AnyAsync_2.md
[3]: AnyAsync.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[7]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[8]: https://learn.microsoft.com/dotnet/api/system.boolean
[9]: README.md