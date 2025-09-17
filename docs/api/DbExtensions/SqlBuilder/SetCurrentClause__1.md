SqlBuilder.SetCurrentClause&lt;TClause> Method
==============================================
Sets the clause identified by TClause as the current SQL clause.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                               | Description                                                      |
| ---------------------------------- | ---------------------------------------------------------------- |
| [SetCurrentClause(SqlClause)][2]   | Sets *clause* as the current SQL clause.                         |
| **SetCurrentClause&lt;TClause>()** | Sets the clause identified by TClause as the current SQL clause. |


Syntax
------

```csharp
public SqlBuilder SetCurrentClause<TClause>()
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
[CurrentClause][4]  

[1]: ../README.md
[2]: SetCurrentClause.md
[3]: README.md
[4]: CurrentClause.md