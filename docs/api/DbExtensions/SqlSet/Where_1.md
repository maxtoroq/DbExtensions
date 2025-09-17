SqlSet.Where(String) Method
===========================
Filters the set based on a predicate.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                              | Description                           |
| --------------------------------- | ------------------------------------- |
| [Where(OperatorStringHandler)][2] | Filters the set based on a predicate. |
| **Where(String)**                 | Filters the set based on a predicate. |


Syntax
------

```csharp
public SqlSet Where(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][3]
A SQL expression to test each row for a condition.

#### Return Value
[SqlSet][4]  
A new [SqlSet][4] that contains elements from the current set that satisfy the condition.

See Also
--------

#### Reference
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Where.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: README.md