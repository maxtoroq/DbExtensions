SqlSet&lt;TResult>.Include Method
=================================
Specifies the related objects to include in the query results.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet<TResult> Include(
	string path
)
```

#### Parameters

##### *path*  [String][2]
Dot-separated list of related objects to return in the query results.

#### Return Value
[SqlSet][3]&lt;[TResult][3]>  
A new [SqlSet&lt;TResult>][3] with the defined query path.

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][4] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception