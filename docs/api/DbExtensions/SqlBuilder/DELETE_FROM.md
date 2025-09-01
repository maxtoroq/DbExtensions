SqlBuilder.DELETE_FROM(SqlInterpolatedStringHandler&lt;SqlClause.DELETE_FROM>) Method
=====================================================================================
Appends the DELETE FROM clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                                    | Description                                                                      |
| ---------------- | ----------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| ![Public method] | **DELETE_FROM(SqlInterpolatedStringHandler&lt;SqlClause.DELETE_FROM>)** | Appends the DELETE FROM clause using the provided interpolated string *handler*. |
| ![Public method] | [DELETE_FROM(String)][2]                                                | Appends the DELETE FROM clause using the provided *text*.                        |


Syntax
------

```csharp
public SqlBuilder DELETE_FROM(
	ref SqlInterpolatedStringHandler<SqlClause.DELETE_FROM> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.DELETE_FROM][3]>
The interpolated string that represents the body of the DELETE FROM clause.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: DELETE_FROM_1.md
[3]: ../SqlClause_DELETE_FROM/README.md
[4]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"