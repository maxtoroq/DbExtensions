SqlBuilder.Append(SqlBuilder) Method
====================================
Appends *sql* to this instance.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                             | Description                                                 |
| -------------------------------- | ----------------------------------------------------------- |
| [Append(AppendStringHandler)][2] | Appends the interpolated string *handler* to this instance. |
| **Append(SqlBuilder)**           | Appends *sql* to this instance.                             |
| [Append(String)][3]              | Appends *text* to this instance.                            |


Syntax
------

```csharp
public SqlBuilder Append(
	SqlBuilder sql
)
```

#### Parameters

##### *sql*  [SqlBuilder][4]
A [SqlBuilder][4].

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Append_1.md
[3]: Append_2.md
[4]: README.md