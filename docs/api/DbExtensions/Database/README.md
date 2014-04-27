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
public class Database : IDisposable, IConnectionContext
```

The **Database** type exposes the following members.


Constructors
------------

Name                                    | Description                                                                                               
--------------------------------------- | --------------------------------------------------------------------------------------------------------- 
[Database()][6]                         | Initializes a new instance of the **Database** class.                                                     
[Database(DbConnection)][7]             | Initializes a new instance of the **Database** class using the provided connection.                       
[Database(MetaModel)][8]                | Initializes a new instance of the **Database** class using the provided meta model.                       
[Database(String)][9]                   | Initializes a new instance of the **Database** class using the provided connection string.                
[Database(DbConnection, MetaModel)][10] | Initializes a new instance of the **Database** class using the provided connection and meta model.        
[Database(String, MetaModel)][11]       | Initializes a new instance of the **Database** class using the provided connection string and meta model. 


Methods
-------

Name                                                              | Description                                                                                                                                                                                                                                                                                                                                                                                                                                        
----------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[Affect(SqlBuilder, Int32)][12]                                   | Executes the *nonQuery* command in a new or existing transaction, and validates the affected records value before comitting.                                                                                                                                                                                                                                                                                                                       
[Affect(SqlBuilder, Int32, AffectedRecordsPolicy)][13]            | Executes the *nonQuery* command in a new or existing transaction, and validates the affected records value before comitting.                                                                                                                                                                                                                                                                                                                       
[AffectOne(String)][14]                                           | Creates and executes a [DbCommand][15] (whose [CommandText][16] property is initialized with the *commandText* parameter) in a new or existing transaction, and validates that the affected records value is equal to one before comitting.                                                                                                                                                                                                        
[AffectOne(SqlBuilder)][17]                                       | Executes the *nonQuery* command in a new or existing transaction, and validates that the affected records value is equal to one before comitting.                                                                                                                                                                                                                                                                                                  
[AffectOne(String, Object[])][18]                                 | Creates and executes a [DbCommand][15] (using the provided *commandText* as a composite format string, as used on [Format(String, Object[])][19], where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][20] collection) in a new or existing transaction, and validates that the affected records value is equal to one before comitting.         
[AffectOneOrNone(String)][21]                                     | Creates and executes a [DbCommand][15] (whose [CommandText][16] property is initialized with the *commandText* parameter) in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting.                                                                                                                                                                                                
[AffectOneOrNone(SqlBuilder)][22]                                 | Executes the *nonQuery* command in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting.                                                                                                                                                                                                                                                                                          
[AffectOneOrNone(String, Object[])][23]                           | Creates and executes a [DbCommand][15] (using the provided *commandText* as a composite format string, as used on [Format(String, Object[])][19], where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][20] collection) in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting. 
[Count][24]                                                       | Gets the number of results the *query* would return.                                                                                                                                                                                                                                                                                                                                                                                               
[CreateCommand(String)][25]                                       | Creates and returns a [DbCommand][15] object using the specified *commandText*.                                                                                                                                                                                                                                                                                                                                                                    
[CreateCommand(SqlBuilder)][26]                                   | Creates and returns a [DbCommand][15] object from the specified *sqlBuilder*.                                                                                                                                                                                                                                                                                                                                                                      
[CreateCommand(String, Object[])][27]                             | Creates and returns a [DbCommand][15] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][19]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][20] collection.                                                                                                                     
[CreateConnection()][28]                                          | Creates a connection using the default connection name specified by the "DbExtensions:DefaultConnectionName" key in the appSettings configuration section, which is used to locate a connection string in the connectionStrings configuration section.                                                                                                                                                                                             
[CreateConnection(String)][29]                                    | Creates a connection using the provided connection string. If the connection string is a named connection string (e.g. "name=Northwind"), then the name is used to locate the connection string in the connectionStrings configuration section, else the default provider is used to create the connection (specified by the "DbExtensions:DefaultProviderName" key in the appSettings configuration section).                                     
[Dispose()][30]                                                   | Releases all resources used by the current instance of the **Database** class.                                                                                                                                                                                                                                                                                                                                                                     
[Dispose(Boolean)][31]                                            | Releases the resources used by this **Database** instance.                                                                                                                                                                                                                                                                                                                                                                                         
[EnsureConnectionOpen][32]                                        | Opens [Connection][33] (if it's not open) and returns an [IDisposable][34] object you can use to close it (if it wasn't open).                                                                                                                                                                                                                                                                                                                     
[EnsureInTransaction()][35]                                       | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                                                                                                                                        
[EnsureInTransaction(IsolationLevel)][36]                         | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                                                                                                                                        
[Equals][37]                                                      | Returns whether the specified object is equal to the current object. (Overrides [Object.Equals(Object)][38].)                                                                                                                                                                                                                                                                                                                                      
[Execute(String)][39]                                             | Creates and executes a [DbCommand][15] whose [CommandText][16] property is initialized with the *commandText* parameter.                                                                                                                                                                                                                                                                                                                           
[Execute(SqlBuilder)][40]                                         | Executes the *nonQuery* command.                                                                                                                                                                                                                                                                                                                                                                                                                   
[Execute(String, Object[])][41]                                   | Creates and executes a [DbCommand][15] using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][19]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][20] collection.                                                                                                                           
[Exists][42]                                                      | Checks if *query* would return at least one row.                                                                                                                                                                                                                                                                                                                                                                                                   
[From(String)][43]                                                | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                                                                                                                                                                                                                                                                                               
[From(SqlBuilder)][44]                                            | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                                                                                                                                                                                                                                                                                           
[From(String, Type)][45]                                          | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                                                                                                                                                                                                                                                                                               
[From(SqlBuilder, Type)][46]                                      | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                                                                                                                                                                                                                                                                                           
[From&lt;TResult>(String)][47]                                    | Creates and returns a new [SqlSet&lt;TResult>][48] using the provided table name.                                                                                                                                                                                                                                                                                                                                                                  
[From&lt;TResult>(SqlBuilder)][49]                                | Creates and returns a new [SqlSet&lt;TResult>][48] using the provided defining query.                                                                                                                                                                                                                                                                                                                                                              
[From&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][50] | Creates and returns a new [SqlSet&lt;TResult>][48] using the provided defining query and mapper.                                                                                                                                                                                                                                                                                                                                                   
[GetHashCode][51]                                                 | Returns the hash function for the current object. (Overrides [Object.GetHashCode()][52].)                                                                                                                                                                                                                                                                                                                                                          
[GetProviderFactory][53]                                          | Locates a [DbProviderFactory][54] using [GetFactory(String)][55] and caches the result.                                                                                                                                                                                                                                                                                                                                                            
[GetType][56]                                                     | Gets the type for the current object.                                                                                                                                                                                                                                                                                                                                                                                                              
[LastInsertId][57]                                                | Gets the identity value of the last inserted record.                                                                                                                                                                                                                                                                                                                                                                                               
[LongCount][58]                                                   | Gets the number of results the *query* would return.                                                                                                                                                                                                                                                                                                                                                                                               
[Map(SqlBuilder)][59]                                             | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                                                                                                                                                                                                                                                                                                                                                
[Map(Type, SqlBuilder)][60]                                       | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                                                                                                                                                                                                                                                                                        
[Map&lt;TResult>(SqlBuilder)][61]                                 | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                                                                                                                                                                                                                                                                                                                                                
[Map&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][62]  | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                                                                                                                                                                                                                                                                                                                                          
[QuoteIdentifier][63]                                             | Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier, including properly escaping any embedded quotes in the identifier.                                                                                                                                                                                                                                                                   
[Table(MetaType)][64]                                             | Returns the [SqlTable][65] instance for the specified *metaType*.                                                                                                                                                                                                                                                                                                                                                                                  
[Table(Type)][66]                                                 | Returns the [SqlTable][65] instance for the specified *entityType*.                                                                                                                                                                                                                                                                                                                                                                                
[Table&lt;TEntity>()][67]                                         | Returns the [SqlTable&lt;TEntity>][3] instance for the specified TEntity.                                                                                                                                                                                                                                                                                                                                                                          
[ToString][68]                                                    | Returns a string representation of the object. (Overrides [Object.ToString()][69].)                                                                                                                                                                                                                                                                                                                                                                


Properties
----------

Name                | Description                                                            
------------------- | ---------------------------------------------------------------------- 
[Configuration][70] | Provides access to configuration options for this instance.            
[Connection][33]    | Gets the connection to associate with new commands.                    
[Transaction][71]   | Gets or sets a [DbTransaction][72] to associate with all new commands. 


Remarks
-------
**Database** is the entry point of the [DbExtensions][5] API. Some components such as [SqlSet][1] and [SqlBuilder][2] can be used without **Database**. [SqlTable&lt;TEntity>][3] on the other hand depends on **Database**. These components can greatly simplify data access, but you can still use **Database** by providing commands in [String][73] form. **Database** also serves as a state keeper that can be used to execute multiple commands using the same connection, transaction, configuration, profiling, etc. 

See Also
--------
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
[37]: Equals.md
[38]: http://msdn.microsoft.com/en-us/library/bsc2ak47
[39]: Execute_1.md
[40]: Execute.md
[41]: Execute_2.md
[42]: Exists.md
[43]: From_2.md
[44]: From.md
[45]: From_3.md
[46]: From_1.md
[47]: From__1_2.md
[48]: ../SqlSet_1/README.md
[49]: From__1.md
[50]: From__1_1.md
[51]: GetHashCode.md
[52]: http://msdn.microsoft.com/en-us/library/zdee4b3y
[53]: GetProviderFactory.md
[54]: http://msdn.microsoft.com/en-us/library/c6c4a26c
[55]: http://msdn.microsoft.com/en-us/library/h508h681
[56]: GetType.md
[57]: LastInsertId.md
[58]: LongCount.md
[59]: Map.md
[60]: Map_1.md
[61]: Map__1.md
[62]: Map__1_1.md
[63]: QuoteIdentifier.md
[64]: Table.md
[65]: ../SqlTable/README.md
[66]: Table_1.md
[67]: Table__1.md
[68]: ToString.md
[69]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[70]: Configuration.md
[71]: Transaction.md
[72]: http://msdn.microsoft.com/en-us/library/xtczstkw
[73]: http://msdn.microsoft.com/en-us/library/s1wwdcbf