SqlBuilder.AppendClause&lt;TClause> Method
==========================================
Appends the SQL clause identified by TClause.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder AppendClause<TClause>()
where TClause : new(), SqlClause

```

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