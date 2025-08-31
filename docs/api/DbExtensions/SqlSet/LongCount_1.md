SqlSet.LongCount(SqlSet.SqlFragmentHandler) Method
==================================================
Returns an [Int64][1] that represents how many elements in the set satisfy a condition.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public long LongCount(
	ref SqlFragmentHandler predicate
)
```

#### Parameters

##### *predicate*  SqlFragmentHandler
A SQL expression to test each row for a condition.

#### Return Value
[Int64][1]  
A number that represents how many elements in the set satisfy the condition in the *predicate*.

Exceptions
----------

| Exception              | Condition                                              |
| ---------------------- | ------------------------------------------------------ |
| [OverflowException][3] | The number of matching elements exceeds [MaxValue][4]. |


See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.int64
[2]: ../README.md
[3]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[4]: https://learn.microsoft.com/dotnet/api/system.int64.maxvalue
[5]: README.md