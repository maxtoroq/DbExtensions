Database.Table&lt;TEntity> Method
=================================
Returns the [SqlTable&lt;TEntity>][1] instance for the specified TEntity.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                    | Description                                                               |
| ----------------------- | ------------------------------------------------------------------------- |
| [Table(Type)][3]        | Returns the [SqlTable][4] instance for the specified *entityType*.        |
| **Table&lt;TEntity>()** | Returns the [SqlTable&lt;TEntity>][1] instance for the specified TEntity. |


Syntax
------

```csharp
public SqlTable<TEntity> Table<TEntity>()
where TEntity : class

```

#### Type Parameters

##### *TEntity*
The type of the entity.

#### Return Value
[SqlTable][1]&lt;**TEntity**>  
The [SqlTable&lt;TEntity>][1] instance for TEntity.

See Also
--------

#### Reference
[Database Class][5]  
[DbExtensions Namespace][2]  

[1]: ../SqlTable_1/README.md
[2]: ../README.md
[3]: Table.md
[4]: ../SqlTable/README.md
[5]: README.md