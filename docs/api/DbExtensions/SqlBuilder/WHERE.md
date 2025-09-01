SqlBuilder.WHERE Method
=======================
Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                         | Description                                                                                                                                                    |
| ---------------- | ------------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | **WHERE()**                                                  | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][1]. |
| ![Public method] | [WHERE(SqlInterpolatedStringHandler&lt;SqlClause.WHERE>)][3] | Appends the WHERE clause using the provided interpolated string *handler*.                                                                                     |
| ![Public method] | [WHERE(String)][4]                                           | Appends the WHERE clause using the provided *text*.                                                                                                            |


Syntax
------

```csharp
public SqlBuilder WHERE()
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
[3]: WHERE_1.md
[4]: WHERE_2.md
[5]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"