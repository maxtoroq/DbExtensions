SqlTable.Cast(Type) Method
==========================
Casts the elements of the set to the specified type.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                    | Description                                                                        |
| ---------------- | ----------------------- | ---------------------------------------------------------------------------------- |
| ![Public method] | **Cast(Type)**          | Casts the elements of the set to the specified type.                               |
| ![Public method] | [Cast&lt;TEntity>()][2] | Casts the current [SqlTable][3] to the generic [SqlTable&lt;TEntity>][4] instance. |


Syntax
------

```csharp
public SqlSet Cast(
	Type resultType
)
```

#### Parameters

##### *resultType*  [Type][5]
The type to cast the elements of the set to.

#### Return Value
[SqlSet][6]  
A new [SqlSet][6] that contains each element of the current set cast to the specified type.

See Also
--------

#### Reference
[SqlTable Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Cast__1.md
[3]: README.md
[4]: ../SqlTable_1/README.md
[5]: https://learn.microsoft.com/dotnet/api/system.type
[6]: ../SqlSet/README.md
[Public method]: ../../icons/pubmethod.svg "Public method"