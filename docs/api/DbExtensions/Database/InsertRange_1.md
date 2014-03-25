Database.InsertRange Method (Object[])
======================================
Executes INSERT commands for the specified *entities*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
[ObsoleteAttribute("Please use Table<TEntity>().InsertRange or Table(Type).InsertRange instead.")]
public void InsertRange(
	params Object[] entities
)
```

### Parameters

#### *entities*
Type: [System.Object][2][]  
The entities whose INSERT commands are to be executed.


See Also
--------
[Database Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: README.md