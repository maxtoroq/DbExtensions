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
| [SqlClause.CROSS_JOIN][14]          | The CROSS JOIN clause.                                                                                                                                                                                                                                                                               |
| [SqlClause.Current][15]             | The "current" clause.                                                                                                                                                                                                                                                                                |
| [SqlClause.DELETE_FROM][16]         | The DELETE FROM clause.                                                                                                                                                                                                                                                                              |
| [SqlClause.FROM][17]                | The FROM clause.                                                                                                                                                                                                                                                                                     |
| [SqlClause.GROUP_BY][18]            | The GROUP BY clause.                                                                                                                                                                                                                                                                                 |
| [SqlClause.HAVING][19]              | The HAVING clause.                                                                                                                                                                                                                                                                                   |
| [SqlClause.INNER_JOIN][20]          | The INNER JOIN clause.                                                                                                                                                                                                                                                                               |
| [SqlClause.INSERT_INTO][21]         | The INSERT INTO clause.                                                                                                                                                                                                                                                                              |
| [SqlClause.JOIN][22]                | The JOIN clause.                                                                                                                                                                                                                                                                                     |
| [SqlClause.LEFT_JOIN][23]           | The LEFT JOIN clause.                                                                                                                                                                                                                                                                                |
| [SqlClause.LIMIT][24]               | The LIMIT clause.                                                                                                                                                                                                                                                                                    |
| [SqlClause.OFFSET][25]              | The OFFSET clause.                                                                                                                                                                                                                                                                                   |
| [SqlClause.ORDER_BY][26]            | The ORDER BY clause.                                                                                                                                                                                                                                                                                 |
| [SqlClause.RIGHT_JOIN][27]          | The RIGHT JOIN clause.                                                                                                                                                                                                                                                                               |
| [SqlClause.SELECT][28]              | The SELECT clause.                                                                                                                                                                                                                                                                                   |
| [SqlClause.SET][29]                 | The SET clause.                                                                                                                                                                                                                                                                                      |
| [SqlClause.UNION][30]               | The UNION clause.                                                                                                                                                                                                                                                                                    |
| [SqlClause.UPDATE][31]              | The UPDATE clause.                                                                                                                                                                                                                                                                                   |
| [SqlClause.VALUES][32]              | The VALUES clause.                                                                                                                                                                                                                                                                                   |
| [SqlClause.WHERE][33]               | The WHERE clause.                                                                                                                                                                                                                                                                                    |
| [SqlClause.WITH][34]                | The WITH clause.                                                                                                                                                                                                                                                                                     |
| [SqlCommandBuilder&lt;TEntity>][35] | Generates SQL commands for annotated classes. This class cannot be instantiated, to get an instance use the [SqlTable&lt;TEntity>.CommandBuilder][36] or [SqlTable.CommandBuilder][37] properties.                                                                                                   |
| [SqlSet][6]                         | Represents an immutable, connected SQL query. This class cannot be instantiated, to get an instance use one of the [Database.From][38] overloads.                                                                                                                                                    |
| [SqlSet&lt;TResult>][39]            | Represents an immutable, connected SQL query that maps to TResult objects. This class cannot be instantiated, to get an instance use one of the [Database.From&lt;TResult>(String)][40] overloads.                                                                                                   |
| [SqlTable][41]                      | A non-generic version of [SqlTable&lt;TEntity>][8] which can be used when the type of the entity is not known at build time. This class cannot be instantiated, to get an instance use the [Database.Table(Type)][42] method.                                                                        |
| [SqlTable&lt;TEntity>][8]           | A [SqlSet&lt;TResult>][39] that provides CRUD (Create, Read, Update, Delete) operations for annotated classes. This class cannot be instantiated, to get an instance use the [Database.Table&lt;TEntity>()][43] method.                                                                              |
| [TableAttribute][44]                | Designates a class as an entity class that is associated with a database table.                                                                                                                                                                                                                      |


Enumerations
------------

| Enumeration    | Description                                                                                                                   |
| -------------- | ----------------------------------------------------------------------------------------------------------------------------- |
| [AutoSync][45] | Used to specify for during INSERT and UPDATE operations when a data member should be read back after the operation completes. |

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
[14]: SqlClause_CROSS_JOIN/README.md
[15]: SqlClause_Current/README.md
[16]: SqlClause_DELETE_FROM/README.md
[17]: SqlClause_FROM/README.md
[18]: SqlClause_GROUP_BY/README.md
[19]: SqlClause_HAVING/README.md
[20]: SqlClause_INNER_JOIN/README.md
[21]: SqlClause_INSERT_INTO/README.md
[22]: SqlClause_JOIN/README.md
[23]: SqlClause_LEFT_JOIN/README.md
[24]: SqlClause_LIMIT/README.md
[25]: SqlClause_OFFSET/README.md
[26]: SqlClause_ORDER_BY/README.md
[27]: SqlClause_RIGHT_JOIN/README.md
[28]: SqlClause_SELECT/README.md
[29]: SqlClause_SET/README.md
[30]: SqlClause_UNION/README.md
[31]: SqlClause_UPDATE/README.md
[32]: SqlClause_VALUES/README.md
[33]: SqlClause_WHERE/README.md
[34]: SqlClause_WITH/README.md
[35]: SqlCommandBuilder_1/README.md
[36]: SqlTable_1/CommandBuilder.md
[37]: SqlTable/CommandBuilder.md
[38]: Database/From.md
[39]: SqlSet_1/README.md
[40]: Database/From__1_2.md
[41]: SqlTable/README.md
[42]: Database/Table.md
[43]: Database/Table__1.md
[44]: TableAttribute/README.md
[45]: AutoSync/README.md