SqlSet&lt;TResult>.IncludeMany&lt;TElement>(Func&lt;TResult, ICollection&lt;TElement>>, Func&lt;TElement, Object>, String, String) Method
=========================================================================================================================================
Specifies which collections to include in the query results.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                                                                | Description                                                  |
| ------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------ |
| [IncludeMany(String, String)][2]                                                                                    | Specifies which collections to include in the query results. |
| **IncludeMany&lt;TElement>(Func&lt;TResult, ICollection&lt;TElement>>, Func&lt;TElement, Object>, String, String)** | Specifies which collections to include in the query results. |


Syntax
------

```csharp
public SqlSet<TResult> IncludeMany<TElement>(
	Func<TResult, ICollection<TElement>?> path,
	Func<TElement, Object?>? elementPath = null,
	string pathExpr = "",
	string elementPathExpr = ""
)

```

#### Parameters

##### *path*  [Func][3]&lt;[TResult][4], [ICollection][5]&lt;**TElement**>>
Lambda expression that returns the collection to load.

##### *elementPath*  [Func][3]&lt;**TElement**, [Object][6]>  (Optional)
Lambda expression that returns the deepest related object to include in each element of the collection.

##### *pathExpr*  [String][7]  (Optional)
This argument is compiler generated.

##### *elementPathExpr*  [String][7]  (Optional)
This argument is compiler generated.

#### Type Parameters

##### *TElement*
The type of objects the collection holds.

#### Return Value
[SqlSet][4]&lt;[TResult][4]>  
A new [SqlSet&lt;TResult>][4].

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][8] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: IncludeMany.md
[3]: https://learn.microsoft.com/dotnet/api/system.func-2
[4]: README.md
[5]: https://learn.microsoft.com/dotnet/api/system.collections.generic.icollection-1
[6]: https://learn.microsoft.com/dotnet/api/system.object
[7]: https://learn.microsoft.com/dotnet/api/system.string
[8]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception