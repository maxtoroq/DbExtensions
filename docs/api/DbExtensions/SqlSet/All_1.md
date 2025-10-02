SqlSet.All(String) Method
=========================
Determines whether all elements of the set satisfy a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                            | Description                                                     |
| ------------------------------- | --------------------------------------------------------------- |
| [All(OperatorStringHandler)][2] | Determines whether all elements of the set satisfy a condition. |
| **All(String)**                 | Determines whether all elements of the set satisfy a condition. |


Syntax
------

```csharp
public bool All(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][3]
A SQL expression to test each row for a condition.

#### Return Value
[Boolean][4]  
`true` if every element of the set passes the test in the specified *predicate*, or if the set is empty; otherwise, `false`.

See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: All.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: https://learn.microsoft.com/dotnet/api/system.boolean
[5]: README.md