SqlSet.Select&lt;TResult>(String, Func&lt;IDataRecord, TResult>) Method
=======================================================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	string columnList,
	Func<IDataRecord, TResult> mapper
)

```

#### Parameters

##### *columnList*  [String][2]
The list of columns that are used by *mapper*.

##### *mapper*  [Func][3]&lt;[IDataRecord][4], **TResult**>
A custom mapper function that creates TResult instances from the rows in the set.

#### Type Parameters

##### *TResult*
The type that *mapper* returns.

#### Return Value
[SqlSet][5]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][5].

See Also
--------

#### Reference
[SqlSet Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: https://learn.microsoft.com/dotnet/api/system.func-2
[4]: https://learn.microsoft.com/dotnet/api/system.data.idatarecord
[5]: ../SqlSet_1/README.md
[6]: README.md