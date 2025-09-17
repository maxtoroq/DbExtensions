SqlSet&lt;TResult>.GetAsyncEnumerator Method
============================================
Returns an async enumerator that iterates through the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public IAsyncEnumerator<TResult> GetAsyncEnumerator(
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *cancellationToken*  [CancellationToken][2]  (Optional)
The [CancellationToken][2] to monitor for cancellation requests. The default is [None][3].

#### Return Value
[IAsyncEnumerator][4]&lt;[TResult][5]>  
A [IAsyncEnumerator&lt;T>][4] for the set.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[3]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[4]: https://learn.microsoft.com/dotnet/api/system.collections.generic.iasyncenumerator-1
[5]: README.md