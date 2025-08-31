SqlTable&lt;TEntity>.AddRange(IEnumerable&lt;TEntity>) Method
=============================================================
Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public void AddRange(
	IEnumerable<TEntity> entities
)
```

#### Parameters

##### *entities*  [IEnumerable][2]&lt;[TEntity][3]>
The entities whose INSERT commands are to be executed.


See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[3]: README.md