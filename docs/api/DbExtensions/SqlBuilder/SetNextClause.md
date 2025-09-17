SqlBuilder.SetNextClause(SqlClause) Method
==========================================
Sets *clause* as the next SQL clause.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                             | Description                                                   |
| -------------------------------- | ------------------------------------------------------------- |
| **SetNextClause(SqlClause)**     | Sets *clause* as the next SQL clause.                         |
| [SetNextClause&lt;TClause>()][2] | Sets the clause identified by TClause as the next SQL clause. |


Syntax
------

```csharp
public SqlBuilder SetNextClause(
	SqlClause? clause
)
```

#### Parameters

##### *clause*  [SqlClause][3]
The SQL clause.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  
[NextClause][5]  

[1]: ../README.md
[2]: SetNextClause__1.md
[3]: ../SqlClause/README.md
[4]: README.md
[5]: NextClause.md