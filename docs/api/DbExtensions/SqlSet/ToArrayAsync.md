SqlSet.ToArrayAsync Method
==========================
Creates an array from the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public ValueTask<Object[]> ToArrayAsync(
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *cancellationToken*  [CancellationToken][2]  (Optional)
The [CancellationToken][2] to monitor for cancellation requests. The default is [None][3].

#### Return Value
[ValueTask][4]&lt;[Object][5][]>  
An array that contains the elements from the set.

See Also
--------

#### Reference
[SqlSet Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[3]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[4]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[5]: https://learn.microsoft.com/dotnet/api/system.object
[6]: README.md