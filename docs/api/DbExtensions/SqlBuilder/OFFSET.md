SqlBuilder.OFFSET Method
========================
Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][1] and [_If(Boolean, String, Object[])][2].
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                          | Description                                                                                                                                                              |
| ---------------- | ----------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | **OFFSET()**                  | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][1] and [_If(Boolean, String, Object[])][2]. |
| ![Public method] | [OFFSET(Int32)][4]            | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                                     |
| ![Public method] | [OFFSET(String, Object[])][5] | Appends the OFFSET clause using the provided *format* string and parameters.                                                                                             |


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
[DbExtensions Namespace][3]  

[1]: _.md
[2]: _If.md
[3]: ../README.md
[4]: OFFSET_1.md
[5]: OFFSET_2.md
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"