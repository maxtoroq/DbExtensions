SqlSet.Any(String, Object[]) Method
===================================
Determines whether any element of the set satisfies a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                      | Description                                                      |
| ---------------- | ------------------------- | ---------------------------------------------------------------- |
| ![Public method] | [Any()][2]                | Determines whether the set contains any elements.                |
| ![Public method] | **Any(String, Object[])** | Determines whether any element of the set satisfies a condition. |


Syntax
------

```csharp
public bool Any(
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
[Boolean][5]  
true if any elements in the set pass the test in the specified *predicate*; otherwise, false.

See Also
--------

#### Reference
[SqlSet Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Any.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: https://learn.microsoft.com/dotnet/api/system.boolean
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"