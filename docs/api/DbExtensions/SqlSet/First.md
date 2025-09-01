SqlSet.First Method
===================
Returns the first element of the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                         | Description                                                                |
| ---------------- | ---------------------------- | -------------------------------------------------------------------------- |
| ![Public method] | **First()**                  | Returns the first element of the set.                                      |
| ![Public method] | [First(String, Object[])][2] | Returns the first element in the set that satisfies a specified condition. |


Syntax
------

```csharp
public Object First()
```

#### Return Value
[Object][3]  
The first element in the set.

Exceptions
----------

| Exception                      | Condition         |
| ------------------------------ | ----------------- |
| [InvalidOperationException][4] | The set is empty. |


See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: First_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception
[5]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"