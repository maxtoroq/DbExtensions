Database.AsyncMap(SqlBuilder) Method
====================================
Maps the results of the *query* to dynamic objects. The query is deferred-executed.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                  | Description                                                                                                                 |
| --------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| **AsyncMap(SqlBuilder)**                                              | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                         |
| [AsyncMap(SqlBuilder, Type)][2]                                       | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed. |
| [AsyncMap&lt;TResult>(SqlBuilder)][3]                                 | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                         |
| [AsyncMap&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)][4] | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                   |


Syntax
------

```csharp
public IAsyncEnumerable<Object> AsyncMap(
	SqlBuilder query
)
```

#### Parameters

##### *query*  [SqlBuilder][5]
The query.

#### Return Value
[IAsyncEnumerable][6]&lt;[Object][7]>  
The results of the query as dynamic objects.

See Also
--------

#### Reference
[Database Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AsyncMap_1.md
[3]: AsyncMap__1.md
[4]: AsyncMap__1_1.md
[5]: ../SqlBuilder/README.md
[6]: https://learn.microsoft.com/dotnet/api/system.collections.generic.iasyncenumerable-1
[7]: https://learn.microsoft.com/dotnet/api/system.object
[8]: README.md