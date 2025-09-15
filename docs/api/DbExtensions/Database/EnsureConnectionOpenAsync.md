Database.EnsureConnectionOpenAsync Method
=========================================
Opens [Connection][1] (if it's not open) and returns an [IAsyncDisposable][2] object you can use to close it (if it wasn't open).
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public ValueTask<IAsyncDisposable> EnsureConnectionOpenAsync(
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *cancellationToken*  [CancellationToken][4]  (Optional)
The [CancellationToken][4] to monitor for cancellation requests. The default is [None][5].

#### Return Value
[ValueTask][6]&lt;[IAsyncDisposable][2]>  
An [IAsyncDisposable][2] object to close the connection.

Remarks
-------
Use this method with the `using` statement in C# or Visual Basic to ensure that a block of code is always executed with an open connection.

Example
-------

```csharp
await using (await db.EnsureConnectionOpenAsync()) {
  // Execute commands.
}
```


See Also
--------

#### Reference
[Database Class][7]  
[DbExtensions Namespace][3]  

[1]: Connection.md
[2]: https://learn.microsoft.com/dotnet/api/system.iasyncdisposable
[3]: ../README.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[7]: README.md