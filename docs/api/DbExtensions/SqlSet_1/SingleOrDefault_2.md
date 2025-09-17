SqlSet&lt;TResult>.SingleOrDefault(String) Method
=================================================
Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                        | Description                                                                                                                                                                                              |
| ------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [SingleOrDefault()][2]                      | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| [SingleOrDefault(OperatorStringHandler)][3] | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| **SingleOrDefault(String)**                 | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |


Syntax
------

```csharp
public TResult SingleOrDefault(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][4]
A SQL expression to test each row for a condition.

#### Return Value
[TResult][5]  
The single element of the set that satisfies the condition, or a default value if no such element is found.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: SingleOrDefault.md
[3]: SingleOrDefault_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: README.md