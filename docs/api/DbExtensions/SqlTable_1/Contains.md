SqlTable&lt;TEntity>.Contains(TEntity) Method
=============================================
Checks the existance of the *entity*, using the primary key value.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                  | Description                                                        |
| ---------------- | --------------------- | ------------------------------------------------------------------ |
| ![Public method] | [Contains(Object)][2] | Checks the existance of the *entity*, using the primary key value. |
| ![Public method] | **Contains(TEntity)** | Checks the existance of the *entity*, using the primary key value. |


Syntax
------

```csharp
public bool Contains(
	TEntity entity
)
```

#### Parameters

##### *entity*  [TEntity][3]
The entity whose existance is to be checked.

#### Return Value
[Boolean][4]  
true if the primary key value exists in the database; otherwise false.

See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlSet_1/Contains.md
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.boolean
[Public method]: ../../icons/pubmethod.svg "Public method"