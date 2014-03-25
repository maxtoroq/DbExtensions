Database.Map Method (Type, SqlBuilder)
======================================
Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public IEnumerable<Object> Map(
	Type resultType,
	SqlBuilder query
)
```

### Parameters

#### *resultType*
Type: [System.Type][2]  
The type of objects to map the results to.

#### *query*
Type: [DbExtensions.SqlBuilder][3]  
The query.

### Return Value
Type: [IEnumerable][4]&lt;[Object][5]>  
The results of the query as objects of type specified by the *resultType* parameter.

See Also
--------
[Database Class][6]  
[DbExtensions Namespace][1]  
[Extensions.Map(IDbCommand, Type, TextWriter)][7]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/42892f65
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/9eekhta0
[5]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[6]: README.md
[7]: ../Extensions/Map_7.md