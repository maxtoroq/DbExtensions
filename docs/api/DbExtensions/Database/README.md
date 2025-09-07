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
| ![Public method]                | [Contains][12]                                                     | Checks the existance of the *entity*, using the primary key value.                                                                                                               |
| ![Public method]                | [ContainsKey(Type, Object)][13]                                    | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                      |
| ![Public method]                | [ContainsKey&lt;TEntity>(Object)][14]                              | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                      |
| ![Public method]                | [CreateCommand][15]                                                | Creates and returns a [DbCommand][16] object from the specified *sqlBuilder*.                                                                                                    |
| ![Public method]                | [Dispose()][17]                                                    | Releases all resources used by the current instance of the **Database** class.                                                                                                   |
| ![Protected method]             | [Dispose(Boolean)][18]                                             | Releases the resources used by this **Database** instance.                                                                                                                       |
| ![Public method]![Code example] | [EnsureConnectionOpen][19]                                         | Opens [Connection][9] (if it's not open) and returns an [IDisposable][20] object you can use to close it (if it wasn't open).                                                    |
| ![Public method]                | [EnsureInTransaction()][21]                                        | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                      |
| ![Public method]                | [EnsureInTransaction(IsolationLevel)][22]                          | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                      |
| ![Public method]                | [Execute][23]                                                      | Executes the *nonQuery* command. Optionally uses a transaction and validates affected records value before committing.                                                           |
| ![Public method]                | [Find(Type, Object)][24]                                           | Gets the entity whose primary key matches the *id* parameter.                                                                                                                    |
| ![Public method]                | [Find&lt;TEntity>(Object)][25]                                     | Gets the entity whose primary key matches the *id* parameter.                                                                                                                    |
| ![Public method]                | [From(SqlBuilder)][26]                                             | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                         |
| ![Public method]                | [From(String)][27]                                                 | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                             |
| ![Public method]                | [From(SqlBuilder, Type)][28]                                       | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                         |
| ![Public method]                | [From(String, Type)][29]                                           | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                             |
| ![Public method]                | [From&lt;TResult>(SqlBuilder)][30]                                 | Creates and returns a new [SqlSet&lt;TResult>][31] using the provided defining query.                                                                                            |
| ![Public method]                | [From&lt;TResult>(String)][32]                                     | Creates and returns a new [SqlSet&lt;TResult>][31] using the provided table name.                                                                                                |
| ![Public method]                | [From&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)][33] | Creates and returns a new [SqlSet&lt;TResult>][31] using the provided defining query and mapper.                                                                                 |
| ![Public method]                | [LastInsertId][34]                                                 | Gets the identity value of the last inserted record.                                                                                                                             |
| ![Public method]                | [Map(SqlBuilder)][35]                                              | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                                                                              |
| ![Public method]                | [Map(SqlBuilder, Type)][36]                                        | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                      |
| ![Public method]                | [Map&lt;TResult>(SqlBuilder)][37]                                  | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                                                                              |
| ![Public method]                | [Map&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)][38]  | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                                                                        |
| ![Public method]                | [QuoteIdentifier][39]                                              | Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier, including properly escaping any embedded quotes in the identifier. |
| ![Public method]                | [Remove][40]                                                       | Executes a DELETE command for the specified *entity*.                                                                                                                            |
| ![Public method]                | [RemoveKey(Type, Object)][41]                                      | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                           |
| ![Public method]                | [RemoveKey&lt;TEntity>(Object)][42]                                | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                           |
| ![Public method]                | [Table(Type)][43]                                                  | Returns the [SqlTable][44] instance for the specified *entityType*.                                                                                                              |
| ![Public method]                | [Table&lt;TEntity>()][45]                                          | Returns the [SqlTable&lt;TEntity>][3] instance for the specified TEntity.                                                                                                        |
| ![Public method]                | [Update(Object)][46]                                               | Executes an UPDATE command for the specified *entity*.                                                                                                                           |
| ![Public method]                | [Update(Object, Object)][47]                                       | Executes an UPDATE command for the specified *entity*.                                                                                                                           |


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
[12]: Contains.md
[13]: ContainsKey.md
[14]: ContainsKey__1.md
[15]: CreateCommand.md
[16]: https://learn.microsoft.com/dotnet/api/system.data.common.dbcommand
[17]: Dispose.md
[18]: Dispose_1.md
[19]: EnsureConnectionOpen.md
[20]: https://learn.microsoft.com/dotnet/api/system.idisposable
[21]: EnsureInTransaction.md
[22]: EnsureInTransaction_1.md
[23]: Execute.md
[24]: Find.md
[25]: Find__1.md
[26]: From.md
[27]: From_2.md
[28]: From_1.md
[29]: From_3.md
[30]: From__1.md
[31]: ../SqlSet_1/README.md
[32]: From__1_2.md
[33]: From__1_1.md
[34]: LastInsertId.md
[35]: Map.md
[36]: Map_1.md
[37]: Map__1.md
[38]: Map__1_1.md
[39]: QuoteIdentifier.md
[40]: Remove.md
[41]: RemoveKey.md
[42]: RemoveKey__1.md
[43]: Table.md
[44]: ../SqlTable/README.md
[45]: Table__1.md
[46]: Update.md
[47]: Update_1.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Protected method]: ../../icons/protmethod.svg "Protected method"
[Code example]: ../../icons/CodeExample.png "Code example"