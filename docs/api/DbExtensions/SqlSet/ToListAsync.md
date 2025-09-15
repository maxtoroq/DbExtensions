SqlSet.ToListAsync Method
=========================
Creates a List&lt;object> from the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public ValueTask<List<Object>> ToListAsync(
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *cancellationToken*  [CancellationToken][2]  (Optional)
The [CancellationToken][2] to monitor for cancellation requests. The default is [None][3].

#### Return Value
[ValueTask][4]&lt;[List][5]&lt;[Object][6]>>  
A List&lt;object> that contains elements from the set.

See Also
--------

#### Reference
[SqlSet Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[3]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[4]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[5]: https://learn.microsoft.com/dotnet/api/system.collections.generic.list-1
[6]: https://learn.microsoft.com/dotnet/api/system.object
[7]: README.md