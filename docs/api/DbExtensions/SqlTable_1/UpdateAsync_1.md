SqlTable&lt;TEntity>.UpdateAsync(TEntity, CancellationToken) Method
===================================================================
Executes an UPDATE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                 | Description                                            |
| ---------------------------------------------------- | ------------------------------------------------------ |
| **UpdateAsync(TEntity, CancellationToken)**          | Executes an UPDATE command for the specified *entity*. |
| [UpdateAsync(TEntity, Object, CancellationToken)][2] | Executes an UPDATE command for the specified *entity*. |


Syntax
------

```csharp
public ValueTask UpdateAsync(
	TEntity entity,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *entity*  [TEntity][3]
The entity whose UPDATE command is to be executed.

##### *cancellationToken*  [CancellationToken][4]  (Optional)
The [CancellationToken][4] to monitor for cancellation requests. The default is [None][5].

#### Return Value
[ValueTask][6]

See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: UpdateAsync.md
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask