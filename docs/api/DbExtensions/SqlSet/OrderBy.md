SqlSet.OrderBy(SqlSet.SqlFragmentHandler) Method
================================================
Sorts the elements of the set according to the *columnList*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet OrderBy(
	ref SqlFragmentHandler columnList
)
```

#### Parameters

##### *columnList*  SqlFragmentHandler
The list of columns to base the sort on.

#### Return Value
[SqlSet][2]  
A new [SqlSet][2] whose elements are sorted according to *columnList*.

See Also
--------

#### Reference
[SqlSet Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md