SqlBuilder.UPDATE(SqlBuilder.ClauseStringHandler&lt;SqlClause.UPDATE>) Method
=============================================================================
Appends the UPDATE clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                  | Description                                                                 |
| ----------------------------------------------------- | --------------------------------------------------------------------------- |
| **UPDATE(SqlBuilder.ClauseStringHandler&lt;UPDATE>)** | Appends the UPDATE clause using the provided interpolated string *handler*. |
| [UPDATE(String)][2]                                   | Appends the UPDATE clause using the provided *text*.                        |


Syntax
------

```csharp
public SqlBuilder UPDATE(
	ref ClauseStringHandler<UPDATE> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;UPDATE>
The interpolated string that represents the body of the UPDATE clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: UPDATE_1.md
[3]: README.md