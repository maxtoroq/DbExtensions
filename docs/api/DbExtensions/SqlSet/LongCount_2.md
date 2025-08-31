SqlSet.LongCount(String) Method
===============================
Returns an [Int64][1] that represents how many elements in the set satisfy a condition.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public long LongCount(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][3]
A SQL expression to test each row for a condition.

#### Return Value
[Int64][1]  
A number that represents how many elements in the set satisfy the condition in the *predicate*.

Exceptions
----------

| Exception              | Condition                                              |
| ---------------------- | ------------------------------------------------------ |
| [OverflowException][4] | The number of matching elements exceeds [MaxValue][5]. |


See Also
--------

#### Reference
[SqlSet Class][6]  
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.int64
[2]: ../README.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[5]: https://learn.microsoft.com/dotnet/api/system.int64.maxvalue
[6]: README.md