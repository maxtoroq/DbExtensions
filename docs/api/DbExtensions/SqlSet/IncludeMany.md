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
	string? elementPath = null
)
```

#### Parameters

##### *path*  [String][2]
Dot-separated list of one or more related objects that ends with the collection to load.

##### *elementPath*  [String][2]  (Optional)
Dot-separated list of related objects to include in each element of the collection.

#### Return Value
[SqlSet][3]  
A new [SqlSet][3].

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][4] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception