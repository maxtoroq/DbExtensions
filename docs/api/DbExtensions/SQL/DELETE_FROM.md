SQL.DELETE_FROM(SqlInterpolatedStringHandler&lt;SqlClause.DELETE_FROM>) Method
==============================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static SqlBuilder DELETE_FROM(
	ref SqlInterpolatedStringHandler<SqlClause.DELETE_FROM> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.DELETE_FROM][3]>
The body of the DELETE FROM clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [DELETE_FROM(SqlInterpolatedStringHandler&lt;SqlClause.DELETE_FROM>)][4].

See Also
--------

#### Reference
[SQL Class][5]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: ../SqlClause_DELETE_FROM/README.md
[4]: ../SqlBuilder/DELETE_FROM.md
[5]: README.md