SqlSet&lt;TResult>.Contains Method (TResult)
============================================
  Checks the existance of the *entity*, using the primary key value.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public bool Contains(
	TResult entity
)
```

#### Parameters

##### *entity*
Type: [TResult][2]  
The entity whose existance is to be checked.

#### Return Value
Type: [Boolean][3]  
true if the primary key value exists in the database; otherwise false.

Remarks
-------
 This method can only be used on sets where the result type is an annotated class. 

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50