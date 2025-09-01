SqlSet.FirstOrDefault(String, Object[]) Method
==============================================
Returns the first element of the set that satisfies a condition or a default value if no such element is found.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                 | Description                                                                                                     |
| ---------------- | ------------------------------------ | --------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [FirstOrDefault()][2]                | Returns the first element of the set, or a default value if the set contains no elements.                       |
| ![Public method] | **FirstOrDefault(String, Object[])** | Returns the first element of the set that satisfies a condition or a default value if no such element is found. |


Syntax
------

```csharp
public Object FirstOrDefault(
	string predicate,
	params Object[] parameters
)
```

#### Parameters

##### *predicate*  [String][3]
A SQL expression to test each row for a condition.

##### *parameters*  [Object][4][]
The parameters to apply to the *predicate*.

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
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"