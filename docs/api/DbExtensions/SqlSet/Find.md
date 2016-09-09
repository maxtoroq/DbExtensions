SqlSet.Find Method
==================
Gets the entity whose primary key matches the *id* parameter.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public Object Find(
	Object id
)
```

#### Parameters

##### *id*
Type: [System.Object][2]  
The primary key value.

#### Return Value
Type: [Object][2]  
 The entity whose primary key matches the *id* parameter, or null if the *id* does not exist. 

Remarks
-------
 This method can only be used on mapped sets created by [Database][3]. 

See Also
--------

#### Reference
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../Database/README.md
[4]: README.md