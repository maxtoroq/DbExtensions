Database.Map&lt;TResult>(SqlBuilder) Method
===========================================
Maps the results of the *query* to TResult objects. The query is deferred-executed.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public IEnumerable<TResult> Map<TResult>(
	SqlBuilder query
)

```

#### Parameters

##### *query*  [SqlBuilder][2]
The query.

#### Type Parameters

##### *TResult*
The type of objects to map the results to.

#### Return Value
[IEnumerable][3]&lt;**TResult**>  
The results of the query as TResult objects.

See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[4]: README.md