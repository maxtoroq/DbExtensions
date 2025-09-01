SqlBuilder.OFFSET(String, Object[]) Method
==========================================
Appends the OFFSET clause using the provided *format* string and parameters.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                         | Description                                                                                                                                                              |
| ---------------- | ---------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [OFFSET()][2]                | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][3] and [_If(Boolean, String, Object[])][4]. |
| ![Public method] | [OFFSET(Int32)][5]           | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                                     |
| ![Public method] | **OFFSET(String, Object[])** | Appends the OFFSET clause using the provided *format* string and parameters.                                                                                             |


Syntax
------

```csharp
public SqlBuilder OFFSET(
	string format,
	params Object[] args
)
```

#### Parameters

##### *format*  [String][6]
The format string that represents the body of the OFFSET clause.

##### *args*  [Object][7][]
The parameters of the clause body.

#### Return Value
[SqlBuilder][8]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: OFFSET.md
[3]: _.md
[4]: _If.md
[5]: OFFSET_1.md
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: https://learn.microsoft.com/dotnet/api/system.object
[8]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"