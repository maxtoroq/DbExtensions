SqlBuilder.SetNextClause&lt;TClause> Method
===========================================
Sets the clause identified by TClause as the next SQL clause.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder SetNextClause<TClause>()
where TClause : new(), SqlClause

```

#### Type Parameters

##### *TClause*
The type of the SQL clause.

#### Return Value
[SqlBuilder][2]  
A reference to this instance after the operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][2]  
[DbExtensions Namespace][1]  
[NextClause][3]  

[1]: ../README.md
[2]: README.md
[3]: NextClause.md