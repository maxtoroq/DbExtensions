SqlSet&lt;TResult>.Where Method (String)
========================================
Filters the set based on a predicate.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet<TResult> Where(
	string predicate
)
```

### Parameters

#### *predicate*
Type: [System.String][2]  
A SQL expression to test each row for a condition.

### Return Value
Type: [SqlSet][3]&lt;[TResult][3]>  
A new [SqlSet&lt;TResult>][3] that contains elements from the current set that satisfy the condition.

See Also
--------
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md