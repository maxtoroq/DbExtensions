SqlSet.LongCount(String, Object[]) Method
=========================================
Returns an [Int64][1] that represents how many elements in the set satisfy a condition.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                            | Description                                                                             |
| ---------------- | ------------------------------- | --------------------------------------------------------------------------------------- |
| ![Public method] | [LongCount()][3]                | Returns an [Int64][1] that represents the total number of elements in the set.          |
| ![Public method] | **LongCount(String, Object[])** | Returns an [Int64][1] that represents how many elements in the set satisfy a condition. |


Syntax
------

```csharp
public long LongCount(
	string predicate,
	params Object[] parameters
)
```

#### Parameters

##### *predicate*  [String][4]
A SQL expression to test each row for a condition.

##### *parameters*  [Object][5][]
The parameters to apply to the *predicate*.

#### Return Value
[Int64][1]  
A number that represents how many elements in the set satisfy the condition in the *predicate*.

Exceptions
----------

| Exception              | Condition                                              |
| ---------------------- | ------------------------------------------------------ |
| [OverflowException][6] | The number of matching elements exceeds [MaxValue][7]. |


See Also
--------

#### Reference
[SqlSet Class][8]  
[DbExtensions Namespace][2]  

[1]: https://learn.microsoft.com/dotnet/api/system.int64
[2]: ../README.md
[3]: LongCount.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: https://learn.microsoft.com/dotnet/api/system.object
[6]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[7]: https://learn.microsoft.com/dotnet/api/system.int64.maxvalue
[8]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"