SqlBuilder.HAVING(SqlInterpolatedStringHandler&lt;SqlClause.HAVING>) Method
===========================================================================
Appends the HAVING clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder HAVING(
	ref SqlInterpolatedStringHandler<SqlClause.HAVING> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.HAVING][2]>
The interpolated string that represents the body of the HAVING clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlClause_HAVING/README.md
[3]: README.md