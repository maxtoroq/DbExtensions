SqlBuilder.LEFT_JOIN(SqlInterpolatedStringHandler&lt;SqlClause.LEFT_JOIN>) Method
=================================================================================
Appends the LEFT JOIN clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder LEFT_JOIN(
	ref SqlInterpolatedStringHandler<SqlClause.LEFT_JOIN> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.LEFT_JOIN][2]>
The interpolated string that represents the body of the LEFT JOIN clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlClause_LEFT_JOIN/README.md
[3]: README.md