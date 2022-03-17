SqlSet&lt;TResult>.Skip Method
==============================
Bypasses a specified number of elements in the set and then returns the remaining elements.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet<TResult> Skip(
	int count
)
```

#### Parameters

##### *count*
Type: [System.Int32][2]  
The number of elements to skip before returning the remaining elements.

#### Return Value
Type: [SqlSet][3]&lt;[TResult][3]>  
A new [SqlSet&lt;TResult>][3] that contains the elements that occur after the specified index in the current set.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.int32
[3]: README.md