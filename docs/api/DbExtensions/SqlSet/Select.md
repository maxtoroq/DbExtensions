SqlSet.Select Method (Type, String)
===================================
Projects each element of the set into a new form.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet Select(
	Type resultType,
	string columnList
)
```

### Parameters

#### *resultType*
Type: [System.Type][2]  
The type that *columnList* maps to.

#### *columnList*
Type: [System.String][3]  
The list of columns that maps to properties on *resultType*.

### Return Value
Type: [SqlSet][4]  
A new [SqlSet][4].

See Also
--------
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/42892f65
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: README.md