SqlSet.First Method (String)
============================
Returns the first element in the set that satisfies a specified condition.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public Object First(
	string predicate
)
```

### Parameters

#### *predicate*
Type: [System.String][2]  
A SQL expression to test each row for a condition.

### Return Value
Type: [Object][3]  
The first element in the set that passes the test in the specified *predicate*.

Exceptions
----------

Exception                      | Condition                                                               
------------------------------ | ----------------------------------------------------------------------- 
[InvalidOperationException][4] | No element satisfies the condition in *predicate*.-or-The set is empty. 


See Also
--------
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: http://msdn.microsoft.com/en-us/library/2asft85a
[5]: README.md