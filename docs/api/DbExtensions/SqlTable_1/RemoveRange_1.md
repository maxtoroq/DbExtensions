SqlTable&lt;TEntity>.RemoveRange(TEntity[]) Method
==================================================
Executes DELETE commands for the specified *entities*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                      | Description                                            |
| ----------------------------------------- | ------------------------------------------------------ |
| [RemoveRange(IEnumerable&lt;TEntity>)][2] | Executes DELETE commands for the specified *entities*. |
| **RemoveRange(TEntity[])**                | Executes DELETE commands for the specified *entities*. |


Syntax
------

```csharp
public void RemoveRange(
	params TEntity[] entities
)
```

#### Parameters

##### *entities*  [TEntity][3][]
The entities whose DELETE commands are to be executed.


See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: RemoveRange.md
[3]: README.md