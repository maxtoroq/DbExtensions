SqlTable&lt;TEntity>.RemoveRange(IEnumerable&lt;TEntity>) Method
================================================================
Executes DELETE commands for the specified *entities*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                     | Description                                            |
| ---------------- | ---------------------------------------- | ------------------------------------------------------ |
| ![Public method] | **RemoveRange(IEnumerable&lt;TEntity>)** | Executes DELETE commands for the specified *entities*. |
| ![Public method] | [RemoveRange(TEntity[])][2]              | Executes DELETE commands for the specified *entities*. |


Syntax
------

```csharp
public void RemoveRange(
	IEnumerable<TEntity> entities
)
```

#### Parameters

##### *entities*  [IEnumerable][3]&lt;[TEntity][4]>
The entities whose DELETE commands are to be executed.


See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: RemoveRange_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[4]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"