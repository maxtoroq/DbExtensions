SqlSet.Any(SqlSet.OperatorStringHandler) Method
===============================================
Determines whether any element of the set satisfies a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                           | Description                                                      |
| ------------------------------ | ---------------------------------------------------------------- |
| [Any()][2]                     | Determines whether the set contains any elements.                |
| **Any(OperatorStringHandler)** | Determines whether any element of the set satisfies a condition. |
| [Any(String)][3]               | Determines whether any element of the set satisfies a condition. |


Syntax
------

```csharp
public bool Any(
	ref OperatorStringHandler predicate
)
```

#### Parameters

##### *predicate*  OperatorStringHandler
A SQL expression to test each row for a condition.

#### Return Value
[Boolean][4]  
`true` if any elements in the set pass the test in the specified *predicate*; otherwise, `false`.

See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Any.md
[3]: Any_2.md
[4]: https://learn.microsoft.com/dotnet/api/system.boolean
[5]: README.md