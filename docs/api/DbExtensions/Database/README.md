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
public class Database : IDisposable, IConnectionContext
```

The **Database** type exposes the following members.


Constructors
------------

                 | Name                                    | Description                                                                                               
---------------- | --------------------------------------- | --------------------------------------------------------------------------------------------------------- 
![Public method] | [Database()][6]                         | Initializes a new instance of the **Database** class.                                                     
![Public method] | [Database(DbConnection)][7]             | Initializes a new instance of the **Database** class using the provided connection.                       
![Public method] | [Database(MetaModel)][8]                | Initializes a new instance of the **Database** class using the provided meta model.                       
![Public method] | [Database(String)][9]                   | Initializes a new instance of the **Database** class using the provided connection string.                
![Public method] | [Database(DbConnection, MetaModel)][10] | Initializes a new instance of the **Database** class using the provided connection and meta model.        
![Public method] | [Database(String, MetaModel)][11]       | Initializes a new instance of the **Database** class using the provided connection string and meta model. 


Methods
-------

                                 | Name                                                              | Description                                                                                                                                                                                                                                                                                                                                                                                                                                        
-------------------------------- | ----------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method]                 | [Affect(SqlBuilder, Int32)][12]                                   | Executes the *nonQuery* command in a new or existing transaction, and validates the affected records value before comitting.                                                                                                                                                                                                                                                                                                                       
![Public method]                 | [Affect(SqlBuilder, Int32, AffectedRecordsPolicy)][13]            | Executes the *nonQuery* command in a new or existing transaction, and validates the affected records value before comitting.                                                                                                                                                                                                                                                                                                                       
![Public method]                 | [AffectOne(String)][14]                                           | Creates and executes a [DbCommand][15] (whose [CommandText][16] property is initialized with the *commandText* parameter) in a new or existing transaction, and validates that the affected records value is equal to one before comitting.                                                                                                                                                                                                        
![Public method]                 | [AffectOne(SqlBuilder)][17]                                       | Executes the *nonQuery* command in a new or existing transaction, and validates that the affected records value is equal to one before comitting.                                                                                                                                                                                                                                                                                                  
![Public method]                 | [AffectOne(String, Object[])][18]                                 | Creates and executes a [DbCommand][15] (using the provided *commandText* as a composite format string, as used on [Format(String, Object[])][19], where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][20] collection) in a new or existing transaction, and validates that the affected records value is equal to one before comitting.         
![Public method]                 | [AffectOneOrNone(String)][21]                                     | Creates and executes a [DbCommand][15] (whose [CommandText][16] property is initialized with the *commandText* parameter) in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting.                                                                                                                                                                                                
![Public method]                 | [AffectOneOrNone(SqlBuilder)][22]                                 | Executes the *nonQuery* command in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting.                                                                                                                                                                                                                                                                                          
![Public method]                 | [AffectOneOrNone(String, Object[])][23]                           | Creates and executes a [DbCommand][15] (using the provided *commandText* as a composite format string, as used on [Format(String, Object[])][19], where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][20] collection) in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting. 
![Public method]                 | [Count][24]                                                       | Gets the number of results the *query* would return.                                                                                                                                                                                                                                                                                                                                                                                               
![Public method]                 | [CreateCommand(String)][25]                                       | Creates and returns a [DbCommand][15] object whose [CommandText][16] property is initialized with the *commandText* parameter.                                                                                                                                                                                                                                                                                                                     
![Public method]                 | [CreateCommand(SqlBuilder)][26]                                   | Creates and returns a [DbCommand][15] object from the specified *sqlBuilder*.                                                                                                                                                                                                                                                                                                                                                                      
![Public method]                 | [CreateCommand(String, Object[])][27]                             | Creates and returns a [DbCommand][15] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][19]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][20] collection.                                                                                                                     
![Public method]![Static member] | [CreateConnection()][28]                                          | Creates a connection using the default connection name specified by the "DbExtensions:DefaultConnectionName" key in the appSettings configuration section, which is used to locate a connection string in the connectionStrings configuration section.                                                                                                                                                                                             
![Public method]![Static member] | [CreateConnection(String)][29]                                    | Creates a connection using the provided connection string. If the connection string is a named connection string (e.g. "name=Northwind"), then the name is used to locate the connection string in the connectionStrings configuration section, else the default provider is used to create the connection (specified by the "DbExtensions:DefaultProviderName" key in the appSettings configuration section).                                     
![Public method]                 | [Dispose()][30]                                                   | Releases all resources used by the current instance of the **Database** class.                                                                                                                                                                                                                                                                                                                                                                     
![Protected method]              | [Dispose(Boolean)][31]                                            | Releases the resources used by this **Database** instance.                                                                                                                                                                                                                                                                                                                                                                                         
![Public method]![Code example]  | [EnsureConnectionOpen][32]                                        | Opens [Connection][33] (if it's not open) and returns an [IDisposable][34] object you can use to close it (if it wasn't open).                                                                                                                                                                                                                                                                                                                     
![Public method]                 | [EnsureInTransaction()][35]                                       | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                                                                                                                                        
![Public method]                 | [EnsureInTransaction(IsolationLevel)][36]                         | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                                                                                                                                        
![Public method]                 | [Execute(String)][37]                                             | Creates and executes a [DbCommand][15] whose [CommandText][16] property is initialized with the *commandText* parameter.                                                                                                                                                                                                                                                                                                                           
![Public method]                 | [Execute(SqlBuilder)][38]                                         | Executes the *nonQuery* command.                                                                                                                                                                                                                                                                                                                                                                                                                   
![Public method]                 | [Execute(String, Object[])][39]                                   | Creates and executes a [DbCommand][15] using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][19]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][20] collection.                                                                                                                           
![Public method]                 | [Exists][40]                                                      | Checks if *query* would return at least one row.                                                                                                                                                                                                                                                                                                                                                                                                   
![Public method]                 | [From(String)][41]                                                | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                                                                                                                                                                                                                                                                                               
![Public method]                 | [From(SqlBuilder)][42]                                            | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                                                                                                                                                                                                                                                                                           
![Public method]                 | [From(String, Type)][43]                                          | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                                                                                                                                                                                                                                                                                               
![Public method]                 | [From(SqlBuilder, Type)][44]                                      | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                                                                                                                                                                                                                                                                                           
![Public method]                 | [From&lt;TResult>(String)][45]                                    | Creates and returns a new [SqlSet&lt;TResult>][46] using the provided table name.                                                                                                                                                                                                                                                                                                                                                                  
![Public method]                 | [From&lt;TResult>(SqlBuilder)][47]                                | Creates and returns a new [SqlSet&lt;TResult>][46] using the provided defining query.                                                                                                                                                                                                                                                                                                                                                              
![Public method]                 | [From&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][48] | Creates and returns a new [SqlSet&lt;TResult>][46] using the provided defining query and mapper.                                                                                                                                                                                                                                                                                                                                                   
![Public method]![Static member] | [GetProviderFactory][49]                                          | Locates a [DbProviderFactory][50] using [GetFactory(String)][51] and caches the result.                                                                                                                                                                                                                                                                                                                                                            
![Public method]                 | [LastInsertId][52]                                                | Gets the identity value of the last inserted record.                                                                                                                                                                                                                                                                                                                                                                                               
![Public method]                 | [LongCount][53]                                                   | Gets the number of results the *query* would return.                                                                                                                                                                                                                                                                                                                                                                                               
![Public method]                 | [Map(SqlBuilder)][54]                                             | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                                                                                                                                                                                                                                                                                                                                                
![Public method]                 | [Map(Type, SqlBuilder)][55]                                       | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                                                                                                                                                                                                                                                                                        
![Public method]                 | [Map&lt;TResult>(SqlBuilder)][56]                                 | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                                                                                                                                                                                                                                                                                                                                                
![Public method]                 | [Map&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][57]  | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                                                                                                                                                                                                                                                                                                                                          
![Public method]                 | [QuoteIdentifier][58]                                             | Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier, including properly escaping any embedded quotes in the identifier.                                                                                                                                                                                                                                                                   
![Protected method]              | [Table(MetaType)][59]                                             | Returns the [SqlTable][60] instance for the specified *metaType*.                                                                                                                                                                                                                                                                                                                                                                                  
![Public method]                 | [Table(Type)][61]                                                 | Returns the [SqlTable][60] instance for the specified *entityType*.                                                                                                                                                                                                                                                                                                                                                                                
![Public method]                 | [Table&lt;TEntity>()][62]                                         | Returns the [SqlTable&lt;TEntity>][3] instance for the specified TEntity.                                                                                                                                                                                                                                                                                                                                                                          


Properties
----------

                   | Name                | Description                                                            
------------------ | ------------------- | ---------------------------------------------------------------------- 
![Public property] | [Configuration][63] | Provides access to configuration options for this instance.            
![Public property] | [Connection][33]    | Gets the connection to associate with new commands.                    
![Public property] | [Transaction][64]   | Gets or sets a [DbTransaction][65] to associate with all new commands. 


Remarks
-------
**Database** is the entry point of the [DbExtensions][5] API. Some components such as [SqlSet][1] and [SqlBuilder][2] can be used without **Database**. [SqlTable&lt;TEntity>][3] on the other hand depends on **Database**. These components can greatly simplify data access, but you can still use **Database** by providing commands in [String][66] form. **Database** also serves as a state keeper that can be used to execute multiple commands using the same connection, transaction, configuration, profiling, etc. 

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
[12]: Affect.md
[13]: Affect_1.md
[14]: AffectOne_1.md
[15]: http://msdn.microsoft.com/en-us/library/852d01k6
[16]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[17]: AffectOne.md
[18]: AffectOne_2.md
[19]: http://msdn.microsoft.com/en-us/library/b1csw23d
[20]: http://msdn.microsoft.com/en-us/library/9czdkzd1
[21]: AffectOneOrNone_1.md
[22]: AffectOneOrNone.md
[23]: AffectOneOrNone_2.md
[24]: Count.md
[25]: CreateCommand_1.md
[26]: CreateCommand.md
[27]: CreateCommand_2.md
[28]: CreateConnection.md
[29]: CreateConnection_1.md
[30]: Dispose.md
[31]: Dispose_1.md
[32]: EnsureConnectionOpen.md
[33]: Connection.md
[34]: http://msdn.microsoft.com/en-us/library/aax125c9
[35]: EnsureInTransaction.md
[36]: EnsureInTransaction_1.md
[37]: Execute_1.md
[38]: Execute.md
[39]: Execute_2.md
[40]: Exists.md
[41]: From_2.md
[42]: From.md
[43]: From_3.md
[44]: From_1.md
[45]: From__1_2.md
[46]: ../SqlSet_1/README.md
[47]: From__1.md
[48]: From__1_1.md
[49]: GetProviderFactory.md
[50]: http://msdn.microsoft.com/en-us/library/c6c4a26c
[51]: http://msdn.microsoft.com/en-us/library/h508h681
[52]: LastInsertId.md
[53]: LongCount.md
[54]: Map.md
[55]: Map_1.md
[56]: Map__1.md
[57]: Map__1_1.md
[58]: QuoteIdentifier.md
[59]: Table.md
[60]: ../SqlTable/README.md
[61]: Table_1.md
[62]: Table__1.md
[63]: Configuration.md
[64]: Transaction.md
[65]: http://msdn.microsoft.com/en-us/library/xtczstkw
[66]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Static member]: ../../_icons/static.gif "Static member"
[Protected method]: ../../_icons/protmethod.gif "Protected method"
[Code example]: ../../_icons/CodeExample.png "Code example"
[Public property]: ../../_icons/pubproperty.gif "Public property"