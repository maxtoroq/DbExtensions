SqlBuilder.FROM(SqlSet, String) Method
======================================
Appends the FROM clause using the provided *subQuery* as body named after *alias*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                               | Description                                                                                                                                       |
| -------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------- |
| [FROM()][2]                                        | Sets FROM as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| [FROM(SqlBuilder.ClauseStringHandler&lt;FROM>)][4] | Appends the FROM clause using the provided interpolated string *handler*.                                                                         |
| [FROM(String)][5]                                  | Appends the FROM clause using the provided *text*.                                                                                                |
| [FROM(SqlBuilder, String)][6]                      | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                |
| **FROM(SqlSet, String)**                           | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                |


Syntax
------

```csharp
public SqlBuilder FROM(
	SqlSet subQuery,
	string alias
)
```

#### Parameters

##### *subQuery*  [SqlSet][7]
The sub-query to use as the body of the FROM clause.

##### *alias*  [String][8]
The alias of the sub-query.

#### Return Value
[SqlBuilder][9]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][9]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FROM.md
[3]: _If.md
[4]: FROM_2.md
[5]: FROM_4.md
[6]: FROM_1.md
[7]: ../SqlSet/README.md
[8]: https://learn.microsoft.com/dotnet/api/system.string
[9]: README.md