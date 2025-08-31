SqlBuilder.LIMIT(SqlInterpolatedStringHandler&lt;SqlClause.LIMIT>) Method
=========================================================================
Appends the LIMIT clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder LIMIT(
	ref SqlInterpolatedStringHandler<SqlClause.LIMIT> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.LIMIT][2]>
The interpolated string that represents the body of the LIMIT clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlClause_LIMIT/README.md
[3]: README.md