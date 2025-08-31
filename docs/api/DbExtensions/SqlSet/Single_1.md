SqlSet.Single(SqlSet.SqlFragmentHandler) Method
===============================================
Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public Object Single(
	ref SqlFragmentHandler predicate
)
```

#### Parameters

##### *predicate*  SqlFragmentHandler
A SQL expression to test each row for a condition.

#### Return Value
[Object][2]  
The single element of the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                                                                                                |
| ------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------- |
| [InvalidOperationException][3] | No element satisfies the condition in *predicate*.-or-More than one element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception
[4]: README.md