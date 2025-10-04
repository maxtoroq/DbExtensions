Database.QuoteIdentifier Method
===============================
Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public string QuoteIdentifier(
	string identifier
)
```

#### Parameters

##### *identifier*  [String][2]
The original identifier.

#### Return Value
[String][2]  
The quoted version of the identifier. If the indentifier is already quoted it's returned unchanged.

See Also
--------

#### Reference
[Database Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: README.md