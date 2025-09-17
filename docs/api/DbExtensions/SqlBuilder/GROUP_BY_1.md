SqlBuilder.GROUP_BY(SqlBuilder.ClauseStringHandler&lt;SqlClause.GROUP_BY>) Method
=================================================================================
Appends the GROUP BY clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                | Description                                                                                                                                           |
| ------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------- |
| [GROUP_BY()][2]                                                     | Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| **GROUP_BY(SqlBuilder.ClauseStringHandler&lt;SqlClause.GROUP_BY>)** | Appends the GROUP BY clause using the provided interpolated string *handler*.                                                                         |
| [GROUP_BY(String)][4]                                               | Appends the GROUP BY clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder GROUP_BY(
	ref ClauseStringHandler<SqlClause.GROUP_BY> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;[SqlClause.GROUP_BY][5]>
The interpolated string that represents the body of the GROUP BY clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: GROUP_BY.md
[3]: _If.md
[4]: GROUP_BY_2.md
[5]: ../SqlClause_GROUP_BY/README.md
[6]: README.md