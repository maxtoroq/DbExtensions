SqlSet.Count Method (String, Object[])
======================================
Returns a number that represents how many elements in the set satisfy a condition.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public int Count(
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
The parameters to apply to the predicate.

#### Return Value
Type: [Int32][4]  
A number that represents how many elements in the set satisfy the condition in the *predicate*.

Exceptions
----------

| Exception              | Condition                                              |
| ---------------------- | ------------------------------------------------------ |
| [OverflowException][5] | The number of matching elements exceeds [MaxValue][6]. |


See Also
--------

#### Reference
[SqlSet Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: http://msdn.microsoft.com/en-us/library/td2s409d
[5]: http://msdn.microsoft.com/en-us/library/41ktf3wy
[6]: http://msdn.microsoft.com/en-us/library/92chhbf3
[7]: README.md