SqlSet.Select&lt;TResult> Method (Func&lt;IDataRecord, TResult>, String)
========================================================================
Projects each element of the set into a new form.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	Func<IDataRecord, TResult> mapper,
	string columnList
)
```

### Parameters

#### *mapper*
Type: [System.Func][2]&lt;[IDataRecord][3], **TResult**>  
A custom mapper function that creates TResult instances from the rows in the set.

#### *columnList*
Type: [System.String][4]  
The list of columns that are used by *mapper*.


Type Parameters
---------------

#### *TResult*
The type that *mapper* returns.

### Return Value
Type: [SqlSet][5]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][5].

See Also
--------
[SqlSet Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/bb549151
[3]: http://msdn.microsoft.com/en-us/library/93wb1heh
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: ../SqlSet_1/README.md
[6]: README.md