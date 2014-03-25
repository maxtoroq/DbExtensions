SqlCommandBuilder&lt;TEntity>.SELECT_ Method (String)
=====================================================
Creates and returns a SELECT query for the current table that includes the SELECT clause only. All column names are qualified with the provided *tableAlias*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder SELECT_(
	string tableAlias
)
```

### Parameters

#### *tableAlias*
Type: [System.String][2]  
The table alias.

### Return Value
Type: [SqlBuilder][3]  
The SELECT query for the current table.

See Also
--------
[SqlCommandBuilder<TEntity> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../SqlBuilder/README.md
[4]: README.md