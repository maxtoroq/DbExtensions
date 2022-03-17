SqlSet.Select&lt;TResult> Method (Func&lt;IDataRecord, TResult>, String, Object[])
==================================================================================
Projects each element of the set into a new form.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	Func<IDataRecord, TResult> mapper,
	string columnList,
	params Object[] parameters
)

```

#### Parameters

##### *mapper*
Type: [System.Func][2]&lt;[IDataRecord][3], **TResult**>  
A custom mapper function that creates TResult instances from the rows in the set.

##### *columnList*
Type: [System.String][4]  
The list of columns that are used by *mapper*.

##### *parameters*
Type: [System.Object][5][]  
The parameters to apply to the *columnList*.

#### Type Parameters

##### *TResult*
The type that *mapper* returns.

#### Return Value
Type: [SqlSet][6]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][6].

See Also
--------

#### Reference
[SqlSet Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.func-2
[3]: https://docs.microsoft.com/dotnet/api/system.data.idatarecord
[4]: https://docs.microsoft.com/dotnet/api/system.string
[5]: https://docs.microsoft.com/dotnet/api/system.object
[6]: ../SqlSet_1/README.md
[7]: README.md