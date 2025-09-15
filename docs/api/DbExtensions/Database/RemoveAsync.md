Database.RemoveAsync Method
===========================
Executes a DELETE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public ValueTask RemoveAsync(
	Object entity,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *entity*  [Object][2]
The entity whose DELETE command is to be executed.

##### *cancellationToken*  [CancellationToken][3]  (Optional)
The [CancellationToken][3] to monitor for cancellation requests. The default is [None][4].

#### Return Value
[ValueTask][5]

Remarks
-------
This method is a shortcut for `await db.Table(entity.GetType()).RemoveAsync(entity, cancellationToken)`.

See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][1]  
[SqlTable.RemoveAsync(Object, CancellationToken)][7]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[5]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask
[6]: README.md
[7]: ../SqlTable/RemoveAsync.md