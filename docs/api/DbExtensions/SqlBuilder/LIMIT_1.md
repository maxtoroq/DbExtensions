SqlBuilder.LIMIT(Int32) Method
==============================
Appends the LIMIT clause using the provided *maxRecords* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                         | Description                                                                                                                                                             |
| ---------------- | ---------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [LIMIT()][2]                 | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][3] and [_If(Boolean, String, Object[])][4]. |
| ![Public method] | **LIMIT(Int32)**             | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                                     |
| ![Public method] | [LIMIT(String, Object[])][5] | Appends the LIMIT clause using the provided *format* string and parameters.                                                                                             |


Syntax
------

```csharp
public SqlBuilder LIMIT(
	int maxRecords
)
```

#### Parameters

##### *maxRecords*  [Int32][6]
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
[2]: LIMIT.md
[3]: _.md
[4]: _If.md
[5]: LIMIT_2.md
[6]: https://learn.microsoft.com/dotnet/api/system.int32
[7]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"