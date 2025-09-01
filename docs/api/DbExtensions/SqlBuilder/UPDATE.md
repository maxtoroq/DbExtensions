SqlBuilder.UPDATE(SqlInterpolatedStringHandler&lt;SqlClause.UPDATE>) Method
===========================================================================
Appends the UPDATE clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                      | Description                                                                 |
| ---------------- | --------------------------------------------------------- | --------------------------------------------------------------------------- |
| ![Public method] | UPDATE(SqlInterpolatedStringHandler&lt;SqlClause.UPDATE>) | Appends the UPDATE clause using the provided interpolated string *handler*. |
| ![Public method] | [UPDATE(String)][2]                                       | Appends the UPDATE clause using the provided *text*.                        |


Syntax
------

```csharp
public SqlBuilder UPDATE(
	ref SqlInterpolatedStringHandler<SqlClause.UPDATE> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.UPDATE][3]>
The interpolated string that represents the body of the UPDATE clause.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: UPDATE_1.md
[3]: ../SqlClause_UPDATE/README.md
[4]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"