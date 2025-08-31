SqlSet.Select(SqlSet.SqlFragmentHandler, Type) Method
=====================================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet Select(
	ref SqlFragmentHandler columnList,
	Type resultType
)
```

#### Parameters

##### *columnList*  SqlFragmentHandler
The list of columns that maps to properties on *resultType*.

##### *resultType*  [Type][2]
The type that *columnList* maps to.

#### Return Value
[SqlSet][3]  
A new [SqlSet][3].

See Also
--------

#### Reference
[SqlSet Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.type
[3]: README.md