SqlTable.RemoveRange Method (IEnumerable&lt;Object>)
====================================================
Executes DELETE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][1].

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void RemoveRange(
	IEnumerable<Object> entities
)
```

### Parameters

#### *entities*
Type: [System.Collections.Generic.IEnumerable][3]&lt;[Object][4]>  
The entities whose DELETE commands are to be executed.


See Also
--------
[SqlTable Class][5]  
[DbExtensions Namespace][2]  

[1]: ../ConcurrencyConflictPolicy/README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/9eekhta0
[4]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[5]: README.md