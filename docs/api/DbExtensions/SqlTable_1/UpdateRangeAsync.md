SqlTable&lt;TEntity>.UpdateRangeAsync(IEnumerable&lt;TEntity>, CancellationToken) Method
========================================================================================
Executes UPDATE commands for the specified *entities*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                            |
| ---------------------------------------------------------------- | ------------------------------------------------------ |
| [UpdateRangeAsync(TEntity[])][2]                                 | Executes UPDATE commands for the specified *entities*. |
| **UpdateRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)** | Executes UPDATE commands for the specified *entities*. |


Syntax
------

```csharp
public ValueTask UpdateRangeAsync(
	IEnumerable<TEntity> entities,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *entities*  [IEnumerable][3]&lt;[TEntity][4]>
The entities whose UPDATE commands are to be executed.

##### *cancellationToken*  [CancellationToken][5]  (Optional)
The [CancellationToken][5] to monitor for cancellation requests. The default is [None][6].

#### Return Value
[ValueTask][7]

See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: UpdateRangeAsync_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[4]: README.md
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[7]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask