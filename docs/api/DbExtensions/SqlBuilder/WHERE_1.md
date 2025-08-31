SqlBuilder.WHERE(SqlInterpolatedStringHandler&lt;SqlClause.WHERE>) Method
=========================================================================
Appends the WHERE clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder WHERE(
	ref SqlInterpolatedStringHandler<SqlClause.WHERE> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.WHERE][2]>
The interpolated string that represents the body of the WHERE clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlClause_WHERE/README.md
[3]: README.md