SqlTable.Cast&lt;TEntity> Method
================================
Casts the current [SqlTable][1] to the generic [SqlTable&lt;TEntity>][2] instance.

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlTable<TEntity> Cast<TEntity>()
where TEntity : class

```

### Type Parameters

#### *TEntity*
The type of the entity.

### Return Value
Type: [SqlTable][2]&lt;**TEntity**>  
The [SqlTable&lt;TEntity>][2] instance for TEntity.

Exceptions
----------

Exception                      | Condition                                             
------------------------------ | ----------------------------------------------------- 
[InvalidOperationException][4] | The specified TEntity is not valid for this instance. 


See Also
--------
[SqlTable Class][1]  
[DbExtensions Namespace][3]  

[1]: README.md
[2]: ../SqlTable_1/README.md
[3]: ../README.md
[4]: http://msdn.microsoft.com/en-us/library/2asft85a