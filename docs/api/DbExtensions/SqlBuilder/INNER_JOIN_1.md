SqlBuilder.INNER_JOIN(SqlInterpolatedStringHandler&lt;SqlClause.INNER_JOIN>) Method
===================================================================================
Appends the INNER JOIN clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                                  | Description                                                                                                                                                         |
| ---------------- | --------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [INNER_JOIN()][2]                                                     | Sets INNER JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][3]. |
| ![Public method] | **INNER_JOIN(SqlInterpolatedStringHandler&lt;SqlClause.INNER_JOIN>)** | Appends the INNER JOIN clause using the provided interpolated string *handler*.                                                                                     |
| ![Public method] | [INNER_JOIN(String)][4]                                               | Appends the INNER JOIN clause using the provided *text*.                                                                                                            |


Syntax
------

```csharp
public SqlBuilder INNER_JOIN(
	ref SqlInterpolatedStringHandler<SqlClause.INNER_JOIN> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.INNER_JOIN][5]>
The interpolated string that represents the body of the INNER JOIN clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: INNER_JOIN.md
[3]: _If.md
[4]: INNER_JOIN_2.md
[5]: ../SqlClause_INNER_JOIN/README.md
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"