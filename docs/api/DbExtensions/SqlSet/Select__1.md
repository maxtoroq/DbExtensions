SqlSet.Select&lt;TResult>(SqlSet.SqlFragmentHandler) Method
===========================================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	ref SqlFragmentHandler columnList
)

```

#### Parameters

##### *columnList*  SqlFragmentHandler
The list of columns that maps to properties on TResult.

#### Type Parameters

##### *TResult*
The type that *columnList* maps to.

#### Return Value
[SqlSet][2]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][2].

See Also
--------

#### Reference
[SqlSet Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlSet_1/README.md
[3]: README.md