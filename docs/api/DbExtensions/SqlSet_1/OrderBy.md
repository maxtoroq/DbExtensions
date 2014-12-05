SqlSet&lt;TResult>.OrderBy Method (String)
==========================================
Sorts the elements of the set according to the *columnList*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet<TResult> OrderBy(
	string columnList
)
```

### Parameters

#### *columnList*
Type: [System.String][2]  
The list of columns to base the sort on.

### Return Value
Type: [SqlSet][3]&lt;[TResult][3]>  
A new [SqlSet&lt;TResult>][3] whose elements are sorted according to *columnList*.

See Also
--------

### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md