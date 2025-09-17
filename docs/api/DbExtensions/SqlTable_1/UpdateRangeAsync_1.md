SqlTable&lt;TEntity>.UpdateRangeAsync(TEntity[]) Method
=======================================================
Executes UPDATE commands for the specified *entities*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                              | Description                                            |
| ----------------------------------------------------------------- | ------------------------------------------------------ |
| **UpdateRangeAsync(TEntity[])**                                   | Executes UPDATE commands for the specified *entities*. |
| [UpdateRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][2] | Executes UPDATE commands for the specified *entities*. |


Syntax
------

```csharp
public ValueTask UpdateRangeAsync(
	params TEntity[] entities
)
```

#### Parameters

##### *entities*  [TEntity][3][]
The entities whose UPDATE commands are to be executed.

#### Return Value
[ValueTask][4]

See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: UpdateRangeAsync.md
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask