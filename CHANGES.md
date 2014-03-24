Changes
=======

v4.4.0
------
- Improved SqlTable, using subqueries only when necessary
- Added SQL.Param to workaround [#10](https://github.com/maxtoroq/DbExtensions/issues/10)
- Deprecated SQL.ctor

v4.3.0
------
- Implemented IDisposable on Database
- Convention-based DbConnection.GetProviderFactory fallback
- Removed AS keyword in FROM clause (to support Oracle)
- Deprecated SqlTable.Initialize
- SqlSet improvements:
  * Oracle support
  * Using subqueries only when necessary
  * Fixed [#13](https://github.com/maxtoroq/DbExtensions/issues/13): Skip().OrderBy() are applied in the same query instead of applying Skip() first
  * Deprecated DbConnection.Set and Database.Set, replaced by From
  * Can create set using table name only, e.g. From("Products")

v4.2.0
------
- Mapping to dynamic objects, Map methods which do not need a Type argument, also supported by SqlSet. This feature requires .NET 4+
- New methods: SqlTable.ContainsKey, SqlCommandBuilder.UPDATE, SqlTable.DeleteRange, SqlTable.UpdateRange
- Deprecated SqlTable.InsertDeep, replaced by Insert(object, bool)
- Added SqlTable.InsertRange overloads with bool parameter
- Deprecated Database.InsertRange
- Deprecated SqlTable.DeleteById, replaced by DeleteKey

v4.1.1
------
- Fixed [#4](https://github.com/maxtoroq/DbExtensions/issues/4): SqlSet&lt;T>.AsEnumerable() fails if T is a value type
- Fixed [#2](https://github.com/maxtoroq/DbExtensions/issues/2): Use parameter on SqlBuilder OFFSET(int) and LIMIT(int)
- Fixed [#3](https://github.com/maxtoroq/DbExtensions/issues/3): OleDbConnection and OdbcConnection do not override DbProviderFactory

v4.1.0
------
- Mapping to constructor arguments
- Copied DbFactory methods to Database, marked DbFactory as obsolete
- Fixed [#1](https://github.com/maxtoroq/DbExtensions/issues/1): Skip Refresh after Insert on non-entity types

v4.0.0
------
- New SqlSet API for making queries
- DataAccessObject split into Database, DatabaseConfiguration and SqlTable
- IDataRecord.Get{TypeName}(string) extension methods
- MapXml methods now return XmlReader, and take XmlMappingSettings parameter
- Unified extension methods class
