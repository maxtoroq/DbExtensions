Database Class
==============
Provides simple data access using [SqlSet][1], [SqlBuilder][2] and [SqlTable&lt;TEntity>][3].


Inheritance Hierarchy
---------------------
[System.Object][4]  
  **DbExtensions.Database**  
  
**Namespace:** [DbExtensions][5]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public class Database : IDisposable
```

The **Database** type exposes the following members.


Constructors
------------

|                  | Name                          | Description                                                                                                              |
| ---------------- | ----------------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [Database(DbConnection)][6]   | Initializes a new instance of the **Database** class using the provided connection.                                      |
| ![Public method] | [Database(String, String)][7] | Initializes a new instance of the **Database** class using the provided connection string and provider's invariant name. |


Properties
----------

|                    | Name               | Description                                                 |
| ------------------ | ------------------ | ----------------------------------------------------------- |
| ![Public property] | [Configuration][8] | Provides access to configuration options for this instance. |
| ![Public property] | [Connection][9]    | Gets the connection to associate with new commands.         |
| ![Public property] | [Transaction][10]  | Gets or sets a transaction to associate with new commands.  |


Methods
-------

|                                 | Name                                                               | Description                                                                                                                                                                      |
| ------------------------------- | ------------------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]                | [Add][11]                                                          | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                             |
| ![Public method]                | [CreateCommand][12]                                                | Creates and returns a [DbCommand][13] object from the specified *sqlBuilder*.                                                                                                    |
| ![Public method]                | [Dispose()][14]                                                    | Releases all resources used by the current instance of the **Database** class.                                                                                                   |
| ![Protected method]             | [Dispose(Boolean)][15]                                             | Releases the resources used by this **Database** instance.                                                                                                                       |
| ![Public method]![Code example] | [EnsureConnectionOpen][16]                                         | Opens [Connection][9] (if it's not open) and returns an [IDisposable][17] object you can use to close it (if it wasn't open).                                                    |
| ![Public method]                | [EnsureInTransaction()][18]                                        | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                      |
| ![Public method]                | [EnsureInTransaction(IsolationLevel)][19]                          | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                      |
| ![Public method]                | [Execute][20]                                                      | Executes the *nonQuery* command. Optionally uses a transaction and validates affected records value before committing.                                                           |
| ![Public method]                | [Find&lt;TEntity>][21]                                             | Gets the entity whose primary key matches the *id* parameter.                                                                                                                    |
| ![Public method]                | [From(SqlBuilder)][22]                                             | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                         |
| ![Public method]                | [From(String)][23]                                                 | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                             |
| ![Public method]                | [From(SqlBuilder, Type)][24]                                       | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                         |
| ![Public method]                | [From(String, Type)][25]                                           | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                             |
| ![Public method]                | [From&lt;TResult>(SqlBuilder)][26]                                 | Creates and returns a new [SqlSet&lt;TResult>][27] using the provided defining query.                                                                                            |
| ![Public method]                | [From&lt;TResult>(String)][28]                                     | Creates and returns a new [SqlSet&lt;TResult>][27] using the provided table name.                                                                                                |
| ![Public method]                | [From&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)][29] | Creates and returns a new [SqlSet&lt;TResult>][27] using the provided defining query and mapper.                                                                                 |
| ![Public method]                | [LastInsertId][30]                                                 | Gets the identity value of the last inserted record.                                                                                                                             |
| ![Public method]                | [Map(SqlBuilder)][31]                                              | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                                                                              |
| ![Public method]                | [Map(SqlBuilder, Type)][32]                                        | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                      |
| ![Public method]                | [Map&lt;TResult>(SqlBuilder)][33]                                  | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                                                                              |
| ![Public method]                | [Map&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)][34]  | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                                                                        |
| ![Public method]                | [QuoteIdentifier][35]                                              | Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier, including properly escaping any embedded quotes in the identifier. |
| ![Public method]                | [Remove][36]                                                       | Executes a DELETE command for the specified *entity*.                                                                                                                            |
| ![Public method]                | [RemoveKey&lt;TEntity>][37]                                        | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                           |
| ![Public method]                | [Table(Type)][38]                                                  | Returns the [SqlTable][39] instance for the specified *entityType*.                                                                                                              |
| ![Public method]                | [Table&lt;TEntity>()][40]                                          | Returns the [SqlTable&lt;TEntity>][3] instance for the specified TEntity.                                                                                                        |
| ![Public method]                | [Update(Object)][41]                                               | Executes an UPDATE command for the specified *entity*.                                                                                                                           |
| ![Public method]                | [Update(Object, Object)][42]                                       | Executes an UPDATE command for the specified *entity*.                                                                                                                           |


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlSet/README.md
[2]: ../SqlBuilder/README.md
[3]: ../SqlTable_1/README.md
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: ../README.md
[6]: _ctor.md
[7]: _ctor_1.md
[8]: Configuration.md
[9]: Connection.md
[10]: Transaction.md
[11]: Add.md
[12]: CreateCommand.md
[13]: https://learn.microsoft.com/dotnet/api/system.data.common.dbcommand
[14]: Dispose.md
[15]: Dispose_1.md
[16]: EnsureConnectionOpen.md
[17]: https://learn.microsoft.com/dotnet/api/system.idisposable
[18]: EnsureInTransaction.md
[19]: EnsureInTransaction_1.md
[20]: Execute.md
[21]: Find__1.md
[22]: From.md
[23]: From_2.md
[24]: From_1.md
[25]: From_3.md
[26]: From__1.md
[27]: ../SqlSet_1/README.md
[28]: From__1_2.md
[29]: From__1_1.md
[30]: LastInsertId.md
[31]: Map.md
[32]: Map_1.md
[33]: Map__1.md
[34]: Map__1_1.md
[35]: QuoteIdentifier.md
[36]: Remove.md
[37]: RemoveKey__1.md
[38]: Table.md
[39]: ../SqlTable/README.md
[40]: Table__1.md
[41]: Update.md
[42]: Update_1.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Protected method]: ../../icons/protmethod.svg "Protected method"
[Code example]: ../../icons/CodeExample.png "Code example"