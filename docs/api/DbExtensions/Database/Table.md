Database.Table Method (MetaType)
================================
Returns the [SqlTable][1] instance for the specified *metaType*.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
protected internal SqlTable Table(
	MetaType metaType
)
```

### Parameters

#### *metaType*
Type: [System.Data.Linq.Mapping.MetaType][3]  
The [MetaType][3] of the entity.

### Return Value
Type: [SqlTable][1]  
The [SqlTable][1] instance for *metaType*.

See Also
--------
[Database Class][4]  
[DbExtensions Namespace][2]  

[1]: ../SqlTable/README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/bb534517
[4]: README.md