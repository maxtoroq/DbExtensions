SqlSet.First(SqlSet.OperatorStringHandler) Method
=================================================
Returns the first element in the set that satisfies a specified condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                             | Description                                                                |
| ---------------- | -------------------------------- | -------------------------------------------------------------------------- |
| ![Public method] | [First()][2]                     | Returns the first element of the set.                                      |
| ![Public method] | **First(OperatorStringHandler)** | Returns the first element in the set that satisfies a specified condition. |
| ![Public method] | [First(String)][3]               | Returns the first element in the set that satisfies a specified condition. |


Syntax
------

```csharp
public Object First(
	ref OperatorStringHandler predicate
)
```

#### Parameters

##### *predicate*  OperatorStringHandler
A SQL expression to test each row for a condition.

#### Return Value
[Object][4]  
The first element in the set that passes the test in the specified *predicate*.

Exceptions
----------

| Exception                      | Condition                                                               |
| ------------------------------ | ----------------------------------------------------------------------- |
| [InvalidOperationException][5] | No element satisfies the condition in *predicate*.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: First.md
[3]: First_2.md
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"