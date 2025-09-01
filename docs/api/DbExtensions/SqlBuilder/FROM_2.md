SqlBuilder.FROM(String, Object[]) Method
========================================
Appends the FROM clause using the provided *format* string and parameters.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                          | Description                                                                        |
| ---------------- | ----------------------------- | ---------------------------------------------------------------------------------- |
| ![Public method] | [FROM(SqlBuilder, String)][2] | Appends the FROM clause using the provided *subQuery* as body named after *alias*. |
| ![Public method] | [FROM(SqlSet, String)][3]     | Appends the FROM clause using the provided *subQuery* as body named after *alias*. |
| ![Public method] | **FROM(String, Object[])**    | Appends the FROM clause using the provided *format* string and parameters.         |


Syntax
------

```csharp
public SqlBuilder FROM(
	string format,
	params Object[] args
)
```

#### Parameters

##### *format*  [String][4]
The format string that represents the body of the FROM clause.

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
[2]: FROM.md
[3]: FROM_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: https://learn.microsoft.com/dotnet/api/system.object
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"