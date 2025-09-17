SqlBuilder.OFFSET(Int32) Method
===============================
Appends the OFFSET clause using the provided *startIndex* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                                                                                                                         |
| ---------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| [OFFSET()][2]                                                    | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| [OFFSET(SqlBuilder.ClauseStringHandler&lt;SqlClause.OFFSET>)][4] | Appends the OFFSET clause using the provided interpolated string *handler*.                                                                         |
| **OFFSET(Int32)**                                                | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                |
| [OFFSET(String)][5]                                              | Appends the OFFSET clause using the provided *text*.                                                                                                |


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
[3]: _If.md
[4]: OFFSET_1.md
[5]: OFFSET_3.md
[6]: https://learn.microsoft.com/dotnet/api/system.int32
[7]: README.md