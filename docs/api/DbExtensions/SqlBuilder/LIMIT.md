SqlBuilder.LIMIT Method
=======================
Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][1] and [_If(Boolean, String, Object[])][2].
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                         | Description                                                                                                                                                             |
| ---------------- | ---------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | **LIMIT()**                  | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][1] and [_If(Boolean, String, Object[])][2]. |
| ![Public method] | [LIMIT(Int32)][4]            | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                                     |
| ![Public method] | [LIMIT(String, Object[])][5] | Appends the LIMIT clause using the provided *format* string and parameters.                                                                                             |


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
[DbExtensions Namespace][3]  

[1]: _.md
[2]: _If.md
[3]: ../README.md
[4]: LIMIT_1.md
[5]: LIMIT_2.md
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"