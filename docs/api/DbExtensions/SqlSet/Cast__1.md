SqlSet.Cast&lt;TResult> Method
==============================
Casts the elements of the set to the specified type.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet<TResult> Cast<TResult>()
```


Type Parameters
---------------

#### *TResult*
The type to cast the elements of the set to.

### Return Value
Type: [SqlSet][2]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][2] that contains each element of the current set cast to the specified type.

See Also
--------
[SqlSet Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlSet_1/README.md
[3]: README.md