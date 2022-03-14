Database.QuoteIdentifier Method
===============================
Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier, including properly escaping any embedded quotes in the identifier.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public virtual string QuoteIdentifier(
	string unquotedIdentifier
)
```

#### Parameters

##### *unquotedIdentifier*
Type: [System.String][2]  
The original unquoted identifier.

#### Return Value
Type: [String][2]  
The quoted version of the identifier. Embedded quotes within the identifier are properly escaped.

See Also
--------

#### Reference
[Database Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: README.md