SqlCommandBuilder&lt;TEntity>.BuildDeleteStatementForKey Method
===============================================================
Creates and returns a DELETE command for the entity whose primary key matches the *id* parameter.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder BuildDeleteStatementForKey(
	Object id
)
```

#### Parameters

##### *id*
Type: [System.Object][2]  
The primary key value.

#### Return Value
Type: [SqlBuilder][3]  
The DELETE command the entity whose primary key matches the *id* parameter.

See Also
--------

#### Reference
[SqlCommandBuilder&lt;TEntity> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: ../SqlBuilder/README.md
[4]: README.md