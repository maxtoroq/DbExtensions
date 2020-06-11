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
public class SqlBuilder
```

The **SqlBuilder** type exposes the following members.


Constructors
------------

                 | Name                              | Description                                                                                             
---------------- | --------------------------------- | ------------------------------------------------------------------------------------------------------- 
![Public method] | [SqlBuilder()][3]                 | Initializes a new instance of the **SqlBuilder** class.                                                 
![Public method] | [SqlBuilder(String, Object[])][4] | Initializes a new instance of the **SqlBuilder** class using the provided format string and parameters. 


Methods
-------

                                 | Name                                              | Description                                                                                                                                                                
-------------------------------- | ------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method]                 | [_][5]                                            | Appends *format* to the current clause. This method is a shortcut for [AppendToCurrentClause(String, Object[])][6].                                                        
![Public method]                 | [_ForEach&lt;T>][7]                               | Appends to the current clause the string made by concatenating an *itemFormat* for each element in *items*, interspersed with *separator*.                                 
![Public method]                 | [_If][8]                                          | Appends *format* to the current clause if *condition* is true.                                                                                                             
![Public method]                 | [_OR&lt;T>][9]                                    | Appends to the current clause the string made by concatenating an *itemFormat* for each element in *items*, interspersed with the OR operator.                             
![Public method]                 | [Append(SqlBuilder)][10]                          | Appends *sql* to this instance.                                                                                                                                            
![Public method]                 | [Append(String, Object[])][11]                    | Appends *format* to this instance.                                                                                                                                         
![Public method]                 | [AppendClause][12]                                | Appends the SQL clause specified by *clauseName* using the provided *format* string and parameters.                                                                        
![Public method]                 | [AppendLine][13]                                  | Appends the default line terminator to this instance.                                                                                                                      
![Public method]                 | [AppendToCurrentClause][6]                        | Appends *format* to the current clause.                                                                                                                                    
![Public method]                 | [Clone][14]                                       | Creates and returns a copy of this instance.                                                                                                                               
![Public method]                 | [CROSS_JOIN][15]                                  | Appends the CROSS JOIN clause using the provided *format* string and parameters.                                                                                           
![Public method]                 | [DELETE_FROM][16]                                 | Appends the DELETE FROM clause using the provided *format* string and parameters.                                                                                          
![Public method]                 | [FROM(String, Object[])][17]                      | Appends the FROM clause using the provided *format* string and parameters.                                                                                                 
![Public method]                 | [FROM(SqlBuilder, String)][18]                    | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                         
![Public method]                 | [FROM(SqlSet, String)][19]                        | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                         
![Public method]                 | [GROUP_BY()][20]                                  | Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8]. 
![Public method]                 | [GROUP_BY(String, Object[])][21]                  | Appends the GROUP BY clause using the provided *format* string and parameters.                                                                                             
![Public method]                 | [HAVING()][22]                                    | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8].   
![Public method]                 | [HAVING(String, Object[])][23]                    | Appends the HAVING clause using the provided *format* string and parameters.                                                                                               
![Public method]                 | [INNER_JOIN][24]                                  | Appends the INNER JOIN clause using the provided *format* string and parameters.                                                                                           
![Public method]                 | [Insert][25]                                      | Inserts a string into this instance at the specified character position.                                                                                                   
![Public method]                 | [INSERT_INTO][26]                                 | Appends the INSERT INTO clause using the provided *format* string and parameters.                                                                                          
![Public method]                 | [JOIN()][27]                                      | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8].     
![Public method]                 | [JOIN(String, Object[])][28]                      | Appends the JOIN clause using the provided *format* string and parameters.                                                                                                 
![Public method]![Static member] | [JoinSql(String, SqlBuilder[])][29]               | Concatenates a specified separator [String][30] between each element of a specified **SqlBuilder** array, yielding a single concatenated **SqlBuilder**.                   
![Public method]![Static member] | [JoinSql(String, IEnumerable&lt;SqlBuilder>)][31] | Concatenates the members of a constructed [IEnumerable&lt;T>][32] collection of type **SqlBuilder**, using the specified *separator* between each member.                  
![Public method]                 | [LEFT_JOIN][33]                                   | Appends the LEFT JOIN clause using the provided *format* string and parameters.                                                                                            
![Public method]                 | [LIMIT()][34]                                     | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8].    
![Public method]                 | [LIMIT(Int32)][35]                                | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                                        
![Public method]                 | [LIMIT(String, Object[])][36]                     | Appends the LIMIT clause using the provided *format* string and parameters.                                                                                                
![Public method]                 | [OFFSET()][37]                                    | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8].   
![Public method]                 | [OFFSET(Int32)][38]                               | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                                       
![Public method]                 | [OFFSET(String, Object[])][39]                    | Appends the OFFSET clause using the provided *format* string and parameters.                                                                                               
![Public method]                 | [ORDER_BY()][40]                                  | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8]. 
![Public method]                 | [ORDER_BY(String, Object[])][41]                  | Appends the ORDER BY clause using the provided *format* string and parameters.                                                                                             
![Public method]                 | [RIGHT_JOIN][42]                                  | Appends the RIGHT JOIN clause using the provided *format* string and parameters.                                                                                           
![Public method]                 | [SELECT()][43]                                    | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8].   
![Public method]                 | [SELECT(String, Object[])][44]                    | Appends the SELECT clause using the provided *format* string and parameters.                                                                                               
![Public method]                 | [SET][45]                                         | Appends the SET clause using the provided *format* string and parameters.                                                                                                  
![Public method]                 | [SetCurrentClause][46]                            | Sets *clauseName* as the current SQL clause.                                                                                                                               
![Public method]                 | [SetNextClause][47]                               | Sets *clauseName* as the next SQL clause.                                                                                                                                  
![Public method]                 | [ToString][48]                                    | Converts the value of this instance to a [String][30]. (Overrides [Object.ToString()][49].)                                                                                
![Public method]                 | [UNION][50]                                       | Appends the UNION clause.                                                                                                                                                  
![Public method]                 | [UPDATE][51]                                      | Appends the UPDATE clause using the provided *format* string and parameters.                                                                                               
![Public method]                 | [VALUES][52]                                      | Appends the VALUES clause using the provided parameters.                                                                                                                   
![Public method]                 | [WHERE()][53]                                     | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8].    
![Public method]                 | [WHERE(String, Object[])][54]                     | Appends the WHERE clause using the provided *format* string and parameters.                                                                                                
![Public method]                 | [WITH(String, Object[])][55]                      | Appends the WITH clause using the provided *format* string and parameters.                                                                                                 
![Public method]                 | [WITH(SqlBuilder, String)][56]                    | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                         
![Public method]                 | [WITH(SqlSet, String)][57]                        | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                         


Properties
----------

                   | Name                   | Description                                                                                                                                                      
------------------ | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [Buffer][58]           | The underlying [StringBuilder][59].                                                                                                                              
![Public property] | [CurrentClause][60]    | Gets or sets the current SQL clause, used to identify consecutive appends to the same clause.                                                                    
![Public property] | [CurrentSeparator][61] | Gets or sets the separator of the current SQL clause body.                                                                                                       
![Public property] | [IsEmpty][62]          | Returns true if the buffer is empty.                                                                                                                             
![Public property] | [NextClause][63]       | Gets or sets the next SQL clause. Used by clause continuation methods, such as [AppendToCurrentClause(String, Object[])][6] and the methods that start with "_". 
![Public property] | [NextSeparator][64]    | Gets or sets the separator of the next SQL clause body.                                                                                                          
![Public property] | [ParameterValues][65]  | The parameter objects to be included in the database command.                                                                                                    


Remarks
-------
For information on how to use SqlBuilder see [SqlBuilder Tutorial][66].

See Also
--------

#### Reference
[DbExtensions Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: _ctor_1.md
[5]: _.md
[6]: AppendToCurrentClause.md
[7]: _ForEach__1.md
[8]: _If.md
[9]: _OR__1.md
[10]: Append.md
[11]: Append_1.md
[12]: AppendClause.md
[13]: AppendLine.md
[14]: Clone.md
[15]: CROSS_JOIN.md
[16]: DELETE_FROM.md
[17]: FROM_2.md
[18]: FROM.md
[19]: FROM_1.md
[20]: GROUP_BY.md
[21]: GROUP_BY_1.md
[22]: HAVING.md
[23]: HAVING_1.md
[24]: INNER_JOIN.md
[25]: Insert.md
[26]: INSERT_INTO.md
[27]: JOIN.md
[28]: JOIN_1.md
[29]: JoinSql.md
[30]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[31]: JoinSql_1.md
[32]: http://msdn.microsoft.com/en-us/library/9eekhta0
[33]: LEFT_JOIN.md
[34]: LIMIT.md
[35]: LIMIT_1.md
[36]: LIMIT_2.md
[37]: OFFSET.md
[38]: OFFSET_1.md
[39]: OFFSET_2.md
[40]: ORDER_BY.md
[41]: ORDER_BY_1.md
[42]: RIGHT_JOIN.md
[43]: SELECT.md
[44]: SELECT_1.md
[45]: SET.md
[46]: SetCurrentClause.md
[47]: SetNextClause.md
[48]: ToString.md
[49]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[50]: UNION.md
[51]: UPDATE.md
[52]: VALUES.md
[53]: WHERE.md
[54]: WHERE_1.md
[55]: WITH_2.md
[56]: WITH.md
[57]: WITH_1.md
[58]: Buffer.md
[59]: http://msdn.microsoft.com/en-us/library/y9sxk6fy
[60]: CurrentClause.md
[61]: CurrentSeparator.md
[62]: IsEmpty.md
[63]: NextClause.md
[64]: NextSeparator.md
[65]: ParameterValues.md
[66]: http://maxtoroq.github.io/DbExtensions/docs/SqlBuilder.html
[Public method]: ../../icons/pubmethod.gif "Public method"
[Static member]: ../../icons/static.gif "Static member"
[Public property]: ../../icons/pubproperty.gif "Public property"