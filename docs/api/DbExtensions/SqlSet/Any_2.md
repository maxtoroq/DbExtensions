SqlSet.Any(String) Method
=========================
Determines whether any element of the set satisfies a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                            | Description                                                      |
| ------------------------------- | ---------------------------------------------------------------- |
| [Any()][2]                      | Determines whether the set contains any elements.                |
| [Any(OperatorStringHandler)][3] | Determines whether any element of the set satisfies a condition. |
| **Any(String)**                 | Determines whether any element of the set satisfies a condition. |


Syntax
------

```csharp
public bool Any(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][4]
A SQL expression to test each row for a condition.

#### Return Value
[Boolean][5]  
`true` if any elements in the set pass the test in the specified *predicate*; otherwise, `false`.

See Also
--------

#### Reference
[SqlSet Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Any.md
[3]: Any_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: https://learn.microsoft.com/dotnet/api/system.boolean
[6]: README.md