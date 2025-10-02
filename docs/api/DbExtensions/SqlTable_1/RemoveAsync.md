SqlTable&lt;TEntity>.RemoveAsync Method
=======================================
Executes a DELETE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public ValueTask<bool> RemoveAsync(
	TEntity entity,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *entity*  [TEntity][2]
The entity whose DELETE command is to be executed.

##### *cancellationToken*  [CancellationToken][3]  (Optional)
The [CancellationToken][3] to monitor for cancellation requests. The default is [None][4].

#### Return Value
[ValueTask][5]&lt;[Boolean][6]>  
`true` if *entity* is deleted; otherwise, `false`.

See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[5]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[6]: https://learn.microsoft.com/dotnet/api/system.boolean