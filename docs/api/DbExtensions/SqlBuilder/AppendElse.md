SqlBuilder.AppendElse Method
============================
Appends the interpolated string *handler* if an antecedent call to [AppendIf(Boolean, AppendStringHandler)][1] or [AppendElseIf(Boolean, AppendElseStringHandler)][2] used a `false` condition
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder AppendElse(
	ref AppendElseStringHandler handler
)
```

#### Parameters

##### *handler*  AppendElseStringHandler
The interpolated string to append.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][3]  

[1]: AppendIf.md
[2]: AppendElseIf.md
[3]: ../README.md
[4]: README.md