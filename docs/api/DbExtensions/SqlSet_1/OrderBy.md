SqlSet&lt;TResult>.OrderBy(SqlSet.SqlFragmentHandler) Method
============================================================
Sorts the elements of the set according to the *columnList*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                        | Description                                                  |
| ---------------- | --------------------------- | ------------------------------------------------------------ |
| ![Public method] | OrderBy(SqlFragmentHandler) | Sorts the elements of the set according to the *columnList*. |
| ![Public method] | [OrderBy(String)][2]        | Sorts the elements of the set according to the *columnList*. |


Syntax
------

```csharp
public SqlSet<TResult> OrderBy(
	ref SqlFragmentHandler columnList
)
```

#### Parameters

##### *columnList*  SqlFragmentHandler
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
[2]: OrderBy_1.md
[3]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"