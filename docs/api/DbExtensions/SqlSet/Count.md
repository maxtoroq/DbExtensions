SqlSet.Count Method
===================
Returns the number of elements in the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                              | Description                                                                        |
| --------------------------------- | ---------------------------------------------------------------------------------- |
| **Count()**                       | Returns the number of elements in the set.                                         |
| [Count(OperatorStringHandler)][2] | Returns a number that represents how many elements in the set satisfy a condition. |
| [Count(String)][3]                | Returns a number that represents how many elements in the set satisfy a condition. |


Syntax
------

```csharp
public int Count()
```

#### Return Value
[Int32][4]  
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
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Count_1.md
[3]: Count_2.md
[4]: https://learn.microsoft.com/dotnet/api/system.int32
[5]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[6]: https://learn.microsoft.com/dotnet/api/system.int32.maxvalue
[7]: README.md