SqlBuilder.HAVING(SqlInterpolatedStringHandler&lt;SqlClause.HAVING>) Method
===========================================================================
Appends the HAVING clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                      | Description                                                                                                                                                     |
| ---------------- | --------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [HAVING()][2]                                             | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][3]. |
| ![Public method] | HAVING(SqlInterpolatedStringHandler&lt;SqlClause.HAVING>) | Appends the HAVING clause using the provided interpolated string *handler*.                                                                                     |
| ![Public method] | [HAVING(String)][4]                                       | Appends the HAVING clause using the provided *text*.                                                                                                            |


Syntax
------

```csharp
public SqlBuilder HAVING(
	ref SqlInterpolatedStringHandler<SqlClause.HAVING> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.HAVING][5]>
The interpolated string that represents the body of the HAVING clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: HAVING.md
[3]: _If.md
[4]: HAVING_2.md
[5]: ../SqlClause_HAVING/README.md
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"