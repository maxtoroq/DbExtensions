SQL.WITH(String, SqlBuilder) Method
===================================
Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static SqlBuilder WITH(
	string alias,
	SqlBuilder subQuery
)
```

#### Parameters

##### *alias*  [String][3]
The alias of the sub-query.

##### *subQuery*  [SqlBuilder][1]
The sub-query to use as the body of the WITH clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [WITH(String, SqlBuilder)][4].

See Also
--------

#### Reference
[SQL Class][5]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: ../SqlBuilder/WITH_2.md
[5]: README.md