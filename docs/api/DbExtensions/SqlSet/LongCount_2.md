SqlSet.LongCount(String) Method
===============================
Returns an [Int64][1] that represents how many elements in the set satisfy a condition.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                  | Description                                                                             |
| ------------------------------------- | --------------------------------------------------------------------------------------- |
| [LongCount()][3]                      | Returns an [Int64][1] that represents the total number of elements in the set.          |
| [LongCount(OperatorStringHandler)][4] | Returns an [Int64][1] that represents how many elements in the set satisfy a condition. |
| **LongCount(String)**                 | Returns an [Int64][1] that represents how many elements in the set satisfy a condition. |


Syntax
------

```csharp
public long LongCount(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][5]
A SQL expression to test each row for a condition.

#### Return Value
[Int64][1]  
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
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.int64
[2]: ../README.md
[3]: LongCount.md
[4]: LongCount_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[7]: https://learn.microsoft.com/dotnet/api/system.int64.maxvalue
[8]: README.md