SqlBuilder.WITH(String, SqlSet) Method
======================================
Appends the WITH clause using the provided *subQuery* as body named after *alias*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder WITH(
	string alias,
	SqlSet subQuery
)
```

#### Parameters

##### *alias*  [String][2]
The alias of the sub-query.

##### *subQuery*  [SqlSet][3]
The sub-query to use as the body of the WITH clause.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: ../SqlSet/README.md
[4]: README.md