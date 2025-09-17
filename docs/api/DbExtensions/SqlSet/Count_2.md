SqlSet.Count(String) Method
===========================
Returns a number that represents how many elements in the set satisfy a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                              | Description                                                                        |
| --------------------------------- | ---------------------------------------------------------------------------------- |
| [Count()][2]                      | Returns the number of elements in the set.                                         |
| [Count(OperatorStringHandler)][3] | Returns a number that represents how many elements in the set satisfy a condition. |
| **Count(String)**                 | Returns a number that represents how many elements in the set satisfy a condition. |


Syntax
------

```csharp
public int Count(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][4]
A SQL expression to test each row for a condition.

#### Return Value
[Int32][5]  
A number that represents how many elements in the set satisfy the condition in the *predicate*.

Exceptions
----------

| Exception              | Condition                                              |
| ---------------------- | ------------------------------------------------------ |
| [OverflowException][6] | The number of matching elements exceeds [MaxValue][7]. |


See Also
--------

#### Reference
[SqlSet Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Count.md
[3]: Count_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: https://learn.microsoft.com/dotnet/api/system.int32
[6]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[7]: https://learn.microsoft.com/dotnet/api/system.int32.maxvalue
[8]: README.md