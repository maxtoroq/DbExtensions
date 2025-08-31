SQL.SELECT(SqlInterpolatedStringHandler&lt;SqlClause.SELECT>) Method
====================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static SqlBuilder SELECT(
	ref SqlInterpolatedStringHandler<SqlClause.SELECT> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.SELECT][3]>
The body of the SELECT clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [SELECT(SqlInterpolatedStringHandler&lt;SqlClause.SELECT>)][4].

See Also
--------

#### Reference
[SQL Class][5]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: ../SqlClause_SELECT/README.md
[4]: ../SqlBuilder/SELECT_1.md
[5]: README.md