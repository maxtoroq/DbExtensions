SQL.UPDATE(SqlBuilder.ClauseStringHandler&lt;SqlClause.UPDATE>) Method
======================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                  | Description                                                                                                                            |
| ----------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------- |
| **UPDATE(SqlBuilder.ClauseStringHandler&lt;UPDATE>)** | Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided string interpolated *handler*. |
| [UPDATE(String)][3]                                   | Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided *text*.                        |


Syntax
------

```csharp
public static SqlBuilder UPDATE(
	ref ClauseStringHandler<UPDATE> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;UPDATE>
The body of the UPDATE clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [UPDATE(SqlBuilder.ClauseStringHandler&lt;UPDATE>)][4].

See Also
--------

#### Reference
[SQL Class][5]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: UPDATE_1.md
[4]: ../SqlBuilder/UPDATE.md
[5]: README.md