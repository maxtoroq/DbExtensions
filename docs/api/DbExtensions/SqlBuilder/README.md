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

| Name                                                              | Description                                                                                                                                                                                                                  |
| ----------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [_(SqlBuilder.ClauseStringHandler&lt;Current>)][11]               | Appends the interpolated string *handler* to the current clause.                                                                                                                                                             |
| [_(String)][8]                                                    | Appends the *text* to the current clause.                                                                                                                                                                                    |
| [_Else][12]                                                       | Appends *handler* to the current clause if an antecedent call to [_If(Boolean, ConditionalStringHandler)][9] or [_ElseIf(Boolean, ConditionalElseStringHandler)][13] used a false condition                                  |
| [_ElseIf][13]                                                     | Appends *handler* to the current clause if *condition* is true and an antecedent call to [_If(Boolean, ConditionalStringHandler)][9] or [_ElseIf(Boolean, ConditionalElseStringHandler)][13] used a false condition.         |
| [_If][9]                                                          | Appends the interpolated string *handler* to the current clause if *condition* is true.                                                                                                                                      |
| [Append(AppendStringHandler)][14]                                 | Appends the interpolated string *handler* to this instance.                                                                                                                                                                  |
| [Append(String)][15]                                              | Appends *text* to this instance.                                                                                                                                                                                             |
| [AppendClause(SqlClause)][16]                                     | Appends the SQL *clause*.                                                                                                                                                                                                    |
| [AppendClause(SqlClause, String)][17]                             | Appends the SQL *clause* and the provided *text*.                                                                                                                                                                            |
| [AppendClause&lt;TClause>()][18]                                  | Appends the SQL clause identified by TClause.                                                                                                                                                                                |
| [AppendClause&lt;TClause>(String)][19]                            | Appends the SQL clause identified by TClause and the provided *text*.                                                                                                                                                        |
| [AppendElse][20]                                                  | Appends the interpolated string *handler* if an antecedent call to [AppendIf(Boolean, AppendStringHandler)][21] or [AppendElseIf(Boolean, AppendElseStringHandler)][22] used a false condition                               |
| [AppendElseIf][22]                                                | Appends the interpolated string *handler* if *condition* is true and an antecedent call to [AppendIf(Boolean, AppendStringHandler)][21] or [AppendElseIf(Boolean, AppendElseStringHandler)][22] used a false condition.      |
| [AppendIf][21]                                                    | Appends the interpolated string *handler* if *condition* is true.                                                                                                                                                            |
| [AppendLine][23]                                                  | Appends the default line terminator to this instance.                                                                                                                                                                        |
| [AppendSql][24]                                                   | Appends *sql* to this instance.                                                                                                                                                                                              |
| [Clone][25]                                                       | Creates and returns a copy of this instance.                                                                                                                                                                                 |
| [Create(AppendStringHandler)][26]                                 | Initializes a new instance of the **SqlBuilder** class using the provided interpolated string.                                                                                                                               |
| [Create(String)][27]                                              | Initializes a new instance of the **SqlBuilder** class using the provided text.                                                                                                                                              |
| [CreateStatic(SqlBuilder)][28]                                    | Initializes a new instance of the **SqlBuilder** class using the provided interpolated string. Use this method if you don't expect to modify the returned builder; otherwise, use [Create(AppendStringHandler)][26] instead. |
| [CreateStatic(String)][29]                                        | Initializes a new instance of the **SqlBuilder** class using the provided text. Use this method if you don't expect to modify the returned builder; otherwise, use [Create(String)][27] instead.                             |
| [CROSS_JOIN()][30]                                                | Sets CROSS JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                      |
| [CROSS_JOIN(SqlBuilder.ClauseStringHandler&lt;CROSS_JOIN>)][31]   | Appends the CROSS JOIN clause using the provided interpolated string *handler*.                                                                                                                                              |
| [CROSS_JOIN(String)][32]                                          | Appends the CROSS JOIN clause using the provided *text*.                                                                                                                                                                     |
| [DELETE_FROM(SqlBuilder.ClauseStringHandler&lt;DELETE_FROM>)][33] | Appends the DELETE FROM clause using the provided interpolated string *handler*.                                                                                                                                             |
| [DELETE_FROM(String)][34]                                         | Appends the DELETE FROM clause using the provided *text*.                                                                                                                                                                    |
| [FROM()][35]                                                      | Sets FROM as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                            |
| [FROM(SqlBuilder.ClauseStringHandler&lt;FROM>)][36]               | Appends the FROM clause using the provided interpolated string *handler*.                                                                                                                                                    |
| [FROM(String)][37]                                                | Appends the FROM clause using the provided *text*.                                                                                                                                                                           |
| [FROM(SqlBuilder, String)][38]                                    | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                                                           |
| [FROM(SqlSet, String)][39]                                        | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                                                           |
| [GROUP_BY()][40]                                                  | Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                        |
| [GROUP_BY(SqlBuilder.ClauseStringHandler&lt;GROUP_BY>)][41]       | Appends the GROUP BY clause using the provided interpolated string *handler*.                                                                                                                                                |
| [GROUP_BY(String)][42]                                            | Appends the GROUP BY clause using the provided *text*.                                                                                                                                                                       |
| [HAVING()][43]                                                    | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                          |
| [HAVING(SqlBuilder.ClauseStringHandler&lt;HAVING>)][44]           | Appends the HAVING clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [HAVING(String)][45]                                              | Appends the HAVING clause using the provided *text*.                                                                                                                                                                         |
| [INNER_JOIN()][46]                                                | Sets INNER JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                      |
| [INNER_JOIN(SqlBuilder.ClauseStringHandler&lt;INNER_JOIN>)][47]   | Appends the INNER JOIN clause using the provided interpolated string *handler*.                                                                                                                                              |
| [INNER_JOIN(String)][48]                                          | Appends the INNER JOIN clause using the provided *text*.                                                                                                                                                                     |
| [INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;INSERT_INTO>)][49] | Appends the INSERT INTO clause using the provided interpolated string *handler*.                                                                                                                                             |
| [INSERT_INTO(String)][50]                                         | Appends the INSERT INTO clause using the provided *text*.                                                                                                                                                                    |
| [InsertText][51]                                                  | Inserts a string into this instance at the specified character position.                                                                                                                                                     |
| [JOIN()][52]                                                      | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                            |
| [JOIN(SqlBuilder.ClauseStringHandler&lt;JOIN>)][53]               | Appends the JOIN clause using the provided interpolated string *handler*.                                                                                                                                                    |
| [JOIN(String)][54]                                                | Appends the JOIN clause using the provided *text*.                                                                                                                                                                           |
| [JoinSql(String, SqlBuilder[])][55]                               | Concatenates a specified separator [String][56] between each element of a specified **SqlBuilder** array, yielding a single concatenated **SqlBuilder**.                                                                     |
| [JoinSql(String, IEnumerable&lt;SqlBuilder>)][57]                 | Concatenates the members of a constructed [IEnumerable&lt;T>][58] collection of type **SqlBuilder**, using the specified *separator* between each member.                                                                    |
| [LEFT_JOIN()][59]                                                 | Sets LEFT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                       |
| [LEFT_JOIN(SqlBuilder.ClauseStringHandler&lt;LEFT_JOIN>)][60]     | Appends the LEFT JOIN clause using the provided interpolated string *handler*.                                                                                                                                               |
| [LEFT_JOIN(String)][61]                                           | Appends the LEFT JOIN clause using the provided *text*.                                                                                                                                                                      |
| [LIMIT()][62]                                                     | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                           |
| [LIMIT(SqlBuilder.ClauseStringHandler&lt;LIMIT>)][63]             | Appends the LIMIT clause using the provided interpolated string *handler*.                                                                                                                                                   |
| [LIMIT(Int32)][64]                                                | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                                                                                          |
| [LIMIT(String)][65]                                               | Appends the LIMIT clause using the provided *text*.                                                                                                                                                                          |
| [OFFSET()][66]                                                    | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                          |
| [OFFSET(SqlBuilder.ClauseStringHandler&lt;OFFSET>)][67]           | Appends the OFFSET clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [OFFSET(Int32)][68]                                               | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                                                                                         |
| [OFFSET(String)][69]                                              | Appends the OFFSET clause using the provided *text*.                                                                                                                                                                         |
| [ORDER_BY()][70]                                                  | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                        |
| [ORDER_BY(SqlBuilder.ClauseStringHandler&lt;ORDER_BY>)][71]       | Appends the ORDER BY clause using the provided interpolated string *handler*.                                                                                                                                                |
| [ORDER_BY(String)][72]                                            | Appends the ORDER BY clause using the provided *text*.                                                                                                                                                                       |
| [RIGHT_JOIN()][73]                                                | Sets RIGHT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                      |
| [RIGHT_JOIN(SqlBuilder.ClauseStringHandler&lt;RIGHT_JOIN>)][74]   | Appends the RIGHT JOIN clause using the provided interpolated string *handler*.                                                                                                                                              |
| [RIGHT_JOIN(String)][75]                                          | Appends the RIGHT JOIN clause using the provided *text*.                                                                                                                                                                     |
| [SELECT()][76]                                                    | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                          |
| [SELECT(SqlBuilder.ClauseStringHandler&lt;SELECT>)][77]           | Appends the SELECT clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [SELECT(String)][78]                                              | Appends the SELECT clause using the provided *text*.                                                                                                                                                                         |
| [SET(SqlBuilder.ClauseStringHandler&lt;SET>)][79]                 | Appends the SET clause using the provided interpolated string *handler*.                                                                                                                                                     |
| [SET(String)][80]                                                 | Appends the SET clause using the provided *text*.                                                                                                                                                                            |
| [SetCurrentClause(SqlClause)][81]                                 | Sets *clause* as the current SQL clause.                                                                                                                                                                                     |
| [SetCurrentClause&lt;TClause>()][82]                              | Sets the clause identified by TClause as the current SQL clause.                                                                                                                                                             |
| [SetNextClause(SqlClause)][83]                                    | Sets *clause* as the next SQL clause.                                                                                                                                                                                        |
| [SetNextClause&lt;TClause>()][84]                                 | Sets the clause identified by TClause as the next SQL clause.                                                                                                                                                                |
| [ToString][85]                                                    | Converts the value of this instance to a [String][56]. <br/>(Overrides [Object.ToString()][86])                                                                                                                              |
| [UNION][87]                                                       | Appends the UNION clause.                                                                                                                                                                                                    |
| [UPDATE(SqlBuilder.ClauseStringHandler&lt;UPDATE>)][88]           | Appends the UPDATE clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [UPDATE(String)][89]                                              | Appends the UPDATE clause using the provided *text*.                                                                                                                                                                         |
| [VALUES(SqlBuilder.ClauseStringHandler&lt;VALUES>)][90]           | Appends the VALUES clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [VALUES(Object[])][91]                                            | Appends the VALUES clause using the provided parameters.                                                                                                                                                                     |
| [WHERE()][92]                                                     | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                           |
| [WHERE(SqlBuilder.ClauseStringHandler&lt;WHERE>)][93]             | Appends the WHERE clause using the provided interpolated string *handler*.                                                                                                                                                   |
| [WHERE(String)][94]                                               | Appends the WHERE clause using the provided *text*.                                                                                                                                                                          |
| [WITH(SqlBuilder.ClauseStringHandler&lt;WITH>)][95]               | Appends the WITH clause using the provided interpolated string *handler*.                                                                                                                                                    |
| [WITH(String)][96]                                                | Appends the WITH clause using the provided *text*.                                                                                                                                                                           |
| [WITH(String, SqlBuilder)][97]                                    | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                                                           |
| [WITH(String, SqlSet)][98]                                        | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                                                           |


Remarks
-------
For information on how to use SqlBuilder see [SqlBuilder Tutorial][99].

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
[20]: AppendElse.md
[21]: AppendIf.md
[22]: AppendElseIf.md
[23]: AppendLine.md
[24]: AppendSql.md
[25]: Clone.md
[26]: Create.md
[27]: Create_1.md
[28]: CreateStatic.md
[29]: CreateStatic_1.md
[30]: CROSS_JOIN.md
[31]: CROSS_JOIN_1.md
[32]: CROSS_JOIN_2.md
[33]: DELETE_FROM.md
[34]: DELETE_FROM_1.md
[35]: FROM.md
[36]: FROM_2.md
[37]: FROM_4.md
[38]: FROM_1.md
[39]: FROM_3.md
[40]: GROUP_BY.md
[41]: GROUP_BY_1.md
[42]: GROUP_BY_2.md
[43]: HAVING.md
[44]: HAVING_1.md
[45]: HAVING_2.md
[46]: INNER_JOIN.md
[47]: INNER_JOIN_1.md
[48]: INNER_JOIN_2.md
[49]: INSERT_INTO.md
[50]: INSERT_INTO_1.md
[51]: InsertText.md
[52]: JOIN.md
[53]: JOIN_1.md
[54]: JOIN_2.md
[55]: JoinSql.md
[56]: https://learn.microsoft.com/dotnet/api/system.string
[57]: JoinSql_1.md
[58]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[59]: LEFT_JOIN.md
[60]: LEFT_JOIN_1.md
[61]: LEFT_JOIN_2.md
[62]: LIMIT.md
[63]: LIMIT_1.md
[64]: LIMIT_2.md
[65]: LIMIT_3.md
[66]: OFFSET.md
[67]: OFFSET_1.md
[68]: OFFSET_2.md
[69]: OFFSET_3.md
[70]: ORDER_BY.md
[71]: ORDER_BY_1.md
[72]: ORDER_BY_2.md
[73]: RIGHT_JOIN.md
[74]: RIGHT_JOIN_1.md
[75]: RIGHT_JOIN_2.md
[76]: SELECT.md
[77]: SELECT_1.md
[78]: SELECT_2.md
[79]: SET.md
[80]: SET_1.md
[81]: SetCurrentClause.md
[82]: SetCurrentClause__1.md
[83]: SetNextClause.md
[84]: SetNextClause__1.md
[85]: ToString.md
[86]: https://learn.microsoft.com/dotnet/api/system.object.tostring
[87]: UNION.md
[88]: UPDATE.md
[89]: UPDATE_1.md
[90]: VALUES.md
[91]: VALUES_1.md
[92]: WHERE.md
[93]: WHERE_1.md
[94]: WHERE_2.md
[95]: WITH.md
[96]: WITH_1.md
[97]: WITH_2.md
[98]: WITH_3.md
[99]: https://maxtoroq.github.io/DbExtensions/docs/7/SqlBuilder.html