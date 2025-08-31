SqlSet.Select&lt;TResult>(SqlSet.SqlFragmentHandler, Func&lt;IDataRecord, TResult>) Method
==========================================================================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	ref SqlFragmentHandler columnList,
	Func<IDataRecord, TResult> mapper
)

```

#### Parameters

##### *columnList*  SqlFragmentHandler
The list of columns that are used by *mapper*.

##### *mapper*  [Func][2]&lt;[IDataRecord][3], **TResult**>
A custom mapper function that creates TResult instances from the rows in the set.

#### Type Parameters

##### *TResult*
The type that *mapper* returns.

#### Return Value
[SqlSet][4]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][4].

See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.func-2
[3]: https://learn.microsoft.com/dotnet/api/system.data.idatarecord
[4]: ../SqlSet_1/README.md
[5]: README.md