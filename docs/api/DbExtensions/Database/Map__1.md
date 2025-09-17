Database.Map&lt;TResult>(SqlBuilder) Method
===========================================
Maps the results of the *query* to TResult objects. The query is deferred-executed.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                                                                                                 |
| ---------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| [Map(SqlBuilder)][2]                                             | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                         |
| [Map(SqlBuilder, Type)][3]                                       | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed. |
| **Map&lt;TResult>(SqlBuilder)**                                  | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                         |
| [Map&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)][4] | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                   |


Syntax
------

```csharp
public IEnumerable<TResult> Map<TResult>(
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
[IEnumerable][6]&lt;**TResult**>  
The results of the query as TResult objects.

See Also
--------

#### Reference
[Database Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Map.md
[3]: Map_1.md
[4]: Map__1_1.md
[5]: ../SqlBuilder/README.md
[6]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[7]: README.md