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

| Name                          | Description                                                                                                              |
| ----------------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| [Database(DbConnection)][6]   | Initializes a new instance of the **Database** class using the provided connection.                                      |
| [Database(String, String)][7] | Initializes a new instance of the **Database** class using the provided connection string and provider's invariant name. |


Properties
----------

| Name               | Description                                                 |
| ------------------ | ----------------------------------------------------------- |
| [Configuration][8] | Provides access to configuration options for this instance. |
| [Connection][9]    | Gets the connection to associate with new commands.         |
| [Transaction][10]  | Gets or sets a transaction to associate with new commands.  |


Methods
-------

| Name                                                                   | Description                                                                                                                                                                      |
| ---------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [Add][11]                                                              | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                             |
| [AddAsync][12]                                                         | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                             |
| [AsyncMap(SqlBuilder)][13]                                             | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                                                                              |
| [AsyncMap(SqlBuilder, Type)][14]                                       | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                      |
| [AsyncMap&lt;TResult>(SqlBuilder)][15]                                 | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                                                                              |
| [AsyncMap&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)][16] | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                                                                        |
| [CreateCommand][17]                                                    | Creates and returns a [DbCommand][18] object from the specified *sqlBuilder*.                                                                                                    |
| [Dispose()][19]                                                        | Releases all resources used by the current instance of the **Database** class.                                                                                                   |
| [Dispose(Boolean)][20]                                                 | Releases the resources used by this **Database** instance.                                                                                                                       |
| [EnsureConnectionOpen][21]                                             | Opens [Connection][9] (if it's not open) and returns an [IDisposable][22] object you can use to close it (if it wasn't open).                                                    |
| [EnsureConnectionOpenAsync][23]                                        | Opens [Connection][9] (if it's not open) and returns an [IAsyncDisposable][24] object you can use to close it (if it wasn't open).                                               |
| [EnsureInTransaction()][25]                                            | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                      |
| [EnsureInTransaction(IsolationLevel)][26]                              | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                      |
| [EnsureInTransactionAsync(CancellationToken)][27]                      | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                      |
| [EnsureInTransactionAsync(IsolationLevel, CancellationToken)][28]      | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                      |
| [Execute][29]                                                          | Executes the *nonQuery* command. Optionally uses a transaction and validates affected records value before committing.                                                           |
| [ExecuteAsync][30]                                                     | Executes the *nonQuery* command. Optionally uses a transaction and validates affected records value before committing.                                                           |
| [Find&lt;TEntity>][31]                                                 | Gets the entity whose primary key matches the *id* parameter.                                                                                                                    |
| [FindAsync&lt;TEntity>][32]                                            | Gets the entity whose primary key matches the *id* parameter.                                                                                                                    |
| [From(SqlBuilder)][33]                                                 | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                         |
| [From(String)][34]                                                     | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                             |
| [From(SqlBuilder, Type)][35]                                           | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                         |
| [From(String, Type)][36]                                               | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                             |
| [From&lt;TResult>(SqlBuilder)][37]                                     | Creates and returns a new [SqlSet&lt;TResult>][38] using the provided defining query.                                                                                            |
| [From&lt;TResult>(String)][39]                                         | Creates and returns a new [SqlSet&lt;TResult>][38] using the provided table name.                                                                                                |
| [From&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)][40]     | Creates and returns a new [SqlSet&lt;TResult>][38] using the provided defining query and mapper.                                                                                 |
| [LastInsertId][41]                                                     | Gets the identity value of the last inserted record.                                                                                                                             |
| [LastInsertIdAsync][42]                                                | Gets the identity value of the last inserted record.                                                                                                                             |
| [Map(SqlBuilder)][43]                                                  | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                                                                              |
| [Map(SqlBuilder, Type)][44]                                            | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                      |
| [Map&lt;TResult>(SqlBuilder)][45]                                      | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                                                                              |
| [Map&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)][46]      | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                                                                        |
| [QuoteIdentifier][47]                                                  | Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier, including properly escaping any embedded quotes in the identifier. |
| [Remove][48]                                                           | Executes a DELETE command for the specified *entity*.                                                                                                                            |
| [RemoveAsync][49]                                                      | Executes a DELETE command for the specified *entity*.                                                                                                                            |
| [RemoveKey&lt;TEntity>][50]                                            | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                           |
| [RemoveKeyAsync&lt;TEntity>][51]                                       | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                           |
| [Table(Type)][52]                                                      | Returns the [SqlTable][53] instance for the specified *entityType*.                                                                                                              |
| [Table&lt;TEntity>()][54]                                              | Returns the [SqlTable&lt;TEntity>][3] instance for the specified TEntity.                                                                                                        |
| [Update(Object)][55]                                                   | Executes an UPDATE command for the specified *entity*.                                                                                                                           |
| [Update(Object, Object)][56]                                           | Executes an UPDATE command for the specified *entity*.                                                                                                                           |
| [UpdateAsync(Object, CancellationToken)][57]                           | Executes an UPDATE command for the specified *entity*.                                                                                                                           |
| [UpdateAsync(Object, Object, CancellationToken)][58]                   | Executes an UPDATE command for the specified *entity*.                                                                                                                           |


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
[12]: AddAsync.md
[13]: AsyncMap.md
[14]: AsyncMap_1.md
[15]: AsyncMap__1.md
[16]: AsyncMap__1_1.md
[17]: CreateCommand.md
[18]: https://learn.microsoft.com/dotnet/api/system.data.common.dbcommand
[19]: Dispose.md
[20]: Dispose_1.md
[21]: EnsureConnectionOpen.md
[22]: https://learn.microsoft.com/dotnet/api/system.idisposable
[23]: EnsureConnectionOpenAsync.md
[24]: https://learn.microsoft.com/dotnet/api/system.iasyncdisposable
[25]: EnsureInTransaction.md
[26]: EnsureInTransaction_1.md
[27]: EnsureInTransactionAsync_1.md
[28]: EnsureInTransactionAsync.md
[29]: Execute.md
[30]: ExecuteAsync.md
[31]: Find__1.md
[32]: FindAsync__1.md
[33]: From.md
[34]: From_2.md
[35]: From_1.md
[36]: From_3.md
[37]: From__1.md
[38]: ../SqlSet_1/README.md
[39]: From__1_2.md
[40]: From__1_1.md
[41]: LastInsertId.md
[42]: LastInsertIdAsync.md
[43]: Map.md
[44]: Map_1.md
[45]: Map__1.md
[46]: Map__1_1.md
[47]: QuoteIdentifier.md
[48]: Remove.md
[49]: RemoveAsync.md
[50]: RemoveKey__1.md
[51]: RemoveKeyAsync__1.md
[52]: Table.md
[53]: ../SqlTable/README.md
[54]: Table__1.md
[55]: Update.md
[56]: Update_1.md
[57]: UpdateAsync_1.md
[58]: UpdateAsync.md