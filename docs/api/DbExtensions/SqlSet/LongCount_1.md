SqlSet.LongCount Method (String)
================================
Returns an [Int64][1] that represents how many elements in the set satisfy a condition.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public long LongCount(
	string predicate
)
```

### Parameters

#### *predicate*
Type: [System.String][3]  
A SQL expression to test each row for a condition.

### Return Value
Type: [Int64][1]  
A number that represents how many elements in the set satisfy the condition in the *predicate*.

Exceptions
----------

Exception              | Condition                                              
---------------------- | ------------------------------------------------------ 
[OverflowException][4] | The number of matching elements exceeds [MaxValue][5]. 


See Also
--------

### Reference
[SqlSet Class][6]  
[DbExtensions Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/6yy583ek
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/41ktf3wy
[5]: http://msdn.microsoft.com/en-us/library/xkeewe20
[6]: README.md