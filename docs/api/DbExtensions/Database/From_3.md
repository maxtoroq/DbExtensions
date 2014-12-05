Database.From Method (String, Type)
===================================
Creates and returns a new [SqlSet][1] using the provided table name.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet From(
	string tableName,
	Type resultType
)
```

### Parameters

#### *tableName*
Type: [System.String][3]  
The name of the table that will be the source of data for the set.

#### *resultType*
Type: [System.Type][4]  
The type of objects to map the results to.

### Return Value
Type: [SqlSet][1]  
A new [SqlSet][1] object.

See Also
--------

### Reference
[Database Class][5]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet/README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/42892f65
[5]: README.md