Database.Table&lt;TEntity> Method
=================================
Returns the [SqlTable&lt;TEntity>][1] instance for the specified TEntity.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlTable<TEntity> Table<TEntity>()
where TEntity : class
```


Type Parameters
---------------

#### *TEntity*
The type of the entity.

### Return Value
Type: [SqlTable][1]&lt;**TEntity**>  
The [SqlTable&lt;TEntity>][1] instance for TEntity.

See Also
--------
[Database Class][3]  
[DbExtensions Namespace][2]  

[1]: ../SqlTable_1/README.md
[2]: ../README.md
[3]: README.md