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
| ![Public method] | [Database()][6]               | Initializes a new instance of the **Database** class.                                                                    |
| ![Public method] | [Database(IDbConnection)][7]  | Initializes a new instance of the **Database** class using the provided connection.                                      |
| ![Public method] | [Database(String)][8]         | Initializes a new instance of the **Database** class using the provided connection string.                               |
| ![Public method] | [Database(String, String)][9] | Initializes a new instance of the **Database** class using the provided connection string and provider's invariant name. |


Properties
----------

|                    | Name                | Description                                                 |
| ------------------ | ------------------- | ----------------------------------------------------------- |
| ![Public property] | [Configuration][10] | Provides access to configuration options for this instance. |
| ![Public property] | [Connection][11]    | Gets the connection to associate with new commands.         |
| ![Public property] | [Transaction][12]   | Gets or sets a transaction to associate with new commands.  |


Methods
-------

|                                 | Name                                                              | Description                                                                                                                                                                      |
| ------------------------------- | ----------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]                | [Add][13]                                                         | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                             |
| ![Public method]                | [Contains][14]                                                    | Checks the existance of the *entity*, using the primary key value.                                                                                                               |
| ![Public method]                | [ContainsKey(Type, Object)][15]                                   | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                      |
| ![Public method]                | [ContainsKey&lt;TEntity>(Object)][16]                             | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                      |
| ![Public method]                | [CreateCommand][17]                                               | Creates and returns an [IDbCommand][18] object from the specified *sqlBuilder*.                                                                                                  |
| ![Public method]                | [Dispose()][19]                                                   | Releases all resources used by the current instance of the **Database** class.                                                                                                   |
| ![Protected method]             | [Dispose(Boolean)][20]                                            | Releases the resources used by this **Database** instance.                                                                                                                       |
| ![Public method]![Code example] | [EnsureConnectionOpen][21]                                        | Opens [Connection][11] (if it's not open) and returns an [IDisposable][22] object you can use to close it (if it wasn't open).                                                   |
| ![Public method]                | [EnsureInTransaction()][23]                                       | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                      |
| ![Public method]                | [EnsureInTransaction(IsolationLevel)][24]                         | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.                                                      |
| ![Public method]                | [Execute][25]                                                     | Executes the *nonQuery* command. Optionally uses a transaction and validates affected records value before committing.                                                           |
| ![Public method]                | [Find(Type, Object)][26]                                          | Gets the entity whose primary key matches the *id* parameter.                                                                                                                    |
| ![Public method]                | [Find&lt;TEntity>(Object)][27]                                    | Gets the entity whose primary key matches the *id* parameter.                                                                                                                    |
| ![Public method]                | [From(SqlBuilder)][28]                                            | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                         |
| ![Public method]                | [From(String)][29]                                                | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                             |
| ![Public method]                | [From(SqlBuilder, Type)][30]                                      | Creates and returns a new [SqlSet][1] using the provided defining query.                                                                                                         |
| ![Public method]                | [From(String, Type)][31]                                          | Creates and returns a new [SqlSet][1] using the provided table name.                                                                                                             |
| ![Public method]                | [From&lt;TResult>(SqlBuilder)][32]                                | Creates and returns a new [SqlSet&lt;TResult>][33] using the provided defining query.                                                                                            |
| ![Public method]                | [From&lt;TResult>(String)][34]                                    | Creates and returns a new [SqlSet&lt;TResult>][33] using the provided table name.                                                                                                |
| ![Public method]                | [From&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][35] | Creates and returns a new [SqlSet&lt;TResult>][33] using the provided defining query and mapper.                                                                                 |
| ![Public method]                | [LastInsertId][36]                                                | Gets the identity value of the last inserted record.                                                                                                                             |
| ![Public method]                | [Map(SqlBuilder)][37]                                             | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                                                                              |
| ![Public method]                | [Map(SqlBuilder, Type)][38]                                       | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                      |
| ![Public method]                | [Map&lt;TResult>(SqlBuilder)][39]                                 | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                                                                              |
| ![Public method]                | [Map&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][40]  | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                                                                        |
| ![Public method]                | [QuoteIdentifier][41]                                             | Given an unquoted identifier in the correct catalog case, returns the correct quoted form of that identifier, including properly escaping any embedded quotes in the identifier. |
| ![Public method]                | [Remove][42]                                                      | Executes a DELETE command for the specified *entity*.                                                                                                                            |
| ![Public method]                | [RemoveKey(Type, Object)][43]                                     | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                           |
| ![Public method]                | [RemoveKey&lt;TEntity>(Object)][44]                               | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                           |
| ![Public method]                | [Table(Type)][45]                                                 | Returns the [SqlTable][46] instance for the specified *entityType*.                                                                                                              |
| ![Public method]                | [Table&lt;TEntity>()][47]                                         | Returns the [SqlTable&lt;TEntity>][3] instance for the specified TEntity.                                                                                                        |
| ![Public method]                | [Update(Object)][48]                                              | Executes an UPDATE command for the specified *entity*.                                                                                                                           |
| ![Public method]                | [Update(Object, Object)][49]                                      | Executes an UPDATE command for the specified *entity*.                                                                                                                           |


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
[8]: _ctor_2.md
[9]: _ctor_3.md
[10]: Configuration.md
[11]: Connection.md
[12]: Transaction.md
[13]: Add.md
[14]: Contains.md
[15]: ContainsKey.md
[16]: ContainsKey__1.md
[17]: CreateCommand.md
[18]: https://learn.microsoft.com/dotnet/api/system.data.idbcommand
[19]: Dispose.md
[20]: Dispose_1.md
[21]: EnsureConnectionOpen.md
[22]: https://learn.microsoft.com/dotnet/api/system.idisposable
[23]: EnsureInTransaction.md
[24]: EnsureInTransaction_1.md
[25]: Execute.md
[26]: Find.md
[27]: Find__1.md
[28]: From.md
[29]: From_2.md
[30]: From_1.md
[31]: From_3.md
[32]: From__1.md
[33]: ../SqlSet_1/README.md
[34]: From__1_2.md
[35]: From__1_1.md
[36]: LastInsertId.md
[37]: Map.md
[38]: Map_1.md
[39]: Map__1.md
[40]: Map__1_1.md
[41]: QuoteIdentifier.md
[42]: Remove.md
[43]: RemoveKey.md
[44]: RemoveKey__1.md
[45]: Table.md
[46]: ../SqlTable/README.md
[47]: Table__1.md
[48]: Update.md
[49]: Update_1.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"
[Protected method]: ../../icons/protmethod.svg "Protected method"
[Code example]: ../../icons/CodeExample.png "Code example"