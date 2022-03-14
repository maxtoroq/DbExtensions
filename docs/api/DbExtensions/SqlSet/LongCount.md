SqlSet.LongCount Method
=======================
Returns an [Int64][1] that represents the total number of elements in the set.

  **Namespace:**  [DbExtensions][2]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public long LongCount()
```

#### Return Value
Type: [Int64][1]  
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
[DbExtensions Namespace][2]  

[1]: https://docs.microsoft.com/dotnet/api/system.int64
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/system.overflowexception
[4]: https://docs.microsoft.com/dotnet/api/system.int64.maxvalue
[5]: README.md