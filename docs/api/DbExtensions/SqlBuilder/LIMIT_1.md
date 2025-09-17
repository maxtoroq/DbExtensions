SqlBuilder.LIMIT(SqlBuilder.ClauseStringHandler&lt;SqlClause.LIMIT>) Method
===========================================================================
Appends the LIMIT clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                          | Description                                                                                                                                        |
| ------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| [LIMIT()][2]                                                  | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| **LIMIT(SqlBuilder.ClauseStringHandler&lt;SqlClause.LIMIT>)** | Appends the LIMIT clause using the provided interpolated string *handler*.                                                                         |
| [LIMIT(Int32)][4]                                             | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                |
| [LIMIT(String)][5]                                            | Appends the LIMIT clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder LIMIT(
	ref ClauseStringHandler<SqlClause.LIMIT> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;[SqlClause.LIMIT][6]>
The interpolated string that represents the body of the LIMIT clause.

#### Return Value
[SqlBuilder][7]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: LIMIT.md
[3]: _If.md
[4]: LIMIT_2.md
[5]: LIMIT_3.md
[6]: ../SqlClause_LIMIT/README.md
[7]: README.md