SqlSet&lt;TResult>.OrderBy(SqlSet.OperatorStringHandler) Method
===============================================================
Sorts the elements of the set according to the *columnList*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                               | Description                                                  |
| ---------------------------------- | ------------------------------------------------------------ |
| **OrderBy(OperatorStringHandler)** | Sorts the elements of the set according to the *columnList*. |
| [OrderBy(String)][2]               | Sorts the elements of the set according to the *columnList*. |


Syntax
------

```csharp
public SqlSet<TResult> OrderBy(
	ref OperatorStringHandler columnList
)
```

#### Parameters

##### *columnList*  OperatorStringHandler
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