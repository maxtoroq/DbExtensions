SqlBuilder.OFFSET Method
========================
Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][1].
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                   | Description                                                                                                                                         |
| ------------------------------------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| **OFFSET()**                                           | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][1]. |
| [OFFSET(SqlBuilder.ClauseStringHandler&lt;OFFSET>)][3] | Appends the OFFSET clause using the provided interpolated string *handler*.                                                                         |
| [OFFSET(Int32)][4]                                     | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                |
| [OFFSET(String)][5]                                    | Appends the OFFSET clause using the provided *text*.                                                                                                |


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
[3]: OFFSET_1.md
[4]: OFFSET_2.md
[5]: OFFSET_3.md
[6]: README.md