SqlSet.CreateSet&lt;TResult> Method (SqlBuilder, Func&lt;IDataRecord, TResult>)
===============================================================================
This member supports the DbExtensions infrastructure and is not intended to be used directly from your code.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
protected virtual SqlSet<TResult> CreateSet<TResult>(
	SqlBuilder superQuery,
	Func<IDataRecord, TResult> mapper
)
```

### Parameters

#### *superQuery*
Type: [DbExtensions.SqlBuilder][2]  


#### *mapper*
Type: [System.Func][3]&lt;[IDataRecord][4], **TResult**>  



Type Parameters
---------------

#### *TResult*


### Return Value
Type: [SqlSet][5]&lt;**TResult**>

See Also
--------
[SqlSet Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: http://msdn.microsoft.com/en-us/library/bb549151
[4]: http://msdn.microsoft.com/en-us/library/93wb1heh
[5]: ../SqlSet_1/README.md
[6]: README.md