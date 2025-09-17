SqlTable.AddRangeAsync(Object[]) Method
=======================================
Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                          | Description                                                                                                              |
| ------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| **AddRangeAsync(Object[])**                                   | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |
| [AddRangeAsync(IEnumerable&lt;Object>, CancellationToken)][2] | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations. |


Syntax
------

```csharp
public ValueTask AddRangeAsync(
	params Object[] entities
)
```

#### Parameters

##### *entities*  [Object][3][]
The entities whose INSERT commands are to be executed.

#### Return Value
[ValueTask][4]

See Also
--------

#### Reference
[SqlTable Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AddRangeAsync.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask
[5]: README.md