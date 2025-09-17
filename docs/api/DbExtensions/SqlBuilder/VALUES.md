SqlBuilder.VALUES(SqlBuilder.ClauseStringHandler&lt;SqlClause.VALUES>) Method
=============================================================================
Appends the VALUES clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                            | Description                                                                 |
| --------------------------------------------------------------- | --------------------------------------------------------------------------- |
| **VALUES(SqlBuilder.ClauseStringHandler&lt;SqlClause.VALUES>)** | Appends the VALUES clause using the provided interpolated string *handler*. |
| [VALUES(Object[])][2]                                           | Appends the VALUES clause using the provided parameters.                    |


Syntax
------

```csharp
public SqlBuilder VALUES(
	ref ClauseStringHandler<SqlClause.VALUES> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;[SqlClause.VALUES][3]>
The interpolated string that represents the body of the VALUES clause.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: VALUES_1.md
[3]: ../SqlClause_VALUES/README.md
[4]: README.md