SqlBuilder.HAVING(SqlBuilder.ClauseStringHandler&lt;SqlClause.HAVING>) Method
=============================================================================
Appends the HAVING clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                  | Description                                                                                                                                         |
| ----------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| [HAVING()][2]                                         | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| **HAVING(SqlBuilder.ClauseStringHandler&lt;HAVING>)** | Appends the HAVING clause using the provided interpolated string *handler*.                                                                         |
| [HAVING(String)][4]                                   | Appends the HAVING clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder HAVING(
	ref ClauseStringHandler<HAVING> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;HAVING>
The interpolated string that represents the body of the HAVING clause.

#### Return Value
[SqlBuilder][5]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: HAVING.md
[3]: _If.md
[4]: HAVING_2.md
[5]: README.md