SqlCommandBuilder&lt;TEntity> Class
===================================
Generates SQL commands for annotated classes. This class cannot be instantiated, to get an instance use the [CommandBuilder][1] or [CommandBuilder][2] properties.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **DbExtensions.SqlCommandBuilder<TEntity>**  

**Namespace:** [DbExtensions][4]  
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

                 | Name                                                 | Description                                                                                                                                                        
---------------- | ---------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
![Public method] | [BuildDeleteStatement][5]                            | Creates and returns a DELETE command for the current table that includes the DELETE and FROM clauses.                                                              
![Public method] | [BuildDeleteStatementForEntity][6]                   | Creates and returns a DELETE command for the specified *entity*.                                                                                                   
![Public method] | [BuildDeleteStatementForKey][7]                      | Creates and returns a DELETE command for the entity whose primary key matches the *id* parameter.                                                                  
![Public method] | [BuildInsertStatementForEntity][8]                   | Creates and returns an INSERT command for the specified *entity*.                                                                                                  
![Public method] | [BuildSelectClause()][9]                             | Creates and returns a SELECT query for the current table that includes the SELECT clause only.                                                                     
![Public method] | [BuildSelectClause(String)][10]                      | Creates and returns a SELECT query for the current table that includes the SELECT clause only. All column names are qualified with the provided *tableAlias*.      
![Public method] | [BuildSelectStatement()][11]                         | Creates and returns a SELECT query for the current table that includes the SELECT and FROM clauses.                                                                
![Public method] | [BuildSelectStatement(String)][12]                   | Creates and returns a SELECT query for the current table that includes the SELECT and FROM clauses. All column names are qualified with the provided *tableAlias*. 
![Public method] | [BuildUpdateClause][13]                              | Creates and returns an UPDATE command for the current table that includes the UPDATE clause.                                                                       
![Public method] | [BuildUpdateStatementForEntity(TEntity)][14]         | Creates and returns an UPDATE command for the specified *entity*.                                                                                                  
![Public method] | [BuildUpdateStatementForEntity(TEntity, Object)][15] | Creates and returns an UPDATE command for the specified *entity*.                                                                                                  


See Also
--------

#### Reference
[DbExtensions Namespace][4]  

[1]: ../SqlTable_1/CommandBuilder.md
[2]: ../SqlTable/CommandBuilder.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: BuildDeleteStatement.md
[6]: BuildDeleteStatementForEntity.md
[7]: BuildDeleteStatementForKey.md
[8]: BuildInsertStatementForEntity.md
[9]: BuildSelectClause.md
[10]: BuildSelectClause_1.md
[11]: BuildSelectStatement.md
[12]: BuildSelectStatement_1.md
[13]: BuildUpdateClause.md
[14]: BuildUpdateStatementForEntity.md
[15]: BuildUpdateStatementForEntity_1.md
[Public method]: ../../_icons/pubmethod.gif "Public method"