SqlBuilder.AppendClause(SqlClause) Method
=========================================
Appends the SQL *clause*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                      | Description                                                                                 |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| **AppendClause(SqlClause)**                                               | Appends the SQL *clause*.                                                                   |
| [AppendClause(SqlClause, String)][2]                                      | Appends the SQL *clause* and the provided *text*.                                           |
| [AppendClause&lt;TClause>()][3]                                           | Appends the SQL clause identified by TClause.                                               |
| [AppendClause&lt;TClause>(SqlBuilder.ClauseStringHandler&lt;TClause>)][4] | Appends the SQL clause identified by TClause and appends the interpolated string *handler*. |
| [AppendClause&lt;TClause>(String)][5]                                     | Appends the SQL clause identified by TClause and appends the *text*.                        |


Syntax
------

```csharp
public SqlBuilder AppendClause(
	SqlClause clause
)
```

#### Parameters

##### *clause*  [SqlClause][6]
The clause to append.

#### Return Value
[SqlBuilder][7]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AppendClause_1.md
[3]: AppendClause__1.md
[4]: AppendClause__1_1.md
[5]: AppendClause__1_2.md
[6]: ../SqlClause/README.md
[7]: README.md