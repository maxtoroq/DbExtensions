SqlBuilder.WITH(String) Method
==============================
Appends the WITH clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                         | Description                                                                        |
| ------------------------------------------------------------ | ---------------------------------------------------------------------------------- |
| [WITH(SqlBuilder.ClauseStringHandler&lt;SqlClause.WITH>)][2] | Appends the WITH clause using the provided interpolated string *handler*.          |
| **WITH(String)**                                             | Appends the WITH clause using the provided *text*.                                 |
| [WITH(String, SqlBuilder)][3]                                | Appends the WITH clause using the provided *subQuery* as body named after *alias*. |
| [WITH(String, SqlSet)][4]                                    | Appends the WITH clause using the provided *subQuery* as body named after *alias*. |


Syntax
------

```csharp
public SqlBuilder WITH(
	string? text
)
```

#### Parameters

##### *text*  [String][5]
The text that represents the body of the WITH clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: WITH.md
[3]: WITH_2.md
[4]: WITH_3.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: README.md