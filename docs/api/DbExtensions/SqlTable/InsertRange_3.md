SqlTable.InsertRange Method (Object[], Boolean)
===============================================
Executes INSERT commands for the specified *entities*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void InsertRange(
	Object[] entities,
	bool deep
)
```

### Parameters

#### *entities*
Type: [System.Object][2][]  
The entities whose INSERT commands are to be executed.

#### *deep*
Type: [System.Boolean][3]  
true to recursively execute INSERT commands for each entity's one-to-many associations; otherwise, false.


See Also
--------
[SqlTable Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: README.md