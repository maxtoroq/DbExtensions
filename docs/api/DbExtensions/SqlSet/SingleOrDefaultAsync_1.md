SqlSet.SingleOrDefaultAsync(String, CancellationToken) Method
=============================================================
Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                | Description                                                                                                                                                                                              |
| ------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [SingleOrDefaultAsync(CancellationToken)][2]                        | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][3] | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| **SingleOrDefaultAsync(String, CancellationToken)**                 | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |


Syntax
------

```csharp
public ValueTask<Object> SingleOrDefaultAsync(
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
[ValueTask][7]&lt;[Object][8]>  
The single element of the set that satisfies the condition, or a default value if no such element is found.

See Also
--------

#### Reference
[SqlSet Class][9]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: SingleOrDefaultAsync_2.md
[3]: SingleOrDefaultAsync.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[7]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[8]: https://learn.microsoft.com/dotnet/api/system.object
[9]: README.md