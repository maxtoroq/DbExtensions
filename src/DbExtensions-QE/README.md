DbExtensions-QE (Query Edition) is a version of DbExtensions that excludes:

- SqlTable, SqlTable&lt;T>
- Annotations (TableAttribute, ColumnAttribute, etc.)
- SqlSet methods that depend on annotations (Contains, ContainsKey, Find, Include)
- Internal Metadata namespace

Query Edition is intended for projects where the CRUD operations are source-generated, or implemented using another ORM.
