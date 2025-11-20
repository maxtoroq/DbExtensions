SqlSet&lt;TResult>.IncludeMany(String, Func&lt;SqlSet, SqlSet>) Method
======================================================================
Specifies which collections to include in the query results.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                                                                                 | Description                                                  |
| ------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------ |
| **IncludeMany(String, Func&lt;SqlSet, SqlSet>)**                                                                                     | Specifies which collections to include in the query results. |
| [IncludeMany&lt;TElement>(Func&lt;TResult, ICollection&lt;TElement>>, Func&lt;SqlSet&lt;TElement>, SqlSet&lt;TElement>>, String)][2] | Specifies which collections to include in the query results. |


Syntax
------

```csharp
public SqlSet<TResult> IncludeMany(
	string path,
	Func<SqlSet, SqlSet>? manySetup = null
)
```

#### Parameters

##### *path*  [String][3]
Dot-separated list of one or more related objects that ends with the collection to load.

##### *manySetup*  [Func][4]&lt;[SqlSet][5], [SqlSet][5]>  (Optional)
A function to customize how the collection is loaded.

#### Return Value
[SqlSet][6]&lt;[TResult][6]>  
A new [SqlSet&lt;TResult>][6].

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][7] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: IncludeMany__1.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: https://learn.microsoft.com/dotnet/api/system.func-2
[5]: ../SqlSet/README.md
[6]: README.md
[7]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception