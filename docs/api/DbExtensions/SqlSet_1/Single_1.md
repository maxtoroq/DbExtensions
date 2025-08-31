SqlSet&lt;TResult>.Single(SqlSet.SqlFragmentHandler) Method
===========================================================
Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public TResult Single(
	ref SqlFragmentHandler predicate
)
```

#### Parameters

##### *predicate*  SqlFragmentHandler
A SQL expression to test each row for a condition.

#### Return Value
[TResult][2]  
The single element of the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                                                                                                |
| ------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------- |
| [InvalidOperationException][3] | No element satisfies the condition in *predicate*.-or-More than one element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception