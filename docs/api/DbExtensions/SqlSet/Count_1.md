SqlSet.Count(SqlSet.SqlFragmentHandler) Method
==============================================
Returns a number that represents how many elements in the set satisfy a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public int Count(
	ref SqlFragmentHandler predicate
)
```

#### Parameters

##### *predicate*  SqlFragmentHandler
A SQL expression to test each row for a condition.

#### Return Value
[Int32][2]  
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
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.int32
[3]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[4]: https://learn.microsoft.com/dotnet/api/system.int32.maxvalue
[5]: README.md