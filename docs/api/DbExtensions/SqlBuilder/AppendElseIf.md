SqlBuilder.AppendElseIf Method
==============================
Appends the interpolated string *handler* if *condition* is `true` and an antecedent call to [AppendIf(Boolean, AppendStringHandler)][1] or **AppendElseIf(Boolean, AppendElseStringHandler)** used a `false` condition.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder AppendElseIf(
	bool condition,
	ref AppendElseStringHandler handler
)
```

#### Parameters

##### *condition*  [Boolean][3]
`true` to append *handler*; otherwise, `false`.

##### *handler*  AppendElseStringHandler
The interpolated string to append.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][2]  

[1]: AppendIf.md
[2]: ../README.md
[3]: https://learn.microsoft.com/dotnet/api/system.boolean
[4]: README.md