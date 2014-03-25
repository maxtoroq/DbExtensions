SqlTable&lt;TEntity>.Contains Method (TEntity, Boolean)
=======================================================
Checks the existance of the *entity*, using the primary key and optionally version column.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public bool Contains(
	TEntity entity,
	bool version
)
```

### Parameters

#### *entity*
Type: [TEntity][2]  
The entity whose existance is to be checked.

#### *version*
Type: [System.Boolean][3]  
true to check the version column; otherwise, false.

### Return Value
Type: [Boolean][3]  
true if the primary key and version combination exists in the database; otherwise, false.

See Also
--------
[SqlTable&lt;TEntity> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50