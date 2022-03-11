SqlSet&lt;TResult>.Find Method
==============================
Gets the entity whose primary key matches the *id* parameter.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public TResult Find(
	Object id
)
```

#### Parameters

##### *id*
Type: [System.Object][2]  
The primary key value.

#### Return Value
Type: [TResult][3]  
 The entity whose primary key matches the *id* parameter, or null if the *id* does not exist. 

Exceptions
----------

Exception                      | Condition                                                                         
------------------------------ | --------------------------------------------------------------------------------- 
[InvalidOperationException][4] | This method can only be used on sets where the result type is an annotated class. 


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: README.md
[4]: http://msdn.microsoft.com/en-us/library/2asft85a