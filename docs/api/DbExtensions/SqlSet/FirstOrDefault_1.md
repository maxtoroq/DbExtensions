SqlSet.FirstOrDefault(SqlSet.SqlFragmentHandler) Method
=======================================================
Returns the first element of the set that satisfies a condition or a default value if no such element is found.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public Object? FirstOrDefault(
	ref SqlFragmentHandler? predicate
)
```

#### Parameters

##### *predicate*  SqlFragmentHandler
A SQL expression to test each row for a condition.

#### Return Value
[Object][2]  
 A default value if the set is empty or if no element passes the test specified by *predicate*; otherwise, the first element that passes the test specified by *predicate*.

See Also
--------

#### Reference
[SqlSet Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: README.md