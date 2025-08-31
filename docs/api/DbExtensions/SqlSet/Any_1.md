SqlSet.Any(SqlSet.SqlFragmentHandler) Method
============================================
Determines whether any element of the set satisfies a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public bool Any(
	ref SqlFragmentHandler predicate
)
```

#### Parameters

##### *predicate*  SqlFragmentHandler
A SQL expression to test each row for a condition.

#### Return Value
[Boolean][2]  
true if any elements in the set pass the test in the specified *predicate*; otherwise, false.

See Also
--------

#### Reference
[SqlSet Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.boolean
[3]: README.md