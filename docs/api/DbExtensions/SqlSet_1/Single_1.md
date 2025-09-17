SqlSet&lt;TResult>.Single(SqlSet.OperatorStringHandler) Method
==============================================================
Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                              | Description                                                                                                                             |
| --------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| [Single()][2]                     | The single element of the set.                                                                                                          |
| **Single(OperatorStringHandler)** | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. |
| [Single(String)][3]               | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. |


Syntax
------

```csharp
public TResult Single(
	ref OperatorStringHandler predicate
)
```

#### Parameters

##### *predicate*  OperatorStringHandler
A SQL expression to test each row for a condition.

#### Return Value
[TResult][4]  
The single element of the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                                                                                                |
| ------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------- |
| [InvalidOperationException][5] | No element satisfies the condition in *predicate*.-or-More than one element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Single.md
[3]: Single_2.md
[4]: README.md
[5]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception