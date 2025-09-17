SqlBuilder.SELECT(SqlBuilder.ClauseStringHandler&lt;SqlClause.SELECT>) Method
=============================================================================
Appends the SELECT clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                            | Description                                                                                                                                         |
| --------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| [SELECT()][2]                                                   | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| **SELECT(SqlBuilder.ClauseStringHandler&lt;SqlClause.SELECT>)** | Appends the SELECT clause using the provided interpolated string *handler*.                                                                         |
| [SELECT(String)][4]                                             | Appends the SELECT clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder SELECT(
	ref ClauseStringHandler<SqlClause.SELECT> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;[SqlClause.SELECT][5]>
The interpolated string that represents the body of the SELECT clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: SELECT.md
[3]: _If.md
[4]: SELECT_2.md
[5]: ../SqlClause_SELECT/README.md
[6]: README.md