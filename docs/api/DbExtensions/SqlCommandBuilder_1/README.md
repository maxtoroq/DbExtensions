SqlCommandBuilder&lt;TEntity> Class
===================================
Generates SQL commands for entities mapped by [SqlTable][1] and [SqlTable&lt;TEntity>][2]. This class cannot be instantiated.


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

                 | Name                                                       | Description                                                                                                                                                        
---------------- | ---------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
![Public method] | [DELETE_FROM][5]                                           | Creates and returns a DELETE command for the current table that includes the DELETE and FROM clauses.                                                              
![Public method] | [DELETE_FROM_WHERE(TEntity)][6]                            | Creates and returns a DELETE command for the specified *entity*, using the default [ConcurrencyConflictPolicy][7].                                                 
![Public method] | [DELETE_FROM_WHERE(TEntity, ConcurrencyConflictPolicy)][8] | Creates and returns a DELETE command for the specified *entity* using the provided *conflictPolicy*.                                                               
![Public method] | [DELETE_FROM_WHERE_id][9]                                  | Creates and returns a DELETE command for the entity whose primary key matches the *id* parameter.                                                                  
![Public method] | [INSERT_INTO_VALUES][10]                                   | Creates and returns an INSERT command for the specified *entity*.                                                                                                  
![Public method] | [SELECT_()][11]                                            | Creates and returns a SELECT query for the current table that includes the SELECT clause only.                                                                     
![Public method] | [SELECT_(String)][12]                                      | Creates and returns a SELECT query for the current table that includes the SELECT clause only. All column names are qualified with the provided *tableAlias*.      
![Public method] | [SELECT_FROM()][13]                                        | Creates and returns a SELECT query for the current table that includes the SELECT and FROM clauses.                                                                
![Public method] | [SELECT_FROM(String)][14]                                  | Creates and returns a SELECT query for the current table that includes the SELECT and FROM clauses. All column names are qualified with the provided *tableAlias*. 
![Public method] | [UPDATE][15]                                               | Creates and returns an UPDATE command for the current table that includes the UPDATE clause.                                                                       
![Public method] | [UPDATE_SET_WHERE(TEntity)][16]                            | Creates and returns an UPDATE command for the specified *entity*, using the default [ConcurrencyConflictPolicy][7].                                                
![Public method] | [UPDATE_SET_WHERE(TEntity, ConcurrencyConflictPolicy)][17] | Creates and returns an UPDATE command for the specified *entity* using the provided *conflictPolicy*.                                                              


See Also
--------

#### Reference
[DbExtensions Namespace][4]  
[SqlTable&lt;TEntity>.SQL][18]  
[SqlTable.SQL][19]  

[1]: ../SqlTable/README.md
[2]: ../SqlTable_1/README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: DELETE_FROM.md
[6]: DELETE_FROM_WHERE.md
[7]: ../ConcurrencyConflictPolicy/README.md
[8]: DELETE_FROM_WHERE_1.md
[9]: DELETE_FROM_WHERE_id.md
[10]: INSERT_INTO_VALUES.md
[11]: SELECT_.md
[12]: SELECT__1.md
[13]: SELECT_FROM.md
[14]: SELECT_FROM_1.md
[15]: UPDATE.md
[16]: UPDATE_SET_WHERE.md
[17]: UPDATE_SET_WHERE_1.md
[18]: ../SqlTable_1/SQL.md
[19]: ../SqlTable/SQL.md
[Public method]: ../../_icons/pubmethod.gif "Public method"