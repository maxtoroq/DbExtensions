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
| **Append(String)**               | Appends *text* to this instance.                            |


Syntax
------

```csharp
public SqlBuilder Append(
	string? text
)
```

#### Parameters

##### *text*  [String][3]
The string.

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
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: README.md