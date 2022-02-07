SqlSet&lt;TResult>.Contains Method (Object)
===========================================
Checks the existance of the *entity*, using the primary key value.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public bool Contains(
	Object entity
)
```

#### Parameters

##### *entity*
Type: [System.Object][2]  
The entity whose existance is to be checked.

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
[SqlSet&lt;TResult> Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: http://msdn.microsoft.com/en-us/library/2asft85a
[5]: README.md