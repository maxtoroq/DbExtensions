SqlTable.Update Method (Object, Object)
=======================================
Executes an UPDATE command for the specified *entity*.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public void Update(
	Object entity,
	Object originalId
)
```

#### Parameters

##### *entity*
Type: [System.Object][2]  
The entity whose UPDATE command is to be executed.

##### *originalId*
Type: [System.Object][2]  
The original primary key value.


Remarks
-------
This overload is helpful when the entity uses an assigned primary key.

See Also
--------

#### Reference
[SqlTable Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: README.md