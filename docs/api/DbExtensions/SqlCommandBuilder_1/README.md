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
![Public method] | [Equals][10]                                               | Returns whether the specified object is equal to the current object. (Overrides [Object.Equals(Object)][11].)                                                      
![Public method] | [GetHashCode][12]                                          | Returns the hash function for the current object. (Overrides [Object.GetHashCode()][13].)                                                                          
![Public method] | [GetType][14]                                              | Gets the type for the current object.                                                                                                                              
![Public method] | [INSERT_INTO_VALUES][15]                                   | Creates and returns an INSERT command for the specified *entity*.                                                                                                  
![Public method] | [SELECT_()][16]                                            | Creates and returns a SELECT query for the current table that includes the SELECT clause only.                                                                     
![Public method] | [SELECT_(String)][17]                                      | Creates and returns a SELECT query for the current table that includes the SELECT clause only. All column names are qualified with the provided *tableAlias*.      
![Public method] | [SELECT_FROM()][18]                                        | Creates and returns a SELECT query for the current table that includes the SELECT and FROM clauses.                                                                
![Public method] | [SELECT_FROM(String)][19]                                  | Creates and returns a SELECT query for the current table that includes the SELECT and FROM clauses. All column names are qualified with the provided *tableAlias*. 
![Public method] | [ToString][20]                                             | Returns a string representation of the object. (Overrides [Object.ToString()][21].)                                                                                
![Public method] | [UPDATE][22]                                               | Creates and returns an UPDATE command for the current table that includes the UPDATE clause.                                                                       
![Public method] | [UPDATE_SET_WHERE(TEntity)][23]                            | Creates and returns an UPDATE command for the specified *entity*, using the default [ConcurrencyConflictPolicy][7].                                                
![Public method] | [UPDATE_SET_WHERE(TEntity, ConcurrencyConflictPolicy)][24] | Creates and returns an UPDATE command for the specified *entity* using the provided *conflictPolicy*.                                                              


See Also
--------

#### Reference
[DbExtensions Namespace][4]  
[SqlTable&lt;TEntity>.SQL][25]  
[SqlTable.SQL][26]  

[1]: ../SqlTable/README.md
[2]: ../SqlTable_1/README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: DELETE_FROM.md
[6]: DELETE_FROM_WHERE.md
[7]: ../ConcurrencyConflictPolicy/README.md
[8]: DELETE_FROM_WHERE_1.md
[9]: DELETE_FROM_WHERE_id.md
[10]: Equals.md
[11]: http://msdn.microsoft.com/en-us/library/bsc2ak47
[12]: GetHashCode.md
[13]: http://msdn.microsoft.com/en-us/library/zdee4b3y
[14]: GetType.md
[15]: INSERT_INTO_VALUES.md
[16]: SELECT_.md
[17]: SELECT__1.md
[18]: SELECT_FROM.md
[19]: SELECT_FROM_1.md
[20]: ToString.md
[21]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[22]: UPDATE.md
[23]: UPDATE_SET_WHERE.md
[24]: UPDATE_SET_WHERE_1.md
[25]: ../SqlTable_1/SQL.md
[26]: ../SqlTable/SQL.md
[Public method]: ../../_icons/pubmethod.gif "Public method"