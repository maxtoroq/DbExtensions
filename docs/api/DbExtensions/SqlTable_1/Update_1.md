SqlTable&lt;TEntity>.Update Method (TEntity, Object)
====================================================
Executes an UPDATE command for the specified *entity*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void Update(
	TEntity entity,
	Object originalId
)
```

#### Parameters

##### *entity*
Type: [TEntity][2]  
The entity whose UPDATE command is to be executed.

##### *originalId*
Type: [System.Object][3]  
The original primary key value.


Remarks
-------
This overload is helpful when the entity uses an assigned primary key.

See Also
--------

#### Reference
[SqlTable&lt;TEntity> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b