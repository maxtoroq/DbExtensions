SqlBuilder.JOIN(SqlBuilder.ClauseStringHandler&lt;SqlClause.JOIN>) Method
=========================================================================
Appends the JOIN clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                        | Description                                                                                                                                       |
| ----------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------- |
| [JOIN()][2]                                                 | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| **JOIN(SqlBuilder.ClauseStringHandler&lt;SqlClause.JOIN>)** | Appends the JOIN clause using the provided interpolated string *handler*.                                                                         |
| [JOIN(String)][4]                                           | Appends the JOIN clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder JOIN(
	ref ClauseStringHandler<SqlClause.JOIN> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;[SqlClause.JOIN][5]>
The interpolated string that represents the body of the JOIN clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: JOIN.md
[3]: _If.md
[4]: JOIN_2.md
[5]: ../SqlClause_JOIN/README.md
[6]: README.md