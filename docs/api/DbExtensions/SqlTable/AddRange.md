SqlTable.AddRange Method (IEnumerable&lt;Object>)
=================================================
  Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void AddRange(
	IEnumerable<Object> entities
)
```

#### Parameters

##### *entities*
Type: [System.Collections.Generic.IEnumerable][2]&lt;[Object][3]>  
The entities whose INSERT commands are to be executed.


See Also
--------

#### Reference
[SqlTable Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/9eekhta0
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: README.md