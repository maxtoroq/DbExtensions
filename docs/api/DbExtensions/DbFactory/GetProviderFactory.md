DbFactory.GetProviderFactory Method
===================================
Locates a [DbProviderFactory][1] using [GetFactory(String)][2] and caches the result.

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
[ObsoleteAttribute("Please use DbExtensions.Database.GetProviderFactory(String) instead.")]
public static DbProviderFactory GetProviderFactory(
	string providerInvariantName
)
```

### Parameters

#### *providerInvariantName*
Type: [System.String][4]  
The provider invariant name.

### Return Value
Type: [DbProviderFactory][1]  
The requested provider factory.

See Also
--------
[DbFactory Class][5]  
[DbExtensions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/c6c4a26c
[2]: http://msdn.microsoft.com/en-us/library/h508h681
[3]: ../README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: README.md