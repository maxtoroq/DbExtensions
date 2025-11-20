SqlSet&lt;TResult>.IncludeMany&lt;TElement>(Func&lt;TResult, ICollection&lt;TElement>>, Func&lt;SqlSet&lt;TElement>, SqlSet&lt;TElement>>, String) Method
=========================================================================================================================================================
Specifies which collections to include in the query results.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                                                                                | Description                                                  |
| ----------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------ |
| [IncludeMany(String, Func&lt;SqlSet, SqlSet>)][2]                                                                                   | Specifies which collections to include in the query results. |
| **IncludeMany&lt;TElement>(Func&lt;TResult, ICollection&lt;TElement>>, Func&lt;SqlSet&lt;TElement>, SqlSet&lt;TElement>>, String)** | Specifies which collections to include in the query results. |


Syntax
------

```csharp
public SqlSet<TResult> IncludeMany<TElement>(
	Func<TResult, ICollection<TElement>?> path,
	Func<SqlSet<TElement>, SqlSet<TElement>>? manySetup = null,
	string pathExpr = ""
)

```

#### Parameters

##### *path*  [Func][3]&lt;[TResult][4], [ICollection][5]&lt;**TElement**>>
Lambda expression that returns the collection to load.

##### *manySetup*  [Func][3]&lt;[SqlSet][4]&lt;**TElement**>, [SqlSet][4]&lt;**TElement**>>  (Optional)
A function to customize how the collection is loaded.

##### *pathExpr*  [String][6]  (Optional)
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
| [InvalidOperationException][7] | This method can only be used on sets where the result type is an annotated class. |


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
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception