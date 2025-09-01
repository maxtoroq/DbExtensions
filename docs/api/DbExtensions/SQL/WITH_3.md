SQL.WITH(String, SqlSet) Method
===============================
Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                                  | Name                                                       | Description                                                                                                                          |
| -------------------------------- | ---------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method]![Static member] | [WITH(SqlInterpolatedStringHandler&lt;SqlClause.WITH>)][3] | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided string interpolated *handler*. |
| ![Public method]![Static member] | [WITH(String)][4]                                          | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *text*.                        |
| ![Public method]![Static member] | [WITH(String, SqlBuilder)][5]                              | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.        |
| ![Public method]![Static member] | **WITH(String, SqlSet)**                                   | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.        |


Syntax
------

```csharp
public static SqlBuilder WITH(
	string alias,
	SqlSet subQuery
)
```

#### Parameters

##### *alias*  [String][6]
The alias of the sub-query.

##### *subQuery*  [SqlSet][7]
The sub-query to use as the body of the WITH clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [WITH(String, SqlSet)][8].

See Also
--------

#### Reference
[SQL Class][9]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: WITH.md
[4]: WITH_1.md
[5]: WITH_2.md
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: ../SqlSet/README.md
[8]: ../SqlBuilder/WITH_3.md
[9]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/Static.gif "Static member"