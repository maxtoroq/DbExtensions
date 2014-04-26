DbExtensions Namespace
======================
Extensions methods for ADO.NET, CRUD and dynamic SQL components. [Database][1] is the entry point of the **DbExtensions** API.


Classes
-------

Class                              | Description                                                                                                                                                                                                                                                                      
---------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[Database][1]                      | Provides simple data access using [SqlSet][2], [SqlBuilder][3] and [SqlTable&lt;TEntity>][4].                                                                                                                                                                                    
[DatabaseConfiguration][5]         | Holds configuration options that customize the behavior of [Database][1].                                                                                                                                                                                                        
[Extensions][6]                    | Provides extension methods for common ADO.NET objects.                                                                                                                                                                                                                           
[SQL][7]                           | Provides a set of static (Shared in Visual Basic) methods to create [SqlBuilder][3] instances.                                                                                                                                                                                   
[SqlBuilder][3]                    | Represents a mutable SQL string.                                                                                                                                                                                                                                                 
[SqlCommandBuilder&lt;TEntity>][8] | Generates SQL commands for entities mapped by [SqlTable][9] and [SqlTable&lt;TEntity>][4]. This class cannot be instantiated.                                                                                                                                                    
[SqlSet][2]                        | Represents an immutable, connected SQL query.                                                                                                                                                                                                                                    
[SqlSet&lt;TResult>][10]           | Represents an immutable, connected SQL query that maps to TResult objects.                                                                                                                                                                                                       
[SqlTable][9]                      | A non-generic version of [SqlTable&lt;TEntity>][4] which can be used when the type of the entity is not known at build time. This class cannot be instantiated, to get an instance use the [Table(Type)][11] method.                                                             
[SqlTable&lt;TEntity>][4]          | A [SqlSet&lt;TResult>][10] that provides additional methods for CRUD (Create, Read, Update, Delete) operations for entities mapped using the [System.Data.Linq.Mapping][12] API. This class cannot be instantiated, to get an instance use the [Table&lt;TEntity>()][13] method. 


Enumerations
------------

Enumeration                     | Description                                                                                                                                                                                                
------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[AffectedRecordsPolicy][14]     | Indicates how to validate the affected records value returned by a non-query command.                                                                                                                      
[ConcurrencyConflictPolicy][15] | Indicates what concurrency conflict policy to use. A concurrency conflict ocurrs when trying to UPDATE/DELETE a row that has a newer version, or when trying to UPDATE/DELETE a row that no longer exists. 

[1]: Database/README.md
[2]: SqlSet/README.md
[3]: SqlBuilder/README.md
[4]: SqlTable_1/README.md
[5]: DatabaseConfiguration/README.md
[6]: Extensions/README.md
[7]: SQL/README.md
[8]: SqlCommandBuilder_1/README.md
[9]: SqlTable/README.md
[10]: SqlSet_1/README.md
[11]: Database/Table_1.md
[12]: http://msdn.microsoft.com/en-us/library/bb515105
[13]: Database/Table__1.md
[14]: AffectedRecordsPolicy/README.md
[15]: ConcurrencyConflictPolicy/README.md