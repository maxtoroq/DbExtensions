SqlSet&lt;TResult>.SingleOrDefault Method
=========================================
Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public TResult SingleOrDefault()
```

### Return Value
Type: [TResult][2]  
The single element of the set, or a default value if the set contains no elements.

Exceptions
----------

Exception                      | Condition                               
------------------------------ | --------------------------------------- 
[InvalidOperationException][3] | The set contains more than one element. 


See Also
--------

### Reference
[SqlSet&lt;TResult> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: http://msdn.microsoft.com/en-us/library/2asft85a