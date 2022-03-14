SqlSet.Select Method (Type, String, Object[])
=============================================
Projects each element of the set into a new form.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet Select(
	Type resultType,
	string columnList,
	params Object[] parameters
)
```

#### Parameters

##### *resultType*
Type: [System.Type][2]  
The type that *columnList* maps to.

##### *columnList*
Type: [System.String][3]  
The list of columns that maps to properties on *resultType*.

##### *parameters*
Type: [System.Object][4][]  
The parameters to apply to the *columnList*.

#### Return Value
Type: [SqlSet][5]  
A new [SqlSet][5].

See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.type
[3]: https://docs.microsoft.com/dotnet/api/system.string
[4]: https://docs.microsoft.com/dotnet/api/system.object
[5]: README.md