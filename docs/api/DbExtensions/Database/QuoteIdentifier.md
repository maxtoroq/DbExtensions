Database.QuoteIdentifier Method
===============================
Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier, including properly escaping any embedded quotes in the identifier.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public string QuoteIdentifier(
	string unquotedIdentifier
)
```

### Parameters

#### *unquotedIdentifier*
Type: [System.String][2]  
The original unquoted identifier.

### Return Value
Type: [String][2]  
The quoted version of the identifier. Embedded quotes within the identifier are properly escaped.

See Also
--------
[Database Class][3]  
[DbExtensions Namespace][1]  
[DbCommandBuilder.QuoteIdentifier(String)][4]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: http://msdn.microsoft.com/en-us/library/79h5bby0