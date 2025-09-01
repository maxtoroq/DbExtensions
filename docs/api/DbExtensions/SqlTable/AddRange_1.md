SqlTable.AddRange(Object[]) Method
==================================
Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                  | Description                                                                                                              |
| ---------------- | ------------------------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [AddRange(IEnumerable&lt;Object>)][2] | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |
| ![Public method] | **AddRange(Object[])**                | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |


Syntax
------

```csharp
public void AddRange(
	params Object[] entities
)
```

#### Parameters

##### *entities*  [Object][3][]
The entities whose INSERT commands are to be executed.


See Also
--------

#### Reference
[SqlTable Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AddRange.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"