SqlBuilder.GROUP_BY(SqlInterpolatedStringHandler&lt;SqlClause.GROUP_BY>) Method
===============================================================================
Appends the GROUP BY clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder GROUP_BY(
	ref SqlInterpolatedStringHandler<SqlClause.GROUP_BY> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.GROUP_BY][2]>
The interpolated string that represents the body of the GROUP BY clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlClause_GROUP_BY/README.md
[3]: README.md