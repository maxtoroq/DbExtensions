SqlTable.AddAsync Method
========================
Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public ValueTask AddAsync(
	Object entity,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *entity*  [Object][2]
The object whose INSERT command is to be executed. This parameter is named entity for consistency with the other CRUD methods, but in this case it doesn't need to be an actual entity, which means it doesn't need to have a primary key.

##### *cancellationToken*  [CancellationToken][3]  (Optional)
The [CancellationToken][3] to monitor for cancellation requests. The default is [None][4].

#### Return Value
[ValueTask][5]

See Also
--------

#### Reference
[SqlTable Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[5]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask
[6]: README.md