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
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: https://docs.microsoft.com/dotnet/api/system.object
[4]: https://docs.microsoft.com/dotnet/api/system.int32
[5]: https://docs.microsoft.com/dotnet/api/system.overflowexception
[6]: https://docs.microsoft.com/dotnet/api/system.int32.maxvalue
[7]: README.md