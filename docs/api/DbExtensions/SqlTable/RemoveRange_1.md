SqlTable.RemoveRange(Object[]) Method
=====================================
Executes DELETE commands for the specified *entities*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                     | Description                                            |
| ---------------- | ---------------------------------------- | ------------------------------------------------------ |
| ![Public method] | [RemoveRange(IEnumerable&lt;Object>)][2] | Executes DELETE commands for the specified *entities*. |
| ![Public method] | **RemoveRange(Object[])**                | Executes DELETE commands for the specified *entities*. |


Syntax
------

```csharp
public void RemoveRange(
	params Object[] entities
)
```

#### Parameters

##### *entities*  [Object][3][]
The entities whose DELETE commands are to be executed.


See Also
--------

#### Reference
[SqlTable Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: RemoveRange.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"