SqlBuilder.INSERT_INTO(SqlInterpolatedStringHandler&lt;SqlClause.INSERT_INTO>) Method
=====================================================================================
Appends the INSERT INTO clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder INSERT_INTO(
	ref SqlInterpolatedStringHandler<SqlClause.INSERT_INTO> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.INSERT_INTO][2]>
The interpolated string that represents the body of the INSERT INTO clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlClause_INSERT_INTO/README.md
[3]: README.md