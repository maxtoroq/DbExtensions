SqlSet&lt;TResult>.FirstOrDefault Method
========================================
Returns the first element of the set, or a default value if the set contains no elements.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                       | Description                                                                                                     |
| ------------------------------------------ | --------------------------------------------------------------------------------------------------------------- |
| **FirstOrDefault()**                       | Returns the first element of the set, or a default value if the set contains no elements.                       |
| [FirstOrDefault(OperatorStringHandler)][2] | Returns the first element of the set that satisfies a condition or a default value if no such element is found. |
| [FirstOrDefault(String)][3]                | Returns the first element of the set that satisfies a condition or a default value if no such element is found. |


Syntax
------

```csharp
public TResult FirstOrDefault()
```

#### Return Value
[TResult][4]  
A default value if the set is empty; otherwise, the first element.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FirstOrDefault_1.md
[3]: FirstOrDefault_2.md
[4]: README.md