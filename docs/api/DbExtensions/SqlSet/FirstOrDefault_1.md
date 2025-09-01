SqlSet.FirstOrDefault(SqlSet.SqlFragmentHandler) Method
=======================================================
Returns the first element of the set that satisfies a condition or a default value if no such element is found.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                               | Description                                                                                                     |
| ---------------- | ---------------------------------- | --------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [FirstOrDefault()][2]              | Returns the first element of the set, or a default value if the set contains no elements.                       |
| ![Public method] | FirstOrDefault(SqlFragmentHandler) | Returns the first element of the set that satisfies a condition or a default value if no such element is found. |
| ![Public method] | [FirstOrDefault(String)][3]        | Returns the first element of the set that satisfies a condition or a default value if no such element is found. |


Syntax
------

```csharp
public Object? FirstOrDefault(
	ref SqlFragmentHandler? predicate
)
```

#### Parameters

##### *predicate*  SqlFragmentHandler
A SQL expression to test each row for a condition.

#### Return Value
[Object][4]  
 A default value if the set is empty or if no element passes the test specified by *predicate*; otherwise, the first element that passes the test specified by *predicate*.

See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FirstOrDefault.md
[3]: FirstOrDefault_2.md
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"