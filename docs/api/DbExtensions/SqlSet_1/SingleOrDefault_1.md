SqlSet&lt;TResult>.SingleOrDefault Method (String)
==================================================
Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public TResult SingleOrDefault(
	string predicate
)
```

### Parameters

#### *predicate*
Type: [System.String][2]  
A SQL expression to test each row for a condition.

### Return Value
Type: [TResult][3]  
The single element of the set that satisfies the condition, or a default value if no such element is found.

See Also
--------
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md