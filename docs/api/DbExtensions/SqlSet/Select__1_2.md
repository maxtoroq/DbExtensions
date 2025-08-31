SqlSet.Select&lt;TResult>(String) Method
========================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	string columnList
)

```

#### Parameters

##### *columnList*  [String][2]
The list of columns that maps to properties on TResult.

#### Type Parameters

##### *TResult*
The type that *columnList* maps to.

#### Return Value
[SqlSet][3]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][3].

See Also
--------

#### Reference
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: ../SqlSet_1/README.md
[4]: README.md