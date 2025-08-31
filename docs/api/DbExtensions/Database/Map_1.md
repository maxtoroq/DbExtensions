Database.Map(SqlBuilder, Type) Method
=====================================
Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public IEnumerable<Object> Map(
	SqlBuilder query,
	Type resultType
)
```

#### Parameters

##### *query*  [SqlBuilder][2]
The query.

##### *resultType*  [Type][3]
The type of objects to map the results to.

#### Return Value
[IEnumerable][4]&lt;[Object][5]>  
The results of the query as objects of type specified by the *resultType* parameter.

See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: https://learn.microsoft.com/dotnet/api/system.type
[4]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[5]: https://learn.microsoft.com/dotnet/api/system.object
[6]: README.md