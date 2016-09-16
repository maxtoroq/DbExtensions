DbExtensions Namespace
======================
DbExtensions is a data-access framework with a strong focus on query composition, granularity and code aesthetics. [Database][1] is the entry point of the **DbExtensions** API.


Classes
-------

                | Class                               | Description                                                                                                                                                                                                                                                                                          
--------------- | ----------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public class] | [AssociationAttribute][2]           | Designates a property to represent a database association, such as a foreign key relationship.                                                                                                                                                                                                       
![Public class] | [ChangeConflictException][3]        | An exception that is thrown when a concurrency violation is encountered while saving to the database. A concurrency violation occurs when an unexpected number of rows are affected during save. This is usually because the data in the database has been modified since it was loaded into memory. 
![Public class] | [ColumnAttribute][4]                | Associates a property with a column in a database table.                                                                                                                                                                                                                                             
![Public class] | [Database][1]                       | Provides simple data access using [SqlSet][5], [SqlBuilder][6] and [SqlTable&lt;TEntity>][7].                                                                                                                                                                                                        
![Public class] | [DatabaseConfiguration][8]          | Holds configuration options that customize the behavior of [Database][1].                                                                                                                                                                                                                            
![Public class] | [Extensions][9]                     | Provides extension methods for common ADO.NET objects.                                                                                                                                                                                                                                               
![Public class] | [SQL][10]                           | Provides a set of static (Shared in Visual Basic) methods to create [SqlBuilder][6] instances.                                                                                                                                                                                                       
![Public class] | [SqlBuilder][6]                     | Represents a mutable SQL string.                                                                                                                                                                                                                                                                     
![Public class] | [SqlCommandBuilder&lt;TEntity>][11] | Generates SQL commands for entities mapped by [SqlTable&lt;TEntity>][7] and [SqlTable][12]. This class cannot be instantiated, to get an instance use the [CommandBuilder][13] or [CommandBuilder][14] properties.                                                                                   
![Public class] | [SqlSet][5]                         | Represents an immutable, connected SQL query. This class cannot be instantiated, to get an instance use the [From(String)][15] method.                                                                                                                                                               
![Public class] | [SqlSet&lt;TResult>][16]            | Represents an immutable, connected SQL query that maps to TResult objects. This class cannot be instantiated, to get an instance use the [From&lt;TResult>(String)][17] method.                                                                                                                      
![Public class] | [SqlTable][12]                      | A non-generic version of [SqlTable&lt;TEntity>][7] which can be used when the type of the entity is not known at build time. This class cannot be instantiated, to get an instance use the [Table(Type)][18] method.                                                                                 
![Public class] | [SqlTable&lt;TEntity>][7]           | A [SqlSet&lt;TResult>][16] that provides additional methods for CRUD (Create, Read, Update, Delete) operations for entities mapped using the [System.Data.Linq.Mapping][19] API. This class cannot be instantiated, to get an instance use the [Table&lt;TEntity>()][20] method.                     
![Public class] | [TableAttribute][21]                | Designates a class as an entity class that is associated with a database table.                                                                                                                                                                                                                      


Enumerations
------------

                      | Enumeration    | Description                                                                                                                   
--------------------- | -------------- | ----------------------------------------------------------------------------------------------------------------------------- 
![Public enumeration] | [AutoSync][22] | Used to specify for during INSERT and UPDATE operations when a data member should be read back after the operation completes. 

[1]: Database/README.md
[2]: AssociationAttribute/README.md
[3]: ChangeConflictException/README.md
[4]: ColumnAttribute/README.md
[5]: SqlSet/README.md
[6]: SqlBuilder/README.md
[7]: SqlTable_1/README.md
[8]: DatabaseConfiguration/README.md
[9]: Extensions/README.md
[10]: SQL/README.md
[11]: SqlCommandBuilder_1/README.md
[12]: SqlTable/README.md
[13]: SqlTable_1/CommandBuilder.md
[14]: SqlTable/CommandBuilder.md
[15]: Database/From_2.md
[16]: SqlSet_1/README.md
[17]: Database/From__1_2.md
[18]: Database/Table.md
[19]: http://msdn.microsoft.com/en-us/library/bb515105
[20]: Database/Table__1.md
[21]: TableAttribute/README.md
[22]: AutoSync/README.md
[Public class]: ../_icons/pubclass.gif "Public class"
[Public enumeration]: ../_icons/pubenumeration.gif "Public enumeration"