SqlBuilder.OFFSET(SqlBuilder.ClauseStringHandler&lt;SqlClause.OFFSET>) Method
=============================================================================
Appends the OFFSET clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                  | Description                                                                                                                                         |
| ----------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| [OFFSET()][2]                                         | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| **OFFSET(SqlBuilder.ClauseStringHandler&lt;OFFSET>)** | Appends the OFFSET clause using the provided interpolated string *handler*.                                                                         |
| [OFFSET(Int32)][4]                                    | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                |
| [OFFSET(String)][5]                                   | Appends the OFFSET clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder OFFSET(
	ref ClauseStringHandler<OFFSET> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;OFFSET>
The interpolated string that represents the body of the OFFSET clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: OFFSET.md
[3]: _If.md
[4]: OFFSET_2.md
[5]: OFFSET_3.md
[6]: README.md