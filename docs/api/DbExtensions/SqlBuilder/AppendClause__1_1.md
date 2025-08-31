SqlBuilder.AppendClause&lt;TClause>(SqlInterpolatedStringHandler&lt;TClause>) Method
====================================================================================
Appends the SQL clause identified by TClause and appends the interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder AppendClause<TClause>(
	ref SqlInterpolatedStringHandler<TClause> handler
)
where TClause : new(), SqlClause

```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;**TClause**>
The interpolated string to append.

#### Type Parameters

##### *TClause*
The type of the SQL clause.

#### Return Value
[SqlBuilder][2]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md