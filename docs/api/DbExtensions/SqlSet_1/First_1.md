SqlSet&lt;TResult>.First(SqlSet.SqlFragmentHandler) Method
==========================================================
Returns the first element in the set that satisfies a specified condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public TResult First(
	ref SqlFragmentHandler predicate
)
```

#### Parameters

##### *predicate*  SqlFragmentHandler
A SQL expression to test each row for a condition.

#### Return Value
[TResult][2]  
The first element in the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                               |
| ------------------------------ | ----------------------------------------------------------------------- |
| [InvalidOperationException][3] | No element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception