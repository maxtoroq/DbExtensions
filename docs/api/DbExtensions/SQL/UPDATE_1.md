SQL.UPDATE(String) Method
=========================
Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided *text*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                   | Description                                                                                                                            |
| ------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------- |
| [UPDATE(SqlBuilder.ClauseStringHandler&lt;UPDATE>)][3] | Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided string interpolated *handler*. |
| **UPDATE(String)**                                     | Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided *text*.                        |


Syntax
------

```csharp
public static SqlBuilder UPDATE(
	string? text
)
```

#### Parameters

##### *text*  [String][4]
The body of the UPDATE clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [UPDATE(String)][5].

See Also
--------

#### Reference
[SQL Class][6]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: UPDATE.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: ../SqlBuilder/UPDATE_1.md
[6]: README.md