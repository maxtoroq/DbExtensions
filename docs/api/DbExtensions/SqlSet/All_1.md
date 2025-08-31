SqlSet.All(String) Method
=========================
Determines whether all elements of the set satisfy a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public bool All(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][2]
A SQL expression to test each row for a condition.

#### Return Value
[Boolean][3]  
true if every element of the set passes the test in the specified *predicate*, or if the set is empty; otherwise, false.

See Also
--------

#### Reference
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: https://learn.microsoft.com/dotnet/api/system.boolean
[4]: README.md