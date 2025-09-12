SqlBuilder._If Method
=====================
Appends the interpolated string *handler* to the current clause if *condition* is true.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder _If(
	bool condition,
	ref ConditionalStringHandler handler
)
```

#### Parameters

##### *condition*  [Boolean][2]
true to append *handler* to the current clause; otherwise, false.

##### *handler*  ConditionalStringHandler
The interpolated string that represents the body of the current clause.

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