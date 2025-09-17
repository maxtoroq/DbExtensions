SqlSet&lt;TResult>.ContainsAsync(TResult, CancellationToken) Method
===================================================================
Checks the existance of the *entity*, using the primary key value.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                          | Description                                                        |
| --------------------------------------------- | ------------------------------------------------------------------ |
| [ContainsAsync(Object, CancellationToken)][2] | Checks the existance of the *entity*, using the primary key value. |
| **ContainsAsync(TResult, CancellationToken)** | Checks the existance of the *entity*, using the primary key value. |


Syntax
------

```csharp
public ValueTask<bool> ContainsAsync(
	TResult entity,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *entity*  [TResult][3]
The entity whose existance is to be checked.

##### *cancellationToken*  [CancellationToken][4]  (Optional)
The [CancellationToken][4] to monitor for cancellation requests. The default is [None][5].

#### Return Value
[ValueTask][6]&lt;[Boolean][7]>  
true if the primary key value exists in the database; otherwise false.

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][8] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlSet/ContainsAsync.md
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[7]: https://learn.microsoft.com/dotnet/api/system.boolean
[8]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception