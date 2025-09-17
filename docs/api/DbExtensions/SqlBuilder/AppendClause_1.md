SqlBuilder.AppendClause(SqlClause, String) Method
=================================================
Appends the SQL *clause* and the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                      | Description                                                                                 |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| [AppendClause(SqlClause)][2]                                              | Appends the SQL *clause*.                                                                   |
| **AppendClause(SqlClause, String)**                                       | Appends the SQL *clause* and the provided *text*.                                           |
| [AppendClause&lt;TClause>()][3]                                           | Appends the SQL clause identified by TClause.                                               |
| [AppendClause&lt;TClause>(SqlBuilder.ClauseStringHandler&lt;TClause>)][4] | Appends the SQL clause identified by TClause and appends the interpolated string *handler*. |
| [AppendClause&lt;TClause>(String)][5]                                     | Appends the SQL clause identified by TClause and appends the *text*.                        |


Syntax
------

```csharp
public SqlBuilder AppendClause(
	SqlClause clause,
	string? text
)
```

#### Parameters

##### *clause*  [SqlClause][6]
The clause to append.

##### *text*  [String][7]
The text to append.

#### Return Value
[SqlBuilder][8]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AppendClause.md
[3]: AppendClause__1.md
[4]: AppendClause__1_1.md
[5]: AppendClause__1_2.md
[6]: ../SqlClause/README.md
[7]: https://learn.microsoft.com/dotnet/api/system.string
[8]: README.md