Database.From(String, Type) Method
==================================
Creates and returns a new [SqlSet][1] using the provided table name.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet From(
	string tableName,
	Type? resultType
)
```

#### Parameters

##### *tableName*  [String][3]
The name of the table that will be the source of data for the set.

##### *resultType*  [Type][4]
The type of objects to map the results to.

#### Return Value
[SqlSet][1]  
A new [SqlSet][1] object.

See Also
--------

#### Reference
[Database Class][5]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet/README.md
[2]: ../README.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: https://learn.microsoft.com/dotnet/api/system.type
[5]: README.md