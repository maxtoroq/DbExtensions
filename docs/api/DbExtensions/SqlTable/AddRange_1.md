SqlTable.AddRange Method (Object[])
===================================
Recursively executes INSERT commands for the specified *entities* and all it's one-to-one and one-to-many associations. Recursion can be disabled by setting [EnableInsertRecursion][1] to false.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void AddRange(
	params Object[] entities
)
```

### Parameters

#### *entities*
Type: [System.Object][3][]  
The entities whose INSERT commands are to be executed.


See Also
--------
[SqlTable Class][4]  
[DbExtensions Namespace][2]  

[1]: ../DatabaseConfiguration/EnableInsertRecursion.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: README.md