SqlTable&lt;TEntity>.RemoveKeyAsync Method
==========================================
Executes a DELETE command for the entity whose primary key matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public ValueTask<bool> RemoveKeyAsync(
	Object id,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *id*  [Object][2]
The primary key value.

##### *cancellationToken*  [CancellationToken][3]  (Optional)
The [CancellationToken][3] to monitor for cancellation requests. The default is [None][4].

#### Return Value
[ValueTask][5]&lt;[Boolean][6]>  
`true` if a record that matches *id* was found and deleted; otherwise, `false`.

See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[5]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[6]: https://learn.microsoft.com/dotnet/api/system.boolean
[7]: README.md