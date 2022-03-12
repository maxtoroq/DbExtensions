SqlSet.Include Method
=====================
Specifies the related objects to include in the query results.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet Include(
	string path
)
```

#### Parameters

##### *path*
Type: [System.String][2]  
Dot-separated list of related objects to return in the query results.

#### Return Value
Type: [SqlSet][3]  
A new [SqlSet][3] with the defined query path.

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][4] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: http://msdn.microsoft.com/en-us/library/2asft85a