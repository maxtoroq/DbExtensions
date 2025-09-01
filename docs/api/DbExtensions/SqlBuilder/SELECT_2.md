SqlBuilder.SELECT(String) Method
================================
Appends the SELECT clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                           | Description                                                                                                                                                     |
| ---------------- | -------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [SELECT()][2]                                                  | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][3]. |
| ![Public method] | [SELECT(SqlInterpolatedStringHandler&lt;SqlClause.SELECT>)][4] | Appends the SELECT clause using the provided interpolated string *handler*.                                                                                     |
| ![Public method] | SELECT(String)                                                 | Appends the SELECT clause using the provided *text*.                                                                                                            |


Syntax
------

```csharp
public SqlBuilder SELECT(
	string? text
)
```

#### Parameters

##### *text*  [String][5]
The text that represents the body of the SELECT clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: SELECT.md
[3]: _If.md
[4]: SELECT_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"