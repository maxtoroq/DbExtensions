SqlBuilder.WITH(SqlSet, String) Method
======================================
Appends the WITH clause using the provided *subQuery* as body named after *alias*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                          | Description                                                                        |
| ---------------- | ----------------------------- | ---------------------------------------------------------------------------------- |
| ![Public method] | [WITH(SqlBuilder, String)][2] | Appends the WITH clause using the provided *subQuery* as body named after *alias*. |
| ![Public method] | **WITH(SqlSet, String)**      | Appends the WITH clause using the provided *subQuery* as body named after *alias*. |
| ![Public method] | [WITH(String, Object[])][3]   | Appends the WITH clause using the provided *format* string and parameters.         |


Syntax
------

```csharp
public SqlBuilder WITH(
	SqlSet subQuery,
	string alias
)
```

#### Parameters

##### *subQuery*  [SqlSet][4]
The sub-query to use as the body of the WITH clause.

##### *alias*  [String][5]
The alias of the sub-query.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: WITH.md
[3]: WITH_2.md
[4]: ../SqlSet/README.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"