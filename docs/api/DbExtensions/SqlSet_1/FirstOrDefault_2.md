SqlSet&lt;TResult>.FirstOrDefault(String) Method
================================================
Returns the first element of the set that satisfies a condition or a default value if no such element is found.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public TResult FirstOrDefault(
	string predicate
)
```

#### Parameters

##### *predicate*  [String][2]
A SQL expression to test each row for a condition.

#### Return Value
[TResult][3]  
 A default value if the set is empty or if no element passes the test specified by *predicate*; otherwise, the first element that passes the test specified by *predicate*.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: README.md