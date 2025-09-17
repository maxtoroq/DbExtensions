SqlBuilder.OFFSET(String) Method
================================
Appends the OFFSET clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                                                                                                                         |
| ---------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| [OFFSET()][2]                                                    | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| [OFFSET(SqlBuilder.ClauseStringHandler&lt;SqlClause.OFFSET>)][4] | Appends the OFFSET clause using the provided interpolated string *handler*.                                                                         |
| [OFFSET(Int32)][5]                                               | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                |
| **OFFSET(String)**                                               | Appends the OFFSET clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder OFFSET(
	string? text
)
```

#### Parameters

##### *text*  [String][6]
The text that represents the body of the OFFSET clause.

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
[3]: _If.md
[4]: OFFSET_1.md
[5]: OFFSET_2.md
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: README.md