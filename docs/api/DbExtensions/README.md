DbExtensions Namespace
======================
DbExtensions is a data-access framework with a strong focus on query composition, granularity and code aesthetics. [Database][1] is the entry point of the **DbExtensions** API.


Classes
-------

|                 | Class                               | Description                                                                                                                                                                                                                                                                                          |
| --------------- | ----------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public class] | [AssociationAttribute][2]           | Designates a property to represent a database association, such as a foreign key relationship.                                                                                                                                                                                                       |
| ![Public class] | [ChangeConflictException][3]        | An exception that is thrown when a concurrency violation is encountered while saving to the database. A concurrency violation occurs when an unexpected number of rows are affected during save. This is usually because the data in the database has been modified since it was loaded into memory. |
| ![Public class] | [ColumnAttribute][4]                | Associates a property with a column in a database table.                                                                                                                                                                                                                                             |
| ![Public class] | [ComplexPropertyAttribute][5]       | Designates a property as a complex property that groups columns of a table that share the same base name.                                                                                                                                                                                            |
| ![Public class] | [Database][1]                       | Provides simple data access using [SqlSet][6], [SqlBuilder][7] and [SqlTable&lt;TEntity>][8].                                                                                                                                                                                                        |
| ![Public class] | [DatabaseConfiguration][9]          | Holds configuration options that customize the behavior of [Database][1]. This class cannot be instantiated, to get an instance use the [Configuration][10] property.                                                                                                                                |
| ![Public class] | [Extensions][11]                    | Provides extension methods for common ADO.NET objects.                                                                                                                                                                                                                                               |
| ![Public class] | [SQL][12]                           | Provides a set of static (Shared in Visual Basic) methods to create [SqlBuilder][7] instances.                                                                                                                                                                                                       |
| ![Public class] | [SqlBuilder][7]                     | Represents a mutable SQL string.                                                                                                                                                                                                                                                                     |
| ![Public class] | [SqlCommandBuilder&lt;TEntity>][13] | Generates SQL commands for annotated classes. This class cannot be instantiated, to get an instance use the [CommandBuilder][14] or [CommandBuilder][15] properties.                                                                                                                                 |
| ![Public class] | [SqlSet][6]                         | Represents an immutable, connected SQL query. This class cannot be instantiated, to get an instance use the [From(String)][16] method.                                                                                                                                                               |
| ![Public class] | [SqlSet&lt;TResult>][17]            | Represents an immutable, connected SQL query that maps to TResult objects. This class cannot be instantiated, to get an instance use the [From&lt;TResult>(String)][18] method.                                                                                                                      |
| ![Public class] | [SqlTable][19]                      | A non-generic version of [SqlTable&lt;TEntity>][8] which can be used when the type of the entity is not known at build time. This class cannot be instantiated, to get an instance use the [Table(Type)][20] method.                                                                                 |
| ![Public class] | [SqlTable&lt;TEntity>][8]           | A [SqlSet&lt;TResult>][17] that provides CRUD (Create, Read, Update, Delete) operations for annotated classes. This class cannot be instantiated, to get an instance use the [Table&lt;TEntity>()][21] method.                                                                                       |
| ![Public class] | [TableAttribute][22]                | Designates a class as an entity class that is associated with a database table.                                                                                                                                                                                                                      |


Enumerations
------------

|                       | Enumeration    | Description                                                                                                                   |
| --------------------- | -------------- | ----------------------------------------------------------------------------------------------------------------------------- |
| ![Public enumeration] | [AutoSync][23] | Used to specify for during INSERT and UPDATE operations when a data member should be read back after the operation completes. |

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
[13]: SqlCommandBuilder_1/README.md
[14]: SqlTable_1/CommandBuilder.md
[15]: SqlTable/CommandBuilder.md
[16]: Database/From_2.md
[17]: SqlSet_1/README.md
[18]: Database/From__1_2.md
[19]: SqlTable/README.md
[20]: Database/Table.md
[21]: Database/Table__1.md
[22]: TableAttribute/README.md
[23]: AutoSync/README.md
[Public class]: ../icons/pubclass.svg "Public class"
[Public enumeration]: ../icons/pubenumeration.svg "Public enumeration"