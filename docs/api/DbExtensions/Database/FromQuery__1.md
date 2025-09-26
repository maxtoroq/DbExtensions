Database.FromQuery&lt;TResult>(SqlBuilder) Method
=================================================
Creates and returns a new [SqlSet&lt;TResult>][1] using the provided defining query.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                   | Description                                                                                     |
| ---------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| [FromQuery(SqlBuilder)][3]                                             | Creates and returns a new [SqlSet][4] using the provided defining query.                        |
| [FromQuery(SqlBuilder, Type)][5]                                       | Creates and returns a new [SqlSet][4] using the provided defining query.                        |
| **FromQuery&lt;TResult>(SqlBuilder)**                                  | Creates and returns a new [SqlSet&lt;TResult>][1] using the provided defining query.            |
| [FromQuery&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)][6] | Creates and returns a new [SqlSet&lt;TResult>][1] using the provided defining query and mapper. |


Syntax
------

```csharp
public SqlSet<TResult> FromQuery<TResult>(
	SqlBuilder definingQuery
)

```

#### Parameters

##### *definingQuery*  [SqlBuilder][7]
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
[Database Class][8]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet_1/README.md
[2]: ../README.md
[3]: FromQuery.md
[4]: ../SqlSet/README.md
[5]: FromQuery_1.md
[6]: FromQuery__1_1.md
[7]: ../SqlBuilder/README.md
[8]: README.md