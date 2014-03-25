SqlSet.Select&lt;TResult> Method (String)
=========================================
Projects each element of the set into a new form.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	string columnList
)
```

### Parameters

#### *columnList*
Type: [System.String][2]  
The list of columns that maps to properties on TResult.


Type Parameters
---------------

#### *TResult*
The type that *columnList* maps to.

### Return Value
Type: [SqlSet][3]&lt;**TResult**>  
A new [SqlSet<TResult>][3].

See Also
--------
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../SqlSet_1/README.md
[4]: README.md