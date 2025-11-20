SqlSet.IncludeMany Method
=========================
Specifies which collections to include in the query results.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet IncludeMany(
	string path,
	Func<SqlSet, SqlSet>? manySetup = null
)
```

#### Parameters

##### *path*  [String][2]
Dot-separated list of one or more related objects that ends with the collection to load.

##### *manySetup*  [Func][3]&lt;[SqlSet][4], [SqlSet][4]>  (Optional)
A function to customize how the collection is loaded.

#### Return Value
[SqlSet][4]  
A new [SqlSet][4].

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][5] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: https://learn.microsoft.com/dotnet/api/system.func-2
[4]: README.md
[5]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception