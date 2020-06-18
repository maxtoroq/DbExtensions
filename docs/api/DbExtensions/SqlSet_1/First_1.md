SqlSet&lt;TResult>.First Method (String, Object[])
==================================================
  Returns the first element in the set that satisfies a specified condition.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public TResult First(
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
Type: [TResult][4]  
The first element in the set that passes the test in the specified *predicate*.

Exceptions
----------

Exception                      | Condition                                                               
------------------------------ | ----------------------------------------------------------------------- 
[InvalidOperationException][5] | No element satisfies the condition in *predicate*.-or-The set is empty. 


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: README.md
[5]: http://msdn.microsoft.com/en-us/library/2asft85a