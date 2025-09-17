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
| [Append(SqlBuilder)][2]         | Appends *sql* to this instance.                             |
| [Append(String)][3]             | Appends *text* to this instance.                            |


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
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Append.md
[3]: Append_2.md
[4]: README.md