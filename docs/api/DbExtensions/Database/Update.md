Database.Update(Object) Method
==============================
Executes an UPDATE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                        | Description                                            |
| ---------------- | --------------------------- | ------------------------------------------------------ |
| ![Public method] | **Update(Object)**          | Executes an UPDATE command for the specified *entity*. |
| ![Public method] | [Update(Object, Object)][2] | Executes an UPDATE command for the specified *entity*. |


Syntax
------

```csharp
public void Update(
	Object entity
)
```

#### Parameters

##### *entity*  [Object][3]
The entity whose UPDATE command is to be executed.


Remarks
-------
This method is a shortcut for `db.Table(entity.GetType()).Update(entity)`.

See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][1]  
[SqlTable.Update(Object)][5]  

[1]: ../README.md
[2]: Update_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: README.md
[5]: ../SqlTable/Update.md
[Public method]: ../../icons/pubmethod.svg "Public method"