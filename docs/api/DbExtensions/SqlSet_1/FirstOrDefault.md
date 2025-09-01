SqlSet&lt;TResult>.FirstOrDefault Method
========================================
Returns the first element of the set, or a default value if the set contains no elements.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                  | Description                                                                                                     |
| ---------------- | ------------------------------------- | --------------------------------------------------------------------------------------------------------------- |
| ![Public method] | **FirstOrDefault()**                  | Returns the first element of the set, or a default value if the set contains no elements.                       |
| ![Public method] | [FirstOrDefault(String, Object[])][2] | Returns the first element of the set that satisfies a condition or a default value if no such element is found. |


Syntax
------

```csharp
public TResult FirstOrDefault()
```

#### Return Value
[TResult][3]  
A default value if the set is empty; otherwise, the first element.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FirstOrDefault_1.md
[3]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"