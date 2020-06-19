SqlSet.LongCount Method
=======================
Returns an [Int64][1] that represents the total number of elements in the set.

  **Namespace:**  [DbExtensions][2]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public long LongCount()
```

#### Return Value
Type: [Int64][1]  
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
[DbExtensions Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/6yy583ek
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/41ktf3wy
[4]: http://msdn.microsoft.com/en-us/library/xkeewe20
[5]: README.md