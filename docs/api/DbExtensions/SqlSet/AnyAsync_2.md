SqlSet.AnyAsync(CancellationToken) Method
=========================================
Determines whether the set contains any elements.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                    | Description                                                      |
| ------------------------------------------------------- | ---------------------------------------------------------------- |
| **AnyAsync(CancellationToken)**                         | Determines whether the set contains any elements.                |
| [AnyAsync(OperatorStringHandler, CancellationToken)][2] | Determines whether any element of the set satisfies a condition. |
| [AnyAsync(String, CancellationToken)][3]                | Determines whether any element of the set satisfies a condition. |


Syntax
------

```csharp
public ValueTask<bool> AnyAsync(
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *cancellationToken*  [CancellationToken][4]  (Optional)
The [CancellationToken][4] to monitor for cancellation requests. The default is [None][5].

#### Return Value
[ValueTask][6]&lt;[Boolean][7]>  
`true` if the sequence contains any elements; otherwise, `false`.

See Also
--------

#### Reference
[SqlSet Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AnyAsync.md
[3]: AnyAsync_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[7]: https://learn.microsoft.com/dotnet/api/system.boolean
[8]: README.md