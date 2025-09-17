SqlBuilder.SET(SqlBuilder.ClauseStringHandler&lt;SqlClause.SET>) Method
=======================================================================
Appends the SET clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                      | Description                                                              |
| --------------------------------------------------------- | ------------------------------------------------------------------------ |
| **SET(SqlBuilder.ClauseStringHandler&lt;SqlClause.SET>)** | Appends the SET clause using the provided interpolated string *handler*. |
| [SET(String)][2]                                          | Appends the SET clause using the provided *text*.                        |


Syntax
------

```csharp
public SqlBuilder SET(
	ref ClauseStringHandler<SqlClause.SET> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;[SqlClause.SET][3]>
The interpolated string that represents the body of the SET clause.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: SET_1.md
[3]: ../SqlClause_SET/README.md
[4]: README.md