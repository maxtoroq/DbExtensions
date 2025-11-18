SqlSet&lt;TResult>.Include(Func&lt;TResult, Object>, String) Method
===================================================================
Specifies the related objects to include in the query results.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                          | Description                                                    |
| --------------------------------------------- | -------------------------------------------------------------- |
| [Include(String)][2]                          | Specifies the related objects to include in the query results. |
| **Include(Func&lt;TResult, Object>, String)** | Specifies the related objects to include in the query results. |


Syntax
------

```csharp
public SqlSet<TResult> Include(
	Func<TResult, Object?> path,
	string pathExpr = ""
)
```

#### Parameters

##### *path*  [Func][3]&lt;[TResult][4], [Object][5]>
Lambda expression that returns the deepest related object to return in the query results.

##### *pathExpr*  [String][6]  (Optional)
This argument is compiler generated.

#### Return Value
[SqlSet][4]&lt;[TResult][4]>  
A new [SqlSet&lt;TResult>][4] with the defined query path.

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
[2]: Include_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.func-2
[4]: README.md
[5]: https://learn.microsoft.com/dotnet/api/system.object
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception