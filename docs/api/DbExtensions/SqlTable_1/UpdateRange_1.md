SqlTable&lt;TEntity>.UpdateRange(TEntity[]) Method
==================================================
Executes UPDATE commands for the specified *entities*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                      | Description                                            |
| ----------------------------------------- | ------------------------------------------------------ |
| [UpdateRange(IEnumerable&lt;TEntity>)][2] | Executes UPDATE commands for the specified *entities*. |
| **UpdateRange(TEntity[])**                | Executes UPDATE commands for the specified *entities*. |


Syntax
------

```csharp
public void UpdateRange(
	params TEntity[] entities
)
```

#### Parameters

##### *entities*  [TEntity][3][]
The entities whose UPDATE commands are to be executed.


See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: UpdateRange.md
[3]: README.md