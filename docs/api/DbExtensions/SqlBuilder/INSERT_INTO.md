SqlBuilder.INSERT_INTO(SqlInterpolatedStringHandler&lt;SqlClause.INSERT_INTO>) Method
=====================================================================================
Appends the INSERT INTO clause using the provided interpolated string *handler*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                                    | Description                                                                      |
| ---------------- | ----------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| ![Public method] | **INSERT_INTO(SqlInterpolatedStringHandler&lt;SqlClause.INSERT_INTO>)** | Appends the INSERT INTO clause using the provided interpolated string *handler*. |
| ![Public method] | [INSERT_INTO(String)][2]                                                | Appends the INSERT INTO clause using the provided *text*.                        |


Syntax
------

```csharp
public SqlBuilder INSERT_INTO(
	ref SqlInterpolatedStringHandler<SqlClause.INSERT_INTO> handler
)
```

#### Parameters

##### *handler*  SqlInterpolatedStringHandler&lt;[SqlClause.INSERT_INTO][3]>
The interpolated string that represents the body of the INSERT INTO clause.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: INSERT_INTO_1.md
[3]: ../SqlClause_INSERT_INTO/README.md
[4]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"