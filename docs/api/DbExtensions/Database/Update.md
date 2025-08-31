Database.Update(Object) Method
==============================
Executes an UPDATE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public void Update(
	Object entity
)
```

#### Parameters

##### *entity*  [Object][2]
The entity whose UPDATE command is to be executed.


Remarks
-------
This method is a shortcut for `db.Table(entity.GetType()).Update(entity)`.

See Also
--------

#### Reference
[Database Class][3]  
[DbExtensions Namespace][1]  
[Update(Object)][4]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: README.md
[4]: ../SqlTable/Update.md