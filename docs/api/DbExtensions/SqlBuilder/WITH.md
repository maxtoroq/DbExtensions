SqlBuilder.WITH(SqlInterpolatedStringHandler&lt;SqlClause.WITH>) Method
=======================================================================
Appends the WITH clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder WITH(
	ref SqlInterpolatedStringHandler<SqlClause.WITH> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.WITH][2]>
The interpolated string that represents the body of the WITH clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlClause_WITH/README.md
[3]: README.md