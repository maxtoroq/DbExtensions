SQL.WITH(String) Method
=======================
Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *text*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                               | Description                                                                                                                          |
| -------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| [WITH(SqlBuilder.ClauseStringHandler&lt;WITH>)][3] | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided string interpolated *handler*. |
| **WITH(String)**                                   | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *text*.                        |
| [WITH(String, SqlBuilder)][4]                      | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.        |
| [WITH(String, SqlSet)][5]                          | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.        |


Syntax
------

```csharp
public static SqlBuilder WITH(
	string? text
)
```

#### Parameters

##### *text*  [String][6]
The body of the WITH clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [WITH(String)][7].

See Also
--------

#### Reference
[SQL Class][8]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: WITH.md
[4]: WITH_2.md
[5]: WITH_3.md
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: ../SqlBuilder/WITH_1.md
[8]: README.md