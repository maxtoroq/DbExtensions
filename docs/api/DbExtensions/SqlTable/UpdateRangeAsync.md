SqlTable.UpdateRangeAsync(IEnumerable&lt;Object>, CancellationToken) Method
===========================================================================
Executes UPDATE commands for the specified *entities*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                            | Description                                            |
| --------------------------------------------------------------- | ------------------------------------------------------ |
| [UpdateRangeAsync(Object[])][2]                                 | Executes UPDATE commands for the specified *entities*. |
| **UpdateRangeAsync(IEnumerable&lt;Object>, CancellationToken)** | Executes UPDATE commands for the specified *entities*. |


Syntax
------

```csharp
public ValueTask UpdateRangeAsync(
	IEnumerable<Object> entities,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *entities*  [IEnumerable][3]&lt;[Object][4]>
The entities whose UPDATE commands are to be executed.

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
[2]: UpdateRangeAsync_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[6]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[7]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask
[8]: README.md