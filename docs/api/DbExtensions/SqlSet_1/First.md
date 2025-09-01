SqlSet&lt;TResult>.First Method
===============================
Returns the first element of the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                           | Description                                                                |
| ---------------- | ------------------------------ | -------------------------------------------------------------------------- |
| ![Public method] | First()                        | Returns the first element of the set.                                      |
| ![Public method] | [First(SqlFragmentHandler)][2] | Returns the first element in the set that satisfies a specified condition. |
| ![Public method] | [First(String)][3]             | Returns the first element in the set that satisfies a specified condition. |


Syntax
------

```csharp
public TResult First()
```

#### Return Value
[TResult][4]  
The first element in the set.

Exceptions
----------

| Exception                      | Condition         |
| ------------------------------ | ----------------- |
| [InvalidOperationException][5] | The set is empty. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: First_1.md
[3]: First_2.md
[4]: README.md
[5]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception
[Public method]: ../../icons/pubmethod.svg "Public method"