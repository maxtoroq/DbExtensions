Database.Exists Method
======================
Checks if *query* would return at least one row.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public bool Exists(
	SqlBuilder query
)
```

### Parameters

#### *query*
Type: [DbExtensions.SqlBuilder][2]  
The query whose existance is to be checked.

### Return Value
Type: [Boolean][3]  
true if *query* contains any rows; otherwise, false.

See Also
--------

### Reference
[Database Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: README.md