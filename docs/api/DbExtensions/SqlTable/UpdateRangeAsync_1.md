SqlTable.UpdateRangeAsync(Object[]) Method
==========================================
Executes UPDATE commands for the specified *entities*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                            |
| ---------------------------------------------------------------- | ------------------------------------------------------ |
| **UpdateRangeAsync(Object[])**                                   | Executes UPDATE commands for the specified *entities*. |
| [UpdateRangeAsync(IEnumerable&lt;Object>, CancellationToken)][2] | Executes UPDATE commands for the specified *entities*. |


Syntax
------

```csharp
public ValueTask UpdateRangeAsync(
	params Object[] entities
)
```

#### Parameters

##### *entities*  [Object][3][]
The entities whose UPDATE commands are to be executed.

#### Return Value
[ValueTask][4]

See Also
--------

#### Reference
[SqlTable Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: UpdateRangeAsync.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask
[5]: README.md