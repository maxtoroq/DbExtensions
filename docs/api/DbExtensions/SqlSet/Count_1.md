SqlSet.Count Method (String)
============================
Returns a number that represents how many elements in the set satisfy a condition.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public int Count(
	string predicate
)
```

### Parameters

#### *predicate*
Type: [System.String][2]  
A SQL expression to test each row for a condition.

### Return Value
Type: [Int32][3]  
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
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/td2s409d
[4]: http://msdn.microsoft.com/en-us/library/41ktf3wy
[5]: http://msdn.microsoft.com/en-us/library/92chhbf3
[6]: README.md