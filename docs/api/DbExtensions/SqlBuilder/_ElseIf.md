SqlBuilder._ElseIf Method
=========================
Appends *handler* to the current clause if *condition* is `true` and an antecedent call to [_If(Boolean, ConditionalStringHandler)][1] or **_ElseIf(Boolean, ConditionalElseStringHandler)** used a `false` condition.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder _ElseIf(
	bool condition,
	ref ConditionalElseStringHandler handler
)
```

#### Parameters

##### *condition*  [Boolean][3]
`true` to append *handler* to the current clause; otherwise, `false`.

##### *handler*  ConditionalElseStringHandler
The interpolated string that represents the body of the current clause.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][2]  

[1]: _If.md
[2]: ../README.md
[3]: https://learn.microsoft.com/dotnet/api/system.boolean
[4]: README.md