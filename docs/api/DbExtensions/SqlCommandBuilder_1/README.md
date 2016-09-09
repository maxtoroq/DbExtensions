SqlCommandBuilder&lt;TEntity> Class
===================================
Generates SQL commands for entities mapped by [SqlTable&lt;TEntity>][1] and [SqlTable][2]. This class cannot be instantiated, to get an instance use the [CommandBuilder][3] or [CommandBuilder][4] properties.


Inheritance Hierarchy
---------------------
[System.Object][5]  
  **DbExtensions.SqlCommandBuilder<TEntity>**  

**Namespace:** [DbExtensions][6]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public sealed class SqlCommandBuilder<TEntity>
where TEntity : class

```

#### Type Parameters

##### *TEntity*
The type of the entity to generate commands for.

The **SqlCommandBuilder<TEntity>** type exposes the following members.


Methods
-------

                 | Name                                | Description                                                                                                                                                        
---------------- | ----------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
![Public method] | [BuildDeleteStatement][7]           | Creates and returns a DELETE command for the current table that includes the DELETE and FROM clauses.                                                              
![Public method] | [BuildDeleteStatementForEntity][8]  | Creates and returns a DELETE command for the specified *entity*.                                                                                                   
![Public method] | [BuildDeleteStatementForKey][9]     | Creates and returns a DELETE command for the entity whose primary key matches the *id* parameter.                                                                  
![Public method] | [BuildInsertStatementForEntity][10] | Creates and returns an INSERT command for the specified *entity*.                                                                                                  
![Public method] | [BuildSelectClause()][11]           | Creates and returns a SELECT query for the current table that includes the SELECT clause only.                                                                     
![Public method] | [BuildSelectClause(String)][12]     | Creates and returns a SELECT query for the current table that includes the SELECT clause only. All column names are qualified with the provided *tableAlias*.      
![Public method] | [BuildSelectStatement()][13]        | Creates and returns a SELECT query for the current table that includes the SELECT and FROM clauses.                                                                
![Public method] | [BuildSelectStatement(String)][14]  | Creates and returns a SELECT query for the current table that includes the SELECT and FROM clauses. All column names are qualified with the provided *tableAlias*. 
![Public method] | [BuildUpdateClause][15]             | Creates and returns an UPDATE command for the current table that includes the UPDATE clause.                                                                       
![Public method] | [BuildUpdateStatementForEntity][16] | Creates and returns an UPDATE command for the specified *entity*.                                                                                                  


See Also
--------

#### Reference
[DbExtensions Namespace][6]  

[1]: ../SqlTable_1/README.md
[2]: ../SqlTable/README.md
[3]: ../SqlTable_1/CommandBuilder.md
[4]: ../SqlTable/CommandBuilder.md
[5]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[6]: ../README.md
[7]: BuildDeleteStatement.md
[8]: BuildDeleteStatementForEntity.md
[9]: BuildDeleteStatementForKey.md
[10]: BuildInsertStatementForEntity.md
[11]: BuildSelectClause.md
[12]: BuildSelectClause_1.md
[13]: BuildSelectStatement.md
[14]: BuildSelectStatement_1.md
[15]: BuildUpdateClause.md
[16]: BuildUpdateStatementForEntity.md
[Public method]: ../../_icons/pubmethod.gif "Public method"