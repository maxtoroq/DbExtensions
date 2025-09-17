Database.AsyncMap&lt;TResult>(SqlBuilder) Method
================================================
Maps the results of the *query* to TResult objects. The query is deferred-executed.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                  | Description                                                                                                                 |
| --------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| [AsyncMap(SqlBuilder)][2]                                             | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                         |
| [AsyncMap(SqlBuilder, Type)][3]                                       | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed. |
| **AsyncMap&lt;TResult>(SqlBuilder)**                                  | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                         |
| [AsyncMap&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)][4] | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                   |


Syntax
------

```csharp
public IAsyncEnumerable<TResult> AsyncMap<TResult>(
	SqlBuilder query
)

```

#### Parameters

##### *query*  [SqlBuilder][5]
The query.

#### Type Parameters

##### *TResult*
The type of objects to map the results to.

#### Return Value
[IAsyncEnumerable][6]&lt;**TResult**>  
The results of the query as TResult objects.

See Also
--------

#### Reference
[Database Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: AsyncMap.md
[3]: AsyncMap_1.md
[4]: AsyncMap__1_1.md
[5]: ../SqlBuilder/README.md
[6]: https://learn.microsoft.com/dotnet/api/system.collections.generic.iasyncenumerable-1
[7]: README.md