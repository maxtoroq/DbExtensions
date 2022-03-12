SqlSet.Find Method
==================
Gets the entity whose primary key matches the *id* parameter.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

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

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][3] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: http://msdn.microsoft.com/en-us/library/2asft85a
[4]: README.md