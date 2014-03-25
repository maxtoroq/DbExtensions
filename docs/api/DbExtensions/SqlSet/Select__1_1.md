SqlSet.Select&lt;TResult> Method (Func&lt;IDataRecord, TResult>, String, Object[])
==================================================================================
Projects each element of the set into a new form.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	Func<IDataRecord, TResult> mapper,
	string columnList,
	params Object[] parameters
)
```

### Parameters

#### *mapper*
Type: [System.Func][2]&lt;[IDataRecord][3], **TResult**>  
A custom mapper function that creates TResult instances from the rows in the set.

#### *columnList*
Type: [System.String][4]  
The list of columns that are used by *mapper*.

#### *parameters*
Type: [System.Object][5][]  
The parameters to apply to the *columnList*.


Type Parameters
---------------

#### *TResult*
The type that *mapper* returns.

### Return Value
Type: [SqlSet][6]&lt;**TResult**>  
A new [SqlSet<TResult>][6].

See Also
--------
[SqlSet Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/bb549151
[3]: http://msdn.microsoft.com/en-us/library/93wb1heh
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[6]: ../SqlSet_1/README.md
[7]: README.md