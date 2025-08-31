SqlSet.First(SqlSet.SqlFragmentHandler) Method
==============================================
Returns the first element in the set that satisfies a specified condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public Object First(
	ref SqlFragmentHandler predicate
)
```

#### Parameters

##### *predicate*  SqlFragmentHandler
A SQL expression to test each row for a condition.

#### Return Value
[Object][2]  
The first element in the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                               |
| ------------------------------ | ----------------------------------------------------------------------- |
| [InvalidOperationException][3] | No element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception
[4]: README.md