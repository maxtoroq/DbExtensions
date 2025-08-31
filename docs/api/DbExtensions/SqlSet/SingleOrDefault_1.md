SqlSet.SingleOrDefault(SqlSet.SqlFragmentHandler) Method
========================================================
Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public Object? SingleOrDefault(
	ref SqlFragmentHandler? predicate
)
```

#### Parameters

##### *predicate*  SqlFragmentHandler
A SQL expression to test each row for a condition.

#### Return Value
[Object][2]  
The single element of the set that satisfies the condition, or a default value if no such element is found.

See Also
--------

#### Reference
[SqlSet Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: README.md