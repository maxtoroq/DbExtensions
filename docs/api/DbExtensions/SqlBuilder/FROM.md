SqlBuilder.FROM Method
======================
Sets FROM as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                       | Description                                                                                                                                                   |
| ---------------- | ---------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | FROM()                                                     | Sets FROM as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][1]. |
| ![Public method] | [FROM(SqlInterpolatedStringHandler&lt;SqlClause.FROM>)][3] | Appends the FROM clause using the provided interpolated string *handler*.                                                                                     |
| ![Public method] | [FROM(String)][4]                                          | Appends the FROM clause using the provided *text*.                                                                                                            |
| ![Public method] | [FROM(SqlBuilder, String)][5]                              | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                            |
| ![Public method] | [FROM(SqlSet, String)][6]                                  | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                            |


Syntax
------

```csharp
public SqlBuilder FROM()
```

#### Return Value
[SqlBuilder][7]  
A reference to this instance after the operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][7]  
[DbExtensions Namespace][2]  

[1]: _If.md
[2]: ../README.md
[3]: FROM_2.md
[4]: FROM_4.md
[5]: FROM_1.md
[6]: FROM_3.md
[7]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"