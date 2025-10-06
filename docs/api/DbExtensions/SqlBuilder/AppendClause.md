SqlBuilder.AppendClause(SqlClause) Method
=========================================
Appends the SQL *clause*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                            | Description                                   |
| ------------------------------- | --------------------------------------------- |
| **AppendClause(SqlClause)**     | Appends the SQL *clause*.                     |
| [AppendClause&lt;TClause>()][2] | Appends the SQL clause identified by TClause. |


Syntax
------

```csharp
public SqlBuilder AppendClause(
	SqlClause clause
)
```

#### Parameters

##### *clause*  [SqlClause][3]
The clause to append.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AppendClause__1.md
[3]: ../SqlClause/README.md
[4]: README.md