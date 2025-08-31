SQL Class
=========
Provides a set of static (Shared in Visual Basic) methods to create [SqlBuilder][1] instances.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **DbExtensions.SQL**  
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static class SQL
```

The **SQL** type exposes the following members.


Methods
-------

|                                  | Name                                                                     | Description                                                                                                                                 |
| -------------------------------- | ------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]![Static member] | [DELETE_FROM(SqlInterpolatedStringHandler&lt;SqlClause.DELETE_FROM>)][4] | Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided string interpolated *handler*. |
| ![Public method]![Static member] | [DELETE_FROM(String)][5]                                                 | Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided *text*.                        |
| ![Public method]![Static member] | [INSERT_INTO(SqlInterpolatedStringHandler&lt;SqlClause.INSERT_INTO>)][6] | Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided string interpolated *handler*. |
| ![Public method]![Static member] | [INSERT_INTO(String)][7]                                                 | Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided *text*.                        |
| ![Public method]![Static member] | [SELECT(SqlInterpolatedStringHandler&lt;SqlClause.SELECT>)][8]           | Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided string interpolated *handler*.      |
| ![Public method]![Static member] | [SELECT(String)][9]                                                      | Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided *text*.                             |
| ![Public method]![Static member] | [UPDATE(SqlInterpolatedStringHandler&lt;SqlClause.UPDATE>)][10]          | Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided string interpolated *handler*.      |
| ![Public method]![Static member] | [UPDATE(String)][11]                                                     | Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided *text*.                             |
| ![Public method]![Static member] | [WITH(SqlInterpolatedStringHandler&lt;SqlClause.WITH>)][12]              | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided string interpolated *handler*.        |
| ![Public method]![Static member] | [WITH(String)][13]                                                       | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *text*.                               |
| ![Public method]![Static member] | [WITH(String, SqlBuilder)][14]                                           | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.               |
| ![Public method]![Static member] | [WITH(String, SqlSet)][15]                                               | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.               |


See Also
--------

#### Reference
[DbExtensions Namespace][3]  

[1]: ../SqlBuilder/README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: ../README.md
[4]: DELETE_FROM.md
[5]: DELETE_FROM_1.md
[6]: INSERT_INTO.md
[7]: INSERT_INTO_1.md
[8]: SELECT.md
[9]: SELECT_1.md
[10]: UPDATE.md
[11]: UPDATE_1.md
[12]: WITH.md
[13]: WITH_1.md
[14]: WITH_2.md
[15]: WITH_3.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/Static.gif "Static member"