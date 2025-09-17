SqlBuilder.WHERE(SqlBuilder.ClauseStringHandler&lt;SqlClause.WHERE>) Method
===========================================================================
Appends the WHERE clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                          | Description                                                                                                                                        |
| ------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| [WHERE()][2]                                                  | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| **WHERE(SqlBuilder.ClauseStringHandler&lt;SqlClause.WHERE>)** | Appends the WHERE clause using the provided interpolated string *handler*.                                                                         |
| [WHERE(String)][4]                                            | Appends the WHERE clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder WHERE(
	ref ClauseStringHandler<SqlClause.WHERE> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;[SqlClause.WHERE][5]>
The interpolated string that represents the body of the WHERE clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: WHERE.md
[3]: _If.md
[4]: WHERE_2.md
[5]: ../SqlClause_WHERE/README.md
[6]: README.md