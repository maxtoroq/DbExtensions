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

                 | Name                                      | Description                                                                                                                          
---------------- | ----------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ 
![Public method] | [Database()][6]                           | Initializes a new instance of the **Database** class.                                                                                
![Public method] | [Database(IDbConnection)][7]              | Initializes a new instance of the **Database** class using the provided connection.                                                  
![Public method] | [Database(MetaModel)][8]                  | Initializes a new instance of the **Database** class using the provided meta model.                                                  
![Public method] | [Database(String)][9]                     | Initializes a new instance of the **Database** class using the provided connection string.                                           
![Public method] | [Database(IDbConnection, MetaModel)][10]  | Initializes a new instance of the **Database** class using the provided connection and meta model.                                   
![Public method] | [Database(String, MetaModel)][11]         | Initializes a new instance of the **Database** class using the provided connection string and meta model.                            
![Public method] | [Database(String, String)][12]            | Initializes a new instance of the **Database** class using the provided connection string and provider's invariant name.             
![Public method] | [Database(String, String, MetaModel)][13] | Initializes a new instance of the **Database** class using the provided connection string, provider's invariant name and meta model. 


Methods
-------

                                | Name                                                              | Description                                                                                                                                                                                                                                                                                                                      
------------------------------- | ----------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method]                | [CreateCommand(SqlBuilder)][14]                                   | Creates and returns an [IDbCommand][15] object from the specified *sqlBuilder*.                                                                                                                                                                                                                                                  
![Public method]                | [CreateCommand(String, Object[])][16]                             | Creates and returns an [IDbCommand][15] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][17]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][18] collection. 
![Public method]                | [Dispose()][19]                                                   | Releases all resources used by the current instance of the **Database** class.                                                                                                                                                                                                                                                   
![Protected method]             | [Dispose(Boolean)][20]                                            | Releases the resources used by this **Database** instance.                                                                                                                                                                                                                                                                       
![Public method]![Code example] | [EnsureConnectionOpen][21]                                        | Opens [Connection][22] (if it's not open) and returns an [IDisposable][23] object you can use to close it (if it wasn't open).                                                                                                                                                                                                   
![Public method]                | [EnsureInTransaction()][24]                                       | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                      
![Public method]                | [EnsureInTransaction(IsolationLevel)][25]                         | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                      
![Public method]                | [Execute(String, Object[])][26]                                   | Creates and executes an [IDbCommand][15] using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][17]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][18] collection.       
![Public method]                | [Execute(SqlBuilder, Int32, Boolean)][27]                         | Executes the *nonQuery* command. Optionally uses a transaction scope and validates affected records value before completing.                                                                                                                                                                                                     
![Public method]                | [From(String)][28]                                                | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                                                                                                                                                                             
![Public method]                | [From(SqlBuilder)][29]                                            | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                                                                                                                                                                         
![Public method]                | [From(String, Type)][30]                                          | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                                                                                                                                                                             
![Public method]                | [From(SqlBuilder, Type)][31]                                      | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                                                                                                                                                                         
![Public method]                | [From&lt;TResult>(String)][32]                                    | Creates and returns a new [SqlSet&lt;TResult>][33] using the provided table name.                                                                                                                                                                                                                                                
![Public method]                | [From&lt;TResult>(SqlBuilder)][34]                                | Creates and returns a new [SqlSet&lt;TResult>][33] using the provided defining query.                                                                                                                                                                                                                                            
![Public method]                | [From&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][35] | Creates and returns a new [SqlSet&lt;TResult>][33] using the provided defining query and mapper.                                                                                                                                                                                                                                 
![Public method]                | [LastInsertId][36]                                                | Gets the identity value of the last inserted record.                                                                                                                                                                                                                                                                             
![Public method]                | [Map(SqlBuilder)][37]                                             | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                                                                                                                                                                                                                              
![Public method]                | [Map(Type, SqlBuilder)][38]                                       | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                                                                                                                                                                      
![Public method]                | [Map&lt;TResult>(SqlBuilder)][39]                                 | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                                                                                                                                                                                                                              
![Public method]                | [Map&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][40]  | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                                                                                                                                                                                                                        
![Public method]                | [QuoteIdentifier][41]                                             | Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier, including properly escaping any embedded quotes in the identifier.                                                                                                                                                 
![Protected method]             | [Table(MetaType)][42]                                             | Returns the [SqlTable][43] instance for the specified *metaType*.                                                                                                                                                                                                                                                                
![Public method]                | [Table(Type)][44]                                                 | Returns the [SqlTable][43] instance for the specified *entityType*.                                                                                                                                                                                                                                                              
![Public method]                | [Table&lt;TEntity>()][45]                                         | Returns the [SqlTable&lt;TEntity>][3] instance for the specified TEntity.                                                                                                                                                                                                                                                        


Properties
----------

                   | Name                | Description                                                 
------------------ | ------------------- | ----------------------------------------------------------- 
![Public property] | [Configuration][46] | Provides access to configuration options for this instance. 
![Public property] | [Connection][22]    | Gets the connection to associate with new commands.         
![Public property] | [Transaction][47]   | Gets or sets a transaction to associate with new commands.  


Remarks
-------
**Database** is the entry point of the [DbExtensions][5] API. Some components such as [SqlSet][1] and [SqlBuilder][2] can be used without **Database**. [SqlTable&lt;TEntity>][3] on the other hand depends on **Database**. These components can greatly simplify data access, but you can still use **Database** by providing commands in [String][48] form. **Database** also serves as a state keeper that can be used to execute multiple commands using the same connection, transaction, configuration, profiling, etc. 

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
[8]: _ctor_3.md
[9]: _ctor_4.md
[10]: _ctor_2.md
[11]: _ctor_5.md
[12]: _ctor_6.md
[13]: _ctor_7.md
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
[28]: From_2.md
[29]: From.md
[30]: From_3.md
[31]: From_1.md
[32]: From__1_2.md
[33]: ../SqlSet_1/README.md
[34]: From__1.md
[35]: From__1_1.md
[36]: LastInsertId.md
[37]: Map.md
[38]: Map_1.md
[39]: Map__1.md
[40]: Map__1_1.md
[41]: QuoteIdentifier.md
[42]: Table.md
[43]: ../SqlTable/README.md
[44]: Table_1.md
[45]: Table__1.md
[46]: Configuration.md
[47]: Transaction.md
[48]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Protected method]: ../../_icons/protmethod.gif "Protected method"
[Code example]: ../../_icons/CodeExample.png "Code example"
[Public property]: ../../_icons/pubproperty.gif "Public property"