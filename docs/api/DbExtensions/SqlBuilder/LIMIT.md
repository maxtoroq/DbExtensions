SqlBuilder.LIMIT Method
=======================
Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                         | Description                                                                                                                                                    |
| ---------------- | ------------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | **LIMIT()**                                                  | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][1]. |
| ![Public method] | [LIMIT(Int32)][3]                                            | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                            |
| ![Public method] | [LIMIT(SqlInterpolatedStringHandler&lt;SqlClause.LIMIT>)][4] | Appends the LIMIT clause using the provided interpolated string *handler*.                                                                                     |
| ![Public method] | [LIMIT(String)][5]                                           | Appends the LIMIT clause using the provided *text*.                                                                                                            |


Syntax
------

```csharp
public SqlBuilder LIMIT()
```

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][2]  

[1]: _If.md
[2]: ../README.md
[3]: LIMIT_2.md
[4]: LIMIT_1.md
[5]: LIMIT_3.md
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"