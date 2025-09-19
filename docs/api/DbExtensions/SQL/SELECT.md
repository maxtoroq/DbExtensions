SQL.SELECT(SqlBuilder.ClauseStringHandler&lt;SqlClause.SELECT>) Method
======================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                  | Description                                                                                                                            |
| ----------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------- |
| **SELECT(SqlBuilder.ClauseStringHandler&lt;SELECT>)** | Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided string interpolated *handler*. |
| [SELECT(String)][3]                                   | Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided *text*.                        |


Syntax
------

```csharp
public static SqlBuilder SELECT(
	ref ClauseStringHandler<SELECT> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;SELECT>
The body of the SELECT clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [SELECT(SqlBuilder.ClauseStringHandler&lt;SELECT>)][4].

See Also
--------

#### Reference
[SQL Class][5]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: SELECT_1.md
[4]: ../SqlBuilder/SELECT_1.md
[5]: README.md