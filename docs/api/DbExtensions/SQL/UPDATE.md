SQL.UPDATE(SqlInterpolatedStringHandler&lt;SqlClause.UPDATE>) Method
====================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                                  | Name                                                      | Description                                                                                                                            |
| -------------------------------- | --------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]![Static member] | UPDATE(SqlInterpolatedStringHandler&lt;SqlClause.UPDATE>) | Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided string interpolated *handler*. |
| ![Public method]![Static member] | [UPDATE(String)][3]                                       | Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided *text*.                        |


Syntax
------

```csharp
public static SqlBuilder UPDATE(
	ref SqlInterpolatedStringHandler<SqlClause.UPDATE> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.UPDATE][4]>
The body of the UPDATE clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [UPDATE(SqlInterpolatedStringHandler&lt;SqlClause.UPDATE>)][5].

See Also
--------

#### Reference
[SQL Class][6]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: UPDATE_1.md
[4]: ../SqlClause_UPDATE/README.md
[5]: ../SqlBuilder/UPDATE.md
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/Static.gif "Static member"