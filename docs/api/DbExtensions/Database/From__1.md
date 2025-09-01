Database.From&lt;TResult>(SqlBuilder) Method
============================================
Creates and returns a new [SqlSet&lt;TResult>][1] using the provided defining query.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                             | Description                                                                                     |
| ---------------- | ---------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| ![Public method] | [From(SqlBuilder)][3]                                            | Creates and returns a new [SqlSet][4] using the provided defining query.                        |
| ![Public method] | [From(String)][5]                                                | Creates and returns a new [SqlSet][4] using the provided table name.                            |
| ![Public method] | [From(SqlBuilder, Type)][6]                                      | Creates and returns a new [SqlSet][4] using the provided defining query.                        |
| ![Public method] | [From(String, Type)][7]                                          | Creates and returns a new [SqlSet][4] using the provided table name.                            |
| ![Public method] | **From&lt;TResult>(SqlBuilder)**                                 | Creates and returns a new [SqlSet&lt;TResult>][1] using the provided defining query.            |
| ![Public method] | [From&lt;TResult>(String)][8]                                    | Creates and returns a new [SqlSet&lt;TResult>][1] using the provided table name.                |
| ![Public method] | [From&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][9] | Creates and returns a new [SqlSet&lt;TResult>][1] using the provided defining query and mapper. |


Syntax
------

```csharp
public SqlSet<TResult> From<TResult>(
	SqlBuilder definingQuery
)

```

#### Parameters

##### *definingQuery*  [SqlBuilder][10]
The SQL query that will be the source of data for the set.

#### Type Parameters

##### *TResult*
The type of objects to map the results to.

#### Return Value
[SqlSet][1]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][1] object.

See Also
--------

#### Reference
[Database Class][11]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet_1/README.md
[2]: ../README.md
[3]: From.md
[4]: ../SqlSet/README.md
[5]: From_2.md
[6]: From_1.md
[7]: From_3.md
[8]: From__1_2.md
[9]: From__1_1.md
[10]: ../SqlBuilder/README.md
[11]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"