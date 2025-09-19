SqlBuilder.LEFT_JOIN Method
===========================
Sets LEFT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                         | Description                                                                                                                                            |
| ------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **LEFT_JOIN()**                                              | Sets LEFT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][1]. |
| [LEFT_JOIN(SqlBuilder.ClauseStringHandler&lt;LEFT_JOIN>)][3] | Appends the LEFT JOIN clause using the provided interpolated string *handler*.                                                                         |
| [LEFT_JOIN(String)][4]                                       | Appends the LEFT JOIN clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder LEFT_JOIN()
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
[3]: LEFT_JOIN_1.md
[4]: LEFT_JOIN_2.md
[5]: README.md