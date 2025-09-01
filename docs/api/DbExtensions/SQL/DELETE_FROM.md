SQL.DELETE_FROM(SqlInterpolatedStringHandler&lt;SqlClause.DELETE_FROM>) Method
==============================================================================
Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided string interpolated *handler*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                                  | Name                                                                    | Description                                                                                                                                 |
| -------------------------------- | ----------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]![Static member] | **DELETE_FROM(SqlInterpolatedStringHandler&lt;SqlClause.DELETE_FROM>)** | Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided string interpolated *handler*. |
| ![Public method]![Static member] | [DELETE_FROM(String)][3]                                                | Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided *text*.                        |


Syntax
------

```csharp
public static SqlBuilder DELETE_FROM(
	ref SqlInterpolatedStringHandler<SqlClause.DELETE_FROM> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.DELETE_FROM][4]>
The body of the DELETE FROM clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [DELETE_FROM(SqlInterpolatedStringHandler&lt;SqlClause.DELETE_FROM>)][5].

See Also
--------

#### Reference
[SQL Class][6]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: DELETE_FROM_1.md
[4]: ../SqlClause_DELETE_FROM/README.md
[5]: ../SqlBuilder/DELETE_FROM.md
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/Static.gif "Static member"