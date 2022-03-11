SqlSet.Any Method (String, Object[])
====================================
Determines whether any element of the set satisfies a condition.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public bool Any(
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
Type: [Boolean][4]  
true if any elements in the set pass the test in the specified *predicate*; otherwise, false.

See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: http://msdn.microsoft.com/en-us/library/a28wyd50
[5]: README.md