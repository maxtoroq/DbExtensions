SqlBuilder.AppendClause&lt;TClause> Method
==========================================
Appends the SQL clause identified by TClause.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                  | Description                                                           |
| ------------------------------------- | --------------------------------------------------------------------- |
| [AppendClause(SqlClause)][2]          | Appends the SQL *clause*.                                             |
| [AppendClause(SqlClause, String)][3]  | Appends the SQL *clause* and the provided *text*.                     |
| **AppendClause&lt;TClause>()**        | Appends the SQL clause identified by TClause.                         |
| [AppendClause&lt;TClause>(String)][4] | Appends the SQL clause identified by TClause and the provided *text*. |


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
[SqlBuilder][5]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AppendClause.md
[3]: AppendClause_1.md
[4]: AppendClause__1_1.md
[5]: README.md