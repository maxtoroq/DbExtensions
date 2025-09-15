SqlSet&lt;TResult>.FindAsync Method
===================================
Gets the entity whose primary key matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public ValueTask<TResult> FindAsync(
	Object id,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *id*  [Object][2]
The primary key value.

##### *cancellationToken*  [CancellationToken][3]  (Optional)
The [CancellationToken][3] to monitor for cancellation requests. The default is [None][4].

#### Return Value
[ValueTask][5]&lt;[TResult][6]>  
 The entity whose primary key matches the *id* parameter, or null if the *id* does not exist.

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][7] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[5]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[6]: README.md
[7]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception