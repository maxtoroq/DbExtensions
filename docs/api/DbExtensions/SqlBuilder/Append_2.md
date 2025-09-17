SqlBuilder.Append(String) Method
================================
Appends *text* to this instance.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                             | Description                                                 |
| -------------------------------- | ----------------------------------------------------------- |
| [Append(AppendStringHandler)][2] | Appends the interpolated string *handler* to this instance. |
| [Append(SqlBuilder)][3]          | Appends *sql* to this instance.                             |
| **Append(String)**               | Appends *text* to this instance.                            |


Syntax
------

```csharp
public SqlBuilder Append(
	string? text
)
```

#### Parameters

##### *text*  [String][4]
The string.

#### Return Value
[SqlBuilder][5]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Append_1.md
[3]: Append.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: README.md