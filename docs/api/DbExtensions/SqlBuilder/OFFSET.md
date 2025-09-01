SqlBuilder.OFFSET Method
========================
Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                           | Description                                                                                                                                                     |
| ---------------- | -------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | OFFSET()                                                       | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][1]. |
| ![Public method] | [OFFSET(Int32)][3]                                             | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                            |
| ![Public method] | [OFFSET(SqlInterpolatedStringHandler&lt;SqlClause.OFFSET>)][4] | Appends the OFFSET clause using the provided interpolated string *handler*.                                                                                     |
| ![Public method] | [OFFSET(String)][5]                                            | Appends the OFFSET clause using the provided *text*.                                                                                                            |


Syntax
------

```csharp
public SqlBuilder OFFSET()
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
[3]: OFFSET_2.md
[4]: OFFSET_1.md
[5]: OFFSET_3.md
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"