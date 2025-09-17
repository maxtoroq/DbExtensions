SqlTable&lt;TEntity>.UpdateAsync(TEntity, Object, CancellationToken) Method
===========================================================================
Executes an UPDATE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                | Description                                            |
| --------------------------------------------------- | ------------------------------------------------------ |
| [UpdateAsync(TEntity, CancellationToken)][2]        | Executes an UPDATE command for the specified *entity*. |
| **UpdateAsync(TEntity, Object, CancellationToken)** | Executes an UPDATE command for the specified *entity*. |


Syntax
------

```csharp
public ValueTask UpdateAsync(
	TEntity entity,
	Object? originalId,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *entity*  [TEntity][3]
The entity whose UPDATE command is to be executed.

##### *originalId*  [Object][4]
The original primary key value.

##### *cancellationToken*  [CancellationToken][5]  (Optional)
The [CancellationToken][5] to monitor for cancellation requests. The default is [None][6].

#### Return Value
[ValueTask][7]

Remarks
-------
This overload is helpful when the entity uses an assigned primary key.

See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: UpdateAsync_1.md
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[7]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask