SqlTable&lt;TEntity>.RemoveKey Method
=====================================
Executes a DELETE command for the entity whose primary key matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public bool RemoveKey(
	Object id
)
```

#### Parameters

##### *id*  [Object][2]
The primary key value.

#### Return Value
[Boolean][3]  
`true` if a record that matches *id* was found and deleted; otherwise, `false`.

See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: https://learn.microsoft.com/dotnet/api/system.boolean
[4]: README.md