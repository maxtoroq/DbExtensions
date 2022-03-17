Database.Map Method (SqlBuilder)
================================
Maps the results of the *query* to dynamic objects. The query is deferred-executed.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public IEnumerable<Object> Map(
	SqlBuilder query
)
```

#### Parameters

##### *query*
Type: [DbExtensions.SqlBuilder][2]  
The query.

#### Return Value
Type: [IEnumerable][3]&lt;[Object][4]>  
The results of the query as dynamic objects.

See Also
--------

#### Reference
[Database Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[4]: https://docs.microsoft.com/dotnet/api/system.object
[5]: README.md