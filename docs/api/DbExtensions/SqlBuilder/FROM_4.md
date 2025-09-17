SqlBuilder.FROM(String) Method
==============================
Appends the FROM clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                         | Description                                                                                                                                       |
| ------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------- |
| [FROM()][2]                                                  | Sets FROM as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| [FROM(SqlBuilder.ClauseStringHandler&lt;SqlClause.FROM>)][4] | Appends the FROM clause using the provided interpolated string *handler*.                                                                         |
| **FROM(String)**                                             | Appends the FROM clause using the provided *text*.                                                                                                |
| [FROM(SqlBuilder, String)][5]                                | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                |
| [FROM(SqlSet, String)][6]                                    | Appends the FROM clause using the provided *subQuery* as body named after *alias*.                                                                |


Syntax
------

```csharp
public SqlBuilder FROM(
	string? text
)
```

#### Parameters

##### *text*  [String][7]
The text that represents the body of the FROM clause.

#### Return Value
[SqlBuilder][8]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FROM.md
[3]: _If.md
[4]: FROM_2.md
[5]: FROM_1.md
[6]: FROM_3.md
[7]: https://learn.microsoft.com/dotnet/api/system.string
[8]: README.md