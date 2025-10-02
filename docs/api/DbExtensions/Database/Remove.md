Database.Remove Method
======================
Executes a DELETE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public bool Remove(
	Object entity
)
```

#### Parameters

##### *entity*  [Object][2]
The entity whose DELETE command is to be executed.

#### Return Value
[Boolean][3]  
`true` if *entity* is deleted; otherwise, `false`.

Remarks
-------
This method is a shortcut for `db.Table(entity.GetType()).Remove(entity)`.

See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][1]  
[SqlTable.Remove(Object)][5]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: https://learn.microsoft.com/dotnet/api/system.boolean
[4]: README.md
[5]: ../SqlTable/Remove.md