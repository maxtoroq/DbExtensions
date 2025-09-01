SqlSet.Where Method
===================
Filters the set based on a predicate.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet Where(
	string predicate,
	params Object[] parameters
)
```

#### Parameters

##### *predicate*  [String][2]
A SQL expression to test each row for a condition.

##### *parameters*  [Object][3][]
The parameters to apply to the *predicate*.

#### Return Value
[SqlSet][4]  
A new [SqlSet][4] that contains elements from the current set that satisfy the condition.

See Also
--------

#### Reference
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: README.md