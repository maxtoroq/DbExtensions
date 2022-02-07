SqlSet.ContainsKey Method
=========================
Checks the existance of an entity whose primary matches the *id* parameter.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public bool ContainsKey(
	Object id
)
```

#### Parameters

##### *id*
Type: [System.Object][2]  
The primary key value.

#### Return Value
Type: [Boolean][3]  
true if the primary key value exists in the database; otherwise false.

Exceptions
----------

Exception                      | Condition                                                                         
------------------------------ | --------------------------------------------------------------------------------- 
[InvalidOperationException][4] | This method can only be used on sets where the result type is an annotated class. 


See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: http://msdn.microsoft.com/en-us/library/2asft85a
[5]: README.md