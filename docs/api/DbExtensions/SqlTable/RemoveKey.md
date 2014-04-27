SqlTable.RemoveKey Method (Object)
==================================
Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the default [ConcurrencyConflictPolicy][1].

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public void RemoveKey(
	Object id
)
```

### Parameters

#### *id*
Type: [System.Object][3]  
The primary key value.


See Also
--------
[SqlTable Class][4]  
[DbExtensions Namespace][2]  

[1]: ../ConcurrencyConflictPolicy/README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: README.md