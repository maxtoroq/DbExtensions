SqlSet.Count Method
===================
  Returns the number of elements in the set.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public int Count()
```

#### Return Value
Type: [Int32][2]  
The number of elements in the set.

Exceptions
----------

Exception              | Condition                                            
---------------------- | ---------------------------------------------------- 
[OverflowException][3] | The number of elements is larger than [MaxValue][4]. 


See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/td2s409d
[3]: http://msdn.microsoft.com/en-us/library/41ktf3wy
[4]: http://msdn.microsoft.com/en-us/library/92chhbf3
[5]: README.md