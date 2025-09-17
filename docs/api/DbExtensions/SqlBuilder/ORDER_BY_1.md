SqlBuilder.ORDER_BY(SqlBuilder.ClauseStringHandler&lt;SqlClause.ORDER_BY>) Method
=================================================================================
Appends the ORDER BY clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                | Description                                                                                                                                           |
| ------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------- |
| [ORDER_BY()][2]                                                     | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| **ORDER_BY(SqlBuilder.ClauseStringHandler&lt;SqlClause.ORDER_BY>)** | Appends the ORDER BY clause using the provided interpolated string *handler*.                                                                         |
| [ORDER_BY(String)][4]                                               | Appends the ORDER BY clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder ORDER_BY(
	ref ClauseStringHandler<SqlClause.ORDER_BY> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;[SqlClause.ORDER_BY][5]>
The interpolated string that represents the body of the ORDER BY clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ORDER_BY.md
[3]: _If.md
[4]: ORDER_BY_2.md
[5]: ../SqlClause_ORDER_BY/README.md
[6]: README.md