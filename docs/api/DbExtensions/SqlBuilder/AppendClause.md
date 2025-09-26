SqlBuilder.AppendClause(SqlClause, String) Method
=================================================
Appends the SQL *clause* and the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                      | Description                                                                                 |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| **AppendClause(SqlClause, String)**                                       | Appends the SQL *clause* and the provided *text*.                                           |
| [AppendClause&lt;TClause>(SqlBuilder.ClauseStringHandler&lt;TClause>)][2] | Appends the SQL clause identified by TClause and appends the interpolated string *handler*. |
| [AppendClause&lt;TClause>(String)][3]                                     | Appends the SQL clause identified by TClause and appends the *text*.                        |


Syntax
------

```csharp
public SqlBuilder AppendClause(
	SqlClause clause,
	string? text
)
```

#### Parameters

##### *clause*  [SqlClause][4]
The clause to append.

##### *text*  [String][5]
The text to append.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AppendClause__1.md
[3]: AppendClause__1_1.md
[4]: ../SqlClause/README.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: README.md