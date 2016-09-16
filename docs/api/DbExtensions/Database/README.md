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
![Public method]                | [CreateCommand(SqlBuilder)][10]                                   | Creates and returns an [IDbCommand][11] object from the specified *sqlBuilder*.                                                                                                                                                                                                                                                  
![Public method]                | [CreateCommand(String, Object[])][12]                             | Creates and returns an [IDbCommand][11] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][13]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][14] collection. 
![Public method]                | [Dispose()][15]                                                   | Releases all resources used by the current instance of the **Database** class.                                                                                                                                                                                                                                                   
![Protected method]             | [Dispose(Boolean)][16]                                            | Releases the resources used by this **Database** instance.                                                                                                                                                                                                                                                                       
![Public method]![Code example] | [EnsureConnectionOpen][17]                                        | Opens [Connection][18] (if it's not open) and returns an [IDisposable][19] object you can use to close it (if it wasn't open).                                                                                                                                                                                                   
![Public method]                | [EnsureInTransaction()][20]                                       | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                      
![Public method]                | [EnsureInTransaction(IsolationLevel)][21]                         | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                      
![Public method]                | [Execute(String, Object[])][22]                                   | Creates and executes an [IDbCommand][11] using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][13]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][14] collection.       
![Public method]                | [Execute(SqlBuilder, Int32, Boolean)][23]                         | Executes the *nonQuery* command. Optionally uses a transaction and validates affected records value before committing.                                                                                                                                                                                                           
![Public method]                | [From(String)][24]                                                | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                                                                                                                                                                             
![Public method]                | [From(SqlBuilder)][25]                                            | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                                                                                                                                                                         
![Public method]                | [From(String, Type)][26]                                          | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                                                                                                                                                                             
![Public method]                | [From(SqlBuilder, Type)][27]                                      | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                                                                                                                                                                         
![Public method]                | [From&lt;TResult>(String)][28]                                    | Creates and returns a new [SqlSet&lt;TResult>][29] using the provided table name.                                                                                                                                                                                                                                                
![Public method]                | [From&lt;TResult>(SqlBuilder)][30]                                | Creates and returns a new [SqlSet&lt;TResult>][29] using the provided defining query.                                                                                                                                                                                                                                            
![Public method]                | [From&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][31] | Creates and returns a new [SqlSet&lt;TResult>][29] using the provided defining query and mapper.                                                                                                                                                                                                                                 
![Public method]                | [LastInsertId][32]                                                | Gets the identity value of the last inserted record.                                                                                                                                                                                                                                                                             
![Public method]                | [Map(SqlBuilder)][33]                                             | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                                                                                                                                                                                                                              
![Public method]                | [Map(Type, SqlBuilder)][34]                                       | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                                                                                                                                                                      
![Public method]                | [Map&lt;TResult>(SqlBuilder)][35]                                 | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                                                                                                                                                                                                                              
![Public method]                | [Map&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][36]  | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                                                                                                                                                                                                                        
![Public method]                | [QuoteIdentifier][37]                                             | Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier, including properly escaping any embedded quotes in the identifier.                                                                                                                                                 
![Public method]                | [Table(Type)][38]                                                 | Returns the [SqlTable][39] instance for the specified *entityType*.                                                                                                                                                                                                                                                              
![Public method]                | [Table&lt;TEntity>()][40]                                         | Returns the [SqlTable&lt;TEntity>][3] instance for the specified TEntity.                                                                                                                                                                                                                                                        


Properties
----------

                   | Name                | Description                                                 
------------------ | ------------------- | ----------------------------------------------------------- 
![Public property] | [Configuration][41] | Provides access to configuration options for this instance. 
![Public property] | [Connection][18]    | Gets the connection to associate with new commands.         
![Public property] | [Transaction][42]   | Gets or sets a transaction to associate with new commands.  


Remarks
-------
**Database** is the entry point of the [DbExtensions][5] API. Some components such as [SqlSet][1] and [SqlBuilder][2] can be used without **Database**. [SqlTable&lt;TEntity>][3] on the other hand depends on **Database**. These components can greatly simplify data access, but you can still use **Database** by providing commands in [String][43] form. **Database** also serves as a state keeper that can be used to execute multiple commands using the same connection, transaction, configuration, profiling, etc. 

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
[10]: CreateCommand.md
[11]: http://msdn.microsoft.com/en-us/library/bt2afddc
[12]: CreateCommand_1.md
[13]: http://msdn.microsoft.com/en-us/library/b1csw23d
[14]: http://msdn.microsoft.com/en-us/library/btt06a5s
[15]: Dispose.md
[16]: Dispose_1.md
[17]: EnsureConnectionOpen.md
[18]: Connection.md
[19]: http://msdn.microsoft.com/en-us/library/aax125c9
[20]: EnsureInTransaction.md
[21]: EnsureInTransaction_1.md
[22]: Execute_1.md
[23]: Execute.md
[24]: From_2.md
[25]: From.md
[26]: From_3.md
[27]: From_1.md
[28]: From__1_2.md
[29]: ../SqlSet_1/README.md
[30]: From__1.md
[31]: From__1_1.md
[32]: LastInsertId.md
[33]: Map.md
[34]: Map_1.md
[35]: Map__1.md
[36]: Map__1_1.md
[37]: QuoteIdentifier.md
[38]: Table.md
[39]: ../SqlTable/README.md
[40]: Table__1.md
[41]: Configuration.md
[42]: Transaction.md
[43]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Protected method]: ../../_icons/protmethod.gif "Protected method"
[Code example]: ../../_icons/CodeExample.png "Code example"
[Public property]: ../../_icons/pubproperty.gif "Public property"