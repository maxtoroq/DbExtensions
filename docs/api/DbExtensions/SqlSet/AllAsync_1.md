SqlSet.AllAsync(String, CancellationToken) Method
=================================================
Determines whether all elements of the set satisfy a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                    | Description                                                     |
| ------------------------------------------------------- | --------------------------------------------------------------- |
| [AllAsync(OperatorStringHandler, CancellationToken)][2] | Determines whether all elements of the set satisfy a condition. |
| **AllAsync(String, CancellationToken)**                 | Determines whether all elements of the set satisfy a condition. |


Syntax
------

```csharp
public ValueTask<bool> AllAsync(
	string predicate,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *predicate*  [String][3]
A SQL expression to test each row for a condition.

##### *cancellationToken*  [CancellationToken][4]  (Optional)
The [CancellationToken][4] to monitor for cancellation requests. The default is [None][5].

#### Return Value
[ValueTask][6]&lt;[Boolean][7]>  
`true` if every element of the set passes the test in the specified *predicate*, or if the set is empty; otherwise, `false`.

See Also
--------

#### Reference
[SqlSet Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AllAsync.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[7]: https://learn.microsoft.com/dotnet/api/system.boolean
[8]: README.md