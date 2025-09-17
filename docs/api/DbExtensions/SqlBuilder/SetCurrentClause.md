SqlBuilder.SetCurrentClause(SqlClause) Method
=============================================
Sets *clause* as the current SQL clause.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                | Description                                                      |
| ----------------------------------- | ---------------------------------------------------------------- |
| **SetCurrentClause(SqlClause)**     | Sets *clause* as the current SQL clause.                         |
| [SetCurrentClause&lt;TClause>()][2] | Sets the clause identified by TClause as the current SQL clause. |


Syntax
------

```csharp
public SqlBuilder SetCurrentClause(
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
[CurrentClause][5]  

[1]: ../README.md
[2]: SetCurrentClause__1.md
[3]: ../SqlClause/README.md
[4]: README.md
[5]: CurrentClause.md