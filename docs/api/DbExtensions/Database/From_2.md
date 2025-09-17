Database.From(String) Method
============================
Creates and returns a new [SqlSet][1] using the provided table name.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                              | Description                                                                                     |
| ----------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| [From(SqlBuilder)][3]                                             | Creates and returns a new [SqlSet][1] using the provided defining query.                        |
| **From(String)**                                                  | Creates and returns a new [SqlSet][1] using the provided table name.                            |
| [From(SqlBuilder, Type)][4]                                       | Creates and returns a new [SqlSet][1] using the provided defining query.                        |
| [From(String, Type)][5]                                           | Creates and returns a new [SqlSet][1] using the provided table name.                            |
| [From&lt;TResult>(SqlBuilder)][6]                                 | Creates and returns a new [SqlSet&lt;TResult>][7] using the provided defining query.            |
| [From&lt;TResult>(String)][8]                                     | Creates and returns a new [SqlSet&lt;TResult>][7] using the provided table name.                |
| [From&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)][9] | Creates and returns a new [SqlSet&lt;TResult>][7] using the provided defining query and mapper. |


Syntax
------

```csharp
public SqlSet From(
	string tableName
)
```

#### Parameters

##### *tableName*  [String][10]
The name of the table that will be the source of data for the set.

#### Return Value
[SqlSet][1]  
A new [SqlSet][1] object.

See Also
--------

#### Reference
[Database Class][11]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet/README.md
[2]: ../README.md
[3]: From.md
[4]: From_1.md
[5]: From_3.md
[6]: From__1.md
[7]: ../SqlSet_1/README.md
[8]: From__1_2.md
[9]: From__1_1.md
[10]: https://learn.microsoft.com/dotnet/api/system.string
[11]: README.md