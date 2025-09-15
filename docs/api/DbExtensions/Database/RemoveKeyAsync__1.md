Database.RemoveKeyAsync&lt;TEntity> Method
==========================================
Executes a DELETE command for the entity whose primary key matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public ValueTask RemoveKeyAsync<TEntity>(
	Object id,
	CancellationToken cancellationToken = default
)
where TEntity : class

```

#### Parameters

##### *id*  [Object][2]
The primary key value.

##### *cancellationToken*  [CancellationToken][3]  (Optional)
The [CancellationToken][3] to monitor for cancellation requests. The default is [None][4].

#### Type Parameters

##### *TEntity*


#### Return Value
[ValueTask][5]

Remarks
-------
This method is a shortcut for `await db.Table<TEntity>().RemoveKeyAsync(id, cancellationToken)`.

See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][1]  
[SqlTable&lt;TEntity>.RemoveKeyAsync(Object, CancellationToken)][7]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[5]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask
[6]: README.md
[7]: ../SqlTable_1/RemoveKeyAsync.md