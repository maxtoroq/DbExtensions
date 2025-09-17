Database.Table(Type) Method
===========================
Returns the [SqlTable][1] instance for the specified *entityType*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                     | Description                                                               |
| ------------------------ | ------------------------------------------------------------------------- |
| **Table(Type)**          | Returns the [SqlTable][1] instance for the specified *entityType*.        |
| [Table&lt;TEntity>()][3] | Returns the [SqlTable&lt;TEntity>][4] instance for the specified TEntity. |


Syntax
------

```csharp
public SqlTable Table(
	Type entityType
)
```

#### Parameters

##### *entityType*  [Type][5]
The type of the entity.

#### Return Value
[SqlTable][1]  
The [SqlTable][1] instance for *entityType*.

See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][2]  

[1]: ../SqlTable/README.md
[2]: ../README.md
[3]: Table__1.md
[4]: ../SqlTable_1/README.md
[5]: https://learn.microsoft.com/dotnet/api/system.type
[6]: README.md