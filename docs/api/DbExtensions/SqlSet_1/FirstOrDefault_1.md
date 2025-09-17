SqlSet&lt;TResult>.FirstOrDefault(SqlSet.OperatorStringHandler) Method
======================================================================
Returns the first element of the set that satisfies a condition or a default value if no such element is found.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                      | Description                                                                                                     |
| ----------------------------------------- | --------------------------------------------------------------------------------------------------------------- |
| [FirstOrDefault()][2]                     | Returns the first element of the set, or a default value if the set contains no elements.                       |
| **FirstOrDefault(OperatorStringHandler)** | Returns the first element of the set that satisfies a condition or a default value if no such element is found. |
| [FirstOrDefault(String)][3]               | Returns the first element of the set that satisfies a condition or a default value if no such element is found. |


Syntax
------

```csharp
public TResult FirstOrDefault(
	ref OperatorStringHandler? predicate
)
```

#### Parameters

##### *predicate*  OperatorStringHandler
A SQL expression to test each row for a condition.

#### Return Value
[TResult][4]  
 A default value if the set is empty or if no element passes the test specified by *predicate*; otherwise, the first element that passes the test specified by *predicate*.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FirstOrDefault.md
[3]: FirstOrDefault_2.md
[4]: README.md