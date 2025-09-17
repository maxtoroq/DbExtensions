SqlBuilder.SetNextClause&lt;TClause> Method
===========================================
Sets the clause identified by TClause as the next SQL clause.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                            | Description                                                   |
| ------------------------------- | ------------------------------------------------------------- |
| [SetNextClause(SqlClause)][2]   | Sets *clause* as the next SQL clause.                         |
| **SetNextClause&lt;TClause>()** | Sets the clause identified by TClause as the next SQL clause. |


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
[SqlBuilder][3]  
A reference to this instance after the operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  
[NextClause][4]  

[1]: ../README.md
[2]: SetNextClause.md
[3]: README.md
[4]: NextClause.md