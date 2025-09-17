SqlBuilder.VALUES(Object[]) Method
==================================
Appends the VALUES clause using the provided parameters.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                                                 |
| ---------------------------------------------------------------- | --------------------------------------------------------------------------- |
| [VALUES(SqlBuilder.ClauseStringHandler&lt;SqlClause.VALUES>)][2] | Appends the VALUES clause using the provided interpolated string *handler*. |
| **VALUES(Object[])**                                             | Appends the VALUES clause using the provided parameters.                    |


Syntax
------

```csharp
public SqlBuilder VALUES(
	params Object?[] args
)
```

#### Parameters

##### *args*  [Object][3][]
The parameters of the clause body.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: VALUES.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: README.md