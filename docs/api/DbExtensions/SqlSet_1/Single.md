SqlSet&lt;TResult>.Single Method
================================
The single element of the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                               | Description                                                                                                                             |
| ---------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| **Single()**                       | The single element of the set.                                                                                                          |
| [Single(OperatorStringHandler)][2] | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. |
| [Single(String)][3]                | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. |


Syntax
------

```csharp
public TResult Single()
```

#### Return Value
[TResult][4]  
The single element of the set.

Exceptions
----------

| Exception                      | Condition                                                    |
| ------------------------------ | ------------------------------------------------------------ |
| [InvalidOperationException][5] | The set contains more than one element.-or-The set is empty. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Single_1.md
[3]: Single_2.md
[4]: README.md
[5]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception