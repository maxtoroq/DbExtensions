SqlSet.Count(SqlSet.OperatorStringHandler) Method
=================================================
Returns a number that represents how many elements in the set satisfy a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                             | Description                                                                        |
| -------------------------------- | ---------------------------------------------------------------------------------- |
| [Count()][2]                     | Returns the number of elements in the set.                                         |
| **Count(OperatorStringHandler)** | Returns a number that represents how many elements in the set satisfy a condition. |
| [Count(String)][3]               | Returns a number that represents how many elements in the set satisfy a condition. |


Syntax
------

```csharp
public int Count(
	ref OperatorStringHandler predicate
)
```

#### Parameters

##### *predicate*  OperatorStringHandler
A SQL expression to test each row for a condition.

#### Return Value
[Int32][4]  
A number that represents how many elements in the set satisfy the condition in the *predicate*.

Exceptions
----------

| Exception              | Condition                                              |
| ---------------------- | ------------------------------------------------------ |
| [OverflowException][5] | The number of matching elements exceeds [MaxValue][6]. |


See Also
--------

#### Reference
[SqlSet Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Count.md
[3]: Count_2.md
[4]: https://learn.microsoft.com/dotnet/api/system.int32
[5]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[6]: https://learn.microsoft.com/dotnet/api/system.int32.maxvalue
[7]: README.md