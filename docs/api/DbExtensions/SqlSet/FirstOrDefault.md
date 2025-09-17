SqlSet.FirstOrDefault Method
============================
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
public Object? FirstOrDefault()
```

#### Return Value
[Object][4]  
A default value if the set is empty; otherwise, the first element.

See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FirstOrDefault_1.md
[3]: FirstOrDefault_2.md
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: README.md