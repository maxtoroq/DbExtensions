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
| [IsEmpty][6]          | Returns `true` if the buffer is empty.                                                                                                         |
| [NextClause][7]       | Gets or sets the next SQL clause. Used by clause continuation methods, such as [_(String)][8] and [_If(Boolean, ConditionalStringHandler)][9]. |
| [ParameterValues][10] | The parameter objects to be included in the database command.                                                                                  |


Methods
-------

| Name                                                              | Description                                                                                                                                                                                                                 |
| ----------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [_(SqlBuilder.ClauseStringHandler&lt;Current>)][11]               | Appends the interpolated string *handler* to the current clause.                                                                                                                                                            |
| [_(String)][8]                                                    | Appends the *text* to the current clause.                                                                                                                                                                                   |
| [_Else][12]                                                       | Appends *handler* to the current clause if an antecedent call to [_If(Boolean, ConditionalStringHandler)][9] or [_ElseIf(Boolean, ConditionalElseStringHandler)][13] used a `false` condition                               |
| [_ElseIf][13]                                                     | Appends *handler* to the current clause if *condition* is `true` and an antecedent call to [_If(Boolean, ConditionalStringHandler)][9] or [_ElseIf(Boolean, ConditionalElseStringHandler)][13] used a `false` condition.    |
| [_If][9]                                                          | Appends the interpolated string *handler* to the current clause if *condition* is `true`.                                                                                                                                   |
| [Append(AppendStringHandler)][14]                                 | Appends the interpolated string *handler* to this instance.                                                                                                                                                                 |
| [Append(String)][15]                                              | Appends *text* to this instance.                                                                                                                                                                                            |
| [AppendClause(SqlClause)][16]                                     | Appends the SQL *clause*.                                                                                                                                                                                                   |
| [AppendClause&lt;TClause>()][17]                                  | Appends the SQL clause identified by TClause.                                                                                                                                                                               |
| [AppendElse][18]                                                  | Appends the interpolated string *handler* if an antecedent call to [AppendIf(Boolean, AppendStringHandler)][19] or [AppendElseIf(Boolean, AppendElseStringHandler)][20] used a `false` condition                            |
| [AppendElseIf][20]                                                | Appends the interpolated string *handler* if *condition* is `true` and an antecedent call to [AppendIf(Boolean, AppendStringHandler)][19] or [AppendElseIf(Boolean, AppendElseStringHandler)][20] used a `false` condition. |
| [AppendIf][19]                                                    | Appends the interpolated string *handler* if *condition* is `true`.                                                                                                                                                         |
| [AppendLine][21]                                                  | Appends the default line terminator to this instance.                                                                                                                                                                       |
| [AppendSql][22]                                                   | Appends *sql* to this instance.                                                                                                                                                                                             |
| [Clone][23]                                                       | Creates and returns a copy of this instance.                                                                                                                                                                                |
| [CROSS_JOIN()][24]                                                | Sets CROSS JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                     |
| [CROSS_JOIN(SqlBuilder.ClauseStringHandler&lt;CROSS_JOIN>)][25]   | Appends the CROSS JOIN clause using the provided interpolated string *handler*.                                                                                                                                             |
| [CROSS_JOIN(String)][26]                                          | Appends the CROSS JOIN clause using the provided *text*.                                                                                                                                                                    |
| [DELETE_FROM(SqlBuilder.ClauseStringHandler&lt;DELETE_FROM>)][27] | Appends the DELETE FROM clause using the provided interpolated string *handler*.                                                                                                                                            |
| [DELETE_FROM(String)][28]                                         | Appends the DELETE FROM clause using the provided *text*.                                                                                                                                                                   |
| [FROM()][29]                                                      | Sets FROM as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                           |
| [FROM(SqlBuilder.ClauseStringHandler&lt;FROM>)][30]               | Appends the FROM clause using the provided interpolated string *handler*.                                                                                                                                                   |
| [FROM(String)][31]                                                | Appends the FROM clause using the provided *text*.                                                                                                                                                                          |
| [FROM(SqlBuilder, String)][32]                                    | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                                                          |
| [FROM(SqlSet, String)][33]                                        | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                                                          |
| [GROUP_BY()][34]                                                  | Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                       |
| [GROUP_BY(SqlBuilder.ClauseStringHandler&lt;GROUP_BY>)][35]       | Appends the GROUP BY clause using the provided interpolated string *handler*.                                                                                                                                               |
| [GROUP_BY(String)][36]                                            | Appends the GROUP BY clause using the provided *text*.                                                                                                                                                                      |
| [HAVING()][37]                                                    | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                         |
| [HAVING(SqlBuilder.ClauseStringHandler&lt;HAVING>)][38]           | Appends the HAVING clause using the provided interpolated string *handler*.                                                                                                                                                 |
| [HAVING(String)][39]                                              | Appends the HAVING clause using the provided *text*.                                                                                                                                                                        |
| [INNER_JOIN()][40]                                                | Sets INNER JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                     |
| [INNER_JOIN(SqlBuilder.ClauseStringHandler&lt;INNER_JOIN>)][41]   | Appends the INNER JOIN clause using the provided interpolated string *handler*.                                                                                                                                             |
| [INNER_JOIN(String)][42]                                          | Appends the INNER JOIN clause using the provided *text*.                                                                                                                                                                    |
| [INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;INSERT_INTO>)][43] | Appends the INSERT INTO clause using the provided interpolated string *handler*.                                                                                                                                            |
| [INSERT_INTO(String)][44]                                         | Appends the INSERT INTO clause using the provided *text*.                                                                                                                                                                   |
| [InsertText][45]                                                  | Inserts a string into this instance at the specified character position.                                                                                                                                                    |
| [JOIN()][46]                                                      | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                           |
| [JOIN(SqlBuilder.ClauseStringHandler&lt;JOIN>)][47]               | Appends the JOIN clause using the provided interpolated string *handler*.                                                                                                                                                   |
| [JOIN(String)][48]                                                | Appends the JOIN clause using the provided *text*.                                                                                                                                                                          |
| [JoinSql(String, SqlBuilder[])][49]                               | Concatenates a specified separator [String][50] between each element of a specified **SqlBuilder** array, yielding a single concatenated **SqlBuilder**.                                                                    |
| [JoinSql(String, IEnumerable&lt;SqlBuilder>)][51]                 | Concatenates the members of a constructed [IEnumerable&lt;T>][52] collection of type **SqlBuilder**, using the specified *separator* between each member.                                                                   |
| [LEFT_JOIN()][53]                                                 | Sets LEFT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                      |
| [LEFT_JOIN(SqlBuilder.ClauseStringHandler&lt;LEFT_JOIN>)][54]     | Appends the LEFT JOIN clause using the provided interpolated string *handler*.                                                                                                                                              |
| [LEFT_JOIN(String)][55]                                           | Appends the LEFT JOIN clause using the provided *text*.                                                                                                                                                                     |
| [LIMIT()][56]                                                     | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                          |
| [LIMIT(SqlBuilder.ClauseStringHandler&lt;LIMIT>)][57]             | Appends the LIMIT clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [LIMIT(Int32)][58]                                                | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                                                                                         |
| [LIMIT(String)][59]                                               | Appends the LIMIT clause using the provided *text*.                                                                                                                                                                         |
| [OFFSET()][60]                                                    | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                         |
| [OFFSET(SqlBuilder.ClauseStringHandler&lt;OFFSET>)][61]           | Appends the OFFSET clause using the provided interpolated string *handler*.                                                                                                                                                 |
| [OFFSET(Int32)][62]                                               | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                                                                                        |
| [OFFSET(String)][63]                                              | Appends the OFFSET clause using the provided *text*.                                                                                                                                                                        |
| [ORDER_BY()][64]                                                  | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                       |
| [ORDER_BY(SqlBuilder.ClauseStringHandler&lt;ORDER_BY>)][65]       | Appends the ORDER BY clause using the provided interpolated string *handler*.                                                                                                                                               |
| [ORDER_BY(String)][66]                                            | Appends the ORDER BY clause using the provided *text*.                                                                                                                                                                      |
| [RIGHT_JOIN()][67]                                                | Sets RIGHT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                     |
| [RIGHT_JOIN(SqlBuilder.ClauseStringHandler&lt;RIGHT_JOIN>)][68]   | Appends the RIGHT JOIN clause using the provided interpolated string *handler*.                                                                                                                                             |
| [RIGHT_JOIN(String)][69]                                          | Appends the RIGHT JOIN clause using the provided *text*.                                                                                                                                                                    |
| [SELECT()][70]                                                    | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                         |
| [SELECT(SqlBuilder.ClauseStringHandler&lt;SELECT>)][71]           | Appends the SELECT clause using the provided interpolated string *handler*.                                                                                                                                                 |
| [SELECT(String)][72]                                              | Appends the SELECT clause using the provided *text*.                                                                                                                                                                        |
| [SET(SqlBuilder.ClauseStringHandler&lt;SET>)][73]                 | Appends the SET clause using the provided interpolated string *handler*.                                                                                                                                                    |
| [SET(String)][74]                                                 | Appends the SET clause using the provided *text*.                                                                                                                                                                           |
| [SetCurrentClause(SqlClause)][75]                                 | Sets *clause* as the current SQL clause.                                                                                                                                                                                    |
| [SetCurrentClause&lt;TClause>()][76]                              | Sets the clause identified by TClause as the current SQL clause.                                                                                                                                                            |
| [SetNextClause(SqlClause)][77]                                    | Sets *clause* as the next SQL clause.                                                                                                                                                                                       |
| [SetNextClause&lt;TClause>()][78]                                 | Sets the clause identified by TClause as the next SQL clause.                                                                                                                                                               |
| [ToString][79]                                                    | Converts the value of this instance to a [String][50]. <br/>(Overrides [Object.ToString()][80])                                                                                                                             |
| [UNION][81]                                                       | Appends the UNION clause.                                                                                                                                                                                                   |
| [UPDATE(SqlBuilder.ClauseStringHandler&lt;UPDATE>)][82]           | Appends the UPDATE clause using the provided interpolated string *handler*.                                                                                                                                                 |
| [UPDATE(String)][83]                                              | Appends the UPDATE clause using the provided *text*.                                                                                                                                                                        |
| [VALUES(SqlBuilder.ClauseStringHandler&lt;VALUES>)][84]           | Appends the VALUES clause using the provided interpolated string *handler*.                                                                                                                                                 |
| [VALUES(Object[])][85]                                            | Appends the VALUES clause using the provided parameters.                                                                                                                                                                    |
| [WHERE()][86]                                                     | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                          |
| [WHERE(SqlBuilder.ClauseStringHandler&lt;WHERE>)][87]             | Appends the WHERE clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [WHERE(String)][88]                                               | Appends the WHERE clause using the provided *text*.                                                                                                                                                                         |
| [WITH(SqlBuilder.ClauseStringHandler&lt;WITH>)][89]               | Appends the WITH clause using the provided interpolated string *handler*.                                                                                                                                                   |
| [WITH(String)][90]                                                | Appends the WITH clause using the provided *text*.                                                                                                                                                                          |
| [WITH(String, SqlBuilder)][91]                                    | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                                                          |
| [WITH(String, SqlSet)][92]                                        | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                                                          |


Remarks
-------
For information on how to use SqlBuilder see [SqlBuilder Tutorial][93].

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
[17]: AppendClause__1.md
[18]: AppendElse.md
[19]: AppendIf.md
[20]: AppendElseIf.md
[21]: AppendLine.md
[22]: AppendSql.md
[23]: Clone.md
[24]: CROSS_JOIN.md
[25]: CROSS_JOIN_1.md
[26]: CROSS_JOIN_2.md
[27]: DELETE_FROM.md
[28]: DELETE_FROM_1.md
[29]: FROM.md
[30]: FROM_2.md
[31]: FROM_4.md
[32]: FROM_1.md
[33]: FROM_3.md
[34]: GROUP_BY.md
[35]: GROUP_BY_1.md
[36]: GROUP_BY_2.md
[37]: HAVING.md
[38]: HAVING_1.md
[39]: HAVING_2.md
[40]: INNER_JOIN.md
[41]: INNER_JOIN_1.md
[42]: INNER_JOIN_2.md
[43]: INSERT_INTO.md
[44]: INSERT_INTO_1.md
[45]: InsertText.md
[46]: JOIN.md
[47]: JOIN_1.md
[48]: JOIN_2.md
[49]: JoinSql.md
[50]: https://learn.microsoft.com/dotnet/api/system.string
[51]: JoinSql_1.md
[52]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[53]: LEFT_JOIN.md
[54]: LEFT_JOIN_1.md
[55]: LEFT_JOIN_2.md
[56]: LIMIT.md
[57]: LIMIT_1.md
[58]: LIMIT_2.md
[59]: LIMIT_3.md
[60]: OFFSET.md
[61]: OFFSET_1.md
[62]: OFFSET_2.md
[63]: OFFSET_3.md
[64]: ORDER_BY.md
[65]: ORDER_BY_1.md
[66]: ORDER_BY_2.md
[67]: RIGHT_JOIN.md
[68]: RIGHT_JOIN_1.md
[69]: RIGHT_JOIN_2.md
[70]: SELECT.md
[71]: SELECT_1.md
[72]: SELECT_2.md
[73]: SET.md
[74]: SET_1.md
[75]: SetCurrentClause.md
[76]: SetCurrentClause__1.md
[77]: SetNextClause.md
[78]: SetNextClause__1.md
[79]: ToString.md
[80]: https://learn.microsoft.com/dotnet/api/system.object.tostring
[81]: UNION.md
[82]: UPDATE.md
[83]: UPDATE_1.md
[84]: VALUES.md
[85]: VALUES_1.md
[86]: WHERE.md
[87]: WHERE_1.md
[88]: WHERE_2.md
[89]: WITH.md
[90]: WITH_1.md
[91]: WITH_2.md
[92]: WITH_3.md
[93]: https://maxtoroq.github.io/DbExtensions/docs/7/SqlBuilder.html