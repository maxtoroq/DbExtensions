SqlBuilder.ORDER_BY Method
==========================
Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                 | Description                                                                                                                                           |
| -------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------- |
| **ORDER_BY()**                                                       | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][1]. |
| [ORDER_BY(SqlBuilder.ClauseStringHandler&lt;SqlClause.ORDER_BY>)][3] | Appends the ORDER BY clause using the provided interpolated string *handler*.                                                                         |
| [ORDER_BY(String)][4]                                                | Appends the ORDER BY clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder ORDER_BY()
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
[3]: ORDER_BY_1.md
[4]: ORDER_BY_2.md
[5]: README.md