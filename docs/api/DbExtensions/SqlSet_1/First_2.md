SqlSet&lt;TResult>.First(String) Method
=======================================
Returns the first element in the set that satisfies a specified condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                              | Description                                                                |
| --------------------------------- | -------------------------------------------------------------------------- |
| [First()][2]                      | Returns the first element of the set.                                      |
| [First(OperatorStringHandler)][3] | Returns the first element in the set that satisfies a specified condition. |
| **First(String)**                 | Returns the first element in the set that satisfies a specified condition. |


Syntax
------

```csharp
public TResult First(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][4]
A SQL expression to test each row for a condition.

#### Return Value
[TResult][5]  
The first element in the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                               |
| ------------------------------ | ----------------------------------------------------------------------- |
| [InvalidOperationException][6] | No element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: First.md
[3]: First_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: README.md
[6]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception