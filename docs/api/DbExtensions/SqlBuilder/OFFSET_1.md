SqlBuilder.OFFSET(SqlInterpolatedStringHandler&lt;SqlClause.OFFSET>) Method
===========================================================================
Appends the OFFSET clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                          | Description                                                                                                                                                     |
| ---------------- | ------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [OFFSET()][2]                                                 | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][3]. |
| ![Public method] | [OFFSET(Int32)][4]                                            | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                            |
| ![Public method] | **OFFSET(SqlInterpolatedStringHandler&lt;SqlClause.OFFSET>)** | Appends the OFFSET clause using the provided interpolated string *handler*.                                                                                     |
| ![Public method] | [OFFSET(String)][5]                                           | Appends the OFFSET clause using the provided *text*.                                                                                                            |


Syntax
------

```csharp
public SqlBuilder OFFSET(
	ref SqlInterpolatedStringHandler<SqlClause.OFFSET> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.OFFSET][6]>
The interpolated string that represents the body of the OFFSET clause.

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
[4]: OFFSET_2.md
[5]: OFFSET_3.md
[6]: ../SqlClause_OFFSET/README.md
[7]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"