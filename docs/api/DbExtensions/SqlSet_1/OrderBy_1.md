SqlSet&lt;TResult>.OrderBy(String) Method
=========================================
Sorts the elements of the set according to the *columnList*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet<TResult> OrderBy(
	string columnList
)
```

#### Parameters

##### *columnList*  [String][2]
The list of columns to base the sort on.

#### Return Value
[SqlSet][3]&lt;[TResult][3]>  
A new [SqlSet&lt;TResult>][3] whose elements are sorted according to *columnList*.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: README.md