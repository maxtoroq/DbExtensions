SqlBuilder.AppendClause&lt;TClause> Method
==========================================
Appends the SQL clause identified by TClause.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                           | Description                                   |
| ------------------------------ | --------------------------------------------- |
| [AppendClause(SqlClause)][2]   | Appends the SQL *clause*.                     |
| **AppendClause&lt;TClause>()** | Appends the SQL clause identified by TClause. |


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
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AppendClause.md
[3]: README.md