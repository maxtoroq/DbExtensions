Database Class
==============
Provides simple data access using [SqlSet][1], [SqlBuilder][2] and [SqlTable&lt;TEntity>][3].


Inheritance Hierarchy
---------------------
[System.Object][4]  
  **DbExtensions.Database**  

  **Namespace:**  [DbExtensions][5]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public class Database : IDisposable
```

The **Database** type exposes the following members.


Constructors
------------

                 | Name                          | Description                                                                                                              
---------------- | ----------------------------- | ------------------------------------------------------------------------------------------------------------------------ 
![Public method] | [Database()][6]               | Initializes a new instance of the **Database** class.                                                                    
![Public method] | [Database(IDbConnection)][7]  | Initializes a new instance of the **Database** class using the provided connection.                                      
![Public method] | [Database(String)][8]         | Initializes a new instance of the **Database** class using the provided connection string.                               
![Public method] | [Database(String, String)][9] | Initializes a new instance of the **Database** class using the provided connection string and provider's invariant name. 


Properties
----------

                   | Name                | Description                                                 
------------------ | ------------------- | ----------------------------------------------------------- 
![Public property] | [Configuration][10] | Provides access to configuration options for this instance. 
![Public property] | [Connection][11]    | Gets the connection to associate with new commands.         
![Public property] | [Transaction][12]   | Gets or sets a transaction to associate with new commands.  


Methods
-------

                                | Name                                                              | Description                                                                                                                                                                                                                                                                                                                      
------------------------------- | ----------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method]                | [Add][13]                                                         | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                                                                                                             
![Public method]                | [Contains][14]                                                    | Checks the existance of the *entity*, using the primary key value.                                                                                                                                                                                                                                                               
![Public method]                | [ContainsKey(Type, Object)][15]                                   | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                                                                                                                      
![Public method]                | [ContainsKey&lt;TEntity>(Object)][16]                             | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                                                                                                                      
![Public method]                | [CreateCommand(SqlBuilder)][17]                                   | Creates and returns an [IDbCommand][18] object from the specified *sqlBuilder*.                                                                                                                                                                                                                                                  
![Public method]                | [CreateCommand(String, Object[])][19]                             | Creates and returns an [IDbCommand][18] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][20]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][21] collection. 
![Public method]                | [Dispose()][22]                                                   | Releases all resources used by the current instance of the **Database** class.                                                                                                                                                                                                                                                   
![Protected method]             | [Dispose(Boolean)][23]                                            | Releases the resources used by this **Database** instance.                                                                                                                                                                                                                                                                       
![Public method]![Code example] | [EnsureConnectionOpen][24]                                        | Opens [Connection][11] (if it's not open) and returns an [IDisposable][25] object you can use to close it (if it wasn't open).                                                                                                                                                                                                   
![Public method]                | [EnsureInTransaction()][26]                                       | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                      
![Public method]                | [EnsureInTransaction(IsolationLevel)][27]                         | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                      
![Public method]                | [Execute(String, Object[])][28]                                   | Creates and executes an [IDbCommand][18] using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][20]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][21] collection.       
![Public method]                | [Execute(SqlBuilder, Int32, Boolean)][29]                         | Executes the *nonQuery* command. Optionally uses a transaction and validates affected records value before committing.                                                                                                                                                                                                           
![Public method]                | [Find(Type, Object)][30]                                          | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                                                                                                                                                    
![Public method]                | [Find&lt;TEntity>(Object)][31]                                    | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                                                                                                                                                    
![Public method]                | [From(String)][32]                                                | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                                                                                                                                                                             
![Public method]                | [From(SqlBuilder)][33]                                            | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                                                                                                                                                                         
![Public method]                | [From(String, Type)][34]                                          | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                                                                                                                                                                             
![Public method]                | [From(SqlBuilder, Type)][35]                                      | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                                                                                                                                                                         
![Public method]                | [From&lt;TResult>(String)][36]                                    | Creates and returns a new [SqlSet&lt;TResult>][37] using the provided table name.                                                                                                                                                                                                                                                
![Public method]                | [From&lt;TResult>(SqlBuilder)][38]                                | Creates and returns a new [SqlSet&lt;TResult>][37] using the provided defining query.                                                                                                                                                                                                                                            
![Public method]                | [From&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][39] | Creates and returns a new [SqlSet&lt;TResult>][37] using the provided defining query and mapper.                                                                                                                                                                                                                                 
![Public method]                | [LastInsertId][40]                                                | Gets the identity value of the last inserted record.                                                                                                                                                                                                                                                                             
![Public method]                | [Map(SqlBuilder)][41]                                             | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                                                                                                                                                                                                                              
![Public method]                | [Map(Type, SqlBuilder)][42]                                       | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                                                                                                                                                                      
![Public method]                | [Map&lt;TResult>(SqlBuilder)][43]                                 | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                                                                                                                                                                                                                              
![Public method]                | [Map&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][44]  | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                                                                                                                                                                                                                        
![Public method]                | [QuoteIdentifier][45]                                             | Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier, including properly escaping any embedded quotes in the identifier.                                                                                                                                                 
![Public method]                | [Remove][46]                                                      | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                                                                                                            
![Public method]                | [RemoveKey(Type, Object)][47]                                     | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                                                                                                           
![Public method]                | [RemoveKey&lt;TEntity>(Object)][48]                               | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                                                                                                           
![Public method]                | [Table(Type)][49]                                                 | Returns the [SqlTable][50] instance for the specified *entityType*.                                                                                                                                                                                                                                                              
![Public method]                | [Table&lt;TEntity>()][51]                                         | Returns the [SqlTable&lt;TEntity>][3] instance for the specified TEntity.                                                                                                                                                                                                                                                        
![Public method]                | [Update(Object)][52]                                              | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                                                                                           
![Public method]                | [Update(Object, Object)][53]                                      | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                                                                                           


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlSet/README.md
[2]: ../SqlBuilder/README.md
[3]: ../SqlTable_1/README.md
[4]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[5]: ../README.md
[6]: _ctor.md
[7]: _ctor_1.md
[8]: _ctor_2.md
[9]: _ctor_3.md
[10]: Configuration.md
[11]: Connection.md
[12]: Transaction.md
[13]: Add.md
[14]: Contains.md
[15]: ContainsKey.md
[16]: ContainsKey__1.md
[17]: CreateCommand.md
[18]: http://msdn.microsoft.com/en-us/library/bt2afddc
[19]: CreateCommand_1.md
[20]: http://msdn.microsoft.com/en-us/library/b1csw23d
[21]: http://msdn.microsoft.com/en-us/library/btt06a5s
[22]: Dispose.md
[23]: Dispose_1.md
[24]: EnsureConnectionOpen.md
[25]: http://msdn.microsoft.com/en-us/library/aax125c9
[26]: EnsureInTransaction.md
[27]: EnsureInTransaction_1.md
[28]: Execute_1.md
[29]: Execute.md
[30]: Find.md
[31]: Find__1.md
[32]: From_2.md
[33]: From.md
[34]: From_3.md
[35]: From_1.md
[36]: From__1_2.md
[37]: ../SqlSet_1/README.md
[38]: From__1.md
[39]: From__1_1.md
[40]: LastInsertId.md
[41]: Map.md
[42]: Map_1.md
[43]: Map__1.md
[44]: Map__1_1.md
[45]: QuoteIdentifier.md
[46]: Remove.md
[47]: RemoveKey.md
[48]: RemoveKey__1.md
[49]: Table.md
[50]: ../SqlTable/README.md
[51]: Table__1.md
[52]: Update.md
[53]: Update_1.md
[Public method]: ../../icons/pubmethod.gif "Public method"
[Public property]: ../../icons/pubproperty.gif "Public property"
[Protected method]: ../../icons/protmethod.gif "Protected method"
[Code example]: ../../icons/CodeExample.png "Code example"