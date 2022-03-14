SqlSet.Count Method
===================
Returns the number of elements in the set.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public int Count()
```

#### Return Value
Type: [Int32][2]  
The number of elements in the set.

Exceptions
----------

| Exception              | Condition                                            |
| ---------------------- | ---------------------------------------------------- |
| [OverflowException][3] | The number of elements is larger than [MaxValue][4]. |


See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.int32
[3]: https://docs.microsoft.com/dotnet/api/system.overflowexception
[4]: https://docs.microsoft.com/dotnet/api/system.int32.maxvalue
[5]: README.md