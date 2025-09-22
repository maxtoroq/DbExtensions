SqlBuilder Class
================
Represents a mutable SQL string.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **DbExtensions.SqlBuilder**  
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class SqlBuilder
```

The **SqlBuilder** type exposes the following members.


Properties
----------

| Name                  | Description                                                                                                                                    |
| --------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| [Buffer][3]           | The underlying [StringBuilder][4].                                                                                                             |
| [CurrentClause][5]    | Gets or sets the current SQL clause, used to identify consecutive appends to the same clause.                                                  |
| [IsEmpty][6]          | Returns true if the buffer is empty.                                                                                                           |
| [NextClause][7]       | Gets or sets the next SQL clause. Used by clause continuation methods, such as [_(String)][8] and [_If(Boolean, ConditionalStringHandler)][9]. |
| [ParameterValues][10] | The parameter objects to be included in the database command.                                                                                  |


Methods
-------

| Name                                                                       | Description                                                                                                                                                                                                                  |
| -------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [_(SqlBuilder.ClauseStringHandler&lt;Current>)][11]                        | Appends the interpolated string *handler* to the current clause.                                                                                                                                                             |
| [_(String)][8]                                                             | Appends the *text* to the current clause.                                                                                                                                                                                    |
| [_Else][12]                                                                | Appends *handler* to the current clause if an antecedent call to [_If(Boolean, ConditionalStringHandler)][9] or [_ElseIf(Boolean, ConditionalElseStringHandler)][13] used a false condition                                  |
| [_ElseIf][13]                                                              | Appends *handler* to the current clause if *condition* is true and an antecedent call to [_If(Boolean, ConditionalStringHandler)][9] or [_ElseIf(Boolean, ConditionalElseStringHandler)][13] used a false condition.         |
| [_If][9]                                                                   | Appends the interpolated string *handler* to the current clause if *condition* is true.                                                                                                                                      |
| [Append(AppendStringHandler)][14]                                          | Appends the interpolated string *handler* to this instance.                                                                                                                                                                  |
| [Append(String)][15]                                                       | Appends *text* to this instance.                                                                                                                                                                                             |
| [AppendClause(SqlClause)][16]                                              | Appends the SQL *clause*.                                                                                                                                                                                                    |
| [AppendClause(SqlClause, String)][17]                                      | Appends the SQL *clause* and the provided *text*.                                                                                                                                                                            |
| [AppendClause&lt;TClause>()][18]                                           | Appends the SQL clause identified by TClause.                                                                                                                                                                                |
| [AppendClause&lt;TClause>(SqlBuilder.ClauseStringHandler&lt;TClause>)][19] | Appends the SQL clause identified by TClause and appends the interpolated string *handler*.                                                                                                                                  |
| [AppendClause&lt;TClause>(String)][20]                                     | Appends the SQL clause identified by TClause and appends the *text*.                                                                                                                                                         |
| [AppendLine][21]                                                           | Appends the default line terminator to this instance.                                                                                                                                                                        |
| [AppendSql][22]                                                            | Appends *sql* to this instance.                                                                                                                                                                                              |
| [Clone][23]                                                                | Creates and returns a copy of this instance.                                                                                                                                                                                 |
| [Create(AppendStringHandler)][24]                                          | Initializes a new instance of the **SqlBuilder** class using the provided interpolated string.                                                                                                                               |
| [Create(String)][25]                                                       | Initializes a new instance of the **SqlBuilder** class using the provided text.                                                                                                                                              |
| [CreateStatic(SqlBuilder)][26]                                             | Initializes a new instance of the **SqlBuilder** class using the provided interpolated string. Use this method if you don't expect to modify the returned builder; otherwise, use [Create(AppendStringHandler)][24] instead. |
| [CreateStatic(String)][27]                                                 | Initializes a new instance of the **SqlBuilder** class using the provided text. Use this method if you don't expect to modify the returned builder; otherwise, use [Create(String)][25] instead.                             |
| [CROSS_JOIN()][28]                                                         | Sets CROSS JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                      |
| [CROSS_JOIN(SqlBuilder.ClauseStringHandler&lt;CROSS_JOIN>)][29]            | Appends the CROSS JOIN clause using the provided interpolated string *handler*.                                                                                                                                              |
| [CROSS_JOIN(String)][30]                                                   | Appends the CROSS JOIN clause using the provided *text*.                                                                                                                                                                     |
| [DELETE_FROM(SqlBuilder.ClauseStringHandler&lt;DELETE_FROM>)][31]          | Appends the DELETE FROM clause using the provided interpolated string *handler*.                                                                                                                                             |
| [DELETE_FROM(String)][32]                                                  | Appends the DELETE FROM clause using the provided *text*.                                                                                                                                                                    |
| [FROM()][33]                                                               | Sets FROM as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                            |
| [FROM(SqlBuilder.ClauseStringHandler&lt;FROM>)][34]                        | Appends the FROM clause using the provided interpolated string *handler*.                                                                                                                                                    |
| [FROM(String)][35]                                                         | Appends the FROM clause using the provided *text*.                                                                                                                                                                           |
| [FROM(SqlBuilder, String)][36]                                             | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                                                           |
| [FROM(SqlSet, String)][37]                                                 | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                                                           |
| [GROUP_BY()][38]                                                           | Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                        |
| [GROUP_BY(SqlBuilder.ClauseStringHandler&lt;GROUP_BY>)][39]                | Appends the GROUP BY clause using the provided interpolated string *handler*.                                                                                                                                                |
| [GROUP_BY(String)][40]                                                     | Appends the GROUP BY clause using the provided *text*.                                                                                                                                                                       |
| [HAVING()][41]                                                             | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                          |
| [HAVING(SqlBuilder.ClauseStringHandler&lt;HAVING>)][42]                    | Appends the HAVING clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [HAVING(String)][43]                                                       | Appends the HAVING clause using the provided *text*.                                                                                                                                                                         |
| [INNER_JOIN()][44]                                                         | Sets INNER JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                      |
| [INNER_JOIN(SqlBuilder.ClauseStringHandler&lt;INNER_JOIN>)][45]            | Appends the INNER JOIN clause using the provided interpolated string *handler*.                                                                                                                                              |
| [INNER_JOIN(String)][46]                                                   | Appends the INNER JOIN clause using the provided *text*.                                                                                                                                                                     |
| [INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;INSERT_INTO>)][47]          | Appends the INSERT INTO clause using the provided interpolated string *handler*.                                                                                                                                             |
| [INSERT_INTO(String)][48]                                                  | Appends the INSERT INTO clause using the provided *text*.                                                                                                                                                                    |
| [InsertText][49]                                                           | Inserts a string into this instance at the specified character position.                                                                                                                                                     |
| [JOIN()][50]                                                               | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                            |
| [JOIN(SqlBuilder.ClauseStringHandler&lt;JOIN>)][51]                        | Appends the JOIN clause using the provided interpolated string *handler*.                                                                                                                                                    |
| [JOIN(String)][52]                                                         | Appends the JOIN clause using the provided *text*.                                                                                                                                                                           |
| [JoinSql(String, SqlBuilder[])][53]                                        | Concatenates a specified separator [String][54] between each element of a specified **SqlBuilder** array, yielding a single concatenated **SqlBuilder**.                                                                     |
| [JoinSql(String, IEnumerable&lt;SqlBuilder>)][55]                          | Concatenates the members of a constructed [IEnumerable&lt;T>][56] collection of type **SqlBuilder**, using the specified *separator* between each member.                                                                    |
| [LEFT_JOIN()][57]                                                          | Sets LEFT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                       |
| [LEFT_JOIN(SqlBuilder.ClauseStringHandler&lt;LEFT_JOIN>)][58]              | Appends the LEFT JOIN clause using the provided interpolated string *handler*.                                                                                                                                               |
| [LEFT_JOIN(String)][59]                                                    | Appends the LEFT JOIN clause using the provided *text*.                                                                                                                                                                      |
| [LIMIT()][60]                                                              | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                           |
| [LIMIT(SqlBuilder.ClauseStringHandler&lt;LIMIT>)][61]                      | Appends the LIMIT clause using the provided interpolated string *handler*.                                                                                                                                                   |
| [LIMIT(Int32)][62]                                                         | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                                                                                          |
| [LIMIT(String)][63]                                                        | Appends the LIMIT clause using the provided *text*.                                                                                                                                                                          |
| [OFFSET()][64]                                                             | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                          |
| [OFFSET(SqlBuilder.ClauseStringHandler&lt;OFFSET>)][65]                    | Appends the OFFSET clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [OFFSET(Int32)][66]                                                        | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                                                                                         |
| [OFFSET(String)][67]                                                       | Appends the OFFSET clause using the provided *text*.                                                                                                                                                                         |
| [ORDER_BY()][68]                                                           | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                        |
| [ORDER_BY(SqlBuilder.ClauseStringHandler&lt;ORDER_BY>)][69]                | Appends the ORDER BY clause using the provided interpolated string *handler*.                                                                                                                                                |
| [ORDER_BY(String)][70]                                                     | Appends the ORDER BY clause using the provided *text*.                                                                                                                                                                       |
| [RIGHT_JOIN()][71]                                                         | Sets RIGHT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                      |
| [RIGHT_JOIN(SqlBuilder.ClauseStringHandler&lt;RIGHT_JOIN>)][72]            | Appends the RIGHT JOIN clause using the provided interpolated string *handler*.                                                                                                                                              |
| [RIGHT_JOIN(String)][73]                                                   | Appends the RIGHT JOIN clause using the provided *text*.                                                                                                                                                                     |
| [SELECT()][74]                                                             | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                          |
| [SELECT(SqlBuilder.ClauseStringHandler&lt;SELECT>)][75]                    | Appends the SELECT clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [SELECT(String)][76]                                                       | Appends the SELECT clause using the provided *text*.                                                                                                                                                                         |
| [SET(SqlBuilder.ClauseStringHandler&lt;SET>)][77]                          | Appends the SET clause using the provided interpolated string *handler*.                                                                                                                                                     |
| [SET(String)][78]                                                          | Appends the SET clause using the provided *text*.                                                                                                                                                                            |
| [SetCurrentClause(SqlClause)][79]                                          | Sets *clause* as the current SQL clause.                                                                                                                                                                                     |
| [SetCurrentClause&lt;TClause>()][80]                                       | Sets the clause identified by TClause as the current SQL clause.                                                                                                                                                             |
| [SetNextClause(SqlClause)][81]                                             | Sets *clause* as the next SQL clause.                                                                                                                                                                                        |
| [SetNextClause&lt;TClause>()][82]                                          | Sets the clause identified by TClause as the next SQL clause.                                                                                                                                                                |
| [ToString][83]                                                             | Converts the value of this instance to a [String][54]. <br/>(Overrides [Object.ToString()][84])                                                                                                                              |
| [UNION][85]                                                                | Appends the UNION clause.                                                                                                                                                                                                    |
| [UPDATE(SqlBuilder.ClauseStringHandler&lt;UPDATE>)][86]                    | Appends the UPDATE clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [UPDATE(String)][87]                                                       | Appends the UPDATE clause using the provided *text*.                                                                                                                                                                         |
| [VALUES(SqlBuilder.ClauseStringHandler&lt;VALUES>)][88]                    | Appends the VALUES clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [VALUES(Object[])][89]                                                     | Appends the VALUES clause using the provided parameters.                                                                                                                                                                     |
| [WHERE()][90]                                                              | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                           |
| [WHERE(SqlBuilder.ClauseStringHandler&lt;WHERE>)][91]                      | Appends the WHERE clause using the provided interpolated string *handler*.                                                                                                                                                   |
| [WHERE(String)][92]                                                        | Appends the WHERE clause using the provided *text*.                                                                                                                                                                          |
| [WITH(SqlBuilder.ClauseStringHandler&lt;WITH>)][93]                        | Appends the WITH clause using the provided interpolated string *handler*.                                                                                                                                                    |
| [WITH(String)][94]                                                         | Appends the WITH clause using the provided *text*.                                                                                                                                                                           |
| [WITH(String, SqlBuilder)][95]                                             | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                                                           |
| [WITH(String, SqlSet)][96]                                                 | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                                                           |


Remarks
-------
For information on how to use SqlBuilder see [SqlBuilder Tutorial][97].

See Also
--------

#### Reference
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.object
[2]: ../README.md
[3]: Buffer.md
[4]: https://learn.microsoft.com/dotnet/api/system.text.stringbuilder
[5]: CurrentClause.md
[6]: IsEmpty.md
[7]: NextClause.md
[8]: __1.md
[9]: _If.md
[10]: ParameterValues.md
[11]: _.md
[12]: _Else.md
[13]: _ElseIf.md
[14]: Append.md
[15]: Append_1.md
[16]: AppendClause.md
[17]: AppendClause_1.md
[18]: AppendClause__1.md
[19]: AppendClause__1_1.md
[20]: AppendClause__1_2.md
[21]: AppendLine.md
[22]: AppendSql.md
[23]: Clone.md
[24]: Create.md
[25]: Create_1.md
[26]: CreateStatic.md
[27]: CreateStatic_1.md
[28]: CROSS_JOIN.md
[29]: CROSS_JOIN_1.md
[30]: CROSS_JOIN_2.md
[31]: DELETE_FROM.md
[32]: DELETE_FROM_1.md
[33]: FROM.md
[34]: FROM_2.md
[35]: FROM_4.md
[36]: FROM_1.md
[37]: FROM_3.md
[38]: GROUP_BY.md
[39]: GROUP_BY_1.md
[40]: GROUP_BY_2.md
[41]: HAVING.md
[42]: HAVING_1.md
[43]: HAVING_2.md
[44]: INNER_JOIN.md
[45]: INNER_JOIN_1.md
[46]: INNER_JOIN_2.md
[47]: INSERT_INTO.md
[48]: INSERT_INTO_1.md
[49]: InsertText.md
[50]: JOIN.md
[51]: JOIN_1.md
[52]: JOIN_2.md
[53]: JoinSql.md
[54]: https://learn.microsoft.com/dotnet/api/system.string
[55]: JoinSql_1.md
[56]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[57]: LEFT_JOIN.md
[58]: LEFT_JOIN_1.md
[59]: LEFT_JOIN_2.md
[60]: LIMIT.md
[61]: LIMIT_1.md
[62]: LIMIT_2.md
[63]: LIMIT_3.md
[64]: OFFSET.md
[65]: OFFSET_1.md
[66]: OFFSET_2.md
[67]: OFFSET_3.md
[68]: ORDER_BY.md
[69]: ORDER_BY_1.md
[70]: ORDER_BY_2.md
[71]: RIGHT_JOIN.md
[72]: RIGHT_JOIN_1.md
[73]: RIGHT_JOIN_2.md
[74]: SELECT.md
[75]: SELECT_1.md
[76]: SELECT_2.md
[77]: SET.md
[78]: SET_1.md
[79]: SetCurrentClause.md
[80]: SetCurrentClause__1.md
[81]: SetNextClause.md
[82]: SetNextClause__1.md
[83]: ToString.md
[84]: https://learn.microsoft.com/dotnet/api/system.object.tostring
[85]: UNION.md
[86]: UPDATE.md
[87]: UPDATE_1.md
[88]: VALUES.md
[89]: VALUES_1.md
[90]: WHERE.md
[91]: WHERE_1.md
[92]: WHERE_2.md
[93]: WITH.md
[94]: WITH_1.md
[95]: WITH_2.md
[96]: WITH_3.md
[97]: https://maxtoroq.github.io/DbExtensions/docs/7/SqlBuilder.html