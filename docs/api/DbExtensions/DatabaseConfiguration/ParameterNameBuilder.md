DatabaseConfiguration.ParameterNameBuilder Property
===================================================
Specifies a function that prepares a parameter name to be used on [ParameterName][1].

  **Namespace:**  [DbExtensions][2]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public Func<string, string> ParameterNameBuilder { get; set; }
```

#### Property Value
Type: [Func][3]&lt;[String][4], [String][4]>

See Also
--------

#### Reference
[DatabaseConfiguration Class][5]  
[DbExtensions Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.data.idataparameter.parametername#System_Data_IDataParameter_ParameterName
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/system.func-2
[4]: https://docs.microsoft.com/dotnet/api/system.string
[5]: README.md