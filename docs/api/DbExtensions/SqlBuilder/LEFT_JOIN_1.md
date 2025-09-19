SqlBuilder.LEFT_JOIN(SqlBuilder.ClauseStringHandler&lt;SqlClause.LEFT_JOIN>) Method
===================================================================================
Appends the LEFT JOIN clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                        | Description                                                                                                                                            |
| ----------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| [LEFT_JOIN()][2]                                            | Sets LEFT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| **LEFT_JOIN(SqlBuilder.ClauseStringHandler&lt;LEFT_JOIN>)** | Appends the LEFT JOIN clause using the provided interpolated string *handler*.                                                                         |
| [LEFT_JOIN(String)][4]                                      | Appends the LEFT JOIN clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder LEFT_JOIN(
	ref ClauseStringHandler<LEFT_JOIN> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;LEFT_JOIN>
The interpolated string that represents the body of the LEFT JOIN clause.

#### Return Value
[SqlBuilder][5]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: LEFT_JOIN.md
[3]: _If.md
[4]: LEFT_JOIN_2.md
[5]: README.md