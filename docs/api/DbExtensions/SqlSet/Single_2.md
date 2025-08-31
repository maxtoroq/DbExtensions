SqlSet.Single(String) Method
============================
Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public Object Single(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][2]
A SQL expression to test each row for a condition.

#### Return Value
[Object][3]  
The single element of the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                                                                                                |
| ------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------- |
| [InvalidOperationException][4] | No element satisfies the condition in *predicate*.-or-More than one element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception
[5]: README.md