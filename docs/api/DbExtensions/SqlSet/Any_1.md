SqlSet.Any Method (String)
==========================
Determines whether any element of the set satisfies a condition.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public bool Any(
	string predicate
)
```

### Parameters

#### *predicate*
Type: [System.String][2]  
A SQL expression to test each row for a condition.

### Return Value
Type: [Boolean][3]  
true if any elements in the set pass the test in the specified *predicate*; otherwise, false.

See Also
--------
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: README.md