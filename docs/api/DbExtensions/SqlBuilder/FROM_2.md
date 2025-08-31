SqlBuilder.FROM(SqlInterpolatedStringHandler&lt;SqlClause.FROM>) Method
=======================================================================
Appends the FROM clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder FROM(
	ref SqlInterpolatedStringHandler<SqlClause.FROM> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.FROM][2]>
The interpolated string that represents the body of the FROM clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlClause_FROM/README.md
[3]: README.md