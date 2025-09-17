SqlTable&lt;TEntity>.AddRangeAsync(TEntity[]) Method
====================================================
Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                           | Description                                                                                                              |
| -------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| **AddRangeAsync(TEntity[])**                                   | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |
| [AddRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][2] | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |


Syntax
------

```csharp
public ValueTask AddRangeAsync(
	params TEntity[] entities
)
```

#### Parameters

##### *entities*  [TEntity][3][]
The entities whose INSERT commands are to be executed.

#### Return Value
[ValueTask][4]

See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AddRangeAsync.md
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask