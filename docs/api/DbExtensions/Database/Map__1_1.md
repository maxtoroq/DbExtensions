Database.Map&lt;TResult> Method (SqlBuilder, Func&lt;IDataRecord, TResult>)
===========================================================================
Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public IEnumerable<TResult> Map<TResult>(
	SqlBuilder query,
	Func<IDataRecord, TResult> mapper
)

```

#### Parameters

##### *query*
Type: [DbExtensions.SqlBuilder][2]  
The query.

##### *mapper*
Type: [System.Func][3]&lt;[IDataRecord][4], **TResult**>  
The delegate for creating TResult objects from an [IDataRecord][4] object.

#### Type Parameters

##### *TResult*
The type of objects to map the results to.

#### Return Value
Type: [IEnumerable][5]&lt;**TResult**>  
The results of the query as TResult objects.

See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: https://docs.microsoft.com/dotnet/api/system.func-2
[4]: https://docs.microsoft.com/dotnet/api/system.data.idatarecord
[5]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[6]: README.md