SQL.UPDATE(SqlInterpolatedStringHandler&lt;SqlClause.UPDATE>) Method
====================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static SqlBuilder UPDATE(
	ref SqlInterpolatedStringHandler<SqlClause.UPDATE> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.UPDATE][3]>
The body of the UPDATE clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [UPDATE(SqlInterpolatedStringHandler&lt;SqlClause.UPDATE>)][4].

See Also
--------

#### Reference
[SQL Class][5]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: ../SqlClause_UPDATE/README.md
[4]: ../SqlBuilder/UPDATE.md
[5]: README.md