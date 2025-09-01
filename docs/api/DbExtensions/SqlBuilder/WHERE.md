SqlBuilder.WHERE Method
=======================
Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][1] and [_If(Boolean, String, Object[])][2].
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                         | Description                                                                                                                                                             |
| ---------------- | ---------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | **WHERE()**                  | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][1] and [_If(Boolean, String, Object[])][2]. |
| ![Public method] | [WHERE(String, Object[])][4] | Appends the WHERE clause using the provided *format* string and parameters.                                                                                             |


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
[DbExtensions Namespace][3]  

[1]: _.md
[2]: _If.md
[3]: ../README.md
[4]: WHERE_1.md
[5]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"