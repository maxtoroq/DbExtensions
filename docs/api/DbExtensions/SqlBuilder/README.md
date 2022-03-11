SqlBuilder Class
================
Represents a mutable SQL string.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **DbExtensions.SqlBuilder**  

  **Namespace:**  [DbExtensions][2]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public class SqlBuilder
```

The **SqlBuilder** type exposes the following members.


Constructors
------------

                 | Name                              | Description                                                                                             
---------------- | --------------------------------- | ------------------------------------------------------------------------------------------------------- 
![Public method] | [SqlBuilder()][3]                 | Initializes a new instance of the **SqlBuilder** class.                                                 
![Public method] | [SqlBuilder(String, Object[])][4] | Initializes a new instance of the **SqlBuilder** class using the provided format string and parameters. 


Properties
----------

                   | Name                  | Description                                                                                                                                                       
------------------ | --------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [Buffer][5]           | The underlying [StringBuilder][6].                                                                                                                                
![Public property] | [CurrentClause][7]    | Gets or sets the current SQL clause, used to identify consecutive appends to the same clause.                                                                     
![Public property] | [CurrentSeparator][8] | Gets or sets the separator of the current SQL clause body.                                                                                                        
![Public property] | [IsEmpty][9]          | Returns true if the buffer is empty.                                                                                                                              
![Public property] | [NextClause][10]      | Gets or sets the next SQL clause. Used by clause continuation methods, such as [AppendToCurrentClause(String, Object[])][11] and the methods that start with "_". 
![Public property] | [NextSeparator][12]   | Gets or sets the separator of the next SQL clause body.                                                                                                           
![Public property] | [ParameterValues][13] | The parameter objects to be included in the database command.                                                                                                     


Methods
-------

                                 | Name                                              | Description                                                                                                                                                                                      
-------------------------------- | ------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
![Public method]                 | [_][14]                                           | Appends *format* to the current clause. This method is a shortcut for [AppendToCurrentClause(String, Object[])][11].                                                                             
![Public method]                 | [_Else][15]                                       | Appends *format* to the current clause if an antecedent call to [_If(Boolean, String, Object[])][16] or [_ElseIf(Boolean, String, Object[])][17] used a false condition.                         
![Public method]                 | [_ElseIf][17]                                     | Appends *format* to the current clause if *condition* is true and an antecedent call to [_If(Boolean, String, Object[])][16] or [_ElseIf(Boolean, String, Object[])][17] used a false condition. 
![Public method]                 | [_ForEach&lt;T>][18]                              | Appends to the current clause the string made by concatenating an *itemFormat* for each element in *items*, interspersed with *separator*.                                                       
![Public method]                 | [_If][16]                                         | Appends *format* to the current clause if *condition* is true.                                                                                                                                   
![Public method]                 | [_OR&lt;T>][19]                                   | Appends to the current clause the string made by concatenating an *itemFormat* for each element in *items*, interspersed with the OR operator.                                                   
![Public method]                 | [Append(SqlBuilder)][20]                          | Appends *sql* to this instance.                                                                                                                                                                  
![Public method]                 | [Append(String, Object[])][21]                    | Appends *format* to this instance.                                                                                                                                                               
![Public method]                 | [AppendClause][22]                                | Appends the SQL clause specified by *clauseName* using the provided *format* string and parameters.                                                                                              
![Public method]                 | [AppendLine][23]                                  | Appends the default line terminator to this instance.                                                                                                                                            
![Public method]                 | [AppendToCurrentClause][11]                       | Appends *format* to the current clause.                                                                                                                                                          
![Public method]                 | [Clone][24]                                       | Creates and returns a copy of this instance.                                                                                                                                                     
![Public method]                 | [CROSS_JOIN][25]                                  | Appends the CROSS JOIN clause using the provided *format* string and parameters.                                                                                                                 
![Public method]                 | [DELETE_FROM][26]                                 | Appends the DELETE FROM clause using the provided *format* string and parameters.                                                                                                                
![Public method]                 | [FROM(String, Object[])][27]                      | Appends the FROM clause using the provided *format* string and parameters.                                                                                                                       
![Public method]                 | [FROM(SqlBuilder, String)][28]                    | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                               
![Public method]                 | [FROM(SqlSet, String)][29]                        | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                               
![Public method]                 | [GROUP_BY()][30]                                  | Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].                     
![Public method]                 | [GROUP_BY(String, Object[])][31]                  | Appends the GROUP BY clause using the provided *format* string and parameters.                                                                                                                   
![Public method]                 | [HAVING()][32]                                    | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].                       
![Public method]                 | [HAVING(String, Object[])][33]                    | Appends the HAVING clause using the provided *format* string and parameters.                                                                                                                     
![Public method]                 | [INNER_JOIN][34]                                  | Appends the INNER JOIN clause using the provided *format* string and parameters.                                                                                                                 
![Public method]                 | [Insert][35]                                      | Inserts a string into this instance at the specified character position.                                                                                                                         
![Public method]                 | [INSERT_INTO][36]                                 | Appends the INSERT INTO clause using the provided *format* string and parameters.                                                                                                                
![Public method]                 | [JOIN()][37]                                      | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].                         
![Public method]                 | [JOIN(String, Object[])][38]                      | Appends the JOIN clause using the provided *format* string and parameters.                                                                                                                       
![Public method]![Static member] | [JoinSql(String, SqlBuilder[])][39]               | Concatenates a specified separator [String][40] between each element of a specified **SqlBuilder** array, yielding a single concatenated **SqlBuilder**.                                         
![Public method]![Static member] | [JoinSql(String, IEnumerable&lt;SqlBuilder>)][41] | Concatenates the members of a constructed [IEnumerable&lt;T>][42] collection of type **SqlBuilder**, using the specified *separator* between each member.                                        
![Public method]                 | [LEFT_JOIN][43]                                   | Appends the LEFT JOIN clause using the provided *format* string and parameters.                                                                                                                  
![Public method]                 | [LIMIT()][44]                                     | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].                        
![Public method]                 | [LIMIT(Int32)][45]                                | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                                                              
![Public method]                 | [LIMIT(String, Object[])][46]                     | Appends the LIMIT clause using the provided *format* string and parameters.                                                                                                                      
![Public method]                 | [OFFSET()][47]                                    | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].                       
![Public method]                 | [OFFSET(Int32)][48]                               | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                                                             
![Public method]                 | [OFFSET(String, Object[])][49]                    | Appends the OFFSET clause using the provided *format* string and parameters.                                                                                                                     
![Public method]                 | [ORDER_BY()][50]                                  | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].                     
![Public method]                 | [ORDER_BY(String, Object[])][51]                  | Appends the ORDER BY clause using the provided *format* string and parameters.                                                                                                                   
![Public method]                 | [RIGHT_JOIN][52]                                  | Appends the RIGHT JOIN clause using the provided *format* string and parameters.                                                                                                                 
![Public method]                 | [SELECT()][53]                                    | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].                       
![Public method]                 | [SELECT(String, Object[])][54]                    | Appends the SELECT clause using the provided *format* string and parameters.                                                                                                                     
![Public method]                 | [SET][55]                                         | Appends the SET clause using the provided *format* string and parameters.                                                                                                                        
![Public method]                 | [SetCurrentClause][56]                            | Sets *clauseName* as the current SQL clause.                                                                                                                                                     
![Public method]                 | [SetNextClause][57]                               | Sets *clauseName* as the next SQL clause.                                                                                                                                                        
![Public method]                 | [ToString][58]                                    | Converts the value of this instance to a [String][40]. (Overrides [Object.ToString()][59].)                                                                                                      
![Public method]                 | [UNION][60]                                       | Appends the UNION clause.                                                                                                                                                                        
![Public method]                 | [UPDATE][61]                                      | Appends the UPDATE clause using the provided *format* string and parameters.                                                                                                                     
![Public method]                 | [VALUES][62]                                      | Appends the VALUES clause using the provided parameters.                                                                                                                                         
![Public method]                 | [WHERE()][63]                                     | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].                        
![Public method]                 | [WHERE(String, Object[])][64]                     | Appends the WHERE clause using the provided *format* string and parameters.                                                                                                                      
![Public method]                 | [WITH(String, Object[])][65]                      | Appends the WITH clause using the provided *format* string and parameters.                                                                                                                       
![Public method]                 | [WITH(SqlBuilder, String)][66]                    | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                               
![Public method]                 | [WITH(SqlSet, String)][67]                        | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                               


Remarks
-------
For information on how to use SqlBuilder see [SqlBuilder Tutorial][68].

See Also
--------

#### Reference
[DbExtensions Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: _ctor_1.md
[5]: Buffer.md
[6]: http://msdn.microsoft.com/en-us/library/y9sxk6fy
[7]: CurrentClause.md
[8]: CurrentSeparator.md
[9]: IsEmpty.md
[10]: NextClause.md
[11]: AppendToCurrentClause.md
[12]: NextSeparator.md
[13]: ParameterValues.md
[14]: _.md
[15]: _Else.md
[16]: _If.md
[17]: _ElseIf.md
[18]: _ForEach__1.md
[19]: _OR__1.md
[20]: Append.md
[21]: Append_1.md
[22]: AppendClause.md
[23]: AppendLine.md
[24]: Clone.md
[25]: CROSS_JOIN.md
[26]: DELETE_FROM.md
[27]: FROM_2.md
[28]: FROM.md
[29]: FROM_1.md
[30]: GROUP_BY.md
[31]: GROUP_BY_1.md
[32]: HAVING.md
[33]: HAVING_1.md
[34]: INNER_JOIN.md
[35]: Insert.md
[36]: INSERT_INTO.md
[37]: JOIN.md
[38]: JOIN_1.md
[39]: JoinSql.md
[40]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[41]: JoinSql_1.md
[42]: http://msdn.microsoft.com/en-us/library/9eekhta0
[43]: LEFT_JOIN.md
[44]: LIMIT.md
[45]: LIMIT_1.md
[46]: LIMIT_2.md
[47]: OFFSET.md
[48]: OFFSET_1.md
[49]: OFFSET_2.md
[50]: ORDER_BY.md
[51]: ORDER_BY_1.md
[52]: RIGHT_JOIN.md
[53]: SELECT.md
[54]: SELECT_1.md
[55]: SET.md
[56]: SetCurrentClause.md
[57]: SetNextClause.md
[58]: ToString.md
[59]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[60]: UNION.md
[61]: UPDATE.md
[62]: VALUES.md
[63]: WHERE.md
[64]: WHERE_1.md
[65]: WITH_2.md
[66]: WITH.md
[67]: WITH_1.md
[68]: http://maxtoroq.github.io/DbExtensions/docs/SqlBuilder.html
[Public method]: ../../icons/pubmethod.gif "Public method"
[Public property]: ../../icons/pubproperty.gif "Public property"
[Static member]: ../../icons/static.gif "Static member"