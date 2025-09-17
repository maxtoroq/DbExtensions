SQL.SELECT(SqlBuilder.ClauseStringHandler&lt;SqlClause.SELECT>) Method
======================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                            | Description                                                                                                                            |
| --------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------- |
| **SELECT(SqlBuilder.ClauseStringHandler&lt;SqlClause.SELECT>)** | Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided string interpolated *handler*. |
| [SELECT(String)][3]                                             | Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided *text*.                        |


Syntax
------

```csharp
public static SqlBuilder SELECT(
	ref ClauseStringHandler<SqlClause.SELECT> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;[SqlClause.SELECT][4]>
The body of the SELECT clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [SELECT(SqlBuilder.ClauseStringHandler&lt;SqlClause.SELECT>)][5].

See Also
--------

#### Reference
[SQL Class][6]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: SELECT_1.md
[4]: ../SqlClause_SELECT/README.md
[5]: ../SqlBuilder/SELECT_1.md
[6]: README.md