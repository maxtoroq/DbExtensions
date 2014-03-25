SqlSet&lt;TResult>.Union Method (SqlSet&lt;TResult>)
====================================================
Produces the set union of the current set with *otherSet*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet<TResult> Union(
	SqlSet<TResult> otherSet
)
```

### Parameters

#### *otherSet*
Type: [DbExtensions.SqlSet][2]&lt;[TResult][2]>  
A [SqlSet<TResult>][2] whose distinct elements form the second set for the union.

### Return Value
Type: [SqlSet][2]&lt;[TResult][2]>  
A new [SqlSet<TResult>][2] that contains the elements from both sets, excluding duplicates.

See Also
--------
[SqlSet<TResult> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md