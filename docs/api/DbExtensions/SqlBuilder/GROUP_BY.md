SqlBuilder.GROUP_BY Method
==========================
Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                               | Description                                                                                                                                                       |
| ---------------- | ------------------------------------------------------------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | GROUP_BY()                                                         | Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][1]. |
| ![Public method] | [GROUP_BY(SqlInterpolatedStringHandler&lt;SqlClause.GROUP_BY>)][3] | Appends the GROUP BY clause using the provided interpolated string *handler*.                                                                                     |
| ![Public method] | [GROUP_BY(String)][4]                                              | Appends the GROUP BY clause using the provided *text*.                                                                                                            |


Syntax
------

```csharp
public SqlBuilder GROUP_BY()
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
[3]: GROUP_BY_1.md
[4]: GROUP_BY_2.md
[5]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"