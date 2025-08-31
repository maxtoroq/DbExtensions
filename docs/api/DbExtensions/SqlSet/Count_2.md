SqlSet.Count(String) Method
===========================
Returns a number that represents how many elements in the set satisfy a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public int Count(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][2]
A SQL expression to test each row for a condition.

#### Return Value
[Int32][3]  
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
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: https://learn.microsoft.com/dotnet/api/system.int32
[4]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[5]: https://learn.microsoft.com/dotnet/api/system.int32.maxvalue
[6]: README.md