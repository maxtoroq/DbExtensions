SqlTable&lt;TEntity>.UpdateRange(IEnumerable&lt;TEntity>) Method
================================================================
Executes UPDATE commands for the specified *entities*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                     | Description                                            |
| ---------------- | ---------------------------------------- | ------------------------------------------------------ |
| ![Public method] | **UpdateRange(IEnumerable&lt;TEntity>)** | Executes UPDATE commands for the specified *entities*. |
| ![Public method] | [UpdateRange(TEntity[])][2]              | Executes UPDATE commands for the specified *entities*. |


Syntax
------

```csharp
public void UpdateRange(
	IEnumerable<TEntity> entities
)
```

#### Parameters

##### *entities*  [IEnumerable][3]&lt;[TEntity][4]>
The entities whose UPDATE commands are to be executed.


See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: UpdateRange_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[4]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"