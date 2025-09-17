Database.From&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>) Method
============================================================================
Creates and returns a new [SqlSet&lt;TResult>][1] using the provided defining query and mapper.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                                                                     |
| ---------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| [From(SqlBuilder)][3]                                            | Creates and returns a new [SqlSet][4] using the provided defining query.                        |
| [From(String)][5]                                                | Creates and returns a new [SqlSet][4] using the provided table name.                            |
| [From(SqlBuilder, Type)][6]                                      | Creates and returns a new [SqlSet][4] using the provided defining query.                        |
| [From(String, Type)][7]                                          | Creates and returns a new [SqlSet][4] using the provided table name.                            |
| [From&lt;TResult>(SqlBuilder)][8]                                | Creates and returns a new [SqlSet&lt;TResult>][1] using the provided defining query.            |
| [From&lt;TResult>(String)][9]                                    | Creates and returns a new [SqlSet&lt;TResult>][1] using the provided table name.                |
| **From&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)** | Creates and returns a new [SqlSet&lt;TResult>][1] using the provided defining query and mapper. |


Syntax
------

```csharp
public SqlSet<TResult> From<TResult>(
	SqlBuilder definingQuery,
	Func<DbDataReader, TResult> mapper
)

```

#### Parameters

##### *definingQuery*  [SqlBuilder][10]
The SQL query that will be the source of data for the set.

##### *mapper*  [Func][11]&lt;[DbDataReader][12], **TResult**>
A custom mapper function that creates TResult instances from the rows in the set.

#### Type Parameters

##### *TResult*
The type of objects to map the results to.

#### Return Value
[SqlSet][1]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][1] object.

See Also
--------

#### Reference
[Database Class][13]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet_1/README.md
[2]: ../README.md
[3]: From.md
[4]: ../SqlSet/README.md
[5]: From_2.md
[6]: From_1.md
[7]: From_3.md
[8]: From__1.md
[9]: From__1_2.md
[10]: ../SqlBuilder/README.md
[11]: https://learn.microsoft.com/dotnet/api/system.func-2
[12]: https://learn.microsoft.com/dotnet/api/system.data.common.dbdatareader
[13]: README.md