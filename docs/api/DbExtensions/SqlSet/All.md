SqlSet.All(SqlSet.SqlFragmentHandler) Method
============================================
Determines whether all elements of the set satisfy a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public bool All(
	ref SqlFragmentHandler predicate
)
```

#### Parameters

##### *predicate*  SqlFragmentHandler
A SQL expression to test each row for a condition.

#### Return Value
[Boolean][2]  
true if every element of the set passes the test in the specified *predicate*, or if the set is empty; otherwise, false.

See Also
--------

#### Reference
[SqlSet Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.boolean
[3]: README.md