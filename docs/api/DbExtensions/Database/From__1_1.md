Database.From&lt;TResult> Method (SqlBuilder, Func&lt;IDataRecord, TResult>)
============================================================================
Creates and returns a new [SqlSet&lt;TResult>][1] using the provided defining query and mapper.

  **Namespace:**  [DbExtensions][2]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet<TResult> From<TResult>(
	SqlBuilder definingQuery,
	Func<IDataRecord, TResult> mapper
)

```

#### Parameters

##### *definingQuery*
Type: [DbExtensions.SqlBuilder][3]  
The SQL query that will be the source of data for the set.

##### *mapper*
Type: [System.Func][4]&lt;[IDataRecord][5], **TResult**>  
A custom mapper function that creates TResult instances from the rows in the set.

#### Type Parameters

##### *TResult*
The type of objects to map the results to.

#### Return Value
Type: [SqlSet][1]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][1] object.

See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet_1/README.md
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: https://docs.microsoft.com/dotnet/api/system.func-2
[5]: https://docs.microsoft.com/dotnet/api/system.data.idatarecord
[6]: README.md