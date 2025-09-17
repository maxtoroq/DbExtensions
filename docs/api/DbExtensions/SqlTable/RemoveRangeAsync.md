SqlTable.RemoveRangeAsync(IEnumerable&lt;Object>, CancellationToken) Method
===========================================================================
Executes DELETE commands for the specified *entities*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                            | Description                                            |
| --------------------------------------------------------------- | ------------------------------------------------------ |
| [RemoveRangeAsync(Object[])][2]                                 | Executes DELETE commands for the specified *entities*. |
| **RemoveRangeAsync(IEnumerable&lt;Object>, CancellationToken)** | Executes DELETE commands for the specified *entities*. |


Syntax
------

```csharp
public ValueTask RemoveRangeAsync(
	IEnumerable<Object> entities,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *entities*  [IEnumerable][3]&lt;[Object][4]>
The entities whose DELETE commands are to be executed.

##### *cancellationToken*  [CancellationToken][5]  (Optional)
The [CancellationToken][5] to monitor for cancellation requests. The default is [None][6].

#### Return Value
[ValueTask][7]

See Also
--------

#### Reference
[SqlTable Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: RemoveRangeAsync_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[7]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask
[8]: README.md