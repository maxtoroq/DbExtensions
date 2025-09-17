SqlTable.AddRange(IEnumerable&lt;Object>) Method
================================================
Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                 | Description                                                                                                              |
| ------------------------------------ | ------------------------------------------------------------------------------------------------------------------------ |
| **AddRange(IEnumerable&lt;Object>)** | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |
| [AddRange(Object[])][2]              | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |


Syntax
------

```csharp
public void AddRange(
	IEnumerable<Object> entities
)
```

#### Parameters

##### *entities*  [IEnumerable][3]&lt;[Object][4]>
The entities whose INSERT commands are to be executed.


See Also
--------

#### Reference
[SqlTable Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AddRange_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: README.md