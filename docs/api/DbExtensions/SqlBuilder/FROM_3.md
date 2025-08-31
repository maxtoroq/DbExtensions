SqlBuilder.FROM(SqlSet, String) Method
======================================
Appends the FROM clause using the provided *subQuery* as body named after *alias*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder FROM(
	SqlSet subQuery,
	string alias
)
```

#### Parameters

##### *subQuery*  [SqlSet][2]
The sub-query to use as the body of the FROM clause.

##### *alias*  [String][3]
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
[2]: ../SqlSet/README.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: README.md