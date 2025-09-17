SqlBuilder.SELECT Method
========================
Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                                                                                                                         |
| ---------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| **SELECT()**                                                     | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][1]. |
| [SELECT(SqlBuilder.ClauseStringHandler&lt;SqlClause.SELECT>)][3] | Appends the SELECT clause using the provided interpolated string *handler*.                                                                         |
| [SELECT(String)][4]                                              | Appends the SELECT clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder SELECT()
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
[3]: SELECT_1.md
[4]: SELECT_2.md
[5]: README.md