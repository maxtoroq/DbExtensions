Database.LastInsertIdAsync Method
=================================
Gets the identity value of the last inserted record.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public virtual ValueTask<Object> LastInsertIdAsync(
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *cancellationToken*  [CancellationToken][2]  (Optional)
The [CancellationToken][2] to monitor for cancellation requests. The default is [None][3].

#### Return Value
[ValueTask][4]&lt;[Object][5]>  
The identity value of the last inserted record.

Remarks
-------
It is very important to keep the connection open between the last command and this one, or else you might get the wrong value.

See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[3]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[4]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[5]: https://learn.microsoft.com/dotnet/api/system.object
[6]: README.md