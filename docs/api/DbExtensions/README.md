DbExtensions Namespace
======================
Extensions methods for ADO.NET, CRUD and dynamic SQL components.


Classes
-------

Class                           | Description                                                                                                                                                                                                     
------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[Database][1]                   | Creates and executes CRUD (Create, Read, Update, Delete) commands for entities mapped using the [System.Data.Linq.Mapping][2] API.                                                                              
[DatabaseConfiguration][3]      | Holds configuration options that customize the behavior of [Database][1].                                                                                                                                       
[DbFactory][4]                  | Provides a set of static (Shared in Visual Basic) methods for the creation and location of common ADO.NET objects.                                                                                              
[Extensions][5]                 | Provides extension methods for common ADO.NET objects.                                                                                                                                                          
[SQL][6]                        | Provides a set of static (Shared in Visual Basic) methods to create [SqlBuilder][7] instances.                                                                                                                  
[SqlBuilder][7]                 | Represents a mutable SQL string.                                                                                                                                                                                
[SqlCommandBuilder<TEntity>][8] | Generates SQL commands for entities mapped by [SqlTable][9] and [SqlTable<TEntity>][10]. This class cannot be instantiated.                                                                                     
[SqlSet][11]                    | Represents an immutable, connected SQL query.                                                                                                                                                                   
[SqlSet<TResult>][12]           | Represents an immutable, connected SQL query that maps to TResult objects.                                                                                                                                      
[SqlTable][9]                   | A non-generic version of [SqlTable<TEntity>][10] which can be used when the type of the entity is not known at build time. This class cannot be instantiated.                                                   
[SqlTable<TEntity>][10]         | A [SqlSet<TResult>][12] that provides additional methods for CRUD (Create, Read, Update, Delete) operations for TEntity, mapped using the [System.Data.Linq.Mapping][2] API. This class cannot be instantiated. 
[XmlMappingSettings][13]        | Provides settings for SQL to XML mapping.                                                                                                                                                                       


Enumerations
------------

Enumeration                     | Description                                                                                                                                                                                                
------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[AffectedRecordsPolicy][14]     | Indicates how to validate the affected records value returned by a non-query command.                                                                                                                      
[ConcurrencyConflictPolicy][15] | Indicates what concurrency conflict policy to use. A concurrency conflict ocurrs when trying to UPDATE/DELETE a row that has a newer version, or when trying to UPDATE/DELETE a row that no longer exists. 
[XmlNullHandling][16]           | Specifies how to handle null fields.                                                                                                                                                                       
[XmlTypeAnnotation][17]         | Specifies what kind of type information to include.                                                                                                                                                        

[1]: Database/README.md
[2]: http://msdn.microsoft.com/en-us/library/bb515105
[3]: DatabaseConfiguration/README.md
[4]: DbFactory/README.md
[5]: Extensions/README.md
[6]: SQL/README.md
[7]: SqlBuilder/README.md
[8]: SqlCommandBuilder_1/README.md
[9]: SqlTable/README.md
[10]: SqlTable_1/README.md
[11]: SqlSet/README.md
[12]: SqlSet_1/README.md
[13]: XmlMappingSettings/README.md
[14]: AffectedRecordsPolicy/README.md
[15]: ConcurrencyConflictPolicy/README.md
[16]: XmlNullHandling/README.md
[17]: XmlTypeAnnotation/README.md