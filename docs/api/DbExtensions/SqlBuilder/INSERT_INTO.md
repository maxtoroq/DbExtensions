SqlBuilder.INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;SqlClause.INSERT_INTO>) Method
=======================================================================================
Appends the INSERT INTO clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                            | Description                                                                      |
| --------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| **INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;INSERT_INTO>)** | Appends the INSERT INTO clause using the provided interpolated string *handler*. |
| [INSERT_INTO(String)][2]                                        | Appends the INSERT INTO clause using the provided *text*.                        |


Syntax
------

```csharp
public SqlBuilder INSERT_INTO(
	ref ClauseStringHandler<INSERT_INTO> handler
)
```

#### Parameters

##### *handler*  ClauseStringHandler&lt;INSERT_INTO>
The interpolated string that represents the body of the INSERT INTO clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: INSERT_INTO_1.md
[3]: README.md