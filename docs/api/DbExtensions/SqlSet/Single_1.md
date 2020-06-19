SqlSet.Single Method (String, Object[])
=======================================
Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public Object Single(
	string predicate,
	params Object[] parameters
)
```

#### Parameters

##### *predicate*
Type: [System.String][2]  
A SQL expression to test each row for a condition.

##### *parameters*
Type: [System.Object][3][]  
The parameters to apply to the *predicate*.

#### Return Value
Type: [Object][3]  
The single element of the set that passes the test in the specified *predicate*.

Exceptions
----------

Exception                      | Condition                                                                                                                                
------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------- 
[InvalidOperationException][4] | No element satisfies the condition in *predicate*.-or-More than one element satisfies the condition in *predicate*.-or-The set is empty. 


See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: http://msdn.microsoft.com/en-us/library/2asft85a
[5]: README.md