SqlSet&lt;TResult>.First(SqlSet.OperatorStringHandler) Method
=============================================================
Returns the first element in the set that satisfies a specified condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                             | Description                                                                |
| -------------------------------- | -------------------------------------------------------------------------- |
| [First()][2]                     | Returns the first element of the set.                                      |
| **First(OperatorStringHandler)** | Returns the first element in the set that satisfies a specified condition. |
| [First(String)][3]               | Returns the first element in the set that satisfies a specified condition. |


Syntax
------

```csharp
public TResult First(
	ref OperatorStringHandler predicate
)
```

#### Parameters

##### *predicate*  OperatorStringHandler
A SQL expression to test each row for a condition.

#### Return Value
[TResult][4]  
The first element in the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                               |
| ------------------------------ | ----------------------------------------------------------------------- |
| [InvalidOperationException][5] | No element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: First.md
[3]: First_2.md
[4]: README.md
[5]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception