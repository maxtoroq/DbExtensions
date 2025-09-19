SqlBuilder.JOIN(SqlBuilder.ClauseStringHandler&lt;SqlClause.JOIN>) Method
=========================================================================
Appends the JOIN clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                              | Description                                                                                                                                       |
| ------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------- |
| [JOIN()][2]                                       | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| **JOIN(SqlBuilder.ClauseStringHandler&lt;JOIN>)** | Appends the JOIN clause using the provided interpolated string *handler*.                                                                         |
| [JOIN(String)][4]                                 | Appends the JOIN clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder JOIN(
	ref ClauseStringHandler<JOIN> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;JOIN>
The interpolated string that represents the body of the JOIN clause.

#### Return Value
[SqlBuilder][5]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: JOIN.md
[3]: _If.md
[4]: JOIN_2.md
[5]: README.md