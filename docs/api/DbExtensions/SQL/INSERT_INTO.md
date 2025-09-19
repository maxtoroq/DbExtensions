SQL.INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;SqlClause.INSERT_INTO>) Method
================================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                            | Description                                                                                                                                 |
| --------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
| **INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;INSERT_INTO>)** | Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided string interpolated *handler*. |
| [INSERT_INTO(String)][3]                                        | Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided *text*.                        |


Syntax
------

```csharp
public static SqlBuilder INSERT_INTO(
	ref ClauseStringHandler<INSERT_INTO> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;INSERT_INTO>
The body of the INSERT INTO clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;INSERT_INTO>)][4].

See Also
--------

#### Reference
[SQL Class][5]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: INSERT_INTO_1.md
[4]: ../SqlBuilder/INSERT_INTO.md
[5]: README.md