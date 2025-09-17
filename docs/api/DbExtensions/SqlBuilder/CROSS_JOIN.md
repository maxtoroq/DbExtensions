SqlBuilder.CROSS_JOIN Method
============================
Sets CROSS JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                     | Description                                                                                                                                             |
| ------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **CROSS_JOIN()**                                                         | Sets CROSS JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][1]. |
| [CROSS_JOIN(SqlBuilder.ClauseStringHandler&lt;SqlClause.CROSS_JOIN>)][3] | Appends the CROSS JOIN clause using the provided interpolated string *handler*.                                                                         |
| [CROSS_JOIN(String)][4]                                                  | Appends the CROSS JOIN clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder CROSS_JOIN()
```

#### Return Value
[SqlBuilder][5]  
A reference to this instance after the operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][5]  
[DbExtensions Namespace][2]  

[1]: _If.md
[2]: ../README.md
[3]: CROSS_JOIN_1.md
[4]: CROSS_JOIN_2.md
[5]: README.md