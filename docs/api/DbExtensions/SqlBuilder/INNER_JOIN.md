SqlBuilder.INNER_JOIN Method
============================
Sets INNER JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                           | Description                                                                                                                                             |
| -------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **INNER_JOIN()**                                               | Sets INNER JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][1]. |
| [INNER_JOIN(SqlBuilder.ClauseStringHandler&lt;INNER_JOIN>)][3] | Appends the INNER JOIN clause using the provided interpolated string *handler*.                                                                         |
| [INNER_JOIN(String)][4]                                        | Appends the INNER JOIN clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder INNER_JOIN()
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
[3]: INNER_JOIN_1.md
[4]: INNER_JOIN_2.md
[5]: README.md