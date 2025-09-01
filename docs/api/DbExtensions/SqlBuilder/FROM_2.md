SqlBuilder.FROM(SqlInterpolatedStringHandler&lt;SqlClause.FROM>) Method
=======================================================================
Appends the FROM clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                  | Description                                                                                                                                                   |
| ---------------- | ----------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [FROM()][2]                                           | Sets FROM as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalInterpolatedStringHandler)][3]. |
| ![Public method] | FROM(SqlInterpolatedStringHandler&lt;SqlClause.FROM>) | Appends the FROM clause using the provided interpolated string *handler*.                                                                                     |
| ![Public method] | [FROM(String)][4]                                     | Appends the FROM clause using the provided *text*.                                                                                                            |
| ![Public method] | [FROM(SqlBuilder, String)][5]                         | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                            |
| ![Public method] | [FROM(SqlSet, String)][6]                             | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                            |


Syntax
------

```csharp
public SqlBuilder FROM(
	ref SqlInterpolatedStringHandler<SqlClause.FROM> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.FROM][7]>
The interpolated string that represents the body of the FROM clause.

#### Return Value
[SqlBuilder][8]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FROM.md
[3]: _If.md
[4]: FROM_4.md
[5]: FROM_1.md
[6]: FROM_3.md
[7]: ../SqlClause_FROM/README.md
[8]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"