SqlSet&lt;TResult>.IncludeMany(String, String) Method
=====================================================
Specifies which collections to include in the query results.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                                                                 | Description                                                  |
| -------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------ |
| **IncludeMany(String, String)**                                                                                      | Specifies which collections to include in the query results. |
| [IncludeMany&lt;TElement>(Func&lt;TResult, ICollection&lt;TElement>>, Func&lt;TElement, Object>, String, String)][2] | Specifies which collections to include in the query results. |


Syntax
------

```csharp
public SqlSet<TResult> IncludeMany(
	string path,
	string? elementPath = null
)
```

#### Parameters

##### *path*  [String][3]
Dot-separated list of one or more related objects that ends with the collection to load.

##### *elementPath*  [String][3]  (Optional)
Dot-separated list of related objects to include in each element of the collection.

#### Return Value
[SqlSet][4]&lt;[TResult][4]>  
A new [SqlSet&lt;TResult>][4].

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][5] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: IncludeMany__1.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: README.md
[5]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception