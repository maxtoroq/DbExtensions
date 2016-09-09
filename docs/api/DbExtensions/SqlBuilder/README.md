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
![Public method]                 | [GROUP_BY()][19]                                  | Sets GROUP BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8]. 
![Public method]                 | [GROUP_BY(String, Object[])][20]                  | Appends the GROUP BY clause using the provided *format* string and parameters.                                                                                             
![Public method]                 | [HAVING()][21]                                    | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8].   
![Public method]                 | [HAVING(String, Object[])][22]                    | Appends the HAVING clause using the provided *format* string and parameters.                                                                                               
![Public method]                 | [INNER_JOIN][23]                                  | Appends the INNER JOIN clause using the provided *format* string and parameters.                                                                                           
![Public method]                 | [Insert][24]                                      | Inserts a string into this instance at the specified character position.                                                                                                   
![Public method]                 | [INSERT_INTO][25]                                 | Appends the INSERT INTO clause using the provided *format* string and parameters.                                                                                          
![Public method]                 | [JOIN()][26]                                      | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8].     
![Public method]                 | [JOIN(String, Object[])][27]                      | Appends the JOIN clause using the provided *format* string and parameters.                                                                                                 
![Public method]![Static member] | [JoinSql(String, SqlBuilder[])][28]               | Concatenates a specified separator [String][29] between each element of a specified **SqlBuilder** array, yielding a single concatenated **SqlBuilder**.                   
![Public method]![Static member] | [JoinSql(String, IEnumerable&lt;SqlBuilder>)][30] | Concatenates the members of a constructed [IEnumerable&lt;T>][31] collection of type **SqlBuilder**, using the specified *separator* between each member.                  
![Public method]                 | [LEFT_JOIN][32]                                   | Appends the LEFT JOIN clause using the provided *format* string and parameters.                                                                                            
![Public method]                 | [LIMIT()][33]                                     | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8].    
![Public method]                 | [LIMIT(Int32)][34]                                | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                                        
![Public method]                 | [LIMIT(String, Object[])][35]                     | Appends the LIMIT clause using the provided *format* string and parameters.                                                                                                
![Public method]                 | [OFFSET()][36]                                    | Sets OFFSET as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8].   
![Public method]                 | [OFFSET(Int32)][37]                               | Appends the OFFSET clause using the provided *startIndex* parameter.                                                                                                       
![Public method]                 | [OFFSET(String, Object[])][38]                    | Appends the OFFSET clause using the provided *format* string and parameters.                                                                                               
![Public method]                 | [ORDER_BY()][39]                                  | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8]. 
![Public method]                 | [ORDER_BY(String, Object[])][40]                  | Appends the ORDER BY clause using the provided *format* string and parameters.                                                                                             
![Public method]                 | [RIGHT_JOIN][41]                                  | Appends the RIGHT JOIN clause using the provided *format* string and parameters.                                                                                           
![Public method]                 | [SELECT()][42]                                    | Sets SELECT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8].   
![Public method]                 | [SELECT(String, Object[])][43]                    | Appends the SELECT clause using the provided *format* string and parameters.                                                                                               
![Public method]                 | [SET][44]                                         | Appends the SET clause using the provided *format* string and parameters.                                                                                                  
![Public method]                 | [SetCurrentClause][45]                            | Sets *clauseName* as the current SQL clause.                                                                                                                               
![Public method]                 | [SetNextClause][46]                               | Sets *clauseName* as the next SQL clause.                                                                                                                                  
![Public method]                 | [ToString][47]                                    | Converts the value of this instance to a [String][29]. (Overrides [Object.ToString()][48].)                                                                                
![Public method]                 | [UNION][49]                                       | Appends the UNION clause.                                                                                                                                                  
![Public method]                 | [UPDATE][50]                                      | Appends the UPDATE clause using the provided *format* string and parameters.                                                                                               
![Public method]                 | [VALUES][51]                                      | Appends the VALUES clause using the provided parameters.                                                                                                                   
![Public method]                 | [WHERE()][52]                                     | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][5] and [_If(Boolean, String, Object[])][8].    
![Public method]                 | [WHERE(String, Object[])][53]                     | Appends the WHERE clause using the provided *format* string and parameters.                                                                                                
![Public method]                 | [WITH(String, Object[])][54]                      | Appends the WITH clause using the provided *format* string and parameters.                                                                                                 
![Public method]                 | [WITH(SqlBuilder, String)][55]                    | Appends the WITH clause using the provided *subQuery* as body named after *alias*.                                                                                         


Properties
----------

                   | Name                   | Description                                                                                                                                                      
------------------ | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [Buffer][56]           | The underlying [StringBuilder][57].                                                                                                                              
![Public property] | [CurrentClause][58]    | Gets or sets the current SQL clause, used to identify consecutive appends to the same clause.                                                                    
![Public property] | [CurrentSeparator][59] | Gets or sets the separator of the current SQL clause body.                                                                                                       
![Public property] | [IsEmpty][60]          | Returns true if the buffer is empty.                                                                                                                             
![Public property] | [NextClause][61]       | Gets or sets the next SQL clause. Used by clause continuation methods, such as [AppendToCurrentClause(String, Object[])][6] and the methods that start with "_". 
![Public property] | [NextSeparator][62]    | Gets or sets the separator of the next SQL clause body.                                                                                                          
![Public property] | [ParameterValues][63]  | The parameter objects to be included in the database command.                                                                                                    


Remarks
-------
For information on how to use SqlBuilder see [SqlBuilder Tutorial][64].

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
[17]: FROM_1.md
[18]: FROM.md
[19]: GROUP_BY.md
[20]: GROUP_BY_1.md
[21]: HAVING.md
[22]: HAVING_1.md
[23]: INNER_JOIN.md
[24]: Insert.md
[25]: INSERT_INTO.md
[26]: JOIN.md
[27]: JOIN_1.md
[28]: JoinSql.md
[29]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[30]: JoinSql_1.md
[31]: http://msdn.microsoft.com/en-us/library/9eekhta0
[32]: LEFT_JOIN.md
[33]: LIMIT.md
[34]: LIMIT_1.md
[35]: LIMIT_2.md
[36]: OFFSET.md
[37]: OFFSET_1.md
[38]: OFFSET_2.md
[39]: ORDER_BY.md
[40]: ORDER_BY_1.md
[41]: RIGHT_JOIN.md
[42]: SELECT.md
[43]: SELECT_1.md
[44]: SET.md
[45]: SetCurrentClause.md
[46]: SetNextClause.md
[47]: ToString.md
[48]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[49]: UNION.md
[50]: UPDATE.md
[51]: VALUES.md
[52]: WHERE.md
[53]: WHERE_1.md
[54]: WITH_1.md
[55]: WITH.md
[56]: Buffer.md
[57]: http://msdn.microsoft.com/en-us/library/y9sxk6fy
[58]: CurrentClause.md
[59]: CurrentSeparator.md
[60]: IsEmpty.md
[61]: NextClause.md
[62]: NextSeparator.md
[63]: ParameterValues.md
[64]: http://maxtoroq.github.io/DbExtensions/docs/SqlBuilder.html
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Static member]: ../../_icons/static.gif "Static member"
[Public property]: ../../_icons/pubproperty.gif "Public property"