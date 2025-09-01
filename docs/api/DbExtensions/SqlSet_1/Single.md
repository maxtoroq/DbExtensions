SqlSet&lt;TResult>.Single Method
================================
The single element of the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                          | Description                                                                                                                             |
| ---------------- | ----------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | **Single()**                  | The single element of the set.                                                                                                          |
| ![Public method] | [Single(String, Object[])][2] | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. |


Syntax
------

```csharp
public TResult Single()
```

#### Return Value
[TResult][3]  
The single element of the set.

Exceptions
----------

| Exception                      | Condition                                                    |
| ------------------------------ | ------------------------------------------------------------ |
| [InvalidOperationException][4] | The set contains more than one element.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Single_1.md
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception
[Public method]: ../../icons/pubmethod.svg "Public method"