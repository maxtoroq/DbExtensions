SqlBuilder.FROM(SqlBuilder, String) Method
==========================================
Appends the FROM clause using the provided *subQuery* as body named after *alias*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder FROM(
	SqlBuilder subQuery,
	string alias
)
```

#### Parameters

##### *subQuery*  [SqlBuilder][2]
The sub-query to use as the body of the FROM clause.

##### *alias*  [String][3]
The alias of the sub-query.

#### Return Value
[SqlBuilder][2]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: https://learn.microsoft.com/dotnet/api/system.string