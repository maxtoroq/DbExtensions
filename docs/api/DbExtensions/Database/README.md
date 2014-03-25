Database Class
==============
Creates and executes CRUD (Create, Read, Update, Delete) commands for entities mapped using the [System.Data.Linq.Mapping][1] API.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **DbExtensions.Database**  

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public class Database : IDisposable, IConnectionContext
```

The **Database** type exposes the following members.


Constructors
------------

Name                                   | Description                                                                                               
-------------------------------------- | --------------------------------------------------------------------------------------------------------- 
[Database()][4]                        | Initializes a new instance of the **Database** class.                                                     
[Database(DbConnection)][5]            | Initializes a new instance of the **Database** class using the provided connection.                       
[Database(MetaModel)][6]               | Initializes a new instance of the **Database** class using the provided meta model.                       
[Database(String)][7]                  | Initializes a new instance of the **Database** class using the provided connection string.                
[Database(DbConnection, MetaModel)][8] | Initializes a new instance of the **Database** class using the provided connection and meta model.        
[Database(String, MetaModel)][9]       | Initializes a new instance of the **Database** class using the provided connection string and meta model. 


Methods
-------

Name                                                              | Description                                                                                                                                                                                                                                                                                                                                                                                                                                        
----------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[Affect(SqlBuilder, Int32)][10]                                   | Executes the *nonQuery* command in a new or existing transaction, and validates the affected records value before comitting.                                                                                                                                                                                                                                                                                                                       
[Affect(SqlBuilder, Int32, AffectedRecordsPolicy)][11]            | Executes the *nonQuery* command in a new or existing transaction, and validates the affected records value before comitting.                                                                                                                                                                                                                                                                                                                       
[AffectOne(String)][12]                                           | Creates and executes a [DbCommand][13] (whose [CommandText][14] property is initialized with the *commandText* parameter) in a new or existing transaction, and validates that the affected records value is equal to one before comitting.                                                                                                                                                                                                        
[AffectOne(SqlBuilder)][15]                                       | Executes the *nonQuery* command in a new or existing transaction, and validates that the affected records value is equal to one before comitting.                                                                                                                                                                                                                                                                                                  
[AffectOne(String, Object[])][16]                                 | Creates and executes a [DbCommand][13] (using the provided *commandText* as a composite format string, as used on [Format(String, Object[])][17], where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][18] collection) in a new or existing transaction, and validates that the affected records value is equal to one before comitting.         
[AffectOneOrNone(String)][19]                                     | Creates and executes a [DbCommand][13] (whose [CommandText][14] property is initialized with the *commandText* parameter) in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting.                                                                                                                                                                                                
[AffectOneOrNone(SqlBuilder)][20]                                 | Executes the *nonQuery* command in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting.                                                                                                                                                                                                                                                                                          
[AffectOneOrNone(String, Object[])][21]                           | Creates and executes a [DbCommand][13] (using the provided *commandText* as a composite format string, as used on [Format(String, Object[])][17], where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][18] collection) in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting. 
[Count][22]                                                       | Gets the number of results the *query* would return.                                                                                                                                                                                                                                                                                                                                                                                               
[CreateCommand(String)][23]                                       | Creates and returns a [DbCommand][13] object using the specified *commandText*.                                                                                                                                                                                                                                                                                                                                                                    
[CreateCommand(SqlBuilder)][24]                                   | Creates and returns a [DbCommand][13] object from the specified *sqlBuilder*.                                                                                                                                                                                                                                                                                                                                                                      
[CreateCommand(String, Object[])][25]                             | Creates and returns a [DbCommand][13] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][17]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][18] collection.                                                                                                                     
[CreateConnection()][26]                                          | Creates a connection using the default connection name specified by the "DbExtensions:DefaultConnectionName" key in the appSettings configuration section, which is used to locate a connection string in the connectionStrings configuration section.                                                                                                                                                                                             
[CreateConnection(String)][27]                                    | Creates a connection using the provided connection string. If the connection string is a named connection string (e.g. "name=Northwind"), then the name is used to locate the connection string in the connectionStrings configuration section, else the default provider is used to create the connection (specified by the "DbExtensions:DefaultProviderName" key in the appSettings configuration section).                                     
[Dispose()][28]                                                   | Releases all resources used by the current instance of the **Database** class.                                                                                                                                                                                                                                                                                                                                                                     
[Dispose(Boolean)][29]                                            | Releases the resources used by this **Database** instance.                                                                                                                                                                                                                                                                                                                                                                                         
[EnsureConnectionOpen][30]                                        | Opens [Connection][31] (if it's not open) and returns an [IDisposable][32] object you can use to close it (if it wasn't open).                                                                                                                                                                                                                                                                                                                     
[EnsureInTransaction()][33]                                       | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                                                                                                                                        
[EnsureInTransaction(IsolationLevel)][34]                         | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                                                                                                                                                                                                                                                                                        
[Equals][35]                                                      | Returns whether the specified object is equal to the current object. (Overrides [Object.Equals(Object)][36].)                                                                                                                                                                                                                                                                                                                                      
[Execute(String)][37]                                             | Creates and executes a [DbCommand][13] whose [CommandText][14] property is initialized with the *commandText* parameter.                                                                                                                                                                                                                                                                                                                           
[Execute(SqlBuilder)][38]                                         | Executes the *nonQuery* command.                                                                                                                                                                                                                                                                                                                                                                                                                   
[Execute(String, Object[])][39]                                   | Creates and executes a [DbCommand][13] using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][17]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][18] collection.                                                                                                                           
[Exists][40]                                                      | Checks if *query* would return at least one row.                                                                                                                                                                                                                                                                                                                                                                                                   
[From(String)][41]                                                | Creates and returns a new [SqlSet][42] using the provided table name.                                                                                                                                                                                                                                                                                                                                                                              
[From(SqlBuilder)][43]                                            | Creates and returns a new [SqlSet][42] using the provided defining query.                                                                                                                                                                                                                                                                                                                                                                          
[From(String, Type)][44]                                          | Creates and returns a new [SqlSet][42] using the provided table name.                                                                                                                                                                                                                                                                                                                                                                              
[From(SqlBuilder, Type)][45]                                      | Creates and returns a new [SqlSet][42] using the provided defining query.                                                                                                                                                                                                                                                                                                                                                                          
[From&lt;TResult>(String)][46]                                    | Creates and returns a new [SqlSet&lt;TResult>][47] using the provided table name.                                                                                                                                                                                                                                                                                                                                                                  
[From&lt;TResult>(SqlBuilder)][48]                                | Creates and returns a new [SqlSet&lt;TResult>][47] using the provided defining query.                                                                                                                                                                                                                                                                                                                                                              
[From&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][49] | Creates and returns a new [SqlSet&lt;TResult>][47] using the provided defining query and mapper.                                                                                                                                                                                                                                                                                                                                                   
[GetHashCode][50]                                                 | Returns the hash function for the current object. (Overrides [Object.GetHashCode()][51].)                                                                                                                                                                                                                                                                                                                                                          
[GetProviderFactory][52]                                          | Locates a [DbProviderFactory][53] using [GetFactory(String)][54] and caches the result.                                                                                                                                                                                                                                                                                                                                                            
[GetType][55]                                                     | Gets the type for the current object.                                                                                                                                                                                                                                                                                                                                                                                                              
[InsertRange(IEnumerable&lt;Object>)][56]                         | **Obsolete.** Executes INSERT commands for the specified *entities*.                                                                                                                                                                                                                                                                                                                                                                               
[InsertRange(Object[])][57]                                       | **Obsolete.** Executes INSERT commands for the specified *entities*.                                                                                                                                                                                                                                                                                                                                                                               
[LastInsertId][58]                                                | Gets the identity value of the last inserted record.                                                                                                                                                                                                                                                                                                                                                                                               
[LongCount][59]                                                   | Gets the number of results the *query* would return.                                                                                                                                                                                                                                                                                                                                                                                               
[Map(SqlBuilder)][60]                                             | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                                                                                                                                                                                                                                                                                                                                                
[Map(Type, SqlBuilder)][61]                                       | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                                                                                                                                                                                                                                                                                        
[Map&lt;TResult>(SqlBuilder)][62]                                 | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                                                                                                                                                                                                                                                                                                                                                
[Map&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][63]  | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                                                                                                                                                                                                                                                                                                                                          
[MapXml(SqlBuilder)][64]                                          | Maps the results of the *query* to XML. The query is deferred-executed.                                                                                                                                                                                                                                                                                                                                                                            
[MapXml(SqlBuilder, XmlMappingSettings)][65]                      | Maps the results of the *query* to XML. The query is deferred-executed.                                                                                                                                                                                                                                                                                                                                                                            
[QuoteIdentifier][66]                                             | Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier, including properly escaping any embedded quotes in the identifier.                                                                                                                                                                                                                                                                   
[Set(SqlBuilder)][67]                                             | **Obsolete.** Creates and returns a new [SqlSet][42] using the provided defining query.                                                                                                                                                                                                                                                                                                                                                            
[Set&lt;TResult>(SqlBuilder)][68]                                 | **Obsolete.** Creates and returns a new [SqlSet&lt;TResult>][47] using the provided defining query.                                                                                                                                                                                                                                                                                                                                                
[Set&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][69]  | **Obsolete.** Creates and returns a new [SqlSet&lt;TResult>][47] using the provided defining query and mapper.                                                                                                                                                                                                                                                                                                                                     
[Table(MetaType)][70]                                             | Returns the [SqlTable][71] instance for the specified *metaType*.                                                                                                                                                                                                                                                                                                                                                                                  
[Table(Type)][72]                                                 | Returns the [SqlTable][71] instance for the specified *entityType*.                                                                                                                                                                                                                                                                                                                                                                                
[Table&lt;TEntity>()][73]                                         | Returns the [SqlTable&lt;TEntity>][74] instance for the specified TEntity.                                                                                                                                                                                                                                                                                                                                                                         
[ToString][75]                                                    | Returns a string representation of the object. (Overrides [Object.ToString()][76].)                                                                                                                                                                                                                                                                                                                                                                


Properties
----------

Name                | Description                                                            
------------------- | ---------------------------------------------------------------------- 
[Configuration][77] | Provides access to configuration options for this instance.            
[Connection][31]    | Gets the connection to associate with new commands.                    
[Transaction][78]   | Gets or sets a [DbTransaction][79] to associate with all new commands. 


See Also
--------
[DbExtensions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/bb515105
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: _ctor_1.md
[6]: _ctor_3.md
[7]: _ctor_4.md
[8]: _ctor_2.md
[9]: _ctor_5.md
[10]: Affect.md
[11]: Affect_1.md
[12]: AffectOne_1.md
[13]: http://msdn.microsoft.com/en-us/library/852d01k6
[14]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[15]: AffectOne.md
[16]: AffectOne_2.md
[17]: http://msdn.microsoft.com/en-us/library/b1csw23d
[18]: http://msdn.microsoft.com/en-us/library/9czdkzd1
[19]: AffectOneOrNone_1.md
[20]: AffectOneOrNone.md
[21]: AffectOneOrNone_2.md
[22]: Count.md
[23]: CreateCommand_1.md
[24]: CreateCommand.md
[25]: CreateCommand_2.md
[26]: CreateConnection.md
[27]: CreateConnection_1.md
[28]: Dispose.md
[29]: Dispose_1.md
[30]: EnsureConnectionOpen.md
[31]: Connection.md
[32]: http://msdn.microsoft.com/en-us/library/aax125c9
[33]: EnsureInTransaction.md
[34]: EnsureInTransaction_1.md
[35]: Equals.md
[36]: http://msdn.microsoft.com/en-us/library/bsc2ak47
[37]: Execute_1.md
[38]: Execute.md
[39]: Execute_2.md
[40]: Exists.md
[41]: From_2.md
[42]: ../SqlSet/README.md
[43]: From.md
[44]: From_3.md
[45]: From_1.md
[46]: From__1_2.md
[47]: ../SqlSet_1/README.md
[48]: From__1.md
[49]: From__1_1.md
[50]: GetHashCode.md
[51]: http://msdn.microsoft.com/en-us/library/zdee4b3y
[52]: GetProviderFactory.md
[53]: http://msdn.microsoft.com/en-us/library/c6c4a26c
[54]: http://msdn.microsoft.com/en-us/library/h508h681
[55]: GetType.md
[56]: InsertRange.md
[57]: InsertRange_1.md
[58]: LastInsertId.md
[59]: LongCount.md
[60]: Map.md
[61]: Map_1.md
[62]: Map__1.md
[63]: Map__1_1.md
[64]: MapXml.md
[65]: MapXml_1.md
[66]: QuoteIdentifier.md
[67]: Set.md
[68]: Set__1.md
[69]: Set__1_1.md
[70]: Table.md
[71]: ../SqlTable/README.md
[72]: Table_1.md
[73]: Table__1.md
[74]: ../SqlTable_1/README.md
[75]: ToString.md
[76]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[77]: Configuration.md
[78]: Transaction.md
[79]: http://msdn.microsoft.com/en-us/library/xtczstkw