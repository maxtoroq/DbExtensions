Database.Update(Object, Object) Method
======================================
Executes an UPDATE command for the specified *entity*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                       | Description                                            |
| ---------------- | -------------------------- | ------------------------------------------------------ |
| ![Public method] | [Update(Object)][2]        | Executes an UPDATE command for the specified *entity*. |
| ![Public method] | **Update(Object, Object)** | Executes an UPDATE command for the specified *entity*. |


Syntax
------

```csharp
public void Update(
	Object entity,
	Object originalId
)
```

#### Parameters

##### *entity*  [Object][3]
The entity whose UPDATE command is to be executed.

##### *originalId*  [Object][3]
The original primary key value.


Remarks
-------
This method is a shortcut for `db.Table(entity.GetType()).Update(entity, originalId)`.

See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][1]  
[SqlTable.Update(Object, Object)][5]  

[1]: ../README.md
[2]: Update.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: README.md
[5]: ../SqlTable/Update_1.md
[Public method]: ../../icons/pubmethod.svg "Public method"