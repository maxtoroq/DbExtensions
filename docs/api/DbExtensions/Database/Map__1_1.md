Database.Map&lt;TResult> Method (SqlBuilder, Func&lt;IDataRecord, TResult>)
===========================================================================
Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public IEnumerable<TResult> Map<TResult>(
	SqlBuilder query,
	Func<IDataRecord, TResult> mapper
)

```

### Parameters

#### *query*
Type: [DbExtensions.SqlBuilder][2]  
The query.

#### *mapper*
Type: [System.Func][3]&lt;[IDataRecord][4], **TResult**>  
The delegate for creating TResult objects from an [IDataRecord][4] object.

### Type Parameters

#### *TResult*
The type of objects to map the results to.

### Return Value
Type: [IEnumerable][5]&lt;**TResult**>  
The results of the query as TResult objects.

See Also
--------

### Reference
[Database Class][6]  
[DbExtensions Namespace][1]  
[Extensions.Map&lt;TResult>(IDbCommand, Func&lt;IDataRecord, TResult>, TextWriter)][7]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: http://msdn.microsoft.com/en-us/library/bb549151
[4]: http://msdn.microsoft.com/en-us/library/93wb1heh
[5]: http://msdn.microsoft.com/en-us/library/9eekhta0
[6]: README.md
[7]: ../Extensions/Map__1_2.md