SqlBuilder.VALUES(SqlInterpolatedStringHandler&lt;SqlClause.VALUES>) Method
===========================================================================
Appends the VALUES clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder VALUES(
	ref SqlInterpolatedStringHandler<SqlClause.VALUES> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.VALUES][2]>
The interpolated string that represents the body of the VALUES clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlClause_VALUES/README.md
[3]: README.md