SqlSet.Where(String) Method
===========================
Filters the set based on a predicate.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet Where(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][2]
A SQL expression to test each row for a condition.

#### Return Value
[SqlSet][3]  
A new [SqlSet][3] that contains elements from the current set that satisfy the condition.

See Also
--------

#### Reference
[SqlSet Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: README.md