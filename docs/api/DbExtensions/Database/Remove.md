Database.Remove Method
======================
Executes a DELETE command for the specified *entity*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void Remove(
	Object entity
)
```

#### Parameters

##### *entity*
Type: [System.Object][2]  
The entity whose DELETE command is to be executed.


Remarks
-------
This method is a shortcut for `db.Table(entity.GetType()).Remove(entity)`.

See Also
--------

#### Reference
[Database Class][3]  
[DbExtensions Namespace][1]  
[SqlTable.Remove(Object)][4]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: README.md
[4]: ../SqlTable/Remove.md