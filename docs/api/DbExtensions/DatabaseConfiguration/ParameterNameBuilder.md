DatabaseConfiguration.ParameterNameBuilder Property
===================================================
Specifies a function that prepares a parameter name to be used on [ParameterName][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public Func<string, string> ParameterNameBuilder { get; set; }
```

#### Property Value
[Func][3]&lt;[String][4], [String][4]>

See Also
--------

#### Reference
[DatabaseConfiguration Class][5]  
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.data.idataparameter.parametername
[2]: ../README.md
[3]: https://learn.microsoft.com/dotnet/api/system.func-2
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: README.md