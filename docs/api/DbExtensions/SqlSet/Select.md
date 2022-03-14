SqlSet.Select Method (String, Object[])
=======================================
Projects each element of the set into a new form.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet Select(
	string columnList,
	params Object[] parameters
)
```

#### Parameters

##### *columnList*
Type: [System.String][2]  
The list of columns to select.

##### *parameters*
Type: [System.Object][3][]  
The parameters to apply to the *columnList*.

#### Return Value
Type: [SqlSet][4]  
A new [SqlSet][4].

See Also
--------

#### Reference
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: https://docs.microsoft.com/dotnet/api/system.object
[4]: README.md