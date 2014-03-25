SqlSet&lt;TResult>.FirstOrDefault Method (String, Object[])
===========================================================
Returns the first element of the set that satisfies a condition or a default value if no such element is found.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public TResult FirstOrDefault(
	string predicate,
	params Object[] parameters
)
```

### Parameters

#### *predicate*
Type: [System.String][2]  
A SQL expression to test each row for a condition.

#### *parameters*
Type: [System.Object][3][]  
The parameters to apply to the *predicate*.

### Return Value
Type: [TResult][4]  
 A default value if the set is empty or if no element passes the test specified by *predicate*; otherwise, the first element that passes the test specified by *predicate*. 

See Also
--------
[SqlSet<TResult> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: README.md