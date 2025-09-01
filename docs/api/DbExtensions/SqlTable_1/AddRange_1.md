SqlTable&lt;TEntity>.AddRange(TEntity[]) Method
===============================================
Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                   | Description                                                                                                              |
| ---------------- | -------------------------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [AddRange(IEnumerable&lt;TEntity>)][2] | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |
| ![Public method] | **AddRange(TEntity[])**                | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |


Syntax
------

```csharp
public void AddRange(
	params TEntity[] entities
)
```

#### Parameters

##### *entities*  [TEntity][3][]
The entities whose INSERT commands are to be executed.


See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AddRange.md
[3]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"