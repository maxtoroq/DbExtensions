SqlSet.SingleOrDefault Method
=============================
Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public Object SingleOrDefault()
```

#### Return Value
Type: [Object][2]  
The single element of the set, or a default value if the set contains no elements.

Exceptions
----------

Exception                      | Condition                               
------------------------------ | --------------------------------------- 
[InvalidOperationException][3] | The set contains more than one element. 


See Also
--------

#### Reference
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: http://msdn.microsoft.com/en-us/library/2asft85a
[4]: README.md