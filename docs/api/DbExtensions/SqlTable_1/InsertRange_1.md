SqlTable&lt;TEntity>.InsertRange Method (IEnumerable&lt;TEntity>, Boolean)
==========================================================================
Executes INSERT commands for the specified *entities*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void InsertRange(
	IEnumerable<TEntity> entities,
	bool deep
)
```

### Parameters

#### *entities*
Type: [System.Collections.Generic.IEnumerable][2]&lt;[TEntity][3]>  
The entities whose INSERT commands are to be executed.

#### *deep*
Type: [System.Boolean][4]  
true to recursively execute INSERT commands for each entity's one-to-many associations; otherwise, false.


See Also
--------
[SqlTable&lt;TEntity> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/9eekhta0
[3]: README.md
[4]: http://msdn.microsoft.com/en-us/library/a28wyd50