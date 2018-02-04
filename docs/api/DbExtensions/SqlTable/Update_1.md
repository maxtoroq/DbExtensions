SqlTable.Update Method (Object, Object)
=======================================
Executes an UPDATE command for the specified *entity*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

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
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: README.md