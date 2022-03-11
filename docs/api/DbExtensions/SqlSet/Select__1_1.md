SqlSet.Select&lt;TResult> Method (String, Object[])
===================================================
Projects each element of the set into a new form.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	string columnList,
	params Object[] parameters
)

```

#### Parameters

##### *columnList*
Type: [System.String][2]  
The list of columns that maps to properties on TResult.

##### *parameters*
Type: [System.Object][3][]  
The parameters to apply to the *columnList*.

#### Type Parameters

##### *TResult*
The type that *columnList* maps to.

#### Return Value
Type: [SqlSet][4]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][4].

See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../SqlSet_1/README.md
[5]: README.md