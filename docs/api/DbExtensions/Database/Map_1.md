Database.Map Method (Type, SqlBuilder)
======================================
Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public IEnumerable<Object> Map(
	Type resultType,
	SqlBuilder query
)
```

#### Parameters

##### *resultType*
Type: [System.Type][2]  
The type of objects to map the results to.

##### *query*
Type: [DbExtensions.SqlBuilder][3]  
The query.

#### Return Value
Type: [IEnumerable][4]&lt;[Object][5]>  
The results of the query as objects of type specified by the *resultType* parameter.

See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.type
[3]: ../SqlBuilder/README.md
[4]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[5]: https://docs.microsoft.com/dotnet/api/system.object
[6]: README.md