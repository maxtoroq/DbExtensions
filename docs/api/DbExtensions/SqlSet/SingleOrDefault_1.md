SqlSet.SingleOrDefault(String, Object[]) Method
===============================================
Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                  | Description                                                                                                                                                                                              |
| ---------------- | ------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [SingleOrDefault()][2]                | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| ![Public method] | **SingleOrDefault(String, Object[])** | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |


Syntax
------

```csharp
public Object SingleOrDefault(
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
The single element of the set that satisfies the condition, or a default value if no such element is found.

See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: SingleOrDefault.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"