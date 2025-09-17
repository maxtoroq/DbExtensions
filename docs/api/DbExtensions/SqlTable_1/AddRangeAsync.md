SqlTable&lt;TEntity>.AddRangeAsync(IEnumerable&lt;TEntity>, CancellationToken) Method
=====================================================================================
Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                          | Description                                                                                                              |
| ------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| [AddRangeAsync(TEntity[])][2]                                 | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |
| **AddRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)** | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |


Syntax
------

```csharp
public ValueTask AddRangeAsync(
	IEnumerable<TEntity> entities,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *entities*  [IEnumerable][3]&lt;[TEntity][4]>
The entities whose INSERT commands are to be executed.

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
[2]: AddRangeAsync_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[4]: README.md
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[7]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask