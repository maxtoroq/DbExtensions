SqlSet&lt;TResult>.Take Method
==============================
Returns a specified number of contiguous elements from the start of the set.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet<TResult> Take(
	int count
)
```

### Parameters

#### *count*
Type: [System.Int32][2]  
The number of elements to return.

### Return Value
Type: [SqlSet][3]&lt;[TResult][3]>  
A new [SqlSet][4] that contains the specified number of elements from the start of the current set.

See Also
--------
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/td2s409d
[3]: README.md
[4]: ../SqlSet/README.md