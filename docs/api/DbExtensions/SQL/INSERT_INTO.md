SQL.INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;SqlClause.INSERT_INTO>) Method
================================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                      | Description                                                                                                                                 |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
| **INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;SqlClause.INSERT_INTO>)** | Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided string interpolated *handler*. |
| [INSERT_INTO(String)][3]                                                  | Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided *text*.                        |


Syntax
------

```csharp
public static SqlBuilder INSERT_INTO(
	ref ClauseStringHandler<SqlClause.INSERT_INTO> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;[SqlClause.INSERT_INTO][4]>
The body of the INSERT INTO clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;SqlClause.INSERT_INTO>)][5].

See Also
--------

#### Reference
[SQL Class][6]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: INSERT_INTO_1.md
[4]: ../SqlClause_INSERT_INTO/README.md
[5]: ../SqlBuilder/INSERT_INTO.md
[6]: README.md