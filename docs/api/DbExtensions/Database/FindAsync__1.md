Database.FindAsync&lt;TEntity> Method
=====================================
Gets the entity whose primary key matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public ValueTask<TEntity> FindAsync<TEntity>(
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
The type of the entity.

#### Return Value
[ValueTask][5]&lt;**TEntity**>  
 The entity whose primary key matches the *id* parameter, or null if the *id* does not exist.

Remarks
-------
This method is a shortcut for `await db.Table<TEntity>().FindAsync(id, cancellationToken)`.

See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[5]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[6]: README.md