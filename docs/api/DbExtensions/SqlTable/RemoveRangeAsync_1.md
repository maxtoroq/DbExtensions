SqlTable.RemoveRangeAsync(Object[]) Method
==========================================
Executes DELETE commands for the specified *entities*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                            |
| ---------------------------------------------------------------- | ------------------------------------------------------ |
| **RemoveRangeAsync(Object[])**                                   | Executes DELETE commands for the specified *entities*. |
| [RemoveRangeAsync(IEnumerable&lt;Object>, CancellationToken)][2] | Executes DELETE commands for the specified *entities*. |


Syntax
------

```csharp
public ValueTask RemoveRangeAsync(
	params Object[] entities
)
```

#### Parameters

##### *entities*  [Object][3][]
The entities whose DELETE commands are to be executed.

#### Return Value
[ValueTask][4]

See Also
--------

#### Reference
[SqlTable Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: RemoveRangeAsync.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask
[5]: README.md