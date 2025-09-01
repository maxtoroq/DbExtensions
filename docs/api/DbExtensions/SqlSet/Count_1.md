SqlSet.Count(String, Object[]) Method
=====================================
Returns a number that represents how many elements in the set satisfy a condition.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                        | Description                                                                        |
| ---------------- | --------------------------- | ---------------------------------------------------------------------------------- |
| ![Public method] | [Count()][2]                | Returns the number of elements in the set.                                         |
| ![Public method] | **Count(String, Object[])** | Returns a number that represents how many elements in the set satisfy a condition. |


Syntax
------

```csharp
public int Count(
	string predicate,
	params Object[] parameters
)
```

#### Parameters

##### *predicate*  [String][3]
A SQL expression to test each row for a condition.

##### *parameters*  [Object][4][]
The parameters to apply to the predicate.

#### Return Value
[Int32][5]  
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
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Count.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: https://learn.microsoft.com/dotnet/api/system.int32
[6]: https://learn.microsoft.com/dotnet/api/system.overflowexception
[7]: https://learn.microsoft.com/dotnet/api/system.int32.maxvalue
[8]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"