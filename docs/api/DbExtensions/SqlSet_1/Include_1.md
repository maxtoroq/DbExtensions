SqlSet&lt;TResult>.Include(String) Method
=========================================
Specifies the related objects to include in the query results.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                           | Description                                                    |
| ---------------------------------------------- | -------------------------------------------------------------- |
| **Include(String)**                            | Specifies the related objects to include in the query results. |
| [Include(Func&lt;TResult, Object>, String)][2] | Specifies the related objects to include in the query results. |


Syntax
------

```csharp
public SqlSet<TResult> Include(
	string path
)
```

#### Parameters

##### *path*  [String][3]
Dot-separated list of related objects to return in the query results.

#### Return Value
[SqlSet][4]&lt;[TResult][4]>  
A new [SqlSet&lt;TResult>][4] with the defined query path.

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
[2]: Include.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: README.md
[5]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception