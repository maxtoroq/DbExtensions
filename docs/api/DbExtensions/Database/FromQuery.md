Database.FromQuery(SqlBuilder) Method
=====================================
Creates and returns a new [SqlSet][1] using the provided defining query.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                   | Description                                                                                     |
| ---------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| **FromQuery(SqlBuilder)**                                              | Creates and returns a new [SqlSet][1] using the provided defining query.                        |
| [FromQuery(SqlBuilder, Type)][3]                                       | Creates and returns a new [SqlSet][1] using the provided defining query.                        |
| [FromQuery&lt;TResult>(SqlBuilder)][4]                                 | Creates and returns a new [SqlSet&lt;TResult>][5] using the provided defining query.            |
| [FromQuery&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)][6] | Creates and returns a new [SqlSet&lt;TResult>][5] using the provided defining query and mapper. |


Syntax
------

```csharp
public SqlSet FromQuery(
	SqlBuilder definingQuery
)
```

#### Parameters

##### *definingQuery*  [SqlBuilder][7]
The SQL query that will be the source of data for the set.

#### Return Value
[SqlSet][1]  
A new [SqlSet][1] object.

See Also
--------

#### Reference
[Database Class][8]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet/README.md
[2]: ../README.md
[3]: FromQuery_1.md
[4]: FromQuery__1.md
[5]: ../SqlSet_1/README.md
[6]: FromQuery__1_1.md
[7]: ../SqlBuilder/README.md
[8]: README.md