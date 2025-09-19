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

| Name                                                                       | Description                                                                                                                                                                                                          |
| -------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [_(SqlBuilder.ClauseStringHandler&lt;Current>)][11]                        | Appends the interpolated string *handler* to the current clause.                                                                                                                                                     |
| [_(String)][8]                                                             | Appends the *text* to the current clause.                                                                                                                                                                            |
| [_Else][12]                                                                | Appends *handler* to the current clause if an antecedent call to [_If(Boolean, ConditionalStringHandler)][9] or [_ElseIf(Boolean, ConditionalElseStringHandler)][13] used a false condition                          |
| [_ElseIf][13]                                                              | Appends *handler* to the current clause if *condition* is true and an antecedent call to [_If(Boolean, ConditionalStringHandler)][9] or [_ElseIf(Boolean, ConditionalElseStringHandler)][13] used a false condition. |
| [_If][9]                                                                   | Appends the interpolated string *handler* to the current clause if *condition* is true.                                                                                                                              |
| [Append(AppendStringHandler)][14]                                          | Appends the interpolated string *handler* to this instance.                                                                                                                                                          |
| [Append(SqlBuilder)][15]                                                   | Appends *sql* to this instance.                                                                                                                                                                                      |
| [Append(String)][16]                                                       | Appends *text* to this instance.                                                                                                                                                                                     |
| [AppendClause(SqlClause)][17]                                              | Appends the SQL *clause*.                                                                                                                                                                                            |
| [AppendClause(SqlClause, String)][18]                                      | Appends the SQL *clause* and the provided *text*.                                                                                                                                                                    |
| [AppendClause&lt;TClause>()][19]                                           | Appends the SQL clause identified by TClause.                                                                                                                                                                        |
| [AppendClause&lt;TClause>(SqlBuilder.ClauseStringHandler&lt;TClause>)][20] | Appends the SQL clause identified by TClause and appends the interpolated string *handler*.                                                                                                                          |
| [AppendClause&lt;TClause>(String)][21]                                     | Appends the SQL clause identified by TClause and appends the *text*.                                                                                                                                                 |
| [AppendLine][22]                                                           | Appends the default line terminator to this instance.                                                                                                                                                                |
| [Clone][23]                                                                | Creates and returns a copy of this instance.                                                                                                                                                                         |
| [Create(AppendStringHandler)][24]                                          | Initializes a new instance of the **SqlBuilder** class using the provided interpolated string.                                                                                                                       |
| [Create(String)][25]                                                       | Initializes a new instance of the **SqlBuilder** class using the provided text.                                                                                                                                      |
| [CROSS_JOIN()][26]                                                         | Sets CROSS JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                              |
| [CROSS_JOIN(SqlBuilder.ClauseStringHandler&lt;CROSS_JOIN>)][27]            | Appends the CROSS JOIN clause using the provided interpolated string *handler*.                                                                                                                                      |
| [CROSS_JOIN(String)][28]                                                   | Appends the CROSS JOIN clause using the provided *text*.                                                                                                                                                             |
| [DELETE_FROM(SqlBuilder.ClauseStringHandler&lt;DELETE_FROM>)][29]          | Appends the DELETE FROM clause using the provided interpolated string *handler*.                                                                                                                                     |
| [DELETE_FROM(String)][30]                                                  | Appends the DELETE FROM clause using the provided *text*.                                                                                                                                                            |
| [FROM()][31]                                                               | Sets FROM as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                    |
| [FROM(SqlBuilder.ClauseStringHandler&lt;FROM>)][32]                        | Appends the FROM clause using the provided interpolated string *handler*.                                                                                                                                            |
| [FROM(String)][33]                                                         | Appends the FROM clause using the provided *text*.                                                                                                                                                                   |
| [FROM(SqlBuilder, String)][34]                                             | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                                                   |
| [FROM(SqlSet, String)][35]                                                 | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                                                   |
| [GROUP_BY()][36]                                                           | Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                |
| [GROUP_BY(SqlBuilder.ClauseStringHandler&lt;GROUP_BY>)][37]                | Appends the GROUP BY clause using the provided interpolated string *handler*.                                                                                                                                        |
| [GROUP_BY(String)][38]                                                     | Appends the GROUP BY clause using the provided *text*.                                                                                                                                                               |
| [HAVING()][39]                                                             | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                  |
| [HAVING(SqlBuilder.ClauseStringHandler&lt;HAVING>)][40]                    | Appends the HAVING clause using the provided interpolated string *handler*.                                                                                                                                          |
| [HAVING(String)][41]                                                       | Appends the HAVING clause using the provided *text*.                                                                                                                                                                 |
| [INNER_JOIN()][42]                                                         | Sets INNER JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                              |
| [INNER_JOIN(SqlBuilder.ClauseStringHandler&lt;INNER_JOIN>)][43]            | Appends the INNER JOIN clause using the provided interpolated string *handler*.                                                                                                                                      |
| [INNER_JOIN(String)][44]                                                   | Appends the INNER JOIN clause using the provided *text*.                                                                                                                                                             |
| [INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;INSERT_INTO>)][45]          | Appends the INSERT INTO clause using the provided interpolated string *handler*.                                                                                                                                     |
| [INSERT_INTO(String)][46]                                                  | Appends the INSERT INTO clause using the provided *text*.                                                                                                                                                            |
| [InsertText][47]                                                           | Inserts a string into this instance at the specified character position.                                                                                                                                             |
| [JOIN()][48]                                                               | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                    |
| [JOIN(SqlBuilder.ClauseStringHandler&lt;JOIN>)][49]                        | Appends the JOIN clause using the provided interpolated string *handler*.                                                                                                                                            |
| [JOIN(String)][50]                                                         | Appends the JOIN clause using the provided *text*.                                                                                                                                                                   |
| [JoinSql(String, SqlBuilder[])][51]                                        | Concatenates a specified separator [String][52] between each element of a specified **SqlBuilder** array, yielding a single concatenated **SqlBuilder**.                                                             |
| [JoinSql(String, IEnumerable&lt;SqlBuilder>)][53]                          | Concatenates the members of a constructed [IEnumerable&lt;T>][54] collection of type **SqlBuilder**, using the specified *separator* between each member.                                                            |
| [LEFT_JOIN()][55]                                                          | Sets LEFT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                               |
| [LEFT_JOIN(SqlBuilder.ClauseStringHandler&lt;LEFT_JOIN>)][56]              | Appends the LEFT JOIN clause using the provided interpolated string *handler*.                                                                                                                                       |
| [LEFT_JOIN(String)][57]                                                    | Appends the LEFT JOIN clause using the provided *text*.                                                                                                                                                              |
| [LIMIT()][58]                                                              | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                   |
| [LIMIT(SqlBuilder.ClauseStringHandler&lt;LIMIT>)][59]                      | Appends the LIMIT clause using the provided interpolated string *handler*.                                                                                                                                           |
| [LIMIT(Int32)][60]                                                         | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                                                                                  |
| [LIMIT(String)][61]                                                        | Appends the LIMIT clause using the provided *text*.                                                                                                                                                                  |
| [OFFSET()][62]                                                             | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                  |
| [OFFSET(SqlBuilder.ClauseStringHandler&lt;OFFSET>)][63]                    | Appends the OFFSET clause using the provided interpolated string *handler*.                                                                                                                                          |
| [OFFSET(Int32)][64]                                                        | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                                                                                 |
| [OFFSET(String)][65]                                                       | Appends the OFFSET clause using the provided *text*.                                                                                                                                                                 |
| [ORDER_BY()][66]                                                           | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                |
| [ORDER_BY(SqlBuilder.ClauseStringHandler&lt;ORDER_BY>)][67]                | Appends the ORDER BY clause using the provided interpolated string *handler*.                                                                                                                                        |
| [ORDER_BY(String)][68]                                                     | Appends the ORDER BY clause using the provided *text*.                                                                                                                                                               |
| [RIGHT_JOIN()][69]                                                         | Sets RIGHT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                              |
| [RIGHT_JOIN(SqlBuilder.ClauseStringHandler&lt;RIGHT_JOIN>)][70]            | Appends the RIGHT JOIN clause using the provided interpolated string *handler*.                                                                                                                                      |
| [RIGHT_JOIN(String)][71]                                                   | Appends the RIGHT JOIN clause using the provided *text*.                                                                                                                                                             |
| [SELECT()][72]                                                             | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                  |
| [SELECT(SqlBuilder.ClauseStringHandler&lt;SELECT>)][73]                    | Appends the SELECT clause using the provided interpolated string *handler*.                                                                                                                                          |
| [SELECT(String)][74]                                                       | Appends the SELECT clause using the provided *text*.                                                                                                                                                                 |
| [SET(SqlBuilder.ClauseStringHandler&lt;SET>)][75]                          | Appends the SET clause using the provided interpolated string *handler*.                                                                                                                                             |
| [SET(String)][76]                                                          | Appends the SET clause using the provided *text*.                                                                                                                                                                    |
| [SetCurrentClause(SqlClause)][77]                                          | Sets *clause* as the current SQL clause.                                                                                                                                                                             |
| [SetCurrentClause&lt;TClause>()][78]                                       | Sets the clause identified by TClause as the current SQL clause.                                                                                                                                                     |
| [SetNextClause(SqlClause)][79]                                             | Sets *clause* as the next SQL clause.                                                                                                                                                                                |
| [SetNextClause&lt;TClause>()][80]                                          | Sets the clause identified by TClause as the next SQL clause.                                                                                                                                                        |
| [ToString][81]                                                             | Converts the value of this instance to a [String][52]. <br/>(Overrides [Object.ToString()][82])                                                                                                                      |
| [UNION][83]                                                                | Appends the UNION clause.                                                                                                                                                                                            |
| [UPDATE(SqlBuilder.ClauseStringHandler&lt;UPDATE>)][84]                    | Appends the UPDATE clause using the provided interpolated string *handler*.                                                                                                                                          |
| [UPDATE(String)][85]                                                       | Appends the UPDATE clause using the provided *text*.                                                                                                                                                                 |
| [VALUES(SqlBuilder.ClauseStringHandler&lt;VALUES>)][86]                    | Appends the VALUES clause using the provided interpolated string *handler*.                                                                                                                                          |
| [VALUES(Object[])][87]                                                     | Appends the VALUES clause using the provided parameters.                                                                                                                                                             |
| [WHERE()][88]                                                              | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                   |
| [WHERE(SqlBuilder.ClauseStringHandler&lt;WHERE>)][89]                      | Appends the WHERE clause using the provided interpolated string *handler*.                                                                                                                                           |
| [WHERE(String)][90]                                                        | Appends the WHERE clause using the provided *text*.                                                                                                                                                                  |
| [WITH(SqlBuilder.ClauseStringHandler&lt;WITH>)][91]                        | Appends the WITH clause using the provided interpolated string *handler*.                                                                                                                                            |
| [WITH(String)][92]                                                         | Appends the WITH clause using the provided *text*.                                                                                                                                                                   |
| [WITH(String, SqlBuilder)][93]                                             | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                                                   |
| [WITH(String, SqlSet)][94]                                                 | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                                                   |


Remarks
-------
For information on how to use SqlBuilder see [SqlBuilder Tutorial][95].

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
[14]: Append_1.md
[15]: Append.md
[16]: Append_2.md
[17]: AppendClause.md
[18]: AppendClause_1.md
[19]: AppendClause__1.md
[20]: AppendClause__1_1.md
[21]: AppendClause__1_2.md
[22]: AppendLine.md
[23]: Clone.md
[24]: Create.md
[25]: Create_1.md
[26]: CROSS_JOIN.md
[27]: CROSS_JOIN_1.md
[28]: CROSS_JOIN_2.md
[29]: DELETE_FROM.md
[30]: DELETE_FROM_1.md
[31]: FROM.md
[32]: FROM_2.md
[33]: FROM_4.md
[34]: FROM_1.md
[35]: FROM_3.md
[36]: GROUP_BY.md
[37]: GROUP_BY_1.md
[38]: GROUP_BY_2.md
[39]: HAVING.md
[40]: HAVING_1.md
[41]: HAVING_2.md
[42]: INNER_JOIN.md
[43]: INNER_JOIN_1.md
[44]: INNER_JOIN_2.md
[45]: INSERT_INTO.md
[46]: INSERT_INTO_1.md
[47]: InsertText.md
[48]: JOIN.md
[49]: JOIN_1.md
[50]: JOIN_2.md
[51]: JoinSql.md
[52]: https://learn.microsoft.com/dotnet/api/system.string
[53]: JoinSql_1.md
[54]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[55]: LEFT_JOIN.md
[56]: LEFT_JOIN_1.md
[57]: LEFT_JOIN_2.md
[58]: LIMIT.md
[59]: LIMIT_1.md
[60]: LIMIT_2.md
[61]: LIMIT_3.md
[62]: OFFSET.md
[63]: OFFSET_1.md
[64]: OFFSET_2.md
[65]: OFFSET_3.md
[66]: ORDER_BY.md
[67]: ORDER_BY_1.md
[68]: ORDER_BY_2.md
[69]: RIGHT_JOIN.md
[70]: RIGHT_JOIN_1.md
[71]: RIGHT_JOIN_2.md
[72]: SELECT.md
[73]: SELECT_1.md
[74]: SELECT_2.md
[75]: SET.md
[76]: SET_1.md
[77]: SetCurrentClause.md
[78]: SetCurrentClause__1.md
[79]: SetNextClause.md
[80]: SetNextClause__1.md
[81]: ToString.md
[82]: https://learn.microsoft.com/dotnet/api/system.object.tostring
[83]: UNION.md
[84]: UPDATE.md
[85]: UPDATE_1.md
[86]: VALUES.md
[87]: VALUES_1.md
[88]: WHERE.md
[89]: WHERE_1.md
[90]: WHERE_2.md
[91]: WITH.md
[92]: WITH_1.md
[93]: WITH_2.md
[94]: WITH_3.md
[95]: https://maxtoroq.github.io/DbExtensions/docs/7/SqlBuilder.html