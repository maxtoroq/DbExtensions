SqlSet&lt;TResult>.OrderBy Method (String, Object[])
====================================================
Sorts the elements of the set according to the *columnList*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet<TResult> OrderBy(
	string columnList,
	params Object[] parameters
)
```

### Parameters

#### *columnList*
Type: [System.String][2]  
The list of columns to base the sort on.

#### *parameters*
Type: [System.Object][3][]  
The parameters to apply to the *columnList*.

### Return Value
Type: [SqlSet][4]&lt;[TResult][4]>  
A new [SqlSet&lt;TResult>][4] whose elements are sorted according to *columnList*.

See Also
--------
[SqlSet&lt;TResult> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: README.md