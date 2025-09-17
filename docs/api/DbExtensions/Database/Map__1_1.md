Database.Map&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>) Method
===========================================================================
Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                            | Description                                                                                                                 |
| --------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| [Map(SqlBuilder)][2]                                            | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                         |
| [Map(SqlBuilder, Type)][3]                                      | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed. |
| [Map&lt;TResult>(SqlBuilder)][4]                                | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                         |
| **Map&lt;TResult>(SqlBuilder, Func&lt;DbDataReader, TResult>)** | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                   |


Syntax
------

```csharp
public IEnumerable<TResult> Map<TResult>(
	SqlBuilder query,
	Func<DbDataReader, TResult> mapper
)

```

#### Parameters

##### *query*  [SqlBuilder][5]
The query.

##### *mapper*  [Func][6]&lt;[DbDataReader][7], **TResult**>
The delegate for creating TResult objects from an [DbDataReader][7] object.

#### Type Parameters

##### *TResult*
The type of objects to map the results to.

#### Return Value
[IEnumerable][8]&lt;**TResult**>  
The results of the query as TResult objects.

See Also
--------

#### Reference
[Database Class][9]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Map.md
[3]: Map_1.md
[4]: Map__1.md
[5]: ../SqlBuilder/README.md
[6]: https://learn.microsoft.com/dotnet/api/system.func-2
[7]: https://learn.microsoft.com/dotnet/api/system.data.common.dbdatareader
[8]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[9]: README.md