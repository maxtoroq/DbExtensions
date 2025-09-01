SqlTable&lt;TEntity>.AddRange(IEnumerable&lt;TEntity>) Method
=============================================================
Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                  | Description                                                                                                              |
| ---------------- | ------------------------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | **AddRange(IEnumerable&lt;TEntity>)** | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |
| ![Public method] | [AddRange(TEntity[])][2]              | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |


Syntax
------

```csharp
public void AddRange(
	IEnumerable<TEntity> entities
)
```

#### Parameters

##### *entities*  [IEnumerable][3]&lt;[TEntity][4]>
The entities whose INSERT commands are to be executed.


See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AddRange_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[4]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"