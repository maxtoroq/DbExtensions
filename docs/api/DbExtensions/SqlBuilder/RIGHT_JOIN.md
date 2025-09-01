SqlBuilder.RIGHT_JOIN Method
============================
Sets RIGHT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                                   | Description                                                                                                                                                         |
| ---------------- | ---------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | RIGHT_JOIN()                                                           | Sets RIGHT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][1]. |
| ![Public method] | [RIGHT_JOIN(SqlInterpolatedStringHandler&lt;SqlClause.RIGHT_JOIN>)][3] | Appends the RIGHT JOIN clause using the provided interpolated string *handler*.                                                                                     |
| ![Public method] | [RIGHT_JOIN(String)][4]                                                | Appends the RIGHT JOIN clause using the provided *text*.                                                                                                            |


Syntax
------

```csharp
public SqlBuilder RIGHT_JOIN()
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
[3]: RIGHT_JOIN_1.md
[4]: RIGHT_JOIN_2.md
[5]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"