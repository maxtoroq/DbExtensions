SqlBuilder.AppendClause&lt;TClause>(SqlBuilder.ClauseStringHandler&lt;TClause>) Method
======================================================================================
Appends the SQL clause identified by TClause and appends the interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                     | Description                                                                                 |
| ------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------- |
| [AppendClause(SqlClause)][2]                                             | Appends the SQL *clause*.                                                                   |
| [AppendClause(SqlClause, String)][3]                                     | Appends the SQL *clause* and the provided *text*.                                           |
| [AppendClause&lt;TClause>()][4]                                          | Appends the SQL clause identified by TClause.                                               |
| **AppendClause&lt;TClause>(SqlBuilder.ClauseStringHandler&lt;TClause>)** | Appends the SQL clause identified by TClause and appends the interpolated string *handler*. |
| [AppendClause&lt;TClause>(String)][5]                                    | Appends the SQL clause identified by TClause and appends the *text*.                        |


Syntax
------

```csharp
public SqlBuilder AppendClause<TClause>(
	ref ClauseStringHandler<TClause> handler
)
where TClause : new(), SqlClause

```

#### Parameters

##### *handler*  ClauseStringHandler&lt;**TClause**>
The interpolated string to append.

#### Type Parameters

##### *TClause*
The type of the SQL clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AppendClause.md
[3]: AppendClause_1.md
[4]: AppendClause__1.md
[5]: AppendClause__1_2.md
[6]: README.md