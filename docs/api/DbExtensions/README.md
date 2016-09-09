DbExtensions Namespace
======================
DbExtensions is a data-access framework with a strong focus on query composition, granularity and code aesthetics. [Database][1] is the entry point of the **DbExtensions** API.


Classes
-------

                | Class                              | Description                                                                                                                                                                                                                                                                                          
--------------- | ---------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public class] | [ChangeConflictException][2]       | An exception that is thrown when a concurrency violation is encountered while saving to the database. A concurrency violation occurs when an unexpected number of rows are affected during save. This is usually because the data in the database has been modified since it was loaded into memory. 
![Public class] | [Database][1]                      | Provides simple data access using [SqlSet][3], [SqlBuilder][4] and [SqlTable&lt;TEntity>][5].                                                                                                                                                                                                        
![Public class] | [DatabaseConfiguration][6]         | Holds configuration options that customize the behavior of [Database][1].                                                                                                                                                                                                                            
![Public class] | [Extensions][7]                    | Provides extension methods for common ADO.NET objects.                                                                                                                                                                                                                                               
![Public class] | [SQL][8]                           | Provides a set of static (Shared in Visual Basic) methods to create [SqlBuilder][4] instances.                                                                                                                                                                                                       
![Public class] | [SqlBuilder][4]                    | Represents a mutable SQL string.                                                                                                                                                                                                                                                                     
![Public class] | [SqlCommandBuilder&lt;TEntity>][9] | Generates SQL commands for entities mapped by [SqlTable&lt;TEntity>][5] and [SqlTable][10]. This class cannot be instantiated, to get an instance use the [CommandBuilder][11] or [CommandBuilder][12] properties.                                                                                   
![Public class] | [SqlSet][3]                        | Represents an immutable, connected SQL query. This class cannot be instantiated, to get an instance use the [From(String)][13] method.                                                                                                                                                               
![Public class] | [SqlSet&lt;TResult>][14]           | Represents an immutable, connected SQL query that maps to TResult objects. This class cannot be instantiated, to get an instance use the [From&lt;TResult>(String)][15] method.                                                                                                                      
![Public class] | [SqlTable][10]                     | A non-generic version of [SqlTable&lt;TEntity>][5] which can be used when the type of the entity is not known at build time. This class cannot be instantiated, to get an instance use the [Table(Type)][16] method.                                                                                 
![Public class] | [SqlTable&lt;TEntity>][5]          | A [SqlSet&lt;TResult>][14] that provides additional methods for CRUD (Create, Read, Update, Delete) operations for entities mapped using the [System.Data.Linq.Mapping][17] API. This class cannot be instantiated, to get an instance use the [Table&lt;TEntity>()][18] method.                     

[1]: Database/README.md
[2]: ChangeConflictException/README.md
[3]: SqlSet/README.md
[4]: SqlBuilder/README.md
[5]: SqlTable_1/README.md
[6]: DatabaseConfiguration/README.md
[7]: Extensions/README.md
[8]: SQL/README.md
[9]: SqlCommandBuilder_1/README.md
[10]: SqlTable/README.md
[11]: SqlTable_1/CommandBuilder.md
[12]: SqlTable/CommandBuilder.md
[13]: Database/From_2.md
[14]: SqlSet_1/README.md
[15]: Database/From__1_2.md
[16]: Database/Table_1.md
[17]: http://msdn.microsoft.com/en-us/library/bb515105
[18]: Database/Table__1.md
[Public class]: ../_icons/pubclass.gif "Public class"