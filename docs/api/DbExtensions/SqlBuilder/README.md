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

Name                              | Description                                                                                             
--------------------------------- | ------------------------------------------------------------------------------------------------------- 
[SqlBuilder()][3]                 | Initializes a new instance of the **SqlBuilder** class.                                                 
[SqlBuilder(String)][4]           | Initializes a new instance of the **SqlBuilder** class using the provided SQL string.                   
[SqlBuilder(String, Object[])][5] | Initializes a new instance of the **SqlBuilder** class using the provided format string and parameters. 


Methods
-------

Name                                              | Description                                                                                                                                                                                                                                                
------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[_(String)][6]                                    | Appends *body* to the current clause. This method is a shortcut for [AppendToCurrentClause(String)][7].                                                                                                                                                    
[_(String, Object[])][8]                          | Appends *format* to the current clause. This method is a shortcut for [AppendToCurrentClause(String, Object[])][9].                                                                                                                                        
[_ForEach&lt;T>][10]                              | Appends to the current clause the string made by concatenating an *itemFormat* for each element in *items*, interspersed with *separator*.                                                                                                                 
[_If(Boolean, Int32)][11]                         | Appends *body* to the current clause if *condition* is true.                                                                                                                                                                                               
[_If(Boolean, Int64)][12]                         | Appends *body* to the current clause if *condition* is true.                                                                                                                                                                                               
[_If(Boolean, String)][13]                        | Appends *body* to the current clause if *condition* is true.                                                                                                                                                                                               
[_If(Boolean, String, Object[])][14]              | Appends *format* to the current clause if *condition* is true.                                                                                                                                                                                             
[_OR&lt;T>][15]                                   | Appends to the current clause the string made by concatenating an *itemFormat* for each element in *items*, interspersed with the OR operator.                                                                                                             
[Append(String)][16]                              | Appends *sql* to this instance.                                                                                                                                                                                                                            
[Append(SqlBuilder)][17]                          | Appends *sql* to this instance.                                                                                                                                                                                                                            
[Append(String, Object[])][18]                    | Appends *format* to this instance.                                                                                                                                                                                                                         
[AppendClause][19]                                | Appends the SQL clause specified by *clauseName* using the provided *format* string and parameters.                                                                                                                                                        
[AppendLine][20]                                  | Appends the default line terminator to this instance.                                                                                                                                                                                                      
[AppendToCurrentClause(String)][7]                | Appends *body* to the current clause.                                                                                                                                                                                                                      
[AppendToCurrentClause(String, Object[])][9]      | Appends *format* to the current clause.                                                                                                                                                                                                                    
[Clone][21]                                       | Creates and returns a copy of this instance.                                                                                                                                                                                                               
[DELETE_FROM(String)][22]                         | Appends the DELETE FROM clause using the provided *body*.                                                                                                                                                                                                  
[DELETE_FROM(String, Object[])][23]               | Appends the DELETE FROM clause using the provided *format* string and parameters.                                                                                                                                                                          
[FROM(String)][24]                                | Appends the FROM clause using the provided *body*.                                                                                                                                                                                                         
[FROM(String, Object[])][25]                      | Appends the FROM clause using the provided *format* string and parameters.                                                                                                                                                                                 
[FROM(SqlBuilder, String)][26]                    | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                                                                                                         
[GROUP_BY()][27]                                  | Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                    
[GROUP_BY(String)][28]                            | Appends the GROUP BY clause using the provided *body*.                                                                                                                                                                                                     
[GROUP_BY(String, Object[])][29]                  | Appends the GROUP BY clause using the provided *format* string and parameters.                                                                                                                                                                             
[HAVING()][30]                                    | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                      
[HAVING(String)][31]                              | Appends the HAVING clause using the provided *body*.                                                                                                                                                                                                       
[HAVING(String, Object[])][32]                    | Appends the HAVING clause using the provided *format* string and parameters.                                                                                                                                                                               
[INNER_JOIN(String)][33]                          | Appends the INNER JOIN clause using the provided *body*.                                                                                                                                                                                                   
[INNER_JOIN(String, Object[])][34]                | Appends the INNER JOIN clause using the provided *format* string and parameters.                                                                                                                                                                           
[Insert][35]                                      | Inserts a string into this instance at the specified character position.                                                                                                                                                                                   
[INSERT_INTO(String)][36]                         | Appends the INSERT INTO clause using the provided *body*.                                                                                                                                                                                                  
[INSERT_INTO(String, Object[])][37]               | Appends the INSERT INTO clause using the provided *format* string and parameters.                                                                                                                                                                          
[JOIN()][38]                                      | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                        
[JOIN(String)][39]                                | Appends the JOIN clause using the provided *body*.                                                                                                                                                                                                         
[JOIN(String, Object[])][40]                      | Appends the JOIN clause using the provided *format* string and parameters.                                                                                                                                                                                 
[JoinSql(String, SqlBuilder[])][41]               | Concatenates a specified separator [String][42] between each element of a specified **SqlBuilder** array, yielding a single concatenated **SqlBuilder**.                                                                                                   
[JoinSql(String, IEnumerable&lt;SqlBuilder>)][43] | Concatenates the members of a constructed [IEnumerable&lt;T>][44] collection of type **SqlBuilder**, using the specified *separator* between each member.                                                                                                  
[LEFT_JOIN(String)][45]                           | Appends the LEFT JOIN clause using the provided *body*.                                                                                                                                                                                                    
[LEFT_JOIN(String, Object[])][46]                 | Appends the LEFT JOIN clause using the provided *format* string and parameters.                                                                                                                                                                            
[LIMIT()][47]                                     | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                       
[LIMIT(Int32)][48]                                | Appends the LIMIT clause using the string representation of *maxRecords* as body.                                                                                                                                                                          
[LIMIT(String)][49]                               | Appends the LIMIT clause using the provided *body*.                                                                                                                                                                                                        
[LIMIT(String, Object[])][50]                     | Appends the LIMIT clause using the provided *format* string and parameters.                                                                                                                                                                                
[OFFSET()][51]                                    | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                      
[OFFSET(Int32)][52]                               | Appends the OFFSET clause using the string representation of *startIndex* as body.                                                                                                                                                                         
[OFFSET(String)][53]                              | Appends the OFFSET clause using the provided *body*.                                                                                                                                                                                                       
[OFFSET(String, Object[])][54]                    | Appends the OFFSET clause using the provided *format* string and parameters.                                                                                                                                                                               
[ORDER_BY()][55]                                  | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                    
[ORDER_BY(String)][56]                            | Appends the ORDER BY clause using the provided *body*.                                                                                                                                                                                                     
[ORDER_BY(String, Object[])][57]                  | Appends the ORDER BY clause using the provided *format* string and parameters.                                                                                                                                                                             
[RIGHT_JOIN(String)][58]                          | Appends the RIGHT JOIN clause using the provided *body*.                                                                                                                                                                                                   
[RIGHT_JOIN(String, Object[])][59]                | Appends the RIGHT JOIN clause using the provided *format* string and parameters.                                                                                                                                                                           
[SELECT()][60]                                    | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                      
[SELECT(String)][61]                              | Appends the SELECT clause using the provided *body*.                                                                                                                                                                                                       
[SELECT(String, Object[])][62]                    | Appends the SELECT clause using the provided *format* string and parameters.                                                                                                                                                                               
[SET(String)][63]                                 | Appends the SET clause using the provided *body*.                                                                                                                                                                                                          
[SET(String, Object[])][64]                       | Appends the SET clause using the provided *format* string and parameters.                                                                                                                                                                                  
[SetCurrentClause][65]                            | Sets *clauseName* as the current SQL clause.                                                                                                                                                                                                               
[SetNextClause][66]                               | Sets *clauseName* as the next SQL clause.                                                                                                                                                                                                                  
[ToCommand(DbConnection)][67]                     | Creates and returns a [DbCommand][68] object whose [CommandText][69] property is initialized with the SQL representation of this instance, and whose [Parameters][70] property is initialized with the values from [ParameterValues][71] of this instance. 
[ToCommand(DbProviderFactory)][72]                | Creates and returns a [DbCommand][68] object whose [CommandText][69] property is initialized with the SQL representation of this instance, and whose [Parameters][70] property is initialized with the values from [ParameterValues][71] of this instance. 
[ToString][73]                                    | Converts the value of this instance to a [String][42]. (Overrides [Object.ToString()][74].)                                                                                                                                                                
[UNION][75]                                       | Appends the UNION clause.                                                                                                                                                                                                                                  
[UPDATE(String)][76]                              | Appends the UPDATE clause using the provided *body*.                                                                                                                                                                                                       
[UPDATE(String, Object[])][77]                    | Appends the UPDATE clause using the provided *format* string and parameters.                                                                                                                                                                               
[VALUES][78]                                      | Appends the VALUES clause using the provided parameters.                                                                                                                                                                                                   
[WHERE()][79]                                     | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String)][6] and [_If(Boolean, String)][13].                                                                                                       
[WHERE(String)][80]                               | Appends the WHERE clause using the provided *body*.                                                                                                                                                                                                        
[WHERE(String, Object[])][81]                     | Appends the WHERE clause using the provided *format* string and parameters.                                                                                                                                                                                
[WITH(String)][82]                                | Appends the WITH clause using the provided *body*.                                                                                                                                                                                                         
[WITH(String, Object[])][83]                      | Appends the WITH clause using the provided *format* string and parameters.                                                                                                                                                                                 
[WITH(SqlBuilder, String)][84]                    | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                                                                                                         


Properties
----------

Name                   | Description                                                                                                                                            
---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ 
[Buffer][85]           | The underlying [StringBuilder][86].                                                                                                                    
[CurrentClause][87]    | Gets or sets the current SQL clause, used to identify consecutive appends to the same clause.                                                          
[CurrentSeparator][88] | Gets or sets the separator of the current SQL clause body.                                                                                             
[IsEmpty][89]          | Returns true if the buffer is empty.                                                                                                                   
[NextClause][90]       | Gets or sets the next SQL clause. Used by clause continuation methods, such as [AppendToCurrentClause(String)][7] and the methods that start with "_". 
[NextSeparator][91]    | Gets or sets the separator of the next SQL clause body.                                                                                                
[ParameterValues][71]  | The parameter objects to be included in the database command.                                                                                          


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