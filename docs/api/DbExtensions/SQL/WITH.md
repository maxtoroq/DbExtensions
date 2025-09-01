SQL.WITH(SqlInterpolatedStringHandler&lt;SqlClause.WITH>) Method
================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                                  | Name                                                  | Description                                                                                                                          |
| -------------------------------- | ----------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method]![Static member] | WITH(SqlInterpolatedStringHandler&lt;SqlClause.WITH>) | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided string interpolated *handler*. |
| ![Public method]![Static member] | [WITH(String)][3]                                     | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *text*.                        |
| ![Public method]![Static member] | [WITH(String, SqlBuilder)][4]                         | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.        |
| ![Public method]![Static member] | [WITH(String, SqlSet)][5]                             | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.        |


Syntax
------

```csharp
public static SqlBuilder WITH(
	ref SqlInterpolatedStringHandler<SqlClause.WITH> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.WITH][6]>
The body of the WITH clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [WITH(SqlInterpolatedStringHandler&lt;SqlClause.WITH>)][7].

See Also
--------

#### Reference
[SQL Class][8]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: WITH_1.md
[4]: WITH_2.md
[5]: WITH_3.md
[6]: ../SqlClause_WITH/README.md
[7]: ../SqlBuilder/WITH.md
[8]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/Static.gif "Static member"