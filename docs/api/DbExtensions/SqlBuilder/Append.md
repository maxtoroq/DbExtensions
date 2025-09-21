SqlBuilder.Append(SqlBuilder.AppendStringHandler) Method
========================================================
Appends the interpolated string *handler* to this instance.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                            | Description                                                 |
| ------------------------------- | ----------------------------------------------------------- |
| **Append(AppendStringHandler)** | Appends the interpolated string *handler* to this instance. |
| [Append(String)][2]             | Appends *text* to this instance.                            |


Syntax
------

```csharp
public SqlBuilder Append(
	ref AppendStringHandler handler
)
```

#### Parameters

##### *handler*  AppendStringHandler
The interpolated string.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Append_1.md
[3]: README.md