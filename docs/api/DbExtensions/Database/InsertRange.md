Database.InsertRange Method (IEnumerable&lt;Object>)
====================================================
Executes INSERT commands for the specified *entities*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
[ObsoleteAttribute("Please use Table<TEntity>().InsertRange or Table(Type).InsertRange instead.")]
public void InsertRange(
	IEnumerable<Object> entities
)
```

### Parameters

#### *entities*
Type: [System.Collections.Generic.IEnumerable][2]&lt;[Object][3]>  
The entities whose INSERT commands are to be executed.


See Also
--------
[Database Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/9eekhta0
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: README.md