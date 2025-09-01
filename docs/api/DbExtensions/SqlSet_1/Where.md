SqlSet&lt;TResult>.Where(SqlSet.SqlFragmentHandler) Method
==========================================================
Filters the set based on a predicate.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                          | Description                           |
| ---------------- | ----------------------------- | ------------------------------------- |
| ![Public method] | **Where(SqlFragmentHandler)** | Filters the set based on a predicate. |
| ![Public method] | [Where(String)][2]            | Filters the set based on a predicate. |


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
[SqlSet][3]&lt;[TResult][3]>  
A new [SqlSet&lt;TResult>][3] that contains elements from the current set that satisfy the condition.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Where_1.md
[3]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"