SqlBuilder.ORDER_BY(SqlInterpolatedStringHandler&lt;SqlClause.ORDER_BY>) Method
===============================================================================
Appends the ORDER BY clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder ORDER_BY(
	ref SqlInterpolatedStringHandler<SqlClause.ORDER_BY> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.ORDER_BY][2]>
The interpolated string that represents the body of the ORDER BY clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlClause_ORDER_BY/README.md
[3]: README.md