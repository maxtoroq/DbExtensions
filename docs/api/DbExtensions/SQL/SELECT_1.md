SQL.SELECT(String) Method
=========================
Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided *text*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                   | Description                                                                                                                            |
| ------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------- |
| [SELECT(SqlBuilder.ClauseStringHandler&lt;SELECT>)][3] | Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided string interpolated *handler*. |
| **SELECT(String)**                                     | Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided *text*.                        |


Syntax
------

```csharp
public static SqlBuilder SELECT(
	string? text
)
```

#### Parameters

##### *text*  [String][4]
The body of the SELECT clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [SELECT(String)][5].

See Also
--------

#### Reference
[SQL Class][6]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: SELECT.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: ../SqlBuilder/SELECT_2.md
[6]: README.md