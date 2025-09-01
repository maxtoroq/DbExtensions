SqlBuilder.OFFSET(Int32) Method
===============================
Appends the OFFSET clause using the provided *startIndex* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                          | Description                                                                                                                                                              |
| ---------------- | ----------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [OFFSET()][2]                 | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][3] and [_If(Boolean, String, Object[])][4]. |
| ![Public method] | **OFFSET(Int32)**             | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                                     |
| ![Public method] | [OFFSET(String, Object[])][5] | Appends the OFFSET clause using the provided *format* string and parameters.                                                                                             |


Syntax
------

```csharp
public SqlBuilder OFFSET(
	int startIndex
)
```

#### Parameters

##### *startIndex*  [Int32][6]
The value to use as parameter.

#### Return Value
[SqlBuilder][7]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: OFFSET.md
[3]: _.md
[4]: _If.md
[5]: OFFSET_2.md
[6]: https://learn.microsoft.com/dotnet/api/system.int32
[7]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"