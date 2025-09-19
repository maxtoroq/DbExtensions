SQL.WITH(SqlBuilder.ClauseStringHandler&lt;SqlClause.WITH>) Method
==================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                              | Description                                                                                                                          |
| ------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| **WITH(SqlBuilder.ClauseStringHandler&lt;WITH>)** | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided string interpolated *handler*. |
| [WITH(String)][3]                                 | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *text*.                        |
| [WITH(String, SqlBuilder)][4]                     | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.        |
| [WITH(String, SqlSet)][5]                         | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.        |


Syntax
------

```csharp
public static SqlBuilder WITH(
	ref ClauseStringHandler<WITH> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;WITH>
The body of the WITH clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [WITH(SqlBuilder.ClauseStringHandler&lt;WITH>)][6].

See Also
--------

#### Reference
[SQL Class][7]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: WITH_1.md
[4]: WITH_2.md
[5]: WITH_3.md
[6]: ../SqlBuilder/WITH.md
[7]: README.md