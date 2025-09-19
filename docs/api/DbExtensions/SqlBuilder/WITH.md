SqlBuilder.WITH(SqlBuilder.ClauseStringHandler&lt;SqlClause.WITH>) Method
=========================================================================
Appends the WITH clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                              | Description                                                                        |
| ------------------------------------------------- | ---------------------------------------------------------------------------------- |
| **WITH(SqlBuilder.ClauseStringHandler&lt;WITH>)** | Appends the WITH clause using the provided interpolated string *handler*.          |
| [WITH(String)][2]                                 | Appends the WITH clause using the provided *text*.                                 |
| [WITH(String, SqlBuilder)][3]                     | Appends the WITH clause using the provided *subQuery* as body named after *alias*. |
| [WITH(String, SqlSet)][4]                         | Appends the WITH clause using the provided *subQuery* as body named after *alias*. |


Syntax
------

```csharp
public SqlBuilder WITH(
	ref ClauseStringHandler<WITH> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;WITH>
The interpolated string that represents the body of the WITH clause.

#### Return Value
[SqlBuilder][5]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: WITH_1.md
[3]: WITH_2.md
[4]: WITH_3.md
[5]: README.md