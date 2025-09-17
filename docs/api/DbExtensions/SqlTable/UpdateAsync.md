SqlTable.UpdateAsync(Object, Object, CancellationToken) Method
==============================================================
Executes an UPDATE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                               | Description                                            |
| -------------------------------------------------- | ------------------------------------------------------ |
| [UpdateAsync(Object, CancellationToken)][2]        | Executes an UPDATE command for the specified *entity*. |
| **UpdateAsync(Object, Object, CancellationToken)** | Executes an UPDATE command for the specified *entity*. |


Syntax
------

```csharp
public ValueTask UpdateAsync(
	Object entity,
	Object? originalId,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *entity*  [Object][3]
The entity whose UPDATE command is to be executed.

##### *originalId*  [Object][3]
The original primary key value.

##### *cancellationToken*  [CancellationToken][4]  (Optional)
The [CancellationToken][4] to monitor for cancellation requests. The default is [None][5].

#### Return Value
[ValueTask][6]

Remarks
-------
This overload is helpful when the entity uses an assigned primary key.

See Also
--------

#### Reference
[SqlTable Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: UpdateAsync_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask
[7]: README.md