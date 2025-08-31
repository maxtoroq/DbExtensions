SqlSet&lt;TResult>.Where(SqlSet.SqlFragmentHandler) Method
==========================================================
Filters the set based on a predicate.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet<TResult> Where(
	ref SqlFragmentHandler predicate
)
```

#### Parameters

##### *predicate*  SqlFragmentHandler
A SQL expression to test each row for a condition.

#### Return Value
[SqlSet][2]&lt;[TResult][2]>  
A new [SqlSet&lt;TResult>][2] that contains elements from the current set that satisfy the condition.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md