SqlCommandBuilder&lt;TEntity>.DELETE_FROM_WHERE_id Method
=========================================================
Creates and returns a DELETE command for the entity whose primary key matches the *id* parameter.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder DELETE_FROM_WHERE_id(
	Object id
)
```

### Parameters

#### *id*
Type: [System.Object][2]  
The primary key value.

### Return Value
Type: [SqlBuilder][3]  
The DELETE command the entity whose primary key matches the *id* parameter.

See Also
--------
[SqlCommandBuilder&lt;TEntity> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../SqlBuilder/README.md
[4]: README.md