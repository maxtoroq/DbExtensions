SqlBuilder.WITH(String, Object[]) Method
========================================
Appends the WITH clause using the provided *format* string and parameters.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                          | Description                                                                        |
| ---------------- | ----------------------------- | ---------------------------------------------------------------------------------- |
| ![Public method] | [WITH(SqlBuilder, String)][2] | Appends the WITH clause using the provided *subQuery* as body named after *alias*. |
| ![Public method] | [WITH(SqlSet, String)][3]     | Appends the WITH clause using the provided *subQuery* as body named after *alias*. |
| ![Public method] | **WITH(String, Object[])**    | Appends the WITH clause using the provided *format* string and parameters.         |


Syntax
------

```csharp
public SqlBuilder WITH(
	string format,
	params Object[] args
)
```

#### Parameters

##### *format*  [String][4]
The format string that represents the body of the WITH clause.

##### *args*  [Object][5][]
The parameters of the clause body.

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
[3]: WITH_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: https://learn.microsoft.com/dotnet/api/system.object
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"