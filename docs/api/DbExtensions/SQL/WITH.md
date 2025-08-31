SQL.WITH(SqlInterpolatedStringHandler&lt;SqlClause.WITH>) Method
================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static SqlBuilder WITH(
	ref SqlInterpolatedStringHandler<SqlClause.WITH> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.WITH][3]>
The body of the WITH clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [WITH(SqlInterpolatedStringHandler&lt;SqlClause.WITH>)][4].

See Also
--------

#### Reference
[SQL Class][5]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: ../SqlClause_WITH/README.md
[4]: ../SqlBuilder/WITH.md
[5]: README.md