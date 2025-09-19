SQL.DELETE_FROM(String) Method
==============================
Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided *text*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                                                                                                                 |
| ---------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
| [DELETE_FROM(SqlBuilder.ClauseStringHandler&lt;DELETE_FROM>)][3] | Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided string interpolated *handler*. |
| **DELETE_FROM(String)**                                          | Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided *text*.                        |


Syntax
------

```csharp
public static SqlBuilder DELETE_FROM(
	string? text
)
```

#### Parameters

##### *text*  [String][4]
The body of the DELETE FROM clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [DELETE_FROM(String)][5].

See Also
--------

#### Reference
[SQL Class][6]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: DELETE_FROM.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: ../SqlBuilder/DELETE_FROM_1.md
[6]: README.md