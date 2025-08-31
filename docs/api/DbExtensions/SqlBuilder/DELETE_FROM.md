SqlBuilder.DELETE_FROM(SqlInterpolatedStringHandler&lt;SqlClause.DELETE_FROM>) Method
=====================================================================================
Appends the DELETE FROM clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder DELETE_FROM(
	ref SqlInterpolatedStringHandler<SqlClause.DELETE_FROM> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.DELETE_FROM][2]>
The interpolated string that represents the body of the DELETE FROM clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlClause_DELETE_FROM/README.md
[3]: README.md