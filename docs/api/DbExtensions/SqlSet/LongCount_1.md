SqlSet.LongCount Method (String, Object[])
==========================================
Returns an [Int64][1] that represents how many elements in the set satisfy a condition.

  **Namespace:**  [DbExtensions][2]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public long LongCount(
	string predicate,
	params Object[] parameters
)
```

#### Parameters

##### *predicate*
Type: [System.String][3]  
A SQL expression to test each row for a condition.

##### *parameters*
Type: [System.Object][4][]  
The parameters to apply to the *predicate*.

#### Return Value
Type: [Int64][1]  
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
[DbExtensions Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.int64
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/system.string
[4]: https://docs.microsoft.com/dotnet/api/system.object
[5]: https://docs.microsoft.com/dotnet/api/system.overflowexception
[6]: https://docs.microsoft.com/dotnet/api/system.int64.maxvalue
[7]: README.md