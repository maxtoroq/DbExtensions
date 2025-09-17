SqlSet.SingleOrDefault Method
=============================
Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                        | Description                                                                                                                                                                                              |
| ------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **SingleOrDefault()**                       | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| [SingleOrDefault(OperatorStringHandler)][2] | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefault(String)][3]                | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |


Syntax
------

```csharp
public Object? SingleOrDefault()
```

#### Return Value
[Object][4]  
The single element of the set, or a default value if the set contains no elements.

Exceptions
----------

| Exception                      | Condition                               |
| ------------------------------ | --------------------------------------- |
| [InvalidOperationException][5] | The set contains more than one element. |


See Also
--------

#### Reference
[SqlSet Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: SingleOrDefault_1.md
[3]: SingleOrDefault_2.md
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception
[6]: README.md