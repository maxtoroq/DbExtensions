Database.From&lt;TResult> Method (String)
=========================================
Creates and returns a new [SqlSet&lt;TResult>][1] using the provided table name.

  **Namespace:**  [DbExtensions][2]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet<TResult> From<TResult>(
	string tableName
)

```

#### Parameters

##### *tableName*
Type: [System.String][3]  
The name of the table that will be the source of data for the set.

#### Type Parameters

##### *TResult*
The type of objects to map the results to.

#### Return Value
Type: [SqlSet][1]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][1] object.

See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet_1/README.md
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/system.string
[4]: README.md