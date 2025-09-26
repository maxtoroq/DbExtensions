SqlBuilder.AppendClause&lt;TClause>(SqlBuilder.ClauseStringHandler&lt;TClause>) Method
======================================================================================
Appends the SQL clause identified by TClause and appends the interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                     | Description                                                                                 |
| ------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------- |
| [AppendClause(SqlClause, String)][2]                                     | Appends the SQL *clause* and the provided *text*.                                           |
| **AppendClause&lt;TClause>(SqlBuilder.ClauseStringHandler&lt;TClause>)** | Appends the SQL clause identified by TClause and appends the interpolated string *handler*. |
| [AppendClause&lt;TClause>(String)][3]                                    | Appends the SQL clause identified by TClause and appends the *text*.                        |


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
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AppendClause.md
[3]: AppendClause__1_1.md
[4]: README.md