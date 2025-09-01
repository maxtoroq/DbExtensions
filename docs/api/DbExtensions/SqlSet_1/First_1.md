SqlSet&lt;TResult>.First(SqlSet.SqlFragmentHandler) Method
==========================================================
Returns the first element in the set that satisfies a specified condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                          | Description                                                                |
| ---------------- | ----------------------------- | -------------------------------------------------------------------------- |
| ![Public method] | [First()][2]                  | Returns the first element of the set.                                      |
| ![Public method] | **First(SqlFragmentHandler)** | Returns the first element in the set that satisfies a specified condition. |
| ![Public method] | [First(String)][3]            | Returns the first element in the set that satisfies a specified condition. |


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
[Public method]: ../../icons/pubmethod.svg "Public method"