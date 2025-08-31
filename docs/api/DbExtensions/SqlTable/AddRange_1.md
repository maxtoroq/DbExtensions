SqlTable.AddRange(Object[]) Method
==================================
Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public void AddRange(
	params Object[] entities
)
```

#### Parameters

##### *entities*  [Object][2][]
The entities whose INSERT commands are to be executed.


See Also
--------

#### Reference
[SqlTable Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: README.md