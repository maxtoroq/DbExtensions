SqlSet.Union Method
===================
Produces the set union of the current set with *otherSet*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet Union(
	SqlSet otherSet
)
```

### Parameters

#### *otherSet*
Type: [DbExtensions.SqlSet][2]  
A [SqlSet][2] whose distinct elements form the second set for the union.

### Return Value
Type: [SqlSet][2]  
A new [SqlSet][2] that contains the elements from both sets, excluding duplicates.

See Also
--------
[SqlSet Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md