Database.Map Method (SqlBuilder)
================================
Maps the results of the *query* to dynamic objects. The query is deferred-executed.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public IEnumerable<Object> Map(
	SqlBuilder query
)
```

### Parameters

#### *query*
Type: [DbExtensions.SqlBuilder][2]  
The query.

### Return Value
Type: [IEnumerable][3]&lt;[Object][4]>  
The results of the query as dynamic objects.

See Also
--------
[Database Class][5]  
[DbExtensions Namespace][1]  
[Extensions.Map(IDbCommand, TextWriter)][6]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: http://msdn.microsoft.com/en-us/library/9eekhta0
[4]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[5]: README.md
[6]: ../Extensions/Map_1.md