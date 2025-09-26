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
| [AppendLine][20]                                                  | Appends the default line terminator to this instance.                                                                                                                                                                        |
| [AppendSql][21]                                                   | Appends *sql* to this instance.                                                                                                                                                                                              |
| [Clone][22]                                                       | Creates and returns a copy of this instance.                                                                                                                                                                                 |
| [Create(AppendStringHandler)][23]                                 | Initializes a new instance of the **SqlBuilder** class using the provided interpolated string.                                                                                                                               |
| [Create(String)][24]                                              | Initializes a new instance of the **SqlBuilder** class using the provided text.                                                                                                                                              |
| [CreateStatic(SqlBuilder)][25]                                    | Initializes a new instance of the **SqlBuilder** class using the provided interpolated string. Use this method if you don't expect to modify the returned builder; otherwise, use [Create(AppendStringHandler)][23] instead. |
| [CreateStatic(String)][26]                                        | Initializes a new instance of the **SqlBuilder** class using the provided text. Use this method if you don't expect to modify the returned builder; otherwise, use [Create(String)][24] instead.                             |
| [CROSS_JOIN()][27]                                                | Sets CROSS JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                      |
| [CROSS_JOIN(SqlBuilder.ClauseStringHandler&lt;CROSS_JOIN>)][28]   | Appends the CROSS JOIN clause using the provided interpolated string *handler*.                                                                                                                                              |
| [CROSS_JOIN(String)][29]                                          | Appends the CROSS JOIN clause using the provided *text*.                                                                                                                                                                     |
| [DELETE_FROM(SqlBuilder.ClauseStringHandler&lt;DELETE_FROM>)][30] | Appends the DELETE FROM clause using the provided interpolated string *handler*.                                                                                                                                             |
| [DELETE_FROM(String)][31]                                         | Appends the DELETE FROM clause using the provided *text*.                                                                                                                                                                    |
| [FROM()][32]                                                      | Sets FROM as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                            |
| [FROM(SqlBuilder.ClauseStringHandler&lt;FROM>)][33]               | Appends the FROM clause using the provided interpolated string *handler*.                                                                                                                                                    |
| [FROM(String)][34]                                                | Appends the FROM clause using the provided *text*.                                                                                                                                                                           |
| [FROM(SqlBuilder, String)][35]                                    | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                                                           |
| [FROM(SqlSet, String)][36]                                        | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                                                           |
| [GROUP_BY()][37]                                                  | Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                        |
| [GROUP_BY(SqlBuilder.ClauseStringHandler&lt;GROUP_BY>)][38]       | Appends the GROUP BY clause using the provided interpolated string *handler*.                                                                                                                                                |
| [GROUP_BY(String)][39]                                            | Appends the GROUP BY clause using the provided *text*.                                                                                                                                                                       |
| [HAVING()][40]                                                    | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                          |
| [HAVING(SqlBuilder.ClauseStringHandler&lt;HAVING>)][41]           | Appends the HAVING clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [HAVING(String)][42]                                              | Appends the HAVING clause using the provided *text*.                                                                                                                                                                         |
| [INNER_JOIN()][43]                                                | Sets INNER JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                      |
| [INNER_JOIN(SqlBuilder.ClauseStringHandler&lt;INNER_JOIN>)][44]   | Appends the INNER JOIN clause using the provided interpolated string *handler*.                                                                                                                                              |
| [INNER_JOIN(String)][45]                                          | Appends the INNER JOIN clause using the provided *text*.                                                                                                                                                                     |
| [INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;INSERT_INTO>)][46] | Appends the INSERT INTO clause using the provided interpolated string *handler*.                                                                                                                                             |
| [INSERT_INTO(String)][47]                                         | Appends the INSERT INTO clause using the provided *text*.                                                                                                                                                                    |
| [InsertText][48]                                                  | Inserts a string into this instance at the specified character position.                                                                                                                                                     |
| [JOIN()][49]                                                      | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                            |
| [JOIN(SqlBuilder.ClauseStringHandler&lt;JOIN>)][50]               | Appends the JOIN clause using the provided interpolated string *handler*.                                                                                                                                                    |
| [JOIN(String)][51]                                                | Appends the JOIN clause using the provided *text*.                                                                                                                                                                           |
| [JoinSql(String, SqlBuilder[])][52]                               | Concatenates a specified separator [String][53] between each element of a specified **SqlBuilder** array, yielding a single concatenated **SqlBuilder**.                                                                     |
| [JoinSql(String, IEnumerable&lt;SqlBuilder>)][54]                 | Concatenates the members of a constructed [IEnumerable&lt;T>][55] collection of type **SqlBuilder**, using the specified *separator* between each member.                                                                    |
| [LEFT_JOIN()][56]                                                 | Sets LEFT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                       |
| [LEFT_JOIN(SqlBuilder.ClauseStringHandler&lt;LEFT_JOIN>)][57]     | Appends the LEFT JOIN clause using the provided interpolated string *handler*.                                                                                                                                               |
| [LEFT_JOIN(String)][58]                                           | Appends the LEFT JOIN clause using the provided *text*.                                                                                                                                                                      |
| [LIMIT()][59]                                                     | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                           |
| [LIMIT(SqlBuilder.ClauseStringHandler&lt;LIMIT>)][60]             | Appends the LIMIT clause using the provided interpolated string *handler*.                                                                                                                                                   |
| [LIMIT(Int32)][61]                                                | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                                                                                          |
| [LIMIT(String)][62]                                               | Appends the LIMIT clause using the provided *text*.                                                                                                                                                                          |
| [OFFSET()][63]                                                    | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                          |
| [OFFSET(SqlBuilder.ClauseStringHandler&lt;OFFSET>)][64]           | Appends the OFFSET clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [OFFSET(Int32)][65]                                               | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                                                                                         |
| [OFFSET(String)][66]                                              | Appends the OFFSET clause using the provided *text*.                                                                                                                                                                         |
| [ORDER_BY()][67]                                                  | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                        |
| [ORDER_BY(SqlBuilder.ClauseStringHandler&lt;ORDER_BY>)][68]       | Appends the ORDER BY clause using the provided interpolated string *handler*.                                                                                                                                                |
| [ORDER_BY(String)][69]                                            | Appends the ORDER BY clause using the provided *text*.                                                                                                                                                                       |
| [RIGHT_JOIN()][70]                                                | Sets RIGHT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                      |
| [RIGHT_JOIN(SqlBuilder.ClauseStringHandler&lt;RIGHT_JOIN>)][71]   | Appends the RIGHT JOIN clause using the provided interpolated string *handler*.                                                                                                                                              |
| [RIGHT_JOIN(String)][72]                                          | Appends the RIGHT JOIN clause using the provided *text*.                                                                                                                                                                     |
| [SELECT()][73]                                                    | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                          |
| [SELECT(SqlBuilder.ClauseStringHandler&lt;SELECT>)][74]           | Appends the SELECT clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [SELECT(String)][75]                                              | Appends the SELECT clause using the provided *text*.                                                                                                                                                                         |
| [SET(SqlBuilder.ClauseStringHandler&lt;SET>)][76]                 | Appends the SET clause using the provided interpolated string *handler*.                                                                                                                                                     |
| [SET(String)][77]                                                 | Appends the SET clause using the provided *text*.                                                                                                                                                                            |
| [SetCurrentClause(SqlClause)][78]                                 | Sets *clause* as the current SQL clause.                                                                                                                                                                                     |
| [SetCurrentClause&lt;TClause>()][79]                              | Sets the clause identified by TClause as the current SQL clause.                                                                                                                                                             |
| [SetNextClause(SqlClause)][80]                                    | Sets *clause* as the next SQL clause.                                                                                                                                                                                        |
| [SetNextClause&lt;TClause>()][81]                                 | Sets the clause identified by TClause as the next SQL clause.                                                                                                                                                                |
| [ToString][82]                                                    | Converts the value of this instance to a [String][53]. <br/>(Overrides [Object.ToString()][83])                                                                                                                              |
| [UNION][84]                                                       | Appends the UNION clause.                                                                                                                                                                                                    |
| [UPDATE(SqlBuilder.ClauseStringHandler&lt;UPDATE>)][85]           | Appends the UPDATE clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [UPDATE(String)][86]                                              | Appends the UPDATE clause using the provided *text*.                                                                                                                                                                         |
| [VALUES(SqlBuilder.ClauseStringHandler&lt;VALUES>)][87]           | Appends the VALUES clause using the provided interpolated string *handler*.                                                                                                                                                  |
| [VALUES(Object[])][88]                                            | Appends the VALUES clause using the provided parameters.                                                                                                                                                                     |
| [WHERE()][89]                                                     | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][9].                                                                           |
| [WHERE(SqlBuilder.ClauseStringHandler&lt;WHERE>)][90]             | Appends the WHERE clause using the provided interpolated string *handler*.                                                                                                                                                   |
| [WHERE(String)][91]                                               | Appends the WHERE clause using the provided *text*.                                                                                                                                                                          |
| [WITH(SqlBuilder.ClauseStringHandler&lt;WITH>)][92]               | Appends the WITH clause using the provided interpolated string *handler*.                                                                                                                                                    |
| [WITH(String)][93]                                                | Appends the WITH clause using the provided *text*.                                                                                                                                                                           |
| [WITH(String, SqlBuilder)][94]                                    | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                                                           |
| [WITH(String, SqlSet)][95]                                        | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                                                           |


Remarks
-------
For information on how to use SqlBuilder see [SqlBuilder Tutorial][96].

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
[20]: AppendLine.md
[21]: AppendSql.md
[22]: Clone.md
[23]: Create.md
[24]: Create_1.md
[25]: CreateStatic.md
[26]: CreateStatic_1.md
[27]: CROSS_JOIN.md
[28]: CROSS_JOIN_1.md
[29]: CROSS_JOIN_2.md
[30]: DELETE_FROM.md
[31]: DELETE_FROM_1.md
[32]: FROM.md
[33]: FROM_2.md
[34]: FROM_4.md
[35]: FROM_1.md
[36]: FROM_3.md
[37]: GROUP_BY.md
[38]: GROUP_BY_1.md
[39]: GROUP_BY_2.md
[40]: HAVING.md
[41]: HAVING_1.md
[42]: HAVING_2.md
[43]: INNER_JOIN.md
[44]: INNER_JOIN_1.md
[45]: INNER_JOIN_2.md
[46]: INSERT_INTO.md
[47]: INSERT_INTO_1.md
[48]: InsertText.md
[49]: JOIN.md
[50]: JOIN_1.md
[51]: JOIN_2.md
[52]: JoinSql.md
[53]: https://learn.microsoft.com/dotnet/api/system.string
[54]: JoinSql_1.md
[55]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[56]: LEFT_JOIN.md
[57]: LEFT_JOIN_1.md
[58]: LEFT_JOIN_2.md
[59]: LIMIT.md
[60]: LIMIT_1.md
[61]: LIMIT_2.md
[62]: LIMIT_3.md
[63]: OFFSET.md
[64]: OFFSET_1.md
[65]: OFFSET_2.md
[66]: OFFSET_3.md
[67]: ORDER_BY.md
[68]: ORDER_BY_1.md
[69]: ORDER_BY_2.md
[70]: RIGHT_JOIN.md
[71]: RIGHT_JOIN_1.md
[72]: RIGHT_JOIN_2.md
[73]: SELECT.md
[74]: SELECT_1.md
[75]: SELECT_2.md
[76]: SET.md
[77]: SET_1.md
[78]: SetCurrentClause.md
[79]: SetCurrentClause__1.md
[80]: SetNextClause.md
[81]: SetNextClause__1.md
[82]: ToString.md
[83]: https://learn.microsoft.com/dotnet/api/system.object.tostring
[84]: UNION.md
[85]: UPDATE.md
[86]: UPDATE_1.md
[87]: VALUES.md
[88]: VALUES_1.md
[89]: WHERE.md
[90]: WHERE_1.md
[91]: WHERE_2.md
[92]: WITH.md
[93]: WITH_1.md
[94]: WITH_2.md
[95]: WITH_3.md
[96]: https://maxtoroq.github.io/DbExtensions/docs/7/SqlBuilder.html