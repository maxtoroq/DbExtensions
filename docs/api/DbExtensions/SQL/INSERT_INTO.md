SQL.INSERT_INTO(SqlInterpolatedStringHandler&lt;SqlClause.INSERT_INTO>) Method
==============================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static SqlBuilder INSERT_INTO(
	ref SqlInterpolatedStringHandler<SqlClause.INSERT_INTO> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.INSERT_INTO][3]>
The body of the INSERT INTO clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [INSERT_INTO(SqlInterpolatedStringHandler&lt;SqlClause.INSERT_INTO>)][4].

See Also
--------

#### Reference
[SQL Class][5]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: ../SqlClause_INSERT_INTO/README.md
[4]: ../SqlBuilder/INSERT_INTO.md
[5]: README.md