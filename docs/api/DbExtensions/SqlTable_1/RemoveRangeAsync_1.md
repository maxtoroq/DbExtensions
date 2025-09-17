SqlTable&lt;TEntity>.RemoveRangeAsync(TEntity[]) Method
=======================================================
Executes DELETE commands for the specified *entities*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                              | Description                                            |
| ----------------------------------------------------------------- | ------------------------------------------------------ |
| **RemoveRangeAsync(TEntity[])**                                   | Executes DELETE commands for the specified *entities*. |
| [RemoveRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][2] | Executes DELETE commands for the specified *entities*. |


Syntax
------

```csharp
public ValueTask RemoveRangeAsync(
	params TEntity[] entities
)
```

#### Parameters

##### *entities*  [TEntity][3][]
The entities whose DELETE commands are to be executed.

#### Return Value
[ValueTask][4]

See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: RemoveRangeAsync.md
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask