Database Class
==============
Provides simple data access using [SqlSet][1], [SqlBuilder][2] and [SqlTable&lt;TEntity>][3].


Inheritance Hierarchy
---------------------
[System.Object][4]  
  **DbExtensions.Database**  

**Namespace:** [DbExtensions][5]  
**Assembly:** DbExtensions (in DbExtensions.dll)

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


Methods
-------

                                | Name                                                              | Description                                                                                                                                                                                                                                                                                                                      
------------------------------- | ----------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method]                | [Add][10]                                                         | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                                                                                                             
![Public method]                | [Contains][11]                                                    | Checks the existance of the *entity*, using the primary key value.                                                                                                                                                                                                                                                               
![Public method]                | [ContainsKey(Type, Object)][12]                                   | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                                                                                                                      
![Public method]                | [ContainsKey&lt;TEntity>(Object)][13]                             | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                                                                                                                      
![Public method]                | [CreateCommand(SqlBuilder)][14]                                   | Creates and returns an [IDbCommand][15] object from the specified *sqlBuilder*.                                                                                                                                                                                                                                                  
![Public method]                | [CreateCommand(String, Object[])][16]                             | Creates and returns an [IDbCommand][15] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][17]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][18] collection. 
![Public method]                | [Dispose()][19]                                                   | Releases all resources used by the current instance of the **Database** class.                                                                                                                                                                                                                                                   
![Protected method]             | [Dispose(Boolean)][20]                                            | Releases the resources used by this **Database** instance.                                                                                                                                                                                                                                                                       
![Public method]![Code example] | [EnsureConnectionOpen][21]                                        | Opens [Connection][22] (if it's not open) and returns an [IDisposable][23] object you can use to close it (if it wasn't open).                                                                                                                                                                                                   
![Public method]                | [EnsureInTransaction()][24]                                       | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                      
![Public method]                | [EnsureInTransaction(IsolationLevel)][25]                         | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                      
![Public method]                | [Execute(String, Object[])][26]                                   | Creates and executes an [IDbCommand][15] using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][17]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][18] collection.       
![Public method]                | [Execute(SqlBuilder, Int32, Boolean)][27]                         | Executes the *nonQuery* command. Optionally uses a transaction and validates affected records value before committing.                                                                                                                                                                                                           
![Public method]                | [Find(Type, Object)][28]                                          | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                                                                                                                                                    
![Public method]                | [Find&lt;TEntity>(Object)][29]                                    | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                                                                                                                                                    
![Public method]                | [From(String)][30]                                                | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                                                                                                                                                                             
![Public method]                | [From(SqlBuilder)][31]                                            | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                                                                                                                                                                         
![Public method]                | [From(String, Type)][32]                                          | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                                                                                                                                                                             
![Public method]                | [From(SqlBuilder, Type)][33]                                      | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                                                                                                                                                                         
![Public method]                | [From&lt;TResult>(String)][34]                                    | Creates and returns a new [SqlSet&lt;TResult>][35] using the provided table name.                                                                                                                                                                                                                                                
![Public method]                | [From&lt;TResult>(SqlBuilder)][36]                                | Creates and returns a new [SqlSet&lt;TResult>][35] using the provided defining query.                                                                                                                                                                                                                                            
![Public method]                | [From&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][37] | Creates and returns a new [SqlSet&lt;TResult>][35] using the provided defining query and mapper.                                                                                                                                                                                                                                 
![Public method]                | [LastInsertId][38]                                                | Gets the identity value of the last inserted record.                                                                                                                                                                                                                                                                             
![Public method]                | [Map(SqlBuilder)][39]                                             | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                                                                                                                                                                                                                              
![Public method]                | [Map(Type, SqlBuilder)][40]                                       | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                                                                                                                                                                      
![Public method]                | [Map&lt;TResult>(SqlBuilder)][41]                                 | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                                                                                                                                                                                                                              
![Public method]                | [Map&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][42]  | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                                                                                                                                                                                                                        
![Public method]                | [QuoteIdentifier][43]                                             | Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier, including properly escaping any embedded quotes in the identifier.                                                                                                                                                 
![Public method]                | [Remove][44]                                                      | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                                                                                                            
![Public method]                | [RemoveKey(Type, Object)][45]                                     | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                                                                                                           
![Public method]                | [RemoveKey&lt;TEntity>(Object)][46]                               | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                                                                                                           
![Public method]                | [Table(Type)][47]                                                 | Returns the [SqlTable][48] instance for the specified *entityType*.                                                                                                                                                                                                                                                              
![Public method]                | [Table&lt;TEntity>()][49]                                         | Returns the [SqlTable&lt;TEntity>][3] instance for the specified TEntity.                                                                                                                                                                                                                                                        
![Public method]                | [Update(Object)][50]                                              | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                                                                                           
![Public method]                | [Update(Object, Object)][51]                                      | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                                                                                           


Properties
----------

                   | Name                | Description                                                 
------------------ | ------------------- | ----------------------------------------------------------- 
![Public property] | [Configuration][52] | Provides access to configuration options for this instance. 
![Public property] | [Connection][22]    | Gets the connection to associate with new commands.         
![Public property] | [Transaction][53]   | Gets or sets a transaction to associate with new commands.  


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
[10]: Add.md
[11]: Contains.md
[12]: ContainsKey.md
[13]: ContainsKey__1.md
[14]: CreateCommand.md
[15]: http://msdn.microsoft.com/en-us/library/bt2afddc
[16]: CreateCommand_1.md
[17]: http://msdn.microsoft.com/en-us/library/b1csw23d
[18]: http://msdn.microsoft.com/en-us/library/btt06a5s
[19]: Dispose.md
[20]: Dispose_1.md
[21]: EnsureConnectionOpen.md
[22]: Connection.md
[23]: http://msdn.microsoft.com/en-us/library/aax125c9
[24]: EnsureInTransaction.md
[25]: EnsureInTransaction_1.md
[26]: Execute_1.md
[27]: Execute.md
[28]: Find.md
[29]: Find__1.md
[30]: From_2.md
[31]: From.md
[32]: From_3.md
[33]: From_1.md
[34]: From__1_2.md
[35]: ../SqlSet_1/README.md
[36]: From__1.md
[37]: From__1_1.md
[38]: LastInsertId.md
[39]: Map.md
[40]: Map_1.md
[41]: Map__1.md
[42]: Map__1_1.md
[43]: QuoteIdentifier.md
[44]: Remove.md
[45]: RemoveKey.md
[46]: RemoveKey__1.md
[47]: Table.md
[48]: ../SqlTable/README.md
[49]: Table__1.md
[50]: Update.md
[51]: Update_1.md
[52]: Configuration.md
[53]: Transaction.md
[Public method]: ../../icons/pubmethod.gif "Public method"
[Protected method]: ../../icons/protmethod.gif "Protected method"
[Code example]: ../../icons/CodeExample.png "Code example"
[Public property]: ../../icons/pubproperty.gif "Public property"