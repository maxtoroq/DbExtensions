SqlSet&lt;TResult>.Single Method
================================
The single element of the set.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public TResult Single()
```

### Return Value
Type: [TResult][2]  
The single element of the set.

Exceptions
----------

Exception                      | Condition                                                    
------------------------------ | ------------------------------------------------------------ 
[InvalidOperationException][3] | The set contains more than one element.-or-The set is empty. 


See Also
--------

### Reference
[SqlSet&lt;TResult> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: http://msdn.microsoft.com/en-us/library/2asft85a