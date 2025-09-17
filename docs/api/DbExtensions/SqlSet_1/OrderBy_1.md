SqlSet&lt;TResult>.OrderBy(String) Method
=========================================
Sorts the elements of the set according to the *columnList*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                | Description                                                  |
| ----------------------------------- | ------------------------------------------------------------ |
| [OrderBy(OperatorStringHandler)][2] | Sorts the elements of the set according to the *columnList*. |
| **OrderBy(String)**                 | Sorts the elements of the set according to the *columnList*. |


Syntax
------

```csharp
public SqlSet<TResult> OrderBy(
	string columnList
)
```

#### Parameters

##### *columnList*  [String][3]
The list of columns to base the sort on.

#### Return Value
[SqlSet][4]&lt;[TResult][4]>  
A new [SqlSet&lt;TResult>][4] whose elements are sorted according to *columnList*.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: OrderBy.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: README.md