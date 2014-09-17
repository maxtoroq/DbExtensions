SqlBuilder Class
================
Represents a mutable SQL string.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **DbExtensions.SqlBuilder**  

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public class SqlBuilder
```

The **SqlBuilder** type exposes the following members.


Constructors
------------

                 | Name                              | Description                                                                                             
---------------- | --------------------------------- | ------------------------------------------------------------------------------------------------------- 
![Public method] | [SqlBuilder()][3]                 | Initializes a new instance of the **SqlBuilder** class.                                                 
![Public method] | [SqlBuilder(String)][4]           | Initializes a new instance of the **SqlBuilder** class using the provided SQL string.                   
![Public method] | [SqlBuilder(String, Object[])][5] | Initializes a new instance of the **SqlBuilder** class using the provided format string and parameters. 


Methods
-------

                                 | Name                                              | Description                                                                                                                                                                                                                                                
-------------------------------- | ------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method]                 | [_(String)][6]                                    | Appends *body* to the current clause. This method is a shortcut for [AppendToCurrentClause(String)][7].                                                                                                                                                    
![Public method]                 | [_(String, Object[])][8]                          | Appends *format* to the current clause. This method is a shortcut for [AppendToCurrentClause(String, Object[])][9].                                                                                                                                        
![Public method]                 | [_ForEach&lt;T>][10]                              | Appends to the current clause the string made by concatenating an *itemFormat* for each element in *items*, interspersed with *separator*.                                                                                                                 
![Public method]                 | [_If(Boolean, Int32)][11]                         | Appends *body* to the current clause if *condition* is true.                                                                                                                                                                                               
![Public method]                 | [_If(Boolean, Int64)][12]                         | Appends *body* to the current clause if *condition* is true.                                                                                                                                                                                               
![Public method]                 | [_If(Boolean, String)][13]                        | Appends *body* to the current clause if *condition* is true.                                                                                                                                                                                               
![Public method]                 | [_If(Boolean, String, Object[])][14]              | Appends *format* to the current clause if *condition* is true.                                                                                                                                                                                             
![Public method]                 | [_OR&lt;T>][15]                                   | Appends to the current clause the string made by concatenating an *itemFormat* for each element in *items*, interspersed with the OR operator.                                                                                                             
![Public method]                 | [Append(String)][16]                              | Appends *sql* to this instance.                                                                                                                                                                                                                            
![Public method]                 | [Append(SqlBuilder)][17]                          | Appends *sql* to this instance.                                                                                                                                                                                                                            
![Public method]                 | [Append(String, Object[])][18]                    | Appends *format* to this instance.                                                                                                                                                                                                                         
![Public method]                 | [AppendClause][19]                                | Appends the SQL clause specified by *clauseName* using the provided *format* string and parameters.                                                                                                                                                        
![Public method]                 | [AppendLine][20]                                  | Appends the default line terminator to this instance.                                                                                                                                                                                                      
![Public method]                 | [AppendToCurrentClause(String)][7]                | Appends *body* to the current clause.                                                                                                                                                                                                                      
![Public method]                 | [AppendToCurrentClause(String, Object[])][9]      | Appends *format* to the current clause.                                                                                                                                                                                                                    
![Public method]                 | [Clone][21]                                       | Creates and returns a copy of this instance.                                                                                                                                                                                                               
![Public method]                 | [DELETE_FROM(String)][22]                         | Appends the DELETE FROM clause using the provided *body*.                                                                                                                                                                                                  
![Public method]                 | [DELETE_FROM(String, Object[])][23]               | Appends the DELETE FROM clause using the provided *format* string and parameters.                                                                                                                                                                          
![Public method]                 | [FROM(String)][24]                                | Appends the FROM clause using the provided *body*.                                                                                                                                                                                                         
![Public method]                 | [FROM(String, Object[])][25]                      | Appends the FROM clause using the provided *format* string and parameters.                                                                                                                                                                                 
![Public method]                 | [FROM(SqlBuilder, String)][26]                    | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                                                                                         
![Public method]                 | [GROUP_BY()][27]                                  | Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                    
![Public method]                 | [GROUP_BY(String)][28]                            | Appends the GROUP BY clause using the provided *body*.                                                                                                                                                                                                     
![Public method]                 | [GROUP_BY(String, Object[])][29]                  | Appends the GROUP BY clause using the provided *format* string and parameters.                                                                                                                                                                             
![Public method]                 | [HAVING()][30]                                    | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                      
![Public method]                 | [HAVING(String)][31]                              | Appends the HAVING clause using the provided *body*.                                                                                                                                                                                                       
![Public method]                 | [HAVING(String, Object[])][32]                    | Appends the HAVING clause using the provided *format* string and parameters.                                                                                                                                                                               
![Public method]                 | [INNER_JOIN(String)][33]                          | Appends the INNER JOIN clause using the provided *body*.                                                                                                                                                                                                   
![Public method]                 | [INNER_JOIN(String, Object[])][34]                | Appends the INNER JOIN clause using the provided *format* string and parameters.                                                                                                                                                                           
![Public method]                 | [Insert][35]                                      | Inserts a string into this instance at the specified character position.                                                                                                                                                                                   
![Public method]                 | [INSERT_INTO(String)][36]                         | Appends the INSERT INTO clause using the provided *body*.                                                                                                                                                                                                  
![Public method]                 | [INSERT_INTO(String, Object[])][37]               | Appends the INSERT INTO clause using the provided *format* string and parameters.                                                                                                                                                                          
![Public method]                 | [JOIN()][38]                                      | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                        
![Public method]                 | [JOIN(String)][39]                                | Appends the JOIN clause using the provided *body*.                                                                                                                                                                                                         
![Public method]                 | [JOIN(String, Object[])][40]                      | Appends the JOIN clause using the provided *format* string and parameters.                                                                                                                                                                                 
![Public method]![Static member] | [JoinSql(String, SqlBuilder[])][41]               | Concatenates a specified separator [String][42] between each element of a specified **SqlBuilder** array, yielding a single concatenated **SqlBuilder**.                                                                                                   
![Public method]![Static member] | [JoinSql(String, IEnumerable&lt;SqlBuilder>)][43] | Concatenates the members of a constructed [IEnumerable&lt;T>][44] collection of type **SqlBuilder**, using the specified *separator* between each member.                                                                                                  
![Public method]                 | [LEFT_JOIN(String)][45]                           | Appends the LEFT JOIN clause using the provided *body*.                                                                                                                                                                                                    
![Public method]                 | [LEFT_JOIN(String, Object[])][46]                 | Appends the LEFT JOIN clause using the provided *format* string and parameters.                                                                                                                                                                            
![Public method]                 | [LIMIT()][47]                                     | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                       
![Public method]                 | [LIMIT(Int32)][48]                                | Appends the LIMIT clause using the string representation of *maxRecords* as body.                                                                                                                                                                          
![Public method]                 | [LIMIT(String)][49]                               | Appends the LIMIT clause using the provided *body*.                                                                                                                                                                                                        
![Public method]                 | [LIMIT(String, Object[])][50]                     | Appends the LIMIT clause using the provided *format* string and parameters.                                                                                                                                                                                
![Public method]                 | [OFFSET()][51]                                    | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                      
![Public method]                 | [OFFSET(Int32)][52]                               | Appends the OFFSET clause using the string representation of *startIndex* as body.                                                                                                                                                                         
![Public method]                 | [OFFSET(String)][53]                              | Appends the OFFSET clause using the provided *body*.                                                                                                                                                                                                       
![Public method]                 | [OFFSET(String, Object[])][54]                    | Appends the OFFSET clause using the provided *format* string and parameters.                                                                                                                                                                               
![Public method]                 | [ORDER_BY()][55]                                  | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                    
![Public method]                 | [ORDER_BY(String)][56]                            | Appends the ORDER BY clause using the provided *body*.                                                                                                                                                                                                     
![Public method]                 | [ORDER_BY(String, Object[])][57]                  | Appends the ORDER BY clause using the provided *format* string and parameters.                                                                                                                                                                             
![Public method]                 | [RIGHT_JOIN(String)][58]                          | Appends the RIGHT JOIN clause using the provided *body*.                                                                                                                                                                                                   
![Public method]                 | [RIGHT_JOIN(String, Object[])][59]                | Appends the RIGHT JOIN clause using the provided *format* string and parameters.                                                                                                                                                                           
![Public method]                 | [SELECT()][60]                                    | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                      
![Public method]                 | [SELECT(String)][61]                              | Appends the SELECT clause using the provided *body*.                                                                                                                                                                                                       
![Public method]                 | [SELECT(String, Object[])][62]                    | Appends the SELECT clause using the provided *format* string and parameters.                                                                                                                                                                               
![Public method]                 | [SET(String)][63]                                 | Appends the SET clause using the provided *body*.                                                                                                                                                                                                          
![Public method]                 | [SET(String, Object[])][64]                       | Appends the SET clause using the provided *format* string and parameters.                                                                                                                                                                                  
![Public method]                 | [SetCurrentClause][65]                            | Sets *clauseName* as the current SQL clause.                                                                                                                                                                                                               
![Public method]                 | [SetNextClause][66]                               | Sets *clauseName* as the next SQL clause.                                                                                                                                                                                                                  
![Public method]                 | [ToCommand(DbConnection)][67]                     | Creates and returns a [DbCommand][68] object whose [CommandText][69] property is initialized with the SQL representation of this instance, and whose [Parameters][70] property is initialized with the values from [ParameterValues][71] of this instance. 
![Public method]                 | [ToCommand(DbProviderFactory)][72]                | Creates and returns a [DbCommand][68] object whose [CommandText][69] property is initialized with the SQL representation of this instance, and whose [Parameters][70] property is initialized with the values from [ParameterValues][71] of this instance. 
![Public method]                 | [ToString][73]                                    | Converts the value of this instance to a [String][42]. (Overrides [Object.ToString()][74].)                                                                                                                                                                
![Public method]                 | [UNION][75]                                       | Appends the UNION clause.                                                                                                                                                                                                                                  
![Public method]                 | [UPDATE(String)][76]                              | Appends the UPDATE clause using the provided *body*.                                                                                                                                                                                                       
![Public method]                 | [UPDATE(String, Object[])][77]                    | Appends the UPDATE clause using the provided *format* string and parameters.                                                                                                                                                                               
![Public method]                 | [VALUES][78]                                      | Appends the VALUES clause using the provided parameters.                                                                                                                                                                                                   
![Public method]                 | [WHERE()][79]                                     | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                       
![Public method]                 | [WHERE(String)][80]                               | Appends the WHERE clause using the provided *body*.                                                                                                                                                                                                        
![Public method]                 | [WHERE(String, Object[])][81]                     | Appends the WHERE clause using the provided *format* string and parameters.                                                                                                                                                                                
![Public method]                 | [WITH(String)][82]                                | Appends the WITH clause using the provided *body*.                                                                                                                                                                                                         
![Public method]                 | [WITH(String, Object[])][83]                      | Appends the WITH clause using the provided *format* string and parameters.                                                                                                                                                                                 
![Public method]                 | [WITH(SqlBuilder, String)][84]                    | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                                                                                         


Properties
----------

                   | Name                   | Description                                                                                                                                            
------------------ | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ 
![Public property] | [Buffer][85]           | The underlying [StringBuilder][86].                                                                                                                    
![Public property] | [CurrentClause][87]    | Gets or sets the current SQL clause, used to identify consecutive appends to the same clause.                                                          
![Public property] | [CurrentSeparator][88] | Gets or sets the separator of the current SQL clause body.                                                                                             
![Public property] | [IsEmpty][89]          | Returns true if the buffer is empty.                                                                                                                   
![Public property] | [NextClause][90]       | Gets or sets the next SQL clause. Used by clause continuation methods, such as [AppendToCurrentClause(String)][7] and the methods that start with "_". 
![Public property] | [NextSeparator][91]    | Gets or sets the separator of the next SQL clause body.                                                                                                
![Public property] | [ParameterValues][71]  | The parameter objects to be included in the database command.                                                                                          


See Also
--------
[DbExtensions Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: _ctor_1.md
[5]: _ctor_2.md
[6]: _.md
[7]: AppendToCurrentClause.md
[8]: __1.md
[9]: AppendToCurrentClause_1.md
[10]: _ForEach__1.md
[11]: _If.md
[12]: _If_1.md
[13]: _If_2.md
[14]: _If_3.md
[15]: _OR__1.md
[16]: Append_1.md
[17]: Append.md
[18]: Append_2.md
[19]: AppendClause.md
[20]: AppendLine.md
[21]: Clone.md
[22]: DELETE_FROM.md
[23]: DELETE_FROM_1.md
[24]: FROM_1.md
[25]: FROM_2.md
[26]: FROM.md
[27]: GROUP_BY.md
[28]: GROUP_BY_1.md
[29]: GROUP_BY_2.md
[30]: HAVING.md
[31]: HAVING_1.md
[32]: HAVING_2.md
[33]: INNER_JOIN.md
[34]: INNER_JOIN_1.md
[35]: Insert.md
[36]: INSERT_INTO.md
[37]: INSERT_INTO_1.md
[38]: JOIN.md
[39]: JOIN_1.md
[40]: JOIN_2.md
[41]: JoinSql.md
[42]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[43]: JoinSql_1.md
[44]: http://msdn.microsoft.com/en-us/library/9eekhta0
[45]: LEFT_JOIN.md
[46]: LEFT_JOIN_1.md
[47]: LIMIT.md
[48]: LIMIT_1.md
[49]: LIMIT_2.md
[50]: LIMIT_3.md
[51]: OFFSET.md
[52]: OFFSET_1.md
[53]: OFFSET_2.md
[54]: OFFSET_3.md
[55]: ORDER_BY.md
[56]: ORDER_BY_1.md
[57]: ORDER_BY_2.md
[58]: RIGHT_JOIN.md
[59]: RIGHT_JOIN_1.md
[60]: SELECT.md
[61]: SELECT_1.md
[62]: SELECT_2.md
[63]: SET.md
[64]: SET_1.md
[65]: SetCurrentClause.md
[66]: SetNextClause.md
[67]: ToCommand.md
[68]: http://msdn.microsoft.com/en-us/library/852d01k6
[69]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[70]: http://msdn.microsoft.com/en-us/library/9czdkzd1
[71]: ParameterValues.md
[72]: ToCommand_1.md
[73]: ToString.md
[74]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[75]: UNION.md
[76]: UPDATE.md
[77]: UPDATE_1.md
[78]: VALUES.md
[79]: WHERE.md
[80]: WHERE_1.md
[81]: WHERE_2.md
[82]: WITH_1.md
[83]: WITH_2.md
[84]: WITH.md
[85]: Buffer.md
[86]: http://msdn.microsoft.com/en-us/library/y9sxk6fy
[87]: CurrentClause.md
[88]: CurrentSeparator.md
[89]: IsEmpty.md
[90]: NextClause.md
[91]: NextSeparator.md
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Static member]: ../../_icons/static.gif "Static member"
[Public property]: ../../_icons/pubproperty.gif "Public property"