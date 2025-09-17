SqlSet.All(SqlSet.OperatorStringHandler) Method
===============================================
Determines whether all elements of the set satisfy a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                           | Description                                                     |
| ------------------------------ | --------------------------------------------------------------- |
| **All(OperatorStringHandler)** | Determines whether all elements of the set satisfy a condition. |
| [All(String)][2]               | Determines whether all elements of the set satisfy a condition. |


Syntax
------

```csharp
public bool All(
	ref OperatorStringHandler predicate
)
```

#### Parameters

##### *predicate*  OperatorStringHandler
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
[2]: All_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.boolean
[4]: README.md