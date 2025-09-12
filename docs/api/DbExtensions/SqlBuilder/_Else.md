SqlBuilder._Else Method
=======================
Appends *handler* to the current clause if an antecedent call to [_If(Boolean, ConditionalStringHandler)][1] or [_ElseIf(Boolean, ConditionalElseStringHandler)][2] used a false condition
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder _Else(
	ref ConditionalElseStringHandler handler
)
```

#### Parameters

##### *handler*  ConditionalElseStringHandler
The interpolated string that represents the body of the current clause.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][3]  

[1]: _If.md
[2]: _ElseIf.md
[3]: ../README.md
[4]: README.md