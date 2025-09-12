SQL.WITH(String, SqlBuilder) Method
===================================
Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                                  | Name                                                         | Description                                                                                                                          |
| -------------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method]![Static member] | [WITH(SqlBuilder.ClauseStringHandler&lt;SqlClause.WITH>)][3] | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided string interpolated *handler*. |
| ![Public method]![Static member] | [WITH(String)][4]                                            | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *text*.                        |
| ![Public method]![Static member] | **WITH(String, SqlBuilder)**                                 | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.        |
| ![Public method]![Static member] | [WITH(String, SqlSet)][5]                                    | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.        |


Syntax
------

```csharp
public static SqlBuilder WITH(
	string alias,
	SqlBuilder subQuery
)
```

#### Parameters

##### *alias*  [String][6]
The alias of the sub-query.

##### *subQuery*  [SqlBuilder][1]
The sub-query to use as the body of the WITH clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [WITH(String, SqlBuilder)][7].

See Also
--------

#### Reference
[SQL Class][8]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: WITH.md
[4]: WITH_1.md
[5]: WITH_3.md
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: ../SqlBuilder/WITH_2.md
[8]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/Static.gif "Static member"