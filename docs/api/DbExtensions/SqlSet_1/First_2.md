SqlSet&lt;TResult>.First(String) Method
=======================================
Returns the first element in the set that satisfies a specified condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public TResult First(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][2]
A SQL expression to test each row for a condition.

#### Return Value
[TResult][3]  
The first element in the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                               |
| ------------------------------ | ----------------------------------------------------------------------- |
| [InvalidOperationException][4] | No element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception