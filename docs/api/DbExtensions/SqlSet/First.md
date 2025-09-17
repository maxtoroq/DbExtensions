SqlSet.First Method
===================
Returns the first element of the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                              | Description                                                                |
| --------------------------------- | -------------------------------------------------------------------------- |
| **First()**                       | Returns the first element of the set.                                      |
| [First(OperatorStringHandler)][2] | Returns the first element in the set that satisfies a specified condition. |
| [First(String)][3]                | Returns the first element in the set that satisfies a specified condition. |


Syntax
------

```csharp
public Object First()
```

#### Return Value
[Object][4]  
The first element in the set.

Exceptions
----------

| Exception                      | Condition         |
| ------------------------------ | ----------------- |
| [InvalidOperationException][5] | The set is empty. |


See Also
--------

#### Reference
[SqlSet Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: First_1.md
[3]: First_2.md
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception
[6]: README.md