SqlSet.Select(String, Type) Method
==================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet Select(
	string columnList,
	Type resultType
)
```

#### Parameters

##### *columnList*  [String][2]
The list of columns that maps to properties on *resultType*.

##### *resultType*  [Type][3]
The type that *columnList* maps to.

#### Return Value
[SqlSet][4]  
A new [SqlSet][4].

See Also
--------

#### Reference
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: https://learn.microsoft.com/dotnet/api/system.type
[4]: README.md