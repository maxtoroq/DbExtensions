SqlBuilder.SET(SqlInterpolatedStringHandler&lt;SqlClause.SET>) Method
=====================================================================
Appends the SET clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder SET(
	ref SqlInterpolatedStringHandler<SqlClause.SET> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.SET][2]>
The interpolated string that represents the body of the SET clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlClause_SET/README.md
[3]: README.md