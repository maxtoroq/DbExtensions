SqlSet.Count Method
===================
Returns the number of elements in the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                         | Description                                                                        |
| ---------------- | ---------------------------- | ---------------------------------------------------------------------------------- |
| ![Public method] | **Count()**                  | Returns the number of elements in the set.                                         |
| ![Public method] | [Count(String, Object[])][2] | Returns a number that represents how many elements in the set satisfy a condition. |


Syntax
------

```csharp
public int Count()
```

#### Return Value
[Int32][3]  
The number of elements in the set.

Exceptions
----------

| Exception              | Condition                                            |
| ---------------------- | ---------------------------------------------------- |
| [OverflowException][4] | The number of elements is larger than [MaxValue][5]. |


See Also
--------

#### Reference
[SqlSet Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Count_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.int32
[4]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[5]: https://learn.microsoft.com/dotnet/api/system.int32.maxvalue
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"