SqlSet.LongCount Method (String, Object[])
==========================================
Returns an [Int64][1] that represents how many elements in the set satisfy a condition.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public long LongCount(
	string predicate,
	params Object[] parameters
)
```

### Parameters

#### *predicate*
Type: [System.String][3]  
A SQL expression to test each row for a condition.

#### *parameters*
Type: [System.Object][4][]  
The parameters to apply to the *predicate*.

### Return Value
Type: [Int64][1]  
A number that represents how many elements in the set satisfy the condition in the *predicate*.

Exceptions
----------

Exception              | Condition                                              
---------------------- | ------------------------------------------------------ 
[OverflowException][5] | The number of matching elements exceeds [MaxValue][6]. 


See Also
--------
[SqlSet Class][7]  
[DbExtensions Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/6yy583ek
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[5]: http://msdn.microsoft.com/en-us/library/41ktf3wy
[6]: http://msdn.microsoft.com/en-us/library/xkeewe20
[7]: README.md