SqlBuilder.FROM(SqlBuilder, String) Method
==========================================
Appends the FROM clause using the provided *subQuery* as body named after *alias*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                         | Description                                                                        |
| ---------------- | ---------------------------- | ---------------------------------------------------------------------------------- |
| ![Public method] | **FROM(SqlBuilder, String)** | Appends the FROM clause using the provided *subQuery* as body named after *alias*. |
| ![Public method] | [FROM(SqlSet, String)][2]    | Appends the FROM clause using the provided *subQuery* as body named after *alias*. |
| ![Public method] | [FROM(String, Object[])][3]  | Appends the FROM clause using the provided *format* string and parameters.         |


Syntax
------

```csharp
public SqlBuilder FROM(
	SqlBuilder subQuery,
	string alias
)
```

#### Parameters

##### *subQuery*  [SqlBuilder][4]
The sub-query to use as the body of the FROM clause.

##### *alias*  [String][5]
The alias of the sub-query.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: FROM_1.md
[3]: FROM_2.md
[4]: README.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[Public method]: ../../icons/pubmethod.svg "Public method"