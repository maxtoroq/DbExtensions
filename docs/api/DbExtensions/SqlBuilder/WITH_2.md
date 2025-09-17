SqlBuilder.WITH(String, SqlBuilder) Method
==========================================
Appends the WITH clause using the provided *subQuery* as body named after *alias*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                         | Description                                                                        |
| ------------------------------------------------------------ | ---------------------------------------------------------------------------------- |
| [WITH(SqlBuilder.ClauseStringHandler&lt;SqlClause.WITH>)][2] | Appends the WITH clause using the provided interpolated string *handler*.          |
| [WITH(String)][3]                                            | Appends the WITH clause using the provided *text*.                                 |
| **WITH(String, SqlBuilder)**                                 | Appends the WITH clause using the provided *subQuery* as body named after *alias*. |
| [WITH(String, SqlSet)][4]                                    | Appends the WITH clause using the provided *subQuery* as body named after *alias*. |


Syntax
------

```csharp
public SqlBuilder WITH(
	string alias,
	SqlBuilder subQuery
)
```

#### Parameters

##### *alias*  [String][5]
The alias of the sub-query.

##### *subQuery*  [SqlBuilder][6]
The sub-query to use as the body of the WITH clause.

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
[3]: WITH_1.md
[4]: WITH_3.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: README.md