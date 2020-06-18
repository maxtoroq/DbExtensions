SqlBuilder Class
================
  Represents a mutable SQL string.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **DbExtensions.SqlBuilder**  

  **Namespace:**  [DbExtensions][2]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

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
-------------------------------- | ------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method]                 | [_][14]                                           | Appends *format* to the current clause. This method is a shortcut for [AppendToCurrentClause(String, Object[])][11].                                                         
![Public method]                 | [_ForEach&lt;T>][15]                              | Appends to the current clause the string made by concatenating an *itemFormat* for each element in *items*, interspersed with *separator*.                                   
![Public method]                 | [_If][16]                                         | Appends *format* to the current clause if *condition* is true.                                                                                                               
![Public method]                 | [_OR&lt;T>][17]                                   | Appends to the current clause the string made by concatenating an *itemFormat* for each element in *items*, interspersed with the OR operator.                               
![Public method]                 | [Append(SqlBuilder)][18]                          | Appends *sql* to this instance.                                                                                                                                              
![Public method]                 | [Append(String, Object[])][19]                    | Appends *format* to this instance.                                                                                                                                           
![Public method]                 | [AppendClause][20]                                | Appends the SQL clause specified by *clauseName* using the provided *format* string and parameters.                                                                          
![Public method]                 | [AppendLine][21]                                  | Appends the default line terminator to this instance.                                                                                                                        
![Public method]                 | [AppendToCurrentClause][11]                       | Appends *format* to the current clause.                                                                                                                                      
![Public method]                 | [Clone][22]                                       | Creates and returns a copy of this instance.                                                                                                                                 
![Public method]                 | [CROSS_JOIN][23]                                  | Appends the CROSS JOIN clause using the provided *format* string and parameters.                                                                                             
![Public method]                 | [DELETE_FROM][24]                                 | Appends the DELETE FROM clause using the provided *format* string and parameters.                                                                                            
![Public method]                 | [FROM(String, Object[])][25]                      | Appends the FROM clause using the provided *format* string and parameters.                                                                                                   
![Public method]                 | [FROM(SqlBuilder, String)][26]                    | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                           
![Public method]                 | [FROM(SqlSet, String)][27]                        | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                                           
![Public method]                 | [GROUP_BY()][28]                                  | Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16]. 
![Public method]                 | [GROUP_BY(String, Object[])][29]                  | Appends the GROUP BY clause using the provided *format* string and parameters.                                                                                               
![Public method]                 | [HAVING()][30]                                    | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].   
![Public method]                 | [HAVING(String, Object[])][31]                    | Appends the HAVING clause using the provided *format* string and parameters.                                                                                                 
![Public method]                 | [INNER_JOIN][32]                                  | Appends the INNER JOIN clause using the provided *format* string and parameters.                                                                                             
![Public method]                 | [Insert][33]                                      | Inserts a string into this instance at the specified character position.                                                                                                     
![Public method]                 | [INSERT_INTO][34]                                 | Appends the INSERT INTO clause using the provided *format* string and parameters.                                                                                            
![Public method]                 | [JOIN()][35]                                      | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].     
![Public method]                 | [JOIN(String, Object[])][36]                      | Appends the JOIN clause using the provided *format* string and parameters.                                                                                                   
![Public method]![Static member] | [JoinSql(String, SqlBuilder[])][37]               | Concatenates a specified separator [String][38] between each element of a specified **SqlBuilder** array, yielding a single concatenated **SqlBuilder**.                     
![Public method]![Static member] | [JoinSql(String, IEnumerable&lt;SqlBuilder>)][39] | Concatenates the members of a constructed [IEnumerable&lt;T>][40] collection of type **SqlBuilder**, using the specified *separator* between each member.                    
![Public method]                 | [LEFT_JOIN][41]                                   | Appends the LEFT JOIN clause using the provided *format* string and parameters.                                                                                              
![Public method]                 | [LIMIT()][42]                                     | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].    
![Public method]                 | [LIMIT(Int32)][43]                                | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                                          
![Public method]                 | [LIMIT(String, Object[])][44]                     | Appends the LIMIT clause using the provided *format* string and parameters.                                                                                                  
![Public method]                 | [OFFSET()][45]                                    | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].   
![Public method]                 | [OFFSET(Int32)][46]                               | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                                         
![Public method]                 | [OFFSET(String, Object[])][47]                    | Appends the OFFSET clause using the provided *format* string and parameters.                                                                                                 
![Public method]                 | [ORDER_BY()][48]                                  | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16]. 
![Public method]                 | [ORDER_BY(String, Object[])][49]                  | Appends the ORDER BY clause using the provided *format* string and parameters.                                                                                               
![Public method]                 | [RIGHT_JOIN][50]                                  | Appends the RIGHT JOIN clause using the provided *format* string and parameters.                                                                                             
![Public method]                 | [SELECT()][51]                                    | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].   
![Public method]                 | [SELECT(String, Object[])][52]                    | Appends the SELECT clause using the provided *format* string and parameters.                                                                                                 
![Public method]                 | [SET][53]                                         | Appends the SET clause using the provided *format* string and parameters.                                                                                                    
![Public method]                 | [SetCurrentClause][54]                            | Sets *clauseName* as the current SQL clause.                                                                                                                                 
![Public method]                 | [SetNextClause][55]                               | Sets *clauseName* as the next SQL clause.                                                                                                                                    
![Public method]                 | [ToString][56]                                    | Converts the value of this instance to a [String][38]. (Overrides [Object.ToString()][57].)                                                                                  
![Public method]                 | [UNION][58]                                       | Appends the UNION clause.                                                                                                                                                    
![Public method]                 | [UPDATE][59]                                      | Appends the UPDATE clause using the provided *format* string and parameters.                                                                                                 
![Public method]                 | [VALUES][60]                                      | Appends the VALUES clause using the provided parameters.                                                                                                                     
![Public method]                 | [WHERE()][61]                                     | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][14] and [_If(Boolean, String, Object[])][16].    
![Public method]                 | [WHERE(String, Object[])][62]                     | Appends the WHERE clause using the provided *format* string and parameters.                                                                                                  
![Public method]                 | [WITH(String, Object[])][63]                      | Appends the WITH clause using the provided *format* string and parameters.                                                                                                   
![Public method]                 | [WITH(SqlBuilder, String)][64]                    | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                           
![Public method]                 | [WITH(SqlSet, String)][65]                        | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                           


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
[15]: _ForEach__1.md
[16]: _If.md
[17]: _OR__1.md
[18]: Append.md
[19]: Append_1.md
[20]: AppendClause.md
[21]: AppendLine.md
[22]: Clone.md
[23]: CROSS_JOIN.md
[24]: DELETE_FROM.md
[25]: FROM_2.md
[26]: FROM.md
[27]: FROM_1.md
[28]: GROUP_BY.md
[29]: GROUP_BY_1.md
[30]: HAVING.md
[31]: HAVING_1.md
[32]: INNER_JOIN.md
[33]: Insert.md
[34]: INSERT_INTO.md
[35]: JOIN.md
[36]: JOIN_1.md
[37]: JoinSql.md
[38]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[39]: JoinSql_1.md
[40]: http://msdn.microsoft.com/en-us/library/9eekhta0
[41]: LEFT_JOIN.md
[42]: LIMIT.md
[43]: LIMIT_1.md
[44]: LIMIT_2.md
[45]: OFFSET.md
[46]: OFFSET_1.md
[47]: OFFSET_2.md
[48]: ORDER_BY.md
[49]: ORDER_BY_1.md
[50]: RIGHT_JOIN.md
[51]: SELECT.md
[52]: SELECT_1.md
[53]: SET.md
[54]: SetCurrentClause.md
[55]: SetNextClause.md
[56]: ToString.md
[57]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[58]: UNION.md
[59]: UPDATE.md
[60]: VALUES.md
[61]: WHERE.md
[62]: WHERE_1.md
[63]: WITH_2.md
[64]: WITH.md
[65]: WITH_1.md
[66]: http://maxtoroq.github.io/DbExtensions/docs/SqlBuilder.html
[Public method]: ../../icons/pubmethod.gif "Public method"
[Public property]: ../../icons/pubproperty.gif "Public property"
[Static member]: ../../icons/static.gif "Static member"