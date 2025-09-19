DbExtensions Namespace
======================
DbExtensions is a data-access framework with a strong focus on query composition, granularity and code aesthetics. [Database][1] is the entry point of the **DbExtensions** API.


Classes
-------

| Class                               | Description                                                                                                                                                                                                                                                                                          |
| ----------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [AssociationAttribute][2]           | Designates a property to represent a database association, such as a foreign key relationship.                                                                                                                                                                                                       |
| [ChangeConflictException][3]        | An exception that is thrown when a concurrency violation is encountered while saving to the database. A concurrency violation occurs when an unexpected number of rows are affected during save. This is usually because the data in the database has been modified since it was loaded into memory. |
| [ColumnAttribute][4]                | Associates a property with a column in a database table.                                                                                                                                                                                                                                             |
| [ComplexPropertyAttribute][5]       | Designates a property as a complex property that groups columns of a table that share the same base name.                                                                                                                                                                                            |
| [Database][1]                       | Provides simple data access using [SqlSet][6], [SqlBuilder][7] and [SqlTable&lt;TEntity>][8].                                                                                                                                                                                                        |
| [DatabaseConfiguration][9]          | Holds configuration options that customize the behavior of [Database][1]. This class cannot be instantiated, to get an instance use the [Configuration][10] property.                                                                                                                                |
| [Extensions][11]                    | Provides extension methods for common ADO.NET objects.                                                                                                                                                                                                                                               |
| [SQL][12]                           | Provides a set of static (Shared in Visual Basic) methods to create [SqlBuilder][7] instances.                                                                                                                                                                                                       |
| [SqlBuilder][7]                     | Represents a mutable SQL string.                                                                                                                                                                                                                                                                     |
| [SqlClause][13]                     | Provides information about a SQL clause. Used by [SqlBuilder][7].                                                                                                                                                                                                                                    |
| [SqlCommandBuilder&lt;TEntity>][14] | Generates SQL commands for annotated classes. This class cannot be instantiated, to get an instance use the [SqlTable&lt;TEntity>.CommandBuilder][15] or [SqlTable.CommandBuilder][16] properties.                                                                                                   |
| [SqlSet][6]                         | Represents an immutable, connected SQL query. This class cannot be instantiated, to get an instance use one of the [Database.From][17] overloads.                                                                                                                                                    |
| [SqlSet&lt;TResult>][18]            | Represents an immutable, connected SQL query that maps to TResult objects. This class cannot be instantiated, to get an instance use one of the [Database.From&lt;TResult>(String)][19] overloads.                                                                                                   |
| [SqlTable][20]                      | A non-generic version of [SqlTable&lt;TEntity>][8] which can be used when the type of the entity is not known at build time. This class cannot be instantiated, to get an instance use the [Database.Table(Type)][21] method.                                                                        |
| [SqlTable&lt;TEntity>][8]           | A [SqlSet&lt;TResult>][18] that provides CRUD (Create, Read, Update, Delete) operations for annotated classes. This class cannot be instantiated, to get an instance use the [Database.Table&lt;TEntity>()][22] method.                                                                              |
| [TableAttribute][23]                | Designates a class as an entity class that is associated with a database table.                                                                                                                                                                                                                      |


Enumerations
------------

| Enumeration    | Description                                                                                                                   |
| -------------- | ----------------------------------------------------------------------------------------------------------------------------- |
| [AutoSync][24] | Used to specify for during INSERT and UPDATE operations when a data member should be read back after the operation completes. |

[1]: Database/README.md
[2]: AssociationAttribute/README.md
[3]: ChangeConflictException/README.md
[4]: ColumnAttribute/README.md
[5]: ComplexPropertyAttribute/README.md
[6]: SqlSet/README.md
[7]: SqlBuilder/README.md
[8]: SqlTable_1/README.md
[9]: DatabaseConfiguration/README.md
[10]: Database/Configuration.md
[11]: Extensions/README.md
[12]: SQL/README.md
[13]: SqlClause/README.md
[14]: SqlCommandBuilder_1/README.md
[15]: SqlTable_1/CommandBuilder.md
[16]: SqlTable/CommandBuilder.md
[17]: Database/From.md
[18]: SqlSet_1/README.md
[19]: Database/From__1_2.md
[20]: SqlTable/README.md
[21]: Database/Table.md
[22]: Database/Table__1.md
[23]: TableAttribute/README.md
[24]: AutoSync/README.md