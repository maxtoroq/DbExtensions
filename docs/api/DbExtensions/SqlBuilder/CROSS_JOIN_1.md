SqlBuilder.CROSS_JOIN(SqlInterpolatedStringHandler&lt;SqlClause.CROSS_JOIN>) Method
===================================================================================
Appends the CROSS JOIN clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder CROSS_JOIN(
	ref SqlInterpolatedStringHandler<SqlClause.CROSS_JOIN> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.CROSS_JOIN][2]>
The interpolated string that represents the body of the CROSS JOIN clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlClause_CROSS_JOIN/README.md
[3]: README.md