SqlBuilder.AppendIf Method
==========================
Appends the interpolated string *handler* if *condition* is `true`.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder AppendIf(
	bool condition,
	ref AppendStringHandler handler
)
```

#### Parameters

##### *condition*  [Boolean][2]
`true` to append *handler*; otherwise, `false`.

##### *handler*  AppendStringHandler
The interpolated string to append.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.boolean
[3]: README.md