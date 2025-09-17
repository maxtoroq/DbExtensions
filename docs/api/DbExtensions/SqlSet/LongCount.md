SqlSet.LongCount Method
=======================
Returns an [Int64][1] that represents the total number of elements in the set.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                  | Description                                                                             |
| ------------------------------------- | --------------------------------------------------------------------------------------- |
| **LongCount()**                       | Returns an [Int64][1] that represents the total number of elements in the set.          |
| [LongCount(OperatorStringHandler)][3] | Returns an [Int64][1] that represents how many elements in the set satisfy a condition. |
| [LongCount(String)][4]                | Returns an [Int64][1] that represents how many elements in the set satisfy a condition. |


Syntax
------

```csharp
public long LongCount()
```

#### Return Value
[Int64][1]  
The number of elements in the set.

Exceptions
----------

| Exception              | Condition                                            |
| ---------------------- | ---------------------------------------------------- |
| [OverflowException][5] | The number of elements is larger than [MaxValue][6]. |


See Also
--------

#### Reference
[SqlSet Class][7]  
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.int64
[2]: ../README.md
[3]: LongCount_1.md
[4]: LongCount_2.md
[5]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[6]: https://learn.microsoft.com/dotnet/api/system.int64.maxvalue
[7]: README.md